
using System;
using ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas;

namespace ProtectoraMilpatitasGenNHibernate.CAD.ProtectoraMilpatitas
{
public partial interface IContratoAdopcionCAD
{
ContratoAdopcionEN ReadOIDDefault (int id
                                   );

void ModifyDefault (ContratoAdopcionEN contratoAdopcion);

System.Collections.Generic.IList<ContratoAdopcionEN> ReadAllDefault (int first, int size);



int Nuevo (ContratoAdopcionEN contratoAdopcion);

void Eliminar (int id
               );


void Rellenar_Contrato (ContratoAdopcionEN contratoAdopcion);


ContratoAdopcionEN Ver_Contrato (int id
                                 );


System.Collections.Generic.IList<ContratoAdopcionEN> Dame_Todos (int first, int size);


void Actualizar_Estado (ContratoAdopcionEN contratoAdopcion);


System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.ContratoAdopcionEN> Obtener_Contrato_Usuario (string p_email);
}
}
