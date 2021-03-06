using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
// ReSharper disable InconsistentNaming
// ReSharper disable LocalizableElement

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

            if (Shared.PPGExists())
            {
                
            }
            else
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = @"People Playground|People Playground.exe";
                openFileDialog.Title = @"Locate People Playground.exe";
                if (openFileDialog.ShowDialog() != DialogResult.OK)
                {
                    Environment.Exit(0);
                }
                else
                {
                    Directory.SetCurrentDirectory(Path.GetDirectoryName(openFileDialog.FileName) ??
                                                  throw new InvalidOperationException());
                    openFileDialog.Dispose();
                }
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
        
        private void label1_DragDrop(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.None;
            string[] filePath = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            string path = filePath[0];
            string extension = Path.GetExtension(filePath[0]);
            if (extension != ".zip" && extension != ".7z" && extension != ".rar")
            {
                MessageBox.Show(@"Not a valid file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                FileInfo info = new FileInfo(path);
                long size = info.Length;
                if (size >= 20971520)
                {
                    string rslashn = Environment.NewLine;
                    if (MessageBox.Show($"This file is over 20 MB.{rslashn}The file name is {info.Name}.{rslashn}If this is actually a mod/contraption, say Yes.{rslashn}Otherwise, say No.", @"Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        
                    }
                    else
                    {
                        return;
                    }
                }
                Installer installer = new Installer();
                installer.path = path;
                installer.type = extension;
                installer.ShowDialog();
            }
        }

        private void label1_DragEnter(object sender, DragEventArgs e)
        {
            string[] filePath = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            string extension = Path.GetExtension(filePath[0]);
            //MessageBox.Show(filePath[0]);
            if (extension is ".zip" or ".7z" or ".rar")
            {
                e.Effect = DragDropEffects.All;
            }
        }

        private void label1_DragLeave(object sender, EventArgs e)
        {
            
        }

        private void ButtonFindAddon_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = @"Zip file|*.zip|7-Zip file|*.7z|RAR file|*.rar";
            openFileDialog.Title = @"Find a mod/contraption file";
            openFileDialog.RestoreDirectory = false;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileInfo info = new FileInfo(openFileDialog.FileName);
                long size = info.Length;
                if (size >= 20971520)
                {
                    string rslashn = Environment.NewLine;

                    if (MessageBox.Show(
                            
                            $"This file is over 20 MB.{rslashn}The file name is {info.Name}.{rslashn}If this is actually a mod/contraption, say Yes.{rslashn}Otherwise, say No.",
                            @"Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        
                    }
                    else
                    {
                        return;
                    }
                }
                Installer installer = new Installer();
                installer.path = openFileDialog.FileName;
                string extension = Path.GetExtension(openFileDialog.FileName);
                installer.type = extension;
                installer.ShowDialog();
            }
            
        }
    }
}