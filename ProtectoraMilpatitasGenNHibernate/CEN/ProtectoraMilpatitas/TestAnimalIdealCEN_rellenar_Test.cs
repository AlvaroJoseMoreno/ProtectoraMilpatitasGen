
using System;
using System.Text;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using ProtectoraMilpatitasGenNHibernate.Exceptions;
using ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas;
using ProtectoraMilpatitasGenNHibernate.CAD.ProtectoraMilpatitas;


/*PROTECTED REGION ID(usingProtectoraMilpatitasGenNHibernate.CEN.ProtectoraMilpatitas_TestAnimalIdeal_rellenar_Test) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ProtectoraMilpatitasGenNHibernate.CEN.ProtectoraMilpatitas
{
public partial class TestAnimalIdealCEN
{
public void Rellenar_Test (int p_TestAnimalIdeal, string p_aficionFavorita, string p_personalidad, string p_colorFavorito)
{
        /*PROTECTED REGION ID(ProtectoraMilpatitasGenNHibernate.CEN.ProtectoraMilpatitas_TestAnimalIdeal_rellenar_Test_customized) START*/

        TestAnimalIdealEN testAnimalIdealEN = null;

        //Initialized TestAnimalIdealEN
        testAnimalIdealEN = new TestAnimalIdealEN ();
        testAnimalIdealEN.Id = p_TestAnimalIdeal;
        testAnimalIdealEN.AficionFavorita = p_aficionFavorita;
        testAnimalIdealEN.Personalidad = p_personalidad;
        testAnimalIdealEN.ColorFavorito = p_colorFavorito;

            testAnimalIdealEN.Resultado = "Perro";
        //Call to TestAnimalIdealCAD

        _ITestAnimalIdealCAD.Rellenar_Test (testAnimalIdealEN);

        /*PROTECTED REGION END*/
}
}
}
