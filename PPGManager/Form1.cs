using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PPGManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (Checks.PPGExists()) return;
            
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "People Playground|People Playground.exe";
            openFileDialog.Title = "Locate People Playground.exe";
            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                Environment.Exit(0);
            }
            else
            {
                Directory.SetCurrentDirectory(Path.GetDirectoryName(openFileDialog.FileName) ?? throw new InvalidOperationException());
                openFileDialog.Dispose();
            }
        }
        
        private void ButtonMods_Click(object sender, EventArgs e)
        {
            Mods mods = new Mods();
            mods.ShowDialog();
        }

        private void ButtonContraptions_Click(object sender, EventArgs e)
        {
            Contraptions contraptions = new Contraptions();
            contraptions.ShowDialog();
        }

        private void ButtonPlay_Click(object sender, EventArgs e)
        {
            Process.Start("People Playground.exe");
            Environment.Exit(0);
        }
    }
}