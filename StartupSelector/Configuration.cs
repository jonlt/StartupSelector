using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace StartupSelector
{
    [Serializable()]
    [XmlRoot("config")]
    public class Configuration
    {
        public class Program
        {
            [XmlElement("name")]
            public string Name { get; set; }
            [XmlElement("path")]
            public string Path { get; set; }
            [XmlElement("selected")]
            public bool Selected { get; set; }

            public override string ToString()
            {
                return Name;
            }
        }

        public class Settings
        {
            [XmlElement("selectedProfile")]
            public string SelectedProfile { get; set; }
        }

        [XmlArray("programs")]
        [XmlArrayItem("program")]
        public List<Program> Programs { get; set; }

        public Configuration()
        {
            Programs = new List<Program>();
        }
    }
}
