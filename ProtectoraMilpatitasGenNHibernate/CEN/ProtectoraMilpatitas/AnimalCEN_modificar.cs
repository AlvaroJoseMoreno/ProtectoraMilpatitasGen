
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
        
        if(p_nombre != null && p_nombre != animalEN.Nombre)
        animalEN.Nombre = p_nombre;
        if(p_edad != -1 && p_edad != animalEN.Edad)
        animalEN.Edad = p_edad;
        if(p_sexo != null && p_sexo != animalEN.Sexo)
        animalEN.Sexo = p_sexo;
        if(p_centro != null && p_centro != animalEN.Centro)
        animalEN.Centro = p_centro;
        if(p_caracter != null && p_caracter != animalEN.Caracter)
        animalEN.Caracter = p_caracter;


        //Call to AnimalCAD

        _IAnimalCAD.Modificar (animalEN);

        /*PROTECTED REGION END*/
}
}
}
