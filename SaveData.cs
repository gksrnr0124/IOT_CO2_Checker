using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;
using WCHS_Assignment14;

namespace IoTDataVisualizer
{
    class SaveData
    {
        public void Save(IoTData data, string filePath)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(IoTData));
                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                {
                    serializer.Serialize(fs, data);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error in saving the data...");
            }
        }
    }
}
