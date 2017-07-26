using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TPFinal.DTO;
using TPFinal.Model;
using Microsoft.Practices.Unity;

namespace TPFinal.View
{
    /// <summary>
    /// Vista de busquedas de fuentes RSS
    /// </summary>
    public partial class RssTextBannerSearch : Form
    {
        /// <summary>
        /// Servicio de fuentes de RSS
        /// </summary>
        private IRssBannerService iRssBannerService = IoCContainerLocator.Container.Resolve<IRssBannerService>();

        /// <summary>
        /// Enumerable con todos los RssBannerDTO
        /// </summary>
        private IEnumerable<RssBannerDTO> rssBanners;

        /// <summary>
        /// Constructor de la vista de busqueda de fuentes de RSS
        /// </summary>
        public RssTextBannerSearch()
        {
            InitializeComponent();
            //Se obtienen todas las fuentes RSS en el enumerable
            rssBanners = iRssBannerService.GetAll();

            //Se ejecuta por primera para actualizar la lista de fuentes RSS
            searchText.Text = "";
            searchText_TextChanged(null, EventArgs.Empty);

        }

        /// <summary>
        /// Se ejecuta cuando cambia el texto en pantalla. Muestra las fuentes RSS cuyo nombre coincida con el texto ingresado.
        /// </summary>
        private void searchText_TextChanged(object sender, EventArgs e)
        {
            int searchLenght = searchText.Text.Length;
            dataGridViewRssBanners.Rows.Clear();
            IEnumerator<RssBannerDTO> rssBannersEnumerator = rssBanners.GetEnumerator();

            while (rssBannersEnumerator.MoveNext())
            {
                if (rssBannersEnumerator.Current.name.Length >= searchLenght)
                {
                    if (rssBannersEnumerator.Current.name.Substring(0, searchLenght).ToLower() == searchText.Text.ToString().Substring(0, searchLenght).ToLower())
                    {
                        dataGridViewRssBanners.Rows.Add(rssBannersEnumerator.Current.id, rssBannersEnumerator.Current.name, rssBannersEnumerator.Current.initDate.Date.ToString("dd/MM/yyyy"), rssBannersEnumerator.Current.endDate.Date.ToString("dd/MM/yyyy"), rssBannersEnumerator.Current.url);
                    }
                }
            }
            rssBannersEnumerator.Reset();
        }

        /// <summary>
        /// En el caso de estar seleccionando la lista y presionar la 'd' o la 'm'. Permite eliminar o modificar filas segun corresponda.
        /// </summary>
        private void dataGridViewRssBanners_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'd')
            {
                foreach (DataGridViewRow row in dataGridViewRssBanners.SelectedRows)
                {
                    try
                    {
                        //Se le pasa la id de la columna seleccionada
                        iRssBannerService.Delete((int)row.Cells[0].Value);
                        dataGridViewRssBanners.Rows.Remove(row);
                        dataGridViewRssBanners.Refresh();

                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error deleting RssTextBanner.");
                    }
                }
                rssBanners = iRssBannerService.GetAll();
                searchText_TextChanged(null, EventArgs.Empty);
            }
            else if (e.KeyChar == 'm')
            {
                if (dataGridViewRssBanners.SelectedRows.Count == 1)
                {
                    try
                    {
                        //Se crea una vista pasandole como parametro el objeto seleccionado.
                        RssBannerView rssBannerView = new RssBannerView(rssBanners.First<RssBannerDTO>(x => x.id == ((int)dataGridViewRssBanners.SelectedRows[0].Cells[0].Value)));
                        rssBannerView.ShowDialog();
                        iRssBannerService.Update(rssBannerView.ViewRssBannerDTO);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error updating RssBanner.");
                    }
                }
                rssBanners = iRssBannerService.GetAll();
                searchText_TextChanged(null, EventArgs.Empty);
            }

        }
    }
}
