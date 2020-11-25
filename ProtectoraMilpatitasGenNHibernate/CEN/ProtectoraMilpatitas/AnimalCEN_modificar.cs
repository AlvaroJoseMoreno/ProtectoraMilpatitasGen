
using System;
using System.Text;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using ProtectoraMilpatitasGenNHibernate.Exceptions;
using ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas;
using ProtectoraMilpatitasGenNHibernate.CAD.ProtectoraMilpatitas;


/*PROTECTED REGION ID(usingProtectoraMilpatitasGenNHibernate.CEN.ProtectoraMilpatitas_Animal_modificar) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ProtectoraMilpatitasGenNHibernate.CEN.ProtectoraMilpatitas
{
public partial class AnimalCEN
{
public void Modificar (int p_Animal, string p_nombre, int p_edad, char p_sexo, string p_centro, string p_caracter)
{
        /*PROTECTED REGION ID(ProtectoraMilpatitasGenNHibernate.CEN.ProtectoraMilpatitas_Animal_modificar_customized) START*/

        AnimalEN animalEN = null;

        //Initialized AnimalEN
        animalEN = new AnimalEN ();
        animalEN.Id = p_Animal;
        animalEN.Nombre = p_nombre;
        animalEN.Edad = p_edad;
        animalEN.Sexo = p_sexo;
        animalEN.Centro = p_centro;
        animalEN.Caracter = p_caracter;
        //Call to AnimalCAD

        _IAnimalCAD.Modificar (animalEN);

        /*PROTECTED REGION END*/
}
}
}
