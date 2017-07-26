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
    /// <summary>
    /// Vista de campañas
    /// </summary>
    public partial class CampaignView : Form
    {
        /// <summary>
        /// Atributo campaignDTO
        /// </summary>
        private CampaignDTO iCampaignDTO;

        /// <summary>
        /// Accesor del atributo CampaignDTO
        /// </summary>
        public CampaignDTO ViewCampaignDTO
        {
            get
            {
                return iCampaignDTO;
            }
        }

        /// <summary>
        /// Constructor de la vista de campañas. Se le pasa un objeto segun es para crear uno nuevo o para editarlo
        /// </summary>
        /// <param name="pCampaignDTO">Objeto de tipo campaignDTO</param>
        public CampaignView(CampaignDTO pCampaignDTO)
        {
            InitializeComponent();

            //Si el objeto no es nulo, lo carga en la vista y lo asigna a la variable.
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

        /// <summary>
        /// Carga la campaña del atributo en la vista
        /// </summary>
        private void loadCampaignInView()
        {
            campaignNameText.Text = iCampaignDTO.name;

            initDateTimePicker.Value = iCampaignDTO.initDate;
            endDateTimePicker.Value = iCampaignDTO.endDate;

            initTimeHour.Text = iCampaignDTO.initTime.Hours.ToString();
            initTimeMinute.Text = iCampaignDTO.initTime.Minutes.ToString();

            endTimeHour.Text = iCampaignDTO.endTime.Hours.ToString();
            endTimeMinute.Text = iCampaignDTO.endTime.Minutes.ToString();

            TimeSpan interval = new TimeSpan(0, 0, 0, iCampaignDTO.interval, 0);
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

        /// <summary>
        /// Carga la campaña de la vista en la campaña del atributo
        /// </summary>
        private void loadCampaignInVariable()
        {
            iCampaignDTO.name = campaignNameText.Text;
            iCampaignDTO.interval = Convert.ToInt32(intervalMinute.Text) * 60 + Convert.ToInt32(intervalSecond.Text);

            if (initDateTimePicker.Value.Date > endDateTimePicker.Value.Date)
                throw new ArgumentException();

            iCampaignDTO.initDate = initDateTimePicker.Value.Date;
            iCampaignDTO.endDate = endDateTimePicker.Value.Date;

            IList<TimeSpan> listSpan = Utilities.createTimeSpans(initTimeHour.Text, initTimeMinute.Text, endTimeHour.Text, endTimeMinute.Text);

            iCampaignDTO.initTime = listSpan.ElementAt(0);
            iCampaignDTO.endTime = listSpan.ElementAt(1);

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

        /// <summary>
        /// Se ejecuta cuando se cliquea el boton de cancelar. Cierra la vista y sale como cancelado.
        /// </summary>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// Se ejecuta cuando se cliquea el boton de aceptar. Intenta cargar la campaña de la vista en el atributo
        /// </summary>
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

        /// <summary>
        /// Se ejecuta cuando se presiona el boton de agregar imagen. Abre el seleccionador de imagenes.
        /// </summary>
        private void addButtonImage_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
        }

        /// <summary>
        /// Se ejecuta cuando se seleccionaron las imagenes. Agrega cada imagen a la lista de la vista.
        /// </summary>
        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            foreach (String dir in openFileDialog.FileNames)
            {
                dataGridViewImages.Rows.Add(Bitmap.FromFile(dir));
            }
            dataGridViewImages.Update();
            dataGridViewImages.Refresh();
        }

        /// <summary>
        /// Se ejecuta cada vez que se presiona la letra d en la lista de la vista y si tiene seleccionada una fila, la elimina.
        /// </summary>
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
