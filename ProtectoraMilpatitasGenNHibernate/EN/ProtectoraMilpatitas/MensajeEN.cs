
using System;
// Definición clase MensajeEN
namespace ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas
{
public partial class MensajeEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo administrador
 */
private ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.AdministradorEN administrador;



/**
 *	Atributo usuario
 */
private ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.UsuarioEN usuario;



/**
 *	Atributo notificacion
 */
private System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.NotificacionEN> notificacion;



/**
 *	Atributo texto
 */
private string texto;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.AdministradorEN Administrador {
        get { return administrador; } set { administrador = value;  }
}



public virtual ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.UsuarioEN Usuario {
        get { return usuario; } set { usuario = value;  }
}



public virtual System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.NotificacionEN> Notificacion {
        get { return notificacion; } set { notificacion = value;  }
}



public virtual string Texto {
        get { return texto; } set { texto = value;  }
}





public MensajeEN()
{
        notificacion = new System.Collections.Generic.List<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.NotificacionEN>();
}



public MensajeEN(int id, ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.AdministradorEN administrador, ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.UsuarioEN usuario, System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.NotificacionEN> notificacion, string texto
                 )
{
        this.init (Id, administrador, usuario, notificacion, texto);
}


public MensajeEN(MensajeEN mensaje)
{
        this.init (Id, mensaje.Administrador, mensaje.Usuario, mensaje.Notificacion, mensaje.Texto);
}

private void init (int id
                   , ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.AdministradorEN administrador, ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.UsuarioEN usuario, System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.NotificacionEN> notificacion, string texto)
{
        this.Id = id;


        this.Administrador = administrador;

        this.Usuario = usuario;

        this.Notificacion = notificacion;

        this.Texto = texto;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        MensajeEN t = obj as MensajeEN;
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
