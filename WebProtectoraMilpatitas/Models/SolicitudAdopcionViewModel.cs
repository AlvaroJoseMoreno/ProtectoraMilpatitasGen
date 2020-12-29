using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebProtectoraMilpatitas.Models
{
    public class SolicitudAdopcionViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Prompt = "Nombre del solicitante", Description = "Nombre del solicitante", Name = "Nombre")]
        [Required(ErrorMessage = "Debe indicar un nombre para el solicitante")]
        [StringLength(maximumLength: 50, ErrorMessage = "El nombre del solicitante no puede superar los 50 caracteres")]

        public String Nombre { get; set; }

        [Display(Prompt = "Animales a cargo", Description = "Animales a cargo", Name = "AnimalesAcargo")]
        [Required(ErrorMessage = "Debe indicar los animales que tiene a cargo")]
        [Range(minimum: 0, maximum: 50, ErrorMessage = "El número de animales tiene que estar entre 0 y 50")]

        public int AnimalesAcargo { get; set; }

        [Display(Prompt = "AmbienteConvivencia", Description = "Ambiente de convivencia", Name = "AmbienteConvivencia")]
        [Required(ErrorMessage = "Debe indicar un ambiente de convivencia")]
        [StringLength(maximumLength: 100, ErrorMessage = "La descripción no puede superar los 100 caracteres")]

        public String AmbienteConvivencia { get; set; }

        [Display(Prompt = "TiempoLibre", Description = "Tiempo libre al día para dedicar al animal", Name = "TiempoLibre")]
        [Required(ErrorMessage = "Debe indicar un número de horas")]
        [Range(minimum: 0, maximum: 24, ErrorMessage = "El número de horas libres al día tiene que estar entre 0 y 24 horas ")]

        public int TiempoLibre { get; set; }

        [Display(Prompt = "TodosAcuerdo", Description = "Todos están de acuerdo", Name = "TodosAcuerdo")]
        [Required(ErrorMessage = "Debe indicar si están todos de acuerdo o no")]

        public Boolean TodosAcuerdo { get; set; }

        [Display(Prompt = "MotivosAdopcion", Description = "Motivos de la adopción", Name = "MotivosAdopcion")]
        [Required(ErrorMessage = "Debe indicar un motivo mínimo para adoptar")]
        [StringLength(maximumLength: 100, ErrorMessage = "La descripción del motivo no puede superar los 100 caracteres")]

        public String MotivosAdopcion { get; set; }


        [Display(Prompt = "Estado de solicitud", Description = "Estado de solicitud animal", Name = "Estado de solicitud")]
        [Required(ErrorMessage = "Debe indicar un estado de solicitud de animal")]

        public ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas.EstadoAdopcionEnum Estado { get; set; }

        [ScaffoldColumn(false)]

        [Display(Prompt = "Usuario solicitante", Description = "Usuario que solicita adopción", Name = "Usuario")]

        public string idUsuario { get; set; }

        [Display(Prompt = "Nombre del usuario", Description = "Nombre del usuario", Name = "Usuario")]
        public string NomUsuario { get; set; }

        [ScaffoldColumn(false)]

        [Display(Prompt = "Animal Solicitado", Description = "Animal que solicitan en adopción", Name = "Animal")]

        public int idAnimal { get; set; }

        [Display(Prompt = "Nombre del animal", Description = "Nombre del animal", Name = "Animal solicitado")]
        public string NomAnimal { get; set; }

        [Display(Prompt = "Fecha solicitud", Description = "Fecha solicitud", Name = "Fecha solicitud")]
        public DateTime FechaSoli { get; set; }
    }
}