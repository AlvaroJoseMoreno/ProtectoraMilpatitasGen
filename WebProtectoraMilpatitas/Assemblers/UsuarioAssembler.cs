using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas;
using WebProtectoraMilpatitas.Models;

namespace WebProtectoraMilpatitas.Assemblers
{
    public class UsuarioAssembler
    {
        public UsuarioViewModel ConvertENToModelUI(UsuarioEN usu)
        {
            UsuarioViewModel usuario = new UsuarioViewModel();

            usuario.Nombre = usu.Nombre;
            usuario.Email = usu.Email;
            usuario.Password = usu.Password;
            usuario.Foto = usu.Foto;

            return usuario;
        }

        public IList<UsuarioViewModel> ConvertListENToModel(IList<UsuarioEN> usus)
        {
            IList<UsuarioViewModel> usuarios = new List<UsuarioViewModel>();

            foreach (UsuarioEN usu in usus)
            {
                usuarios.Add(ConvertENToModelUI(usu));
            }
            return usuarios;
        }
    }
}