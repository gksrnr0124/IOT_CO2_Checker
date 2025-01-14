using System; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace IoTDataVisualizer
{
    public class Devices
    {
        public ListBox ListMsgs { get; set; }
        public Chart Chartdata { get; set; }

        public Devices( ListBox listMsgs, Chart chartdata)
        {
            ListMsgs = listMsgs;
            Chartdata = chartdata;
        }

        public void Visible()
        {
            ListMsgs.Visible = true;
            Chartdata.Visible = true;
        }
        public void Invisible()
        {
            ListMsgs.Visible = false;
            Chartdata.Visible = false;
        }

    }
}
