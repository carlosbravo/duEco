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
	public partial class VerCultivo : ContentPage
	{
		public VerCultivo (string cultivoID)
		{
			InitializeComponent();
            MostrarCultivoSeleccionado(cultivoID);
		}

        private void MostrarCultivoSeleccionado(string cultivoID)
        {
            var esCultivo = CultivoServicio.BuscarPorId(cultivoID);
            if (esCultivo != null)
            {
                NombreCultivo.Text = esCultivo.NombreCultivo;
            }
        }
    }
}