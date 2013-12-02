using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StartupSelector.Helpers;

namespace StartupSelector
{
    public partial class Form1 : Form
    {
        private Configuration _configuration;

        public Form1()
        {
            InitializeComponent();
            try
            {
                var configFile = ConfigurationManager.AppSettings["configFile"];
                var xml = File.ReadAllText(configFile);
                _configuration = Serializer.DeserializeXml<Configuration>(xml);
            }
            catch (FileNotFoundException fnfe)
            {
                _configuration = new Configuration();
            }
            catch (Serializer.SerializationException se)
            {
                _configuration = new Configuration();
            }

            var activeProfile = _configuration.Profiles.FirstOrDefault() ?? new Configuration.Profile();

            foreach (var program in _configuration.Programs)
            {
                var state = (activeProfile.Active.Contains(program.Name))
                                ? CheckState.Checked
                                : CheckState.Unchecked;

                clbPrograms.Items.Add(program.Name, state);
            }
        }
    }
}
