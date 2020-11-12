
using System;
// Definición clase SeguimientoEN
namespace ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas
{
public partial class SeguimientoEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo estado
 */
private ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas.EstadoSeguimientoEnum estado;



/**
 *	Atributo fecha
 */
private Nullable<DateTime> fecha;



/**
 *	Atributo usuario
 */
private ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.UsuarioEN usuario;



/**
 *	Atributo animal
 */
private ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.AnimalEN animal;



/**
 *	Atributo contratoAdopcion
 */
private ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.ContratoAdopcionEN contratoAdopcion;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas.EstadoSeguimientoEnum Estado {
        get { return estado; } set { estado = value;  }
}



public virtual Nullable<DateTime> Fecha {
        get { return fecha; } set { fecha = value;  }
}



public virtual ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.UsuarioEN Usuario {
        get { return usuario; } set { usuario = value;  }
}



public virtual ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.AnimalEN Animal {
        get { return animal; } set { animal = value;  }
}



public virtual ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.ContratoAdopcionEN ContratoAdopcion {
        get { return contratoAdopcion; } set { contratoAdopcion = value;  }
}





public SeguimientoEN()
{
}



public SeguimientoEN(int id, ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas.EstadoSeguimientoEnum estado, Nullable<DateTime> fecha, ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.UsuarioEN usuario, ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.AnimalEN animal, ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.ContratoAdopcionEN contratoAdopcion
                     )
{
        this.init (Id, estado, fecha, usuario, animal, contratoAdopcion);
}


public SeguimientoEN(SeguimientoEN seguimiento)
{
        this.init (Id, seguimiento.Estado, seguimiento.Fecha, seguimiento.Usuario, seguimiento.Animal, seguimiento.ContratoAdopcion);
}

private void init (int id
                   , ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas.EstadoSeguimientoEnum estado, Nullable<DateTime> fecha, ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.UsuarioEN usuario, ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.AnimalEN animal, ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.ContratoAdopcionEN contratoAdopcion)
{
        this.Id = id;


        this.Estado = estado;

        this.Fecha = fecha;

        this.Usuario = usuario;

        this.Animal = animal;

        this.ContratoAdopcion = contratoAdopcion;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        SeguimientoEN t = obj as SeguimientoEN;
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
