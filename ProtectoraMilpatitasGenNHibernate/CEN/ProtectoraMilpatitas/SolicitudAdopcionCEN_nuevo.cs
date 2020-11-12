
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


/*PROTECTED REGION ID(usingProtectoraMilpatitasGenNHibernate.CEN.ProtectoraMilpatitas_SolicitudAdopcion_nuevo) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ProtectoraMilpatitasGenNHibernate.CEN.ProtectoraMilpatitas
{
public partial class SolicitudAdopcionCEN
{
public int Nuevo (string p_usuario, int p_animal)
{
        /*PROTECTED REGION ID(ProtectoraMilpatitasGenNHibernate.CEN.ProtectoraMilpatitas_SolicitudAdopcion_nuevo_customized) START*/

        SolicitudAdopcionEN solicitudAdopcionEN = null;

        int oid;

        //Initialized SolicitudAdopcionEN
        solicitudAdopcionEN = new SolicitudAdopcionEN ();

        if (p_usuario != null) {
                solicitudAdopcionEN.Usuario = new ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.UsuarioEN ();
                solicitudAdopcionEN.Usuario.Email = p_usuario;
        }


        if (p_animal != -1) {
                solicitudAdopcionEN.Animal = new ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.AnimalEN ();
                solicitudAdopcionEN.Animal.Id = p_animal;
        }

        //Call to SolicitudAdopcionCAD

        oid = _ISolicitudAdopcionCAD.Nuevo (solicitudAdopcionEN);
        return oid;
        /*PROTECTED REGION END*/
}
}
}
