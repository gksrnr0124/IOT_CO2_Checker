using System;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Azure.Messaging.EventHubs.Consumer;
using Newtonsoft.Json;

namespace WCHS_Assignment14
{
    public partial class frmMain : Form
    {
        private readonly static string connectionString = "Endpoint=sb://iothub-ns-wchs-58009161-d596108607.servicebus.windows.net/;SharedAccessKeyName=iothubowner;SharedAccessKey=glM1A7WyVpMhjjMrhLcdQjkIr91upa8tSAIoTFiDvUI=;EntityPath=wchs";
        private readonly static string EventHubName = "wchs";
        static int msgCount = 1;

        private async Task ReceiveMessagesFromDeviceAsync()
        {
            await using EventHubConsumerClient consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connectionString, EventHubName);

            await foreach (PartitionEvent partitionEvent in consumer.ReadEventsAsync())
            {
                partitionEvent.Data.SystemProperties.TryGetValue("iothub-connection-device-id", out object deviceID);
                string data = Encoding.UTF8.GetString(partitionEvent.Data.Body.ToArray());
                if (deviceID.ToString() == "wchs1")
                {
                    this.listMsgs1.Items.Insert(0, ConstructDisplayMessage(partitionEvent));
                    UpdateChart1(data);
                    msgCount ++;
                }
                if (deviceID.ToString() == "wchs8")
                {
                    this.listMsgs2.Items.Insert(0, ConstructDisplayMessage(partitionEvent));
                    UpdateChart2(data);
                    msgCount++;
                }
            }
        }

        private string ConstructDisplayMessage(PartitionEvent partitionEvent)
        {
            partitionEvent.Data.SystemProperties.TryGetValue("iothub-connection-device-id", out object deviceID);
            string jsonData = Encoding.UTF8.GetString(partitionEvent.Data.Body.ToArray());
            string msg = partitionEvent.Data.EnqueuedTime.LocalDateTime.ToString("G");
            msg += " > Received msg from ";
            msg += (string)deviceID;
            msg += ": ";
            msg += jsonData;
            return msg;
        }

        private void UpdateChart1(string data)
        {
            data = data.Substring(9);
            this.chartData1.Series["CO2"].Points.AddXY(msgCount++, data);
            this.chartData1.ChartAreas[0].AxisX.Minimum = 0;
            this.chartData1.ChartAreas[0].AxisY.Maximum = 5000;
        }

        private void SetUpChart1()
        {
            this.chartData1.Palette = ChartColorPalette.SeaGreen;
            this.chartData1.Titles.Add("IoT data from Device 1");
            this.chartData1.Series.Clear();
            this.chartData1.Series.Add("CO2");
            this.chartData1.Series["CO2"].ChartType = SeriesChartType.Line;
        }

        private void SetUpListBox1()
        {
            this.listMsgs1.Items.Add("Reading data from WCHS IoT Device 1. Ctrl-C to exit.\n");
        }
        private void SetUpListBox2()
        {
            this.listMsgs2.Items.Add("Reading data from WCHS IoT Device 2. Ctrl-C to exit.\n");
        }
        private async void frmMain_Load(object sender, EventArgs e)
        {
            SetUpChart1();
            SetUpListBox1();
            SetUpChart2();
            SetUpListBox2();
            await ReceiveMessagesFromDeviceAsync();
        }

        public frmMain()
        {
            InitializeComponent();
        }
        private void chartData_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedItem.ToString())
            {
                case "Device 1":
                    //bring up device 1 stuff
                    listMsgs1.Visible = true;
                    chartData1.Visible = true;
                    //take down device 2 stuff
                    listMsgs2.Visible = false;
                    chartData2.Visible = false;
                    break;

                case "Device 2":
                    //do opposite
                    listMsgs1.Visible = false;
                    chartData1.Visible = false;
                    listMsgs2.Visible = true;
                    chartData2.Visible = true;
                    break;
            }
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
        private void SetUpChart2()
        {
            this.chartData2.Palette = ChartColorPalette.SeaGreen;
            this.chartData2.Titles.Add("IoT data from Device 2");
            this.chartData2.Series.Clear();
            this.chartData2.Series.Add("CO2");
            this.chartData2.Series["CO2"].ChartType = SeriesChartType.Line;
        }
        private void UpdateChart2(string data)
        {
            data = data.Substring(9);
            this.chartData2.Series["CO2"].Points.AddXY(msgCount++, data);
            this.chartData2.ChartAreas[0].AxisX.Minimum = 0;
            this.chartData2.ChartAreas[0].AxisY.Maximum = 5000;
        }
    }
}
