
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



/*PROTECTED REGION ID(usingProtectoraMilpatitasGenNHibernate.CP.ProtectoraMilpatitas_Mensaje_responder) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ProtectoraMilpatitasGenNHibernate.CP.ProtectoraMilpatitas
{
public partial class MensajeCP : BasicCP
{
public void Responder (int p_Mensaje, string p_texto, string p_usuario)
{
        /*PROTECTED REGION ID(ProtectoraMilpatitasGenNHibernate.CP.ProtectoraMilpatitas_Mensaje_responder) ENABLED START*/

        IMensajeCAD mensajeCAD = null;
        MensajeCEN mensajeCEN = null;



        try
        {
                SessionInitializeTransaction ();
                mensajeCAD = new MensajeCAD (session);
                mensajeCEN = new  MensajeCEN (mensajeCAD);




                MensajeEN mensajeEN = null;
                //Initialized MensajeEN
                mensajeEN = new MensajeEN ();
                mensajeEN.Id = p_Mensaje;
                mensajeEN.Texto = p_texto;
                mensajeEN.Usuario = p_usuario;
                //Call to MensajeCAD

                mensajeCAD.Responder (mensajeEN);


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
