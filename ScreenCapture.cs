using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TranslateOCR
{
	public partial class ScreenCapture : Form
	{
		private Point _topLeftPoint;
		private Point _sourcePoint = new Point();
		private Point _destinationPoint = new Point();
		private bool _isDrawing = false;

		public ScreenCapture()
		{
			InitializeComponent();

			MouseDown += new MouseEventHandler(this.Canvas_MouseDown);
			MouseUp += new MouseEventHandler(this.Canvas_MouseUp);
			Paint += new PaintEventHandler(this.Canvas_Paint);
			MouseMove += new MouseEventHandler(this.Canvas_MouseMove);
			DoubleBuffered = true;
		}

		private void Canvas_MouseDown(object sender, MouseEventArgs e)
		{
			if (!_isDrawing)
			{
				_isDrawing = true;
				_sourcePoint = GetPointOnScreen(e.Location);
				_destinationPoint = GetPointOnScreen(e.Location);

				Canvas_Repaint();
			}
		}

		private void Canvas_MouseUp(object sender, MouseEventArgs e)
		{
			_isDrawing = false;
			_destinationPoint = GetPointOnScreen(e.Location);

			Rectangle captureArea = GetCaptureArea();
			Bitmap bitmap = new Bitmap(captureArea.Width, captureArea.Height);

			using (Graphics graphics = Graphics.FromImage(bitmap))
			{
				TranslateOCR parentForm = (TranslateOCR)Application.OpenForms["TranslateOCR"];

				parentForm.HideScreenCaptureForms();
				graphics.CopyFromScreen(captureArea.Location, Point.Empty, captureArea.Size, CopyPixelOperation.SourceCopy);
				parentForm.ProcessImage(bitmap);
			}
		}

		private void Canvas_MouseMove(object sender, MouseEventArgs e)
		{
			if (_isDrawing)
			{
				_destinationPoint = GetPointOnScreen(e.Location);
			}
		}

		private void Canvas_Paint(object sender, PaintEventArgs e)
		{
			Rectangle captureArea = GetCaptureArea(false);
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

		private Rectangle GetCaptureArea(bool relativeToPrimaryScreen = true)
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

			if (!relativeToPrimaryScreen)
			{
				point.X -= TopLeftPoint.X;
				point.Y -= TopLeftPoint.Y;
			}

			return new Rectangle(point, size);
		}

		private Point GetPointOnScreen(Point point)
		{
			return new Point()
			{
				X = point.X + TopLeftPoint.X,
				Y = point.Y + TopLeftPoint.Y
			};
		}

		#region Public methods
		public Point TopLeftPoint {
			get { return _topLeftPoint; }
			set { _topLeftPoint = value; }
		}
		#endregion
	}
}
