using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Windows.Forms;
using System.Text.Json;
using SevenZipNET;
using SharpCompress.Archives;
using SharpCompress.Archives.Rar;
using SharpCompress.Common;

// ReSharper disable InconsistentNaming
// ReSharper disable LocalizableElement

namespace PPGManager
{

    public class ModInfo
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string ModVersion { get; set; }
        public string GameVersion { get; set; }
        public string ThumbnailPath { get; set; }
        public bool Active { get; set; }
        public string EntryPoint { get; set; }
        public string[] Tags { get; set; }
        public string[] Scripts { get; set; }
        public string UGCIdentity { get; set; }
        public string CreatorUGCIdentity { get; set; }
    }

    public class ContraptionInfo
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Version { get; set; }
    }
    
    public partial class Installer : Form
    {
        private ContraptionInfo contraptionInfo;
        private ModInfo modInfo;
        private string modtempdir;
        public string path;
        public string type;
        public Installer()
        {
            InitializeComponent();
        }

        private void InfoLabel_Click(object sender, EventArgs e)
        {
            
        }

        private void Installer_Load(object sender, EventArgs e)
        {
            this.DisableCloseButton();
            string randomstr = Shared.RandomString(20);
            modtempdir = $@"{Directory.GetCurrentDirectory()}\TempFiles\{randomstr}";
            if (Directory.Exists(modtempdir))
            {
                throw new DuplicateNameException(
                    "You must be really lucky, because your PC made a random string more than once. If this happens often, delete the TempFiles folder in your People Playground folder.");
            }
            else
            {
                Directory.CreateDirectory(modtempdir);
            }

            if (type == ".zip")
            {
                try
                {
                    ZipFile.ExtractToDirectory(path, modtempdir); // .\TempFiles\randomajdfedhauelakeua
                    GC.Collect();
                }
                catch (InvalidDataException)
                {
                    MessageBox.Show("Mod/contraption is corrupted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Directory.Delete($"TempFiles", true);
                    Hide();
                    Close();
                    return;
                }   
            }
            else if (type == ".7z")
            {
                SevenZipExtractor zz = new SevenZipExtractor(path);
                SevenZipBase.Path7za = "7za.exe";
                zz.ExtractAll(modtempdir);
                GC.Collect();
            }
            else if (type == ".rar")
            {
                RarArchive archive = RarArchive.Open(path);
                foreach (var entry in archive.Entries.Where(entry => !entry.IsDirectory))
                {
                    entry.WriteToDirectory(modtempdir, new ExtractionOptions()
                    {
                        ExtractFullPath = true,
                        Overwrite = true
                    });

                }
                
                archive.Dispose();
                GC.Collect();
            }

            if (!File.Exists($@"{modtempdir}\mod.json")) // contraption
            {
                string[] files = Directory.GetFiles(modtempdir, "*.json");
                try
                {
                    contraptionInfo = JsonSerializer.Deserialize<ContraptionInfo>(File.ReadAllText(files[0]));
                }
                catch (Exception)
                {
                    if (Debugger.IsAttached)
                        throw;
                    
                    // will get handled later
                }
                
                try
                {
                    // ReSharper disable once PossibleNullReferenceException
                    Image image = Image.FromFile($@"{modtempdir}\{contraptionInfo.Name}.png");
                    byte[] imageBytes = Shared.ImageToByteArray(image); // stores the image as a byte array in memory
                    IconBox.Image = Shared.ByteArrayToImage(imageBytes); // sets the PictureBox to the byte array as an image
                    image.Dispose(); // makes the actual image file freed from the program (so it can move it)
                    this.Text = contraptionInfo.DisplayName;
                    NameLabel.Text = contraptionInfo.DisplayName;
                    InfoLabel.Text = $"Type: Contraption\n" +
                                     $"Required game version: {contraptionInfo.Version}";
                    button1.Enabled = true;
                }
                catch (Exception)
                {
                    if (Debugger.IsAttached)
                        throw;

                    MessageBox.Show("Failed to get required contraption information.\nIt may be corrupted or just not a contraption at all.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Directory.Delete($"TempFiles", true);
                    this.Hide();
                    this.Close();
                }
            }
            else // mod
            {
                try
                {
                    modInfo = JsonSerializer.Deserialize<ModInfo>(File.ReadAllText($@"{modtempdir}\mod.json"));
                }
                catch (JsonException)
                {
                    if (Debugger.IsAttached)
                        throw;
                        
                        // it will handle it later
                }
                
                try
                {
                    // ReSharper disable once PossibleNullReferenceException
                    Image image = Image.FromFile($@"{modtempdir}\{modInfo.ThumbnailPath}");
                    byte[] imageBytes = Shared.ImageToByteArray(image); // stores the image as a byte array in memory
                    IconBox.Image = Shared.ByteArrayToImage(imageBytes); // sets the PictureBox to the byte array as an image
                    image.Dispose(); // makes the actual image file freed from the program (so it can move it)
                    this.Text = modInfo.Name;
                    NameLabel.Text = modInfo.Name;
                    InfoLabel.Text = $"by {modInfo.Author}\n" +
                                     $"Type: Mod\n" +
                                     $"Mod version: {modInfo.ModVersion}\n" +
                                     $"Required game version: {modInfo.GameVersion}\n" +
                                     $"Description: {modInfo.Description}";
                    button1.Enabled = true;
                }
                catch (Exception)
                {
                    //if (Debugger.IsAttached)
                        //throw;
                    
                    MessageBox.Show("Failed to get required mod information. It may be corrupted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Directory.Delete($"TempFiles", true);
                    this.Hide();
                    this.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Directory.Delete($"TempFiles", true);
            this.Hide();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!File.Exists($@"{modtempdir}\mod.json")) // contraption
            {
                if (!Directory.Exists("Contraptions"))
                {
                    Directory.CreateDirectory("Contraptions");
                }

                if (Directory.Exists($"Contraptions/{contraptionInfo.Name.Replace(" ", "")}")) // so it wont crash on reinstall of a contraption
                {
                    Directory.Delete($"Contraptions/{contraptionInfo.Name.Replace(" ", "")}", true);
                }
                
                Directory.Move(modtempdir, $"Contraptions/{contraptionInfo.Name.Replace(" ", "")}");
                Directory.Delete($"TempFiles", true);
                MessageBox.Show("Successfully installed contraption.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                this.Close();
            }
            else // mod
            {
                if (!Directory.Exists("Mods"))
                {
                    Directory.CreateDirectory("Mods");
                }

                if (Directory.Exists($"Mods/{modInfo.Name.Replace(" ", "")}")) // so it wont crash on reinstall of a mod
                {
                    Directory.Delete($"Mods/{modInfo.Name.Replace(" ", "")}", true);
                }
                
                Directory.Move(modtempdir, $"Mods/{modInfo.Name.Replace(" ", "")}");
                Directory.Delete($"TempFiles", true);
                MessageBox.Show("Successfully installed mod.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                this.Close();
            }
        }
    }
}