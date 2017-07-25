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
    public partial class TextBannerViewAdd : Form
    {

        private TextBannerService iTextBannerService = IoCContainerLocator.Container.Resolve<TextBannerService>();

        public TextBannerViewAdd()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            TextBannerDTO banner = new TextBannerDTO();
            banner.name = bannerNameText.Text;

            banner.initDate = initDateTimePicker.Value.Date;
            banner.endDate = endDateTimePicker.Value.Date;

            banner.initTime = new TimeSpan(Convert.ToInt32(initTimeHour.Text), Convert.ToInt32(initTimeMinute.Text), 0);
            banner.endTime = new TimeSpan(Convert.ToInt32(endTimeHour.Text), Convert.ToInt32(endTimeMinute.Text), 0);

            banner.text = textBanner.Text;

            iTextBannerService.Create(banner);

            this.Close();

        }
    }
}
