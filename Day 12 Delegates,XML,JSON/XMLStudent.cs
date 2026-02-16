using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace CAP2025.Day_12
{
    public class XMLStudent
    {
        public string name;
        public List<int> marks;
        public XMLStudent()
        {

        }
    }
    class StuMain
    {
        public static void Main(String[] args)
        {
            XMLStudent s = new XMLStudent();
            s.name = "Indra";
            s.marks = new List<int> { 56, 77, 85, 99, 66 };
            XmlSerializer serial = new XmlSerializer(typeof(XMLStudent));
            using (StringWriter sw = new StringWriter())
            {
                serial.Serialize(sw, s);
                string Outp = sw.ToString();
                Console.Write(Outp);
            }
        }
    }
}
