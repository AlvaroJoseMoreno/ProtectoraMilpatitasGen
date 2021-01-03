
using System;
// Definición clase TestAnimalIdealEN
namespace ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas
{
public partial class TestAnimalIdealEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo aficionFavorita
 */
private string aficionFavorita;



/**
 *	Atributo personalidad
 */
private string personalidad;



/**
 *	Atributo colorFavorito
 */
private string colorFavorito;



/**
 *	Atributo usuario
 */
private ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.UsuarioEN usuario;



/**
 *	Atributo resultado
 */
private string resultado;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string AficionFavorita {
        get { return aficionFavorita; } set { aficionFavorita = value;  }
}



public virtual string Personalidad {
        get { return personalidad; } set { personalidad = value;  }
}



public virtual string ColorFavorito {
        get { return colorFavorito; } set { colorFavorito = value;  }
}



public virtual ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.UsuarioEN Usuario {
        get { return usuario; } set { usuario = value;  }
}



public virtual string Resultado {
        get { return resultado; } set { resultado = value;  }
}





public TestAnimalIdealEN()
{
}



public TestAnimalIdealEN(int id, string aficionFavorita, string personalidad, string colorFavorito, ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.UsuarioEN usuario, string resultado
                         )
{
        this.init (Id, aficionFavorita, personalidad, colorFavorito, usuario, resultado);
}


public TestAnimalIdealEN(TestAnimalIdealEN testAnimalIdeal)
{
        this.init (Id, testAnimalIdeal.AficionFavorita, testAnimalIdeal.Personalidad, testAnimalIdeal.ColorFavorito, testAnimalIdeal.Usuario, testAnimalIdeal.Resultado);
}

private void init (int id
                   , string aficionFavorita, string personalidad, string colorFavorito, ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.UsuarioEN usuario, string resultado)
{
        this.Id = id;


        this.AficionFavorita = aficionFavorita;

        this.Personalidad = personalidad;

        this.ColorFavorito = colorFavorito;

        this.Usuario = usuario;

        this.Resultado = resultado;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        TestAnimalIdealEN t = obj as TestAnimalIdealEN;
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
