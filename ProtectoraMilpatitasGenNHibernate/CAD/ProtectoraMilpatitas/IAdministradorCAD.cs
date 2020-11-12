
using System;
using ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas;

namespace ProtectoraMilpatitasGenNHibernate.CAD.ProtectoraMilpatitas
{
public partial interface IAdministradorCAD
{
AdministradorEN ReadOIDDefault (string email
                                );

void ModifyDefault (AdministradorEN administrador);

System.Collections.Generic.IList<AdministradorEN> ReadAllDefault (int first, int size);



string Registrarse (AdministradorEN administrador);

void Modificar (AdministradorEN administrador);


void Eliminar (string email
               );


System.Collections.Generic.IList<AdministradorEN> Dame_Todos (int first, int size);


AdministradorEN Dame_Por_Id (string email
                             );
}
}
