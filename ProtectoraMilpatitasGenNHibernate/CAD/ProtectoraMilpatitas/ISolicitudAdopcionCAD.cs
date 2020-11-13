
using System;
using ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas;

namespace ProtectoraMilpatitasGenNHibernate.CAD.ProtectoraMilpatitas
{
public partial interface ISolicitudAdopcionCAD
{
SolicitudAdopcionEN ReadOIDDefault (int id
                                    );

void ModifyDefault (SolicitudAdopcionEN solicitudAdopcion);

System.Collections.Generic.IList<SolicitudAdopcionEN> ReadAllDefault (int first, int size);



void Eliminar (int id
               );


void Rellenar_Solicitud (SolicitudAdopcionEN solicitudAdopcion);


SolicitudAdopcionEN Ver_Solicitud (int id
                                   );


System.Collections.Generic.IList<SolicitudAdopcionEN> Dame_Todas (int first, int size);


void Actualizar_Estado (SolicitudAdopcionEN solicitudAdopcion);


System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.SolicitudAdopcionEN> Obtener_Solicitud_Usuario (string p_email);




int Nuevo (SolicitudAdopcionEN solicitudAdopcion);
}
}
