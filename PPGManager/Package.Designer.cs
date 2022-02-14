using System.ComponentModel;

namespace PPGManager;

partial class Package
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
        this.label1 = new System.Windows.Forms.Label();
        this.FileLocation = new System.Windows.Forms.TextBox();
        this.FileButton = new System.Windows.Forms.Button();
        this.EnableCheckBox = new System.Windows.Forms.CheckBox();
        this.StartPackage = new System.Windows.Forms.Button();
        this.label2 = new System.Windows.Forms.Label();
        this.SuspendLayout();
        // 
        // label1
        // 
        this.label1.Location = new System.Drawing.Point(12, 9);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(57, 20);
        this.label1.TabIndex = 0;
        this.label1.Text = "Save to:";
        // 
        // FileLocation
        // 
        this.FileLocation.Location = new System.Drawing.Point(12, 32);
        this.FileLocation.Name = "FileLocation";
        this.FileLocation.ReadOnly = true;
        this.FileLocation.Size = new System.Drawing.Size(191, 23);
        this.FileLocation.TabIndex = 1;
        this.FileLocation.TextChanged += new System.EventHandler(this.FileLocation_TextChanged);
        // 
        // FileButton
        // 
        this.FileButton.Location = new System.Drawing.Point(209, 32);
        this.FileButton.Name = "FileButton";
        this.FileButton.Size = new System.Drawing.Size(63, 23);
        this.FileButton.TabIndex = 2;
        this.FileButton.Text = "Search";
        this.FileButton.UseVisualStyleBackColor = true;
        this.FileButton.Click += new System.EventHandler(this.FileButton_Click);
        // 
        // EnableCheckBox
        // 
        this.EnableCheckBox.Checked = true;
        this.EnableCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
        this.EnableCheckBox.Location = new System.Drawing.Point(12, 61);
        this.EnableCheckBox.Name = "EnableCheckBox";
        this.EnableCheckBox.Size = new System.Drawing.Size(152, 24);
        this.EnableCheckBox.TabIndex = 3;
        this.EnableCheckBox.Text = "Enable mod by default";
        this.EnableCheckBox.UseVisualStyleBackColor = true;
        // 
        // StartPackage
        // 
        this.StartPackage.Enabled = false;
        this.StartPackage.Location = new System.Drawing.Point(198, 96);
        this.StartPackage.Name = "StartPackage";
        this.StartPackage.Size = new System.Drawing.Size(74, 23);
        this.StartPackage.TabIndex = 4;
        this.StartPackage.Text = "Save";
        this.StartPackage.UseVisualStyleBackColor = true;
        this.StartPackage.Click += new System.EventHandler(this.StartPackage_Click);
        // 
        // label2
        // 
        this.label2.Location = new System.Drawing.Point(12, 100);
        this.label2.Name = "label2";
        this.label2.Size = new System.Drawing.Size(130, 19);
        this.label2.TabIndex = 5;
        this.label2.Text = "This may take a while.";
        this.label2.Visible = false;
        // 
        // Package
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(284, 131);
        this.Controls.Add(this.label2);
        this.Controls.Add(this.StartPackage);
        this.Controls.Add(this.EnableCheckBox);
        this.Controls.Add(this.FileButton);
        this.Controls.Add(this.FileLocation);
        this.Controls.Add(this.label1);
        this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
        this.Name = "Package";
        this.ShowInTaskbar = false;
        this.Text = "Package";
        this.Load += new System.EventHandler(this.Package_Load);
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    private System.Windows.Forms.Label label2;

    private System.Windows.Forms.CheckBox EnableCheckBox;
    private System.Windows.Forms.Button StartPackage;

    private System.Windows.Forms.TextBox FileLocation;
    private System.Windows.Forms.Button FileButton;

    private System.Windows.Forms.Label label1;

    #endregion
}