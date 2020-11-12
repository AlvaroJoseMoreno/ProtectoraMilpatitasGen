
using System;
// Definición clase SolicitudAdopcionEN
namespace ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas
{
public partial class SolicitudAdopcionEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo animalesAcargo
 */
private int animalesAcargo;



/**
 *	Atributo ambienteConvivencia
 */
private string ambienteConvivencia;



/**
 *	Atributo tiempoLibre
 */
private int tiempoLibre;



/**
 *	Atributo todosAcuerdo
 */
private bool todosAcuerdo;



/**
 *	Atributo motivosAdopcion
 */
private string motivosAdopcion;



/**
 *	Atributo estado
 */
private ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas.EstadoAdopcionEnum estado;



/**
 *	Atributo usuario
 */
private ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.UsuarioEN usuario;



/**
 *	Atributo notificacion
 */
private System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.NotificacionEN> notificacion;



/**
 *	Atributo contratoAdopcion
 */
private ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.ContratoAdopcionEN contratoAdopcion;



/**
 *	Atributo animal
 */
private ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.AnimalEN animal;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual int AnimalesAcargo {
        get { return animalesAcargo; } set { animalesAcargo = value;  }
}



public virtual string AmbienteConvivencia {
        get { return ambienteConvivencia; } set { ambienteConvivencia = value;  }
}



public virtual int TiempoLibre {
        get { return tiempoLibre; } set { tiempoLibre = value;  }
}



public virtual bool TodosAcuerdo {
        get { return todosAcuerdo; } set { todosAcuerdo = value;  }
}



public virtual string MotivosAdopcion {
        get { return motivosAdopcion; } set { motivosAdopcion = value;  }
}



public virtual ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas.EstadoAdopcionEnum Estado {
        get { return estado; } set { estado = value;  }
}



public virtual ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.UsuarioEN Usuario {
        get { return usuario; } set { usuario = value;  }
}



public virtual System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.NotificacionEN> Notificacion {
        get { return notificacion; } set { notificacion = value;  }
}



public virtual ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.ContratoAdopcionEN ContratoAdopcion {
        get { return contratoAdopcion; } set { contratoAdopcion = value;  }
}



public virtual ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.AnimalEN Animal {
        get { return animal; } set { animal = value;  }
}





public SolicitudAdopcionEN()
{
        notificacion = new System.Collections.Generic.List<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.NotificacionEN>();
}



public SolicitudAdopcionEN(int id, string nombre, int animalesAcargo, string ambienteConvivencia, int tiempoLibre, bool todosAcuerdo, string motivosAdopcion, ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas.EstadoAdopcionEnum estado, ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.UsuarioEN usuario, System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.NotificacionEN> notificacion, ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.ContratoAdopcionEN contratoAdopcion, ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.AnimalEN animal
                           )
{
        this.init (Id, nombre, animalesAcargo, ambienteConvivencia, tiempoLibre, todosAcuerdo, motivosAdopcion, estado, usuario, notificacion, contratoAdopcion, animal);
}


public SolicitudAdopcionEN(SolicitudAdopcionEN solicitudAdopcion)
{
        this.init (Id, solicitudAdopcion.Nombre, solicitudAdopcion.AnimalesAcargo, solicitudAdopcion.AmbienteConvivencia, solicitudAdopcion.TiempoLibre, solicitudAdopcion.TodosAcuerdo, solicitudAdopcion.MotivosAdopcion, solicitudAdopcion.Estado, solicitudAdopcion.Usuario, solicitudAdopcion.Notificacion, solicitudAdopcion.ContratoAdopcion, solicitudAdopcion.Animal);
}

private void init (int id
                   , string nombre, int animalesAcargo, string ambienteConvivencia, int tiempoLibre, bool todosAcuerdo, string motivosAdopcion, ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas.EstadoAdopcionEnum estado, ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.UsuarioEN usuario, System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.NotificacionEN> notificacion, ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.ContratoAdopcionEN contratoAdopcion, ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.AnimalEN animal)
{
        this.Id = id;


        this.Nombre = nombre;

        this.AnimalesAcargo = animalesAcargo;

        this.AmbienteConvivencia = ambienteConvivencia;

        this.TiempoLibre = tiempoLibre;

        this.TodosAcuerdo = todosAcuerdo;

        this.MotivosAdopcion = motivosAdopcion;

        this.Estado = estado;

        this.Usuario = usuario;

        this.Notificacion = notificacion;

        this.ContratoAdopcion = contratoAdopcion;

        this.Animal = animal;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        SolicitudAdopcionEN t = obj as SolicitudAdopcionEN;
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
