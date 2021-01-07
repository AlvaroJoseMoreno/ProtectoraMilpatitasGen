using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas;
using WebProtectoraMilpatitas.Models;

namespace WebProtectoraMilpatitas.Assemblers
{
    public class MensajeAssembler
    {

        public MensajeViewModel ConvertENToModelUI(MensajeEN men)
        {
            MensajeViewModel mensaje = new MensajeViewModel();
            mensaje.Id = men.Id;
            mensaje.Texto = men.Texto;
            if (men.Usuario != null)
            {
                mensaje.Usuario = men.Usuario.Email;
            }
            if(men.Administrador!= null)
            {
                mensaje.Administrador = men.Administrador.Email;
            }

            return mensaje;
        }

        public IList<MensajeViewModel> ConvertListENToModel(IList<MensajeEN> men)
        {
            IList<MensajeViewModel> mensaje = new List<MensajeViewModel>();

            foreach (MensajeEN m in men)
            {
                mensaje.Add(ConvertENToModelUI(m));
            }
            return mensaje;
        }
    }
}