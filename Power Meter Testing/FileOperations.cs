using System;
using System.IO;
using System.Windows.Forms;

namespace Power_Meter_Testing
{
    class FileOperations
    {
        //Date related variables
        public static string CurrentDateString = DateTime.Today.ToString("MM/dd/yyyy");

        //File name and path related variables
        public static string FileNameDate = CurrentDateString.Replace("/", "-");

        public static void CreateFolder()
        {
            //Creates the test log folder for the current day
            try
            {
                Directory.CreateDirectory(Convert.ToString(frmTester.TestLogFolder) + "\\" + FileNameDate + "\\");
            }
            catch
            {
                MessageBox.Show("There was an error creating the folder.");
            }
        }

        public static bool FolderExists()
        {
            //Checks to see if a folder already exists for test files from today
            string FolderCheckPath = Convert.ToString(frmTester.TestLogFolder) + "\\" + FileNameDate + "\\";
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
            string Folder = Convert.ToString(frmTester.TestLogFolder);
            string FilePath = Folder + "\\" + FileNameDate + "\\" + "Test " + Convert.ToString(Measurement.TestCount);
            return FilePath;
        }


        public static int GetLastTestCount()
        {
            //If the program is opened more than once during the same day, this function finds
            //the last test number and adjusts the display accordingly. If its the first time the
            //program is opened that day, it sets the test count to zero
            int LastTestNum = 0;
            string LastFile;
            string GetFilePath = frmTester.TestLogFolder.ToString() + "\\" + FileNameDate + "\\";
            string[] FileEntries = Directory.GetFiles(GetFilePath);
            if (FileEntries.Length > 0)
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
            foreach (char c in Ending)
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
    }
}
