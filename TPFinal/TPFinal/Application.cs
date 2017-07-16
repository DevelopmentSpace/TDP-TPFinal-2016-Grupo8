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

        private BannerService bannerService = new BannerService(30);

        internal BannerService BannerService
        {
            get
            {
                return bannerService;
            }

            set
            {
                bannerService = value;
            }
        }

        private CampaignService campaignService = new CampaignService(30);

        internal CampaignService CampaignService
        {
            get
            {
                return campaignService;
            }

            set
            {
                campaignService = value;
            }
        }

        public Application()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CampaignView campaignView = new CampaignView(this);
            campaignView.Show();
        }

        private void adButton_Click(object sender, EventArgs e)
        {
            AdView adview = new AdView(this);
            adview.Show();
        }
    }
}
