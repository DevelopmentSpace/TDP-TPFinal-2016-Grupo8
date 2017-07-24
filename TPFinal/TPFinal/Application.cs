using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TPFinal.View;
using TPFinal.Model;

namespace TPFinal
{
    public partial class Application : Form
    {

        int DataBaseRefreshTime; //TODAVIA NO IMPLEMENTADO, SE TIENE QUE SELECCIONAR AL PRINCIPIO.

        private TextBannerService textBannerService = new TextBannerService();

        internal TextBannerService TextBannerService
        {
            get
            {
                return textBannerService;
            }
        }

        private RssBannerService rssBannerService = new RssBannerService();

        internal RssBannerService RssBannerService
        {
            get
            {
                return rssBannerService;
            }

        }

        private BannerService bannerService = new BannerService();

        internal BannerService BannerService
        {
            get
            {
                return bannerService;
            }

        }

        private CampaignService campaignService = new CampaignService();

        internal CampaignService CampaignService
        {
            get
            {
                return campaignService;
            }
        }



        public Application()
        {
            InitializeComponent();
            bannerService.AddService(textBannerService);
            bannerService.AddService(rssBannerService);
        }

        private void adminButton_Click(object sender, EventArgs e)
        {
            AdminView adminView = new AdminView(this);
            adminView.Show();
        }

        private void adButton_Click(object sender, EventArgs e)
        {
            AdView adview = new AdView(this);
            adview.Show();
        }

        private void Application_Load(object sender, EventArgs e)
        {

        }
    }
}
