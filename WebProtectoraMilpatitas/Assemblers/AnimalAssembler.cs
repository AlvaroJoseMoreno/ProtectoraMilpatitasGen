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
        public AnimalViewModel ConvertENToModelUI(AnimalEN ani)
        {
            AnimalViewModel animal = new AnimalViewModel();
            animal.Id = ani.Id;
            animal.Nombre = ani.Nombre;
            animal.Edad = ani.Edad;
            animal.Sexo = ani.Sexo;
            animal.Centro = ani.Centro;
            animal.Caracter = ani.Caracter;
            animal.DatosMedicos = ani.DatosMedicos;
            animal.EstadoAdopcion = ani.EstadoAdopcion;
            animal.Foto = ani.Foto;
            animal.FechaLlegada = (DateTime)ani.FechaLlegada;

            if (ani.Especie != null)
            {
                animal.idEspecie = ani.Especie.Id;
                animal.idBusEspecie = ani.Especie.Id;
                animal.NomEspecie = ani.Especie.Nombre;
            }
            

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