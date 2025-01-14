using System; 
using System.Collections.Generic;

namespace WCHS_Assignment14
{
    [Serializable]
    public class IoTData
    {
        private double _co2;
        private List<string> _logs = new List<string>();
        private DateTime _timestamp;

        public IoTData()
        {
            _timestamp = DateTime.Now;
        }

        public IoTData(double co2, List<string> logs)
        {
            this.CO2 = co2;
            this.Logs = logs;
            this.Timestamp = DateTime.Now;
        }

        public double CO2
        {
            get { return _co2; }
            set { _co2 = Math.Round(value, 2); }
        }

        public List<string> Logs
        {
            get { return _logs; }
            set { _logs = value; }
        }

        public DateTime Timestamp
        {
            get { return _timestamp; }
            set { _timestamp = value; }
        }
    }
}
