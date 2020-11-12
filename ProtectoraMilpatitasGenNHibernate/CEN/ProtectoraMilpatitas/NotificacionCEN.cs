

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
 *      Definition of the class NotificacionCEN
 *
 */
public partial class NotificacionCEN
{
private INotificacionCAD _INotificacionCAD;

public NotificacionCEN()
{
        this._INotificacionCAD = new NotificacionCAD ();
}

public NotificacionCEN(INotificacionCAD _INotificacionCAD)
{
        this._INotificacionCAD = _INotificacionCAD;
}

public INotificacionCAD get_INotificacionCAD ()
{
        return this._INotificacionCAD;
}

public int Nuevo (string p_usuario, ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas.TipoNotificacionEnum p_tipo, int p_solicitudAdopcion, string p_mensaje)
{
        NotificacionEN notificacionEN = null;
        int oid;

        //Initialized NotificacionEN
        notificacionEN = new NotificacionEN ();

        if (p_usuario != null) {
                // El argumento p_usuario -> Property usuario es oid = false
                // Lista de oids id
                notificacionEN.Usuario = new ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.UsuarioEN ();
                notificacionEN.Usuario.Email = p_usuario;
        }

        notificacionEN.Tipo = p_tipo;


        if (p_solicitudAdopcion != -1) {
                // El argumento p_solicitudAdopcion -> Property solicitudAdopcion es oid = false
                // Lista de oids id
                notificacionEN.SolicitudAdopcion = new ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.SolicitudAdopcionEN ();
                notificacionEN.SolicitudAdopcion.Id = p_solicitudAdopcion;
        }

        notificacionEN.Mensaje = p_mensaje;

        //Call to NotificacionCAD

        oid = _INotificacionCAD.Nuevo (notificacionEN);
        return oid;
}

public void Modificar (int p_Notificacion_OID, ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas.TipoNotificacionEnum p_tipo, string p_mensaje)
{
        NotificacionEN notificacionEN = null;

        //Initialized NotificacionEN
        notificacionEN = new NotificacionEN ();
        notificacionEN.Id = p_Notificacion_OID;
        notificacionEN.Tipo = p_tipo;
        notificacionEN.Mensaje = p_mensaje;
        //Call to NotificacionCAD

        _INotificacionCAD.Modificar (notificacionEN);
}

public void Eliminar (int id
                      )
{
        _INotificacionCAD.Eliminar (id);
}

public System.Collections.Generic.IList<NotificacionEN> Dame_Todas (int first, int size)
{
        System.Collections.Generic.IList<NotificacionEN> list = null;

        list = _INotificacionCAD.Dame_Todas (first, size);
        return list;
}
public NotificacionEN Dame_Por_Id (int id
                                   )
{
        NotificacionEN notificacionEN = null;

        notificacionEN = _INotificacionCAD.Dame_Por_Id (id);
        return notificacionEN;
}
}
}
