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

namespace StartupSelector
{
    public partial class Startup : Form
    {
        private readonly Dictionary<Keys, Button> _keybindings = new Dictionary<Keys, Button>();
        private string _profilesPath = ConfigurationManager.AppSettings["profilesPath"];

        public Startup()
        {
            InitializeComponent();

            if (_profilesPath == null)
            {
                _profilesPath = "Profiles";
            }

            if (_profilesPath.EndsWith("/"))
            {
                _profilesPath = _profilesPath.Remove(_profilesPath.Length - 1);
            }

            CreateProfileButtons();
        }

        private void CreateProfileButtons()
        {

            var dir = new DirectoryInfo(_profilesPath);
            var dirs = dir.GetDirectories();

            var start = new Point(13, 13);
            var size = new Size(239, 35);

            var spacing = 6;

            for (int i = 0; i < dirs.Count(); i++)
            {
                var currentDir = dirs[i];
                var name = currentDir.Name;
                var keyBinding = name.ToUpper()[0];

                var button = new Button
                    {
                        Text = name, 
                        Size = size, Location = new Point(start.X, start.Y),
                    };

                button.Click += ButtonOnClick;
                _keybindings[(Keys)keyBinding] = button;
                Controls.Add(button);
                start.Y += size.Height + 6;
            }
        }

        private void ButtonOnClick(object sender, EventArgs eventArgs)
        {
            var button = (Button) sender;
            var name = button.Text;

            var dir = new DirectoryInfo(_profilesPath + "/" + name);

            foreach (var file in dir.GetFiles())
            {
                Process.Start(file.FullName);
            }

            Close();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (_keybindings.ContainsKey(keyData))
            {
                _keybindings[keyData].PerformClick();
            }


            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
