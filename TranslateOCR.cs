using System.Drawing;
using System.Windows.Forms;

namespace TranslateOCR
{
    public partial class TranslateOCR : Form
	{
		private System.ComponentModel.IContainer components = null;
        private NotifyIcon notifyIcon;

		public TranslateOCR()
		{
			InitializeComponent();

            this.components = new System.ComponentModel.Container();

            // Set up how the form should be displayed.
            this.Hide();
            this.Text = "Translate OCR";

            // Create the NotifyIcon.
            this.notifyIcon = new NotifyIcon(this.components);

            // The Icon property sets the icon that will appear
            // in the systray for this application.
            notifyIcon.Icon = new Icon("language.ico");

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

		private void Capture_Click(object sender, System.EventArgs e)
		{
            // Allow user to drag a rectangle on the screen.
            ScreenCapture screenCapture = new ScreenCapture();
            
            screenCapture.Show();
		}
	}
}
