
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


/*PROTECTED REGION ID(usingProtectoraMilpatitasGenNHibernate.CEN.ProtectoraMilpatitas_Seguimiento_nuevo) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ProtectoraMilpatitasGenNHibernate.CEN.ProtectoraMilpatitas
{
public partial class SeguimientoCEN
{
public int Nuevo (string p_usuario, int p_animal, int p_contratoAdopcion)
{
        /*PROTECTED REGION ID(ProtectoraMilpatitasGenNHibernate.CEN.ProtectoraMilpatitas_Seguimiento_nuevo_customized) START*/

        SeguimientoEN seguimientoEN = null;

        int oid;

        //Initialized SeguimientoEN
        seguimientoEN = new SeguimientoEN ();

        if (p_usuario != null) {
                seguimientoEN.Usuario = new ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.UsuarioEN ();
                seguimientoEN.Usuario.Email = p_usuario;
        }


        if (p_animal != -1) {
                seguimientoEN.Animal = new ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.AnimalEN ();
                seguimientoEN.Animal.Id = p_animal;
        }


        if (p_contratoAdopcion != -1) {
                seguimientoEN.ContratoAdopcion = new ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.ContratoAdopcionEN ();
                seguimientoEN.ContratoAdopcion.Id = p_contratoAdopcion;
        }

        //Call to SeguimientoCAD

        oid = _ISeguimientoCAD.Nuevo (seguimientoEN);
        return oid;
        /*PROTECTED REGION END*/
}
}
}
