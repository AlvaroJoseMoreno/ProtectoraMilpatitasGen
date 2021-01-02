

using System;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using ProtectoraMilpatitasGenNHibernate.Exceptions;

using ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas;
using ProtectoraMilpatitasGenNHibernate.CAD.ProtectoraMilpatitas;


namespace ProtectoraMilpatitasGenNHibernate.CEN.ProtectoraMilpatitas
{
/*
 *      Definition of the class AnimalCEN
 *
 */
public partial class AnimalCEN
{
private IAnimalCAD _IAnimalCAD;

public AnimalCEN()
{
        this._IAnimalCAD = new AnimalCAD ();
}

public AnimalCEN(IAnimalCAD _IAnimalCAD)
{
        this._IAnimalCAD = _IAnimalCAD;
}

public IAnimalCAD get_IAnimalCAD ()
{
        return this._IAnimalCAD;
}

public void Eliminar (int id
                      )
{
        _IAnimalCAD.Eliminar (id);
}

public AnimalEN Ver_Detalle_Animal (int id
                                    )
{
        AnimalEN animalEN = null;

        animalEN = _IAnimalCAD.Ver_Detalle_Animal (id);
        return animalEN;
}

public System.Collections.Generic.IList<AnimalEN> Dame_Todos (int first, int size)
{
        System.Collections.Generic.IList<AnimalEN> list = null;

        list = _IAnimalCAD.Dame_Todos (first, size);
        return list;
}
public System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.AnimalEN> BuscarAnimales (string p_nombre, int? p_edad, char p_sexo, string p_centro, ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas.EstadoSaludEnum? p_datosMedicos, string p_caracter)
{
        return _IAnimalCAD.BuscarAnimales (p_nombre, p_edad, p_sexo, p_centro, p_datosMedicos, p_caracter);
}
public System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.AnimalEN> Dame_Animales_Por_Especie (int p_especie)
{
        return _IAnimalCAD.Dame_Animales_Por_Especie (p_especie);
}
public System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.AnimalEN> Obtener_Animal_Usuario (string p_email)
{
        return _IAnimalCAD.Obtener_Animal_Usuario (p_email);
}
public void AsignarDuenyo (int p_Animal_OID, string p_dueño_OID)
{
        //Call to AnimalCAD

        _IAnimalCAD.AsignarDuenyo (p_Animal_OID, p_dueño_OID);
}
public System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.AnimalEN> BusquedaRapida (string p_nombre)
{
        return _IAnimalCAD.BusquedaRapida (p_nombre);
}
}
}
