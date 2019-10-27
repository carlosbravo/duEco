using duEco.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace duEco.Servicio
{
    public class UsuarioServicio
    {
        public void Guardar(UsuarioModel usuario)
        {

        }

        public void Modificar(UsuarioModel usuario)
        {

        }

        public void Eliminar(UsuarioModel usuario)
        {

        }

        internal static bool UsuarioExiste(UsuarioModel usuarioLogin)
        {
            return UsuarioModel.BuscarByLogin(usuarioLogin);
        }

        internal static bool Registrar(string text1, string text2)
        {
            UsuarioModel nuevoUsuario = new UsuarioModel
            {
                email = text1,
                password = text2,
                nombre = ""
            };
            return UsuarioModel.CrearUsuario(nuevoUsuario, CoreServicio.Encrypt.GetMD5(nuevoUsuario.email.Substring(6)));
        }
    }
}
