using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Training5
{
   public interface Iserializer<T>
    {
        List<T> DeserializeForBinary();

        void SerializeForBinary(List<T> objects);

        List<T> DeserializeForXML();

        void SerializeForXML(List<T> objects);

        List<T> DeserializeForJson(string jsonData);

        string SerializeForJson(List<T> objects);
    }
}
