
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using System.Collections.Generic;
using ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas;
using ProtectoraMilpatitasGenNHibernate.CAD.ProtectoraMilpatitas;
using ProtectoraMilpatitasGenNHibernate.CEN.ProtectoraMilpatitas;



/*PROTECTED REGION ID(usingProtectoraMilpatitasGenNHibernate.CP.ProtectoraMilpatitas_SolicitudAdopcion_actualizar_Estado) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ProtectoraMilpatitasGenNHibernate.CP.ProtectoraMilpatitas
{
public partial class SolicitudAdopcionCP : BasicCP
{
public void Actualizar_Estado (int p_SolicitudAdopcion, ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas.EstadoAdopcionEnum p_estado)
{
        /*PROTECTED REGION ID(ProtectoraMilpatitasGenNHibernate.CP.ProtectoraMilpatitas_SolicitudAdopcion_actualizar_Estado) ENABLED START*/

        ISolicitudAdopcionCAD solicitudAdopcionCAD = null;
        SolicitudAdopcionCEN solicitudAdopcionCEN = null;



        try
        {
                SessionInitializeTransaction ();
                solicitudAdopcionCAD = new SolicitudAdopcionCAD (session);
                solicitudAdopcionCEN = new SolicitudAdopcionCEN (solicitudAdopcionCAD);

                ContratoAdopcionCAD conCAD = new ContratoAdopcionCAD (session);
                ContratoAdopcionCEN conCEN = new ContratoAdopcionCEN (conCAD);


                SolicitudAdopcionEN solicitudAdopcionEN = null;
                //Initialized SolicitudAdopcionEN
                solicitudAdopcionEN = solicitudAdopcionCEN.Ver_Solicitud (p_SolicitudAdopcion);
                //solicitudAdopcionEN.Id = p_SolicitudAdopcion;
                solicitudAdopcionEN.Estado = p_estado;
                //Call to SolicitudAdopcionCAD

                if (solicitudAdopcionEN.Estado == ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas.EstadoAdopcionEnum.aceptado) {
                        solicitudAdopcionEN.Animal.EstadoAdopcion = ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas.EstadoAnimalAdopcionEnum.EnContrato;

                        conCEN.Nuevo (solicitudAdopcionEN.Usuario.Email, solicitudAdopcionEN.Id, solicitudAdopcionEN.Animal.Id);
                }
                else{
                        if (solicitudAdopcionEN.Estado == ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas.EstadoAdopcionEnum.enEspera) {
                                solicitudAdopcionEN.Animal.EstadoAdopcion = ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas.EstadoAnimalAdopcionEnum.EnSolicitud;
                        }
                }

                solicitudAdopcionCAD.Actualizar_Estado (solicitudAdopcionEN);


                SessionCommit ();
        }
        catch (Exception ex)
        {
                SessionRollBack ();
                throw ex;
        }
        finally
        {
                SessionClose ();
        }


        /*PROTECTED REGION END*/
}
}
}
