using System.ComponentModel;

namespace PPGManager
{
    partial class Contraptions
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
            this.ContraptionsListBox = new System.Windows.Forms.ListBox();
            this.ContraptionPictureBox = new System.Windows.Forms.PictureBox();
            this.ContraptionLabel = new System.Windows.Forms.Label();
            this.ContraptionInfoLabel = new System.Windows.Forms.Label();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.PackageContraption = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ContraptionPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ContraptionsListBox
            // 
            this.ContraptionsListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ContraptionsListBox.FormattingEnabled = true;
            this.ContraptionsListBox.ItemHeight = 15;
            this.ContraptionsListBox.Items.AddRange(new object[] { "Currently loading list.", "Please wait." });
            this.ContraptionsListBox.Location = new System.Drawing.Point(12, 12);
            this.ContraptionsListBox.Name = "ContraptionsListBox";
            this.ContraptionsListBox.Size = new System.Drawing.Size(198, 317);
            this.ContraptionsListBox.TabIndex = 1;
            this.ContraptionsListBox.SelectedIndexChanged += new System.EventHandler(this.ContraptionsListBox_SelectedIndexChanged);
            // 
            // ContraptionPictureBox
            // 
            this.ContraptionPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ContraptionPictureBox.Location = new System.Drawing.Point(216, 12);
            this.ContraptionPictureBox.Name = "ContraptionPictureBox";
            this.ContraptionPictureBox.Size = new System.Drawing.Size(75, 75);
            this.ContraptionPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ContraptionPictureBox.TabIndex = 2;
            this.ContraptionPictureBox.TabStop = false;
            // 
            // ContraptionLabel
            // 
            this.ContraptionLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ContraptionLabel.Location = new System.Drawing.Point(297, 12);
            this.ContraptionLabel.Name = "ContraptionLabel";
            this.ContraptionLabel.Size = new System.Drawing.Size(235, 75);
            this.ContraptionLabel.TabIndex = 3;
            this.ContraptionLabel.Text = "Choose a contraption";
            // 
            // ContraptionInfoLabel
            // 
            this.ContraptionInfoLabel.Location = new System.Drawing.Point(216, 90);
            this.ContraptionInfoLabel.Name = "ContraptionInfoLabel";
            this.ContraptionInfoLabel.Size = new System.Drawing.Size(316, 113);
            this.ContraptionInfoLabel.TabIndex = 4;
            this.ContraptionInfoLabel.Text = "In this screen, you can view info and delete contraptions. You can also package c" + "ontraptions.";
            // 
            // DeleteButton
            // 
            this.DeleteButton.Enabled = false;
            this.DeleteButton.Location = new System.Drawing.Point(432, 299);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(100, 30);
            this.DeleteButton.TabIndex = 5;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // PackageContraption
            // 
            this.PackageContraption.Enabled = false;
            this.PackageContraption.Location = new System.Drawing.Point(326, 299);
            this.PackageContraption.Name = "PackageContraption";
            this.PackageContraption.Size = new System.Drawing.Size(100, 30);
            this.PackageContraption.TabIndex = 6;
            this.PackageContraption.Text = "Package";
            this.PackageContraption.UseVisualStyleBackColor = true;
            this.PackageContraption.Click += new System.EventHandler(this.PackageContraption_Click);
            // 
            // Contraptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 341);
            this.Controls.Add(this.PackageContraption);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.ContraptionInfoLabel);
            this.Controls.Add(this.ContraptionLabel);
            this.Controls.Add(this.ContraptionPictureBox);
            this.Controls.Add(this.ContraptionsListBox);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Contraptions";
            this.ShowInTaskbar = false;
            this.Text = "Contraptions";
            this.Load += new System.EventHandler(this.Contraptions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ContraptionPictureBox)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button PackageContraption;

        private System.Windows.Forms.Button DeleteButton;

        private System.Windows.Forms.Label ContraptionInfoLabel;

        private System.Windows.Forms.Label ContraptionLabel;

        private System.Windows.Forms.PictureBox ContraptionPictureBox;

        private System.Windows.Forms.ListBox ContraptionsListBox;

        #endregion
    }
}