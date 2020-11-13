
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
        public static void Create(string databaseArg, string userArg, string passArg)
        {
            String database = databaseArg;
            String user = userArg;
            String pass = passArg;

            // Conex DB
            SqlConnection cnn = new SqlConnection(@"Server=(local)\sqlexpress; database=master; integrated security=yes");

            // Order T-SQL create user
            String createUser = @"IF NOT EXISTS(SELECT name FROM master.dbo.syslogins WHERE name = '" + user + @"')
            BEGIN
                CREATE LOGIN [" + user + @"] WITH PASSWORD=N'" + pass + @"', DEFAULT_DATABASE=[master], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
            END";

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
                cnn.Open();

                //Create user in SQLSERVER
                cmd = new SqlCommand(createUser, cnn);
                cmd.ExecuteNonQuery();

                //DELETE database if exist
                cmd = new SqlCommand(deleteDataBase, cnn);
                cmd.ExecuteNonQuery();

                //CREATE DB
                cmd = new SqlCommand(createBD, cnn);
                cmd.ExecuteNonQuery();

                //Associate user with db
                cmd = new SqlCommand(associatedUser, cnn);
                cmd.ExecuteNonQuery();

                System.Console.WriteLine("DataBase create sucessfully..");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
            }
        }

        public static void InitializeData()
        {
            /*PROTECTED REGION ID(initializeDataMethod) ENABLED START*/
            try
            {
                // Insert the initilizations of entities using the CEN classes


                // p.e. CustomerCEN customer = new CustomerCEN();
                // customer.New_ (p_user:"user", p_password:"1234");

                AdministradorCEN adminCEN = new AdministradorCEN();
                adminCEN.Registrarse("Protectora", "milpatitas@gmail.com", "patitas");

                if (adminCEN.Iniciar_Sesion("milpatitas@gmail.com", "patitas") != null)
                {
                    Console.WriteLine("El login de administrador es correcto");
                }

                UsuarioCEN usuCEN = new UsuarioCEN();
                usuCEN.Registrarse("Perico", "perico10@ciclismo", "1235");

                if (usuCEN.Iniciar_Sesion("perico10@ciclismo", "1235") != null)
                {
                    Console.WriteLine("El login es correcto");
                }

                UsuarioCEN juan99 = new UsuarioCEN();
                juan99.Registrarse("Juan", "juan20@gmail.com", "constantino1");
                UsuarioCEN manuel = new UsuarioCEN();
                manuel.Registrarse("Manuel45", "Manueljumilla@gmail.com", "password=5");
                UsuarioCEN Antonio = new UsuarioCEN();
                Antonio.Registrarse("Antonio53", "Antonio323@gmail.com", "villena92");

                MensajeCEN mensaCEN = new MensajeCEN();
                mensaCEN.Nuevo("milpatitas@gmail.com", "juan20@gmail.com", "prueba");

                AnimalCP chihua = new AnimalCP();
                chihua.Nuevo("tobi", 3, 'H', "Alicante", ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas.EstadoSaludEnum.sano, "amigable");
                AnimalCP yorkshire = new AnimalCP();
                yorkshire.Nuevo("Pelusa", 3, 'M', "Albacete", ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas.EstadoSaludEnum.enRecuperacion, "carinoso");
                AnimalCP siames = new AnimalCP();
                siames.Nuevo("minino", 1, 'H', "Alicante", ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas.EstadoSaludEnum.enfermo, "mimoso");


                // Console.WriteLine(" El animal es ");
                //Vamos a modificar el estado de tobi
                //   chihua.Modificar(1, "tobi", 3, 'H', "Alicante", "desagradable");
                //vamos a ver sus datos
                //  Console.WriteLine(chihua.Ver_Detalle_Animal(1));
                SolicitudAdopcionCEN solicitudAdopcionCEN = new SolicitudAdopcionCEN();

                solicitudAdopcionCEN.Nuevo("juan20@gmail.com", 65536);
                solicitudAdopcionCEN.Nuevo("Manueljumilla@gmail.com", 65536);


                /*PROTECTED REGION END*/


            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.InnerException);
                throw ex;
            }
        }
    }
}
