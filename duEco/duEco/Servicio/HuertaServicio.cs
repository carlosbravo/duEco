using duEco.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace duEco.Servicio
{
    public class HuertaServicio
    {
        internal static List<HuertaModel> TodasLasHuertas(string userId)
        {
            var objHuerta = new HuertaModel();
            var objUsuario = new UsuarioModel();

            var idUser = objUsuario.ConsultarPorLog(userId);
            return objHuerta.ConsultarTodos(idUser);
        }

        internal static HuertaModel BuscarPorId(string huertaID)
        {
            return new HuertaModel().ConsultarPorId(huertaID);
        }

        internal static bool CrearHuerta(string text1, string text2, string userLog)
        {
            var objUsuario = new UsuarioModel();

            var idUser = objUsuario.ConsultarPorLog(userLog);
            return new HuertaModel().CrearHuerta(text1, text2, idUser, CoreServicio.Encrypt.GetMD5(text1.Substring(2)));
                         
        }
    }
}
