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

        [Display(Prompt = "Email de usuario", Description = "Email de usuario", Name = "E-mail")]
        [Required(ErrorMessage = "Debe usar un email para registrarte")]
        [StringLength(maximumLength: 254, ErrorMessage = "El e-mail tiene que tener menos de 254 caracteres")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail no valido")]
        public string Email { get; set; }

        [Display(Prompt = "Password", Description = "Password de usuario", Name = "Password")]
        [Required(ErrorMessage = "Debe usar password")]
        [StringLength(maximumLength: 15, ErrorMessage = "El password tiene que tener menos de 15 caracteres")]
        
      //  [RegularExpression("" , ErrorMessage = "Password invalido")]
        public string Password { get; set; }
    }
}