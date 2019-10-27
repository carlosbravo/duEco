using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace duEco.Entidades
{
    public class tbl_Etapa
    {
        /// <summary>
        ///  id interno para sqlite
        /// </summary>
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        // Atributos coincidentes con los Modelos de Carpeta -> Model
        [MaxLength(36)]
        public char Tar_Id { get; set; }

        public int Tar_Eta_Id { get; set; }

        [MaxLength(300)]
        public String Tar_Descripcion { get; set; }

        public char Tar_Baja { get; set; }
    }
}
