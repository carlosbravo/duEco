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
        private string _huertaID;

        public VerHuerta (string huertaID)
		{
			InitializeComponent ();
            _huertaID = huertaID;
            MostrarHuertaSeleccionada(_huertaID);
            btnAgregar.Clicked += BtnAgregar_Clicked;
            btnTodas.Clicked += BtnTodas_Clicked;
        }

        private void BtnTodas_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MisHuertas());
        }

        private void BtnAgregar_Clicked(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new ABMCultivo(_huertaID));
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
                    var cultivoTest = new Model.CultivoModel();
                    foreach (var item in esHuerta.ListaCultivos)
                    {
                        if (item != null)
                        {
                            item.descripcion = "% Sembrado: 20";
                        }
                    }
                    
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