
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



/*PROTECTED REGION ID(usingProtectoraMilpatitasGenNHibernate.CP.ProtectoraMilpatitas_Mensaje_responder) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ProtectoraMilpatitasGenNHibernate.CP.ProtectoraMilpatitas
{
    public partial class MensajeCP : BasicCP
    {
        public void Responder(int p_Mensaje, string p_texto, string p_usuario)
        {
            /*PROTECTED REGION ID(ProtectoraMilpatitasGenNHibernate.CP.ProtectoraMilpatitas_Mensaje_responder) ENABLED START*/

            IMensajeCAD mensajeCAD = null;
            MensajeCEN mensajeCEN = null;

            try
            {
                SessionInitializeTransaction();
                mensajeCAD = new MensajeCAD(session);
                mensajeCEN = new MensajeCEN(mensajeCAD);

                MensajeEN mensajeEN = null;
                //Initialized MensajeEN
                mensajeEN = new MensajeEN();
                mensajeEN.Id = p_Mensaje;
                mensajeEN.Texto = p_texto;
                mensajeEN.Usuario.Email = p_usuario;
                //Call to MensajeCAD

                if (p_Mensaje != -1)
                {
                    NotificacionEN notificacionEN = new NotificacionEN();

                    if (p_texto != "")
                    {
                        notificacionEN.Mensaje = p_texto;
                        notificacionEN.Tipo = ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas.TipoNotificacionEnum.Chat;

                        NotificacionCAD notificacionCAD = new NotificacionCAD(session);

                        notificacionCAD.ModifyDefault(notificacionEN);

                        NotificacionCEN notificacionCEN = new NotificacionCEN(notificacionCAD);

                        notificacionCEN.Enviar(notificacionEN.Id, p_usuario, "Tienes un mensaje en el chat: " + p_texto);
                    }
                }

                mensajeCAD.Responder(mensajeEN);


                SessionCommit();
            }
            catch (Exception ex)
            {
                SessionRollBack();
                throw ex;
            }
            finally
            {
                SessionClose();
            }


            /*PROTECTED REGION END*/
        }
    }
}
