using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPFinal.View
{
    public partial class AdminView : Form
    {
        public AdminView()
        {
            InitializeComponent();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CampaignViewAdd campaignViewAdd = new CampaignViewAdd();
            campaignViewAdd.Show();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CampaignViewDelete campaignViewDelete = new CampaignViewDelete();
            campaignViewDelete.Show();
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CampaignViewUpdate campaignViewUpdate = new CampaignViewUpdate();
            campaignViewUpdate.Show();
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

        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TextBannerViewDelete textBannerViewDelete = new TextBannerViewDelete();
            textBannerViewDelete.Show();
        }

        private void updateToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TextBannerViewUpdate textBannerViewUpdate = new TextBannerViewUpdate();
            textBannerViewUpdate.Show();
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

        private void deleteToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            RssTextBannerDelete rssTextBannerDelete = new RssTextBannerDelete();
            rssTextBannerDelete.Show();
        }

        private void listAllToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            RssTextBannerSearch rssTextBannerSearch = new RssTextBannerSearch();
            rssTextBannerSearch.Show();
        }
    }
}
