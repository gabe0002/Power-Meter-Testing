using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;


namespace Power_Meter_Testing
{
    class Measurement
    {
        //Measurement variables
        public static double Power1, Power2;
        public static double Wavelength;

        //Measurement setting variables
        public static int IntervalNum;
        public static double SleepTime;
        public static int DataPointCount;
        public static int BaseCount, SampleCount;
        public static int TestCount;
        public static int IntervalSet;

        //Arrays that hold the power measurements
        //Need to be 1 larger than expected, as for loops start at 1
        //Easier to start at base 1, because of how Excel controls row & column naming
        public static double[,] BaseArray = new double[DataPointCount + 1, 4];
        public static double[,] SampleArray = new double[DataPointCount + 1, 4];
        public static TimeSpan[] BaseTimes = new TimeSpan[DataPointCount + 1];
        public static TimeSpan[] imes = new TimeSpan[DataPointCount + 1];

        //Target OD and tolerance variables:
        public static double TargetOD;
        public static double PosTol, NegTol;

        //Power Range Adjustment Variables
        public static double TestPower;
        public static double SampleMeterMaxPowerScaleFactor, ReferenceMeterMaxPowerScaleFactor;
        public static double SampleMeterPowerScaleFactorT1, ReferenceMeterPowerScaleFactorT1;
        public static double SampleMeterPowerScaleFactorT2, ReferenceMeterPowerScaleFactorT2;
        public static double SampleExpectedPowerT1, ReferenceExpectedPowerT1;
        public static double SampleExpectedPowerT2, ReferenceExpectedPowerT2;

        public static int TestNum;

        public static double CalibratedOD;
        public static double CalibratedRatio;
        public static double AdjustedPower;

        public static void ExpectedPowerAdjust()
        {
            SampleMeterPowerScaleFactorT1 = 1.2 * SampleMeterMaxPowerScaleFactor;
            ReferenceMeterPowerScaleFactorT1 = 1.2 * ReferenceMeterMaxPowerScaleFactor;
            SampleExpectedPowerT1 = SampleMeterPowerScaleFactorT1 * AdjustedPower;
            ReferenceExpectedPowerT1 = ReferenceMeterPowerScaleFactorT1 * AdjustedPower;

            SampleMeterPowerScaleFactorT2 = (1 / Math.Pow(10, TargetOD)) * 1.2;
            ReferenceMeterPowerScaleFactorT2 = ReferenceMeterPowerScaleFactorT1;
            SampleExpectedPowerT2 = SampleMeterPowerScaleFactorT2 * AdjustedPower;
            ReferenceExpectedPowerT2 = ReferenceExpectedPowerT1;

            SensorControl.pm1.setPowerAutoRange(false);
            SensorControl.pm2.setPowerAutoRange(false);
        }

        //Results variables, not currently in use
        public static double ResultOD, ResultPosUncert, ResultNegUncert;

        public static double[,] BaseMeasurement()
        {
            //Baseline measurement procedure (no step averaging)
            SensorControl.pm1.setPowerRange(ReferenceExpectedPowerT1);
            SensorControl.pm2.setPowerRange(SampleExpectedPowerT1);
            double[,] BaseMeas = new double[DataPointCount + 1, 4];
            for (TestNum = 1; TestNum <= DataPointCount; TestNum++)
            {
                BaseCount = TestNum;
                BaseMeas[TestNum, 0] = Convert.ToDouble(BaseCount);
                SensorControl.pm1.measPower(out Power1);
                BaseMeas[TestNum, 2] = Power1;
                SensorControl.pm2.measPower(out Power2);
                BaseMeas[TestNum, 3] = Power2;
                BaseMeas[TestNum, 1] = DateTime.Now.ToOADate();
                if (SleepTime > 0)
                {
                    Thread.Sleep(Convert.ToInt32(SleepTime));
                }
                //frmTester.MeasureThread.ReportProgress(TestNum);
            }
            TestNum = 0;
            return BaseMeas;
        }

        public static double[,] SampleMeasurement()
        {
            //Sample measurement procedure (no step averaging)
            SensorControl.pm1.setPowerRange(ReferenceExpectedPowerT2);
            SensorControl.pm2.setPowerRange(SampleExpectedPowerT2);
            double[,] SampleMeas = new double[DataPointCount + 1, 4];
            for (int i = 1; i <= DataPointCount; i++)
            {
                SampleCount = i;
                SampleMeas[i, 0] = Convert.ToDouble(SampleCount);
                SensorControl.pm1.measPower(out Power1);
                SampleMeas[i, 2] = Power1;
                SensorControl.pm2.measPower(out Power2);
                SampleMeas[i, 3] = Power2;
                SampleMeas[i, 1] = DateTime.Now.ToOADate();
                if (SleepTime > 0)
                {
                    Thread.Sleep(Convert.ToInt32(SleepTime));
                }
            }
            return SampleMeas;
        }

        //Check interval measurment logic. Currently divide datapointcount by itself to set actual datapoints.
        //This works, but could be easier to have one variable that gets used by both sample and base measurements.
        //Perhaps some sort of function to set the new variable depending on whether or not interval measurement is set.
        
        //Maybe delete interval measurement altogether? Is there really a purpose to this method of measurement.

        public static double[,] IntervalBaseMeasurement()
        {
            //Baseline measurement procedure using step averaging setting
            SensorControl.pm1.setPowerRange(ReferenceExpectedPowerT1);
            SensorControl.pm2.setPowerRange(SampleExpectedPowerT1);
            DataPointCount = DataPointCount / IntervalNum;
            double[,] IntBaseMeas = new double[DataPointCount + 1, 4];
            double Sum1, Sum2, IntTestCount;
            for (int i = 1; i <= DataPointCount; i++)
            {
                Sum1 = Sum2 = IntTestCount = 0;
                BaseCount++;
                for (int x = 1; x <= IntervalNum; x++)
                {
                    SensorControl.pm1.measPower(out Power1);
                    SensorControl.pm2.measPower(out Power2);
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
            SensorControl.pm1.setPowerRange(ReferenceExpectedPowerT2);
            SensorControl.pm2.setPowerRange(SampleExpectedPowerT2);
            double[,] IntSampMeas = new double[DataPointCount + 1, 4];
            double Sum1, Sum2, IntTestCount;
            for (int i = 1; i <= DataPointCount; i++)
            {
                Sum1 = Sum2 = IntTestCount = 0;
                SampleCount++;
                for (int x = 1; x <= IntervalNum; x++)
                {
                    SensorControl.pm1.measPower(out Power1);
                    SensorControl.pm2.measPower(out Power2);
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
            for (int i = 1; i <= DataPointCount; i++)
            {
                BaseDenomDet1 += BaseArray[i, 2];
                BaseDenomDet2 += BaseArray[i, 3];
                BaseDenomRatio += BaseArray[i, 3] / BaseArray[i, 2];
            }
            //Multiplying by 1000 to convert to mW from W.
            BaseAvgs[0] = BaseDenomDet1 / DataPointCount * 1000;
            BaseAvgs[1] = BaseDenomDet2 / DataPointCount * 1000;
            BaseAvgs[2] = BaseDenomRatio / DataPointCount;
            return BaseAvgs;
        }

        public static double[] SampleAverages()
        {
            double[] SampleAvgs = new double[4];
            double SampleDenomDet1, SampleDenomDet2, SampleDenomRatio;
            SampleDenomDet1 = SampleDenomDet2 = SampleDenomRatio = 0;
            for (int i = 1; i <= DataPointCount; i++)
            {
                SampleDenomDet1 += SampleArray[i, 2];
                SampleDenomDet2 += SampleArray[i, 3];
                SampleDenomRatio += SampleArray[i, 3] / SampleArray[i, 2];
            }

            //Multiplying by 1000 to convert to mW from W. Multiplying by 100 to get result in percent format.
            SampleAvgs[0] = SampleDenomDet1 / DataPointCount * 1000;
            SampleAvgs[1] = SampleDenomDet2 / DataPointCount * 1000;
            SampleAvgs[2] = SampleDenomRatio / DataPointCount;
            SampleAvgs[3] = SampleAvgs[2] / frmTester.BaseResults[2] * 100;
            return SampleAvgs;
        }

        public static int CalibrationRatioPrep()
        {
            //The logic of this is based off the type of beamsplitter used. I assumed it would 70(T):30(R) or higher transmission.
            CalibratedRatio = Math.Pow(10, CalibratedOD);
            double Transmission = 1 / CalibratedRatio;
            AdjustedPower = Transmission * TestPower;
            int Result;

            if (TestPower < .005 && CalibratedOD > 0)
            {
                DialogResult CalConfirm = MessageBox.Show("You have entered an expected test power of below 5mW and have used a calibrating OD filter." +
                    " This is unecessary when the test power is below 5mW. Would you like to cancel and remove the calibration filter? (Recommended)",
                    "Calibration Filter Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (CalConfirm == DialogResult.Yes)
                {
                    Result = 1;
                    return Result;
                }
                else if(CalConfirm == DialogResult.No)
                {
                    Result = 0;
                    return Result;
                }
            }
            else if(AdjustedPower > .005)
            {
                MessageBox.Show("With the calibration OD entered, the expected power is still above 5mW. Please use a filter with a higher OD.");
                Result = 0;
                return Result;
            }
            else if(CalibratedOD >= 5)
            {
                DialogResult HighODConfirm = MessageBox.Show("You have entered a calibration optical density of 5 or greater." +
                    " This will probably introduce inaccuracy into the measurement. It is recommended to use a lower optical density filter." +
                    " If you wish to continue regardless, press yes. Press no to cancel and adjust.", "High OD Calibration Filter Confirmation",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(HighODConfirm == DialogResult.Yes)
                {
                    Result = 1;
                    return Result;
                }
                else if(HighODConfirm == DialogResult.No)
                {
                    Result = 0;
                    return Result;
                }
            }
                Result = 1;
                return Result;
        }

    }
}
