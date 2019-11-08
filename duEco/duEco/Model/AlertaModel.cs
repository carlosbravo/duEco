using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace duEco.Model
{
    public class AlertaModel
    {
        private int Id;
        public int id
        {
            get { return Id; }
            set { Id = value; }
        }
        
        private char HuertaID;
        [MaxLength(36)]
        public char huertaID
        {
            get { return HuertaID; }
            set { HuertaID = value; }
        }

        private string Descripcion;
        public string descripcion
        {
            get { return Descripcion; }
            set { Descripcion = value; }
        }

        private DateTime FechaHora;
        public DateTime fechaHora
        {
            get { return FechaHora; }
            set { FechaHora = value; }
        }

        public char Avisa;
        public char avisa
        {
            get { return Avisa; }
            set { Avisa = value; }
        }

        public int TipoAlertaID;
        public int tipoalertaID
        {
            get { return TipoAlertaID; }
            set { TipoAlertaID = value; }
        }

        public char Baja;
        public char baja
        {
            get { return Baja; }
            set { Baja = value; }
        }

        //-------------------------------------------------------------        

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
                string urlImg = "iso_v7.PNG";
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

        internal static PlantaModel buscarPorId(string v)
        {
            // Acceso y conexion a la BD
            _dbName = "duEcoSQLite.db3";
            _path = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.Personal), _dbName);
            _db = new SQLiteConnection(_path);

            var query = _db.Table<Entidades.tbl_Planta>()
                            .Where(t => t.Pla_Id == v)
                            .FirstOrDefault();

            //IEnumerable<Entidades.tbl_Usuario> resultado = SELECT_WHERE(_db, usuarioLogin);
            if (query != null)
            {
                return new PlantaModel { id = query.Pla_Id, nombre = query.Pla_Nombre, imagenPortada = "" };
            }
            else
            {
                return null;
            }
        }

        internal static List<CategoriaModel> todasLasCategorias()
        {
            // Acceso y conexion a la BD
            _dbName = "duEcoSQLite.db3";
            _path = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.Personal), _dbName);
            _db = new SQLiteConnection(_path);

            var query = _db.Table<Entidades.tbl_Categoria>()
                            .ToList();

            List<CategoriaModel> todasLasCategorias = new List<CategoriaModel>();
            if (query.Count > 0)
            {
                foreach (Entidades.tbl_Categoria item in query)
                {
                    CategoriaModel nCategoria = new CategoriaModel();
                    nCategoria.id = item.Cat_Id;
                    nCategoria.nombre = item.Cat_Nombre;

                    todasLasCategorias.Add(nCategoria);
                }
            }

            return todasLasCategorias;
        }
        #endregion
    }
}
