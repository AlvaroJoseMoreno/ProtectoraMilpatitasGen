
using System;
using ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas;

namespace ProtectoraMilpatitasGenNHibernate.CAD.ProtectoraMilpatitas
{
public partial interface IAnimalCAD
{
AnimalEN ReadOIDDefault (int id
                         );

void ModifyDefault (AnimalEN animal);

System.Collections.Generic.IList<AnimalEN> ReadAllDefault (int first, int size);



int Nuevo (AnimalEN animal);

void Modificar (AnimalEN animal);


void Eliminar (int id
               );


AnimalEN Ver_Detalle_Animal (int id
                             );



System.Collections.Generic.IList<AnimalEN> Dame_Todos (int first, int size);


void Actualizar_DatosMedicos (AnimalEN animal);


void Actualizar_Estado (AnimalEN animal);


System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.AnimalEN> BuscarAnimales (string p_nombre, int? p_edad, char p_sexo, string p_centro, ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas.EstadoSaludEnum? p_datosMedicos, string p_caracter, Nullable<DateTime> p_fechaLlegada, int p_especie, int p_raza);


System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.AnimalEN> Dame_Animales_Por_Especie (int p_especie);


System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.AnimalEN> Obtener_Animal_Usuario (string p_email);


void AsignarDuenyo (int p_Animal_OID, string p_dueño_OID);

System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.AnimalEN> BusquedaRapida (string p_nombre);


System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.AnimalEN> ObtenerBabies ();


System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.AnimalEN> ObtenerRecienLlegados ();


System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.AnimalEN> ObtenerCasosEspeciales (ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas.EstadoSaludEnum ? p_enfermo);


System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.AnimalEN> ObtenerUrgentes ();
}
}
