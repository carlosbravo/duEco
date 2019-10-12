using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace duEco.Model
{
    public class UsuarioModel : INotifyPropertyChanged
    {
        private string Nombre;

        public string nombre
        {
            get { return Nombre; }
            set { Nombre = value; OnPropertyChanged(); }
        }

        private string Email;

        public string email
        {
            get { return Email; }
            set { Email = value; OnPropertyChanged(); }
        }

        private string Password;

        public string password
        {
            get { return Password; }
            set { Password = value; OnPropertyChanged(); }
        }


        #region Implements
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string nombre = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombre));
        }
        #endregion
    }
}
