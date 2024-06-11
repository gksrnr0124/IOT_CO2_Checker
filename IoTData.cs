using System;
using System.Collections.Generic;
using System.Windows.Documents;

namespace WCHS_Assignment14
{
    [Serializable]
    public class IoTData
    {
        private double _co2;
        private List<string> _logs = new List<string>();
        public IoTData()
        {

        }
        public IoTData(double co2, List<string> logs)
        {
            this.CO2 = co2;
            this.Logs = logs;
        }

        public double CO2
        {
            get { return _co2; }
            set { _co2 = Math.Round(value, 2); }  // round value off to 2 digits of precision
        }
        public List<string> Logs
        {
            get { return _logs; }
            set { _logs = value; }
        }
    }
}
