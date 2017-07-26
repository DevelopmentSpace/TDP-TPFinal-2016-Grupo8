using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Practices.Unity;
using TPFinal.Model;
using TPFinal.DTO;
using TPFinal.Domain;

namespace TPFinal.View
{
    /// <summary>
    /// Vista de publicidades
    /// </summary>
    public partial class AdView : Form, IObserver
    {
        /// <summary>
        /// Servicio de banners
        /// </summary>
        private IBannerService iBannerService = IoCContainerLocator.Container.Resolve<IBannerService>();
        /// <summary>
        /// Servicio de campañas
        /// </summary>
        private ICampaignService iCampaignService = IoCContainerLocator.Container.Resolve<ICampaignService>();

        /// <summary>
        /// String de espacios
        /// </summary>
        private static string SPACE_STRING = "                                                                                                                                                                                             ";

        public AdView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Se ejecuta al cargar la AdView
        /// </summary>
        private void AdView_Load(object sender, EventArgs e)
        {
            //Agrega como observador esta vista al servicio de campañas.
            iCampaignService.AddListener(this);

            //Actualiza por primera vez la imagen de la pantalla
            UpdateImage();

            //Configura el timer
            moveTextTimer.Interval = 50;
            moveTextTimer.Enabled = true;    

            textBanner.Text = "";
        }

        /// <summary>
        /// Metodo que se encarga de actualizar la imagen en pantalla.
        /// </summary>
        private void UpdateImage()
        {
            ByteImageMapper imageMapper = new ByteImageMapper();
            ByteImage imageModel = new ByteImage();
            byte[] image;

            //Mapea de DTO a ByteImage
            imageMapper.MapToModel(iCampaignService.GetActualImage(), imageModel);
            //Obtiene los bytes
            image = imageModel.bytes;

            //Si la imagen obtenida desde el servicio de camapaña es nula muestra la imagen por defecto.
            if (image == null)
            {
                imageBox.Image = Image.FromFile("defaultImage.jpg");
                return;
            } 

            //Si no es nula la muestra la imagen obtenida en pantalla
            MemoryStream stream = new MemoryStream(image);
            Image i = Image.FromStream(stream);
            stream.Dispose();
            imageBox.Image = i;
        }

        /// <summary>
        /// Cada vez que es notificado por el servicio de campañas actualiza la imagen.
        /// </summary>
        public void Update(String des)
        {
            if (des == "Campaign")
            {
                UpdateImage();
            }
        }

        /// <summary>
        /// Cada vez que el timer llega a su tiempo de ejecucion
        /// </summary>
        private void moveTextTimer_Tick(object sender, EventArgs e)
        {
            //Si es el string que se muestra en pantalla es mayor a 0 elimina el primer caracter
            if (textBanner.Text.Length > 0)
            {
                textBanner.Text = textBanner.Text.Remove(0, 1);
            }
            //Si el string esta vacio
            else
            {
                string showText = iBannerService.GetText();
                //Y si el texto obtenido en el servicio de banner no es vacio, actualiza la vista y muestra el texto obtenido
                if (showText != "")
                { 
                    textBanner.Text = SPACE_STRING + showText;
                }
            }
        }

        /// <summary>
        /// Se ejecuta cuando la pantalla se esta por cerrar
        /// </summary>
        private void AdView_Leave(object sender, EventArgs e)
        {
            //Saca la pantalla de la lista de observadores del servicio de campañas
            iCampaignService.RemoveListener(this);
        }
    }
}
