using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace WebProtectoraMilpatitas.Models
{
    public class SeguimientoViewModel
    {
        [ScaffoldColumn(false)]
        public int  Id { get; set; }

        [ScaffoldColumn(false)]
        [Display(Prompt = "Usuario", Description = "Usuario", Name = "Usuario")]
        public String Usuario { get; set; }

        [ScaffoldColumn(false)]
        [Display(Prompt = "Animal", Description = "Animal", Name = "Animal")]
        public int Animal { get; set; }


        [ScaffoldColumn(false)]
        [Display(Prompt = "Contrato Adopcion", Description = "Contrato Adopcion", Name = "Contrato Adopcion")]
        public int Contrato { get; set; }


        [Display(Prompt = "Estado de seguimiento", Description = "Estado de segumiento del animal", Name = "Estado de seguimiento")]
        [Required(ErrorMessage = "Debe indicar un estado de seguimiento de animal")]

        public ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas.EstadoSeguimientoEnum Estado { get; set; }


        [Display(Prompt = "Fecha", Description = "Fecha del ultimo seguimiento", Name = "Fecha")]
        [Required(ErrorMessage = "Debe indicar una fecha valida")]

        public Nullable<DateTime> Fecha { get; set; }

    }

   
}