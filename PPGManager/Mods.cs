using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
// ReSharper disable LocalizableElement

namespace PPGManager;

public partial class Mods : Form
{
    public Mods()
    {
        InitializeComponent();
    }

    private bool _checkboxAutoAction = true;
    
    private void Mods_Load(object sender, EventArgs e)
    {

        void Action(object obj)
        {
            List<string> modList = new List<string>();
            
            foreach (string s in Directory.GetDirectories("Mods", "*", SearchOption.TopDirectoryOnly))
            {
                ModInfo modInfo = JsonSerializer.Deserialize<ModInfo>(File.ReadAllText($"{s}/mod.json"));
                if (modInfo != null) modList.Add(modInfo.Name);
            }
            
            ModsListBox.DataSource = modList;
            ModsListBox.SelectedItem = null;
        }

        Task loadMods = new Task(Action, null);
        loadMods.Start(); // multithreading solves all your problems
    }

    private void ModsListBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        _checkboxAutoAction = true;
        
        string selectedMod = ModsListBox.GetItemText(ModsListBox.SelectedItem);
        string fileName = selectedMod.Replace(" ", "");

        try
        {
            ModInfo modInfo =
                JsonSerializer.Deserialize<ModInfo>(
                    File.ReadAllText($@"Mods\{fileName}\mod.json"));

            if (modInfo != null)
            {
                Image image = Image.FromFile($@"Mods\{fileName}\{modInfo.ThumbnailPath}");
                byte[] imageBytes = Shared.ImageToByteArray(image);
                ModPictureBox.Image = Shared.ByteArrayToImage(imageBytes);
                image.Dispose();
            }

            if (modInfo != null)
            {
                ModLabel.Text = modInfo.Name;
                ModEnabled.Checked = modInfo.Active;
                // ReSharper disable once LocalizableElement
                ModInfoLabel.Text = $"by {modInfo.Author}\n" +
                                    $"Type: Mod\n" +
                                    $"Mod version: {modInfo.ModVersion}\n" +
                                    $"Required game version: {modInfo.GameVersion}\n" +
                                    $"Description: {modInfo.Description}";
            }

            DeleteButton.Enabled = true;
            PackageMod.Enabled = true;
            ModEnabled.Enabled = true;
        }
        catch (FileNotFoundException)
        {
            ModPictureBox.Image = null;
            ModLabel.Text = "Choose a mod";
            ModInfoLabel.Text = "In this screen, you can view info and delete mods. You can also package mods.";
                
            DeleteButton.Enabled = false;
            PackageMod.Enabled = false;
            ModEnabled.Enabled = false;
            ModEnabled.Checked = false;
        }

        _checkboxAutoAction = false;
    }

    private void DeleteButton_Click(object sender, EventArgs e)
    {
        string selectedMod = ModsListBox.GetItemText(ModsListBox.SelectedItem);
        if (MessageBox.Show(@$"Are you sure you want to delete {selectedMod}?", @"Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
        {
            string fileName = selectedMod.Replace(" ", "");
            Directory.Delete($@"Mods\{fileName}", true);
            ModsListBox.Items.Remove(ModsListBox.SelectedItem);
        }
    }

    private void PackageMod_Click(object sender, EventArgs e)
    {
        Package package = new Package();
        package.selectedItem = ModsListBox.GetItemText(ModsListBox.SelectedItem);
        package.Type = package.Mod;
        package.ShowDialog();
    }

    private void ModEnabled_CheckedChanged(object sender, EventArgs e)
    {
        if (_checkboxAutoAction == false)
        {
            string selectedMod = ModsListBox.GetItemText(ModsListBox.SelectedItem);
            string fileName = selectedMod.Replace(" ", "");

            ModInfo modInfo =
                JsonSerializer.Deserialize<ModInfo>(
                    File.ReadAllText($@"Mods\{fileName}\mod.json"));
                
            var newJson = new ModInfo()
            {
                // ReSharper disable once PossibleNullReferenceException
                Name = modInfo.Name,
                Author = modInfo.Author,
                Description = modInfo.Description,
                ModVersion = modInfo.ModVersion,
                GameVersion = modInfo.GameVersion,
                ThumbnailPath = modInfo.ThumbnailPath,
                EntryPoint = modInfo.EntryPoint,
                Tags = modInfo.Tags,
                Scripts = modInfo.Scripts,
                Active = ModEnabled.Checked,
                UGCIdentity = modInfo.UGCIdentity,
                CreatorUGCIdentity = modInfo.CreatorUGCIdentity
            };

            JsonSerializerOptions options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping, // calm down Microsoft
                WriteIndented = true
            };
            string jsonString = JsonSerializer.Serialize(newJson, options);
            File.WriteAllText($@"Mods\{fileName}\mod.json", jsonString);
        }
    }
}