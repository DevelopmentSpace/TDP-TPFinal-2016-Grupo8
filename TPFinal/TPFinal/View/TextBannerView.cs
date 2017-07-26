using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TPFinal.DTO;

namespace TPFinal.View
{
    /// <summary>
    /// Vista de los banners de texto
    /// </summary>
    public partial class TextBannerView : Form
    {
        /// <summary>
        /// Atributo TextBannerDTO
        /// </summary>
        private TextBannerDTO iTextBannerDTO;

        /// <summary>
        /// Accesor del atributo TextBannerDTO
        /// </summary>
        public TextBannerDTO ViewTextBannerDTO
        {
            get
            {
                return iTextBannerDTO;
            }
        }

        /// <summary>
        /// Constructor de la vista de TextBanner
        /// </summary>
        /// <param name="pCampaignDTO">Objeto de tipo TextBannerDTO que se asigna a el atributo</param>
        public TextBannerView(TextBannerDTO pTextBannerDTO)
        {
            InitializeComponent();

            //Si el objeto no es nulo, lo carga en la vista y lo asigna a la variable.
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

        /// <summary>
        /// Carga el banner del atributo en la vista
        /// </summary>
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

        /// <summary>
        /// Carga el banner de texto de la vista en el banner de texto del atributo
        /// </summary>
        private void loadTextBannerInVariable()
        {
            iTextBannerDTO.name = bannerNameText.Text;

            if (initDateTimePicker.Value.Date > endDateTimePicker.Value.Date)
                throw new ArgumentException();

            iTextBannerDTO.initDate = initDateTimePicker.Value.Date;
            iTextBannerDTO.endDate = endDateTimePicker.Value.Date;

            IList<TimeSpan> listSpan = Utilities.createTimeSpans(initTimeHour.Text, initTimeMinute.Text, endTimeHour.Text, endTimeMinute.Text);

            iTextBannerDTO.initTime = listSpan.ElementAt(0);
            iTextBannerDTO.endTime = listSpan.ElementAt(1);

            iTextBannerDTO.text = textBanner.Text;
        }

        /// <summary>
        /// Se ejecuta cuando se cliquea el boton de cancelar. Cierra la vista
        /// </summary>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Se ejecuta cuando se cliquea el boton de aceptar. Intenta cargar el banner de texto de la vista en el atributo
        /// </summary>
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
