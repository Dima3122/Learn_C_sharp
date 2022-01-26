using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace serialization
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int>();
            list.Add(2);
            list.Add(6);
            list.Add(10);
            list.Add(10);
            list.Add(10);
            list.Add(10);
            list.Add(10);
            list.Add(10);
            list.Add(10);
            list.Add(10);
            list.Add(10);
            list.Add(10);
            var xmlFormater = new XmlSerializer(typeof(List<int>));
            using (var file = new FileStream("file.xml", FileMode.OpenOrCreate))
            {
                xmlFormater.Serialize(file, list);
            }
            using (var file = new FileStream("file.xml", FileMode.Open))
            {
                var desirialese = xmlFormater.Deserialize(file) as List<int>;
                if (desirialese != null)
                {
                    foreach (var item in desirialese)
                    {
                        Console.WriteLine(desirialese);
                    }
                }
            }
        }
    }
}
