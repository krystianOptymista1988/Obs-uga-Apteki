using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Obsługa_Apteki
{
    public class FileActions<T> where T : new()
    {
        private string _filePath;

        public FileActions(string filePath)
        {
            _filePath = filePath;
        }

        public void SerializeToFile(T medicines)
        {
            var serializer = new XmlSerializer(typeof(T));

            using (var streamWriter = new StreamWriter(_filePath))
            {
                serializer.Serialize(streamWriter, medicines);
                streamWriter.Close();
            }
        }

        public T DeserializeFromFile()
        {
            if (!File.Exists(_filePath))
                return new T();

            var serializer = new XmlSerializer(typeof(T));

            using (var streamReader = new StreamReader(_filePath))
            {
                var medicines = (T)serializer.Deserialize(streamReader);
                streamReader.Close();
                return medicines;
            }
        }

    }
}
