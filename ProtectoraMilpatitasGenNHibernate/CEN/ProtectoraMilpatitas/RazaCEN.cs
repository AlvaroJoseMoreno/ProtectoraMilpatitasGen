

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
 *      Definition of the class RazaCEN
 *
 */
public partial class RazaCEN
{
private IRazaCAD _IRazaCAD;

public RazaCEN()
{
        this._IRazaCAD = new RazaCAD ();
}

public RazaCEN(IRazaCAD _IRazaCAD)
{
        this._IRazaCAD = _IRazaCAD;
}

public IRazaCAD get_IRazaCAD ()
{
        return this._IRazaCAD;
}

public int Nuevo (string p_nombre, int p_especie)
{
        RazaEN razaEN = null;
        int oid;

        //Initialized RazaEN
        razaEN = new RazaEN ();
        razaEN.Nombre = p_nombre;


        if (p_especie != -1) {
                // El argumento p_especie -> Property especie es oid = false
                // Lista de oids id
                razaEN.Especie = new ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.EspecieEN ();
                razaEN.Especie.Id = p_especie;
        }

        //Call to RazaCAD

        oid = _IRazaCAD.Nuevo (razaEN);
        return oid;
}

public void Modificar (int p_Raza, string p_nombre)
{
        RazaEN razaEN = null;

        //Initialized RazaEN
        razaEN = new RazaEN ();
        razaEN.Id = p_Raza;
        razaEN.Nombre = p_nombre;
        //Call to RazaCAD

        _IRazaCAD.Modificar (razaEN);
}

public void Eliminar (int id
                      )
{
        _IRazaCAD.Eliminar (id);
}

public System.Collections.Generic.IList<RazaEN> Dame_Todas (int first, int size)
{
        System.Collections.Generic.IList<RazaEN> list = null;

        list = _IRazaCAD.Dame_Todas (first, size);
        return list;
}
public RazaEN Dame_Por_Id (int id
                           )
{
        RazaEN razaEN = null;

        razaEN = _IRazaCAD.Dame_Por_Id (id);
        return razaEN;
}

public System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.RazaEN> Dame_Raza_Por_Especie (int p_especie)
{
        return _IRazaCAD.Dame_Raza_Por_Especie (p_especie);
}
}
}
