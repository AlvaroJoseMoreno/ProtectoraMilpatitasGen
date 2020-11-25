
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


/*PROTECTED REGION ID(usingProtectoraMilpatitasGenNHibernate.CEN.ProtectoraMilpatitas_SolicitudAdopcion_rellenar_Solicitud) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ProtectoraMilpatitasGenNHibernate.CEN.ProtectoraMilpatitas
{
public partial class SolicitudAdopcionCEN
{
public void Rellenar_Solicitud (int p_SolicitudAdopcion, string p_nombre, int p_animalesAcargo, string p_ambienteConvivencia, int p_tiempoLibre, bool p_todosAcuerdo, string p_motivosAdopcion)
{
        /*PROTECTED REGION ID(ProtectoraMilpatitasGenNHibernate.CEN.ProtectoraMilpatitas_SolicitudAdopcion_rellenar_Solicitud_customized) START*/

        SolicitudAdopcionEN solicitudAdopcionEN = null;

        //Initialized SolicitudAdopcionEN
        solicitudAdopcionEN = new SolicitudAdopcionEN ();
            
        solicitudAdopcionEN.Id = p_SolicitudAdopcion;
            if(p_nombre != null && p_nombre != solicitudAdopcionEN.Nombre)
        solicitudAdopcionEN.Nombre = p_nombre;
            if(p_animalesAcargo != -1 && p_animalesAcargo != solicitudAdopcionEN.AnimalesAcargo)
        solicitudAdopcionEN.AnimalesAcargo = p_animalesAcargo;
            if(p_ambienteConvivencia != null && solicitudAdopcionEN.AmbienteConvivencia != p_ambienteConvivencia)
        solicitudAdopcionEN.AmbienteConvivencia = p_ambienteConvivencia;
            if(p_tiempoLibre != -1 && solicitudAdopcionEN.TiempoLibre != p_tiempoLibre)
        solicitudAdopcionEN.TiempoLibre = p_tiempoLibre;
            if(p_todosAcuerdo != null && p_todosAcuerdo != solicitudAdopcionEN.TodosAcuerdo)
        solicitudAdopcionEN.TodosAcuerdo = p_todosAcuerdo;
            if(p_motivosAdopcion != null && solicitudAdopcionEN.MotivosAdopcion != p_motivosAdopcion)
        solicitudAdopcionEN.MotivosAdopcion = p_motivosAdopcion;
        //Call to SolicitudAdopcionCAD

        _ISolicitudAdopcionCAD.Rellenar_Solicitud (solicitudAdopcionEN);

        /*PROTECTED REGION END*/
}
}
}
