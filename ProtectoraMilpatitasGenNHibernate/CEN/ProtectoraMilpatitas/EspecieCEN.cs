

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
 *      Definition of the class EspecieCEN
 *
 */
public partial class EspecieCEN
{
private IEspecieCAD _IEspecieCAD;

public EspecieCEN()
{
        this._IEspecieCAD = new EspecieCAD ();
}

public EspecieCEN(IEspecieCAD _IEspecieCAD)
{
        this._IEspecieCAD = _IEspecieCAD;
}

public IEspecieCAD get_IEspecieCAD ()
{
        return this._IEspecieCAD;
}

public int Nuevo (string p_nombre)
{
        EspecieEN especieEN = null;
        int oid;

        //Initialized EspecieEN
        especieEN = new EspecieEN ();
        especieEN.Nombre = p_nombre;

        //Call to EspecieCAD

        oid = _IEspecieCAD.Nuevo (especieEN);
        return oid;
}

public void Modificar (int p_Especie_OID, string p_nombre)
{
        EspecieEN especieEN = null;

        //Initialized EspecieEN
        especieEN = new EspecieEN ();
        especieEN.Id = p_Especie_OID;
        especieEN.Nombre = p_nombre;
        //Call to EspecieCAD

        _IEspecieCAD.Modificar (especieEN);
}

public void Eliminar (int id
                      )
{
        _IEspecieCAD.Eliminar (id);
}

public System.Collections.Generic.IList<EspecieEN> Dame_Todas (int first, int size)
{
        System.Collections.Generic.IList<EspecieEN> list = null;

        list = _IEspecieCAD.Dame_Todas (first, size);
        return list;
}
public EspecieEN Dame_Por_Id (int id
                              )
{
        EspecieEN especieEN = null;

        especieEN = _IEspecieCAD.Dame_Por_Id (id);
        return especieEN;
}
}
}
