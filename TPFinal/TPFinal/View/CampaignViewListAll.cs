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

namespace TPFinal.View
{
    public partial class CampaignViewListAll : Form
    {

        private Application application;

        public CampaignViewListAll(Application pAplication)
        {
            InitializeComponent();
            application = pAplication;

        }

        private void CampaignViewListAll_Load(object sender, EventArgs e)
        {
            foreach (CampaignDTO campaignDTO in application.CampaignService.GetAllCampaigns().ToList())
            {
                dataGridViewCampaigns.Rows.Add(campaignDTO.id, campaignDTO.name, campaignDTO.initDate.Date.ToString(), campaignDTO.endDate.Date.ToString());
            }
        }
    }
}
