using System.Drawing;

namespace TranslateOCR
{
	partial class TranslateOCR
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.Capture = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// Capture
			// 
			this.Capture.Location = new System.Drawing.Point(21, 21);
			this.Capture.Name = "Capture";
			this.Capture.Size = new System.Drawing.Size(127, 28);
			this.Capture.TabIndex = 0;
			this.Capture.Text = "Capture";
			this.Capture.UseVisualStyleBackColor = true;
			this.Capture.Click += new System.EventHandler(this.Capture_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(21, 68);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(739, 132);
			this.pictureBox1.TabIndex = 1;
			this.pictureBox1.TabStop = false;
			// 
			// TranslateOCR
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.Capture);
			this.Name = "TranslateOCR";
			this.Text = "Translate OCR";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button Capture;

		public System.Windows.Forms.PictureBox pictureBox1 = null;
		public Bitmap screenCapture = null;
	}
}

