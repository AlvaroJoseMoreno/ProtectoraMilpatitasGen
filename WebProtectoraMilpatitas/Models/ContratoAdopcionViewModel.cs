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
        //[RegularExpression(" ^[a-zA-Z0-9]+[.]{1}[a-zA-Z0-9] + $", ErrorMessage = "El formato de fichero no es valido")]

        public String EscrituraHogar { get; set; }

        [Display(Prompt = "Justificante del pago", Description = "Justificante del pago", Name = "Justificante del pago")]
        [Required(ErrorMessage = "Debe indicar un justificante del pago")]
        [StringLength(maximumLength: 30, ErrorMessage = "El justificante de pago del usuario no puede tener mas de 30 caracteres")]
        //[RegularExpression(" ^[a - zA - Z0 - 9_\\.-] +[\\.]([a - zA - Z0 - 9 -] +\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "El formato de fichero no es valido")]

        public String JustificantePago { get; set; }

        [Display(Prompt = "Lugar de recojida", Description = "Lugar de recojida", Name = "Lugar de recojida")]
        [Required(ErrorMessage = "Debe indicar un lugar para recojer el animal")]
        [StringLength(maximumLength: 50, ErrorMessage = "El lugar no puede tener mas de 50 caracteres")]

        public String LugarRecojida { get; set; }

        [Display(Prompt = "Firma de compromiso", Description = "Firma de compromiso", Name = "Firma de compromiso")]
        [Required(ErrorMessage = "Debe indicar un lugar para recojer el animal")]

        public Boolean FirmaCompromiso { get; set; }

        [Display(Prompt = "Estado del contrato", Description = "Estado del contrato", Name = "Estado del contrato")]
        [Required(ErrorMessage = "Debe indicar un estado del contrato")]

        public ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas.EstadoContratoEnum Estado { get; set; }

        [ScaffoldColumn(false)]
        [Display(Prompt = "Usuario para el contrato", Description = "Usuario para el contrato", Name = "Usuario")]

        public string idUsuario { get; set; }

        [Display(Prompt = "Nombre del usuario", Description = "Nombre del usuario", Name = "Usuario")]
        public string NomUsuario { get; set; }

        [ScaffoldColumn(false)]
        [Display(Prompt = "Animal para el contrato", Description = "Animal para el contrato", Name = "Animal")]

        public int idAnimal { get; set; }

        [Display(Prompt = "Nombre del animal", Description = "Nombre del animal", Name = "Animal solicitado")]
        public string NomAnimal { get; set; }

        [ScaffoldColumn(false)]
        [Display(Prompt = "Solicitud para el contrato", Description = "Solicitud para el contrato", Name = "Solicitud")]

        public int idSolicitud { get; set; }
    }
}