﻿using System;
using System.Collections.Generic;
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

        public String AnimalesAcargo{ get; set; }

        [Display(Prompt = "AmbienteConvivencia", Description = "Ambiente de convivencia", Name = "AmbienteConvivencia")]
        [Required(ErrorMessage = "Debe indicar un ambiente de convivencia")]
        [StringLength(maximumLength: 100, ErrorMessage = "La descripción no puede superar los 100 caracteres")]

        public int AmbienteConvivencia { get; set; }

        [Display(Prompt = "TiempoLibre", Description = "Tiempo libre al día para dedicar al animal", Name = "TiempoLibre")]
        [Required(ErrorMessage = "Debe indicar un número de horas")]
        [Range(minimum: 0, maximum: 24, ErrorMessage = "El número de horas libres al día tiene que estar entre 0 y 24 horas ")]

        public String TiempoLibre { get; set; }

        [Display(Prompt = "TodosAcuerdo", Description = "Todos están de acuerdo", Name = "TodosAcuerdo")]
        [Required(ErrorMessage = "Debe indicar si están todos de acuerdo o no")]

        public Boolean TodosAcuerdo{ get; set; }

        [Display(Prompt = "MotivosAdopcion", Description = "Motivos de la adopción", Name = "MotivosAdopcion")]
        [Required(ErrorMessage = "Debe indicar un motivo mínimo para adoptar")]
        [StringLength(maximumLength: 100, ErrorMessage = "La descripción del motivo no puede superar los 100 caracteres")]

        public String TiempoLibre { get; set; }


        [Display(Prompt = "Estado de solicitud", Description = "Estado de solicitud animal", Name = "Estado de solicitud")]
        [Required(ErrorMessage = "Debe indicar un estado de solicitud de animal")]

        public ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas.EstadoSolicitudEnum EstadoSolicitud { get; set; }

    }
}

    }
}