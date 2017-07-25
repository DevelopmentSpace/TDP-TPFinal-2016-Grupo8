using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TPFinal.Model;
using TPFinal.DTO;
using Microsoft.Practices.Unity;

namespace TPFinal.View
{
    public partial class TextBannerViewDelete : Form
    {

        private ITextBannerService iTextBannerService = IoCContainerLocator.Container.Resolve<ITextBannerService>();

        public TextBannerViewDelete()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            try
            {
                TextBannerDTO banner = iTextBannerService.Get(Convert.ToInt32(idText.Text));

                bannerNameText.Text = banner.name;

                initDateTimePicker.Value = banner.initDate;
                endDateTimePicker.Value = banner.endDate;

                initTimeHour.Text = banner.initTime.Hours.ToString();
                initTimeMinute.Text = banner.initTime.Minutes.ToString();

                endTimeHour.Text = banner.endTime.Hours.ToString();
                endTimeMinute.Text = banner.endTime.Minutes.ToString();

                textBanner.Text = banner.text;
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("TextBanner not found.");
            }
            catch (FormatException)
            {
                MessageBox.Show("Insert correct ID.");
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            try
            {
                iTextBannerService.Delete(Convert.ToInt32(idText.Text));
                this.Close();
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("TextBanner not found.");
            }
            catch (FormatException)
            {
                MessageBox.Show("Insert correct ID.");
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            TextBannerViewSearch textBannerViewSearch = new TextBannerViewSearch();
            textBannerViewSearch.Show();
        }
    }
}
