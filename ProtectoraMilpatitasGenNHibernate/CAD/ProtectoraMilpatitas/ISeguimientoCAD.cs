
using System;
using ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas;

namespace ProtectoraMilpatitasGenNHibernate.CAD.ProtectoraMilpatitas
{
public partial interface ISeguimientoCAD
{
SeguimientoEN ReadOIDDefault (int id
                              );

void ModifyDefault (SeguimientoEN seguimiento);

System.Collections.Generic.IList<SeguimientoEN> ReadAllDefault (int first, int size);



int Nuevo (SeguimientoEN seguimiento);

void Modificar (SeguimientoEN seguimiento);


void Eliminar (int id
               );


void Actualizar_Estado (SeguimientoEN seguimiento);


System.Collections.Generic.IList<SeguimientoEN> Dame_Todos (int first, int size);


SeguimientoEN Dame_Por_Id (int id
                           );


System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.SeguimientoEN> Obtener_Seguimiento_Usuario (string p_usuario);
}
}
