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
	public partial class Home : ContentPage
	{
		public Home ()
		{
			InitializeComponent();
            btnCatalogo.Clicked += btnCatalogo_Clicked;
		}

        private void btnCatalogo_Clicked(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new View.Catalogo());
        }
    }
}