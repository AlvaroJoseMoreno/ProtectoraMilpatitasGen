using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebProtectoraMilpatitas.Models
{
    public class EspecieViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Prompt = "Nombre de la especie", Description = "Nombre de la especie", Name = "Nombre")]
        [Required(ErrorMessage = "Debe indicar un nombre para la especie")]
        [StringLength(maximumLength: 50, ErrorMessage = "El nombre de la especie no puede tener mas de 50 caracteres")]

        public String Nombre { get; set; }

    }
}