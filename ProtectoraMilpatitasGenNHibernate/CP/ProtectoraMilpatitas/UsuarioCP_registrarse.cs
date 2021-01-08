
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



/*PROTECTED REGION ID(usingProtectoraMilpatitasGenNHibernate.CP.ProtectoraMilpatitas_Usuario_registrarse) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ProtectoraMilpatitasGenNHibernate.CP.ProtectoraMilpatitas
{
public partial class UsuarioCP : BasicCP
{
public ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.UsuarioEN Registrarse (string p_nombre, string p_email, String p_password, string p_foto)
{
        /*PROTECTED REGION ID(ProtectoraMilpatitasGenNHibernate.CP.ProtectoraMilpatitas_Usuario_registrarse) ENABLED START*/

        IUsuarioCAD usuarioCAD = null;
        UsuarioCEN usuarioCEN = null;

        ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.UsuarioEN result = null;


        try
        {
                SessionInitializeTransaction ();
                usuarioCAD = new UsuarioCAD (session);
                usuarioCEN = new  UsuarioCEN (usuarioCAD);




                string oid;
                //Initialized UsuarioEN
                UsuarioEN usuarioEN;
                usuarioEN = new UsuarioEN ();
                usuarioEN.Nombre = p_nombre;

                usuarioEN.Email = p_email;

                usuarioEN.Password = Utils.Util.GetEncondeMD5 (p_password);

                usuarioEN.Foto = p_foto;

                //Call to UsuarioCAD

                oid = usuarioCAD.Registrarse (usuarioEN);

                AdministradorEN admin = new AdministradorCEN().Dame_Todos(0, -1)[0];

                MensajeEN men = new MensajeCP().Nuevo(admin.Email, oid, "Hola nuevo usuario " + usuarioEN.Nombre, DateTime.Now);

                result = usuarioCAD.ReadOIDDefault (oid);



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
