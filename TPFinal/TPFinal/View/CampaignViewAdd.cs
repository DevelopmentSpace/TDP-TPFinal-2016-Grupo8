using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TPFinal.DTO;
using TPFinal.Model;
using Microsoft.Practices.Unity;

namespace TPFinal.View
{
    public partial class CampaignViewAdd : Form
    {

        private CampaignService iCampaignService = IoCContainerLocator.Container.Resolve<CampaignService>();

        public CampaignViewAdd()
        {
            InitializeComponent();
            idText.Text = iCampaignService.GetLastCampaignId().ToString();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addPictureButton_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
        }

        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            foreach (String dir in openFileDialog.FileNames)
            {
                dataGridViewImages.Rows.Add(dataGridViewImages.Rows.Count, Bitmap.FromFile(dir));
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

        //ESTO NO VA ACA
        private static Byte[] imageToByte(Image i)
        {
            MemoryStream stream = new MemoryStream();
            i.Save(stream, ImageFormat.Png);
            byte[] bytes = stream.ToArray();
            return bytes;
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            try
            {
                CampaignDTO campaign = new CampaignDTO();
                campaign.name = campaignNameText.Text;

                campaign.interval = Convert.ToInt32(intervalMinute.Text) * 60 + Convert.ToInt32(intervalSecond.Text);

                campaign.initDate = initDateTimePicker.Value.Date;
                campaign.endDate = endDateTimePicker.Value.Date;

                campaign.initTime = new TimeSpan(Convert.ToInt32(initTimeHour.Text), Convert.ToInt32(initTimeMinute.Text), 0);
                campaign.endTime = new TimeSpan(Convert.ToInt32(endTimeHour.Text), Convert.ToInt32(endTimeMinute.Text), 0);

                IList<ByteImageDTO> imagesAuxDTO = new List<ByteImageDTO> { };

                foreach (DataGridViewRow row in dataGridViewImages.Rows)
                {
                    ByteImageDTO imageDTO = new ByteImageDTO();

                    imageDTO.id = Convert.ToInt32(row.Cells[0].Value);
                    imageDTO.bytes = CampaignViewAdd.imageToByte((Image)row.Cells[1].Value);

                    imagesAuxDTO.Add(imageDTO);
                }

                campaign.imagesList = imagesAuxDTO;

            
                iCampaignService.Create(campaign);
                this.Close();
            }
            catch (FormatException)
            {
                MessageBox.Show("Bad text format: Insert numbers");
            }
            catch(ArgumentException)
            {
                MessageBox.Show("Bad hour format: Hours must go from 0 to 24, minutes and seconds must go from 0 to 60.Also init-time/date must be greater then end-time/date.");
            }
        }
    }
}
