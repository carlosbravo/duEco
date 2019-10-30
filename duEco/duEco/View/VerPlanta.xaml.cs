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
	public partial class VerPlanta : ContentPage
	{
		public VerPlanta (string plantaId)
		{
			InitializeComponent ();

            var esPlanta = PlantaServicio.buscarPorId(plantaId);
            NombrePlanta.Text = esPlanta.nombre;
            ImagenPortada.Source = esPlanta.imagenPortada;
            Descripcion.Text = esPlanta.id;
		}
	}
}