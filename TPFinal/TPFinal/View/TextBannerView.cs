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

        private TextBannerDTO iTextBannerDTO;

        public TextBannerDTO ViewTextBannerDTO
        {
            get
            {
                return iTextBannerDTO;
            }
        }

        public TextBannerView(TextBannerDTO pTextBannerDTO)
        {
            InitializeComponent();

            if (pTextBannerDTO != null)
            {
                iTextBannerDTO = pTextBannerDTO;
                loadTextBannerInView();
            }
            else
            {
                iTextBannerDTO = new TextBannerDTO();
            }
        }

        private void loadTextBannerInView()
        {
            bannerNameText.Text = iTextBannerDTO.name;

            initDateTimePicker.Value = iTextBannerDTO.initDate;
            endDateTimePicker.Value = iTextBannerDTO.endDate;

            initTimeHour.Text = iTextBannerDTO.initTime.Hours.ToString();
            initTimeMinute.Text = iTextBannerDTO.initTime.Minutes.ToString();

            endTimeHour.Text = iTextBannerDTO.endTime.Hours.ToString();
            endTimeMinute.Text = iTextBannerDTO.endTime.Minutes.ToString();

            textBanner.Text = iTextBannerDTO.text;
        }

        private void loadTextBannerInVariable()
        {
            iTextBannerDTO.name = bannerNameText.Text;

            if (initDateTimePicker.Value.Date > endDateTimePicker.Value.Date)
                throw new ArgumentException();

            iTextBannerDTO.initDate = initDateTimePicker.Value.Date;
            iTextBannerDTO.endDate = endDateTimePicker.Value.Date;

            int initHour, endHour, initMinute, endMinute;

            initHour = Convert.ToInt32(initTimeHour.Text);
            endHour = Convert.ToInt32(endTimeHour.Text);
            initMinute = Convert.ToInt32(initTimeMinute.Text);
            endMinute = Convert.ToInt32(endTimeMinute.Text);


            if (initHour < 0 || initHour > 23 || endHour < 0 || endHour > 23 || ((initHour > endHour) && (initMinute > endMinute)) || initMinute < 0 || initMinute > 59 || endMinute < 0 || endMinute > 59)
            {
                throw new ArgumentException();
            }

            iTextBannerDTO.initTime = new TimeSpan(initHour, initMinute, 0);
            iTextBannerDTO.endTime = new TimeSpan(endHour, endMinute, 0);

            iTextBannerDTO.text = textBanner.Text;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            try
            {
                loadTextBannerInVariable();
                DialogResult = DialogResult.OK;
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
