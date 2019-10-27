using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
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

        #region SQLite
        private static string _dbName;
        private static string _path;
        private static SQLiteConnection _db;


        internal static List<PlantaModel> obtenerTodas()
        {
            // Acceso y conexion a la BD
            _dbName = "duEcoSQLite.db3";
            _path = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.Personal), _dbName);
            _db = new SQLiteConnection(_path);

            var query = _db.Table<Entidades.tbl_Planta>()
                            .ToList();

            List<PlantaModel> todasLasPlantas = new List<PlantaModel>();
            if (query.Count > 0)
            {
                string urlImg = "~/Imagenes/iso_v7.PNG";
                foreach (Entidades.tbl_Planta item in query)
                {
                    PlantaModel nPlanta = new PlantaModel();
                    nPlanta.id = item.Pla_Id;
                    nPlanta.nombre = item.Pla_Nombre;
                    nPlanta.imagenPortada = urlImg;

                    todasLasPlantas.Add(nPlanta);
                }
            }

            return todasLasPlantas;
        }
        #endregion
    }
}
