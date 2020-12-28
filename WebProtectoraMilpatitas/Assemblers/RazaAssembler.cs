using ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebProtectoraMilpatitas.Models;

namespace WebProtectoraMilpatitas.Assemblers
{
    public class RazaAssembler
    {
        public RazaViewModel ConvertENToModelUI(RazaEN raz)
        {
            RazaViewModel raza = new RazaViewModel();

            raza.Id = raz.Id;
            raza.Nombre = raz.Nombre;

            raza.idEspecie = raz.Especie.Id;
            raza.NomEspecie = raz.Especie.Nombre;

            return raza;
        }

        public IList<RazaViewModel> ConvertListENToModel(IList<RazaEN> razis)
        {
            IList<RazaViewModel> razas = new List<RazaViewModel>();

            foreach (RazaEN raz in razis)
            {
                razas.Add(ConvertENToModelUI(raz));
            }
            return razas;
        }
    }
}