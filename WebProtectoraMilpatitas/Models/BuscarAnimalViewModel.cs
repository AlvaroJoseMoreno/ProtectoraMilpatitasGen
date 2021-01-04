using ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebProtectoraMilpatitas.Models
{
    public class BuscarAnimalViewModel
    {
        public String Nombre { get; set; }

        public int Edad { get; set; }

        public char Sexo { get; set; }

        public String Centro { get; set; }

        public String Caracter { get; set; }

        public ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas.EstadoSaludEnum DatosMedicos { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaLlegada { get; set; }

        public int idEspecie { get; set; }

        [ScaffoldColumn(false)]
        public int idBusEspecie { get; set; }

        public string NomEspecie { get; set; }

        public int idRaza { get; set; }

        [ScaffoldColumn(false)]
        public int idBusRaza { get; set; }

        public string NomRaza { get; set; }
    }
}