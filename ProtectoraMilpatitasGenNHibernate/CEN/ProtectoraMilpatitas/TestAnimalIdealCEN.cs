

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
}
}
