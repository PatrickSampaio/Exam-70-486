using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XmlTeste
{
    [Serializable]
    public class Person
    {
        [XmlAttribute]
        public string FirstName { get; set; }
        [XmlAttribute]
        public string LastName  { get; set; }
        [XmlAttribute]
        public int Age { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person
            {
                FirstName = "Patrick",
                Age = 18,
                LastName = "Brandão"
            };
            XmlSerialization(p);
            BinarySerialization(p);
        }

        public static void XmlSerialization(Person p)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Person));
            string xml;

            using (StringWriter stringWriter = new StringWriter())
            {

                serializer.Serialize(stringWriter, p);
                xml = stringWriter.ToString();
            }

            Console.WriteLine(xml);

            using (StringReader xmlReader = new StringReader(xml))
            {
                Person p1 = (Person)serializer.Deserialize(xmlReader);
                Console.WriteLine("{0} {1} is {2} years old", p1.FirstName, p1.LastName, p1.Age);
            }
        }

        public static void BinarySerialization(Person p)
        {
            IFormatter formatter = new BinaryFormatter();
            using (Stream stream = new FileStream("data.bin", FileMode.Create))
            {
                formatter.Serialize(stream, p);
            }

            using (Stream stream = new FileStream("data.bin", FileMode.Open))
            {
                Person dp = (Person)formatter.Deserialize(stream);
            }
        }
    }
}
