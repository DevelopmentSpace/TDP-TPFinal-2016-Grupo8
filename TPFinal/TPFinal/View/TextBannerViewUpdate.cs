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
using TPFinal.DTO;
using TPFinal.Model;

namespace TPFinal.View
{
    public partial class TextBannerViewUpdate : Form
    {
        private TextBannerService iTextBannerService = IoCContainerLocator.Container.Resolve<TextBannerService>();

        public TextBannerViewUpdate()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            TextBannerDTO banner = new TextBannerDTO();
            banner.id = Convert.ToInt32(idText.Text);
            banner.name = bannerNameText.Text;

            banner.initDate = initDateTimePicker.Value.Date;
            banner.endDate = endDateTimePicker.Value.Date;

            banner.initTime = new TimeSpan(Convert.ToInt32(initTimeHour.Text), Convert.ToInt32(initTimeMinute.Text), 0);
            banner.endTime = new TimeSpan(Convert.ToInt32(endTimeHour.Text), Convert.ToInt32(endTimeMinute.Text), 0);

            banner.text = textBanner.Text;

            iTextBannerService.Update(banner);

            this.Close();
        }
    }
}
