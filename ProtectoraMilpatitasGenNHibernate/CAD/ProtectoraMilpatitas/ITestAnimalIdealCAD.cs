
using System;
using ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas;

namespace ProtectoraMilpatitasGenNHibernate.CAD.ProtectoraMilpatitas
{
public partial interface ITestAnimalIdealCAD
{
TestAnimalIdealEN ReadOIDDefault (int id
                                  );

void ModifyDefault (TestAnimalIdealEN testAnimalIdeal);

System.Collections.Generic.IList<TestAnimalIdealEN> ReadAllDefault (int first, int size);



void Eliminar (int id
               );


void Rellenar_Test (TestAnimalIdealEN testAnimalIdeal);


TestAnimalIdealEN Ver_Resultado (int id
                                 );


System.Collections.Generic.IList<TestAnimalIdealEN> Dame_Todos (int first, int size);


int Nuevo (TestAnimalIdealEN testAnimalIdeal);
}
}
