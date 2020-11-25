
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
 * Clase Especie:
 *
 */

namespace ProtectoraMilpatitasGenNHibernate.CAD.ProtectoraMilpatitas
{
public partial class EspecieCAD : BasicCAD, IEspecieCAD
{
public EspecieCAD() : base ()
{
}

public EspecieCAD(ISession sessionAux) : base (sessionAux)
{
}



public EspecieEN ReadOIDDefault (int id
                                 )
{
        EspecieEN especieEN = null;

        try
        {
                SessionInitializeTransaction ();
                especieEN = (EspecieEN)session.Get (typeof(EspecieEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProtectoraMilpatitasGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProtectoraMilpatitasGenNHibernate.Exceptions.DataLayerException ("Error in EspecieCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return especieEN;
}

public System.Collections.Generic.IList<EspecieEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<EspecieEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(EspecieEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<EspecieEN>();
                        else
                                result = session.CreateCriteria (typeof(EspecieEN)).List<EspecieEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProtectoraMilpatitasGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProtectoraMilpatitasGenNHibernate.Exceptions.DataLayerException ("Error in EspecieCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (EspecieEN especie)
{
        try
        {
                SessionInitializeTransaction ();
                EspecieEN especieEN = (EspecieEN)session.Load (typeof(EspecieEN), especie.Id);

                especieEN.Nombre = especie.Nombre;



                session.Update (especieEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProtectoraMilpatitasGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProtectoraMilpatitasGenNHibernate.Exceptions.DataLayerException ("Error in EspecieCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int Nuevo (EspecieEN especie)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (especie);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProtectoraMilpatitasGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProtectoraMilpatitasGenNHibernate.Exceptions.DataLayerException ("Error in EspecieCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return especie.Id;
}

public void Modifcar (EspecieEN especie)
{
        try
        {
                SessionInitializeTransaction ();
                EspecieEN especieEN = (EspecieEN)session.Load (typeof(EspecieEN), especie.Id);

                especieEN.Nombre = especie.Nombre;

                session.Update (especieEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProtectoraMilpatitasGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProtectoraMilpatitasGenNHibernate.Exceptions.DataLayerException ("Error in EspecieCAD.", ex);
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
                EspecieEN especieEN = (EspecieEN)session.Load (typeof(EspecieEN), id);
                session.Delete (especieEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProtectoraMilpatitasGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProtectoraMilpatitasGenNHibernate.Exceptions.DataLayerException ("Error in EspecieCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<EspecieEN> Dame_Todas (int first, int size)
{
        System.Collections.Generic.IList<EspecieEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(EspecieEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<EspecieEN>();
                else
                        result = session.CreateCriteria (typeof(EspecieEN)).List<EspecieEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProtectoraMilpatitasGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProtectoraMilpatitasGenNHibernate.Exceptions.DataLayerException ("Error in EspecieCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

//Sin e: Dame_Por_Id
//Con e: EspecieEN
public EspecieEN Dame_Por_Id (int id
                              )
{
        EspecieEN especieEN = null;

        try
        {
                SessionInitializeTransaction ();
                especieEN = (EspecieEN)session.Get (typeof(EspecieEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProtectoraMilpatitasGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProtectoraMilpatitasGenNHibernate.Exceptions.DataLayerException ("Error in EspecieCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return especieEN;
}
}
}
