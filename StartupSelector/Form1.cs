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
    public partial class Startup : Form
    {
        private Configuration _configuration;
        private readonly string _configFile = ConfigurationManager.AppSettings["configFile"];

        public Startup()
        {
            InitializeComponent();
            LoadConfiguration(_configFile);
            RenderConfiguration();
        }

        private void LoadConfiguration(string configurationFile)
        {
            Configuration configuration;
            try
            {
                var configFile = configurationFile;
                var xml = File.ReadAllText(configFile);
                configuration = Serializer.DeserializeXml<Configuration>(xml);
            }
            catch (FileNotFoundException fnfe)
            {
                configuration = new Configuration();
            }
            catch (Serializer.SerializationException se)
            {
                configuration = new Configuration();
            }
            _configuration = configuration;
        }

        private void RenderConfiguration()
        {
            clbPrograms.Items.Clear();
            foreach (var program in _configuration.Programs)
            {
                var state = (program.Selected)
                                ? CheckState.Checked
                                : CheckState.Unchecked;

                clbPrograms.Items.Add(program.Name ?? "", state);
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

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveConfiguration(_configFile);
        }

        private void SaveConfiguration(string configurationFile)
        {
            foreach (var selectedProgram in GetSelectedPrograms())
            {
                selectedProgram.Selected = true;
            }

            var xml = Serializer.SerializeXml(_configuration);
            File.WriteAllText(configurationFile, xml, Encoding.UTF8);
        }
    }
}
