using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace duEco.Model
{
    public class CultivoModel : PlantaModel
    {
        #region Propiedades
        private string idCultivo;

        public string IdCultivo
        {
            get { return idCultivo; }
            set { idCultivo = value; }
        }

        private string nombreCultivo;

        public string NombreCultivo
        {
            get { return nombreCultivo; }
            set { nombreCultivo = value; }
        }

        private DateTime iniciaCultivo;

        public DateTime IniciaCultivo
        {
            get { return iniciaCultivo; }
            set { iniciaCultivo = value; }
        }

        private DateTime finSiembra;

        public DateTime FinSiembra
        {
            get { return finSiembra; }
            set { finSiembra = value; }
        }

        private DateTime finCosecha;

        public DateTime FinCosecha
        {
            get { return finCosecha; }
            set { finCosecha = value; }
        }

        #endregion
        #region SQLite
        private static string _dbName;
        private static string _path;
        private static SQLiteConnection _db;

        public CultivoModel()
        {
            _dbName = "duEcoSQLite.db3";
            _path = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.Personal), _dbName);
            _db = new SQLiteConnection(_path);
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public bool CrearCultivo(CultivoModel Cultivo, string Id, string huertaId)
        {
            try
            {
                var nuevaCultivo = new Entidades.tbl_Cultivo
                {
                    Cul_Id = idCultivo,
                    Cul_Nombre = Cultivo.nombre,
                    Cul_Pla_Id = Cultivo.id,
                    Cul_Hue_Id = huertaId,
                    Cul_FinSiembra = Cultivo.finSiembra,
                    Cul_IniciaCultivo = Cultivo.iniciaCultivo,
                    Cul_FinCosecha = Cultivo.finCosecha,
                    Cul_Baja = "N"
                };
                _db.Insert(Cultivo);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// TESTEAR QUE ACTUALICE EL OBJETO CORRESPONDIENTE
        /// </summary>
        /// <param name="Cultivo"></param>
        /// <returns></returns>
        public bool ActualizarCultivo(CultivoModel Cultivo)
        {
            try
            {
                var updCultivo = new Entidades.tbl_Cultivo
                {
                    Cul_Id = Cultivo.idCultivo,
                    Cul_Nombre = Cultivo.nombre,
                    Cul_IniciaCultivo = Cultivo.iniciaCultivo,
                    Cul_FinSiembra = Cultivo.finSiembra,
                    Cul_FinCosecha = Cultivo.finCosecha
                };
                _db.Update(updCultivo);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Eliminar(string CultivoID)
        {
            try
            {
                _db.Query<Entidades.tbl_Cultivo>("UPDATE tbl_Cultivo SET Hue_Baja = ? WHERE Hue_Id = ?", "S", CultivoID);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public CultivoModel ConsultarPorId(String CultivoID)
        {
            try
            {
                var qCultivo = _db.Table<Entidades.tbl_Cultivo>()
                            .Where(t => t.Cul_Id == CultivoID)
                            .FirstOrDefault();

                var qPlanta = _db.Table<Entidades.tbl_Planta>()
                            .Where(p => p.Pla_Id == qCultivo.Cul_Pla_Id)
                            .FirstOrDefault();

                if (qCultivo != null && qPlanta != null)
                {
                    return new CultivoModel
                    {
                        idCultivo = qCultivo.Cul_Id,
                        id = qPlanta.Pla_Id,
                        nombreCultivo = qCultivo.Cul_Nombre,
                        nombre = qPlanta.Pla_Nombre,
                        descripcion = qPlanta.Pla_Descripcion,
                        tipoSiembra = qPlanta.Pla_TipoSiembra,                        
                        dificultad = qPlanta.Pla_Dificultad,
                        finSiembra = qCultivo.Cul_FinSiembra,
                        iniciaCultivo = qCultivo.Cul_IniciaCultivo,
                        finCosecha = qCultivo.Cul_FinCosecha
                    };
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<CultivoModel> ConsultarTodos(string huertaID)
        {
            try
            {
                var lst = _db.Table<Entidades.tbl_Cultivo>()
                    .Where(h => h.Cul_Baja == "N" && h.Cul_Hue_Id == huertaID)
                    .ToList();

                List<CultivoModel> todasLasCultivos = new List<CultivoModel>();
                if (lst.Count > 0)
                {
                    foreach (Entidades.tbl_Cultivo item in lst)
                    {
                        CultivoModel nCultivo = ConsultarPorId(item.Cul_Id);

                        todasLasCultivos.Add(nCultivo);
                    }
                }

                return todasLasCultivos;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
