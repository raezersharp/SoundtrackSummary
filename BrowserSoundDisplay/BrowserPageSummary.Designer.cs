namespace BrowserSoundDisplay
{
    partial class BrowserPageSummary
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
            this.ItemLabel = new System.Windows.Forms.Label();
            this.ItemImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ItemImage)).BeginInit();
            this.SuspendLayout();
            // 
            // ItemLabel
            // 
            this.ItemLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ItemLabel.Location = new System.Drawing.Point(0, 0);
            this.ItemLabel.Name = "ItemLabel";
            this.ItemLabel.Size = new System.Drawing.Size(512, 55);
            this.ItemLabel.TabIndex = 0;
            this.ItemLabel.Text = "Music Name";
            this.ItemLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ItemImage
            // 
            this.ItemImage.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ItemImage.Location = new System.Drawing.Point(68, 58);
            this.ItemImage.Name = "ItemImage";
            this.ItemImage.Size = new System.Drawing.Size(379, 289);
            this.ItemImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ItemImage.TabIndex = 1;
            this.ItemImage.TabStop = false;
            // 
            // BrowserPageSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 381);
            this.Controls.Add(this.ItemImage);
            this.Controls.Add(this.ItemLabel);
            this.Name = "BrowserPageSummary";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.ItemImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label ItemLabel;
        private System.Windows.Forms.PictureBox ItemImage;
    }
}

