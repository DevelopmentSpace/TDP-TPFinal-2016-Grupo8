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
    public partial class CampaignViewSearch : Form
    {

        private Application application;

        private IEnumerable<CampaignDTO> campaigns;

        public CampaignViewSearch(Application pAplication)
        {
            InitializeComponent();
            application = pAplication;

        }

        private void CampaignViewListAll_Load(object sender, EventArgs e)
        {
            campaigns = application.CampaignService.GetAllCampaigns().ToList();
        }

        private void searchText_TextChanged(object sender, EventArgs e)
        {
            dataGridViewCampaigns.Rows.Clear();

            foreach (CampaignDTO campaign in campaigns)
            {
                int searchLenght = searchText.Text.Length;
                if (campaign.name.Length >= searchLenght)
                {
                    if (campaign.name.Substring(0, searchLenght) == searchText.Text.ToString().Substring(0, searchLenght))
                    {
                        dataGridViewCampaigns.Rows.Add(campaign.id, campaign.name, campaign.initDate.ToString(), campaign.endDate.ToString());
                    }
                }
                }

            }
        }
    }
