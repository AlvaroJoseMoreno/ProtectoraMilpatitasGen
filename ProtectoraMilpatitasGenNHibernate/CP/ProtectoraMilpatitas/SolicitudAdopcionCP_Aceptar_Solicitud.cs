
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



/*PROTECTED REGION ID(usingProtectoraMilpatitasGenNHibernate.CP.ProtectoraMilpatitas_SolicitudAdopcion_Aceptar_Solicitud) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ProtectoraMilpatitasGenNHibernate.CP.ProtectoraMilpatitas
{
public partial class SolicitudAdopcionCP : BasicCP
{
public void Aceptar_Solicitud (int p_SolicitudAdopcion, string p_Usuario)
{
        /*PROTECTED REGION ID(ProtectoraMilpatitasGenNHibernate.CP.ProtectoraMilpatitas_SolicitudAdopcion_Aceptar_Solicitud) ENABLED START*/

        ISolicitudAdopcionCAD solicitudAdopcionCAD = null;
        SolicitudAdopcionCEN solicitudAdopcionCEN = null;



        try
        {
                SessionInitializeTransaction ();
                solicitudAdopcionCAD = new SolicitudAdopcionCAD (session);
                solicitudAdopcionCEN = new  SolicitudAdopcionCEN (solicitudAdopcionCAD);



                // Write here your custom transaction ...

                throw new NotImplementedException ("Method Aceptar_Solicitud() not yet implemented.");



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
