using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Power_Meter_Testing
{
    class Measurement
    {
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
        public static TimeSpan[] imes = new TimeSpan[SampleCountMax + 1];
        public static int BaseDataMax, SampleDataMax;

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

        public static void ExpectedPowerAdjust()
        {
            SampleMeterPowerScaleFactorT1 = 1.2 * SampleMeterMaxPowerScaleFactor;
            ReferenceMeterPowerScaleFactorT1 = 1.2 * ReferenceMeterMaxPowerScaleFactor;
            SampleExpectedPowerT1 = SampleMeterPowerScaleFactorT1 * TestPower;
            ReferenceExpectedPowerT1 = ReferenceMeterPowerScaleFactorT1 * TestPower;

            SampleMeterPowerScaleFactorT2 = (1 / Math.Pow(10, TargetOD)) * 1.2;
            ReferenceMeterPowerScaleFactorT2 = ReferenceMeterPowerScaleFactorT1;
            SampleExpectedPowerT2 = SampleMeterPowerScaleFactorT2 * TestPower;
            ReferenceExpectedPowerT2 = ReferenceExpectedPowerT1;

            SensorControl.pm1.setPowerAutoRange(false);
            SensorControl.pm2.setPowerAutoRange(false);
        }

        //Results variables
        public static double ResultOD, ResultPosUncert, ResultNegUncert;

        public static double[,] BaseMeasurement()
        {
            //Baseline measurement procedure (no step averaging)
            SensorControl.pm1.setPowerRange(ReferenceExpectedPowerT1);
            SensorControl.pm2.setPowerRange(SampleExpectedPowerT1);
            BaseDataMax = BaseCountMax;
            double[,] BaseMeas = new double[BaseCountMax + 1, 4];
            for (int i = 1; i <= BaseDataMax; i++)
            {
                BaseCount = i;
                BaseMeas[i, 0] = Convert.ToDouble(BaseCount);
                SensorControl.pm1.measPower(out Power1);
                BaseMeas[i, 2] = Power1;
                SensorControl.pm2.measPower(out Power2);
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
            SensorControl.pm1.setPowerRange(ReferenceExpectedPowerT2);
            SensorControl.pm2.setPowerRange(SampleExpectedPowerT2);
            SampleDataMax = SampleCountMax;
            double[,] SampleMeas = new double[SampleCountMax + 1, 4];
            for (int i = 1; i <= SampleDataMax; i++)
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

        public static double[,] IntervalBaseMeasurement()
        {
            //Baseline measurement procedure using step averaging setting
            SensorControl.pm1.setPowerRange(ReferenceExpectedPowerT1);
            SensorControl.pm2.setPowerRange(SampleExpectedPowerT1);
            BaseDataMax = BaseCountMax / IntervalNum;
            double[,] IntBaseMeas = new double[BaseDataMax + 1, 4];
            double Sum1, Sum2, IntTestCount;
            for (int i = 1; i <= BaseDataMax; i++)
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
            SampleDataMax = SampleCountMax / IntervalNum;
            double[,] IntSampMeas = new double[SampleDataMax + 1, 4];
            double Sum1, Sum2, IntTestCount;
            for (int i = 1; i <= SampleDataMax; i++)
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
            for (int i = 1; i <= BaseDataMax; i++)
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

        public static double[] SampleAverages()
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
    }
}
