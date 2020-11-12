
using System;
// Definición clase ContratoAdopcionEN
namespace ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas
{
public partial class ContratoAdopcionEN
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
 *	Atributo dNI_NIF_Pasaporte
 */
private string dNI_NIF_Pasaporte;



/**
 *	Atributo escrituraHogar
 */
private string escrituraHogar;



/**
 *	Atributo justificantePago
 */
private string justificantePago;



/**
 *	Atributo lugarRecojida
 */
private string lugarRecojida;



/**
 *	Atributo firmaCompromiso
 */
private bool firmaCompromiso;



/**
 *	Atributo estado
 */
private ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas.EstadoContratoEnum estado;



/**
 *	Atributo usuario
 */
private ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.UsuarioEN usuario;



/**
 *	Atributo solicitudAdopcion
 */
private ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.SolicitudAdopcionEN solicitudAdopcion;



/**
 *	Atributo animal
 */
private ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.AnimalEN animal;



/**
 *	Atributo seguimiento
 */
private ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.SeguimientoEN seguimiento;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual string DNI_NIF_Pasaporte {
        get { return dNI_NIF_Pasaporte; } set { dNI_NIF_Pasaporte = value;  }
}



public virtual string EscrituraHogar {
        get { return escrituraHogar; } set { escrituraHogar = value;  }
}



public virtual string JustificantePago {
        get { return justificantePago; } set { justificantePago = value;  }
}



public virtual string LugarRecojida {
        get { return lugarRecojida; } set { lugarRecojida = value;  }
}



public virtual bool FirmaCompromiso {
        get { return firmaCompromiso; } set { firmaCompromiso = value;  }
}



public virtual ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas.EstadoContratoEnum Estado {
        get { return estado; } set { estado = value;  }
}



public virtual ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.UsuarioEN Usuario {
        get { return usuario; } set { usuario = value;  }
}



public virtual ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.SolicitudAdopcionEN SolicitudAdopcion {
        get { return solicitudAdopcion; } set { solicitudAdopcion = value;  }
}



public virtual ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.AnimalEN Animal {
        get { return animal; } set { animal = value;  }
}



public virtual ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.SeguimientoEN Seguimiento {
        get { return seguimiento; } set { seguimiento = value;  }
}





public ContratoAdopcionEN()
{
}



public ContratoAdopcionEN(int id, string nombre, string dNI_NIF_Pasaporte, string escrituraHogar, string justificantePago, string lugarRecojida, bool firmaCompromiso, ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas.EstadoContratoEnum estado, ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.UsuarioEN usuario, ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.SolicitudAdopcionEN solicitudAdopcion, ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.AnimalEN animal, ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.SeguimientoEN seguimiento
                          )
{
        this.init (Id, nombre, dNI_NIF_Pasaporte, escrituraHogar, justificantePago, lugarRecojida, firmaCompromiso, estado, usuario, solicitudAdopcion, animal, seguimiento);
}


public ContratoAdopcionEN(ContratoAdopcionEN contratoAdopcion)
{
        this.init (Id, contratoAdopcion.Nombre, contratoAdopcion.DNI_NIF_Pasaporte, contratoAdopcion.EscrituraHogar, contratoAdopcion.JustificantePago, contratoAdopcion.LugarRecojida, contratoAdopcion.FirmaCompromiso, contratoAdopcion.Estado, contratoAdopcion.Usuario, contratoAdopcion.SolicitudAdopcion, contratoAdopcion.Animal, contratoAdopcion.Seguimiento);
}

private void init (int id
                   , string nombre, string dNI_NIF_Pasaporte, string escrituraHogar, string justificantePago, string lugarRecojida, bool firmaCompromiso, ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas.EstadoContratoEnum estado, ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.UsuarioEN usuario, ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.SolicitudAdopcionEN solicitudAdopcion, ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.AnimalEN animal, ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.SeguimientoEN seguimiento)
{
        this.Id = id;


        this.Nombre = nombre;

        this.DNI_NIF_Pasaporte = dNI_NIF_Pasaporte;

        this.EscrituraHogar = escrituraHogar;

        this.JustificantePago = justificantePago;

        this.LugarRecojida = lugarRecojida;

        this.FirmaCompromiso = firmaCompromiso;

        this.Estado = estado;

        this.Usuario = usuario;

        this.SolicitudAdopcion = solicitudAdopcion;

        this.Animal = animal;

        this.Seguimiento = seguimiento;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ContratoAdopcionEN t = obj as ContratoAdopcionEN;
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
