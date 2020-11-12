
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
 * Clase Usuario:
 *
 */

namespace ProtectoraMilpatitasGenNHibernate.CAD.ProtectoraMilpatitas
{
public partial class UsuarioCAD : BasicCAD, IUsuarioCAD
{
public UsuarioCAD() : base ()
{
}

public UsuarioCAD(ISession sessionAux) : base (sessionAux)
{
}



public UsuarioEN ReadOIDDefault (string email
                                 )
{
        UsuarioEN usuarioEN = null;

        try
        {
                SessionInitializeTransaction ();
                usuarioEN = (UsuarioEN)session.Get (typeof(UsuarioEN), email);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProtectoraMilpatitasGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProtectoraMilpatitasGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return usuarioEN;
}

public System.Collections.Generic.IList<UsuarioEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<UsuarioEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(UsuarioEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<UsuarioEN>();
                        else
                                result = session.CreateCriteria (typeof(UsuarioEN)).List<UsuarioEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProtectoraMilpatitasGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProtectoraMilpatitasGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (UsuarioEN usuario)
{
        try
        {
                SessionInitializeTransaction ();
                UsuarioEN usuarioEN = (UsuarioEN)session.Load (typeof(UsuarioEN), usuario.Email);

                usuarioEN.Nombre = usuario.Nombre;









                usuarioEN.Password = usuario.Password;

                session.Update (usuarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProtectoraMilpatitasGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProtectoraMilpatitasGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public string Registrarse (UsuarioEN usuario)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (usuario);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProtectoraMilpatitasGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProtectoraMilpatitasGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return usuario.Email;
}

public void Modificar (UsuarioEN usuario)
{
        try
        {
                SessionInitializeTransaction ();
                UsuarioEN usuarioEN = (UsuarioEN)session.Load (typeof(UsuarioEN), usuario.Email);

                usuarioEN.Nombre = usuario.Nombre;


                usuarioEN.Password = usuario.Password;

                session.Update (usuarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProtectoraMilpatitasGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProtectoraMilpatitasGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Eliminar (string email
                      )
{
        try
        {
                SessionInitializeTransaction ();
                UsuarioEN usuarioEN = (UsuarioEN)session.Load (typeof(UsuarioEN), email);
                session.Delete (usuarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProtectoraMilpatitasGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProtectoraMilpatitasGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<UsuarioEN> Dame_Todos (int first, int size)
{
        System.Collections.Generic.IList<UsuarioEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(UsuarioEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<UsuarioEN>();
                else
                        result = session.CreateCriteria (typeof(UsuarioEN)).List<UsuarioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProtectoraMilpatitasGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProtectoraMilpatitasGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

//Sin e: Dame_Por_Email
//Con e: UsuarioEN
public UsuarioEN Dame_Por_Email (string email
                                 )
{
        UsuarioEN usuarioEN = null;

        try
        {
                SessionInitializeTransaction ();
                usuarioEN = (UsuarioEN)session.Get (typeof(UsuarioEN), email);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProtectoraMilpatitasGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProtectoraMilpatitasGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return usuarioEN;
}
}
}
