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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StartupSelector
{
    public partial class Startup : Form
    {
        private readonly string _profilesPath = ConfigurationManager.AppSettings["profilesPath"];

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

            if (!Directory.Exists(_profilesPath))
            {
                Directory.CreateDirectory(_profilesPath);
            }

            CreateProfileButtons();
        }

        private void CreateProfileButtons()
        {

            var dir = new DirectoryInfo(_profilesPath);
            var dirs = dir.GetDirectories();

            var start = new Point(13, 13);
            var size = new Size(239, 35);

            var regex = new Regex("[A-Z]");


            for (int i = 0; i < dirs.Count(); i++)
            {
                var currentDir = dirs[i];
                var name = currentDir.Name;

                var button = new Button
                    {
                        Text = regex.Replace(name, "&$0", 1), // add mnemonic
                        Size = size,
                        Location = new Point(start.X, start.Y),
                        UseMnemonic = true,
                    };

                button.Click += ButtonOnClick;
                Controls.Add(button);
                start.Y += size.Height + 6;
            }
        }

        private void ButtonOnClick(object sender, EventArgs eventArgs)
        {
            var button = (Button) sender;
            var name = button.Text.Replace("&", "");

            var dir = new DirectoryInfo(_profilesPath + "/" + name);

            foreach (var file in dir.GetFiles())
            {
                try
                {
                    Process.Start(file.FullName);
                }
                catch (Exception e)
                {
                    
                }
            }

            Close();
        }
            
    }
}
