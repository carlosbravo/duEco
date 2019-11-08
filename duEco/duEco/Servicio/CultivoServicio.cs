using duEco.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace duEco.Servicio
{
    public class CultivoServicio
    {
        internal static CultivoModel BuscarPorId(string cultivoID)
        {
            return new CultivoModel().ConsultarPorId(cultivoID);
        }
    }
}
