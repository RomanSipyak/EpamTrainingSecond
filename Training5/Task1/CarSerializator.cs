// <copyright file="Car.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Training5.Task1
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Xml.Serialization;
    using Newtonsoft.Json;

    public class CarSerializator : ISerializer<Car>
    {
        public string BinaryPath { get; set; } = ConfigurationManager.AppSettings["BinaryPath"].ToString();

        public string XmlPath { get; set; } = ConfigurationManager.AppSettings["XmlPath"].ToString();

        public List<Car> DeserializeForBinary()
        {
            using (FileStream fs = new FileStream(this.BinaryPath, FileMode.Open))
            {
                try
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    List<Car> data;
                    data = (List<Car>)bf.Deserialize(fs);
                    return data;
                }
                catch (Exception e)
                {
                    throw e;
                }
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
                try
                {
                    XmlSerializer xs = new XmlSerializer(typeof(List<Car>));
                    List<Car> data;
                    data = (List<Car>)xs.Deserialize(fs);
                    return data;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        public void SerializeForBinary(List<Car> objects)
        {
            using (FileStream fs = new FileStream(this.BinaryPath, FileMode.Create))
            {
                try
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(fs, objects);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        public string SerializeForJson(List<Car> objects)
        {
            try
            {
                string jsonData = JsonConvert.SerializeObject(objects);

                return jsonData;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void SerializeForXML(List<Car> objects)
        {
            using (FileStream fs = new FileStream(this.XmlPath, FileMode.Create))
            {
                try
                {
                    XmlSerializer xs = new XmlSerializer(typeof(List<Car>));
                    xs.Serialize(fs, objects);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
    }
}
