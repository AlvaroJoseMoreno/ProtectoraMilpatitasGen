

using System;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using ProtectoraMilpatitasGenNHibernate.Exceptions;

using ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas;
using ProtectoraMilpatitasGenNHibernate.CAD.ProtectoraMilpatitas;


namespace ProtectoraMilpatitasGenNHibernate.CEN.ProtectoraMilpatitas
{
/*
 *      Definition of the class TestAnimalIdealCEN
 *
 */
public partial class TestAnimalIdealCEN
{
private ITestAnimalIdealCAD _ITestAnimalIdealCAD;

public TestAnimalIdealCEN()
{
        this._ITestAnimalIdealCAD = new TestAnimalIdealCAD ();
}

public TestAnimalIdealCEN(ITestAnimalIdealCAD _ITestAnimalIdealCAD)
{
        this._ITestAnimalIdealCAD = _ITestAnimalIdealCAD;
}

public ITestAnimalIdealCAD get_ITestAnimalIdealCAD ()
{
        return this._ITestAnimalIdealCAD;
}

public void Eliminar (int id
                      )
{
        _ITestAnimalIdealCAD.Eliminar (id);
}

public TestAnimalIdealEN Ver_Resultado (int id
                                        )
{
        TestAnimalIdealEN testAnimalIdealEN = null;

        testAnimalIdealEN = _ITestAnimalIdealCAD.Ver_Resultado (id);
        return testAnimalIdealEN;
}

public System.Collections.Generic.IList<TestAnimalIdealEN> Dame_Todos (int first, int size)
{
        System.Collections.Generic.IList<TestAnimalIdealEN> list = null;

        list = _ITestAnimalIdealCAD.Dame_Todos (first, size);
        return list;
}
public int Nuevo (string p_aficionFavorita, string p_personalidad, string p_colorFavorito, string p_usuario)
{
        TestAnimalIdealEN testAnimalIdealEN = null;
        int oid;

        //Initialized TestAnimalIdealEN
        testAnimalIdealEN = new TestAnimalIdealEN ();
        testAnimalIdealEN.AficionFavorita = p_aficionFavorita;

        testAnimalIdealEN.Personalidad = p_personalidad;

        testAnimalIdealEN.ColorFavorito = p_colorFavorito;


        if (p_usuario != null) {
                // El argumento p_usuario -> Property usuario es oid = false
                // Lista de oids id
                testAnimalIdealEN.Usuario = new ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.UsuarioEN ();
                testAnimalIdealEN.Usuario.Email = p_usuario;
        }

        //Call to TestAnimalIdealCAD

        oid = _ITestAnimalIdealCAD.Nuevo (testAnimalIdealEN);
        return oid;
}
}
}
