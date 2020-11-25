
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
                adminCEN.Registrarse ("Protectora", "protectoramilpatitasalicante@gmail.com", "patitas");

                UsuarioCEN aduCEN = new UsuarioCEN ();

                if (aduCEN.Iniciar_Sesion ("protectoramilpatitasalicante@gmail.com", "patitas") != null) {
                        Console.WriteLine ("El login de administrador es correcto");
                }


                //Creacion de usuarios
                UsuarioCEN usuCEN = new UsuarioCEN ();
                string idusu = usuCEN.Registrarse ("Perico", "pericoinventado5@gmail.com", "12356794");

                if (usuCEN.Iniciar_Sesion ("pericoinventado5@gmail.com", "12356794") != null) {
                        Console.WriteLine ("El login de: " + idusu + " es correcto");
                }

                UsuarioCEN juan99 = new UsuarioCEN ();
                string juan = juan99.Registrarse ("Juan", "juaninventado243@gmail.com", "constantino12");
                UsuarioCEN manuel = new UsuarioCEN ();
                string manu = manuel.Registrarse ("Manuel45", "manuelinventado03@gmail.com", "password=5");
                UsuarioCEN Antonio = new UsuarioCEN ();
                string anto = Antonio.Registrarse ("Antonio53", "antonioinventado780@gmail.com", "villena92");


                //Creaci�n de animales
                AnimalCP chihua = new AnimalCP ();
                AnimalEN chi = chihua.Nuevo ("tobi", 3, 'H', "Alicante", ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas.EstadoSaludEnum.sano, "amigable");

                AnimalCP yorkshire = new AnimalCP ();
                AnimalEN yor = yorkshire.Nuevo ("Pelusa", 3, 'M', "Albacete", ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas.EstadoSaludEnum.enRecuperacion, "carinoso");

                AnimalCP siames = new AnimalCP ();
                AnimalEN sia = siames.Nuevo ("minino", 1, 'H', "Alicante", ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas.EstadoSaludEnum.enfermo, "mimoso");

                //Creacion de tests
                TestAnimalIdealCEN test1 = new TestAnimalIdealCEN ();
                int idtest1 = test1.Nuevo (juan);
                Console.WriteLine ("Id del test: " + idtest1);
                test1.Rellenar_Test (idtest1, "ver la television", "timido", "rojo");
                TestAnimalIdealEN restest1 = test1.Ver_Resultado (idtest1);
                Console.WriteLine ("El resultado del test: " + restest1.Id + " es 60");


                //Solicitud de Adopcion
                SolicitudAdopcionCEN solicitudAdopcionCEN = new SolicitudAdopcionCEN ();
                SolicitudAdopcionCP solicitudAdopcionCP = new SolicitudAdopcionCP ();

                int idsol = solicitudAdopcionCEN.Nuevo (juan, chi.Id);
                solicitudAdopcionCP.Actualizar_Estado (idsol, ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas.EstadoAdopcionEnum.enEspera);

                int idsol1 = solicitudAdopcionCEN.Nuevo (manu, chi.Id);
                solicitudAdopcionCP.Actualizar_Estado (idsol1, ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas.EstadoAdopcionEnum.enEspera);

                solicitudAdopcionCEN.Rellenar_Solicitud (idsol, "Juan", 2, "lugar tranquilo", 3, true, "nos gustan los animales");
                solicitudAdopcionCEN.Rellenar_Solicitud (idsol1, "Manu", 1, "lugar natural y tranquilo", 4, true, "necesito compañia");

                IList<SolicitudAdopcionEN> sols = solicitudAdopcionCEN.Obtener_Solicitud_Usuario (juan);
                foreach (SolicitudAdopcionEN sol in sols) {
                        Console.WriteLine ("Solicitud : " + sol.Id + " " + sol.Nombre);
                }


                //Contrato de adopcion
                ContratoAdopcionCEN contratoAdopcionCEN = new ContratoAdopcionCEN ();
                ContratoAdopcionCP contratoAdopcionCP = new ContratoAdopcionCP ();

                int idcon = contratoAdopcionCEN.Nuevo (juan, idsol, chi.Id);
                contratoAdopcionCP.Actualizar_Estado (idcon, ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas.EstadoContratoEnum.entregado);

                int idcon1 = contratoAdopcionCEN.Nuevo (manu, idsol1, chi.Id);
                contratoAdopcionCP.Actualizar_Estado (idcon1, ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas.EstadoContratoEnum.entregado);

                contratoAdopcionCEN.Rellenar_Contrato (idcon, "Juan", "1111111F", "micasa.pdf", "pago.jpg", "alicante", true);
                contratoAdopcionCEN.Rellenar_Contrato (idcon1, "Manuel", "22222221F", "micasa.pdf", "pago.jpg", "villena", true);

                IList<ContratoAdopcionEN> cons = contratoAdopcionCEN.Obtener_Contrato_Usuario (manu);
                foreach (ContratoAdopcionEN con in cons) {
                        Console.WriteLine ("Contrato : " + con.Id + " " + con.Nombre);
                }


                //Seguimiento de adopcion
                SeguimientoCEN seguimientoCEN = new SeguimientoCEN ();
                SeguimientoCP seguimientoCP = new SeguimientoCP ();

                DateTime date1 = new DateTime (2008, 5, 1, 8, 30, 52);

                int idseg = seguimientoCEN.Nuevo (manu, chi.Id, idcon1);
                seguimientoCEN.Modificar (idseg, date1);
                seguimientoCP.Actualizar_Estado (idseg, ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas.EstadoSeguimientoEnum.pendienteRevision);

                IList<SeguimientoEN> segs = seguimientoCEN.Obtener_Seguimiento_Usuario (manu);
                foreach (SeguimientoEN seg in segs) {
                        Console.WriteLine ("Seguimiento de Manu : " + seg.Id);
                }


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
