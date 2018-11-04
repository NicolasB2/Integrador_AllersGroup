using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace serializables
{

    public static class SerializableItemSets
    {
        public static void SerializeObject(this List<int[]> list, string fileName)
        {
            var serializer = new XmlSerializer(typeof(List<int[]>));
            using (var stream = File.OpenWrite(fileName))
            {
                serializer.Serialize(stream, list);
            }
        }

        public static void Deserialize(this List<int[]> list, string fileName)
        {
            var serializer = new XmlSerializer(typeof(List<int[]>));
            using (var stream = File.OpenRead(fileName))
            {
                var other = (List<int[]>)(serializer.Deserialize(stream));
                list.Clear();
                list.AddRange(other);
            }
        }
    }
}
