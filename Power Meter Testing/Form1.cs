using System;
using System.IO;
using System.Windows.Forms;
using System.Threading;
using System.Linq;
using System.Collections.Generic;
using Excel = Microsoft.Office.Interop.Excel;
using System.Diagnostics;
using Thorlabs.PM100D_32.Interop;
using Thorlabs.MotionControl.DeviceManagerCLI;
using Thorlabs.MotionControl.FilterFlipperCLI;
using Thorlabs.MotionControl.GenericMotorCLI;
using System.Drawing;
using System.Globalization;
using System.Runtime.InteropServices;

//Written by Gabriel Marth
//Spring 2018
//If you have any questions/concerns/etc, email me at gmarth@thorlabs.com

//Probably rename to transmission testing device?

namespace Power_Meter_Testing
{
    public partial class frmTester : Form
    {
        public static string FileFolder; //Folder in which test logs are stored
        public static bool ProgramOn; //Variable to check if program has run a test so far.
        public static bool FlipperOn, PowerMeterOn; //Variables to check if hardware components are activated.
        public static double[] BaseResults = new double[4]; //Baseline results array
        public static double[] SampleResults = new double[4]; //Sample results array
        public static bool IntervalOn, TimedMeasure; //Booleans to check if if a rate of samples/sec or stepped averaging have been activated.
        public double StartTime; //Time at which the testing run was started
        public static double SamplesPerSecond; //Variable to help determine how long test will take to run

        public frmTester()
        {
            //Sets up the program to run. Form defaults are filled in and variables are assigned values.
            InitializeComponent();
            txtDate.Text = DateTime.Today.ToString("MM/dd/yyyy");
            ProgramOn = false;
            FileFolder = txtFolder.Text;
            txtTimeSetCheck.Text = "Not set";
            txtIntSetCheck.Text = "Not set";
            txtCurrentPosition.Text = "Activate flipper first";
            Methods.SleepTime = 0;
            Methods.Det1 = txtD1Name.Text;
            Methods.Det2 = txtD2Name.Text;
            Methods.BaseCountMax = Convert.ToInt32(txtBaseCountNum.Text);
            Methods.SampleCountMax = Convert.ToInt32(txtSampCountNum.Text);
            Methods.TargetOD = Convert.ToDouble(txtTargetOD.Text);
            Methods.PosTol = Convert.ToDouble(txtPosTol.Text);
            Methods.NegTol = Convert.ToDouble(txtNegTol.Text);
            Methods.Wavelength = Convert.ToDouble(txtWavelength.Text);
            Methods.LogPath = txtLogLoc.Text;
            txtStatus.Text = "Program Opened";
            txtExportStatus.Text = "Waiting for test";
            //Sets last test number on startup
            if(Methods.FolderExists() == false)
            {
                Methods.TestCount = 0;
                txtTestNum.Text = "N/A";
                Methods.CreateFolder();
            }
            else if(Methods.FolderExists() == true)
            {
                Methods.TestCount = Methods.GetLastTestCount();
                if(Methods.TestCount == 0)
                {
                    txtTestNum.Text = "N/A";
                }
                else
                {
                    txtTestNum.Text = Convert.ToString(Methods.TestCount);
                }
            }
        }

        private void cmdViewFile_Click(object sender, EventArgs e)
        {
            //Procedure to view last test file created. Will only work if a test has been run that day so far.
            if (txtFilePath.Text != "")
            {
                Process.Start(txtFilePath.Text + ".xlsx");
            }
            else
            {
                MessageBox.Show("You must conduct a test first.");
            }
        }

        private void cmdStart_Click(object sender, EventArgs e)
        {
            //Main program procedure. Calls various other functions to accomplish a test.
            for (int i = 1; i <= 1; i++)
            {
                ClearData();
                StartTime = DateTime.Now.ToOADate();
                txtStatus.Text = "Test Starting";
                Methods.TestCount++;
                Methods.Wavelength = Convert.ToDouble(txtWavelength.Text);
                Methods.BaseCountMax = Convert.ToInt32(txtBaseCountNum.Text);
                Methods.SampleCountMax = Convert.ToInt32(txtSampCountNum.Text);
                if (!ProgramOn == true)
                {
                    if (FlipperOn != true) //Checks if flipper is activated, if not activates it.
                    {
                        FlipperControl.PrepareFlipper();
                        FlipperControl.MoveFlipper(FlipperControl.Flipper, 2);
                        FlipperOn = true;
                    }

                    if (PowerMeterOn != true) //Checks if the power meters are activated, if not activates them.
                    {
                        Methods.CreatePowerMeters();
                        DialogResult dr = MessageBox.Show("Would you like to do a dark current adustment procedure?" +
                            " It is recommended each time the sensors are activated the first time, and will produce better accuracy.",
                            "Dark Current Adjustment", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if(dr == DialogResult.Yes)
                        {
                            Methods.pm1.startDarkAdjust();
                            Methods.pm2.startDarkAdjust();
                            Thread.Sleep(10000);
                        }
                    }
                }
                else
                {
                    FlipperControl.MoveFlipper(FlipperControl.Flipper, 2);
                }
                Methods.pm1.setWavelength(Methods.Wavelength);
                Methods.pm2.setWavelength(Methods.Wavelength);
                BaselineStep();
                Thread.Sleep(10000);
                SampleStep();
                txtStatus.Text = "Measurement done";
                ExcelStep();
                txtTestNum.Text = Convert.ToString(Methods.TestCount);
                txtFilePath.Text = Methods.DefineFilePath();
                ResultStep();
                ProgramOn = true;
            }
        }

        public void ExcelStep()
        {
            bool _createcheck = Methods.CreateExcelDoc();
            if (_createcheck == true)
            {
                try
                {
                    txtExportStatus.Text = "File created";
                    Methods.FormatExcel();
                    txtExportStatus.Text = "Data exporting";
                    Methods.PopulateExcel();
                    txtExportStatus.Text = "Export complete";
                    Methods.SaveExcelDoc();
                    txtExportStatus.Text = "Editing program log";
                    Methods.PopulateLogExcel();
                    foreach (Process proc in System.Diagnostics.Process.GetProcessesByName("EXCEL"))
                    {
                        proc.Kill();
                    }
                    txtExportStatus.Text = "All exports complete";
                }
                catch
                {
                    MessageBox.Show("There was an error encountered during the data export step. The data from the last test was not saved.");
                    return;
                }
            }
            else if (_createcheck == false)
            {
                txtExportStatus.Text = "Problem encountered creating Excel file.";
                return;
            }
            
        }

        public void BaselineStep()
        {
            txtStatus.Text = "Testing baseline";
            try
            {
                Methods.BaseCount = 0;
                if (IntervalOn == false)
                {
                    Methods.BaseArray = Methods.BaseMeasurement();
                }
                else
                {
                    Methods.BaseArray = Methods.IntervalBaseMeasurement();
                }
                BaseResults = Methods.BaseAverages();
                txtBaseD1.Text = BaseResults[0].ToString("e4", CultureInfo.InvariantCulture);
                txtBaseD2.Text = BaseResults[1].ToString("e4", CultureInfo.InvariantCulture);
                txtBaseRatio.Text = BaseResults[2].ToString("F5", CultureInfo.InvariantCulture);
            }
            catch
            {
                MessageBox.Show("There was an issue during the baseline measurement step. No data was taken.");
                return;
            }
        }

        public void SampleStep()
        {
            txtStatus.Text = "Testing sample";
            Thread.Sleep(500);
            try
            {
                Methods.SampleCount = 0;
                FlipperControl.MoveFlipper(FlipperControl.Flipper, 1);
                txtStatus.Text = "Testing sample";
                Thread.Sleep(500);
                if(IntervalOn == false)
                {
                    Methods.SampleArray = Methods.SampleMeasurement();
                }
                else
                {
                    Methods.SampleArray = Methods.IntervalSampleMeasurement();
                }
                SampleResults = Methods.SampleAverages();
                txtSampD1.Text = SampleResults[0].ToString("e4", CultureInfo.InvariantCulture);
                txtSampD2.Text = SampleResults[1].ToString("e4", CultureInfo.InvariantCulture);
                txtSampRatio.Text = SampleResults[2].ToString("F5", CultureInfo.InvariantCulture);
                txtSampPerc.Text = SampleResults[3].ToString("F5", CultureInfo.InvariantCulture);
            }
            catch
            {
                MessageBox.Show("There was an issue during the sample measurement step. No data was taken.");
                return;
            }
        }

        public void ResultStep()
        {
            double ResultOD = Math.Log10(100/SampleResults[3]);
            txtResultOD.Text = ResultOD.ToString("F5", CultureInfo.InvariantCulture);
            Methods.PosTol = Convert.ToDouble(txtPosTol.Text);
            Methods.NegTol = Convert.ToDouble(txtNegTol.Text);
            if(ResultOD <= (Methods.TargetOD + Methods.PosTol) && ResultOD >= (Methods.TargetOD - Methods.NegTol))
            {
                PassNotice.BackColor = Color.Green;
            }
            else
            {
                FailNotice.BackColor = Color.Red;
            }
            txtStatus.Text = "Test complete";
        }

        private void txtTargetOD_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Check characters entered in target OD box. No negatives or letters.
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtTargetOD_TextChanged(object sender, EventArgs e)
        {
            //Ensures valid input into target OD textbox. No blanks or decimal points by themselves.
            if (txtTargetOD.Text != "" && txtTargetOD.Text != ".")
            {
                Methods.TargetOD = Convert.ToDouble(txtTargetOD.Text);
            }
        }

        private void txtWavelength_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Check characters entered in target wavelength text box. No negatives or letters.
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtWavelength_TextChanged(object sender, EventArgs e)
        {
            //Ensures valid input into wavelength textbox. No blanks or decimal points by themselves.
            if (txtWavelength.Text != "" && txtWavelength.Text != ".")
            {
                //Checks that the entered wavelength is in the usable range for the power sensors.
                if (Convert.ToDouble(txtWavelength.Text) >= 400 && Convert.ToDouble(txtWavelength.Text) <= 1100)
                {
                    if (!PowerMeterOn == true)
                    {
                        Methods.CreatePowerMeters();
                    }
                    Methods.Wavelength = Convert.ToDouble(txtWavelength.Text);
                    Methods.pm1.setWavelength(Methods.Wavelength);
                    Methods.pm2.setWavelength(Methods.Wavelength);
                }
                else if(Convert.ToDouble(txtWavelength.Text) < 400 && Convert.ToDouble(txtWavelength.Text) > 1100)
                {
                    MessageBox.Show("You must enter a wavelength between 400-1100nm. The power senesor are silicon-based, so this is the usable range.");
                }
            }
        }

        private void txtPosTol_KeyPress(Object sender, KeyPressEventArgs e)
        {
            //Check characters entered in postive tolerance text box. No negatives or letters.
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtPosTol_TextChanged(object sender, EventArgs e)
        {
            //Ensures valid input into positive tolerance textbox. No blanks or decimal points by themselves.
            if (txtPosTol.Text != "" && txtPosTol.Text != ".")
            {
                Methods.PosTol = Convert.ToDouble(txtPosTol.Text);
            }
        }

        private void txtNegTol_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Check characters entered into negative tolerance text box. No negatives or letters.
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtNegTol_TextChanged(object sender, EventArgs e)
        {
            //Ensures valid input into negative tolerance textbox. No blanks or decimal points by themselves.
            if (txtNegTol.Text != "" && txtNegTol.Text != ".")
            {
                Methods.NegTol = Convert.ToDouble(txtNegTol.Text);
            }
            
        }

        private void txtFolder_TextChanged(object sender, EventArgs e)
        {
            //Sets folder that test folders are stored in. 
            FileFolder = txtFolder.Text;
        }

        private void cmdChooseFolder_Click(object sender, EventArgs e)
        {
            //Procedure for dealing with choosing a new folder to store test logs.
            MessageBox.Show("It is suggested that you use a network drive location. This allows others to access the tests taken.");
            FolderBrowserDialog FindFolder = new FolderBrowserDialog();
            if (FindFolder.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FileFolder = FindFolder.SelectedPath;
                txtFolder.Text = FileFolder;
            }
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtD1Name_TextChanged(object sender, EventArgs e)
        {
            //Sets power meter 1's name. Needed for initializing power meter.
            Methods.Det1 = txtD1Name.Text;
        }

        private void txtD2Name_TextChanged(object sender, EventArgs e)
        {
            //Sets power meter 2's name. Needed for initializing power meter.
            Methods.Det2 = txtD2Name.Text;
        }

        private void txtBaseCountNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtBaseCountNum_TextChanged(object sender, EventArgs e)
        {
            if(txtBaseCountNum.Text != "")
            {
                Methods.BaseCountMax = Convert.ToInt32(txtBaseCountNum.Text);
            }

        }

        private void txtSampCountNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Check characters entered into sample count text box. No negatives or letters.
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtSampCountNum_TextChanged(object sender, EventArgs e)
        {
            //Ensures valid input into sample count textbox. No blanks or decimal points by themselves.
            if (txtSampCountNum.Text != "")
            {
                Methods.SampleCountMax = Convert.ToInt32(txtSampCountNum.Text);
            }

        }

        private void txtStatus_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtIntSet_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Checks characters entered into step averaging text box. No negatives or letters.
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtIntSet_TextChanged(object sender, EventArgs e)
        {
            //Ensures valid unput into step averaging text box. No blanks or decimals.
            bool IntBool = IntEntryCheck();
            if (IntBool == true)
            {
                Methods.IntervalSet = Convert.ToInt32(txtIntSet.Text);
                txtIntSetCheck.Text = "Set";
            }
            else
            {
                txtIntSetCheck.Text = "Not set";
            }
        }

        public bool IntEntryCheck()
        {
            //Makes sure that the max data counts for the baseline and sample are evenly divisible by the entry in the stepm averaging box.
            if (txtIntSet.Text == "")
            {
                return false;
            }
            int IntNum = Convert.ToInt32(txtIntSet.Text);
            if (IntNum > Methods.BaseCountMax || IntNum > Methods.SampleCountMax)
            {
                MessageBox.Show("Your averaging interval is set higher than either the baseline or sample count maximum. Please lower the number.");
                return false;
            }
            else if (Convert.ToInt32(txtIntSet.Text) == 0)
            {
                MessageBox.Show("You cannot enter zero. Please choose another number.");
                txtIntSet.Text = "";
                return false;
            }
            else if (Methods.BaseCountMax % IntNum != 0 || Methods.SampleCountMax % IntNum != 0)
            {
                MessageBox.Show("The set baseline and sample count maximums must both be evenly divisible by the set averaging interval. Please adjust accordingly.");
                txtIntSet.Text = "";
                return false;
            }
            else
            {
                return true;
            }
        }

        private void txtTimedMeas_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Checks characters entered into the timed measuring text box. No negatives or letters.
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtTimedMeas_TextChanged(object sender, EventArgs e)
        {
            //Ensures valid unput into the timed measuring text box. No blanks or decimals.
            if (txtTimedMeas.Text != "" && Convert.ToDouble(txtTimedMeas.Text) != 0)
            {
                Methods.SleepTime = (1 / Convert.ToDouble(txtTimedMeas.Text)) * 1000;
                SamplesPerSecond = Convert.ToDouble(txtTimedMeas.Text);
                txtTimeEst.Text = Convert.ToString(Methods.TimeEstimate(SamplesPerSecond));
                txtTimeSetCheck.Text = "Set";
            }
            else if(txtTimedMeas.Text == "0")
            {
                MessageBox.Show("You cannot enter zero.");
                txtTimedMeas.Text = "";
            }
            if (txtTimedMeas.Text != "" && Convert.ToDouble(txtTimedMeas.Text) > 30)
            {
                MessageBox.Show("With no restrictions, the program only runs at around 30 samples per second. You have entered higher. The program will likely not achieve this speed, unless a large data count is entered.");
            }
        }

        private void cmdViewFolder_Click(object sender, EventArgs e)
        {
            //Command to view folder test log folders are stored in.
            Process.Start(txtFolder.Text);
        }

        public void txtBaseD1_TextChanged(object sender, EventArgs e)
        {

        }

        private void chkIntSet_CheckedChanged(object sender, EventArgs e)
        {
            //Procedure for dealing with the interval check being changed.
            if (chkIntSet.Checked == true && txtIntSet.Text != "")
            {
                Methods.IntervalNum = Convert.ToInt32(txtIntSet.Text);
                IntervalOn = true;
            }
            else if(chkIntSet.Checked == true && txtIntSet.Text == "")
            {
                MessageBox.Show("You must enter a interval before activating this control.");
                chkIntSet.Checked = false;
                IntervalOn = false;
            }
            else
            {
                IntervalOn = false;
            }
        }

        private void chkTimedMeas_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTimedMeas.Checked == true && txtTimedMeas.Text != "" && txtTimedMeas.Text != "0")
            {
                TimedMeasure = true;
                SamplesPerSecond = Convert.ToDouble(txtTimedMeas.Text);
                txtTimeEst.Text = Convert.ToString(Methods.TimeEstimate(SamplesPerSecond));
                Methods.SleepTime = (1/Convert.ToDouble(txtTimedMeas.Text)) * 1000;
            }
            else if (chkTimedMeas.Checked == true && txtTimedMeas.Text == "")
            {
                MessageBox.Show("You must enter a value for samples per second before activating this control.");
                chkTimedMeas.Checked = false;
                TimedMeasure = false;
                return;
            }
            else
            {
                TimedMeasure = false;
                txtTimeEst.Text = Convert.ToString(Methods.TimeEstimate(SamplesPerSecond));
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void lblLogLoc_Click(object sender, EventArgs e)
        {

        }

        private void txtLogLoc_TextChanged(object sender, EventArgs e)
        {
            //Sets log file path
            Methods.LogPath = txtLogLoc.Text;
        }

        private void cmdChooseLog_Click(object sender, EventArgs e)
        {
            //Procedure to allow choosing what log file is using
            OpenFileDialog FindFile = new OpenFileDialog();
            if (FindFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string LogFile;
                LogFile = FindFile.FileName.ToString();
                txtLogLoc.Text = LogFile;
            }
        }

        private void cmdViewLog_Click(object sender, EventArgs e)
        {
            Process.Start(txtLogLoc.Text);
        }

        private void tabSettings_Click(object sender, EventArgs e)
        {

        }

        private void cmdChangePosition_Click(object sender, EventArgs e)
        {

            if (FlipperControl.Flipper.Position == 1)
            {
                FlipperControl.MoveFlipper(FlipperControl.Flipper, 2);
                txtCurrentPosition.Text = "Position 2";
            }
            else
            {
                FlipperControl.MoveFlipper(FlipperControl.Flipper, 1);
                txtCurrentPosition.Text = "Position 1";
            }
        }

        private void cmdRefFile_Click(object sender, EventArgs e)
        {
            Methods.ReferenceOpen();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Keep as a testing ground
            double result;
            bool res;
            Methods.pm1.getDarkOffset(out result);
            MessageBox.Show(result.ToString());
            Methods.pm2.getDarkOffset(out result);
            MessageBox.Show(result.ToString());

        }

        private void cmdClearForms_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        public void ClearData()
        {
            //Clears various data boxes on the main form page.
            txtBaseD1.Clear();
            //txtBaseD1.Text = "";
            Thread.Sleep(100);
            //txtBaseD2.Text = "";
            txtBaseD2.Clear();
            Thread.Sleep(100);
            txtBaseRatio.Clear();
            //txtBaseRatio.Text = "";
            Thread.Sleep(100);
            txtSampD1.Clear();
            //txtSampD1.Text = "";
            Thread.Sleep(100);
            txtSampD2.Clear();
            //txtSampD2.Text = "";
            Thread.Sleep(100);
            txtSampRatio.Clear();
            //txtSampRatio.Text = "";
            Thread.Sleep(100);
            txtSampPerc.Clear();
            //txtSampPerc.Text = "";
            Thread.Sleep(100);
            txtResultOD.Clear();
            //txtResultOD.Text = "";
            Thread.Sleep(100);
            PassNotice.BackColor = SystemColors.Control;
            FailNotice.BackColor = SystemColors.Control;
            //I was running into issues with the boxes not actually clearing, creating confusion
        }
    }

    public class Methods
    {
        //Needed variable declarations
        public static string File;

        //Power meter variables
        public static string Det1 = "";
        public static string Det2 = "";
        public static PM100D pm1;
        public static PM100D pm2;

        public static void CreatePowerMeters()
        {
            //Function creates the power meters. Needs its own function, as multiple routes to initialization are present.
            pm1 = new PM100D(Det1, true, true);
            pm2 = new PM100D(Det2, true, true);
            frmTester.PowerMeterOn = true;
        }

        //Measurement variables
        public static double Power1, Power2, Power1Avg, Power2Avg;
        public static double Power1Sum, Power2Sum;
        public static double Wavelength;
        public static bool BaseMeasCheck;
        public static bool SampleMeasCheck;

        //Measurement setting variables
        public static int IntervalNum;
        public static double SleepTime;
        public static int BaseCountMax, SampleCountMax;
        public static int BaseCount, SampleCount;
        public static int TestCount;
        public static int IntervalSet;

        //Arrays that hold the power measurements
        //Need to be 1 larger than expected, as for loops start at 1
        //Easier to start at base 1, because of how Excel controls row & column naming
        public static double[,] BaseArray = new double[BaseCountMax + 1, 4];
        public static double[,] SampleArray = new double[SampleCountMax + 1, 4];
        public static TimeSpan[] BaseTimes = new TimeSpan[BaseCountMax + 1];
        public static TimeSpan[] SampleTimes = new TimeSpan[SampleCountMax + 1];
        public static int BaseDataMax, SampleDataMax;

        //Date related variables
        public static string CurrentDateString = DateTime.Today.ToString("MM/dd/yyyy");

        //File name and path related variables
        public static string FileNameDate = CurrentDateString.Replace("/", "-");

        //Target OD and tolerance variables:
        public static double TargetOD;
        public static double PosTol, NegTol;

        //Excel variables for test workbook
        public static Excel.Application appExcel = null;
        public static Excel.Workbook Workbook = null;
        public static Excel.Worksheet Worksheet = null;
        public static Excel.Range SheetRange = null;

        //Excel variables for log workbook
        public static Excel.Application logExcel = null;
        public static Excel.Workbook logBook = null;
        public static Excel.Worksheet logSheet = null;
        public static Excel.Range logRange = null;
        public static string LogPath = "";
        public static int logLast = 0;

        //Excel variables for reference file:
        public static Excel.Application refExcel = null;
        public static Excel.Workbook refBook = null;
        public static Excel.Worksheet refSheet = null;
        //Hardcoded, didn't want to add more options to change the path
        public static string refPath = @"\\thorlabs.local\NWT\OpticsBU\Users\Gabe Marth\2 Channel Project\Fresh Start - C#\Power Meter Testing";


        //Results variables
        public static double ResultOD, ResultPosUncert, ResultNegUncert;

        public static void CreateFolder()
        {
            //Creates the test log folder for the current day
            try
            {
                Directory.CreateDirectory(Convert.ToString(frmTester.FileFolder) + "\\" + FileNameDate + "\\");
            }
            catch
            {
                MessageBox.Show("There was an error creating the folder.");
            }
        }

        public static bool CreateExcelDoc()
        {
            //Creates the test Excel doc for data insertion
            try
            {
                appExcel = new Excel.Application();
                appExcel.Visible = false;
                Workbook = appExcel.Workbooks.Add(1);
                Worksheet = (Excel.Worksheet)Workbook.Sheets[1];
                return true;
            }
            catch
            {
                MessageBox.Show("Error creating new Excel file.");
                return false;
            }
        }

        public static void SaveExcelDoc()
        {
            //Saves the test Excel doc
            string _localfilepath = DefineFilePath();
            object misValue = System.Reflection.Missing.Value;
            appExcel.DisplayAlerts = false;
            CreateFolder();
            Workbook.SaveAs(Convert.ToString(_localfilepath), Excel.XlFileFormat.xlWorkbookDefault,
                misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlShared,
                misValue, misValue, misValue, misValue, misValue);
        }

        public static void PopulateExcel()
        {
            //Populates the created test file with the recorded data
            double AvgSum = 0;
            //Baseline data insertion
            for (int i = 1; i <= BaseDataMax; i++)
            {
                Worksheet.Cells[i + 4, 1] = Convert.ToString(BaseArray[i, 0]);
                Marshal.ReleaseComObject(Worksheet.Cells[i + 4, 1]);
                Worksheet.Cells[i + 4, 2] = Convert.ToString(BaseArray[i, 1]);
                Worksheet.Cells[i + 4, 3] = Convert.ToString(BaseArray[i, 2]);
                Worksheet.Cells[i + 4, 4] = Convert.ToString(BaseArray[i, 3]);
                Worksheet.Cells[i + 4, 5] = Convert.ToString(Convert.ToDouble(BaseArray[i, 3] / BaseArray[i, 2]));
            }

            //Sample data insertion
            for (int i = 1; i <= SampleDataMax; i++)
            {
                Worksheet.Cells[i + 4, 7] = Convert.ToString(SampleArray[i, 0]);
                Worksheet.Cells[i + 4, 8] = Convert.ToString(SampleArray[i, 1]);
                Worksheet.Cells[i + 4, 9] = Convert.ToString(SampleArray[i, 2]);
                Worksheet.Cells[i + 4, 10] = Convert.ToString(SampleArray[i, 3]);
                Worksheet.Cells[i + 4, 11] = Convert.ToString(Convert.ToDouble(SampleArray[i, 3] / SampleArray[i, 2]));
                Worksheet.Cells[i + 4, 13] = Convert.ToString(Convert.ToDouble(-Math.Log10((SampleArray[i, 3] / SampleArray[i, 2]) / (BaseArray[i, 3] / BaseArray[i, 2]))));
                AvgSum += -Math.Log10((SampleArray[i, 3] / SampleArray[i, 2]) / (BaseArray[i, 3] / BaseArray[i, 2]));
            }

            //Calculates the OD result, which is then displayed on the program form
            //Also inserts tolerance specifications to the worksheet
            Worksheet.Cells[1, 5] = Convert.ToString(AvgSum / SampleDataMax);
            ResultOD = AvgSum / SampleDataMax;
            Worksheet.Cells[2, 5] = TargetOD;
            Worksheet.Cells[1, 8] = PosTol;
            Worksheet.Cells[2, 8] = NegTol;

            //Determines if the part passes or not, does not affect what is displayed on the program form (that does this check again on its own)
            if (ResultOD > (TargetOD - NegTol) && ResultOD < (TargetOD + PosTol))
            {
                Worksheet.Cells[1, 11] = "Yes";
            }
            else
            {
                Worksheet.Cells[1, 11] = "No";
            }
        }

        public static void FormatExcel()
        {
            //Header and Results Summary formatting
            Worksheet.Columns[2].NumberFormat = "hh:mm:ss";
            Worksheet.Columns[8].NumberFormat = "hh:mm:ss";
            Worksheet.Cells[1, 1] = "Test Date:";
            Worksheet.Cells[1, 1].Font.Bold = true;
            Worksheet.Range["B1", "B1"].NumberFormat = "mm/dd/yyyy";
            Worksheet.Range["B2", "B2"].NumberFormat = "####";
            Worksheet.Cells[1, 2] = CurrentDateString;
            Worksheet.Cells[2, 1] = "Test #:";
            Worksheet.Cells[2, 1].Font.Bold = true;
            Worksheet.Cells[2, 2] = Convert.ToString(TestCount);
            Worksheet.Cells[1, 4] = "Sample OD:";
            Worksheet.Cells[1, 4].Font.Bold = true;
            Worksheet.Cells[2, 4] = "Target OD:";
            Worksheet.Cells[2, 4].Font.Bold = true;
            Worksheet.Cells[1, 7] = "Positive Tolerance:";
            Worksheet.Cells[1, 7].Font.Bold = true;
            Worksheet.Cells[1, 7].WrapText = true;
            Worksheet.Cells[2, 7] = "Negative Tolerance:";
            Worksheet.Cells[2, 7].Font.Bold = true;
            Worksheet.Cells[2, 7].WrapText = true;
            Worksheet.Cells[1, 10] = "Test Pass:";
            Worksheet.Cells[1, 10].Font.Bold = true;
            Worksheet.Range["A1", "J1"].VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            Worksheet.Range["A2", "J2"].VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

            //Set baseline formatting
            Worksheet.Cells[4, 1] = "Baseline Test Count:";
            Worksheet.Cells[4, 2] = "Baseline Test Timestamps:";
            Worksheet.Cells[4, 3] = "Power Meter 1 Readings (mW):";
            Worksheet.Cells[4, 4] = "Power Meter 2 Readings (mW):";
            Worksheet.Cells[4, 5] = "Ratio:";

            for(int i = 1; i <= 13; i++)
            {
                Worksheet.Cells[4, i].Font.Bold = true;
            }

            //Set sample formatting
            Worksheet.Cells[4, 7] = "Sample Test Count:";
            Worksheet.Cells[4, 8] = "Sample Test Timestamps:";
            Worksheet.Cells[4, 9] = "Power Meter 1 Readings (mW):";
            Worksheet.Cells[4, 10] = "Power Meter 2 Readings (mW):";
            Worksheet.Cells[4, 11] = "Ratio:";
            Worksheet.Cells[4, 13] = "Optical Density:";

            //Row 4 formatting for next 2 sections
            Worksheet.Range["A4"].EntireRow.WrapText = true;
            Worksheet.Range["A4", "M4"].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            Worksheet.Range["A4", "M4"].VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            Worksheet.Range["A1", "H2"].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            Worksheet.Columns[2].ColumnWidth = 11.57;
            Worksheet.Columns[4].ColumnWidth = 11.57;
            Worksheet.Columns[5].ColumnWidth = 5.43;
            Worksheet.Columns[7].ColumnWidth = 11.57;
            Worksheet.Columns[8].ColumnWidth = 11.57;
            Worksheet.Columns[9].ColumnWidth = 11.43;
            Worksheet.Columns[11].ColumnWidth = 5.43;
            Worksheet.Columns[12].ColumnWidth = 5.43;
        }

        public static void PopulateLogExcel()
        {
            //This function opens and populates the longterm log file used in the program
            //All measurement and hardware settings are saved, as well as the actual results
            logLast = 0;
            logExcel = new Excel.Application();
            logExcel.Visible = false;
            logBook = logExcel.Workbooks.Open(LogPath);
            logSheet = logBook.ActiveSheet;
            logLast = logSheet.Range["C5:C1000000"].End[Excel.XlDirection.xlDown].Row + 1;
            //The above is definitely not the best way to accomplish finding the last row (hardcoding the range is less than ideal)
            logSheet.Cells[logLast, 1] = DateTime.Now;
            logSheet.Cells[logLast, 2] = TestCount;
            logSheet.Cells[logLast, 3] = FlipperControl.SerialNo;
            logSheet.Cells[logLast, 4] = Det1;
            logSheet.Cells[logLast, 5] = Det2;
            if (frmTester.IntervalOn == true)
            {
                logSheet.Cells[logLast, 6] = "True";
                logSheet.Cells[logLast, 7] = IntervalNum;
            }
            else
            {
                logSheet.Cells[logLast, 6] = "False";
                logSheet.Cells[logLast, 7] = "N/A";
            }
            if (frmTester.TimedMeasure == true)
            {
                logSheet.Cells[logLast, 8] = "True";
                logSheet.Cells[logLast, 9] = IntervalSet;
            }
            else
            {
                logSheet.Cells[logLast, 8] = "False";
                logSheet.Cells[logLast, 9] = "N/A";
            }
            logSheet.Cells[logLast, 10] = Wavelength;
            logSheet.Cells[logLast, 11] = TargetOD;
            logSheet.Cells[logLast, 12] = PosTol;
            logSheet.Cells[logLast, 13] = NegTol;
            logSheet.Cells[logLast, 14] = BaseCountMax;
            logSheet.Cells[logLast, 15] = frmTester.BaseResults[0];
            logSheet.Cells[logLast, 16] = frmTester.BaseResults[1];
            logSheet.Cells[logLast, 17] = frmTester.BaseResults[2];
            logSheet.Cells[logLast, 18] = SampleCountMax;
            logSheet.Cells[logLast, 19] = frmTester.SampleResults[0];
            logSheet.Cells[logLast, 20] = frmTester.SampleResults[1];
            logSheet.Cells[logLast, 21] = frmTester.SampleResults[2];
            logSheet.Cells[logLast, 22] = frmTester.SampleResults[3];
            logSheet.Cells[logLast, 23] = ResultOD;
            logSheet.Cells[logLast, 24] = ResultPosUncert;
            logSheet.Cells[logLast, 25] = ResultNegUncert;
            logLast = 0;
            logBook.Save();
            logBook.Close();
            logExcel.Quit();
        }

        public static void ReferenceOpen()
        {
            //Opens a reference file, containing the data from the website for our standard ND filters
            //Allows you to enter a product and wavelength to determine the expected OD
            //object misValue = System.Reflection.Missing.Value;
            //refExcel = new Excel.Application();
            //refExcel.Visible = true;
            //refBook = refExcel.Workbooks.Open(refPath, misValue,true, misValue, misValue, misValue, true, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue);
        }

        public static bool FolderExists()
        {
            //Checks to see if a folder already exists for test files from today
            string FolderCheckPath = Convert.ToString(frmTester.FileFolder) + "\\" + FileNameDate + "\\";
            if (Directory.Exists(FolderCheckPath) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string DefineFilePath()
        {
            //Defines file path for each test file
            string Folder = Convert.ToString(frmTester.FileFolder);
            string FilePath = Folder + "\\" + FileNameDate + "\\" + "Test " + Convert.ToString(TestCount);
            return FilePath;
        }

        public static double[,] BaseMeasurement()
        {
            //Baseline measurement procedure (no step averaging)
            BaseDataMax = BaseCountMax;
            double[,] BaseMeas = new double[BaseCountMax + 1, 4];
            for (int i = 1; i <= BaseDataMax; i++)
            {
                BaseCount = i;
                BaseMeas[i, 0] = Convert.ToDouble(BaseCount);
                pm1.measPower(out Power1);
                BaseMeas[i, 2] = Power1;
                pm2.measPower(out Power2);
                BaseMeas[i, 3] = Power2;
                BaseMeas[i, 1] = DateTime.Now.ToOADate();
                if (SleepTime > 0)
                {
                    Thread.Sleep(Convert.ToInt32(SleepTime));
                }
            }
            return BaseMeas;
        }

        public static double[,] SampleMeasurement()
        {
            //Sample measurement procedure (no step averaging)
            SampleDataMax = SampleCountMax;
            double[,] SampleMeas = new double[SampleCountMax + 1, 4];
            for (int i = 1; i <= SampleDataMax; i++)
            {
                SampleCount = i;
                SampleMeas[i, 0] = Convert.ToDouble(SampleCount);
                pm1.measPower(out Power1);
                SampleMeas[i, 2] = Power1;
                pm2.measPower(out Power2);
                SampleMeas[i, 3] = Power2;
                SampleMeas[i, 1] = DateTime.Now.ToOADate();
                if (SleepTime > 0)
                {
                    Thread.Sleep(Convert.ToInt32(SleepTime));
                }
            }
            return SampleMeas;
        }

        public static double[,] IntervalBaseMeasurement()
        {
            //Baseline measurement procedure using step averaging setting
            BaseDataMax = BaseCountMax / IntervalNum;
            double[,] IntBaseMeas = new double[BaseDataMax + 1, 4];
            double Sum1, Sum2, IntTestCount;
            for (int i = 1; i <= BaseDataMax; i++)
            {
                Sum1 = Sum2 = IntTestCount = 0;
                BaseCount++;
                for (int x = 1; x <= IntervalNum; x++)
                {
                    pm1.measPower(out Power1);
                    pm2.measPower(out Power2);
                    Sum1 += Power1;
                    Sum2 += Power2;
                    IntTestCount++;
                    if (SleepTime > 0)
                    {
                        Thread.Sleep(Convert.ToInt32(SleepTime));
                    }
                }
                IntBaseMeas[i, 0] = BaseCount;
                IntBaseMeas[i, 1] = DateTime.Now.ToOADate();
                IntBaseMeas[i, 2] = Sum1 / IntTestCount;
                IntBaseMeas[i, 3] = Sum2 / IntTestCount;
            }
            return IntBaseMeas;
        }

        public static double[,] IntervalSampleMeasurement()
        {
            //Sample measurement procedure using step averaging procedure
            SampleDataMax = SampleCountMax / IntervalNum;
            double[,] IntSampMeas = new double[SampleDataMax + 1, 4];
            double Sum1, Sum2, IntTestCount;
            for (int i = 1; i <= SampleDataMax; i++)
            {
                Sum1 = Sum2 = IntTestCount = 0;
                SampleCount++;
                for (int x = 1; x <= IntervalNum; x++)
                {
                    pm1.measPower(out Power1);
                    pm2.measPower(out Power2);
                    Sum1 += Power1;
                    Sum2 += Power2;
                    IntTestCount++;
                    if (SleepTime > 0)
                    {
                        Thread.Sleep(Convert.ToInt32(SleepTime));
                    }
                }
                IntSampMeas[i, 0] = SampleCount;
                IntSampMeas[i, 1] = DateTime.Now.ToOADate();
                IntSampMeas[i, 2] = Sum1 / IntTestCount;
                IntSampMeas[i, 3] = Sum2 / IntTestCount;
            }
            return IntSampMeas;
        }
        

        //Averaging functions for results
        public static double[] BaseAverages()
        {
            double[] BaseAvgs = new double[4];
            double BaseDenomDet1, BaseDenomDet2, BaseDenomRatio;
            BaseDenomDet1 = BaseDenomDet2 = BaseDenomRatio = 0;
            for(int i=1; i <= BaseDataMax; i++)
            {
                BaseDenomDet1 += BaseArray[i, 2];
                BaseDenomDet2 += BaseArray[i, 3];
                BaseDenomRatio += BaseArray[i, 3] / BaseArray[i, 2];
            }
            //Multiplying by 1000 to convert to mW from W.
            BaseAvgs[0] = BaseDenomDet1 / BaseCountMax * 1000;
            BaseAvgs[1] = BaseDenomDet2 / BaseCountMax * 1000;
            BaseAvgs[2] = BaseDenomRatio / BaseCountMax;
            return BaseAvgs;
        }

        public static double[]SampleAverages()
        {
            double[] SampleAvgs = new double[4];
            double SampleDenomDet1, SampleDenomDet2, SampleDenomRatio;
            SampleDenomDet1 = SampleDenomDet2 = SampleDenomRatio = 0;
            for (int i = 1; i <= SampleDataMax; i++)
            {
                SampleDenomDet1 += SampleArray[i, 2];
                SampleDenomDet2 += SampleArray[i, 3];
                SampleDenomRatio += SampleArray[i, 3] / SampleArray[i, 2];
            }

            //Multiplying by 1000 to convert to mW from W. Multiplying by 100 to get result in percent format.
            SampleAvgs[0] = SampleDenomDet1 / SampleCountMax * 1000;
            SampleAvgs[1] = SampleDenomDet2 / SampleCountMax * 1000;
            SampleAvgs[2] = SampleDenomRatio / SampleCountMax;
            SampleAvgs[3] = SampleAvgs[2] / frmTester.BaseResults[2] * 100;
            return SampleAvgs;
        }

        public static int GetLastTestCount()
        {
            //If the program is opened more than once during the same day, this function finds
            //the last test number and adjusts the display accordingly. If its the first time the
            //program is opened that day, it sets the test count to zero
            int LastTestNum = 0;
            string LastFile;
            string GetFilePath = Convert.ToString(frmTester.FileFolder) + "\\" + FileNameDate + "\\";
            string[] FileEntries = Directory.GetFiles(GetFilePath);
            if(FileEntries.Length > 0)
            {
                LastFile = FileEntries[FileEntries.Length - 1];
            }
            else
            {
                return LastTestNum = 0;
            }
            //This portion of the function removes the word "test" and the file extension
            //The program can only handle 999 samples per day. I didn't anticipate a scenario where
            //that number could be exceeded in one day (unless you're really trying to break the program)
            string EndingWithExt = LastFile.Substring(LastFile.Length - 9);
            string Ending = EndingWithExt.Remove(4, 5);
            string sLastTestNum = "";
            int number;
            foreach(char c in Ending)
            {
                bool result = int.TryParse(Convert.ToString(c), out number);
                if (result == true)
                {
                    sLastTestNum += c;
                }
            }
            LastTestNum = Convert.ToInt32(sLastTestNum);
            return LastTestNum;
        }

        public static double TimeEstimate(double SampSec)
        {
            //This function is meant to estimate the amount of time a test shoudl take based off the user entered
            //settings. It is currently wildly inaccurate, as it is hard to calculate how much computing time it will take
            //to prepare the test and propogate the data to Excel. The testing itself is relatively easy to figure out
            double SamplesPerSecond = SampSec;
            double BaseTime, SampleTime, TotalTime, DefaultRate;
            double MandatoryTime, FormPrep;

            DefaultRate = 35; //Default calculation rate for samples taken per second (30/s) if no other setting used
            FormPrep = 0.5; //Thread sleeping after clear data procedure, allows form to clear effectively
            MandatoryTime = FormPrep;

            if (frmTester.TimedMeasure == true)
            {
                BaseTime = BaseCountMax / SamplesPerSecond;
                SampleTime = SampleCountMax / SamplesPerSecond;

                TotalTime = BaseTime + SampleTime + MandatoryTime;
                return TotalTime;
            }
            else
            {
                BaseTime = BaseCountMax / DefaultRate;
                SampleTime = SampleCountMax / DefaultRate;

                TotalTime = BaseTime + SampleTime + MandatoryTime;
                return TotalTime;
            }
        }
    }


    //Beginning of the filter flipper functions
    public class FlipperControl
    {
        //Filter Flipper variables
        public static string SerialNo = "37000305"; //Change to control by textbox
        public static FilterFlipper Flipper = FilterFlipper.CreateFilterFlipper(SerialNo);

        //All flipper functions
        public static void BuildDeviceList()
        {
            //Builds the list of filter flippers connected to the computer
            //Necessary per the flipper documentation
            try
            {
                DeviceManagerCLI.BuildDeviceList();
            }
            catch
            {
                MessageBox.Show("There was an error building the device list.");
                return;
            }
        }

        public static bool CheckSerial()
        {
            //Checks to make sure the entered serial number is present on the connected device list
            bool FlipperSerialCheck;
            List<string> SerialNumbers = DeviceManagerCLI.GetDeviceList(FilterFlipper.DevicePrefix);
            if (!SerialNumbers.Contains(SerialNo))
            {
                FlipperSerialCheck = false;
            }
            else
            {
                FlipperSerialCheck = true;
            }
            return FlipperSerialCheck;
        }

        public static bool FlipperCheck()
        {
            //Checks if the specified device is actually a filter flipper
            if (Flipper == null)
            {
                MessageBox.Show("The specified device is not a filter flipper.");
                return false;
            }
            return true;
        }

        public static bool FlipperConnect()
        {
            //Connexts to the specified filter flipper, after confirming it exists and the right serial number is entered
            try
            {
                Flipper.Connect(SerialNo);
                return true;
            }
            catch
            {
                MessageBox.Show("There was an issue connecting to the flipper.");
                return false;
            }
        }

        public static bool FlipperSettingsCheck()
        {
            //Checks to make sure that the filter flipper settings are properly initialized for use
            if (!Flipper.IsSettingsInitialized())
            {
                try
                {
                    Flipper.WaitForSettingsInitialized(2500);
                    if (Flipper.IsSettingsInitialized() == true)
                    {
                        return true;
                    }
                }
                catch
                {
                    MessageBox.Show("Flipper settings failed to initialize.");
                    return false;
                }
            }
            return true;
        }

        public static void DeviceReady()
        {
            //Sets the filter flipper to a "ready" state for further instruction
            Flipper.StartPolling(1000);
            Thread.Sleep(1000);
            Flipper.EnableDevice();
            Thread.Sleep(1000);
        }

        public static void HomeFlipper()
        {
            //Homes the filter flipper
            try
            {
                Flipper.Home(15000); //15000 is the timeout settings. If it takes more than
                //15 seconds to home the device, it gives up and throws an exception (its in ms, hence 15000)
            }
            catch (Exception)
            {
                MessageBox.Show("The flipper failed to home properly.");
                return;
            }
        }

        public static void MoveFlipper(FilterFlipper device, uint position)
        {
            //Moves the filter flipper to the other position, timeout of 15 seconds
            try
            {
                device.SetPosition(position, 15000);
                Thread.Sleep(1000);
            }
            catch (Exception)
            {
                MessageBox.Show("An error occured while moving the filter flipper.");
                return;
            }
        }

        public static void PrepareFlipper()
        {
            //Filter preparation procedure
            BuildDeviceList();
            CheckSerial();
            FlipperCheck();
            FlipperConnect();
            FlipperSettingsCheck();
            DeviceReady();
            HomeFlipper();
        }
    }
}
