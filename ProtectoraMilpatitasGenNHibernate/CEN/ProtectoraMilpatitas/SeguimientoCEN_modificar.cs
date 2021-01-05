
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


/*PROTECTED REGION ID(usingProtectoraMilpatitasGenNHibernate.CEN.ProtectoraMilpatitas_Seguimiento_modificar) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ProtectoraMilpatitasGenNHibernate.CEN.ProtectoraMilpatitas
{
public partial class SeguimientoCEN
{
public void Modificar (int p_Seguimiento, Nullable<DateTime> p_fecha, string p_descripcion)
{
        /*PROTECTED REGION ID(ProtectoraMilpatitasGenNHibernate.CEN.ProtectoraMilpatitas_Seguimiento_modificar_customized) START*/

        SeguimientoEN seguimientoEN = null;

        //Initialized SeguimientoEN
        seguimientoEN = new SeguimientoEN ();
        seguimientoEN.Id = p_Seguimiento;
        seguimientoEN.Fecha = p_fecha;
        seguimientoEN.Descripcion = p_descripcion;
        //Call to SeguimientoCAD

        _ISeguimientoCAD.Modificar (seguimientoEN);

        /*PROTECTED REGION END*/
}
}
}
