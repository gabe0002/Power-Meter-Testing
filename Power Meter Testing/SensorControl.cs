using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thorlabs.TLPM_32.Interop;

namespace Power_Meter_Testing
{
    class SensorControl
    {
        //Power meter variables
        public static string Det1 = "";
        public static string Det2 = "";
        public static TLPM pm1;
        public static TLPM pm2;

        public static void CreatePowerMeters()
        { 
            //Function creates the power meters. Needs its own function, as multiple routes to initialization are present.
            pm1 = new TLPM(Det1, true, true);
            pm2 = new TLPM(Det2, true, true);
            frmTester.PowerMeterOn = true;
        }

        public static void SetCount()
        {

        }
    }
}
