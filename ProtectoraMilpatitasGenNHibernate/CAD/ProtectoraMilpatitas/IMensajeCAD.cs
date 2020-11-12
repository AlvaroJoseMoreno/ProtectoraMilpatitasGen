
using System;
using ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas;

namespace ProtectoraMilpatitasGenNHibernate.CAD.ProtectoraMilpatitas
{
public partial interface IMensajeCAD
{
MensajeEN ReadOIDDefault (int id
                          );

void ModifyDefault (MensajeEN mensaje);

System.Collections.Generic.IList<MensajeEN> ReadAllDefault (int first, int size);



int Nuevo (MensajeEN mensaje);

void Eliminar (int id
               );


void Responder (MensajeEN mensaje);


MensajeEN Ver_Mensaje (int id
                       );


System.Collections.Generic.IList<MensajeEN> Dame_Todos (int first, int size);
}
}
