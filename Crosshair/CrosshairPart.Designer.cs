namespace Crosshair
{
    partial class CrosshairPart
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
            this.crosshair = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.crosshair)).BeginInit();
            this.SuspendLayout();
            // 
            // crosshair
            // 
            this.crosshair.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.crosshair.Location = new System.Drawing.Point(2, 1);
            this.crosshair.Name = "crosshair";
            this.crosshair.Size = new System.Drawing.Size(170, 70);
            this.crosshair.TabIndex = 0;
            this.crosshair.TabStop = false;
            this.crosshair.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // CrosshairPart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 387);
            this.Controls.Add(this.crosshair);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "CrosshairPart";
            this.ShowInTaskbar = false;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.crosshair)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox crosshair;
    }
}

