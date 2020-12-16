
using System;
// Definición clase UsuarioEN
namespace ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas
{
public partial class UsuarioEN
{
/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo email
 */
private string email;



/**
 *	Atributo testsAnimalIdeal
 */
private System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.TestAnimalIdealEN> testsAnimalIdeal;



/**
 *	Atributo notificaciones
 */
private System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.NotificacionEN> notificaciones;



/**
 *	Atributo solicitudAdopcion
 */
private System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.SolicitudAdopcionEN> solicitudAdopcion;



/**
 *	Atributo contratoAdopcion
 */
private System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.ContratoAdopcionEN> contratoAdopcion;



/**
 *	Atributo mascotas
 */
private System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.AnimalEN> mascotas;



/**
 *	Atributo mensajeChat
 */
private System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.MensajeEN> mensajeChat;



/**
 *	Atributo seguimiento
 */
private System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.SeguimientoEN> seguimiento;



/**
 *	Atributo password
 */
private String password;






public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual string Email {
        get { return email; } set { email = value;  }
}



public virtual System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.TestAnimalIdealEN> TestsAnimalIdeal {
        get { return testsAnimalIdeal; } set { testsAnimalIdeal = value;  }
}



public virtual System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.NotificacionEN> Notificaciones {
        get { return notificaciones; } set { notificaciones = value;  }
}



public virtual System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.SolicitudAdopcionEN> SolicitudAdopcion {
        get { return solicitudAdopcion; } set { solicitudAdopcion = value;  }
}



public virtual System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.ContratoAdopcionEN> ContratoAdopcion {
        get { return contratoAdopcion; } set { contratoAdopcion = value;  }
}



public virtual System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.AnimalEN> Mascotas {
        get { return mascotas; } set { mascotas = value;  }
}



public virtual System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.MensajeEN> MensajeChat {
        get { return mensajeChat; } set { mensajeChat = value;  }
}



public virtual System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.SeguimientoEN> Seguimiento {
        get { return seguimiento; } set { seguimiento = value;  }
}



public virtual String Password {
        get { return password; } set { password = value;  }
}





public UsuarioEN()
{
        testsAnimalIdeal = new System.Collections.Generic.List<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.TestAnimalIdealEN>();
        notificaciones = new System.Collections.Generic.List<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.NotificacionEN>();
        solicitudAdopcion = new System.Collections.Generic.List<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.SolicitudAdopcionEN>();
        contratoAdopcion = new System.Collections.Generic.List<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.ContratoAdopcionEN>();
        mascotas = new System.Collections.Generic.List<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.AnimalEN>();
        mensajeChat = new System.Collections.Generic.List<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.MensajeEN>();
        seguimiento = new System.Collections.Generic.List<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.SeguimientoEN>();
}



public UsuarioEN(string email, string nombre, System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.TestAnimalIdealEN> testsAnimalIdeal, System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.NotificacionEN> notificaciones, System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.SolicitudAdopcionEN> solicitudAdopcion, System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.ContratoAdopcionEN> contratoAdopcion, System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.AnimalEN> mascotas, System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.MensajeEN> mensajeChat, System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.SeguimientoEN> seguimiento, String password
                 )
{
        this.init (Email, nombre, testsAnimalIdeal, notificaciones, solicitudAdopcion, contratoAdopcion, mascotas, mensajeChat, seguimiento, password);
}


public UsuarioEN(UsuarioEN usuario)
{
        this.init (Email, usuario.Nombre, usuario.TestsAnimalIdeal, usuario.Notificaciones, usuario.SolicitudAdopcion, usuario.ContratoAdopcion, usuario.Mascotas, usuario.MensajeChat, usuario.Seguimiento, usuario.Password);
}

private void init (string email
                   , string nombre, System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.TestAnimalIdealEN> testsAnimalIdeal, System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.NotificacionEN> notificaciones, System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.SolicitudAdopcionEN> solicitudAdopcion, System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.ContratoAdopcionEN> contratoAdopcion, System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.AnimalEN> mascotas, System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.MensajeEN> mensajeChat, System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.SeguimientoEN> seguimiento, String password)
{
        this.Email = email;


        this.Nombre = nombre;

        this.TestsAnimalIdeal = testsAnimalIdeal;

        this.Notificaciones = notificaciones;

        this.SolicitudAdopcion = solicitudAdopcion;

        this.ContratoAdopcion = contratoAdopcion;

        this.Mascotas = mascotas;

        this.MensajeChat = mensajeChat;

        this.Seguimiento = seguimiento;

        this.Password = password;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        UsuarioEN t = obj as UsuarioEN;
        if (t == null)
                return false;
        if (Email.Equals (t.Email))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Email.GetHashCode ();
        return hash;
}
}
}
