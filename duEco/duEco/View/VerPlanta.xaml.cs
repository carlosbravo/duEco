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
		public VerPlanta ()
		{
			InitializeComponent ();

            var esPlanta = PlantaServicio.buscarPorId("dfe1f51fe651fef1");
            NombrePlanta.Text = esPlanta.nombre;
            ImagenPortada.Source = esPlanta.imagenPortada;
            Descripcion.Text = esPlanta.id;
		}
	}
}