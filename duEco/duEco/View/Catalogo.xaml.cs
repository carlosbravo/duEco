using duEco.Servicio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace duEco.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Catalogo : ContentPage
	{
        public Catalogo()
        {
            InitializeComponent();

            cargarCatalogo();
            listarCategorias();
            
        }

        private void listarCategorias()
        {
            List<Model.CategoriaModel> lasCategorias = PlantaServicio.obtenerCategorias(); //new List<Model.CategoriaModel>();

            foreach (Model.CategoriaModel categoria in lasCategorias)
            {
                ddlCategorias.Items.Add(categoria.nombre);
            }
        }

        private void cargarCatalogo()
        {
            lstPlantas.ItemsSource = PlantaServicio.todasLasPlantas();
        }

        void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedPlanta = (Model.PlantaModel)e.SelectedItem;
            var item = selectedPlanta.id.ToString();
            try
            {
                if (selectedPlanta != null)
                {
                    ((NavigationPage)this.Parent).PushAsync(new VerPlanta(item));
                }
            }
            catch (Exception x)
            {
                throw x;
            }
            
        }
    }
}