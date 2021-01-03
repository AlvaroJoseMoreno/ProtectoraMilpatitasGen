using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebProtectoraMilpatitas.Models
{
    public class TestAnimalIdealViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Prompt ="Afición favorita", Description ="Afición favorita", Name = "¿Cuál es tu afición favorita?")]
        [Required(ErrorMessage ="Debe indicar una afición favorita")]
        [StringLength(maximumLength:100, ErrorMessage ="La afición no puede tener más de 100 caracteres")]
        public string AficionFavorita { get; set; }

        [Display(Prompt = "Personalidad", Description = "Personalidad", Name = "¿Qué te describe mejor?")]
        [Required(ErrorMessage = "Debe indicar una personalidad")]
        [StringLength(maximumLength: 100, ErrorMessage = "La personalidad no puede tener más de 100 caracteres")]
        public string Personalidad { get; set; }

        [Display(Prompt = "Color Favorito", Description = "Color Favorito", Name = "¿Cúal es tu color favorito?")]
        [Required(ErrorMessage = "Debe indicar un color favorito")]
        [StringLength(maximumLength: 100, ErrorMessage = "El color no puede tener más de 50 caracteres")]
        public string ColorFavorito { get; set; }

        public string idUsuario { get; set; }

        public string Resultado { get; set; }
    }
}