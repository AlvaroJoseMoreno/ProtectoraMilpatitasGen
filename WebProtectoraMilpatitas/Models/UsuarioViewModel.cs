using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebProtectoraMilpatitas.Models
{
    public class UsuarioViewModel
    {
        
        [Display(Prompt = "Nombre del usuario", Description = "Nombre de usuario", Name = "Nombre")]
        [Required(ErrorMessage = "Debe usar un nombre de usuario")]
        [Range(minimum: 8, maximum: 20, ErrorMessage = "El nombre tiene que tener entre 8 y 20 caracteres")]
        public String Nombre { get; set; }

        [Display(Prompt = "Email de usuario", Description = "Email de usuario", Name = "E-mail")]
        [Required(ErrorMessage = "Debe usar un email para registrarte")]
        [Range(minimum: 30, maximum: 254, ErrorMessage = "El e-mail tiene que tener entre 8 y 20 caracteres")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail no valido")]
        public String Email { get; set; }

        [Display(Prompt = "Password", Description = "Password de usuario", Name = "Password")]
        [Required(ErrorMessage = "Debe usar password")]
        [Range(minimum: 8, maximum: 15, ErrorMessage = "El password tiene que tener entre 8 y 15 caracteres")]
      //  [RegularExpression("" , ErrorMessage = "Password invalido")]
        public String Password { get; set; }
    }
}