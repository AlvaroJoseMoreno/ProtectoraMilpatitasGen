using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas;
using WebProtectoraMilpatitas.Models;

namespace WebProtectoraMilpatitas.Assemblers
{
    public class AnimalAssembler
    {
        public AnimalViewModel ConverENToModelUI(AnimalEN anim)
        {
            AnimalViewModel animal = new AnimalViewModel();

            animal.Id = anim.Id;
            animal.Nombre = anim.Nombre;

            return animal;
        }


    }
}