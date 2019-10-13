using System;
using System.Collections.Generic;
using System.Text;

namespace duEco.Model
{
    public class PlantaModel
    {
        private string Id;

        public string id
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

        private string ImagenPortada;

        public string imagenPortada
        {
            get { return ImagenPortada; }
            set { ImagenPortada = value; }
        }

    }
}
