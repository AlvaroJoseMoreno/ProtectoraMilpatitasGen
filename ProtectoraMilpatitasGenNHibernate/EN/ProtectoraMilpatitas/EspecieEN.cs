
using System;
// Definición clase EspecieEN
namespace ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas
{
public partial class EspecieEN
{
/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo animal
 */
private System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.AnimalEN> animal;



/**
 *	Atributo raza
 */
private System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.RazaEN> raza;






public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.AnimalEN> Animal {
        get { return animal; } set { animal = value;  }
}



public virtual System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.RazaEN> Raza {
        get { return raza; } set { raza = value;  }
}





public EspecieEN()
{
        animal = new System.Collections.Generic.List<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.AnimalEN>();
        raza = new System.Collections.Generic.List<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.RazaEN>();
}



public EspecieEN(int id, string nombre, System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.AnimalEN> animal, System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.RazaEN> raza
                 )
{
        this.init (Id, nombre, animal, raza);
}


public EspecieEN(EspecieEN especie)
{
        this.init (Id, especie.Nombre, especie.Animal, especie.Raza);
}

private void init (int id
                   , string nombre, System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.AnimalEN> animal, System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.RazaEN> raza)
{
        this.Id = id;


        this.Nombre = nombre;

        this.Animal = animal;

        this.Raza = raza;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        EspecieEN t = obj as EspecieEN;
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
