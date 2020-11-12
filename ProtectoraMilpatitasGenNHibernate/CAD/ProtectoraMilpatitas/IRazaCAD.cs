
using System;
using ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas;

namespace ProtectoraMilpatitasGenNHibernate.CAD.ProtectoraMilpatitas
{
public partial interface IRazaCAD
{
RazaEN ReadOIDDefault (int id
                       );

void ModifyDefault (RazaEN raza);

System.Collections.Generic.IList<RazaEN> ReadAllDefault (int first, int size);



int Nuevo (RazaEN raza);

void Modificar (RazaEN raza);


void Eliminar (int id
               );


System.Collections.Generic.IList<RazaEN> Dame_Todas (int first, int size);


RazaEN Dame_Por_Id (int id
                    );


System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.RazaEN> Dame_Raza_Por_Especie (int p_especie);
}
}
