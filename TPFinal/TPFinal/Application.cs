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
using Microsoft.Practices.Unity;

namespace TPFinal
{
    public partial class Application : Form
    {

        private TextBannerService iTextBannerService = IoCContainerLocator.Container.Resolve<TextBannerService>();
        private RssBannerService iRssBannerService = IoCContainerLocator.Container.Resolve<RssBannerService>();
        private BannerService iBannerService = IoCContainerLocator.Container.Resolve<BannerService>();
        private CampaignService iCampaignService = IoCContainerLocator.Container.Resolve<CampaignService>();

        public Application()
        {
            InitializeComponent();
            iBannerService.AddService(iTextBannerService);
            iBannerService.AddService(iRssBannerService);
        }

        private void adminButton_Click(object sender, EventArgs e)
        {
            AdminView adminView = new AdminView();
            adminView.Show();
        }

        private void adButton_Click(object sender, EventArgs e)
        {
            AdView adview = new AdView();
            adview.Show();
        }

        private void Application_Load(object sender, EventArgs e)
        {

        }
    }
}
