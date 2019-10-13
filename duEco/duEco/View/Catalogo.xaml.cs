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
            List<Model.CategoriaModel> lasCategorias = new List<Model.CategoriaModel>();

            var item0 = new Model.CategoriaModel { id = 0, nombre = "Todas" };
            var item1 = new Model.CategoriaModel { id = 1, nombre = "Semilla" };
            var item2 = new Model.CategoriaModel { id = 2, nombre = "Verduras" };
            var item3 = new Model.CategoriaModel { id = 3, nombre = "Vegetales" };

            lasCategorias.Add(item0);
            lasCategorias.Add(item1);
            lasCategorias.Add(item2);
            lasCategorias.Add(item3);

            foreach (Model.CategoriaModel categoria in lasCategorias)
            {
                ddlCategorias.Items.Add(categoria.nombre);
            }
        }

        private void cargarCatalogo()
        {
            lstPlantas.ItemsSource = PlantaServicio.todasLasPlantas();
        }

        private void BtnInfoPlanta_Clicked(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new View.VerPlanta());
        }
    }
}