
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



/*PROTECTED REGION ID(usingProtectoraMilpatitasGenNHibernate.CP.ProtectoraMilpatitas_Mensaje_nuevo) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ProtectoraMilpatitasGenNHibernate.CP.ProtectoraMilpatitas
{
public partial class MensajeCP : BasicCP
{
public ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.MensajeEN Nuevo (string p_administrador, string p_usuario, string p_texto, Nullable<DateTime> p_fecha)
{
        /*PROTECTED REGION ID(ProtectoraMilpatitasGenNHibernate.CP.ProtectoraMilpatitas_Mensaje_nuevo) ENABLED START*/

        IMensajeCAD mensajeCAD = null;
        MensajeCEN mensajeCEN = null;

        ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.MensajeEN result = null;


        try
        {
                SessionInitializeTransaction ();
                mensajeCAD = new MensajeCAD (session);
                mensajeCEN = new  MensajeCEN (mensajeCAD);




                int oid;
                //Initialized MensajeEN
                MensajeEN mensajeEN;
                mensajeEN = new MensajeEN ();

                if (p_administrador != null) {
                        mensajeEN.Administrador = new ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.AdministradorEN ();
                        mensajeEN.Administrador.Email = p_administrador;
                }


                if (p_usuario != null) {
                        mensajeEN.Usuario = new ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.UsuarioEN ();
                        mensajeEN.Usuario.Email = p_usuario;
                }

                mensajeEN.Texto = p_texto;

                mensajeEN.Fecha = p_fecha;

                //Call to MensajeCAD

                oid = mensajeCAD.Nuevo (mensajeEN);
                mensajeCEN.AsignarUsuario (oid, p_usuario);
                mensajeCEN.AsignarAdministrador (oid, p_administrador);
                result = mensajeCAD.ReadOIDDefault (oid);



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
