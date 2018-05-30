using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Thorlabs.MotionControl.DeviceManagerCLI;
using Thorlabs.MotionControl.FilterFlipperCLI;
using System.Threading;

namespace Power_Meter_Testing
{
    class FlipperControl
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
