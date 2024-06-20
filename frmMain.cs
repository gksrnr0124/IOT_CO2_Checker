using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml.Serialization;
using Azure.Messaging.EventHubs.Consumer;
using IoTDataVisualizer;

using Newtonsoft.Json;

namespace WCHS_Assignment14
{
    public partial class frmMain : Form
    {
        private Devices device1;
        private Devices device2;
        private Devices device3;

        private List<IoTData> dataList1 = new List<IoTData>();
        private List<IoTData> dataList2 = new List<IoTData>();
        private List<IoTData> dataList3 = new List<IoTData>();
        

        private ChartsUpdater ChartsUpdater1;
        private ChartsUpdater ChartsUpdater2;
        private ChartsUpdater ChartsUpdater3;

        private Timer updateTimer;

        private readonly static string connectionString = "Endpoint=sb://iothub-ns-wchs-58009161-d596108607.servicebus.windows.net/;SharedAccessKeyName=iothubowner;SharedAccessKey=glM1A7WyVpMhjjMrhLcdQjkIr91upa8tSAIoTFiDvUI=;EntityPath=wchs";
        private readonly static string EventHubName = "wchs";
        
        //update textboxes every second
        private void InitializeTimer()
        {
            updateTimer = new Timer();
            updateTimer.Interval = 1000; // Update every second
            updateTimer.Tick += new EventHandler(UpdateTextBoxes);
            updateTimer.Start();
        }
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
                    ChartsUpdater1.UpdateChart(data);
                }
                if (deviceID.ToString() == "wchs8")
                {
                    this.listMsgs2.Items.Insert(0, ConstructDisplayMessage(partitionEvent));
                    ChartsUpdater2.UpdateChart(data);
                }
            }
        }

        //call updating max min ave textobxes depending on what device(chart) user is looking at
        private void UpdateTextBoxes(object sender, EventArgs e)
        {
            if (chartData1.Visible)
            {
                UpdateMaxMinAveTextBoxes(ChartsUpdater1);
            }
            else if (chartData2.Visible)
            {
                UpdateMaxMinAveTextBoxes(ChartsUpdater2);
            }
            else if (chartData3.Visible)
            {
                UpdateMaxMinAveTextBoxes(ChartsUpdater3);
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
            btnsave.Visible = true;
            return msg;
        }

        
        private async void frmMain_Load(object sender, EventArgs e)
        {
            SetUpChart1();
            SetUpListBox1();
            SetUpChart2();
            SetUpListBox2();
            SetUpChart3();
            await ReceiveMessagesFromDeviceAsync();
        }

        public frmMain()
        {
            InitializeComponent();

            device1 = new Devices(listMsgs1, chartData1);
            device2 = new Devices(listMsgs2, chartData2);
            device3= new Devices(listMsgs3, chartData3);

            ChartsUpdater1 = new ChartsUpdater(chartData1, listMsgs1, dataList1);
            ChartsUpdater2 = new ChartsUpdater(chartData2, listMsgs2, dataList2);
            ChartsUpdater3 = new ChartsUpdater(chartData3, listMsgs3, dataList3);

            InitializeTimer();
        }
        private void chartData_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedItem.ToString())
            {
                case "Device 1":
                    //bring up device 1 stuff and take down device 2 and 3 stuff
                    device1.Visible();
                    device2.Invisible();
                    device3.Invisible();
                    
                    break;

                case "Device 2":
                    //do for 2
                    device1.Invisible();
                    device2.Visible();
                    device3.Invisible();
                    
                    break;
                case "Saved Data":
                    // Show saved data and prompt for file import
                    device1.Invisible();
                    device2.Invisible();
                    device3.Visible();
                    ImportSavedData(dataList3);
                    break;
            }
        }
        private void chart1_Click(object sender, EventArgs e)
        {

        }
        
        //set up charts
        private void SetUpChart1()
        {
            this.chartData1.Palette = ChartColorPalette.SeaGreen;
            this.chartData1.Titles.Add("IoT data from Device 1");
            this.chartData1.Series.Clear();
            this.chartData1.Series.Add("CO2");
            this.chartData1.Series["CO2"].ChartType = SeriesChartType.Line;
        }
        private void SetUpChart2()
        {
            this.chartData2.Palette = ChartColorPalette.SeaGreen;
            this.chartData2.Titles.Add("IoT data from Device 2");
            this.chartData2.Series.Clear();
            this.chartData2.Series.Add("CO2");
            this.chartData2.Series["CO2"].ChartType = SeriesChartType.Line;
        }
        private void SetUpChart3()
        {
            this.chartData3.Palette = ChartColorPalette.SeaGreen;
            this.chartData3.Titles.Add("IoT data from Saved Data");
            this.chartData3.Series.Clear();
            this.chartData3.Series.Add("CO2");
            this.chartData3.Series["CO2"].ChartType = SeriesChartType.Line;
        }


        //set up listboxes
        private void SetUpListBox1()
        {
            this.listMsgs1.Items.Add("Reading data from WCHS IoT Device 1. Ctrl-C to exit.\n");
        }
        private void SetUpListBox2()
        {
            this.listMsgs2.Items.Add("Reading data from WCHS IoT Device 2. Ctrl-C to exit.\n");
        }



        private void btnsave_Click(object sender, EventArgs e)
        {
            // Prompt the user for the room name using a MessageBox
            string roomName = PromptForRoomName();

            if (!string.IsNullOrEmpty(roomName))
            {
                // Determine which device is selected and save its data
                if (comboBox1.SelectedItem.ToString() == "Device 1")
                {
                    SaveData(dataList1, roomName);
                }
                else if (comboBox1.SelectedItem.ToString() == "Device 2")
                {
                    SaveData(dataList2, roomName);
                }
                else
                {
                    MessageBox.Show("Please select a device to save its data.", "Device Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        //actual save process
        private void SaveData(List<IoTData> dataList, string roomName)
        {
            // Get today's date
            string currentDate = DateTime.Now.ToString("yyyy_MM_dd");

            // Generate the file name
            string fileName = $"{currentDate}_{roomName}.xml";

            // Serialize the dataList to XML and save it to the file
            XmlSerializer serializer = new XmlSerializer(typeof(List<IoTData>));
            using (TextWriter writer = new StreamWriter(fileName))
            {
                serializer.Serialize(writer, dataList);
            }

            MessageBox.Show($"Data saved to {fileName}", "Save Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //bring up promt for user to write in room name
        private string PromptForRoomName()
        {
            string roomName = "";
            do
            {
                roomName = Microsoft.VisualBasic.Interaction.InputBox("Enter the room name:", "Room Name", "");
                if (string.IsNullOrEmpty(roomName))
                {
                    DialogResult result = MessageBox.Show("Room name cannot be empty. Do you want to try again?", "Empty Room Name", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.No)
                        break;
                }
            } while (string.IsNullOrEmpty(roomName));

            return roomName;
        }

        //deserialize and import data
        private void ImportSavedData(List<IoTData> dataList)
        {
            // Reset 
            ChartsUpdater3.ResetMsgCount();
            ChartsUpdater3.ResetMinMaxCO2();

            //deserialize
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "XML files (*.xml)|*.xml";
                openFileDialog.Title = "Select an XML file";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileName = openFileDialog.FileName;

                    // Deserialize the XML file back into dataList
                    XmlSerializer serializer = new XmlSerializer(typeof(List<IoTData>));
                    using (TextReader reader = new StreamReader(fileName))
                    {
                        dataList = (List<IoTData>)serializer.Deserialize(reader);
                    }
                    
                    // Sort the dataList based on the Timestamp property
                    dataList = dataList.OrderBy(data => data.Timestamp).ToList();

                    // Clear the current chart data and ListBox logs
                    this.chartData3.Series["CO2"].Points.Clear();
                    listMsgs3.Items.Clear();
                    
                    

                    // Populate the chart and ListBox with the imported data
                    foreach (IoTData data in dataList)
                    {
                        ChartsUpdater3.UpdateChart3(data.CO2);
                        // Clear duplicate logs
                        listMsgs3.Items.AddRange(data.Logs.Except(listMsgs3.Items.Cast<string>()).ToArray());
                    }
                    UpdateMaxMinAveTextBoxes(ChartsUpdater3);
                }
            }
        }


        // Update textboxes with max and min CO2 values
        private void UpdateMaxMinAveTextBoxes(ChartsUpdater updater)
        {
            txtMaxppm.Text = updater.GetMaxCO2().ToString();
            txtMinppm.Text = updater.GetMinCO2().ToString();
            txtAveppm.Text = updater.GetAverageCO2().ToString();
        }
    }
}
