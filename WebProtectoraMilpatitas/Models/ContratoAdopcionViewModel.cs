using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebProtectoraMilpatitas.Models
{
    public class ContratoAdopcionViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Prompt = "Nombre del usuario", Description = "Nombre del usuario", Name = "Nombre")]
        [Required(ErrorMessage = "Debe indicar un nombre para el usuario")]
        [StringLength(maximumLength: 50, ErrorMessage = "El nombre del usuario no puede tener mas de 50 caracteres")]

        public String Nombre { get; set; }

        [Display(Prompt = "Identificacion del usuario", Description = "Identificacion del usuario", Name = "DNI_NIF_Pasaporte")]
        [Required(ErrorMessage = "Debe indicar una identificacion para el usuario")]
        [StringLength(maximumLength: 20, ErrorMessage = "La identificacion del usuario no puede tener mas de 20 caracteres")]

        public String DNI_NIF_Pasaporte { get; set; }

        [Display(Prompt = "Escritura del hogar", Description = "Escritura del hogar", Name = "Escritura del hogar")]
        [Required(ErrorMessage = "Debe indicar una escritura del hogar del usuario")]
        [StringLength(maximumLength: 30, ErrorMessage = "La escritura del hogar del usuario no puede tener mas de 30 caracteres")]

        public String EscrituraHogar { get; set; }

        [Display(Prompt = "Justificante del pago", Description = "Justificante del pago", Name = "Justificante del pago")]
        [Required(ErrorMessage = "Debe indicar un justificante del pago")]
        [StringLength(maximumLength: 30, ErrorMessage = "El justificante de pago del usuario no puede tener mas de 30 caracteres")]

        public String JustificantePago { get; set; }
    }
}