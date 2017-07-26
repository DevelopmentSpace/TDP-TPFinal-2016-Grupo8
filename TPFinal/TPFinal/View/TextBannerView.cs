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
    public partial class TextBannerView : Form
    {

        public TextBannerDTO textBannerDTO;

        public TextBannerView(TextBannerDTO pTextBannerDTO)
        {
            InitializeComponent();

            if (pTextBannerDTO != null)
            {
                textBannerDTO = pTextBannerDTO;
                loadTextBannerInView();
            }
            else
            {
                textBannerDTO = new TextBannerDTO();
            }
        }

        private void loadTextBannerInView()
        {
            bannerNameText.Text = textBannerDTO.name;

            initDateTimePicker.Value = textBannerDTO.initDate;
            endDateTimePicker.Value = textBannerDTO.endDate;

            initTimeHour.Text = textBannerDTO.initTime.Hours.ToString();
            initTimeMinute.Text = textBannerDTO.initTime.Minutes.ToString();

            endTimeHour.Text = textBannerDTO.endTime.Hours.ToString();
            endTimeMinute.Text = textBannerDTO.endTime.Minutes.ToString();

            textBanner.Text = textBannerDTO.text;
        }

        private void loadTextBannerInVariable()
        {
            textBannerDTO.name = bannerNameText.Text;

            if (initDateTimePicker.Value.Date > endDateTimePicker.Value.Date)
                throw new ArgumentException();

            textBannerDTO.initDate = initDateTimePicker.Value.Date;
            textBannerDTO.endDate = endDateTimePicker.Value.Date;

            int initHour, endHour, initMinute, endMinute;

            initHour = Convert.ToInt32(initTimeHour.Text);
            endHour = Convert.ToInt32(endTimeHour.Text);
            initMinute = Convert.ToInt32(initTimeMinute.Text);
            endMinute = Convert.ToInt32(endTimeMinute.Text);


            if (initHour < 0 || initHour > 23 || endHour < 0 || endHour > 23 || ((initHour > endHour) && (initMinute > endMinute)) || initMinute < 0 || initMinute > 59 || endMinute < 0 || endMinute > 59)
            {
                throw new ArgumentException();
            }

            textBannerDTO.initTime = new TimeSpan(initHour, initMinute, 0);
            textBannerDTO.endTime = new TimeSpan(endHour, endMinute, 0);

            textBannerDTO.text = textBanner.Text;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            textBannerDTO = null;
            this.Close();
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            try
            {
                loadTextBannerInVariable();
                this.Close();
            }
            catch (FormatException)
            {
                MessageBox.Show("Bad time format: Insert numbers");
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Bad hour format: Hours must go from 0 to 24, minutes and seconds must go from 0 to 60. Also init-time/date must be greater then end-time/date.");
            }


        }
    }
}
