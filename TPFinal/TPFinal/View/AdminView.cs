using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TPFinal.DTO;
using TPFinal.Model;
using Microsoft.Practices.Unity;

namespace TPFinal.View
{
    public partial class AdminView : Form
    {

        private ICampaignService iCampaignService = IoCContainerLocator.Container.Resolve<ICampaignService>();

        public AdminView()
        {
            InitializeComponent();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CampaignView campaignView = new CampaignView(null);
            campaignView.ShowDialog();

            if (campaignView.varCampaignDTO != null)
            {
                try
                {
                    iCampaignService.Create(campaignView.varCampaignDTO);
                }
                catch (Exception)
                {
                    MessageBox.Show("Error in database");
                }
            }
        }

        private void listAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CampaignViewSearch campaignViewList = new CampaignViewSearch();
            campaignViewList.Show();
        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextBannerViewAdd textBannerViewAdd = new TextBannerViewAdd();
            textBannerViewAdd.Show();
        }

        private void listAllToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TextBannerViewSearch textBannerViewSearch = new TextBannerViewSearch();
            textBannerViewSearch.Show();
        }

        private void createToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RssTextBannerAdd rssBannerViewAdd = new RssTextBannerAdd();
            rssBannerViewAdd.Show();
        }

        private void listAllToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            RssTextBannerSearch rssTextBannerSearch = new RssTextBannerSearch();
            rssTextBannerSearch.Show();
        }
    }
}
