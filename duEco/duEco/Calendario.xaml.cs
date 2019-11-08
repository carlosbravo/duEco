﻿using Plugin.LocalNotifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace duEco
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Calendario : ContentPage
	{
		public Calendario ()
		{
			InitializeComponent ();
            calCalendario.SelectedDate = DateTime.Now;            
		}

        private void BtnNuevoRecordatorio_Clicked(object sender, EventArgs e)
        {          
            DateTime dtmFechaSeleccionada = Convert.ToDateTime(calCalendario.SelectedDate);

            Navigation.PushAsync(new View.CrearRecordatorio(dtmFechaSeleccionada));                        
        }        
    }
}