
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


/*PROTECTED REGION ID(usingProtectoraMilpatitasGenNHibernate.CEN.ProtectoraMilpatitas_Notificacion_enviar) ENABLED START*/
//  references to other libraries
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
/*PROTECTED REGION END*/

namespace ProtectoraMilpatitasGenNHibernate.CEN.ProtectoraMilpatitas
{
public partial class NotificacionCEN
{
public void Enviar (int p_Notificacion, string p_usuario, string p_mensaje)
{
        /*PROTECTED REGION ID(ProtectoraMilpatitasGenNHibernate.CEN.ProtectoraMilpatitas_Notificacion_enviar) ENABLED START*/

        AdministradorCEN adminCEN = new AdministradorCEN ();

        IList<AdministradorEN> admins = adminCEN.Dame_Todos (0, -1);

        if (admins.Count () > 0) {
                AdministradorEN adminEN = admins [0];
                MailMessage correo = new MailMessage ();
                correo.From = new MailAddress (adminEN.Email, "Protectora Milpatitas", System.Text.Encoding.UTF8); //Correo de salida
                correo.To.Add (p_usuario); //Correo destino?
                correo.Subject = "Correo de prueba"; //Asunto
                correo.Body = p_mensaje; //Mensaje del correo
                correo.IsBodyHtml = true;
                correo.Priority = MailPriority.Normal;
                SmtpClient smtp = new SmtpClient ();
                smtp.UseDefaultCredentials = false;
                smtp.Host = "smtp.gmail.com"; //Host del servidor de correo
                smtp.Port = 25; //Puerto de salida
                smtp.Credentials = new System.Net.NetworkCredential (adminEN.Email, "josemanuel25"); //Cuenta de correo
                ServicePointManager.ServerCertificateValidationCallback = delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
                smtp.EnableSsl = true; //True si el servidor de correo permite ssl
                smtp.Send (correo);
        }
        else{
                throw new ModelException ("No hay administradores");
        }

        /*PROTECTED REGION END*/
}
}
}
