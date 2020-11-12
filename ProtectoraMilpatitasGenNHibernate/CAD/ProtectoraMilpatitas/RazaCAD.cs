
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
 * Clase Raza:
 *
 */

namespace ProtectoraMilpatitasGenNHibernate.CAD.ProtectoraMilpatitas
{
public partial class RazaCAD : BasicCAD, IRazaCAD
{
public RazaCAD() : base ()
{
}

public RazaCAD(ISession sessionAux) : base (sessionAux)
{
}



public RazaEN ReadOIDDefault (int id
                              )
{
        RazaEN razaEN = null;

        try
        {
                SessionInitializeTransaction ();
                razaEN = (RazaEN)session.Get (typeof(RazaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProtectoraMilpatitasGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProtectoraMilpatitasGenNHibernate.Exceptions.DataLayerException ("Error in RazaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return razaEN;
}

public System.Collections.Generic.IList<RazaEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<RazaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(RazaEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<RazaEN>();
                        else
                                result = session.CreateCriteria (typeof(RazaEN)).List<RazaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProtectoraMilpatitasGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProtectoraMilpatitasGenNHibernate.Exceptions.DataLayerException ("Error in RazaCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (RazaEN raza)
{
        try
        {
                SessionInitializeTransaction ();
                RazaEN razaEN = (RazaEN)session.Load (typeof(RazaEN), raza.Id);

                razaEN.Nombre = raza.Nombre;


                session.Update (razaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProtectoraMilpatitasGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProtectoraMilpatitasGenNHibernate.Exceptions.DataLayerException ("Error in RazaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int Nuevo (RazaEN raza)
{
        try
        {
                SessionInitializeTransaction ();
                if (raza.Especie != null) {
                        // Argumento OID y no colección.
                        raza.Especie = (ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.EspecieEN)session.Load (typeof(ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.EspecieEN), raza.Especie.Id);

                        raza.Especie.Raza
                        .Add (raza);
                }

                session.Save (raza);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProtectoraMilpatitasGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProtectoraMilpatitasGenNHibernate.Exceptions.DataLayerException ("Error in RazaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return raza.Id;
}

public void Modificar (RazaEN raza)
{
        try
        {
                SessionInitializeTransaction ();
                RazaEN razaEN = (RazaEN)session.Load (typeof(RazaEN), raza.Id);

                razaEN.Nombre = raza.Nombre;

                session.Update (razaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProtectoraMilpatitasGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProtectoraMilpatitasGenNHibernate.Exceptions.DataLayerException ("Error in RazaCAD.", ex);
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
                RazaEN razaEN = (RazaEN)session.Load (typeof(RazaEN), id);
                session.Delete (razaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProtectoraMilpatitasGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProtectoraMilpatitasGenNHibernate.Exceptions.DataLayerException ("Error in RazaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<RazaEN> Dame_Todas (int first, int size)
{
        System.Collections.Generic.IList<RazaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(RazaEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<RazaEN>();
                else
                        result = session.CreateCriteria (typeof(RazaEN)).List<RazaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProtectoraMilpatitasGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProtectoraMilpatitasGenNHibernate.Exceptions.DataLayerException ("Error in RazaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

//Sin e: Dame_Por_Id
//Con e: RazaEN
public RazaEN Dame_Por_Id (int id
                           )
{
        RazaEN razaEN = null;

        try
        {
                SessionInitializeTransaction ();
                razaEN = (RazaEN)session.Get (typeof(RazaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProtectoraMilpatitasGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProtectoraMilpatitasGenNHibernate.Exceptions.DataLayerException ("Error in RazaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return razaEN;
}

public System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.RazaEN> Dame_Raza_Por_Especie (int p_especie)
{
        System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.RazaEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM RazaEN self where select raz FROM RazaEN as raz WHERE raz.Especie=:p_especie";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("RazaENdame_Raza_Por_EspecieHQL");
                query.SetParameter ("p_especie", p_especie);

                result = query.List<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.RazaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProtectoraMilpatitasGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProtectoraMilpatitasGenNHibernate.Exceptions.DataLayerException ("Error in RazaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
