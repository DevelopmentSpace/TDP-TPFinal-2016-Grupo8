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
            CampaignView campaignView = new CampaignView(new CampaignDTO());
            campaignView.Show();
            if (!(campaignView.campaignDTO == null))
            {
                try
                {
                    iCampaignService.Create(campaignView.campaignDTO);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Bad time format: Insert numbers");
                }
                catch (ArgumentException)
                {
                    MessageBox.Show("Bad hour format: Hours must go from 0 to 24, minutes and seconds must go from 0 to 60. Also init-time/date must be greater then end-time/date.");
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
