using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace duEco.Entidades
{
    public class tbl_TipoAlerta
    {
        /// <summary>
        ///  id interno para sqlite
        /// </summary>
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        // Atributos coincidentes con los Modelos de Carpeta -> Model
        [MaxLength(36)]
        public char TAl_Id { get; set; }

        [MaxLength(200)]
        public String TAl_Descripcion { get; set; }

        public char TAl_Baja { get; set; }
    }
}
