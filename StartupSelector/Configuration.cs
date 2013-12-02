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

            public override string ToString()
            {
                return Name;
            }
        }

        public class Profile
        {
            [XmlElement("name")]
            public string Name { get; set; }
            [XmlArray("active")]
            [XmlArrayItem("name")]
            public List<string> Active { get; set; }

            public override string ToString()
            {
                return Name;
            }

            public Profile()
            {
                Active = new List<string>();
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
        [XmlArray("profiles")]
        [XmlArrayItem("profile")]
        public List<Profile> Profiles { get; set; }
        [XmlElement("userSettings")]
        public Settings UserSettings { get; set; }

        public Configuration()
        {
            Profiles = new List<Profile>();
            Programs = new List<Program>();
            UserSettings = new Settings();
        }
    }
}
