using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Practices.Unity;
using TPFinal.Model;
using TPFinal.DTO;

namespace TPFinal.View
{
    public partial class TextBannerViewSearch : Form
    {

        private ITextBannerService iTextBannerService = IoCContainerLocator.Container.Resolve<ITextBannerService>();

        private IEnumerable<TextBannerDTO> textBanners;

        public TextBannerViewSearch()
        {
            InitializeComponent();
            textBanners = iTextBannerService.GetAll();

            searchText.Text = "";
            searchText_TextChanged(null, EventArgs.Empty);
        }

        private void searchText_TextChanged(object sender, EventArgs e)
        {
            int searchLenght = searchText.Text.Length;
            dataGridViewTextBanners.Rows.Clear();
            IEnumerator<TextBannerDTO> textBannersEnumerator = textBanners.GetEnumerator();

            while (textBannersEnumerator.MoveNext())
            {
                if (textBannersEnumerator.Current.name.Length >= searchLenght)
                {
                    if (textBannersEnumerator.Current.name.Substring(0, searchLenght).ToLower() == searchText.Text.ToString().Substring(0, searchLenght).ToLower())
                    {
                        dataGridViewTextBanners.Rows.Add(textBannersEnumerator.Current.id, textBannersEnumerator.Current.name, textBannersEnumerator.Current.initDate.Date.ToString("dd/MM/yyyy"), textBannersEnumerator.Current.endDate.Date.ToString("dd/MM/yyyy"),textBannersEnumerator.Current.text);
                    }
                }
            }
            textBannersEnumerator.Reset();
        }

        private void dataGridViewTextBanners_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'd')
            {
                foreach (DataGridViewRow row in dataGridViewTextBanners.SelectedRows)
                {
                    try
                    {
                        iTextBannerService.Delete((int)row.Cells[0].Value);
                        dataGridViewTextBanners.Rows.Remove(row);
                        dataGridViewTextBanners.Refresh();

                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error deleting TextBanner.");
                    }
                }
                textBanners = iTextBannerService.GetAll();
                searchText_TextChanged(null, EventArgs.Empty);
            }
            else if (e.KeyChar == 'm')
            {
                if (dataGridViewTextBanners.SelectedRows.Count == 1)
                {
                    try
                    {
                        TextBannerView textBannerView = new TextBannerView(textBanners.First<TextBannerDTO>(x => x.id == ((int)dataGridViewTextBanners.SelectedRows[0].Cells[0].Value)));
                        textBannerView.ShowDialog();
                        iTextBannerService.Update(textBannerView.textBannerDTO);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error updating TextBanner.");
                    }
                }
                textBanners = iTextBannerService.GetAll();
                searchText_TextChanged(null, EventArgs.Empty);
            }
        }
    }
}
