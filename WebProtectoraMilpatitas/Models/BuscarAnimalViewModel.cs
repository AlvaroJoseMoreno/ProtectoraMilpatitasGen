using ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebProtectoraMilpatitas.Models
{
    public class BuscarAnimalViewModel
    {
        [Display(Prompt = "Nombre del animal", Description = "Nombre del animal", Name = "Nombre")]
        public String Nombre { get; set; }

        [Display(Prompt = "Edad del animal", Description = "Edad del animal", Name = "Edad")]
        public int Edad { get; set; }

        [Display(Prompt = "Sexo del animal", Description = "Sexo del animal", Name = "Sexo")]
        public char Sexo { get; set; }

        [Display(Prompt = "Centro donde esta el animal", Description = "Centro donde esta el animal", Name = "Centro")]
        public String Centro { get; set; }

        [Display(Prompt = "Caracter del animal", Description = "Caracter del animal", Name = "Caracter")]
        public String Caracter { get; set; }

        [Display(Prompt = "Estado de salud del animal", Description = "Estado de salud del animal", Name = "Estado de salud")]
        public ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas.EstadoSaludEnum DatosMedicos { get; set; }

        [Display(Prompt = "Fecha llegada", Description = "Fecha llegada", Name = "Fecha llegada")]
        [DataType(DataType.Date)]
        public DateTime FechaLlegada { get; set; }

        [Display(Prompt = "Especie del animal", Description = "Especie del animal", Name = "Especie")]
        public int idEspecie { get; set; }

        [ScaffoldColumn(false)]
        [Display(Prompt = "Especie del animal", Description = "Especie del animal", Name = "Especie")]
        public int idBusEspecie { get; set; }

        [Display(Prompt = "Especie del animal", Description = "Especie del animal", Name = "Especie")]
        public string NomEspecie { get; set; }

        [Display(Prompt = "Raza del animal", Description = "Raza del animal", Name = "Raza")]
        public int idRaza { get; set; }

        [ScaffoldColumn(false)]
        [Display(Prompt = "Raza del animal", Description = "Raza del animal", Name = "Raza")]
        public int idBusRaza { get; set; }

        [Display(Prompt = "Raza del animal", Description = "Raza del animal", Name = "Raza")]
        public string NomRaza { get; set; }
    }
}