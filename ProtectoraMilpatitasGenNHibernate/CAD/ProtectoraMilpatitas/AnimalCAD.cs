
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
 * Clase Animal:
 *
 */

namespace ProtectoraMilpatitasGenNHibernate.CAD.ProtectoraMilpatitas
{
public partial class AnimalCAD : BasicCAD, IAnimalCAD
{
public AnimalCAD() : base ()
{
}

public AnimalCAD(ISession sessionAux) : base (sessionAux)
{
}



public AnimalEN ReadOIDDefault (int id
                                )
{
        AnimalEN animalEN = null;

        try
        {
                SessionInitializeTransaction ();
                animalEN = (AnimalEN)session.Get (typeof(AnimalEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProtectoraMilpatitasGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProtectoraMilpatitasGenNHibernate.Exceptions.DataLayerException ("Error in AnimalCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return animalEN;
}

public System.Collections.Generic.IList<AnimalEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<AnimalEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(AnimalEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<AnimalEN>();
                        else
                                result = session.CreateCriteria (typeof(AnimalEN)).List<AnimalEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProtectoraMilpatitasGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProtectoraMilpatitasGenNHibernate.Exceptions.DataLayerException ("Error in AnimalCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (AnimalEN animal)
{
        try
        {
                SessionInitializeTransaction ();
                AnimalEN animalEN = (AnimalEN)session.Load (typeof(AnimalEN), animal.Id);

                animalEN.Nombre = animal.Nombre;


                animalEN.Edad = animal.Edad;


                animalEN.Sexo = animal.Sexo;


                animalEN.Centro = animal.Centro;


                animalEN.DatosMedicos = animal.DatosMedicos;


                animalEN.Caracter = animal.Caracter;







                animalEN.EstadoAdopcion = animal.EstadoAdopcion;

                session.Update (animalEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProtectoraMilpatitasGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProtectoraMilpatitasGenNHibernate.Exceptions.DataLayerException ("Error in AnimalCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int Nuevo (AnimalEN animal)
{
        try
        {
                SessionInitializeTransaction ();
                if (animal.Especie != null) {
                        // Argumento OID y no colección.
                        animal.Especie = (ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.EspecieEN)session.Load (typeof(ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.EspecieEN), animal.Especie.Id);

                        animal.Especie.Animal
                        .Add (animal);
                }

                session.Save (animal);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProtectoraMilpatitasGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProtectoraMilpatitasGenNHibernate.Exceptions.DataLayerException ("Error in AnimalCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return animal.Id;
}

public void Modificar (AnimalEN animal)
{
        try
        {
                SessionInitializeTransaction ();
                AnimalEN animalEN = (AnimalEN)session.Load (typeof(AnimalEN), animal.Id);

                animalEN.Nombre = animal.Nombre;


                animalEN.Edad = animal.Edad;


                animalEN.Sexo = animal.Sexo;


                animalEN.Centro = animal.Centro;


                animalEN.Caracter = animal.Caracter;

                session.Update (animalEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProtectoraMilpatitasGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProtectoraMilpatitasGenNHibernate.Exceptions.DataLayerException ("Error in AnimalCAD.", ex);
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
                AnimalEN animalEN = (AnimalEN)session.Load (typeof(AnimalEN), id);
                session.Delete (animalEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProtectoraMilpatitasGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProtectoraMilpatitasGenNHibernate.Exceptions.DataLayerException ("Error in AnimalCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: Ver_Detalle_Animal
//Con e: AnimalEN
public AnimalEN Ver_Detalle_Animal (int id
                                    )
{
        AnimalEN animalEN = null;

        try
        {
                SessionInitializeTransaction ();
                animalEN = (AnimalEN)session.Get (typeof(AnimalEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProtectoraMilpatitasGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProtectoraMilpatitasGenNHibernate.Exceptions.DataLayerException ("Error in AnimalCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return animalEN;
}

public System.Collections.Generic.IList<AnimalEN> Dame_Todos (int first, int size)
{
        System.Collections.Generic.IList<AnimalEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(AnimalEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<AnimalEN>();
                else
                        result = session.CreateCriteria (typeof(AnimalEN)).List<AnimalEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProtectoraMilpatitasGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProtectoraMilpatitasGenNHibernate.Exceptions.DataLayerException ("Error in AnimalCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public void Actualizar_DatosMedicos (AnimalEN animal)
{
        try
        {
                SessionInitializeTransaction ();
                AnimalEN animalEN = (AnimalEN)session.Load (typeof(AnimalEN), animal.Id);

                animalEN.DatosMedicos = animal.DatosMedicos;

                session.Update (animalEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProtectoraMilpatitasGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProtectoraMilpatitasGenNHibernate.Exceptions.DataLayerException ("Error in AnimalCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Actualizar_Estado (AnimalEN animal)
{
        try
        {
                SessionInitializeTransaction ();
                AnimalEN animalEN = (AnimalEN)session.Load (typeof(AnimalEN), animal.Id);

                animalEN.EstadoAdopcion = animal.EstadoAdopcion;

                session.Update (animalEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProtectoraMilpatitasGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProtectoraMilpatitasGenNHibernate.Exceptions.DataLayerException ("Error in AnimalCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.AnimalEN> BuscarAnimales (string p_nombre, int? p_edad, char p_sexo, string p_centro, ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas.EstadoSaludEnum? p_datosMedicos, string p_caracter)
{
        System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.AnimalEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM AnimalEN self where select ani FROM AnimalEN as ani where ani.Nombre=:p_nombre OR ani.Edad=:p_edad OR ani.Sexo=:p_sexo OR ani.Centro=:p_centro OR ani.DatosMedicos=:p_datos OR ani.Caracter=:p_caracter";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("AnimalENbuscarAnimalesHQL");
                query.SetParameter ("p_nombre", p_nombre);
                query.SetParameter ("p_edad", p_edad);
                query.SetParameter ("p_sexo", p_sexo);
                query.SetParameter ("p_centro", p_centro);
                query.SetParameter ("p_datosMedicos", p_datosMedicos);
                query.SetParameter ("p_caracter", p_caracter);

                result = query.List<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.AnimalEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProtectoraMilpatitasGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProtectoraMilpatitasGenNHibernate.Exceptions.DataLayerException ("Error in AnimalCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.AnimalEN> Dame_Animales_Por_Especie (int p_especie)
{
        System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.AnimalEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM AnimalEN self where select ani FROM AnimalEN as ani WHERE ani.Especie=:p_especie";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("AnimalENdame_Animales_Por_EspecieHQL");
                query.SetParameter ("p_especie", p_especie);

                result = query.List<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.AnimalEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProtectoraMilpatitasGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProtectoraMilpatitasGenNHibernate.Exceptions.DataLayerException ("Error in AnimalCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.AnimalEN> Obtener_Animal_Usuario (string p_email)
{
        System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.AnimalEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM AnimalEN self where select ani FROM AnimalEN as ani WHERE ani.Dueño is not empty and ani.Dueño.Email=:p_email";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("AnimalENObtener_Animal_UsuarioHQL");
                query.SetParameter ("p_email", p_email);

                result = query.List<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.AnimalEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProtectoraMilpatitasGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProtectoraMilpatitasGenNHibernate.Exceptions.DataLayerException ("Error in AnimalCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
