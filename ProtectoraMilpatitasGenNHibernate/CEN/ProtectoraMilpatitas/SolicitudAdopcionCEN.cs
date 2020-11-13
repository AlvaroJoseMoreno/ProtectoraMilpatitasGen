
using System;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using ProtectoraMilpatitasGenNHibernate.Exceptions;

using ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas;
using ProtectoraMilpatitasGenNHibernate.CAD.ProtectoraMilpatitas;


namespace ProtectoraMilpatitasGenNHibernate.CEN.ProtectoraMilpatitas
{
    /*
     *      Definition of the class SolicitudAdopcionCEN
     *
     */
    public partial class SolicitudAdopcionCEN
    {
        private ISolicitudAdopcionCAD _ISolicitudAdopcionCAD;

        public SolicitudAdopcionCEN()
        {
            this._ISolicitudAdopcionCAD = new SolicitudAdopcionCAD();
        }

        public SolicitudAdopcionCEN(ISolicitudAdopcionCAD _ISolicitudAdopcionCAD)
        {
            this._ISolicitudAdopcionCAD = _ISolicitudAdopcionCAD;
        }

        public ISolicitudAdopcionCAD get_ISolicitudAdopcionCAD()
        {
            return this._ISolicitudAdopcionCAD;
        }

        public void Eliminar(int id
                              )
        {
            _ISolicitudAdopcionCAD.Eliminar(id);
        }

        public SolicitudAdopcionEN Ver_Solicitud(int id
                                                  )
        {
            SolicitudAdopcionEN solicitudAdopcionEN = null;

            solicitudAdopcionEN = _ISolicitudAdopcionCAD.Ver_Solicitud(id);
            return solicitudAdopcionEN;
        }

        public System.Collections.Generic.IList<SolicitudAdopcionEN> Dame_Todas(int first, int size)
        {
            System.Collections.Generic.IList<SolicitudAdopcionEN> list = null;

            list = _ISolicitudAdopcionCAD.Dame_Todas(first, size);
            return list;
        }
        public System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.SolicitudAdopcionEN> Obtener_Solicitud_Usuario(string p_email)
        {
            return _ISolicitudAdopcionCAD.Obtener_Solicitud_Usuario(p_email);
        }
    }
}
