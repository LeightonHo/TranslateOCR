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
			// TranslateOCR
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.Capture);
			this.Name = "TranslateOCR";
			this.Text = "Form1";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button Capture;
	}
}

