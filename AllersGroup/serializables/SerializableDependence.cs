using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace serializables
{
    static class SerializableDependence
    {
        public static void SerializeObject(this Dictionary<int, List<int[]>> list, string fileName)
        {
            var serializer = new XmlSerializer(typeof(Dictionary<int, List<int[]>>));
            using (var stream = File.OpenWrite(fileName))
            {
                serializer.Serialize(stream, list);
            }
        }

        public static void Deserialize(this Dictionary<int, List<int[]>> list, string fileName)
        {
            var serializer = new XmlSerializer(typeof(Dictionary<int, List<int[]>>));
            using (var stream = File.OpenRead(fileName))
            {
                var other = (Dictionary<int, List<int[]>>)(serializer.Deserialize(stream));
                list.Clear();
                list = other;
            }
        }
    }
}
