
using System;
using System.Text;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using ProtectoraMilpatitasGenNHibernate.Exceptions;
using ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas;
using ProtectoraMilpatitasGenNHibernate.CAD.ProtectoraMilpatitas;
using System.Net.Mail;
using System.Net;


/*PROTECTED REGION ID(usingProtectoraMilpatitasGenNHibernate.CEN.ProtectoraMilpatitas_Notificacion_enviar) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ProtectoraMilpatitasGenNHibernate.CEN.ProtectoraMilpatitas
{
public partial class NotificacionCEN
{
public void Enviar (int p_Notificacion, string p_usuario, string p_mensaje)
{
            /*PROTECTED REGION ID(ProtectoraMilpatitasGenNHibernate.CEN.ProtectoraMilpatitas_Notificacion_enviar) ENABLED START*/

            string usuario, contraseña, destinatario, asunto, mensaje;

            Console.WriteLine("\t\t----------------------------------------");
            Console.WriteLine("\t\t\tEnviar Correo Electronico");
            Console.WriteLine("\t\t----------------------------------------");


            Console.WriteLine("\n");
            Console.Write("\t\tIngresa tu correo electornico: ");
            usuario = Console.ReadLine();
            Console.Write("\t\tIngresa tu password: ");
            contraseña = Console.ReadLine();
            Console.Write("\t\tDestinatario: ");
            destinatario = Console.ReadLine();
            Console.Write("\t\tAsunto: ");
            asunto = Console.ReadLine();
            Console.Write("\t\tMensaje: ");
            mensaje = Console.ReadLine();

            MailMessage correo = new MailMessage(usuario, destinatario, asunto, mensaje);

            SmtpClient servidor = new SmtpClient("smtp.live.com",
            NetworkCredential credenciales = new NetworkCredential(usuario, contraseña);
            servidor.Credentials = credenciales;
            servidor.EnableSsl = true;

            try
            {
                servidor.Send(correo);
                Console.WriteLine("\t\tCorreo enviado de manera exitosa");
                correo.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            /*PROTECTED REGION END*/
        }
}
}
