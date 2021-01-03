using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas;
using WebProtectoraMilpatitas.Models;

namespace WebProtectoraMilpatitas.Assemblers
{
    public class TestAnimalIdealAssembler
    {
        public TestAnimalIdealViewModel ConvertENToModelUI(TestAnimalIdealEN test)
        {
            TestAnimalIdealViewModel testi = new TestAnimalIdealViewModel();

            testi.Id = test.Id;
            testi.AficionFavorita = test.AficionFavorita;
            testi.Personalidad = test.Personalidad;
            testi.ColorFavorito = test.ColorFavorito;

            testi.idUsuario = test.Usuario.Email;

            testi.Resultado = test.Resultado;

            return testi;
        }

        public IList<TestAnimalIdealViewModel> ConvertListENToModel(IList<TestAnimalIdealEN> testis)
        {
            IList<TestAnimalIdealViewModel> tests = new List<TestAnimalIdealViewModel>();

            foreach (TestAnimalIdealEN test in testis)
            {
                tests.Add(ConvertENToModelUI(test));
            }

            return tests;
        }
    }
}