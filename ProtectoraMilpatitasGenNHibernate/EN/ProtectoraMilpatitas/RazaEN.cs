
using System;
// Definición clase RazaEN
namespace ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas
{
public partial class RazaEN
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
 *	Atributo especie
 */
private ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.EspecieEN especie;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.EspecieEN Especie {
        get { return especie; } set { especie = value;  }
}





public RazaEN()
{
}



public RazaEN(int id, string nombre, ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.EspecieEN especie
              )
{
        this.init (Id, nombre, especie);
}


public RazaEN(RazaEN raza)
{
        this.init (Id, raza.Nombre, raza.Especie);
}

private void init (int id
                   , string nombre, ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.EspecieEN especie)
{
        this.Id = id;


        this.Nombre = nombre;

        this.Especie = especie;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        RazaEN t = obj as RazaEN;
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
