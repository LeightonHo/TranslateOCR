using System;
using System.Drawing;
using System.Windows.Forms;
using Tesseract;
using System.Collections.Generic;

namespace TranslateOCR
{
    public partial class TranslateOCR : Form
	{
		private System.ComponentModel.IContainer components = null;
        private NotifyIcon notifyIcon;
        private List<ScreenCapture> screenCaptureList = new List<ScreenCapture>();

		public TranslateOCR()
		{
			InitializeComponent();

            this.cboLanguage.SelectedIndex = 0;
            this.components = new System.ComponentModel.Container();

            // Set up how the form should be displayed.
            this.Hide();
            this.Text = "Translate OCR";

            // Create the NotifyIcon.
            this.notifyIcon = new NotifyIcon(this.components);

            // The Icon property sets the icon that will appear
            // in the systray for this application.
            notifyIcon.Icon = new Icon("./Assets/language.ico");

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

        private void InitializeScreenCaptureForms()
        {
            foreach (Screen screen in Screen.AllScreens)
            {
                ScreenCapture screenCapture = new ScreenCapture();

                screenCapture.Location = screen.WorkingArea.Location;
                screenCapture.StartPosition = FormStartPosition.Manual;

                screenCaptureList.Add(screenCapture);
            }
        }

		private void Capture_Click(object sender, System.EventArgs e)
		{
            // Open form to allow user to select a portion of the screen.
            foreach (Screen screen in Screen.AllScreens)
            {
                ScreenCapture screenCapture = new ScreenCapture()
                {
                    Location = screen.WorkingArea.Location,
                    StartPosition = FormStartPosition.Manual,
                    FormBorderStyle = FormBorderStyle.None,
                    WindowState = FormWindowState.Maximized,
                    Opacity = 0.25,
                    TopLeftPoint = screen.WorkingArea.Location
                };

                screenCapture.Show();
                screenCaptureList.Add(screenCapture);
            }
		}

        public void HideScreenCaptureForms()
        {
            foreach (ScreenCapture screenCapture in screenCaptureList)
            {
                screenCapture.Close();
			}

            screenCaptureList = new List<ScreenCapture>();
		}

        public void ProcessImage(Bitmap bitmap)
        {
            picCapture.Image = bitmap;
            screenSnippet = bitmap;

            string filename = SaveBitmapToDisk(bitmap);

            using (var engine = new TesseractEngine(@"./tessdata", GetSelectedLanguage(), EngineMode.Default))
            {
                using (Pix img = Pix.LoadFromFile(filename))
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
