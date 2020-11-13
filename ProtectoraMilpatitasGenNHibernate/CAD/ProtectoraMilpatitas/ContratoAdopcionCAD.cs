
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
 * Clase ContratoAdopcion:
 *
 */

namespace ProtectoraMilpatitasGenNHibernate.CAD.ProtectoraMilpatitas
{
public partial class ContratoAdopcionCAD : BasicCAD, IContratoAdopcionCAD
{
public ContratoAdopcionCAD() : base ()
{
}

public ContratoAdopcionCAD(ISession sessionAux) : base (sessionAux)
{
}



public ContratoAdopcionEN ReadOIDDefault (int id
                                          )
{
        ContratoAdopcionEN contratoAdopcionEN = null;

        try
        {
                SessionInitializeTransaction ();
                contratoAdopcionEN = (ContratoAdopcionEN)session.Get (typeof(ContratoAdopcionEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProtectoraMilpatitasGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProtectoraMilpatitasGenNHibernate.Exceptions.DataLayerException ("Error in ContratoAdopcionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return contratoAdopcionEN;
}

public System.Collections.Generic.IList<ContratoAdopcionEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<ContratoAdopcionEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(ContratoAdopcionEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<ContratoAdopcionEN>();
                        else
                                result = session.CreateCriteria (typeof(ContratoAdopcionEN)).List<ContratoAdopcionEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProtectoraMilpatitasGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProtectoraMilpatitasGenNHibernate.Exceptions.DataLayerException ("Error in ContratoAdopcionCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (ContratoAdopcionEN contratoAdopcion)
{
        try
        {
                SessionInitializeTransaction ();
                ContratoAdopcionEN contratoAdopcionEN = (ContratoAdopcionEN)session.Load (typeof(ContratoAdopcionEN), contratoAdopcion.Id);

                contratoAdopcionEN.Nombre = contratoAdopcion.Nombre;


                contratoAdopcionEN.DNI_NIF_Pasaporte = contratoAdopcion.DNI_NIF_Pasaporte;


                contratoAdopcionEN.EscrituraHogar = contratoAdopcion.EscrituraHogar;


                contratoAdopcionEN.JustificantePago = contratoAdopcion.JustificantePago;


                contratoAdopcionEN.LugarRecojida = contratoAdopcion.LugarRecojida;


                contratoAdopcionEN.FirmaCompromiso = contratoAdopcion.FirmaCompromiso;


                contratoAdopcionEN.Estado = contratoAdopcion.Estado;





                session.Update (contratoAdopcionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProtectoraMilpatitasGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProtectoraMilpatitasGenNHibernate.Exceptions.DataLayerException ("Error in ContratoAdopcionCAD.", ex);
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
                ContratoAdopcionEN contratoAdopcionEN = (ContratoAdopcionEN)session.Load (typeof(ContratoAdopcionEN), id);
                session.Delete (contratoAdopcionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProtectoraMilpatitasGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProtectoraMilpatitasGenNHibernate.Exceptions.DataLayerException ("Error in ContratoAdopcionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Rellenar_Contrato (ContratoAdopcionEN contratoAdopcion)
{
        try
        {
                SessionInitializeTransaction ();
                ContratoAdopcionEN contratoAdopcionEN = (ContratoAdopcionEN)session.Load (typeof(ContratoAdopcionEN), contratoAdopcion.Id);

                contratoAdopcionEN.Nombre = contratoAdopcion.Nombre;


                contratoAdopcionEN.DNI_NIF_Pasaporte = contratoAdopcion.DNI_NIF_Pasaporte;


                contratoAdopcionEN.EscrituraHogar = contratoAdopcion.EscrituraHogar;


                contratoAdopcionEN.JustificantePago = contratoAdopcion.JustificantePago;


                contratoAdopcionEN.LugarRecojida = contratoAdopcion.LugarRecojida;


                contratoAdopcionEN.FirmaCompromiso = contratoAdopcion.FirmaCompromiso;

                session.Update (contratoAdopcionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProtectoraMilpatitasGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProtectoraMilpatitasGenNHibernate.Exceptions.DataLayerException ("Error in ContratoAdopcionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
//Sin e: Ver_Contrato
//Con e: ContratoAdopcionEN
public ContratoAdopcionEN Ver_Contrato (int id
                                        )
{
        ContratoAdopcionEN contratoAdopcionEN = null;

        try
        {
                SessionInitializeTransaction ();
                contratoAdopcionEN = (ContratoAdopcionEN)session.Get (typeof(ContratoAdopcionEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProtectoraMilpatitasGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProtectoraMilpatitasGenNHibernate.Exceptions.DataLayerException ("Error in ContratoAdopcionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return contratoAdopcionEN;
}

public System.Collections.Generic.IList<ContratoAdopcionEN> Dame_Todos (int first, int size)
{
        System.Collections.Generic.IList<ContratoAdopcionEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(ContratoAdopcionEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<ContratoAdopcionEN>();
                else
                        result = session.CreateCriteria (typeof(ContratoAdopcionEN)).List<ContratoAdopcionEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProtectoraMilpatitasGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProtectoraMilpatitasGenNHibernate.Exceptions.DataLayerException ("Error in ContratoAdopcionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public void Actualizar_Estado (ContratoAdopcionEN contratoAdopcion)
{
        try
        {
                SessionInitializeTransaction ();
                ContratoAdopcionEN contratoAdopcionEN = (ContratoAdopcionEN)session.Load (typeof(ContratoAdopcionEN), contratoAdopcion.Id);

                contratoAdopcionEN.Estado = contratoAdopcion.Estado;

                session.Update (contratoAdopcionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProtectoraMilpatitasGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProtectoraMilpatitasGenNHibernate.Exceptions.DataLayerException ("Error in ContratoAdopcionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.ContratoAdopcionEN> Obtener_Contrato_Usuario (string p_email)
{
        System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.ContratoAdopcionEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ContratoAdopcionEN self where select con FROM ContratoAdopcionEN as con WHERE con.Usuario.Email=:p_email";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ContratoAdopcionENObtener_Contrato_UsuarioHQL");
                query.SetParameter ("p_email", p_email);

                result = query.List<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.ContratoAdopcionEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProtectoraMilpatitasGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProtectoraMilpatitasGenNHibernate.Exceptions.DataLayerException ("Error in ContratoAdopcionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public int Nuevo (ContratoAdopcionEN contratoAdopcion)
{
        try
        {
                SessionInitializeTransaction ();
                if (contratoAdopcion.Usuario != null) {
                        // Argumento OID y no colección.
                        contratoAdopcion.Usuario = (ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.UsuarioEN)session.Load (typeof(ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.UsuarioEN), contratoAdopcion.Usuario.Email);

                        contratoAdopcion.Usuario.ContratoAdopcion
                        .Add (contratoAdopcion);
                }
                if (contratoAdopcion.SolicitudAdopcion != null) {
                        // Argumento OID y no colección.
                        contratoAdopcion.SolicitudAdopcion = (ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.SolicitudAdopcionEN)session.Load (typeof(ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.SolicitudAdopcionEN), contratoAdopcion.SolicitudAdopcion.Id);

                        contratoAdopcion.SolicitudAdopcion.ContratoAdopcion
                                = contratoAdopcion;
                }
                if (contratoAdopcion.Animal != null) {
                        // Argumento OID y no colección.
                        contratoAdopcion.Animal = (ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.AnimalEN)session.Load (typeof(ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.AnimalEN), contratoAdopcion.Animal.Id);

                        contratoAdopcion.Animal.ContratoAdopcion
                        .Add (contratoAdopcion);
                }

                session.Save (contratoAdopcion);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProtectoraMilpatitasGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProtectoraMilpatitasGenNHibernate.Exceptions.DataLayerException ("Error in ContratoAdopcionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return contratoAdopcion.Id;
}
}
}
