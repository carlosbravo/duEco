using duEco.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace duEco.Servicio
{
    public class PlantaServicio
    {
        internal static List<PlantaModel> todasLasPlantas()
        {
            /// reemplazar por llamada PlantaModel.todoPlanta() consultando BD
            //List<Model.PlantaModel> plantas = new List<Model.PlantaModel>();

            //Model.PlantaModel plantaTest = new Model.PlantaModel
            //{
            //    id = "dfe1f51fe651fef1",
            //    nombre = "Menta",
            //    imagenPortada = ""
            //};
            //plantas.Add(plantaTest);

            //Model.PlantaModel plantaTest2 = new Model.PlantaModel
            //{
            //    id = "e8fe1f5frfe322ff",
            //    nombre = "Tomate",
            //    imagenPortada = ""
            //};

            //plantas.Add(plantaTest2);
            //return plantas;
            return PlantaModel.obtenerTodas();
        }

        internal static PlantaModel buscarPorId(string v)
        {
            return new PlantaModel
            {
                id = v,
                nombre="Menta",
                imagenPortada=""
            };
        }
    }
}
