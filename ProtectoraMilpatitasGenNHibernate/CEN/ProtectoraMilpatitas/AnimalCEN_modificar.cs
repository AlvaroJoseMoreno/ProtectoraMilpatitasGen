
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
public void Modificar (int p_Animal, string p_nombre, int p_edad, char p_sexo, string p_centro, string p_caracter, string p_foto)
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

            if (p_foto != null)
            {
                string[] fotoAnim = p_foto.Split('/');
                if (fotoAnim.Length == 3)
                {
                    if (fotoAnim[2].Equals(""))
                    {
                        AnimalCEN anicen = new AnimalCEN();
                        AnimalEN anien = anicen.Ver_Detalle_Animal(p_Animal);
                        animalEN.Foto = anien.Foto;
                    }
                    else
                    {
                        animalEN.Foto = p_foto;
                    }
                }

            }
            //Call to AnimalCAD

            _IAnimalCAD.Modificar (animalEN);

        /*PROTECTED REGION END*/
}
}
}
