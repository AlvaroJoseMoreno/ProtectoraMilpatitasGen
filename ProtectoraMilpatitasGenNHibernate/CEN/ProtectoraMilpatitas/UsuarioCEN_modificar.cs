
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


/*PROTECTED REGION ID(usingProtectoraMilpatitasGenNHibernate.CEN.ProtectoraMilpatitas_Usuario_modificar) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ProtectoraMilpatitasGenNHibernate.CEN.ProtectoraMilpatitas
{
public partial class UsuarioCEN
{
public void Modificar (string p_Usuario_OID, string p_nombre, String p_password, string p_foto)
{
        /*PROTECTED REGION ID(ProtectoraMilpatitasGenNHibernate.CEN.ProtectoraMilpatitas_Usuario_modificar_customized) ENABLED START*/

        UsuarioEN usuarioEN = null;

        //Initialized UsuarioEN
        usuarioEN = new UsuarioEN ();
        usuarioEN.Email = p_Usuario_OID;
        usuarioEN.Nombre = p_nombre;
        usuarioEN.Password = Utils.Util.GetEncondeMD5 (p_password);
        usuarioEN.Foto = p_foto;

        if (p_foto != null) {
                string[] fotoAnim = p_foto.Split ('/');
                if (fotoAnim.Length == 3) {
                        if (fotoAnim [2].Equals ("")) {
                                UsuarioCEN anicen = new UsuarioCEN ();
                                UsuarioEN anien = anicen.Dame_Por_Email (p_Usuario_OID);
                                usuarioEN.Foto = anien.Foto;
                        }
                        else{
                                usuarioEN.Foto = p_foto;
                        }
                }
        }
        //Call to UsuarioCAD

        _IUsuarioCAD.Modificar (usuarioEN);

        /*PROTECTED REGION END*/
}
}
}
