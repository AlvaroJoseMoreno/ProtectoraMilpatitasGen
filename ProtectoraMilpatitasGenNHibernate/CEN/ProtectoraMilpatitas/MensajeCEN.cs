

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
public void AsignarUsuario (int p_Mensaje_OID, string p_usuario_OID)
{
        //Call to MensajeCAD

        _IMensajeCAD.AsignarUsuario (p_Mensaje_OID, p_usuario_OID);
}
public void AsignarAdministrador (int p_Mensaje_OID, string p_administrador_OID)
{
        //Call to MensajeCAD

        _IMensajeCAD.AsignarAdministrador (p_Mensaje_OID, p_administrador_OID);
}
}
}
