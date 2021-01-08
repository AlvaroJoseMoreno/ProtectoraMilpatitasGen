﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebProtectoraMilpatitas.Models
{
    public class MensajeViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [ScaffoldColumn(false)]
        [Display(Prompt = "Texto", Description = "Texto del mensaje", Name = "Texto")]
        public String Texto { get; set; }

        [ScaffoldColumn(false)]
        [Display(Prompt = "Fecha", Description = "Fecha del mensaje", Name = "Fecha")]
        public DateTime? Fecha { get; set; }

        [ScaffoldColumn(false)]
        [Display(Prompt = "Enviado", Description = "Usuario que envia el mensaje", Name = "Enviado por")]
        public String Enviador { get; set; }

        [ScaffoldColumn(false)]
        public String Usuario { get; set; }

        [ScaffoldColumn(false)]
        public String Administrador { get; set; }



    }
}