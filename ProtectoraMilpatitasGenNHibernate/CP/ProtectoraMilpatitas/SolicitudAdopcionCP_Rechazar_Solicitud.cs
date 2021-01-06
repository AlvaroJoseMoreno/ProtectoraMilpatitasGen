
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



/*PROTECTED REGION ID(usingProtectoraMilpatitasGenNHibernate.CP.ProtectoraMilpatitas_SolicitudAdopcion_Rechazar_Solicitud) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ProtectoraMilpatitasGenNHibernate.CP.ProtectoraMilpatitas
{
public partial class SolicitudAdopcionCP : BasicCP
{
public string Rechazar_Solicitud (int p_SolicitudAdopcion, string p_Usuario)
{
        /*PROTECTED REGION ID(ProtectoraMilpatitasGenNHibernate.CP.ProtectoraMilpatitas_SolicitudAdopcion_Rechazar_Solicitud) ENABLED START*/

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

                ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas.EstadoAdopcionEnum anterior = solicitudAdopcionEN.Estado;

                usuCAD = new UsuarioCAD (session);
                usuCEN = new UsuarioCEN (usuCAD);

                notiCAD = new NotificacionCAD (session);
                notiCEN = new NotificacionCEN (notiCAD);
                notificacionEN = new NotificacionEN ();

                mensaCAD = new MensajeCAD (session);
                mensaCEN = new MensajeCEN (mensaCAD);
                mensaEn = new MensajeEN ();


                notificacionEN.Mensaje = "Solicitud Denegada";
                mensaEn.Texto = "Solicitud denegada";

                solicitudAdopcionCP.Actualizar_Estado (p_SolicitudAdopcion, ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas.EstadoAdopcionEnum.rechazado);

                if (anterior!=solicitudAdopcionCEN.Ver_Solicitud(p_SolicitudAdopcion).Estado)
                {
                    result = "La solicitud ha sido rechazada";
                } else
                {
                    result = "Ha habido un error al rechazar la solicitud";
                }

                notiCEN.Enviar (notificacionEN.Id, p_Usuario, mensaEn.Texto);


                SessionCommit ();
        }
        catch (Exception ex)
        {
                SessionRollBack ();

                result = "Ha habido un error al rechazar la solicitud";

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
