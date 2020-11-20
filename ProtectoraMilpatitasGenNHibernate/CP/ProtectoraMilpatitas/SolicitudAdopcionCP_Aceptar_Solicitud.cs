
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
public void Aceptar_Solicitud (int p_SolicitudAdopcion, string p_Usuario)
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
        bool entra = false;


        try
        {
                SessionInitializeTransaction ();
                solicitudAdopcionCAD = new SolicitudAdopcionCAD (session);
                solicitudAdopcionCEN = new SolicitudAdopcionCEN (solicitudAdopcionCAD);
                solicitudAdopcionCP = new SolicitudAdopcionCP ();
                solicitudAdopcionEN = new SolicitudAdopcionEN ();

                usuCAD = new UsuarioCAD (session);
                usuCEN = new UsuarioCEN (usuCAD);

                notiCAD = new NotificacionCAD (session);
                notiCEN = new NotificacionCEN (notiCAD);
                notificacionEN = new NotificacionEN ();

                mensaCAD = new MensajeCAD (session);
                mensaCEN = new MensajeCEN (mensaCAD);
                mensaEn = new MensajeEN ();



                IList<UsuarioEN> usuarios = usuCEN.Dame_Todos (0, -1);

                if (usuarios.Count () > 0) {
                        foreach (UsuarioEN usu in usuarios) {
                                if (usu.Email.Equals (p_Usuario)) {
                                        notificacionEN.Mensaje = "Solicitud Aceptada";
                                        mensaEn.Texto = "Solicitud aceptada";
                                        solicitudAdopcionEN.Estado = ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas.EstadoAdopcionEnum.aceptado;
                                        solicitudAdopcionCP.Actualizar_Estado (solicitudAdopcionEN.Id, solicitudAdopcionEN.Estado); //tiene que ser solicitudAdopcionCP
                                        notiCEN.Enviar (notificacionEN.Id, p_Usuario, mensaEn.Texto);
                                }
                                else{
                                        notificacionEN.Mensaje = "Solicitud Denegada";
                                        mensaEn.Texto = "Solicitud denegada";

                                        notiCEN.Enviar (notificacionEN.Id, p_Usuario, mensaEn.Texto);
                                        entra = true;
                                }
                        }
                }



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
