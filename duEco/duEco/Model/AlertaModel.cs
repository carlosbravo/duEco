using Plugin.LocalNotifications;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace duEco.Model
{
    public class AlertaModel
    {
        private int id;        
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        
        private String huertaId;
        [MaxLength(36)]
        public String HuertaID
        {
            get { return huertaId; }
            set { huertaId = value; }
        }

        private string descripcion;
        [MaxLength(300)]
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        private DateTime fechaHora;
        public DateTime FechaHora
        {
            get { return fechaHora; }
            set { fechaHora = value; }
        }

        public String avisa;
        [MaxLength(1)]
        public String Avisa
        {
            get { return avisa; }
            set { avisa = value; }
        }

        public String tipoAlertaId;
        [MaxLength(36)]
        public String TipoAlertaID
        {
            get { return tipoAlertaId; }
            set { tipoAlertaId = value; }
        }

        public String baja;
        [MaxLength(1)]
        public String Baja
        {
            get { return baja; }
            set { baja = value; }
        }

        //-------------------------------------------------------------        

        #region SQLite
        private static string _dbName;
        private static string _path;
        private static SQLiteConnection _db;

        public AlertaModel()
        {
            _dbName = "duEcoSQLite.db3";
            _path = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.Personal), _dbName);
            _db = new SQLiteConnection(_path);
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public bool CrearAlerta(int idIncremental, String idHuerta, String descripcion, DateTime fechaHora, String avisa, String idTipoAlerta)
        {
            try
            {
                var nuevaAlerta = new Entidades.tbl_Alerta
                {
                    Ale_Id = idIncremental,
                    Ale_Hue_Id = idHuerta,
                    Ale_Descripcion = descripcion,
                    Ale_Fecha_Hora = fechaHora,
                    Ale_Avisa = avisa,
                    Ale_TAl_Id = idTipoAlerta,
                    Ale_Baja = "N"                    
                };
                _db.Insert(nuevaAlerta);

                if(avisa == "S")
                    CrossLocalNotifications.Current.Show("duEco", descripcion, idIncremental, fechaHora);

                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public int getUltimoIdAlerta()
        {
            try
            {
                var ultimaAlerta = _db.Table<Entidades.tbl_Alerta>().OrderByDescending(item => item.Ale_Id).FirstOrDefault();                
                int ultID;

                if (ultimaAlerta != null)
                    ultID = ultimaAlerta.Ale_Id++;
                else
                    ultID = 0;

                return ultID;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }            
        }    
            #endregion
    }
}
