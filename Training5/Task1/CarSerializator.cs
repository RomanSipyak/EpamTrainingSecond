using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Training5.Task1
{
    public class CarSerializator : Iserializer<Car>
    {
        public string BinaryPath { get; set; } = ConfigurationManager.AppSettings["BinaryPath"].ToString();

        public string XmlPath { get; set; } = ConfigurationManager.AppSettings["XmlPath"].ToString();

        public List<Car> DeserializeForBinary()
        {
            using (FileStream fs = new FileStream(this.BinaryPath, FileMode.Open))
            {
                BinaryFormatter bf = new BinaryFormatter();
                List<Car> data;
                data = (List<Car>)bf.Deserialize(fs);
                return data;
            }
        }

        public List<Car> DeserializeForJson(string jsonData)
        {
            return JsonConvert.DeserializeObject<List<Car>>(jsonData);
        }

        public List<Car> DeserializeForXML()
        {
            using (FileStream fs = new FileStream(this.XmlPath, FileMode.Open))
            {
                XmlSerializer xs = new XmlSerializer(typeof(List<Car>));
                List<Car> data;
                data = (List<Car>)xs.Deserialize(fs);
                return data;
            }
        }

        public void SerializeForBinary(List<Car> objects)
        {
            using (FileStream fs = new FileStream(this.BinaryPath, FileMode.Create))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, objects);
            }
        }

        public string SerializeForJson(List<Car> objects)
        {
            string jsonData = JsonConvert.SerializeObject(objects);

            return jsonData;
        }

        public void SerializeForXML(List<Car> objects)
        {
            using (FileStream fs = new FileStream(this.XmlPath, FileMode.Create))
            {
                XmlSerializer xs = new XmlSerializer(typeof(List<Car>));
                xs.Serialize(fs, objects);
            }
        }
    }
}
