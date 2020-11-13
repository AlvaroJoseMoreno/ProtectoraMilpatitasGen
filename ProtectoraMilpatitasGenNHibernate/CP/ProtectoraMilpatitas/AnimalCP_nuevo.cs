
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
using System.Linq;



/*PROTECTED REGION ID(usingProtectoraMilpatitasGenNHibernate.CP.ProtectoraMilpatitas_Animal_nuevo) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ProtectoraMilpatitasGenNHibernate.CP.ProtectoraMilpatitas
{
    public partial class AnimalCP : BasicCP
    {
        public ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.AnimalEN Nuevo(string p_nombre, int p_edad, char p_sexo, string p_centro, ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas.EstadoSaludEnum p_datosMedicos, string p_caracter)
        {
            /*PROTECTED REGION ID(ProtectoraMilpatitasGenNHibernate.CP.ProtectoraMilpatitas_Animal_nuevo) ENABLED START*/

            IAnimalCAD animalCAD = null;
            AnimalCEN animalCEN = null;

            UsuarioCAD usuCAD = null;
            UsuarioCEN usuCEN = null;

            NotificacionCAD notiCAD = null;
            NotificacionCEN notiCEN = null;
            NotificacionEN notificacionEN = null;
            MensajeCAD mensajeCAD = null;
            MensajeCEN mensajeCEN = null;

            ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.AnimalEN result = null;


            try
            {
                SessionInitializeTransaction();
                animalCAD = new AnimalCAD(session);
                animalCEN = new AnimalCEN(animalCAD);

                usuCAD = new UsuarioCAD(session);
                usuCEN = new UsuarioCEN(usuCAD);

                notiCAD = new NotificacionCAD(session);
                notiCEN = new NotificacionCEN(notiCAD);

                mensajeCAD = new MensajeCAD(session);
                mensajeCEN = new MensajeCEN(mensajeCAD);

                int oid;
                //Initialized AnimalEN
                AnimalEN animalEN;
                animalEN = new AnimalEN();
                animalEN.Nombre = p_nombre;

                animalEN.Edad = p_edad;

                animalEN.Sexo = p_sexo;

                animalEN.Centro = p_centro;

                animalEN.DatosMedicos = p_datosMedicos;

                animalEN.Caracter = p_caracter;

                notificacionEN = new NotificacionEN();
                notificacionEN.Mensaje = "Ha llegado" + animalEN.Nombre;

                IList<UsuarioEN> usuarios = usuCEN.Dame_Todos(0, -1);

                if (usuarios.Count() > 0)
                {
                    foreach (UsuarioEN usu in usuarios)
                    {
                        Console.WriteLine("hol k ase");
                        UsuarioEN usuen = usu;

                        //mensajeCEN = (MensajeCEN)usuen.MensajeChat;

                        MensajeCP mensajeCP = new MensajeCP(session);

                        //mensajeCP = (MensajeCP)usuen.MensajeChat;

                        MensajeEN mensajeEN = new MensajeEN();
                        mensajeCP.Responder(mensajeEN.Id, notificacionEN.Mensaje, usuen.Email);
                    }
                }

                //Call to AnimalCAD

                oid = animalCAD.Nuevo(animalEN);
                result = animalCAD.ReadOIDDefault(oid);



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
            return result;


            /*PROTECTED REGION END*/
        }
    }
}
