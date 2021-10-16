using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Stock_Market
{
    static class FileOperator
    {
        static public string[] ReadBaseInputFile()
        {
            string path = GetPathLocation();
            return File.ReadAllLines(path + "\\instruments.txt");
        }
        static public string SaveAndGetPathOfStocks(List<Stocks> dataToSave)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Stocks>));
            string path = GetPathLocation() + "\\stocks" + DateTime.Now.ToString("yyyy-MM-dd_HHmmss") + ".xml";
            using (TextWriter creator = new StreamWriter(path))
            {
              serializer.Serialize(creator, dataToSave);
            }
            return path;
        }
        static private string GetPathLocation()
        {
            return Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName);
        }
        static public void CreatePurchaseHistory(List<Stocks> dataToSave)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Stocks>));
            string path = GetPathLocation() + "\\purchased.xml";
            using (TextWriter creator = new StreamWriter(path))
            {
                serializer.Serialize(creator, dataToSave);
            }
        }
        static public List<Stocks> GetPurchaseHistory()
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(List<Stocks>));
            string path = GetPathLocation() + "\\purchased.xml";
            using (TextReader reader = new StreamReader(path))
            {
                object obj = deserializer.Deserialize(reader);
                return (List<Stocks>)obj;
            }
        }
    }
}
