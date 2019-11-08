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
	public partial class ABMHuerta : ContentPage
	{
		public ABMHuerta ()
		{
			InitializeComponent ();
            btnActualizar.Clicked += btnActualizar_Clicked;
		}

        private async void btnActualizar_Clicked(object sender, EventArgs e)
        {
            var userLog = App.Current.Properties["user"].ToString();
            if (userLog != null) {

                var ok = HuertaServicio.CrearHuerta(NombreHuerta.Text, DescHuerta.Text, userLog);
                if (ok) {
                    await DisplayAlert("Registro correcto", "Los datos se han completado correctamente", "Ok");
                    await Navigation.PushAsync(new MisHuertas());
                }
                else
                {
                    await DisplayAlert("Registro incorrecto", "Revise los datos ingresados", "Cancelar");
                }
            }

        }
    }
}