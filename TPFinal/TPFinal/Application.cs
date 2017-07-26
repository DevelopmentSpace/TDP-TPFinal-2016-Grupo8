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

        private ITextBannerService iTextBannerService = IoCContainerLocator.Container.Resolve<ITextBannerService>();
        private IRssBannerService iRssBannerService = IoCContainerLocator.Container.Resolve<IRssBannerService>();
        private IBannerService iBannerService = IoCContainerLocator.Container.Resolve<IBannerService>();
        private ICampaignService iCampaignService = IoCContainerLocator.Container.Resolve<ICampaignService>();

        public Application()
        {
            InitializeComponent();
            //Agrega los servicios de texto al servicio de banners
            iBannerService.AddService((ITextBanner)iTextBannerService);
            iBannerService.AddService((ITextBanner)iRssBannerService);
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

        private void forceUpdate_Click(object sender, EventArgs e)
        {
            iBannerService.ForceUpdate();
            iCampaignService.ForceUpdate();
        }
    }
}
