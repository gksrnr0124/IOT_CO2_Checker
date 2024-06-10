using System;

namespace WCHS_Assignment14
{
    [Serializable]
    public class IoTData
    {
        private double _co2;

        public IoTData()
        {

        }
        public IoTData(double co2)
        {
            this.CO2 = co2;
        }

        public double CO2
        {
            get { return _co2; }
            set { _co2 = Math.Round(value, 2); }  // round value off to 2 digits of precision
        }
    }
}
