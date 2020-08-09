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
			this.btnCapture = new System.Windows.Forms.Button();
			this.picCapture = new System.Windows.Forms.PictureBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.cboLanguage = new System.Windows.Forms.ComboBox();
			this.lblLanguage = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.picCapture)).BeginInit();
			this.SuspendLayout();
			// 
			// btnCapture
			// 
			this.btnCapture.Location = new System.Drawing.Point(21, 21);
			this.btnCapture.Name = "btnCapture";
			this.btnCapture.Size = new System.Drawing.Size(127, 28);
			this.btnCapture.TabIndex = 0;
			this.btnCapture.Text = "Capture";
			this.btnCapture.UseVisualStyleBackColor = true;
			this.btnCapture.Click += new System.EventHandler(this.Capture_Click);
			// 
			// picCapture
			// 
			this.picCapture.Location = new System.Drawing.Point(21, 68);
			this.picCapture.Name = "picCapture";
			this.picCapture.Size = new System.Drawing.Size(756, 132);
			this.picCapture.TabIndex = 1;
			this.picCapture.TabStop = false;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(21, 267);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(756, 100);
			this.textBox1.TabIndex = 2;
			// 
			// cboLanguage
			// 
			this.cboLanguage.FormattingEnabled = true;
			this.cboLanguage.Location = new System.Drawing.Point(86, 225);
			this.cboLanguage.Name = "cboLanguage";
			this.cboLanguage.Size = new System.Drawing.Size(158, 23);
			this.cboLanguage.TabIndex = 3;
			this.cboLanguage.Items.Add("English");
			this.cboLanguage.Items.Add("Chinese (Traditional)");
			this.cboLanguage.Items.Add("Chinese (Simplified)");
			this.cboLanguage.SelectedIndex = 0;
			// 
			// lblLanguage
			// 
			this.lblLanguage.AutoSize = true;
			this.lblLanguage.Location = new System.Drawing.Point(21, 228);
			this.lblLanguage.Name = "lblLanguage";
			this.lblLanguage.Size = new System.Drawing.Size(59, 15);
			this.lblLanguage.TabIndex = 4;
			this.lblLanguage.Text = "Language";
			// 
			// TranslateOCR
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.lblLanguage);
			this.Controls.Add(this.cboLanguage);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.picCapture);
			this.Controls.Add(this.btnCapture);
			this.Name = "TranslateOCR";
			this.Text = "Translate OCR";
			((System.ComponentModel.ISupportInitialize)(this.picCapture)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button btnCapture;
		private System.Windows.Forms.PictureBox pbo = null;

		public Bitmap screenSnippet = null;
		private System.Windows.Forms.ComboBox cboLanguage;
		private System.Windows.Forms.Label lblLanguage;
		private System.Windows.Forms.PictureBox Ca;
		private System.Windows.Forms.PictureBox picCapture;
	}
}

