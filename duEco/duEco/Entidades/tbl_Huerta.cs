using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace duEco.Entidades
{
    public class tbl_Huerta
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        // Atributos coincidentes con los Modelos de Carpeta -> Model
        [MaxLength(36)]
        public char Hue_Id { get; set; }

        [MaxLength(200)]
        public String Hue_Nombre { get; set; }

        [MaxLength(500)]
        public String Hue_Descripcion { get; set; }

        [MaxLength(36)]
        public char Hue_Usu_Id { get; set; }
        public char Hue_Baja { get; set; }
         
    }
}
