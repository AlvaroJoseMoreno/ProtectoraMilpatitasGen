﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebProtectoraMilpatitas.Models
{
    public class AnimalViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Prompt = "Nombre del animal", Description= "Nombre del animal", Name = "Nombre")]
        [Required (ErrorMessage =  "Debe indicar un nombre para el animal")]
        [StringLength (maximumLength: 50, ErrorMessage ="El nombre del animal no puede tener mas de 50 caracteres")]
    
        public String Nombre { get; set; }

        [Display(Prompt = "Edad del animal", Description = "Edad del animal", Name = "Edad")]
        [Required(ErrorMessage = "Debe indicar una edad para el animal")]
        [Range(minimum:0, maximum: 30, ErrorMessage = "La edad tiene que ser mayor que 0 y menor a 30")]

        public int Edad { get; set; }

        [Display(Prompt = "Sexo del animal", Description = "Sexo del animal", Name = "Sexo")]
        [Required(ErrorMessage = "Debe indicar un sexo para el animal")]
        [StringLength(maximumLength: 1, ErrorMessage = "El sexo del animal no puede tener mas de 1 caracter")]

        public char Sexo { get; set; }

        [Display(Prompt = "Centro donde esta el animal", Description = "Centro donde esta el animal", Name = "Centro")]
        [Required(ErrorMessage = "Debe indicar un centro para el animal")]
        [StringLength(maximumLength: 100, ErrorMessage = "El nombre del centro no puede tener mas de 100 caracteres")]

        public String Centro { get; set; }

        [Display(Prompt = "Caracter del animal", Description = "Caracter del animal", Name = "Caracter")]
        [Required(ErrorMessage = "Debe indicar un caracter para el animal")]
        [StringLength(maximumLength: 50, ErrorMessage = "El caracter del animal no puede tener mas de 50 caracteres")]

        public String Caracter { get; set; }

        [Display(Prompt = "Estado de salud del animal", Description = "Estado de salud del animal", Name = "Estado de salud")]
        [Required(ErrorMessage = "Debe indicar un estado de salud para el animal")]

        public ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas.EstadoSaludEnum DatosMedicos { get; set; }

    }
}