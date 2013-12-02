using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
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
            LoadConfiguration(ConfigurationManager.AppSettings["configFile"]);
        }

        private void LoadConfiguration(string configurationFile)
        {
            try
            {
                var configFile = configurationFile;
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

        private void btnSelected_Click(object sender, EventArgs e)
        {
            foreach (var program in GetSelectedPrograms())
            {
                if (program != null)
                {
                    StartProgram(program);
                }
            }
            
            Close();
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            foreach (var program in GetAllPrograms())
            {
                if (program != null)
                {
                    StartProgram(program);
                }
            }

            Close();
        }

        private void btnNone_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void StartProgram(Configuration.Program program)
        {
            Process.Start(program.Path);
        }

        private IEnumerable<Configuration.Program> GetSelectedPrograms()
        {
            return clbPrograms.CheckedItems.OfType<string>()
                              .Select(s => _configuration.Programs.SingleOrDefault(p => p.Name == s))
                              .Where(p => p != null);
        }

        private IEnumerable<Configuration.Program> GetAllPrograms()
        {
            return _configuration.Programs;
        }
    }
}
