
using System;
using ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas;

namespace ProtectoraMilpatitasGenNHibernate.CAD.ProtectoraMilpatitas
{
public partial interface IEspecieCAD
{
EspecieEN ReadOIDDefault (int id
                          );

void ModifyDefault (EspecieEN especie);

System.Collections.Generic.IList<EspecieEN> ReadAllDefault (int first, int size);



int Nuevo (EspecieEN especie);

void Modificar (EspecieEN especie);


void Eliminar (int id
               );


System.Collections.Generic.IList<EspecieEN> Dame_Todas (int first, int size);


EspecieEN Dame_Por_Id (int id
                       );
}
}
