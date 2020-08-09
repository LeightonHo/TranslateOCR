using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tesseract;

namespace TranslateOCR
{
	public partial class ScreenCapture : Form
	{
		private Point _sourcePoint = new Point();
		private Point _destinationPoint = new Point();
		private bool _isDrawing = false;

		public ScreenCapture()
		{
			InitializeComponent();
			FormBorderStyle = FormBorderStyle.None;
			WindowState = FormWindowState.Maximized;
			Opacity = 0.25;

			MouseDown += new MouseEventHandler(this.Canvas_MouseDown);
			MouseUp += new MouseEventHandler(this.Canvas_MouseUp);
			Paint += new PaintEventHandler(this.Canvas_Paint);
			MouseMove += new MouseEventHandler(this.Canvas_MouseMove);
			DoubleBuffered = true;
		}

		public void Canvas_MouseDown(object sender, MouseEventArgs e)
		{
			if (!_isDrawing)
			{
				_isDrawing = true;
				_sourcePoint = new Point(e.X, e.Y);
				_destinationPoint = new Point(e.X, e.Y);

				Canvas_Repaint();
			}
		}

		public void Canvas_MouseUp(object sender, MouseEventArgs e)
		{
			_isDrawing = false;
			_destinationPoint = new Point(e.X, e.Y);

			Rectangle captureArea = GetCaptureArea();
			Bitmap bitmap = new Bitmap(captureArea.Width, captureArea.Height);

			using (Graphics graphics = Graphics.FromImage(bitmap))
			{
				Close();

				graphics.CopyFromScreen(captureArea.Location, Point.Empty, captureArea.Size, CopyPixelOperation.SourceCopy);
				TranslateOCR parentForm = (TranslateOCR)Application.OpenForms["TranslateOCR"];
				parentForm.ProcessImage(bitmap);
			}
		}

		public void Canvas_MouseMove(object sender, MouseEventArgs e)
		{
			if (_isDrawing)
			{
				_destinationPoint = new Point(e.X, e.Y);
			}
		}

		public void Canvas_Paint(object sender, PaintEventArgs e)
		{
			Rectangle captureArea = GetCaptureArea();
			SolidBrush brush = new SolidBrush(Color.Red);

			e.Graphics.FillRectangle(brush, captureArea);
		}

		private void Canvas_Repaint()
		{
			Task.Run(() =>
			{
				while (_isDrawing)
				{
					Invalidate();
				}
			});
		}

		private Rectangle GetCaptureArea()
		{
			Size size = new Size()
			{
				Width = Math.Abs(_sourcePoint.X - _destinationPoint.X),
				Height = Math.Abs(_sourcePoint.Y - _destinationPoint.Y)
			};

			Point point = new Point()
			{
				X = Math.Min(_sourcePoint.X, _destinationPoint.X),
				Y = Math.Min(_sourcePoint.Y, _destinationPoint.Y)
			};

			return new Rectangle(point, size);
		}
	}
}
