using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebProtectoraMilpatitas.Models
{
    public class AnimalViewModel
    {
        [ScaffoldColumn(false)]
        public int Id
        {
            get;set;
        }

        [Display(Prompt = "Descripcion del animal", Description= "Descripcion del animal", Name = "Descripcion")]
        [Required (ErrorMessage =  "Debe indicar un nombre para el animal")]
        [StringLength (maximumLength: 50, ErrorMessage ="El nombre del animal no puede tener mas de 50 caracteres")]
    
        public String Nombre { get; set; }

        

    }
}