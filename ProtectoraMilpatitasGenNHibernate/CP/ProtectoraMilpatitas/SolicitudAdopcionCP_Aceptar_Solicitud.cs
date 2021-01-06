
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



/*PROTECTED REGION ID(usingProtectoraMilpatitasGenNHibernate.CP.ProtectoraMilpatitas_SolicitudAdopcion_Aceptar_Solicitud) ENABLED START*/
//  references to other libraries
using System.Linq;
/*PROTECTED REGION END*/

namespace ProtectoraMilpatitasGenNHibernate.CP.ProtectoraMilpatitas
{
public partial class SolicitudAdopcionCP : BasicCP
{
public string Aceptar_Solicitud (int p_SolicitudAdopcion, string p_Usuario)
{
        /*PROTECTED REGION ID(ProtectoraMilpatitasGenNHibernate.CP.ProtectoraMilpatitas_SolicitudAdopcion_Aceptar_Solicitud) ENABLED START*/

        SolicitudAdopcionCAD solicitudAdopcionCAD = null;
        SolicitudAdopcionCEN solicitudAdopcionCEN = null;
        SolicitudAdopcionEN solicitudAdopcionEN = null;
        SolicitudAdopcionCP solicitudAdopcionCP = null;
        UsuarioCAD usuCAD = null;
        UsuarioCEN usuCEN = null;
        NotificacionCAD notiCAD = null;
        NotificacionCEN notiCEN = null;
        NotificacionEN notificacionEN = null;
        MensajeCAD mensaCAD = null;
        MensajeCEN mensaCEN = null;
        MensajeEN mensaEn = null;

        string result = "";

        try
        {
                SessionInitializeTransaction ();
                solicitudAdopcionCAD = new SolicitudAdopcionCAD (session);
                solicitudAdopcionCEN = new SolicitudAdopcionCEN (solicitudAdopcionCAD);
                solicitudAdopcionCP = new SolicitudAdopcionCP ();

                solicitudAdopcionEN = solicitudAdopcionCEN.Ver_Solicitud(p_SolicitudAdopcion);

                usuCAD = new UsuarioCAD (session);
                usuCEN = new UsuarioCEN (usuCAD);

                notiCAD = new NotificacionCAD (session);
                notiCEN = new NotificacionCEN (notiCAD);
                notificacionEN = new NotificacionEN ();

                mensaCAD = new MensajeCAD (session);
                mensaCEN = new MensajeCEN (mensaCAD);
                mensaEn = new MensajeEN ();

                ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas.EstadoAdopcionEnum anterior = solicitudAdopcionEN.Estado;

                IList<UsuarioEN> usuarios = usuCEN.Dame_Todos (0, -1);

                if (usuarios.Count () > 0) {
                        foreach (UsuarioEN usu in usuarios) {
                                if (usu.Email.Equals (p_Usuario)) {
                                        notificacionEN.Mensaje = "Solicitud Aceptada";
                                        mensaEn.Texto = "Solicitud aceptada";

                                        solicitudAdopcionCP.Actualizar_Estado (p_SolicitudAdopcion, ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas.EstadoAdopcionEnum.aceptado); //tiene que ser solicitudAdopcionCP

                                        notiCEN.Enviar (notificacionEN.Id, p_Usuario, mensaEn.Texto);

                                        if (anterior != solicitudAdopcionCEN.Ver_Solicitud (p_SolicitudAdopcion).Estado) {
                                                result = "La solicitud ha sido aceptada";
                                        }
                                        else{
                                                result = "Ha habido un error al aceptar la solicitud";
                                        }
                                }
                                else{
                                        notificacionEN.Mensaje = "Solicitud en espera";
                                        mensaEn.Texto = "Solicitud en espera";

                                        IList<SolicitudAdopcionEN> sols = solicitudAdopcionCEN.Obtener_Solicitud_Usuario (usu.Email);

                                        foreach (SolicitudAdopcionEN soli in sols) {
                                                if (soli.Animal.Id == solicitudAdopcionCEN.Ver_Solicitud (p_SolicitudAdopcion).Animal.Id) {
                                                        solicitudAdopcionCP.Actualizar_Estado (soli.Id, ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas.EstadoAdopcionEnum.enEspera);
                                                }
                                        }

                                        notiCEN.Enviar (notificacionEN.Id, p_Usuario, mensaEn.Texto);
                                }
                        }
                }



                SessionCommit ();
        }
        catch (Exception ex)
        {
                SessionRollBack ();

                result = "Ha habido un error al aceptar la solicitud";

                throw ex;
        }
        finally
        {
                SessionClose ();
        }

        return result;
        /*PROTECTED REGION END*/
}
}
}
