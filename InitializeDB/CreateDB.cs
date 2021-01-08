
/*PROTECTED REGION ID(CreateDB_imports) ENABLED START*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas;
using ProtectoraMilpatitasGenNHibernate.CEN.ProtectoraMilpatitas;
using ProtectoraMilpatitasGenNHibernate.CAD.ProtectoraMilpatitas;
using ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas;
using ProtectoraMilpatitasGenNHibernate.CP.ProtectoraMilpatitas;
using System.Linq;
/*PROTECTED REGION END*/
namespace InitializeDB
{
public class CreateDB
{
public static void Create (string databaseArg, string userArg, string passArg)
{
        String database = databaseArg;
        String user = userArg;
        String pass = passArg;

        // Conex DB
        SqlConnection cnn = new SqlConnection (@"Server=(local)\sqlexpress; database=master; integrated security=yes");

        // Order T-SQL create user
        String createUser = @"IF NOT EXISTS(SELECT name FROM master.dbo.syslogins WHERE name = '" + user + @"')
            BEGIN
                CREATE LOGIN ["                                                                                                                                     + user + @"] WITH PASSWORD=N'" + pass + @"', DEFAULT_DATABASE=[master], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
            END"                                                                                                                                                                                                                                                                                    ;

        //Order delete user if exist
        String deleteDataBase = @"if exists(select * from sys.databases where name = '" + database + "') DROP DATABASE [" + database + "]";
        //Order create databas
        string createBD = "CREATE DATABASE " + database;
        //Order associate user with database
        String associatedUser = @"USE [" + database + "];CREATE USER [" + user + "] FOR LOGIN [" + user + "];USE [" + database + "];EXEC sp_addrolemember N'db_owner', N'" + user + "'";
        SqlCommand cmd = null;

        try
        {
                // Open conex
                cnn.Open ();

                //Create user in SQLSERVER
                cmd = new SqlCommand (createUser, cnn);
                cmd.ExecuteNonQuery ();

                //DELETE database if exist
                cmd = new SqlCommand (deleteDataBase, cnn);
                cmd.ExecuteNonQuery ();

                //CREATE DB
                cmd = new SqlCommand (createBD, cnn);
                cmd.ExecuteNonQuery ();

                //Associate user with db
                cmd = new SqlCommand (associatedUser, cnn);
                cmd.ExecuteNonQuery ();

                System.Console.WriteLine ("DataBase create sucessfully..");
        }
        catch (Exception ex)
        {
                throw ex;
        }
        finally
        {
                if (cnn.State == ConnectionState.Open) {
                        cnn.Close ();
                }
        }
}

public static void InitializeData ()
{
        /*PROTECTED REGION ID(initializeDataMethod) ENABLED START*/
        try
        {
                //Creacion de un administrador
                AdministradorCEN adminCEN = new AdministradorCEN ();
                adminCEN.Registrarse ("Protectora", "protectoramilpatitasalicante@gmail.com", "Patitas-20", "Imagenes/usuarios/imagen2.png");

                UsuarioCEN aduCEN = new UsuarioCEN ();

                if (aduCEN.Iniciar_Sesion ("protectoramilpatitasalicante@gmail.com", "patitas") != null) {
                        Console.WriteLine ("El login de administrador es correcto");
                }

                //Creacion de usuarios
                UsuarioCEN usuCEN = new UsuarioCEN ();
                UsuarioCP usuCP = new UsuarioCP();

                UsuarioEN perico = usuCP.Registrarse("Perico", "pericoinventado5@gmail.com", "Ciclismo-5", "Imagenes/usuarios/imagen.png");

                if (usuCEN.Iniciar_Sesion ("pericoinventado5@gmail.com", "12356794") != null) {
                        Console.WriteLine ("El login de: " + perico.Nombre + " es correcto");
                }

                UsuarioCP juan99 = new UsuarioCP ();
                UsuarioEN juan = juan99.Registrarse ("Juan", "juaninventado243@gmail.com", "Constantino-12", "Imagenes/usuarios/imagen1.png");
                
                UsuarioCP manuel = new UsuarioCP ();
                UsuarioEN manu = manuel.Registrarse ("Manuel45", "manuelinventado03@gmail.com", "Jugueton=5", "Imagenes/usuarios/imagen3.png");
                
                UsuarioCP Antonio = new UsuarioCP ();
                UsuarioEN anto = Antonio.Registrarse ("Antonio53", "antonioinventado780@gmail.com", "Villena-92", "Imagenes/usuarios/imagen5.jpg");

                Console.WriteLine ();

                //Creacion de especies
                EspecieCEN espCEN = new EspecieCEN ();
                int espPerro = espCEN.Nuevo ("perro");
                Console.WriteLine ("Id de la especie perro: " + espPerro);

                int espGato = espCEN.Nuevo ("gato");
                Console.WriteLine ("Id de la especie gato: " + espGato);

                int espTortuga = espCEN.Nuevo ("tortuga");
                Console.WriteLine ("Id de la especie tortuga: " + espTortuga);

                int espPajaro = espCEN.Nuevo ("pajaro");
                Console.WriteLine ("Id de la especie pajaro: " + espPajaro);

                int espPez = espCEN.Nuevo ("pez");
                Console.WriteLine ("Id de la especie pez: " + espPez);

                int espGeco = espCEN.Nuevo ("geco");
                Console.WriteLine ("Id de la especie geco: " + espGeco);

                int espConejo = espCEN.Nuevo ("conejo");
                Console.WriteLine ("Id de la especie conejo: " + espConejo);

                int espHamster = espCEN.Nuevo ("hamster");
                Console.WriteLine ("Id de la especie hamster: " + espHamster);

                Console.WriteLine ();

                //Creacion de razas
                RazaCEN razCEN = new RazaCEN ();
                int per = razCEN.Nuevo ("carlino", espPerro);
                Console.WriteLine ("Id de la raza carlino: " + per);
                int per1 = razCEN.Nuevo ("yorkshire", espPerro);
                Console.WriteLine ("Id de la raza yorkshine: " + per1);

                int gat = razCEN.Nuevo ("siames", espGato);
                Console.WriteLine ("Id de la raza siames: " + gat);
                int gat1 = razCEN.Nuevo ("europeo", espGato);
                Console.WriteLine ("Id de la raza europeo: " + gat1);

                int tor = razCEN.Nuevo ("rusa", espTortuga);
                Console.WriteLine ("Id de la raza rusa: " + tor);
                int tor1 = razCEN.Nuevo ("del bosque", espTortuga);
                Console.WriteLine ("Id de la raza del bosque: " + tor1);

                int paj = razCEN.Nuevo ("periquito", espPajaro);
                Console.WriteLine ("Id de la raza periquito: " + paj);
                int paj1 = razCEN.Nuevo ("canario", espPajaro);
                Console.WriteLine ("Id de la raza canario: " + paj1);

                int pez = razCEN.Nuevo ("guppy", espPez);
                Console.WriteLine ("Id de la raza guppy: " + pez);
                int pez1 = razCEN.Nuevo ("payaso", espPez);
                Console.WriteLine ("Id de la raza payaso: " + pez1);

                int geco = razCEN.Nuevo ("leopardo", espGeco);
                Console.WriteLine ("Id de la raza leopardo: " + geco);
                int geco1 = razCEN.Nuevo ("crestado", espGeco);
                Console.WriteLine ("Id de la raza crestado: " + geco1);

                int cone = razCEN.Nuevo ("gran chinchilla", espConejo);
                Console.WriteLine ("Id de la raza gran chinchilla: " + cone);
                int cone1 = razCEN.Nuevo ("de Nueva Zelanda", espConejo);
                Console.WriteLine ("Id de la raza de Nueva Zelanda: " + cone1);

                int ham = razCEN.Nuevo ("Roborowski", espHamster);
                Console.WriteLine ("Id de la raza Roborowski: " + ham);
                int ham1 = razCEN.Nuevo ("dorado", espHamster);
                Console.WriteLine ("Id de la raza dorado: " + ham1);

                Console.WriteLine ();

                IList<RazaEN> razas = razCEN.Dame_Raza_Por_Especie (espPerro);
                Console.WriteLine ("razas de la especie: " + (espCEN.Dame_Por_Id (espPerro)).Nombre);
                foreach (RazaEN razi in razas) {
                        Console.WriteLine ("-" + razi.Nombre);
                }

                Console.WriteLine ();

                DateTime date11 = new DateTime (2020, 1, 2, 8, 30, 52);
                DateTime date12 = new DateTime (2020, 11, 1, 8, 30, 52);

                //Creacion de animales
                AnimalCP animalCP = new AnimalCP ();

                AnimalEN chihuahua = animalCP.Nuevo ("Tobi", 3, 'H', "Alicante", ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas.EstadoSaludEnum.sano, "amigable", espPerro, "Imagenes/animales/Galgo-espanol-1.jpg", date11, per);
                AnimalEN yorkshire = animalCP.Nuevo ("Pelusa", 1, 'M', "Albacete", ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas.EstadoSaludEnum.enRecuperacion, "cariñoso", espPerro, "Imagenes/animales/manchitas.jpg", new DateTime (2021, 1, 1, 8, 30, 52), per1);

                AnimalEN siames = animalCP.Nuevo ("Minino", 1, 'H', "Alicante", ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas.EstadoSaludEnum.sano, "mimoso", espGato, "Imagenes/animales/gato1.jpg", new DateTime (2021, 1, 1, 8, 30, 52), gat);
                AnimalEN europeo = animalCP.Nuevo ("Milky", 2, 'H', "Alicante", ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas.EstadoSaludEnum.sano, "mimoso", espGato, "Imagenes/animales/gato2.jpg", date12, gat1);

                AnimalEN rusa = animalCP.Nuevo ("Donatello", 1, 'M', "Villena", ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas.EstadoSaludEnum.sano, "un poco agresivo", espTortuga, "Imagenes/animales/tortuga-rusa.jpg", date11, tor);
                AnimalEN bosque = animalCP.Nuevo ("Leonardo", 5, 'M', "Villena", ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas.EstadoSaludEnum.enfermo, "un poco agresivo", espTortuga, "Imagenes/animales/tortuga-bosque.jpg", date11, tor1);

                AnimalEN periquito = animalCP.Nuevo ("Cantarin", 10, 'H', "Alcoy", ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas.EstadoSaludEnum.sano, "fiestera", espPajaro, "Imagenes/animales/periquito.jpg", date12, paj);
                AnimalEN canario = animalCP.Nuevo ("Bailarin", 10, 'H', "Alcoy", ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas.EstadoSaludEnum.sano, "fiestera", espPajaro, "Imagenes/animales/canario.jpg", date12, paj1);

                AnimalEN guppy = animalCP.Nuevo ("Gup", 2, 'H', "Elche", ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas.EstadoSaludEnum.enfermo, "amigable", espPez, "Imagenes/animales/Pez-guppy.jpg", date11, pez);
                AnimalEN payaso = animalCP.Nuevo ("Payasi", 2, 'M', "Elche", ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas.EstadoSaludEnum.sano, "juguetón", espPez, "Imagenes/animales/pez-payaso.jpg", new DateTime (2021, 1, 1, 8, 30, 52), pez1);

                AnimalEN leopardo = animalCP.Nuevo ("Leo", 2, 'M', "Murcia", ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas.EstadoSaludEnum.enfermo, "solitario", espGeco, "Imagenes/animales/gecko_crestado.jpg", date12, geco);
                AnimalEN crestado = animalCP.Nuevo ("Cresti", 12, 'H', "Murcia", ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas.EstadoSaludEnum.sano, "solitaria", espGeco, "Imagenes/animales/Gecko_leopardo.png", date12, geco1);

                AnimalEN chinchilla = animalCP.Nuevo ("Chincha", 1, 'H', "Elda", ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas.EstadoSaludEnum.sano, "amigable", espConejo, "Imagenes/animales/conejo-chinchilla.jpg", date11, cone);
                AnimalEN zelanda = animalCP.Nuevo ("Zela", 11, 'M', "Elda", ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas.EstadoSaludEnum.sano, "juguetón", espConejo, "Imagenes/animales/conejo-nueva-zelanda.jpg", date11, cone1);

                AnimalEN robo = animalCP.Nuevo ("Robador", 2, 'M', "Petrer", ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas.EstadoSaludEnum.sano, "juguetón", espHamster, "Imagenes/animales/hamster-roborowski.jpg", new DateTime (2021, 1, 1, 8, 30, 52), ham);
                AnimalEN dorado = animalCP.Nuevo ("Sirio", 2, 'H', "Petrer", ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas.EstadoSaludEnum.enfermo, "cariñoso", espHamster, "Imagenes/animales/hamster-dorado.jpg", date12, ham1);

                Console.WriteLine ();

                AnimalCEN aniCEN = new AnimalCEN ();

                Console.WriteLine ("Datos medicos de " + europeo.Nombre + " antes de cambiarlo -> " + europeo.DatosMedicos);
                aniCEN.Actualizar_DatosMedicos (europeo.Id, ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas.EstadoSaludEnum.sano);
                Console.WriteLine ("Datos medicos de " + europeo.Nombre + " despues de cambiarlo -> " + (aniCEN.Ver_Detalle_Animal (europeo.Id)).DatosMedicos);

                Console.WriteLine ();

                IList<AnimalEN> animales = aniCEN.Dame_Animales_Por_Especie (espGato);
                Console.WriteLine ("animales de la especie: " + (espCEN.Dame_Por_Id (espGato)).Nombre);
                foreach (AnimalEN ani in animales) {
                        Console.WriteLine ("-" + ani.Nombre);
                }

                Console.WriteLine ();

                ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas.EstadoAnimalAdopcionEnum estadoSia = aniCEN.Ver_Proceso_Adopcion (siames.Id);
                Console.WriteLine ("Estado de adopcion de " + siames.Nombre + " -> " + estadoSia);

                Console.WriteLine ();

                //Creacion de tests
                TestAnimalIdealCEN test1 = new TestAnimalIdealCEN ();
                int idtest1 = test1.Nuevo (juan.Email);
                Console.WriteLine ("Id del test: " + idtest1);
                test1.Rellenar_Test (idtest1, "Manualidades", "Inteligente", "Rojo");
                TestAnimalIdealEN restest1 = test1.Ver_Resultado (idtest1);
                Console.WriteLine ("El resultado del test: " + restest1.Id + " es " + restest1.Resultado);

                Console.WriteLine ();

                //Solicitud de Adopcion
                SolicitudAdopcionCEN solicitudAdopcionCEN = new SolicitudAdopcionCEN ();
                SolicitudAdopcionCP solicitudAdopcionCP = new SolicitudAdopcionCP ();

                int idsol = solicitudAdopcionCEN.Nuevo (juan.Email, chihuahua.Id, new DateTime (2020, 10, 15, 8, 30, 52));
                solicitudAdopcionCP.Actualizar_Estado (idsol, ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas.EstadoAdopcionEnum.enEspera);

                int idsol1 = solicitudAdopcionCEN.Nuevo (manu.Email, chihuahua.Id, new DateTime (2021, 1, 5, 8, 30, 52));
                solicitudAdopcionCP.Actualizar_Estado (idsol1, ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas.EstadoAdopcionEnum.enEspera);

                solicitudAdopcionCEN.Rellenar_Solicitud (idsol, "Juan", 2, "lugar tranquilo", 3, true, "nos gustan los animales");
                solicitudAdopcionCEN.Rellenar_Solicitud (idsol1, "Manu", 1, "lugar natural y tranquilo", 4, true, "necesito compañia");

                Console.WriteLine ();

                IList<SolicitudAdopcionEN> sols = solicitudAdopcionCEN.Obtener_Solicitud_Usuario (juan.Email);
                foreach (SolicitudAdopcionEN sol in sols) {
                        Console.WriteLine ("Solicitud : " + sol.Id + " " + sol.Nombre + " " + sol.FechaSolicitud);
                }

                Console.WriteLine ();


                //Contrato de adopcion
                ContratoAdopcionCEN contratoAdopcionCEN = new ContratoAdopcionCEN ();
                ContratoAdopcionCP contratoAdopcionCP = new ContratoAdopcionCP ();

                int idcon = contratoAdopcionCEN.Nuevo (juan.Email, idsol, chihuahua.Id);
                contratoAdopcionCP.Actualizar_Estado (idcon, ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas.EstadoContratoEnum.entregado);

                int idcon1 = contratoAdopcionCEN.Nuevo (manu.Email, idsol1, chihuahua.Id);
                contratoAdopcionCP.Actualizar_Estado (idcon1, ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas.EstadoContratoEnum.entregado);

                contratoAdopcionCEN.Rellenar_Contrato (idcon, "Juan", "1111111F", "micasa.pdf", "pago.jpg", "alicante", true);
                contratoAdopcionCEN.Rellenar_Contrato (idcon1, "Manuel", "22222221F", "micasa.pdf", "pago.jpg", "villena", true);

                Console.WriteLine ();

                IList<ContratoAdopcionEN> cons = contratoAdopcionCEN.Obtener_Contrato_Usuario (manu.Email);
                foreach (ContratoAdopcionEN con in cons) {
                        Console.WriteLine ("Contrato : " + con.Id + " " + con.Nombre);
                }

                Console.WriteLine ();

                //Seguimiento de adopcion
                SeguimientoCEN seguimientoCEN = new SeguimientoCEN ();
                SeguimientoCP seguimientoCP = new SeguimientoCP ();

                DateTime date1 = new DateTime (2008, 5, 1, 8, 30, 52);

                int idseg = seguimientoCEN.Nuevo (manu.Email, chihuahua.Id, idcon1);
                seguimientoCEN.Modificar (idseg, date1, "está correcto");
                seguimientoCP.Actualizar_Estado (idseg, ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas.EstadoSeguimientoEnum.pendienteRevision);

                Console.WriteLine ();

                IList<SeguimientoEN> segs = seguimientoCEN.Obtener_Seguimiento_Usuario (manu.Email);
                foreach (SeguimientoEN seg in segs) {
                        Console.WriteLine ("Seguimiento de Manu : " + seg.Id);
                }

                Console.WriteLine ();


                /*PROTECTED REGION END*/
        }
        catch (Exception ex)
        {
                System.Console.WriteLine (ex.InnerException);
                throw ex;
        }
}
}
}
