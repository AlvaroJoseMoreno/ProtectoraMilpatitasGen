
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



/*PROTECTED REGION ID(usingProtectoraMilpatitasGenNHibernate.CP.ProtectoraMilpatitas_Seguimiento_actualizar_Estado) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ProtectoraMilpatitasGenNHibernate.CP.ProtectoraMilpatitas
{
public partial class SeguimientoCP : BasicCP
{
public void Actualizar_Estado (int p_Seguimiento, ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas.EstadoSeguimientoEnum p_estado)
{
        /*PROTECTED REGION ID(ProtectoraMilpatitasGenNHibernate.CP.ProtectoraMilpatitas_Seguimiento_actualizar_Estado) ENABLED START*/

        ISeguimientoCAD seguimientoCAD = null;
        SeguimientoCEN seguimientoCEN = null;



        try
        {
                SessionInitializeTransaction ();
                seguimientoCAD = new SeguimientoCAD (session);
                seguimientoCEN = new SeguimientoCEN (seguimientoCAD);




                SeguimientoEN seguimientoEN = null;
                //Initialized SeguimientoEN
                seguimientoEN = seguimientoCEN.Dame_Por_Id (p_Seguimiento);
                //seguimientoEN.Id = p_Seguimiento;
                seguimientoEN.Estado = p_estado;
                //Call to SeguimientoCAD

                if (seguimientoEN.Estado == ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas.EstadoSeguimientoEnum.marcarQuitarAnimal) {
                        seguimientoEN.Animal.EstadoAdopcion = ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas.EstadoAnimalAdopcionEnum.SinTramite;
                }
                else{
                        seguimientoEN.Animal.EstadoAdopcion = ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas.EstadoAnimalAdopcionEnum.EnSeguimiento;
                }

                seguimientoCAD.Actualizar_Estado (seguimientoEN);


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


        /*PROTECTED REGION END*/
}
}
}
