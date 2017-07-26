﻿using System;
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
    public partial class RssBannerView : Form
    {

        public RssBannerDTO rssBannerDTO;

        public RssBannerView(RssBannerDTO pRssBannerDTO)
        {
            InitializeComponent();

            if (pRssBannerDTO != null)
            {
                rssBannerDTO = pRssBannerDTO;
                loadRssBannerInView();
            }
            else
            {
                rssBannerDTO = new RssBannerDTO();
            }

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void loadRssBannerInView()
        {
            bannerNameText.Text = rssBannerDTO.name;

            initDateTimePicker.Value = rssBannerDTO.initDate;
            endDateTimePicker.Value = rssBannerDTO.endDate;

            initTimeHour.Text = rssBannerDTO.initTime.Hours.ToString();
            initTimeMinute.Text = rssBannerDTO.initTime.Minutes.ToString();

            endTimeHour.Text = rssBannerDTO.endTime.Hours.ToString();
            endTimeMinute.Text = rssBannerDTO.endTime.Minutes.ToString();

            textBanner.Text = rssBannerDTO.url;
        }

        private void loadRssBannerInVariable()
        {
            rssBannerDTO.name = bannerNameText.Text;

            if (initDateTimePicker.Value.Date > endDateTimePicker.Value.Date)
                throw new ArgumentException();

            rssBannerDTO.initDate = initDateTimePicker.Value.Date;
            rssBannerDTO.endDate = endDateTimePicker.Value.Date;

            int initHour, endHour, initMinute, endMinute;

            initHour = Convert.ToInt32(initTimeHour.Text);
            endHour = Convert.ToInt32(endTimeHour.Text);
            initMinute = Convert.ToInt32(initTimeMinute.Text);
            endMinute = Convert.ToInt32(endTimeMinute.Text);


            if (initHour < 0 || initHour > 23 || endHour < 0 || endHour > 23 || ((initHour > endHour) && (initMinute > endMinute)) || initMinute < 0 || initMinute > 59 || endMinute < 0 || endMinute > 59)
            {
                throw new ArgumentException();
            }

            rssBannerDTO.initTime = new TimeSpan(initHour, initMinute, 0);
            rssBannerDTO.endTime = new TimeSpan(endHour, endMinute, 0);

            rssBannerDTO.url = textBanner.Text;
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            try
            {
                loadRssBannerInVariable();
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