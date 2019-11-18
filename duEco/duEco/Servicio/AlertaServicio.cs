using duEco.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace duEco.Servicio
{
    public class AlertaServicio
    {
        internal static bool CrearAlerta(String idHuerta, String descripcion, DateTime fechaAlerta, bool avisa, String idTipoAlerta)
        {
            AlertaModel objAlerta = new AlertaModel();
            int ultIdAlerta = objAlerta.getUltimoIdAlerta();

            String strAvisa = avisa ? "S" : "N";

            return objAlerta.CrearAlerta(ultIdAlerta, idHuerta, descripcion, fechaAlerta, strAvisa, idTipoAlerta);

        }
    }
}
