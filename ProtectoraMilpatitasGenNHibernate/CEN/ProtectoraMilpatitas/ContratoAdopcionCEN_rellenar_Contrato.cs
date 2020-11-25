
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


/*PROTECTED REGION ID(usingProtectoraMilpatitasGenNHibernate.CEN.ProtectoraMilpatitas_ContratoAdopcion_rellenar_Contrato) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ProtectoraMilpatitasGenNHibernate.CEN.ProtectoraMilpatitas
{
public partial class ContratoAdopcionCEN
{
public void Rellenar_Contrato (int p_ContratoAdopcion, string p_nombre, string p_DNI_NIF_Pasaporte, string p_escrituraHogar, string p_justificantePago, string p_lugarRecojida, bool p_firmaCompromiso)
{
        /*PROTECTED REGION ID(ProtectoraMilpatitasGenNHibernate.CEN.ProtectoraMilpatitas_ContratoAdopcion_rellenar_Contrato_customized) START*/

        ContratoAdopcionEN contratoAdopcionEN = null;

        //Initialized ContratoAdopcionEN
        contratoAdopcionEN = new ContratoAdopcionEN ();
        contratoAdopcionEN.Id = p_ContratoAdopcion;
        contratoAdopcionEN.Nombre = p_nombre;
        contratoAdopcionEN.DNI_NIF_Pasaporte = p_DNI_NIF_Pasaporte;
        contratoAdopcionEN.EscrituraHogar = p_escrituraHogar;
        contratoAdopcionEN.JustificantePago = p_justificantePago;
        contratoAdopcionEN.LugarRecojida = p_lugarRecojida;
        contratoAdopcionEN.FirmaCompromiso = p_firmaCompromiso;
        //Call to ContratoAdopcionCAD

        _IContratoAdopcionCAD.Rellenar_Contrato (contratoAdopcionEN);

        /*PROTECTED REGION END*/
}
}
}
