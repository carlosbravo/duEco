using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using SQLite;
using System.Security.Cryptography;

namespace duEco.Servicio
{
    public class CoreServicio
    {
        internal static void ValidarTablasCreadas()
        {
            string dbName = "duEcoSQLite.db3";
            string path = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.Personal), dbName);
            var db = new SQLiteConnection(path);

            try
            {
                var existTable = db.GetTableInfo("tbl_Usuario"); //db.Query<Entidades.tbl_Usuario>("SELECT count(*) FROM sqlite_master WHERE type = 'Table' AND name = 'tbl_Usuario' ");

                if (existTable.Count == 0)
                {
                    db.CreateTable<Entidades.tbl_Usuario>();
                }

                var existPlanta = db.GetTableInfo("tbl_Planta"); //db.Query<Entidades.tbl_Usuario>("SELECT count(*) FROM sqlite_master WHERE type = 'Table' AND name = 'tbl_Planta' ");
                if (existPlanta.Count == 0)
                {
                    db.CreateTable<Entidades.tbl_Planta>();
                    if (db.Table<Entidades.tbl_Planta>().Count() == 0)
                    {
                        // only insert the data if it doesn't already exist
                        var newPlanta = new Entidades.tbl_Planta();
                        newPlanta.Pla_Id = "855C32D15C64E751238C1C80A4C782D9";
                        newPlanta.Pla_Nombre = "Boldo";
                        newPlanta.Pla_TPl_Id = "6f70a13783bf4860bf790627ce995767"; //Hoja 
                        db.Insert(newPlanta);

                        newPlanta.Pla_Id = "354CA05DDADF41E3FD143AC891E5D712";
                        newPlanta.Pla_Nombre = "Cebolla";
                        newPlanta.Pla_TPl_Id = "6c43e855c46aef9f07e0ced4ade1e8b6"; //Bulbo 
                        db.Insert(newPlanta);

                        newPlanta.Pla_Id = "4FA83FDC0117F4C2E5C321ED8810AB70";
                        newPlanta.Pla_Nombre = "Espinaca";
                        newPlanta.Pla_TPl_Id = "6f70a13783bf4860bf790627ce995767"; //Hoja 
                        db.Insert(newPlanta);

                        newPlanta.Pla_Id = "D3C1A05C5108A6B07F1864CC92003A4C";
                        newPlanta.Pla_Nombre = "Menta";
                        newPlanta.Pla_TPl_Id = "6f70a13783bf4860bf790627ce995767"; //Hoja 
                        db.Insert(newPlanta);

                        newPlanta.Pla_Id = "09440664B265A68564200AC25EB8E069";
                        newPlanta.Pla_Nombre = "Jengibre";
                        newPlanta.Pla_TPl_Id = "533b54b7ff9fe7b19bfd965ad37f12e4"; //Rizoma 
                        db.Insert(newPlanta);

                        newPlanta.Pla_Id = "29B0718BB38C0D427134B9B28EEE56FA";
                        newPlanta.Pla_Nombre = "Zapallo";
                        newPlanta.Pla_TPl_Id = "f9e012ff0bbbf0c385910af0795786c9"; //Fruto 
                        db.Insert(newPlanta);
                        var table = db.Table<Entidades.tbl_Planta>();

                        // correcciones 2da insercion
                        //db.Query<Entidades.tbl_Planta>("UPDATE tbl_Planta SET Pla_TPl_Id = ? WHERE Pla_Id = ?", "a25f21d368d34ff8bc64d0ec8396f3cd", "855C32D15C64E751238C1C80A4C782D9");
                        //db.Query<Entidades.tbl_Planta>("UPDATE tbl_Planta SET Pla_TPl_Id = ? WHERE Pla_Id = ?", "533b54b7ff9fe7b19bfd965ad37f12e4", "09440664B265A68564200AC25EB8E069");
                        //db.Query<Entidades.tbl_Planta>("UPDATE tbl_Planta SET Pla_TPl_Id = ? WHERE Pla_Id = ?", "f9e012ff0bbbf0c385910af0795786c9", "29B0718BB38C0D427134B9B28EEE56FA");
                        //db.Query<Entidades.tbl_Planta>("UPDATE tbl_Planta SET Pla_Nombre = ? WHERE Pla_Id = ?", "Zapallo", "29B0718BB38C0D427134B9B28EEE56FA");
                        //var tableC = db.Table<Entidades.tbl_Planta>();
                    }
                }

                var existTipoPlanta = db.GetTableInfo("tbl_TipoPlanta"); //db.Query<Entidades.tbl_Usuario>("SELECT count(*) FROM sqlite_master WHERE type = 'Table' AND name = 'tbl_Planta' ");
                if (existTipoPlanta.Count == 0)
                {
                    db.CreateTable<Entidades.tbl_TipoPlanta>();
                    var newTipoPlanta = new Entidades.tbl_TipoPlanta();
                    newTipoPlanta.TPl_Id = "6f70a13783bf4860bf790627ce995767";
                    newTipoPlanta.TPl_Nombre = "Hoja";  
                    newTipoPlanta.TPl_Cat_Id = "48846075a34c2cf241c9c9300ae921f3";      //Hortaliza
                    db.Insert(newTipoPlanta);

                    newTipoPlanta.TPl_Id = "6c43e855c46aef9f07e0ced4ade1e8b6";
                    newTipoPlanta.TPl_Nombre = "Bulbo";
                    newTipoPlanta.TPl_Cat_Id = "48846075a34c2cf241c9c9300ae921f3";      //Hortaliza
                    db.Insert(newTipoPlanta);

                    newTipoPlanta.TPl_Id = "533b54b7ff9fe7b19bfd965ad37f12e4";
                    newTipoPlanta.TPl_Nombre = "Rizoma";
                    newTipoPlanta.TPl_Cat_Id = "a4fdh2d512gs3gee31h25tfea2s3ee3";      //Aromatica
                    db.Insert(newTipoPlanta);

                    newTipoPlanta.TPl_Id = "f9e012ff0bbbf0c385910af0795786c9";
                    newTipoPlanta.TPl_Nombre = "Fruto";
                    newTipoPlanta.TPl_Cat_Id = "48846075a34c2cf241c9c9300ae921f3";      //Hortaliza
                    db.Insert(newTipoPlanta);


                }
                var tableTP = db.Table<Entidades.tbl_TipoPlanta>().ToList();

                var existCategoria = db.GetTableInfo("tbl_Categoria"); //db.Query<Entidades.tbl_Usuario>("SELECT count(*) FROM sqlite_master WHERE type = 'Table' AND name = 'tbl_Planta' ");
                if (existCategoria.Count == 0)
                {
                    db.CreateTable<Entidades.tbl_Categoria>();
                    var newCategoria = new Entidades.tbl_Categoria();
                    newCategoria.Cat_Id = "48846075a34c2cf241c9c9300ae921f3";
                    newCategoria.Cat_Nombre = "Hortaliza";
                    db.Insert(newCategoria);

                    newCategoria.Cat_Id = "a4fdh2d512gs3gee31h25tfea2s3ee3";
                    newCategoria.Cat_Nombre = "Aromatica";
                    db.Insert(newCategoria);

                    newCategoria.Cat_Id = "6e51043bf9a7fb8f70092ce86474bcf7";
                    newCategoria.Cat_Nombre = "Arbusto";
                    db.Insert(newCategoria);

                    var tableC = db.Table<Entidades.tbl_Categoria>();
                }

            }
            catch (Exception c)
            {
                throw c;
            }
        }

        public static class Encrypt
        {
            public static string GetMD5(string str)
            {
                MD5 md5 = MD5CryptoServiceProvider.Create();
                ASCIIEncoding encoding = new ASCIIEncoding();
                byte[] stream = null;
                StringBuilder sb = new StringBuilder();
                stream = md5.ComputeHash(encoding.GetBytes(str));
                for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
                return sb.ToString();
            }
        }
    }
}
