
using System;
using System.Text;
using ProtectoraMilpatitasGenNHibernate.CEN.ProtectoraMilpatitas;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas;
using ProtectoraMilpatitasGenNHibernate.Exceptions;


/*
 * Clase TestAnimalIdeal:
 *
 */

namespace ProtectoraMilpatitasGenNHibernate.CAD.ProtectoraMilpatitas
{
public partial class TestAnimalIdealCAD : BasicCAD, ITestAnimalIdealCAD
{
public TestAnimalIdealCAD() : base ()
{
}

public TestAnimalIdealCAD(ISession sessionAux) : base (sessionAux)
{
}



public TestAnimalIdealEN ReadOIDDefault (int id
                                         )
{
        TestAnimalIdealEN testAnimalIdealEN = null;

        try
        {
                SessionInitializeTransaction ();
                testAnimalIdealEN = (TestAnimalIdealEN)session.Get (typeof(TestAnimalIdealEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProtectoraMilpatitasGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProtectoraMilpatitasGenNHibernate.Exceptions.DataLayerException ("Error in TestAnimalIdealCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return testAnimalIdealEN;
}

public System.Collections.Generic.IList<TestAnimalIdealEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<TestAnimalIdealEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(TestAnimalIdealEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<TestAnimalIdealEN>();
                        else
                                result = session.CreateCriteria (typeof(TestAnimalIdealEN)).List<TestAnimalIdealEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProtectoraMilpatitasGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProtectoraMilpatitasGenNHibernate.Exceptions.DataLayerException ("Error in TestAnimalIdealCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (TestAnimalIdealEN testAnimalIdeal)
{
        try
        {
                SessionInitializeTransaction ();
                TestAnimalIdealEN testAnimalIdealEN = (TestAnimalIdealEN)session.Load (typeof(TestAnimalIdealEN), testAnimalIdeal.Id);

                testAnimalIdealEN.AficionFavorita = testAnimalIdeal.AficionFavorita;


                testAnimalIdealEN.Personalidad = testAnimalIdeal.Personalidad;


                testAnimalIdealEN.ColorFavorito = testAnimalIdeal.ColorFavorito;



                testAnimalIdealEN.Resultado = testAnimalIdeal.Resultado;

                session.Update (testAnimalIdealEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProtectoraMilpatitasGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProtectoraMilpatitasGenNHibernate.Exceptions.DataLayerException ("Error in TestAnimalIdealCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public void Eliminar (int id
                      )
{
        try
        {
                SessionInitializeTransaction ();
                TestAnimalIdealEN testAnimalIdealEN = (TestAnimalIdealEN)session.Load (typeof(TestAnimalIdealEN), id);
                session.Delete (testAnimalIdealEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProtectoraMilpatitasGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProtectoraMilpatitasGenNHibernate.Exceptions.DataLayerException ("Error in TestAnimalIdealCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Rellenar_Test (TestAnimalIdealEN testAnimalIdeal)
{
        try
        {
                SessionInitializeTransaction ();
                TestAnimalIdealEN testAnimalIdealEN = (TestAnimalIdealEN)session.Load (typeof(TestAnimalIdealEN), testAnimalIdeal.Id);

                testAnimalIdealEN.AficionFavorita = testAnimalIdeal.AficionFavorita;


                testAnimalIdealEN.Personalidad = testAnimalIdeal.Personalidad;


                testAnimalIdealEN.ColorFavorito = testAnimalIdeal.ColorFavorito;

                session.Update (testAnimalIdealEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProtectoraMilpatitasGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProtectoraMilpatitasGenNHibernate.Exceptions.DataLayerException ("Error in TestAnimalIdealCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
//Sin e: Ver_Resultado
//Con e: TestAnimalIdealEN
public TestAnimalIdealEN Ver_Resultado (int id
                                        )
{
        TestAnimalIdealEN testAnimalIdealEN = null;

        try
        {
                SessionInitializeTransaction ();
                testAnimalIdealEN = (TestAnimalIdealEN)session.Get (typeof(TestAnimalIdealEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProtectoraMilpatitasGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProtectoraMilpatitasGenNHibernate.Exceptions.DataLayerException ("Error in TestAnimalIdealCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return testAnimalIdealEN;
}

public System.Collections.Generic.IList<TestAnimalIdealEN> Dame_Todos (int first, int size)
{
        System.Collections.Generic.IList<TestAnimalIdealEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(TestAnimalIdealEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<TestAnimalIdealEN>();
                else
                        result = session.CreateCriteria (typeof(TestAnimalIdealEN)).List<TestAnimalIdealEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProtectoraMilpatitasGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProtectoraMilpatitasGenNHibernate.Exceptions.DataLayerException ("Error in TestAnimalIdealCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public int Nuevo (TestAnimalIdealEN testAnimalIdeal)
{
        try
        {
                SessionInitializeTransaction ();
                if (testAnimalIdeal.Usuario != null) {
                        // Argumento OID y no colección.
                        testAnimalIdeal.Usuario = (ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.UsuarioEN)session.Load (typeof(ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.UsuarioEN), testAnimalIdeal.Usuario.Email);

                        testAnimalIdeal.Usuario.TestsAnimalIdeal
                        .Add (testAnimalIdeal);
                }

                session.Save (testAnimalIdeal);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProtectoraMilpatitasGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProtectoraMilpatitasGenNHibernate.Exceptions.DataLayerException ("Error in TestAnimalIdealCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return testAnimalIdeal.Id;
}
}
}
