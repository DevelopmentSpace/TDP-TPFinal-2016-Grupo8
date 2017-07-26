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
using System.IO;


namespace TPFinal.View
{
    public partial class CampaignView : Form
    {
        private CampaignDTO iCampaignDTO;

        public CampaignDTO ViewCampaignDTO
        {
            get
            {
                return iCampaignDTO;
            }
        }

        public CampaignView(CampaignDTO pCampaignDTO)
        {
            InitializeComponent();

            if (pCampaignDTO != null)
            {
                iCampaignDTO = pCampaignDTO;
                loadCampaignInView();
            }
            else
            {
                iCampaignDTO = new CampaignDTO();
            }
        }

        private void loadCampaignInView()
        {
            campaignNameText.Text = iCampaignDTO.name;

            TimeSpan interval = new TimeSpan(0, 0, 0, iCampaignDTO.interval, 0);

            initDateTimePicker.Value = iCampaignDTO.initDate;
            endDateTimePicker.Value = iCampaignDTO.endDate;

            initTimeHour.Text = iCampaignDTO.initTime.Hours.ToString();
            initTimeMinute.Text = iCampaignDTO.initTime.Minutes.ToString();

            endTimeHour.Text = iCampaignDTO.endTime.Hours.ToString();
            endTimeMinute.Text = iCampaignDTO.endTime.Minutes.ToString();

            intervalMinute.Text = interval.Minutes.ToString();
            intervalSecond.Text = interval.Seconds.ToString();

            IList<ByteImageDTO> imagesAuxDTO = iCampaignDTO.imagesList.ToList<ByteImageDTO>();

            foreach (ByteImageDTO image in imagesAuxDTO)
            {
                MemoryStream ms = new MemoryStream(image.bytes);
                Image imageAux = System.Drawing.Image.FromStream(ms);
                dataGridViewImages.Rows.Add(imageAux);
                ms.Dispose();
            }
        }

        private void loadCampaignInVariable()
        {
            iCampaignDTO.name = campaignNameText.Text;
            iCampaignDTO.interval = Convert.ToInt32(intervalMinute.Text) * 60 + Convert.ToInt32(intervalSecond.Text);

            if (initDateTimePicker.Value.Date > endDateTimePicker.Value.Date)
                throw new ArgumentException();

            iCampaignDTO.initDate = initDateTimePicker.Value.Date;
            iCampaignDTO.endDate = endDateTimePicker.Value.Date;

            int initHour, endHour, initMinute, endMinute;

            initHour = Convert.ToInt32(initTimeHour.Text);
            endHour = Convert.ToInt32(endTimeHour.Text);
            initMinute = Convert.ToInt32(initTimeMinute.Text);
            endMinute = Convert.ToInt32(endTimeMinute.Text);


            if (initHour < 0 || initHour > 23 || endHour < 0 || endHour > 23 || ((initHour > endHour) && (initMinute > endMinute)) || initMinute < 0 || initMinute > 59 || endMinute < 0 || endMinute > 59)
            {
                throw new ArgumentException();
            }

            iCampaignDTO.initTime = new TimeSpan(initHour, initMinute, 0);
            iCampaignDTO.endTime = new TimeSpan(endHour, endMinute, 0);


            IList<ByteImageDTO> imagesAuxDTO = new List<ByteImageDTO> { };

            foreach (DataGridViewRow row in dataGridViewImages.Rows)
            {
                ByteImageDTO imageDTO = new ByteImageDTO();

                imageDTO.bytes = Utilities.imageToByte((Image)row.Cells[0].Value);

                imagesAuxDTO.Add(imageDTO);
            }
            if (imagesAuxDTO.Count == 0)
                throw new ArgumentNullException();

            iCampaignDTO.imagesList = imagesAuxDTO;
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
                loadCampaignInVariable();
                DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (FormatException)
            {
                MessageBox.Show("Bad time format: Insert numbers.");
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("The campaign must have at least one image.");
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
