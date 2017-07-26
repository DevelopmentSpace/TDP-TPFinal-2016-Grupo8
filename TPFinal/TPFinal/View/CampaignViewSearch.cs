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

        private ICampaignService iCampaignService = IoCContainerLocator.Container.Resolve<ICampaignService>();

        private IEnumerable<CampaignDTO> campaigns;

        public CampaignViewSearch()
        {
            InitializeComponent();
            campaigns = iCampaignService.GetAllCampaigns();

            searchText.Text = "";
            searchText_TextChanged(null, EventArgs.Empty);
        }

        private void searchText_TextChanged(object sender, EventArgs e)
        {
            int searchLenght = searchText.Text.Length;
            dataGridViewCampaigns.Rows.Clear();
            IEnumerator<CampaignDTO> campaignsEnumerator = campaigns.GetEnumerator();

            while (campaignsEnumerator.MoveNext())
            {
                if (campaignsEnumerator.Current.name.Length >= searchLenght)
                {
                    if (campaignsEnumerator.Current.name.Substring(0, searchLenght) == searchText.Text.ToString().Substring(0, searchLenght))
                    {
                        dataGridViewCampaigns.Rows.Add(campaignsEnumerator.Current.id, campaignsEnumerator.Current.name, campaignsEnumerator.Current.initDate.Date.ToString("dd/MM/yyyy"), campaignsEnumerator.Current.endDate.Date.ToString("dd/MM/yyyy"));
                    }
                }
             }
            campaignsEnumerator.Reset();

         }

        private void dataGridViewCampaigns_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'd')
            {
                foreach (DataGridViewRow row in dataGridViewCampaigns.SelectedRows)
                {
                    try
                    {
                        iCampaignService.Delete((int)row.Cells[0].Value);
                        dataGridViewCampaigns.Rows.Remove(row);
                        dataGridViewCampaigns.Refresh();

                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error deleting campaigns.");
                    }
                }
                campaigns = iCampaignService.GetAllCampaigns();
            }
            else if (e.KeyChar == 'm')
            {
                if (dataGridViewCampaigns.SelectedRows.Count == 1)
                {
                    try
                    {
                        CampaignView campaignView = new CampaignView(campaigns.First<CampaignDTO>(x => x.id == ((int)dataGridViewCampaigns.SelectedRows[0].Cells[0].Value)));
                        campaignView.Show();
                        iCampaignService.Update(campaignView.varCampaignDTO);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error updating campaign.");
                    }
                }
            }
        }
    }
}
