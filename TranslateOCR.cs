using System;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Tesseract;

namespace TranslateOCR
{
	public partial class TranslateOCR : Form
	{
        public Bitmap ScreenSnippet { get; set; } = null;
        private string Filename { get; set; } = null;
        private System.ComponentModel.IContainer components = null;
        private NotifyIcon notifyIcon;
        private ContextMenuStrip contextMenuStrip;
        private ScreenCapture screenCaptureForm;

		public TranslateOCR()
		{
			InitializeComponent();

            cboLanguage.SelectedIndex = 0;
            components = new System.ComponentModel.Container();

            // Set up how the form should be displayed.
            Hide();
            Text = "Translate OCR";

            // Create the NotifyIcon.
            notifyIcon = new NotifyIcon(components);

            // The Icon property sets the icon that will appear
            // in the systray for this application.
            notifyIcon.Icon = new Icon("./Assets/language.ico");

            contextMenuStrip = new ContextMenuStrip();
            contextMenuStrip.Items.Add("Capture", null, new EventHandler(Capture_Click));

            notifyIcon.ContextMenuStrip = contextMenuStrip;

            // The ContextMenu property sets the menu that will
            // appear when the systray icon is right clicked.
            //notifyIcon.ContextMenu = this.contextMenu1;

            // The Text property sets the text that will be displayed,
            // in a tooltip, when the mouse hovers over the systray icon.
            notifyIcon.Text = "Translate OCR";
            notifyIcon.Visible = true;

            // Handle the DoubleClick event to activate the form.
            //notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
        }

		private void Capture_Click(object sender, EventArgs e)
		{
            Cleanup();

            // Hide the form before the screenshot is taken.
            WindowState = FormWindowState.Minimized;

			// Wait 200ms for the minimize animation.
			Thread.Sleep(300);

            int screenHeight = 0;
            int screenWidth = 0;

            // Open form to allow user to select a portion of the screen.
            foreach (Screen screen in Screen.AllScreens)
            {
                screenHeight = (screen.Bounds.Height >= screenHeight ? screen.Bounds.Height : screenHeight);
                screenWidth += screen.Bounds.Width;
            }

            screenCaptureForm = new ScreenCapture()
            {
                Location = new Point(0, 0),
                Size = new Size(screenWidth, screenHeight),
                StartPosition = FormStartPosition.Manual,
                FormBorderStyle = FormBorderStyle.None,
                TopLeftPoint = new Point(0, 0)
            };

            screenCaptureForm.Initialize();
            screenCaptureForm.Show();
            screenCaptureForm.Activate();
        }

        private void cboLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProcessImage();
        }

        public void ProcessImage()
        {
            if (ScreenSnippet == null)
            {
                return;
			}

            picCapture.Image = ScreenSnippet;

            if (string.IsNullOrEmpty(Filename))
            {
                Filename = SaveBitmapToDisk(ScreenSnippet);
			}

            using (var engine = new TesseractEngine(@"./tessdata", GetSelectedLanguage(), EngineMode.Default))
            {
                using (Pix img = Pix.LoadFromFile(Filename))
                {
                    using (Page page = engine.Process(img))
                    {
                        textBox1.Text = page.GetText();
					}
				}
			}
		}

        private string SaveBitmapToDisk(Bitmap bitmap)
        {
            string filename = $"capture_{DateTime.Now.ToString("yyyyMMddHHmmss")}.tif";

            bitmap.Save(filename, System.Drawing.Imaging.ImageFormat.Tiff);

            return filename;
        }

        private void Cleanup()
        {
            string path = $"{Directory.GetCurrentDirectory()}/{Filename}";

            if (File.Exists(path))
            {
                File.Delete(path);
			}

            Filename = string.Empty;
		}

        private string GetSelectedLanguage()
        {
            string language = cboLanguage.SelectedItem.ToString();

            switch (language.ToUpper().Trim())
            {
                case "ENGLISH":
                    return "eng";
                case "CHINESE (TRADITIONAL)":
                    return "chi_tra";
                case "CHINESE (SIMPLIFIED)":
                    return "chi_sim";
                default:
                    return "eng";
            }
        }
	}
}
