

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
 *      Definition of the class MensajeCEN
 *
 */
public partial class MensajeCEN
{
private IMensajeCAD _IMensajeCAD;

public MensajeCEN()
{
        this._IMensajeCAD = new MensajeCAD ();
}

public MensajeCEN(IMensajeCAD _IMensajeCAD)
{
        this._IMensajeCAD = _IMensajeCAD;
}

public IMensajeCAD get_IMensajeCAD ()
{
        return this._IMensajeCAD;
}

public int Nuevo (string p_administrador, string p_usuario, string p_texto)
{
        MensajeEN mensajeEN = null;
        int oid;

        //Initialized MensajeEN
        mensajeEN = new MensajeEN ();

        if (p_administrador != null) {
                // El argumento p_administrador -> Property administrador es oid = false
                // Lista de oids id
                mensajeEN.Administrador = new ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.AdministradorEN ();
                mensajeEN.Administrador.Email = p_administrador;
        }


        if (p_usuario != null) {
                // El argumento p_usuario -> Property usuario es oid = false
                // Lista de oids id
                mensajeEN.Usuario = new ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.UsuarioEN ();
                mensajeEN.Usuario.Email = p_usuario;
        }

        mensajeEN.Texto = p_texto;

        //Call to MensajeCAD

        oid = _IMensajeCAD.Nuevo (mensajeEN);
        return oid;
}

public void Eliminar (int id
                      )
{
        _IMensajeCAD.Eliminar (id);
}

public MensajeEN Ver_Mensaje (int id
                              )
{
        MensajeEN mensajeEN = null;

        mensajeEN = _IMensajeCAD.Ver_Mensaje (id);
        return mensajeEN;
}

public System.Collections.Generic.IList<MensajeEN> Dame_Todos (int first, int size)
{
        System.Collections.Generic.IList<MensajeEN> list = null;

        list = _IMensajeCAD.Dame_Todos (first, size);
        return list;
}
}
}
