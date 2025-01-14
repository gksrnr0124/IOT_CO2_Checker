using System; 
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms;
using WCHS_Assignment14;

namespace IoTDataVisualizer
{
    public class ChartsUpdater
    {
        private double maxCO2 = double.MinValue;
        private double minCO2 = double.MaxValue;
        private int msgCount = 1;
        private Chart chart;
        private ListBox listBox;
        private List<IoTData> dataList;
        private double totalCO2 = 0;



        public ChartsUpdater(Chart chart, ListBox listBox, List<IoTData> dataList)
        {
            this.chart = chart;
            this.listBox = listBox;
            this.dataList = dataList; // Initialize the dataList from frmMain
            InitializeChart();
            ResetMinMaxCO2();
            maxCO2 = double.MinValue;
            minCO2 = double.MaxValue;
        }

        private void InitializeChart()
        {
            this.chart.Palette = ChartColorPalette.SeaGreen;
            this.chart.Titles.Add("IoT Data");
            this.chart.Series.Clear();
            this.chart.Series.Add("CO2");
            this.chart.Series["CO2"].ChartType = SeriesChartType.Line;
        }

        public void UpdateChart(string data)
        {
            data = data.Substring(9);
            double co2value = double.Parse(data);

            // Update max and min CO2 values
            if (co2value > maxCO2)
            {
                maxCO2 = co2value;
            }
            if (co2value < minCO2)
            {
                minCO2 = co2value;
            }

            // Update total CO2 and data count
            totalCO2 += co2value;

            // Update chart
            this.chart.Series["CO2"].Points.AddXY(msgCount++, data);
            this.chart.ChartAreas[0].AxisX.Minimum = 0;
            this.chart.ChartAreas[0].AxisY.Maximum = 2500;

            // Add data to frmMain's dataList
            AddDataToList(co2value);
        }

        public void UpdateChart3(double co2Value)
        {
            if (co2Value > maxCO2)
            {
                maxCO2 = co2Value;
            }
            if (co2Value < minCO2)
            {
                minCO2 = co2Value;
            }

            // Update total CO2 and data count
            totalCO2 += co2Value;


            // Update chart 3
            this.chart.Series["CO2"].Points.AddXY(msgCount++, co2Value);
            this.chart.ChartAreas[0].AxisX.Minimum = 0;
            this.chart.ChartAreas[0].AxisY.Maximum = 2500;

            // Add data to frmMain's dataList
            AddDataToList(co2Value);
        }

        private void AddDataToList(double co2Value)
        {
            // Collect logs from the ListBox
            List<string> logs = new List<string>();
            foreach (var item in listBox.Items)
            {
                logs.Add(item.ToString());
            }
            // Adding data and logs to frmMain's dataList
            dataList.Add(new IoTData(co2Value, logs));  
        }

        public double GetMaxCO2()
        {
            return maxCO2;
        }

        public double GetMinCO2()
        {
            return minCO2;
        }

        public void ResetMinMaxCO2()
        {
            maxCO2 = double.MinValue;
            minCO2 = double.MaxValue;
        }
        public void ResetMsgCount()
        {
            msgCount = 0;
            totalCO2 = 0;
        }
        public double GetAverageCO2()
        {
            return Math.Round(totalCO2 / msgCount, 2);
        }

    }
}
