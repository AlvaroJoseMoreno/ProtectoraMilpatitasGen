
using System;
// Definición clase AdministradorEN
namespace ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas
{
public partial class AdministradorEN                                                                        : ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.UsuarioEN


{
/**
 *	Atributo mensajeAdmin
 */
private System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.MensajeEN> mensajeAdmin;






public virtual System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.MensajeEN> MensajeAdmin {
        get { return mensajeAdmin; } set { mensajeAdmin = value;  }
}





public AdministradorEN() : base ()
{
        mensajeAdmin = new System.Collections.Generic.List<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.MensajeEN>();
}



public AdministradorEN(string email, System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.MensajeEN> mensajeAdmin
                       , string nombre, System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.TestAnimalIdealEN> testsAnimalIdeal, System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.NotificacionEN> notificaciones, System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.SolicitudAdopcionEN> solicitudAdopcion, System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.ContratoAdopcionEN> contratoAdopcion, System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.AnimalEN> animal, System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.MensajeEN> mensajeChat, System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.SeguimientoEN> seguimiento, String password
                       )
{
        this.init (Email, mensajeAdmin, nombre, testsAnimalIdeal, notificaciones, solicitudAdopcion, contratoAdopcion, animal, mensajeChat, seguimiento, password);
}


public AdministradorEN(AdministradorEN administrador)
{
        this.init (Email, administrador.MensajeAdmin, administrador.Nombre, administrador.TestsAnimalIdeal, administrador.Notificaciones, administrador.SolicitudAdopcion, administrador.ContratoAdopcion, administrador.Animal, administrador.MensajeChat, administrador.Seguimiento, administrador.Password);
}

private void init (string email
                   , System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.MensajeEN> mensajeAdmin, string nombre, System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.TestAnimalIdealEN> testsAnimalIdeal, System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.NotificacionEN> notificaciones, System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.SolicitudAdopcionEN> solicitudAdopcion, System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.ContratoAdopcionEN> contratoAdopcion, System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.AnimalEN> animal, System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.MensajeEN> mensajeChat, System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.SeguimientoEN> seguimiento, String password)
{
        this.Email = email;


        this.MensajeAdmin = mensajeAdmin;

        this.Nombre = nombre;

        this.TestsAnimalIdeal = testsAnimalIdeal;

        this.Notificaciones = notificaciones;

        this.SolicitudAdopcion = solicitudAdopcion;

        this.ContratoAdopcion = contratoAdopcion;

        this.Animal = animal;

        this.MensajeChat = mensajeChat;

        this.Seguimiento = seguimiento;

        this.Password = password;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        AdministradorEN t = obj as AdministradorEN;
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
