﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas;
using WebProtectoraMilpatitas.Models;

namespace WebProtectoraMilpatitas.Assemblers
{
    public class ContratoAdopcionAssembler
    {
        public ContratoAdopcionViewModel ConvertENToModelUI(ContratoAdopcionEN con)
        {
            ContratoAdopcionViewModel contrato = new ContratoAdopcionViewModel();
            contrato.Id = con.Id;
            contrato.Nombre = con.Nombre;
            contrato.DNI_NIF_Pasaporte = con.DNI_NIF_Pasaporte;
            contrato.EscrituraHogar = con.EscrituraHogar;
            contrato.JustificantePago = con.JustificantePago;
            contrato.LugarRecojida = con.LugarRecojida;
            contrato.FirmaCompromiso = con.FirmaCompromiso;
            contrato.Estado = con.Estado;

            contrato.idUsuario = con.Usuario.Email;
            contrato.NomUsuario = con.Usuario.Nombre;
            contrato.FotoUsuario = con.Usuario.Foto;

            contrato.idAnimal = con.Animal.Id;
            if (con.Animal.Nombre != null)
            {
                contrato.NomAnimal = con.Animal.Nombre;
            }
                contrato.FotoAnimal = con.Animal.Foto;

            contrato.idSolicitud = con.SolicitudAdopcion.Id;

            return contrato;
        }

        public IList<ContratoAdopcionViewModel> ConvertListENToModel(IList<ContratoAdopcionEN> conts)
        {
            IList<ContratoAdopcionViewModel> contratos = new List<ContratoAdopcionViewModel>();

            foreach (ContratoAdopcionEN con in conts)
            {
                contratos.Add(ConvertENToModelUI(con));
            }
            return contratos;
        }
    }
}