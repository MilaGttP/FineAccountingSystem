
using System.Runtime.Serialization;
using System.Xml;

namespace FineAccountingSystem
{
    public class FileData
    {
        public static void Serialize<T>(T obj, string fileName)
        {
            try {
                DataContractSerializer serializer = new DataContractSerializer(typeof(T));
                var settings = new XmlWriterSettings() { Indent = true, IndentChars = "\t" };
                XmlWriter writer = XmlWriter.Create(fileName, settings);
                serializer.WriteObject(writer, obj);
                writer.Close();
                if (!File.Exists(fileName)) throw new FileNotFoundException(fileName);
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
        public static T Deserialize<T>(string fileName)
        {
            try {
                if (!File.Exists(fileName)) throw new FileNotFoundException(fileName);
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            FileStream stream = new FileStream(fileName, FileMode.Open);
            XmlTextReader reader = new XmlTextReader(stream);
            DataContractSerializer serializer = new DataContractSerializer(typeof(T));
            T obj = (T)serializer.ReadObject(reader, true);
            reader.Close(); stream.Close();
            return obj;
        }
    }
}
