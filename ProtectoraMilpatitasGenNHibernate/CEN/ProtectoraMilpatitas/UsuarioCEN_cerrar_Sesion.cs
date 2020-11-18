
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


/*PROTECTED REGION ID(usingProtectoraMilpatitasGenNHibernate.CEN.ProtectoraMilpatitas_Usuario_cerrar_Sesion) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ProtectoraMilpatitasGenNHibernate.CEN.ProtectoraMilpatitas
{
public partial class UsuarioCEN
{
public string Cerrar_Sesion (string p_email)
{
        /*PROTECTED REGION ID(ProtectoraMilpatitasGenNHibernate.CEN.ProtectoraMilpatitas_Usuario_cerrar_Sesion) ENABLED START*/

        // Write here your custom code...

        string result = null;
        UsuarioEN en = _IUsuarioCAD.ReadOIDDefault (p_email);

        if (en != null)
                result = "Se ha cerrado la sesi�n del usuario: " + this.GetToken (en.Email);

        return result;

        /*PROTECTED REGION END*/
}
}
}
