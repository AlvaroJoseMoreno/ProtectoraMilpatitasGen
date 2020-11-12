
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


/*PROTECTED REGION ID(usingProtectoraMilpatitasGenNHibernate.CEN.ProtectoraMilpatitas_ContratoAdopcion_nuevo) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ProtectoraMilpatitasGenNHibernate.CEN.ProtectoraMilpatitas
{
public partial class ContratoAdopcionCEN
{
public int Nuevo (string p_usuario, int p_solicitudAdopcion, int p_animal)
{
        /*PROTECTED REGION ID(ProtectoraMilpatitasGenNHibernate.CEN.ProtectoraMilpatitas_ContratoAdopcion_nuevo_customized) START*/

        ContratoAdopcionEN contratoAdopcionEN = null;

        int oid;

        //Initialized ContratoAdopcionEN
        contratoAdopcionEN = new ContratoAdopcionEN ();

        if (p_usuario != null) {
                contratoAdopcionEN.Usuario = new ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.UsuarioEN ();
                contratoAdopcionEN.Usuario.Email = p_usuario;
        }


        if (p_solicitudAdopcion != -1) {
                contratoAdopcionEN.SolicitudAdopcion = new ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.SolicitudAdopcionEN ();
                contratoAdopcionEN.SolicitudAdopcion.Id = p_solicitudAdopcion;
        }


        if (p_animal != -1) {
                contratoAdopcionEN.Animal = new ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.AnimalEN ();
                contratoAdopcionEN.Animal.Id = p_animal;
        }

        //Call to ContratoAdopcionCAD

        oid = _IContratoAdopcionCAD.Nuevo (contratoAdopcionEN);
        return oid;
        /*PROTECTED REGION END*/
}
}
}
