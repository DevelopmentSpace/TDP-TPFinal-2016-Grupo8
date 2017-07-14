using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using TPFinal.Model;

namespace TPFinal.View
{
    public partial class AdView : Form, IObserver
    {
        CampaignService campaignService;
        BannerService bannerService;

        public AdView()
        {
            InitializeComponent();
        }

        private void AdView_Load(object sender, EventArgs e)
        {
            int DataBaseRefreshTime = 20;



            campaignService = new CampaignService(DataBaseRefreshTime); //ESTE TIEMPO SE TIENE QUE SELECCIONAR EN OTRA VISTA 
            bannerService = new BannerService(DataBaseRefreshTime);

            campaignService.AddListener(this);
            bannerService.AddListener(this);

            bannerService.Start();
            campaignService.Start();


        }

        public void Update(String des)
        {
            if (des == "Campaign")
            {
                MemoryStream ms = new MemoryStream(campaignService.GetActualImage());
                imageBox.Image = Image.FromStream(ms);
            }
            else if (des == "Banner")
            {
                textBanner.ForeColor = System.Drawing.Color.Red; // - PARA CAMBIAR EL COLOR DEL TEXTO.
                textBanner.Text = bannerService.GetText();
                textBanner.ForeColor = System.Drawing.Color.Black;

            }
        }
 
    }
}
