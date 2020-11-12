
using System;
using ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas;

namespace ProtectoraMilpatitasGenNHibernate.CAD.ProtectoraMilpatitas
{
public partial interface IUsuarioCAD
{
UsuarioEN ReadOIDDefault (string email
                          );

void ModifyDefault (UsuarioEN usuario);

System.Collections.Generic.IList<UsuarioEN> ReadAllDefault (int first, int size);




string Registrarse (UsuarioEN usuario);

void Modificar (UsuarioEN usuario);


void Eliminar (string email
               );



System.Collections.Generic.IList<UsuarioEN> Dame_Todos (int first, int size);


UsuarioEN Dame_Por_Email (string email
                          );
}
}
