using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas;
using WebProtectoraMilpatitas.Models;

namespace WebProtectoraMilpatitas.Assemblers
{
    public class EspecieAssembler
    {
        public EspecieViewModel ConvertENToModelUI(EspecieEN esp)
        {
            EspecieViewModel especie = new EspecieViewModel();
            especie.Id = esp.Id;
            especie.Nombre = esp.Nombre;

            return especie;
        }

        public IList<EspecieViewModel> ConvertListENToModel(IList<EspecieEN> esps)
        {
            IList<EspecieViewModel> especies = new List<EspecieViewModel>();

            foreach (EspecieEN esp in esps)
            {
                especies.Add(ConvertENToModelUI(esp));
            }
            return especies;
        }
    }
}