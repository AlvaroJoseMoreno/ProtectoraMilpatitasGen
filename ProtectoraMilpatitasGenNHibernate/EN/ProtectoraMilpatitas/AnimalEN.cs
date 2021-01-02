
using System;
// Definición clase AnimalEN
namespace ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas
{
public partial class AnimalEN
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
 *	Atributo edad
 */
private int edad;



/**
 *	Atributo sexo
 */
private char sexo;



/**
 *	Atributo centro
 */
private string centro;



/**
 *	Atributo datosMedicos
 */
private ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas.EstadoSaludEnum datosMedicos;



/**
 *	Atributo caracter
 */
private string caracter;



/**
 *	Atributo solicitudAdopcion
 */
private System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.SolicitudAdopcionEN> solicitudAdopcion;



/**
 *	Atributo contratoAdopcion
 */
private System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.ContratoAdopcionEN> contratoAdopcion;



/**
 *	Atributo dueño
 */
private ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.UsuarioEN dueño;



/**
 *	Atributo especie
 */
private ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.EspecieEN especie;



/**
 *	Atributo seguimiento
 */
private System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.SeguimientoEN> seguimiento;



/**
 *	Atributo estadoAdopcion
 */
private ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas.EstadoAnimalAdopcionEnum estadoAdopcion;



/**
 *	Atributo foto
 */
private string foto;



/**
 *	Atributo fechaLlegada
 */
private Nullable<DateTime> fechaLlegada;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual int Edad {
        get { return edad; } set { edad = value;  }
}



public virtual char Sexo {
        get { return sexo; } set { sexo = value;  }
}



public virtual string Centro {
        get { return centro; } set { centro = value;  }
}



public virtual ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas.EstadoSaludEnum DatosMedicos {
        get { return datosMedicos; } set { datosMedicos = value;  }
}



public virtual string Caracter {
        get { return caracter; } set { caracter = value;  }
}



public virtual System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.SolicitudAdopcionEN> SolicitudAdopcion {
        get { return solicitudAdopcion; } set { solicitudAdopcion = value;  }
}



public virtual System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.ContratoAdopcionEN> ContratoAdopcion {
        get { return contratoAdopcion; } set { contratoAdopcion = value;  }
}



public virtual ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.UsuarioEN Dueño {
        get { return dueño; } set { dueño = value;  }
}



public virtual ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.EspecieEN Especie {
        get { return especie; } set { especie = value;  }
}



public virtual System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.SeguimientoEN> Seguimiento {
        get { return seguimiento; } set { seguimiento = value;  }
}



public virtual ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas.EstadoAnimalAdopcionEnum EstadoAdopcion {
        get { return estadoAdopcion; } set { estadoAdopcion = value;  }
}



public virtual string Foto {
        get { return foto; } set { foto = value;  }
}



public virtual Nullable<DateTime> FechaLlegada {
        get { return fechaLlegada; } set { fechaLlegada = value;  }
}





public AnimalEN()
{
        solicitudAdopcion = new System.Collections.Generic.List<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.SolicitudAdopcionEN>();
        contratoAdopcion = new System.Collections.Generic.List<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.ContratoAdopcionEN>();
        seguimiento = new System.Collections.Generic.List<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.SeguimientoEN>();
}



public AnimalEN(int id, string nombre, int edad, char sexo, string centro, ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas.EstadoSaludEnum datosMedicos, string caracter, System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.SolicitudAdopcionEN> solicitudAdopcion, System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.ContratoAdopcionEN> contratoAdopcion, ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.UsuarioEN dueño, ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.EspecieEN especie, System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.SeguimientoEN> seguimiento, ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas.EstadoAnimalAdopcionEnum estadoAdopcion, string foto, Nullable<DateTime> fechaLlegada
                )
{
        this.init (Id, nombre, edad, sexo, centro, datosMedicos, caracter, solicitudAdopcion, contratoAdopcion, dueño, especie, seguimiento, estadoAdopcion, foto, fechaLlegada);
}


public AnimalEN(AnimalEN animal)
{
        this.init (Id, animal.Nombre, animal.Edad, animal.Sexo, animal.Centro, animal.DatosMedicos, animal.Caracter, animal.SolicitudAdopcion, animal.ContratoAdopcion, animal.Dueño, animal.Especie, animal.Seguimiento, animal.EstadoAdopcion, animal.Foto, animal.FechaLlegada);
}

private void init (int id
                   , string nombre, int edad, char sexo, string centro, ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas.EstadoSaludEnum datosMedicos, string caracter, System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.SolicitudAdopcionEN> solicitudAdopcion, System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.ContratoAdopcionEN> contratoAdopcion, ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.UsuarioEN dueño, ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.EspecieEN especie, System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.SeguimientoEN> seguimiento, ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas.EstadoAnimalAdopcionEnum estadoAdopcion, string foto, Nullable<DateTime> fechaLlegada)
{
        this.Id = id;


        this.Nombre = nombre;

        this.Edad = edad;

        this.Sexo = sexo;

        this.Centro = centro;

        this.DatosMedicos = datosMedicos;

        this.Caracter = caracter;

        this.SolicitudAdopcion = solicitudAdopcion;

        this.ContratoAdopcion = contratoAdopcion;

        this.Dueño = dueño;

        this.Especie = especie;

        this.Seguimiento = seguimiento;

        this.EstadoAdopcion = estadoAdopcion;

        this.Foto = foto;

        this.FechaLlegada = fechaLlegada;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        AnimalEN t = obj as AnimalEN;
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
