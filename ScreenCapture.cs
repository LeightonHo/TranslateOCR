using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TranslateOCR
{
	public partial class ScreenCapture : Form
	{
		Point sourcePoint = new Point();
		Point destinationPoint = new Point();
		bool drawing = false;

		public ScreenCapture()
		{
			InitializeComponent();
			FormBorderStyle = FormBorderStyle.None;
			WindowState = FormWindowState.Maximized;
			Opacity = 0.25;

			this.MouseDown += new MouseEventHandler(this.Canvas_MouseDown);
			this.MouseUp += new MouseEventHandler(this.Canvas_MouseUp);
			//this.MouseMove += new MouseEventHandler(this.Canvas_MouseMove);
		}

		public void Canvas_MouseDown(object sender, MouseEventArgs e)
		{
			drawing = true;
			sourcePoint = new Point(e.X, e.Y);
		}

		public void Canvas_MouseUp(object sender, MouseEventArgs e)
		{
			drawing = false;
			destinationPoint = new Point(e.X, e.Y);

			Size size = new Size()
			{
				Width = Math.Abs(sourcePoint.X - destinationPoint.X),
				Height = Math.Abs(sourcePoint.Y - destinationPoint.Y)
			};
			Rectangle captureArea = new Rectangle(sourcePoint, size);
			Bitmap bitmap = new Bitmap(captureArea.Width, captureArea.Height);

			using (Graphics graphics = Graphics.FromImage(bitmap))
			{
				this.Close();
				graphics.CopyFromScreen(captureArea.Location, Point.Empty, captureArea.Size, CopyPixelOperation.SourceCopy);
				TranslateOCR parentForm = (TranslateOCR)Application.OpenForms["TranslateOCR"];
				parentForm.pictureBox1.Image = bitmap;
			}
		}

		public void Canvas_MouseMove(object sender, MouseEventArgs e)
		{
			if (!drawing)
			{
				destinationPoint = new Point(e.X, e.Y);
			}
		}
	}
}
