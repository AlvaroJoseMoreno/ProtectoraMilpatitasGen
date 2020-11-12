
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


/*PROTECTED REGION ID(usingProtectoraMilpatitasGenNHibernate.CEN.ProtectoraMilpatitas_Animal_actualizar_Estado) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ProtectoraMilpatitasGenNHibernate.CEN.ProtectoraMilpatitas
{
public partial class AnimalCEN
{
public void Actualizar_Estado (int p_Animal, ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas.EstadoAnimalAdopcionEnum p_estadoAdopcion)
{
        /*PROTECTED REGION ID(ProtectoraMilpatitasGenNHibernate.CEN.ProtectoraMilpatitas_Animal_actualizar_Estado_customized) START*/

        AnimalEN animalEN = null;

        //Initialized AnimalEN
        animalEN = new AnimalEN ();
        animalEN.Id = p_Animal;
        animalEN.EstadoAdopcion = p_estadoAdopcion;
        //Call to AnimalCAD

        _IAnimalCAD.Actualizar_Estado (animalEN);

        /*PROTECTED REGION END*/
}
}
}
