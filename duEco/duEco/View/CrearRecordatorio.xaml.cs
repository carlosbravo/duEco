using Plugin.LocalNotifications;
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
	public partial class CrearRecordatorio : ContentPage
	{
        DateTime dtmFechaRec;

        public CrearRecordatorio (DateTime dtmFechaCreacion)
		{
			InitializeComponent ();

            dtmFechaRec = dtmFechaCreacion;
            lblFecha.Text = dtmFechaRec.ToShortDateString();
        }

        private void BtnCrearRecordatorio_Clicked(object sender, EventArgs e)
        {
            DateTime dtmFinal = new DateTime(dtmFechaRec.Year,
                                                dtmFechaRec.Month,
                                                dtmFechaRec.Day,
                                                tmpHora.Time.Hours,
                                                tmpHora.Time.Minutes,
                                                00);            
            CrossLocalNotifications.Current.Show("duEco", txtDescripcion.Text, 0, dtmFinal);
        }
    }    
}