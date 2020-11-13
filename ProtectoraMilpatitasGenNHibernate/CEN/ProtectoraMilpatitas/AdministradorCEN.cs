

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
 *      Definition of the class AdministradorCEN
 *
 */
public partial class AdministradorCEN
{
private IAdministradorCAD _IAdministradorCAD;

public AdministradorCEN()
{
        this._IAdministradorCAD = new AdministradorCAD ();
}

public AdministradorCEN(IAdministradorCAD _IAdministradorCAD)
{
        this._IAdministradorCAD = _IAdministradorCAD;
}

public IAdministradorCAD get_IAdministradorCAD ()
{
        return this._IAdministradorCAD;
}

public string Registrarse (string p_nombre, string p_email, String p_password)
{
        AdministradorEN administradorEN = null;
        string oid;

        //Initialized AdministradorEN
        administradorEN = new AdministradorEN ();
        administradorEN.Nombre = p_nombre;

        administradorEN.Email = p_email;

        administradorEN.Password = Utils.Util.GetEncondeMD5 (p_password);

        //Call to AdministradorCAD

        oid = _IAdministradorCAD.Registrarse (administradorEN);
        return oid;
}

public void Modificar (string p_Administrador_OID, string p_nombre, String p_password)
{
        AdministradorEN administradorEN = null;

        //Initialized AdministradorEN
        administradorEN = new AdministradorEN ();
        administradorEN.Email = p_Administrador_OID;
        administradorEN.Nombre = p_nombre;
        administradorEN.Password = Utils.Util.GetEncondeMD5 (p_password);
        //Call to AdministradorCAD

        _IAdministradorCAD.Modificar (administradorEN);
}

public void Eliminar (string email
                      )
{
        _IAdministradorCAD.Eliminar (email);
}

        public System.Collections.Generic.IList<AdministradorEN> Dame_Todos (int first, int size)
{
        System.Collections.Generic.IList<AdministradorEN> list = null;

        list = _IAdministradorCAD.Dame_Todos (first, size);
        return list;
}
public AdministradorEN Dame_Por_Id (string email
                                    )
{
        AdministradorEN administradorEN = null;

        administradorEN = _IAdministradorCAD.Dame_Por_Id (email);
        return administradorEN;
}
}
}
