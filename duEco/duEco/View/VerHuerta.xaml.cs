using duEco.Servicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace duEco.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class VerHuerta : ContentPage
	{
		public VerHuerta (string huertaID)
		{
			InitializeComponent ();
            MostrarHuertaSeleccionada(huertaID);
		}

        private void MostrarHuertaSeleccionada(string huertaID)
        {
            var esHuerta = HuertaServicio.BuscarPorId(huertaID);
            if(esHuerta != null)
            {
                NombreHuerta.Text = esHuerta.Nombre;
                DescripcionHuerta.Text = esHuerta.Descripcion;
                if(esHuerta.ListaCultivos.Count > 0)
                {
                    lstCultivos.ItemsSource = esHuerta.ListaCultivos;
                }
            }
        }

        private void LstCultivos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedCultivo = (Model.CultivoModel)e.SelectedItem;
            var item = selectedCultivo.id.ToString();
            try
            {
                if (selectedCultivo != null)
                {
                    ((NavigationPage)this.Parent).PushAsync(new VerCultivo(item));
                }
            }
            catch (Exception x)
            {
                throw x;
            }
        }
    }
}