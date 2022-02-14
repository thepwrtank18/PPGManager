using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace PPGManager
{
    public static class Shared
    {

        /// <summary>
        /// Checks for People Playground on the current directory.
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public static bool PPGExists()
        {
            return Directory.Exists("People Playground_Data");
        }
        
        // ReSharper disable once InconsistentNaming
        private static readonly Random _random = new Random();
        
        /// <summary>
        /// Generates a random number within a range.
        /// </summary>
        /// <param name="min">The minimum number it should be.</param>
        /// <param name="max">The maximum number it should be.</param>
        public static int RandomNumber(int min, int max)  
        {  
            return _random.Next(min, max);  
        }  
  
        /// <summary>
        /// Generates a random string within a range.
        /// </summary>
        /// <param name="size">The size of the string.</param>
        /// <param name="lowerCase">Whether you want to make the string lowercase.</param>
        public static string RandomString(int size, bool lowerCase = false)  
        {  
            var builder = new StringBuilder(size);  
  
            // Unicode/ASCII Letters are divided into two blocks
            // (Letters 65–90 / 97–122):   
            // The first group containing the uppercase letters and
            // the second group containing the lowercase.  

            // char is a single Unicode character  
            char offset = lowerCase ? 'a' : 'A';  
            const int lettersOffset = 26; // A...Z or a..z: length = 26  
  
            for (var i = 0; i < size; i++)  
            {  
                var @char = (char)_random.Next(offset, offset + lettersOffset);  
                builder.Append(@char);  
            }  
  
            return lowerCase ? builder.ToString().ToLower() : builder.ToString();  
        }

        /// <summary>
        /// Converts an Image to a byte[], stored in memory.
        /// </summary>
        /// <param name="imageIn">The Image to turn into a byte[].</param>
        public static byte[] ImageToByteArray(Image imageIn)
        {
            using var ms = new MemoryStream();
            imageIn.Save(ms,imageIn.RawFormat);
            return  ms.ToArray();
        }
        
        /// <summary>
        /// Converts the byte[] from ImageToByteArray back into an Image.
        /// </summary>
        /// <param name="byteArrayIn">The byte[] to turn into an Image.</param>
        public static Image ByteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
        
        [DllImport("user32")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        [DllImport("user32")]
        private static extern bool EnableMenuItem(IntPtr hMenu, uint itemId, uint uEnable);
        
        /// <summary>
        /// Disables the close button on the form selected.
        /// </summary>
        /// <param name="form">The form you want to disable the close button on.</param>
        public static void DisableCloseButton(this Form form)
        {
            // The 1 parameter means to gray out. 0xF060 is SC_CLOSE.
            try
            {
                EnableMenuItem(GetSystemMenu(form.Handle, false), 0xF060, 1);
            }
            catch (InvalidOperationException e)
            {
                //if (Debugger.IsAttached)
                //{
                //    throw;
                //}
            }
        }

        /// <summary>
        /// Enables the close button on the form selected.
        /// </summary>
        /// <param name="form">The form you want to enable the close button on.</param>
        public static void EnableCloseButton(this Form form)
        {
            // The zero parameter means to enable. 0xF060 is SC_CLOSE.
            EnableMenuItem(GetSystemMenu(form.Handle, false), 0xF060, 0);
        }
    }
}