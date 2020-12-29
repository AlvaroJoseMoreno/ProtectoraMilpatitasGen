using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas;
using WebProtectoraMilpatitas.Models;

namespace WebProtectoraMilpatitas.Assemblers
{
    public class SeguimientoAssembler
    {
        public SeguimientoViewModel ConvertENToModelUI(SeguimientoEN segui)
        {
            SeguimientoViewModel seguimiento = new SeguimientoViewModel();
            seguimiento.Id = segui.Id;
            seguimiento.Estado = segui.Estado;
            seguimiento.Fecha = segui.Fecha;

            seguimiento.idUsuario = segui.Usuario.Email;
            seguimiento.NomUsuario = segui.Usuario.Nombre;
            seguimiento.FotoUsuario = segui.Usuario.Foto;

            seguimiento.idAnimal = segui.Animal.Id;
            seguimiento.NomAnimal = segui.Animal.Nombre;
            seguimiento.FotoAnimal = segui.Animal.Foto;

            return seguimiento;
        }

        public IList<SeguimientoViewModel> ConvertListENToModel(IList<SeguimientoEN> seg)
        {
            IList<SeguimientoViewModel> seguimientos = new List<SeguimientoViewModel>();

            foreach (SeguimientoEN s in seg)
            {
                seguimientos.Add(ConvertENToModelUI(s));
            }
            return seguimientos;
        }

    }
}