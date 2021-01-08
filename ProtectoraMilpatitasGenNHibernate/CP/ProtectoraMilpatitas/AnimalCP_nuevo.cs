
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



/*PROTECTED REGION ID(usingProtectoraMilpatitasGenNHibernate.CP.ProtectoraMilpatitas_Animal_nuevo) ENABLED START*/
//  references to other libraries
using System.Linq;
using ProtectoraMilpatitasGenNHibernate.Exceptions;
/*PROTECTED REGION END*/

namespace ProtectoraMilpatitasGenNHibernate.CP.ProtectoraMilpatitas
{
public partial class AnimalCP : BasicCP
{
public ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.AnimalEN Nuevo (string p_nombre, int p_edad, char p_sexo, string p_centro, ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas.EstadoSaludEnum p_datosMedicos, string p_caracter, int p_especie, string p_foto, Nullable<DateTime> p_fechaLlegada, int p_raza)
{
        /*PROTECTED REGION ID(ProtectoraMilpatitasGenNHibernate.CP.ProtectoraMilpatitas_Animal_nuevo) ENABLED START*/

        IAnimalCAD animalCAD = null;
        AnimalCEN animalCEN = null;

        UsuarioCAD usuCAD = null;
        UsuarioCEN usuCEN = null;

        NotificacionCAD notiCAD = null;
        NotificacionCEN notiCEN = null;
        NotificacionEN notificacionEN = null;

        AdministradorCEN adminCEN = new AdministradorCEN ();

        ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.AnimalEN result = null;


        try
        {
                SessionInitializeTransaction ();
                animalCAD = new AnimalCAD (session);
                animalCEN = new AnimalCEN (animalCAD);

                usuCAD = new UsuarioCAD (session);
                usuCEN = new UsuarioCEN (usuCAD);

                notiCAD = new NotificacionCAD (session);
                notiCEN = new NotificacionCEN (notiCAD);

                int oid;
                //Initialized AnimalEN
                AnimalEN animalEN;
                animalEN = new AnimalEN ();
                animalEN.Nombre = p_nombre;

                animalEN.Edad = p_edad;

                animalEN.Sexo = p_sexo;

                animalEN.Centro = p_centro;

                animalEN.DatosMedicos = p_datosMedicos;

                animalEN.Caracter = p_caracter;

                animalEN.EstadoAdopcion = ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas.EstadoAnimalAdopcionEnum.SinTramite;

                animalEN.Especie = new EspecieCEN ().Dame_Por_Id (p_especie);

                animalEN.Foto = p_foto;

                animalEN.FechaLlegada = p_fechaLlegada;

                animalEN.Raza = new RazaCEN ().Dame_Por_Id (p_raza);

                notificacionEN = new NotificacionEN ();
                notificacionEN.Mensaje = "Ha llegado " + animalEN.Nombre;

                IList<UsuarioEN> usuarios = usuCEN.Dame_Todos (0, -1);

                IList<AdministradorEN> admins = adminCEN.Dame_Todos (0, -1);

                if (admins.Count () > 0) {
                        AdministradorEN adminEN = admins [0];

                        if (usuarios.Count () > 0) {
                                foreach (UsuarioEN usu in usuarios) {
                                        if ((usu is AdministradorEN) == false) {
                                                UsuarioEN usuen = usu;

                                                Console.WriteLine (notificacionEN.Mensaje);
                                                Console.WriteLine ("Correo enviado a : " + usuen.Nombre);
                                                MensajeCP mensajeCP = new MensajeCP (session);

                                                MensajeCEN mensajeCEN = new MensajeCEN ();

                                                MensajeEN men = mensajeCP.Nuevo (adminEN.Email, usuen.Email, notificacionEN.Mensaje, DateTime.Now, adminEN.Nombre);
                                        }
                                }
                        }
                        else{
                                throw new ModelException ("No hay usuarios a los que avisar");
                        }
                }
                else{
                        throw new ModelException ("No hay administradores que avisen");
                }

                //Call to AnimalCAD

                oid = animalCAD.Nuevo (animalEN);
                result = animalCAD.ReadOIDDefault (oid);

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
        return result;


        /*PROTECTED REGION END*/
}
}
}
