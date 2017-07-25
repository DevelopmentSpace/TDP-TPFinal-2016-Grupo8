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
    public partial class CampaignViewSearch : Form
    {

        private CampaignService iCampaignService = IoCContainerLocator.Container.Resolve<CampaignService>();

        private IEnumerator<CampaignDTO> campaigns;

        public CampaignViewSearch()
        {
            InitializeComponent();
            campaigns = iCampaignService.GetAllCampaigns().GetEnumerator();
        }

        private void searchText_TextChanged(object sender, EventArgs e)
        {
            int searchLenght = searchText.Text.Length;
            dataGridViewCampaigns.Rows.Clear();

            while (campaigns.MoveNext())
            {
                if (campaigns.Current.name.Length >= searchLenght)
                {
                    if (campaigns.Current.name.Substring(0, searchLenght) == searchText.Text.ToString().Substring(0, searchLenght))
                    {
                        dataGridViewCampaigns.Rows.Add(campaigns.Current.id, campaigns.Current.name, campaigns.Current.initDate.ToString(), campaigns.Current.endDate.ToString());
                    }
                }
             }
            campaigns.Reset();

         }
    }
}
