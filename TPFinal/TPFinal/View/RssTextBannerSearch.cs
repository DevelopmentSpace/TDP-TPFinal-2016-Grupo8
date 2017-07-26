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
    public partial class RssTextBannerSearch : Form
    {
        private IRssBannerService iRssBannerService = IoCContainerLocator.Container.Resolve<IRssBannerService>();

        private IEnumerable<RssBannerDTO> rssBanners;

        public RssTextBannerSearch()
        {
            InitializeComponent();
            rssBanners = iRssBannerService.GetAll();

            searchText.Text = "";
            searchText_TextChanged(null, EventArgs.Empty);

        }

        private void searchText_TextChanged(object sender, EventArgs e)
        {
            int searchLenght = searchText.Text.Length;
            dataGridViewRssBanners.Rows.Clear();
            IEnumerator<RssBannerDTO> rssBannersEnumerator = rssBanners.GetEnumerator();

            while (rssBannersEnumerator.MoveNext())
            {
                if (rssBannersEnumerator.Current.name.Length >= searchLenght)
                {
                    if (rssBannersEnumerator.Current.name.Substring(0, searchLenght).ToLower() == searchText.Text.ToString().Substring(0, searchLenght).ToLower())
                    {
                        dataGridViewRssBanners.Rows.Add(rssBannersEnumerator.Current.id, rssBannersEnumerator.Current.name, rssBannersEnumerator.Current.initDate.Date.ToString("dd/MM/yyyy"), rssBannersEnumerator.Current.endDate.Date.ToString("dd/MM/yyyy"), rssBannersEnumerator.Current.url);
                    }
                }
            }
            rssBannersEnumerator.Reset();
        }

        private void dataGridViewRssBanners_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'd')
            {
                foreach (DataGridViewRow row in dataGridViewRssBanners.SelectedRows)
                {
                    try
                    {
                        iRssBannerService.Delete((int)row.Cells[0].Value);
                        dataGridViewRssBanners.Rows.Remove(row);
                        dataGridViewRssBanners.Refresh();

                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error deleting RssTextBanner.");
                    }
                }
                rssBanners = iRssBannerService.GetAll();
                searchText_TextChanged(null, EventArgs.Empty);
            }
            else if (e.KeyChar == 'm')
            {
                if (dataGridViewRssBanners.SelectedRows.Count == 1)
                {
                    try
                    {
                        RssBannerView rssBannerView = new RssBannerView(rssBanners.First<RssBannerDTO>(x => x.id == ((int)dataGridViewRssBanners.SelectedRows[0].Cells[0].Value)));
                        rssBannerView.ShowDialog();
                        iRssBannerService.Update(rssBannerView.ViewRssBannerDTO);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error updating RssBanner.");
                    }
                }
                rssBanners = iRssBannerService.GetAll();
                searchText_TextChanged(null, EventArgs.Empty);
            }

        }
    }
}
