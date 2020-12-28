using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebProtectoraMilpatitas.Models
{
    public class RazaViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Prompt = "Nombre de la raza", Description = "Nombre de la raza", Name = "Nombre")]
        [Required(ErrorMessage = "Debe indicar un nombre para la raza")]
        [StringLength(maximumLength: 50, ErrorMessage = "El nombre de la raza no puede tener mas de 50 caracteres")]

        public String Nombre { get; set; }

        [ScaffoldColumn(false)]

        [Display(Prompt = "Id de la especie", Description = "Id de la especie", Name = "Especie")]

        public int idEspecie { get; set; }

        [Display(Prompt = "Nombre de la especie", Description = "Nombre de la especie", Name = "Especie")]
        public string NomEspecie { get; set; }
    }
}