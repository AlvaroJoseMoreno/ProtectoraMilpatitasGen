using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebProtectoraMilpatitas.Models
{
    public class UsuarioViewModel : RegisterViewModel
    {
        
        [Display(Prompt = "Nombre del usuario", Description = "Nombre de usuario", Name = "Nombre")]
        [Required(ErrorMessage = "Debe usar un nombre de usuario")]
        //preguntar como poner un rango minimo en string
        [StringLength(maximumLength: 20, ErrorMessage = "El nombre tiene que tener entre 8 y 20 caracteres")]
        public string Nombre { get; set; }

     //   [Display(Prompt = "Foto de perfil", Description = "Foto de perfil", Name = "foto")]
       // [Required(ErrorMessage = "Debe seleccionar una foto para el perfil del usuario")]


        public String Foto { get; set; }
    }
}