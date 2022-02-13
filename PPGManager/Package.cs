using System;
using System.IO;
using System.IO.Compression;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Windows.Forms;
// ReSharper disable LocalizableElement
// ReSharper disable InconsistentNaming
namespace PPGManager;

public partial class Package : Form
{
    public string Mod = "Mods";
    public string Contraption = "Contraptions";

    public string Type;
    
    public string selectedItem;
    
    public Package()
    {
        InitializeComponent();
    }

    private void StartPackage_Click(object sender, EventArgs e)
    {
        string fileName = selectedItem.Replace(" ", "");
        if (Type == Mod)
        {
            ModInfo modInfo = JsonSerializer.Deserialize<ModInfo>(File.ReadAllText($@"Mods\{fileName}\mod.json"));
                
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
                Active = EnableCheckBox.Checked,
                UGCIdentity = modInfo.UGCIdentity,
                CreatorUGCIdentity = modInfo.CreatorUGCIdentity
            };
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping, // calm down Microsoft
                WriteIndented = true
            };
            string jsonString = JsonSerializer.Serialize(newJson, options);
            File.Move($@"Mods\{fileName}\mod.json", @"Mods\mod_backup.json");
            File.Create($@"Mods\{fileName}\mod.json").Dispose();
            File.WriteAllText($@"Mods\{fileName}\mod.json", jsonString);   
        }
        
        if (File.Exists(FileLocation.Text))
        {
            File.Delete(FileLocation.Text);
        }
        ZipFile.CreateFromDirectory($"{Type}/{fileName}", FileLocation.Text);
        if (Type == Mod)
        {
            File.Delete($@"Mods\{fileName}\mod.json");
            File.Move(@"Mods\mod_backup.json", $@"Mods\{fileName}\mod.json");
        }
        MessageBox.Show($"Created package at:\n{FileLocation.Text}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void FileLocation_TextChanged(object sender, EventArgs e)
    {
        try
        {
            StartPackage.Enabled = Directory.Exists(Path.GetDirectoryName(FileLocation.Text));
        }
        catch (Exception)
        {
            StartPackage.Enabled = false;
        }
    }

    private void FileButton_Click(object sender, EventArgs e)
    {
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        saveFileDialog.FileName = $"{selectedItem}.zip";
        saveFileDialog.DefaultExt = "zip";
        saveFileDialog.AddExtension = true;
        saveFileDialog.Title = "Save to location";
        saveFileDialog.Filter = "Zip file|*.zip";
        if (saveFileDialog.ShowDialog() == DialogResult.OK)
        {
            FileLocation.Text = saveFileDialog.FileName;
        }
    }

    private void Package_Load(object sender, EventArgs e)
    {
        if (Type == Contraption)
        {
            EnableCheckBox.Checked = false;
            EnableCheckBox.Enabled = false;
        }
    }
}