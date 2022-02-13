using System.ComponentModel;

namespace PPGManager;

partial class Mods
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

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
        this.PackageMod = new System.Windows.Forms.Button();
        this.DeleteButton = new System.Windows.Forms.Button();
        this.ModInfoLabel = new System.Windows.Forms.Label();
        this.ModLabel = new System.Windows.Forms.Label();
        this.ModPictureBox = new System.Windows.Forms.PictureBox();
        this.ModsListBox = new System.Windows.Forms.ListBox();
        this.ModEnabled = new System.Windows.Forms.CheckBox();
        ((System.ComponentModel.ISupportInitialize)(this.ModPictureBox)).BeginInit();
        this.SuspendLayout();
        // 
        // PackageMod
        // 
        this.PackageMod.Enabled = false;
        this.PackageMod.Location = new System.Drawing.Point(326, 299);
        this.PackageMod.Name = "PackageMod";
        this.PackageMod.Size = new System.Drawing.Size(100, 30);
        this.PackageMod.TabIndex = 12;
        this.PackageMod.Text = "Package";
        this.PackageMod.UseVisualStyleBackColor = true;
        this.PackageMod.Click += new System.EventHandler(this.PackageMod_Click);
        // 
        // DeleteButton
        // 
        this.DeleteButton.Enabled = false;
        this.DeleteButton.Location = new System.Drawing.Point(432, 299);
        this.DeleteButton.Name = "DeleteButton";
        this.DeleteButton.Size = new System.Drawing.Size(100, 30);
        this.DeleteButton.TabIndex = 11;
        this.DeleteButton.Text = "Delete";
        this.DeleteButton.UseVisualStyleBackColor = true;
        this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
        // 
        // ModInfoLabel
        // 
        this.ModInfoLabel.Location = new System.Drawing.Point(216, 90);
        this.ModInfoLabel.Name = "ModInfoLabel";
        this.ModInfoLabel.Size = new System.Drawing.Size(316, 113);
        this.ModInfoLabel.TabIndex = 10;
        this.ModInfoLabel.Text = "In this screen, you can view info and delete mods. You can also package mods.";
        // 
        // ModLabel
        // 
        this.ModLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ModLabel.Location = new System.Drawing.Point(297, 12);
        this.ModLabel.Name = "ModLabel";
        this.ModLabel.Size = new System.Drawing.Size(235, 75);
        this.ModLabel.TabIndex = 9;
        this.ModLabel.Text = "Choose a mod";
        // 
        // ModPictureBox
        // 
        this.ModPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.ModPictureBox.Location = new System.Drawing.Point(216, 12);
        this.ModPictureBox.Name = "ModPictureBox";
        this.ModPictureBox.Size = new System.Drawing.Size(75, 75);
        this.ModPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        this.ModPictureBox.TabIndex = 8;
        this.ModPictureBox.TabStop = false;
        // 
        // ModsListBox
        // 
        this.ModsListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.ModsListBox.FormattingEnabled = true;
        this.ModsListBox.ItemHeight = 15;
        this.ModsListBox.Items.AddRange(new object[] { "Currently loading list.", "Please wait." });
        this.ModsListBox.Location = new System.Drawing.Point(12, 12);
        this.ModsListBox.Name = "ModsListBox";
        this.ModsListBox.Size = new System.Drawing.Size(198, 317);
        this.ModsListBox.TabIndex = 7;
        this.ModsListBox.SelectedIndexChanged += new System.EventHandler(this.ModsListBox_SelectedIndexChanged);
        // 
        // ModEnabled
        // 
        this.ModEnabled.Enabled = false;
        this.ModEnabled.Location = new System.Drawing.Point(233, 303);
        this.ModEnabled.Name = "ModEnabled";
        this.ModEnabled.Size = new System.Drawing.Size(76, 24);
        this.ModEnabled.TabIndex = 13;
        this.ModEnabled.Text = "Enabled";
        this.ModEnabled.UseVisualStyleBackColor = true;
        this.ModEnabled.CheckedChanged += new System.EventHandler(this.ModEnabled_CheckedChanged);
        // 
        // Mods
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(544, 341);
        this.Controls.Add(this.ModEnabled);
        this.Controls.Add(this.PackageMod);
        this.Controls.Add(this.DeleteButton);
        this.Controls.Add(this.ModInfoLabel);
        this.Controls.Add(this.ModLabel);
        this.Controls.Add(this.ModPictureBox);
        this.Controls.Add(this.ModsListBox);
        this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
        this.Name = "Mods";
        this.ShowInTaskbar = false;
        this.Text = "Mods";
        this.Load += new System.EventHandler(this.Mods_Load);
        ((System.ComponentModel.ISupportInitialize)(this.ModPictureBox)).EndInit();
        this.ResumeLayout(false);
    }

    private System.Windows.Forms.CheckBox ModEnabled;

    private System.Windows.Forms.Button PackageMod;
    private System.Windows.Forms.Button DeleteButton;
    private System.Windows.Forms.Label ModInfoLabel;
    private System.Windows.Forms.Label ModLabel;
    private System.Windows.Forms.PictureBox ModPictureBox;
    private System.Windows.Forms.ListBox ModsListBox;

    #endregion
}