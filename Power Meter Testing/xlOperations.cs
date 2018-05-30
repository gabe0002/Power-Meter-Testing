using System;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;


namespace Power_Meter_Testing
{
    class xlOperations
    {
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

        //Variables from measurement that are needed
        public static int BaseDataMax;

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
            string _localfilepath = FileOperations.DefineFilePath();
            object misValue = System.Reflection.Missing.Value;
            appExcel.DisplayAlerts = false;
            FileOperations.CreateFolder();
            Workbook.SaveAs(Convert.ToString(_localfilepath), Excel.XlFileFormat.xlWorkbookDefault,
                misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlShared,
                misValue, misValue, misValue, misValue, misValue);
        }

        public static void PopulateExcel()
        {
            //Populates the created test file with the recorded data
            double AvgSum = 0;

            double[,] BaselineValues = new double[Measurement.BaseDataMax + 1, 5];
            for (int i = 1; i <= Measurement.BaseDataMax; i++)
            {
                BaselineValues[i - 1, 0] = Measurement.BaseArray[i, 0];
                BaselineValues[i - 1, 1] = Measurement.BaseArray[i, 1];
                BaselineValues[i - 1, 2] = Measurement.BaseArray[i, 2];
                BaselineValues[i - 1, 3] = Measurement.BaseArray[i, 3];
                BaselineValues[i - 1, 4] = BaselineValues[i - 1, 3] / BaselineValues[i - 1, 2];
            }

            double[,] SampleValues = new double[Measurement.SampleDataMax, 6];
            for (int i = 1; i <= Measurement.SampleDataMax; i++)
            {
                SampleValues[i - 1, 0] = Measurement.SampleArray[i, 0];
                SampleValues[i - 1, 1] = Measurement.SampleArray[i, 1];
                SampleValues[i - 1, 2] = Measurement.SampleArray[i, 2];
                SampleValues[i - 1, 3] = Measurement.SampleArray[i, 3];
                SampleValues[i - 1, 4] = SampleValues[i - 1, 3] / SampleValues[i - 1, 2];
                SampleValues[i - 1, 5] = -Math.Log10(SampleValues[i - 1, 4] / BaselineValues[i - 1, 4]);
                AvgSum += SampleValues[i - 1, 5];
            }

            var BaseStartCell = Worksheet.Cells[5, 1];
            var BaseEndCell = Worksheet.Cells[Measurement.BaseDataMax + 4, 5];
            var BaseWriteRange = Worksheet.Range[BaseStartCell, BaseEndCell];
            BaseWriteRange.Value = BaselineValues;

            var SampleStartCell = Worksheet.Cells[5, 7];
            var SampleEndCell = Worksheet.Cells[Measurement.SampleDataMax + 4, 12];
            var SampleWriteRange = Worksheet.Range[SampleStartCell, SampleEndCell];
            SampleWriteRange.Value = SampleValues;


            ////Baseline data insertion
            //for (int i = 1; i <= Measurement.BaseDataMax; i++)
            //{
            //    Worksheet.Cells[i + 4, 1] = Convert.ToString(Measurement.BaseArray[i, 0]);
            //    Worksheet.Cells[i + 4, 2] = Convert.ToString(Measurement.BaseArray[i, 1]);
            //    Worksheet.Cells[i + 4, 3] = Convert.ToString(Measurement.BaseArray[i, 2]);
            //    Worksheet.Cells[i + 4, 4] = Convert.ToString(Measurement.BaseArray[i, 3]);
            //    Worksheet.Cells[i + 4, 5] = Convert.ToString(Convert.ToDouble(Measurement.BaseArray[i, 3] / Measurement.BaseArray[i, 2]));
            //}

            //Sample data insertion
            //for (int i = 1; i <= Measurement.SampleDataMax; i++)
            //{
            //    Worksheet.Cells[i + 4, 7] = Convert.ToString(Measurement.SampleArray[i, 0]);
            //    Worksheet.Cells[i + 4, 8] = Convert.ToString(Measurement.SampleArray[i, 1]);
            //    Worksheet.Cells[i + 4, 9] = Convert.ToString(Measurement.SampleArray[i, 2]);
            //    Worksheet.Cells[i + 4, 10] = Convert.ToString(Measurement.SampleArray[i, 3]);
            //    Worksheet.Cells[i + 4, 11] = Convert.ToString(Convert.ToDouble(Measurement.SampleArray[i, 3] / Measurement.SampleArray[i, 2]));
            //    Worksheet.Cells[i + 4, 13] = Convert.ToString(Convert.ToDouble(-Math.Log10((Measurement.SampleArray[i, 3] / Measurement.SampleArray[i, 2]) / (Measurement.BaseArray[i, 3] / Measurement.BaseArray[i, 2]))));
            //    AvgSum += -Math.Log10((Measurement.SampleArray[i, 3] / Measurement.SampleArray[i, 2]) / (Measurement.BaseArray[i, 3] / Measurement.BaseArray[i, 2]));
            //}

            //Calculates the OD result, which is then displayed on the program form
            //Also inserts tolerance specifications to the worksheet
            Worksheet.Cells[1, 5] = Convert.ToString(AvgSum / Measurement.SampleDataMax);
            Measurement.ResultOD = AvgSum / Measurement.SampleDataMax;
            Worksheet.Cells[2, 5] = Measurement.TargetOD;
            Worksheet.Cells[1, 8] = Measurement.PosTol;
            Worksheet.Cells[2, 8] = Measurement.NegTol;

            //Determines if the part passes or not, does not affect what is displayed on the program form (that does this check again on its own)
            if (Measurement.ResultOD > (Measurement.TargetOD - Measurement.NegTol) && Measurement.ResultOD < (Measurement.TargetOD + Measurement.PosTol))
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
            Worksheet.Cells[1, 2] = FileOperations.CurrentDateString;
            Worksheet.Cells[2, 1] = "Test #:";
            Worksheet.Cells[2, 1].Font.Bold = true;
            Worksheet.Cells[2, 2] = Convert.ToString(Measurement.TestCount);
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

            for (int i = 1; i <= 13; i++)
            {
                Worksheet.Cells[4, i].Font.Bold = true;
            }

            //Set sample formatting
            Worksheet.Cells[4, 7] = "Sample Test Count:";
            Worksheet.Cells[4, 8] = "Sample Test Timestamps:";
            Worksheet.Cells[4, 9] = "Power Meter 1 Readings (mW):";
            Worksheet.Cells[4, 10] = "Power Meter 2 Readings (mW):";
            Worksheet.Cells[4, 11] = "Ratio:";
            Worksheet.Cells[4, 12] = "Optical Density:";

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
            Worksheet.Columns[12].ColumnWidth = 11.47;
        }

        public static void PopulateLogExcel()
        {
            ////This function opens and populates the longterm log file used in the program
            ////All measurement and hardware settings are saved, as well as the actual results
            //logLast = 0;
            //logExcel = new Excel.Application();
            //logExcel.Visible = false;
            //logBook = logExcel.Workbooks.Open(LogPath);
            //logSheet = logBook.ActiveSheet;
            //logLast = logSheet.Range["C5:C1000000"].End[Excel.XlDirection.xlDown].Row + 1;
            ////The above is definitely not the best way to accomplish finding the last row (hardcoding the range is less than ideal)
            //logSheet.Cells[logLast, 1] = DateTime.Now;
            //logSheet.Cells[logLast, 2] = Measurement.TestCount;
            //logSheet.Cells[logLast, 3] = FlipperControl.SerialNo;
            //logSheet.Cells[logLast, 4] = SensorControl.Det1;
            //logSheet.Cells[logLast, 5] = SensorControl.Det2;
            //if (frmTester.IntervalOn == true)
            //{
            //    logSheet.Cells[logLast, 6] = "True";
            //    logSheet.Cells[logLast, 7] = Measurement.IntervalNum;
            //}
            //else
            //{
            //    logSheet.Cells[logLast, 6] = "False";
            //    logSheet.Cells[logLast, 7] = "N/A";
            //}
            //if (frmTester.TimedMeasure == true)
            //{
            //    logSheet.Cells[logLast, 8] = "True";
            //    logSheet.Cells[logLast, 9] = Measurement.IntervalSet;
            //}
            //else
            //{
            //    logSheet.Cells[logLast, 8] = "False";
            //    logSheet.Cells[logLast, 9] = "N/A";
            //}
            //logSheet.Cells[logLast, 10] = Measurement.Wavelength;
            //logSheet.Cells[logLast, 11] = Measurement.TargetOD;
            //logSheet.Cells[logLast, 12] = Measurement.PosTol;
            //logSheet.Cells[logLast, 13] = Measurement.NegTol;
            //logSheet.Cells[logLast, 14] = Measurement.BaseCountMax;
            //logSheet.Cells[logLast, 15] = frmTester.BaseResults[0];
            //logSheet.Cells[logLast, 16] = frmTester.BaseResults[1];
            //logSheet.Cells[logLast, 17] = frmTester.BaseResults[2];
            //logSheet.Cells[logLast, 18] = Measurement.SampleCountMax;
            //logSheet.Cells[logLast, 19] = frmTester.SampleResults[0];
            //logSheet.Cells[logLast, 20] = frmTester.SampleResults[1];
            //logSheet.Cells[logLast, 21] = frmTester.SampleResults[2];
            //logSheet.Cells[logLast, 22] = frmTester.SampleResults[3];
            //logSheet.Cells[logLast, 23] = Measurement.ResultOD;
            //logSheet.Cells[logLast, 24] = Measurement.ResultPosUncert;
            //logSheet.Cells[logLast, 25] = Measurement.ResultNegUncert;
            //logLast = 0;
            //logBook.Save();
            //logBook.Close();
            //logExcel.Quit();
        }

        public static void ReferenceOpen()
        {
            //Opens a reference file, containing the data from the website for our standard ND filters
            //Allows you to enter a product and wavelength to determine the expected OD
            object misValue = System.Reflection.Missing.Value;
            refExcel = new Excel.Application();
            refExcel.Visible = true;
            refBook = refExcel.Workbooks.Open(refPath, misValue, true, misValue, misValue, misValue, true, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue);
        }
    }
}
