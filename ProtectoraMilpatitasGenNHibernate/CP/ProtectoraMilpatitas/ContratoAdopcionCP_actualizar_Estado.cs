
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



/*PROTECTED REGION ID(usingProtectoraMilpatitasGenNHibernate.CP.ProtectoraMilpatitas_ContratoAdopcion_actualizar_Estado) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ProtectoraMilpatitasGenNHibernate.CP.ProtectoraMilpatitas
{
public partial class ContratoAdopcionCP : BasicCP
{
public void Actualizar_Estado (int p_ContratoAdopcion, ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas.EstadoContratoEnum p_estado)
{
        /*PROTECTED REGION ID(ProtectoraMilpatitasGenNHibernate.CP.ProtectoraMilpatitas_ContratoAdopcion_actualizar_Estado) ENABLED START*/

        IContratoAdopcionCAD contratoAdopcionCAD = null;
        ContratoAdopcionCEN contratoAdopcionCEN = null;

        try
        {
                SessionInitializeTransaction ();
                contratoAdopcionCAD = new ContratoAdopcionCAD (session);
                contratoAdopcionCEN = new ContratoAdopcionCEN (contratoAdopcionCAD);

                ContratoAdopcionEN contratoAdopcionEN = null;
                //Initialized ContratoAdopcionEN
                contratoAdopcionEN = contratoAdopcionCAD.Ver_Contrato(p_ContratoAdopcion);
               // contratoAdopcionEN.Id = p_ContratoAdopcion;
                contratoAdopcionEN.Estado = p_estado;
                //Call to ContratoAdopcionCAD

                if (contratoAdopcionEN.Estado.Equals ("firmado")) {
                        contratoAdopcionEN.Animal.EstadoAdopcion = ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas.EstadoAnimalAdopcionEnum.EnSeguimiento;
                }
                else{
                        contratoAdopcionEN.Animal.EstadoAdopcion = ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas.EstadoAnimalAdopcionEnum.EnContrato;
                }

                contratoAdopcionCAD.Actualizar_Estado (contratoAdopcionEN);


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
