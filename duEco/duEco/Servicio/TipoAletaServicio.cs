﻿using duEco.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace duEco.Servicio
{
    public class TipoAlertaServicio
    {
        internal static List<TipoAlertaModel> todosLosTiposAlerta()
        {
            return new TipoAlertaModel().obtenerTodosTiposAlerta();
        }
    }
}
