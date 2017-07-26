using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Practices.Unity;
using TPFinal.Model;
using TPFinal.DTO;

namespace TPFinal.View
{
    /// <summary>
    /// Vista de busquedas de banners de texto
    /// </summary>
    public partial class TextBannerViewSearch : Form
    {
        /// <summary>
        /// Servicio de banners de texto
        /// </summary>
        private ITextBannerService iTextBannerService = IoCContainerLocator.Container.Resolve<ITextBannerService>();

        /// <summary>
        /// Enumerable con todos los banners de texto
        /// </summary>
        private IEnumerable<TextBannerDTO> textBanners;

        /// <summary>
        /// Constructor de la vista de busqueda de banners de texto
        /// </summary>
        public TextBannerViewSearch()
        {
            InitializeComponent();
            //Se obtienen todos los banners de texto en el enumerable
            textBanners = iTextBannerService.GetAll();

            //Se ejecuta por primera para actualizar la lista de banners de texto
            searchText.Text = "";
            searchText_TextChanged(null, EventArgs.Empty);
        }

        /// <summary>
        /// Se ejecuta cuando cambia el texto en pantalla. Muestra los banners de texto cuyo nombre sea igual al texto ingresado.
        /// </summary>
        private void searchText_TextChanged(object sender, EventArgs e)
        {
            int searchLenght = searchText.Text.Length;
            dataGridViewTextBanners.Rows.Clear();
            IEnumerator<TextBannerDTO> textBannersEnumerator = textBanners.GetEnumerator();

            while (textBannersEnumerator.MoveNext())
            {
                if (textBannersEnumerator.Current.name.Length >= searchLenght)
                {
                    if (textBannersEnumerator.Current.name.Substring(0, searchLenght).ToLower() == searchText.Text.ToString().Substring(0, searchLenght).ToLower())
                    {
                        dataGridViewTextBanners.Rows.Add(textBannersEnumerator.Current.id, textBannersEnumerator.Current.name, textBannersEnumerator.Current.initDate.Date.ToString("dd/MM/yyyy"), textBannersEnumerator.Current.endDate.Date.ToString("dd/MM/yyyy"),textBannersEnumerator.Current.text);
                    }
                }
            }
            textBannersEnumerator.Reset();
        }

        /// <summary>
        /// En el caso de estar seleccionando la lista y presionar la 'd' o la 'm'. Permite eliminar o modificar filas segun corresponda.
        /// </summary>
        private void dataGridViewTextBanners_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'd')
            {
                foreach (DataGridViewRow row in dataGridViewTextBanners.SelectedRows)
                {
                    try
                    {
                        //Se le pasa la id de la columna seleccionada
                        iTextBannerService.Delete((int)row.Cells[0].Value);
                        dataGridViewTextBanners.Rows.Remove(row);
                        dataGridViewTextBanners.Refresh();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error deleting TextBanner.");
                    }
                }
                textBanners = iTextBannerService.GetAll();
                searchText_TextChanged(null, EventArgs.Empty);
            }
            else if (e.KeyChar == 'm')
            {
                if (dataGridViewTextBanners.SelectedRows.Count == 1)
                {
                    try
                    {
                        //Se crea una vista pasandole como parametro el objeto seleccionado.
                        TextBannerView textBannerView = new TextBannerView(textBanners.First<TextBannerDTO>(x => x.id == ((int)dataGridViewTextBanners.SelectedRows[0].Cells[0].Value)));
                        textBannerView.ShowDialog();
                        iTextBannerService.Update(textBannerView.ViewTextBannerDTO);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error updating TextBanner.");
                    }
                }
                textBanners = iTextBannerService.GetAll();
                searchText_TextChanged(null, EventArgs.Empty);
            }
        }
    }
}
