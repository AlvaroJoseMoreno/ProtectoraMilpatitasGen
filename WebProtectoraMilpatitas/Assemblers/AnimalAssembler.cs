﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas;
using WebProtectoraMilpatitas.Models;

namespace WebProtectoraMilpatitas.Assemblers
{
    public class AnimalAssembler
    {
        public AnimalViewModel ConvertENToModelUI(AnimalEN ani)
        {
            AnimalViewModel animal = new AnimalViewModel();
            animal.Id = ani.Id;
            animal.Nombre = ani.Nombre;

            return animal;
        }

        public IList<AnimalViewModel> ConvertListENToModel(IList<AnimalEN> anims)
        {
            IList<AnimalViewModel> animales = new List<AnimalViewModel>();

            foreach (AnimalEN ani in anims)
            {
                animales.Add(ConvertENToModelUI(ani));
            }
            return animales;
        }
    }
}