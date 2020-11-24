
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
       
        if(p_aficionFavorita != null && p_personalidad != null 
        && p_colorFavorito != null && p_aficionFavorita != testAnimalIdealEN.AficionFavorita
        && p_personalidad != testAnimalIdealEN.Personalidad && p_colorFavorito != testAnimalIdealEN.ColorFavorito)
        {
        
        testAnimalIdealEN.AficionFavorita = p_aficionFavorita;
        testAnimalIdealEN.Personalidad = p_personalidad;
        testAnimalIdealEN.ColorFavorito = p_colorFavorito;
        //Call to TestAnimalIdealCAD
       
       
        }else{
            throw new ModelException("error al completar test");
            }

         _ITestAnimalIdealCAD.Rellenar_Test (testAnimalIdealEN);
        /*PROTECTED REGION END*/

}
}
}
