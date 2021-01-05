
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
 * Clase Seguimiento:
 *
 */

namespace ProtectoraMilpatitasGenNHibernate.CAD.ProtectoraMilpatitas
{
public partial class SeguimientoCAD : BasicCAD, ISeguimientoCAD
{
public SeguimientoCAD() : base ()
{
}

public SeguimientoCAD(ISession sessionAux) : base (sessionAux)
{
}



public SeguimientoEN ReadOIDDefault (int id
                                     )
{
        SeguimientoEN seguimientoEN = null;

        try
        {
                SessionInitializeTransaction ();
                seguimientoEN = (SeguimientoEN)session.Get (typeof(SeguimientoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProtectoraMilpatitasGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProtectoraMilpatitasGenNHibernate.Exceptions.DataLayerException ("Error in SeguimientoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return seguimientoEN;
}

public System.Collections.Generic.IList<SeguimientoEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<SeguimientoEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(SeguimientoEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<SeguimientoEN>();
                        else
                                result = session.CreateCriteria (typeof(SeguimientoEN)).List<SeguimientoEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProtectoraMilpatitasGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProtectoraMilpatitasGenNHibernate.Exceptions.DataLayerException ("Error in SeguimientoCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (SeguimientoEN seguimiento)
{
        try
        {
                SessionInitializeTransaction ();
                SeguimientoEN seguimientoEN = (SeguimientoEN)session.Load (typeof(SeguimientoEN), seguimiento.Id);

                seguimientoEN.Estado = seguimiento.Estado;


                seguimientoEN.Fecha = seguimiento.Fecha;





                seguimientoEN.Descripcion = seguimiento.Descripcion;

                session.Update (seguimientoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProtectoraMilpatitasGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProtectoraMilpatitasGenNHibernate.Exceptions.DataLayerException ("Error in SeguimientoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public void Modificar (SeguimientoEN seguimiento)
{
        try
        {
                SessionInitializeTransaction ();
                SeguimientoEN seguimientoEN = (SeguimientoEN)session.Load (typeof(SeguimientoEN), seguimiento.Id);

                seguimientoEN.Fecha = seguimiento.Fecha;


                seguimientoEN.Descripcion = seguimiento.Descripcion;

                session.Update (seguimientoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProtectoraMilpatitasGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProtectoraMilpatitasGenNHibernate.Exceptions.DataLayerException ("Error in SeguimientoCAD.", ex);
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
                SeguimientoEN seguimientoEN = (SeguimientoEN)session.Load (typeof(SeguimientoEN), id);
                session.Delete (seguimientoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProtectoraMilpatitasGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProtectoraMilpatitasGenNHibernate.Exceptions.DataLayerException ("Error in SeguimientoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Actualizar_Estado (SeguimientoEN seguimiento)
{
        try
        {
                SessionInitializeTransaction ();
                SeguimientoEN seguimientoEN = (SeguimientoEN)session.Load (typeof(SeguimientoEN), seguimiento.Id);

                seguimientoEN.Estado = seguimiento.Estado;

                session.Update (seguimientoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProtectoraMilpatitasGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProtectoraMilpatitasGenNHibernate.Exceptions.DataLayerException ("Error in SeguimientoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public System.Collections.Generic.IList<SeguimientoEN> Dame_Todos (int first, int size)
{
        System.Collections.Generic.IList<SeguimientoEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(SeguimientoEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<SeguimientoEN>();
                else
                        result = session.CreateCriteria (typeof(SeguimientoEN)).List<SeguimientoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProtectoraMilpatitasGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProtectoraMilpatitasGenNHibernate.Exceptions.DataLayerException ("Error in SeguimientoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

//Sin e: Dame_Por_Id
//Con e: SeguimientoEN
public SeguimientoEN Dame_Por_Id (int id
                                  )
{
        SeguimientoEN seguimientoEN = null;

        try
        {
                SessionInitializeTransaction ();
                seguimientoEN = (SeguimientoEN)session.Get (typeof(SeguimientoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProtectoraMilpatitasGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProtectoraMilpatitasGenNHibernate.Exceptions.DataLayerException ("Error in SeguimientoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return seguimientoEN;
}

public System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.SeguimientoEN> Obtener_Seguimiento_Usuario (string p_usuario)
{
        System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.SeguimientoEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM SeguimientoEN self where select seg FROM SeguimientoEN as seg WHERE seg.Usuario.Email=:p_usuario";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("SeguimientoENObtener_Seguimiento_UsuarioHQL");
                query.SetParameter ("p_usuario", p_usuario);

                result = query.List<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.SeguimientoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProtectoraMilpatitasGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProtectoraMilpatitasGenNHibernate.Exceptions.DataLayerException ("Error in SeguimientoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public int Nuevo (SeguimientoEN seguimiento)
{
        try
        {
                SessionInitializeTransaction ();
                if (seguimiento.Usuario != null) {
                        // Argumento OID y no colección.
                        seguimiento.Usuario = (ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.UsuarioEN)session.Load (typeof(ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.UsuarioEN), seguimiento.Usuario.Email);

                        seguimiento.Usuario.Seguimiento
                        .Add (seguimiento);
                }
                if (seguimiento.Animal != null) {
                        // Argumento OID y no colección.
                        seguimiento.Animal = (ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.AnimalEN)session.Load (typeof(ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.AnimalEN), seguimiento.Animal.Id);

                        seguimiento.Animal.Seguimiento
                        .Add (seguimiento);
                }
                if (seguimiento.ContratoAdopcion != null) {
                        // Argumento OID y no colección.
                        seguimiento.ContratoAdopcion = (ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.ContratoAdopcionEN)session.Load (typeof(ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.ContratoAdopcionEN), seguimiento.ContratoAdopcion.Id);

                        seguimiento.ContratoAdopcion.Seguimiento
                                = seguimiento;
                }

                session.Save (seguimiento);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProtectoraMilpatitasGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProtectoraMilpatitasGenNHibernate.Exceptions.DataLayerException ("Error in SeguimientoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return seguimiento.Id;
}
}
}
