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
    public partial class RssTextBannerUpdate : Form
    {

        private RssBannerService iRssBannerService = IoCContainerLocator.Container.Resolve<RssBannerService>();

        public RssTextBannerUpdate()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            RssTextBannerSearch rssTextBannerSearch = new RssTextBannerSearch();
            rssTextBannerSearch.Show();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            RssBannerDTO banner = iRssBannerService.Get(Convert.ToInt32(idText.Text));

            bannerNameText.Text = banner.name;

            initDateTimePicker.Value = banner.initDate;
            endDateTimePicker.Value = banner.endDate;

            initTimeHour.Text = banner.initTime.Hours.ToString();
            initTimeMinute.Text = banner.initTime.Minutes.ToString();

            endTimeHour.Text = banner.endTime.Hours.ToString();
            endTimeMinute.Text = banner.endTime.Minutes.ToString();

            textBanner.Text = banner.url;
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            RssBannerDTO banner = new RssBannerDTO();
            banner.id = Convert.ToInt32(idText.Text);
            banner.name = bannerNameText.Text;

            banner.initDate = initDateTimePicker.Value.Date;
            banner.endDate = endDateTimePicker.Value.Date;

            banner.initTime = new TimeSpan(Convert.ToInt32(initTimeHour.Text), Convert.ToInt32(initTimeMinute.Text), 0);
            banner.endTime = new TimeSpan(Convert.ToInt32(endTimeHour.Text), Convert.ToInt32(endTimeMinute.Text), 0);

            banner.url = textBanner.Text;

            iRssBannerService.Update(banner);

            this.Close();
        }
    }
}
