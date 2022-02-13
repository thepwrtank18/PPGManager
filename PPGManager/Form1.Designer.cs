namespace PPGManager
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ButtonMods = new System.Windows.Forms.Button();
            this.ButtonContraptions = new System.Windows.Forms.Button();
            this.ButtonPlay = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ButtonFindAddon = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ButtonMods
            // 
            this.ButtonMods.Location = new System.Drawing.Point(12, 12);
            this.ButtonMods.Name = "ButtonMods";
            this.ButtonMods.Size = new System.Drawing.Size(140, 30);
            this.ButtonMods.TabIndex = 0;
            this.ButtonMods.Text = "Mods";
            this.ButtonMods.UseVisualStyleBackColor = true;
            this.ButtonMods.Click += new System.EventHandler(this.ButtonMods_Click);
            // 
            // ButtonContraptions
            // 
            this.ButtonContraptions.Location = new System.Drawing.Point(162, 12);
            this.ButtonContraptions.Name = "ButtonContraptions";
            this.ButtonContraptions.Size = new System.Drawing.Size(140, 30);
            this.ButtonContraptions.TabIndex = 1;
            this.ButtonContraptions.Text = "Contraptions";
            this.ButtonContraptions.UseVisualStyleBackColor = true;
            this.ButtonContraptions.Click += new System.EventHandler(this.ButtonContraptions_Click);
            // 
            // ButtonPlay
            // 
            this.ButtonPlay.Location = new System.Drawing.Point(12, 159);
            this.ButtonPlay.Name = "ButtonPlay";
            this.ButtonPlay.Size = new System.Drawing.Size(290, 30);
            this.ButtonPlay.TabIndex = 2;
            this.ButtonPlay.Text = "Play";
            this.ButtonPlay.UseVisualStyleBackColor = true;
            this.ButtonPlay.Click += new System.EventHandler(this.ButtonPlay_Click);
            // 
            // label1
            // 
            this.label1.AllowDrop = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(12, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(290, 110);
            this.label1.TabIndex = 3;
            this.label1.Text = "Drag to add mods/contraptions, or";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.DragDrop += new System.Windows.Forms.DragEventHandler(this.label1_DragDrop);
            this.label1.DragEnter += new System.Windows.Forms.DragEventHandler(this.label1_DragEnter);
            this.label1.DragLeave += new System.EventHandler(this.label1_DragLeave);
            // 
            // ButtonFindAddon
            // 
            this.ButtonFindAddon.Location = new System.Drawing.Point(108, 112);
            this.ButtonFindAddon.Name = "ButtonFindAddon";
            this.ButtonFindAddon.Size = new System.Drawing.Size(97, 23);
            this.ButtonFindAddon.TabIndex = 4;
            this.ButtonFindAddon.Text = "Find in Explorer";
            this.ButtonFindAddon.UseVisualStyleBackColor = true;
            this.ButtonFindAddon.Click += new System.EventHandler(this.ButtonFindAddon_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 201);
            this.Controls.Add(this.ButtonFindAddon);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ButtonPlay);
            this.Controls.Add(this.ButtonContraptions);
            this.Controls.Add(this.ButtonMods);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "PPG Mod Manager";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button ButtonFindAddon;

        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.Button ButtonPlay;

        private System.Windows.Forms.Button ButtonContraptions;

        private System.Windows.Forms.Button ButtonMods;

        #endregion
    }
}