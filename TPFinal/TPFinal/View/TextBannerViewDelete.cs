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

        private TextBannerService iTextBannerService = IoCContainerLocator.Container.Resolve<TextBannerService>();

        public TextBannerViewDelete()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
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

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            iTextBannerService.Delete(Convert.ToInt32(idText.Text));
            this.Close();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            TextBannerViewSearch textBannerViewSearch = new TextBannerViewSearch();
            textBannerViewSearch.Show();
        }
    }
}
