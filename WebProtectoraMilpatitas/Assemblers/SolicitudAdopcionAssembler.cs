using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas;
using WebProtectoraMilpatitas.Models;

namespace WebProtectoraMilpatitas.Assemblers
{
    public class SolicitudAdopcionAssembler
    {
        public SolicitudAdopcionViewModel ConvertENToModelUI(SolicitudAdopcionEN soli)
        {
            SolicitudAdopcionViewModel solicitud = new SolicitudAdopcionViewModel();
            solicitud.Id = soli.Id;
            solicitud.Nombre = soli.Nombre;
            solicitud.AnimalesAcargo = soli.AnimalesAcargo;
            solicitud.AmbienteConvivencia = soli.AmbienteConvivencia;
            solicitud.TiempoLibre = soli.TiempoLibre;
            solicitud.TodosAcuerdo = soli.TodosAcuerdo;
            solicitud.MotivosAdopcion = soli.MotivosAdopcion;
            solicitud.Estado = soli.Estado;

        if (soli.Usuario != null) {    
            solicitud.idUsuario = soli.Usuario.Email;
            solicitud.NomUsuario = soli.Usuario.Nombre;
            solicitud.FotoUsuario = soli.Usuario.Foto;
        }
            if (soli.Animal != null)
            {
                solicitud.idAnimal = soli.Animal.Id;
                solicitud.NomAnimal = soli.Animal.Nombre;
                solicitud.FotoAnimal = soli.Animal.Foto;
            }

        if (soli.ContratoAdopcion != null) { 
            solicitud.idContrato = soli.ContratoAdopcion.Id; 
        }

            solicitud.FechaSoli = (DateTime)soli.FechaSolicitud;

            return solicitud;
        }

        public IList<SolicitudAdopcionViewModel> ConvertListENToModel(IList<SolicitudAdopcionEN> solis)
        {
            IList<SolicitudAdopcionViewModel> solicitudes = new List<SolicitudAdopcionViewModel>();

            foreach (SolicitudAdopcionEN sol in solis)
            {
                solicitudes.Add(ConvertENToModelUI(sol));
            }
            return solicitudes;
        }
    }
}