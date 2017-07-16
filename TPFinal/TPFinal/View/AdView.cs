using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using TPFinal.Model;

namespace TPFinal.View
{
    public partial class AdView : Form, IObserver
    {
        private Application application;

        public AdView(Application pApplication)
        {
            InitializeComponent();
            application = pApplication;
        }

        private void AdView_Load(object sender, EventArgs e)
        {

            application.CampaignService.AddListener(this);
            application.BannerService.AddListener(this);

            application.CampaignService.Start();
            application.BannerService.Start();

        }

        public void Update(String des)
        {
            if (des == "Campaign")
            {
                MemoryStream ms = new MemoryStream(application.CampaignService.GetActualImage());
                imageBox.Image = Image.FromStream(ms);
                imageBox.Refresh();
                imageBox.Update();
            }
            else if (des == "Banner")
            {
                textBanner.ForeColor = System.Drawing.Color.Red; // - PARA CAMBIAR EL COLOR DEL TEXTO.
                textBanner.Text = application.BannerService.GetText();
                textBanner.ForeColor = System.Drawing.Color.Black;

            }
        }
 
    }
}
