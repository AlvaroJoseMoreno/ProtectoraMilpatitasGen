
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


/*PROTECTED REGION ID(usingProtectoraMilpatitasGenNHibernate.CEN.ProtectoraMilpatitas_Animal_ver_Proceso_Adopcion) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ProtectoraMilpatitasGenNHibernate.CEN.ProtectoraMilpatitas
{
    public partial class AnimalCEN
    {
        public ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas.EstadoAnimalAdopcionEnum Ver_Proceso_Adopcion(int p_Animal)
        {
            /*PROTECTED REGION ID(ProtectoraMilpatitasGenNHibernate.CEN.ProtectoraMilpatitas_Animal_ver_Proceso_Adopcion) ENABLED START*/

            // Write here your custom code...

            ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas.EstadoAnimalAdopcionEnum estado = ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas.EstadoAnimalAdopcionEnum.SinTramite;
            AnimalEN en = _IAnimalCAD.ReadOIDDefault(p_Animal);

            if (en != null)
                estado = en.EstadoAdopcion;

            return estado;

            /*PROTECTED REGION END*/
        }
    }
}
