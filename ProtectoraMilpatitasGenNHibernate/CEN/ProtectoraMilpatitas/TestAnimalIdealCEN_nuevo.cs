
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


/*PROTECTED REGION ID(usingProtectoraMilpatitasGenNHibernate.CEN.ProtectoraMilpatitas_TestAnimalIdeal_nuevo) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ProtectoraMilpatitasGenNHibernate.CEN.ProtectoraMilpatitas
{
public partial class TestAnimalIdealCEN
{
public int Nuevo (string p_usuario)
{
        /*PROTECTED REGION ID(ProtectoraMilpatitasGenNHibernate.CEN.ProtectoraMilpatitas_TestAnimalIdeal_nuevo_customized) START*/

        TestAnimalIdealEN testAnimalIdealEN = null;

        int oid;

        //Initialized TestAnimalIdealEN
        testAnimalIdealEN = new TestAnimalIdealEN ();

        if (p_usuario != null) {
                testAnimalIdealEN.Usuario = new ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.UsuarioEN ();
                testAnimalIdealEN.Usuario.Email = p_usuario;
        }

        //Call to TestAnimalIdealCAD

        oid = _ITestAnimalIdealCAD.Nuevo (testAnimalIdealEN);
        return oid;
        /*PROTECTED REGION END*/
}
}
}
