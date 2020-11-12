
using System;
// Definición clase NotificacionEN
namespace ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas
{
public partial class NotificacionEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo usuario
 */
private ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.UsuarioEN usuario;



/**
 *	Atributo tipo
 */
private ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas.TipoNotificacionEnum tipo;



/**
 *	Atributo solicitudAdopcion
 */
private ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.SolicitudAdopcionEN solicitudAdopcion;



/**
 *	Atributo mensajeChat
 */
private System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.MensajeEN> mensajeChat;



/**
 *	Atributo mensaje
 */
private string mensaje;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.UsuarioEN Usuario {
        get { return usuario; } set { usuario = value;  }
}



public virtual ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas.TipoNotificacionEnum Tipo {
        get { return tipo; } set { tipo = value;  }
}



public virtual ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.SolicitudAdopcionEN SolicitudAdopcion {
        get { return solicitudAdopcion; } set { solicitudAdopcion = value;  }
}



public virtual System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.MensajeEN> MensajeChat {
        get { return mensajeChat; } set { mensajeChat = value;  }
}



public virtual string Mensaje {
        get { return mensaje; } set { mensaje = value;  }
}





public NotificacionEN()
{
        mensajeChat = new System.Collections.Generic.List<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.MensajeEN>();
}



public NotificacionEN(int id, ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.UsuarioEN usuario, ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas.TipoNotificacionEnum tipo, ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.SolicitudAdopcionEN solicitudAdopcion, System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.MensajeEN> mensajeChat, string mensaje
                      )
{
        this.init (Id, usuario, tipo, solicitudAdopcion, mensajeChat, mensaje);
}


public NotificacionEN(NotificacionEN notificacion)
{
        this.init (Id, notificacion.Usuario, notificacion.Tipo, notificacion.SolicitudAdopcion, notificacion.MensajeChat, notificacion.Mensaje);
}

private void init (int id
                   , ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.UsuarioEN usuario, ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas.TipoNotificacionEnum tipo, ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.SolicitudAdopcionEN solicitudAdopcion, System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.MensajeEN> mensajeChat, string mensaje)
{
        this.Id = id;


        this.Usuario = usuario;

        this.Tipo = tipo;

        this.SolicitudAdopcion = solicitudAdopcion;

        this.MensajeChat = mensajeChat;

        this.Mensaje = mensaje;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        NotificacionEN t = obj as NotificacionEN;
        if (t == null)
                return false;
        if (Id.Equals (t.Id))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Id.GetHashCode ();
        return hash;
}
}
}
