using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
// ReSharper disable LocalizableElement

namespace PPGManager
{
    public partial class Contraptions : Form
    {
        public Contraptions()
        {
            InitializeComponent();
        }
        
        private void Contraptions_Load(object sender, EventArgs e)
        {
            void Action(object obj)
            {
                List<string> contraptionList = new List<string>();
                
                foreach (string s in Directory.GetDirectories("Contraptions", "*", SearchOption.TopDirectoryOnly))
                {
                    string[] files = Directory.GetFiles(s, "*.json");
                    ContraptionInfo contraptionInfo = JsonSerializer.Deserialize<ContraptionInfo>(File.ReadAllText(files[0]));
                    if (contraptionInfo != null) contraptionList.Add(contraptionInfo.DisplayName);
                }

                ContraptionsListBox.DataSource = contraptionList;
                ContraptionsListBox.SelectedItem = null;
            }

            Task loadContraptions = new Task(Action, null);
            loadContraptions.Start();
        }

        private void ContraptionsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            string selectedContraption = ContraptionsListBox.GetItemText(ContraptionsListBox.SelectedItem);
            string fileName = selectedContraption.Replace(" ", "");

            try
            {
                ContraptionInfo contraptionInfo =
                    JsonSerializer.Deserialize<ContraptionInfo>(
                        File.ReadAllText($@"Contraptions\{fileName}\{selectedContraption}.json"));
                
                Image image = Image.FromFile($@"Contraptions\{fileName}\{selectedContraption}.png");
                byte[] imageBytes = Shared.ImageToByteArray(image);
                ContraptionPictureBox.Image = Shared.ByteArrayToImage(imageBytes);
                image.Dispose();

                if (contraptionInfo != null)
                {
                    ContraptionLabel.Text = contraptionInfo.DisplayName;
                    // ReSharper disable once LocalizableElement
                    ContraptionInfoLabel.Text = $"Type: Contraption\n" +
                                                $"Required game version: {contraptionInfo.Version}";
                }

                DeleteButton.Enabled = true;
                PackageContraption.Enabled = true;
            }
            catch (FileNotFoundException)
            {
                ContraptionPictureBox.Image = null;
                ContraptionLabel.Text = "Choose a contraption";
                ContraptionInfoLabel.Text = "In this screen, you can view info and delete contraptions. You can also package contraptions.";
                
                DeleteButton.Enabled = false;
                PackageContraption.Enabled = false;
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            string selectedContraption = ContraptionsListBox.GetItemText(ContraptionsListBox.SelectedItem);
            if (MessageBox.Show(@$"Are you sure you want to delete {selectedContraption}?", @"Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string fileName = selectedContraption.Replace(" ", "");
                Directory.Delete($@"Contraptions\{fileName}", true);
                ContraptionsListBox.Items.Remove(ContraptionsListBox.SelectedItem);
            }
        }

        private void PackageContraption_Click(object sender, EventArgs e)
        {
            Package package = new Package();
            package.selectedItem = ContraptionsListBox.GetItemText(ContraptionsListBox.SelectedItem);
            package.Type = package.Contraption;
            package.ShowDialog();
        }
    }
}