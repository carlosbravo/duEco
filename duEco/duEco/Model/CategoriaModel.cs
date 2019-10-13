using System;
using System.Collections.Generic;
using System.Text;

namespace duEco.Model
{
    public class CategoriaModel
    {
        private int Id;

        public int id
        {
            get { return Id; }
            set { Id = value; }
        }

        private string Nombre;

        public string nombre
        {
            get { return Nombre; }
            set { Nombre = value; }
        }

    }
}
