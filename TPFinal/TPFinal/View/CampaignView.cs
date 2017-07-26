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
using System.IO;


namespace TPFinal.View
{
    public partial class CampaignView : Form
    {
        public CampaignDTO campaignDTO;

        public CampaignView(CampaignDTO pCampaignDTO)
        {
            InitializeComponent();

            if (pCampaignDTO != null)
            {
                campaignDTO = pCampaignDTO;
                loadCampaignInView();
            }
            else
            {
                campaignDTO = new CampaignDTO();
            }
        }

        private void loadCampaignInView()
        {
            campaignNameText.Text = campaignDTO.name;

            TimeSpan interval = new TimeSpan(0, 0, 0, campaignDTO.interval, 0);

            initDateTimePicker.Value = campaignDTO.initDate;
            endDateTimePicker.Value = campaignDTO.endDate;

            initTimeHour.Text = campaignDTO.initTime.Hours.ToString();
            initTimeMinute.Text = campaignDTO.initTime.Minutes.ToString();

            endTimeHour.Text = campaignDTO.endTime.Hours.ToString();
            endTimeMinute.Text = campaignDTO.endTime.Minutes.ToString();

            intervalMinute.Text = interval.Minutes.ToString();
            intervalSecond.Text = interval.Seconds.ToString();

            IList<ByteImageDTO> imagesAuxDTO = campaignDTO.imagesList.ToList<ByteImageDTO>();

            foreach (ByteImageDTO image in imagesAuxDTO)
            {
                MemoryStream ms = new MemoryStream(image.bytes);
                Image imageAux = System.Drawing.Image.FromStream(ms);
                dataGridViewImages.Rows.Add(image.id, imageAux);
                ms.Dispose();
            }
        }

        private void loadCampaignInVariable()
        {
            campaignDTO.name = campaignNameText.Text;
            campaignDTO.interval = Convert.ToInt32(intervalMinute.Text) * 60 + Convert.ToInt32(intervalSecond.Text);

            if (initDateTimePicker.Value.Date > endDateTimePicker.Value.Date)
                throw new ArgumentException();

            campaignDTO.initDate = initDateTimePicker.Value.Date;
            campaignDTO.endDate = endDateTimePicker.Value.Date;

            int initHour, endHour, initMinute, endMinute;

            initHour = Convert.ToInt32(initTimeHour.Text);
            endHour = Convert.ToInt32(endTimeHour.Text);
            initMinute = Convert.ToInt32(initTimeMinute.Text);
            endMinute = Convert.ToInt32(endTimeMinute.Text);


            if (initHour < 0 || initHour > 23 || endHour < 0 || endHour > 23 || ((initHour > endHour) && (initMinute > endMinute)) || initMinute < 0 || initMinute > 59 || endMinute < 0 || endMinute > 59)
            {
                throw new ArgumentException();
            }

            campaignDTO.initTime = new TimeSpan(initHour, initMinute, 0);
            campaignDTO.endTime = new TimeSpan(endHour, endMinute, 0);


            IList<ByteImageDTO> imagesAuxDTO = new List<ByteImageDTO> { };

            foreach (DataGridViewRow row in dataGridViewImages.Rows)
            {
                ByteImageDTO imageDTO = new ByteImageDTO();

                imageDTO.bytes = Utilities.imageToByte((Image)row.Cells[0].Value);

                imagesAuxDTO.Add(imageDTO);
            }

            campaignDTO.imagesList = imagesAuxDTO;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            campaignDTO = null;
            this.Close();
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            try
            {
                loadCampaignInVariable();
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

        private void addButtonImage_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
        }

        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            foreach (String dir in openFileDialog.FileNames)
            {
                dataGridViewImages.Rows.Add(Bitmap.FromFile(dir));
            }
            dataGridViewImages.Update();
            dataGridViewImages.Refresh();
        }

        private void dataGridViewImages_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'd')
            {
                foreach (DataGridViewRow row in dataGridViewImages.SelectedRows)
                {
                    dataGridViewImages.Rows.Remove(row);
                }
            }
        }
    }
}
