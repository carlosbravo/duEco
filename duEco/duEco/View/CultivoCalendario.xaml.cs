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
	public partial class CultivoCalendario : ContentPage
	{
		public CultivoCalendario (string cultivo)
		{
			InitializeComponent ();

            App.Current.Properties["planta"] = cultivo;
        }
	}
}