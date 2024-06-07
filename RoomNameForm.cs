using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IoTDataVisualizer
{
    public partial class SaveFileForm : Form
    {
        public string RoomName { get; private set; }

        public SaveFileForm()
        {
            InitializeComponent();
        }

        private void SaveFileForm_Load(object sender, EventArgs e)
        {

        }
    }
}
