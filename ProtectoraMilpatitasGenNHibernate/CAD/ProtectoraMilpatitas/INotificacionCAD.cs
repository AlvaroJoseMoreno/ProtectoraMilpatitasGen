
using System;
using ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas;

namespace ProtectoraMilpatitasGenNHibernate.CAD.ProtectoraMilpatitas
{
public partial interface INotificacionCAD
{
NotificacionEN ReadOIDDefault (int id
                               );

void ModifyDefault (NotificacionEN notificacion);

System.Collections.Generic.IList<NotificacionEN> ReadAllDefault (int first, int size);



int Nuevo (NotificacionEN notificacion);

void Modificar (NotificacionEN notificacion);


void Eliminar (int id
               );



System.Collections.Generic.IList<NotificacionEN> Dame_Todas (int first, int size);


NotificacionEN Dame_Por_Id (int id
                            );
}
}
