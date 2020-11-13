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
 * Clase SolicitudAdopcion:
 *
 */

namespace ProtectoraMilpatitasGenNHibernate.CAD.ProtectoraMilpatitas
{
    public partial class SolicitudAdopcionCAD : BasicCAD, ISolicitudAdopcionCAD
    {
        public SolicitudAdopcionCAD() : base()
        {
        }

        public SolicitudAdopcionCAD(ISession sessionAux) : base(sessionAux)
        {
        }



        public SolicitudAdopcionEN ReadOIDDefault(int id
                                                   )
        {
            SolicitudAdopcionEN solicitudAdopcionEN = null;

            try
            {
                SessionInitializeTransaction();
                solicitudAdopcionEN = (SolicitudAdopcionEN)session.Get(typeof(SolicitudAdopcionEN), id);
                SessionCommit();
            }

            catch (Exception ex)
            {
                SessionRollBack();
                if (ex is ProtectoraMilpatitasGenNHibernate.Exceptions.ModelException)
                    throw ex;
                throw new ProtectoraMilpatitasGenNHibernate.Exceptions.DataLayerException("Error in SolicitudAdopcionCAD.", ex);
            }


            finally
            {
                SessionClose();
            }

            return solicitudAdopcionEN;
        }

        public System.Collections.Generic.IList<SolicitudAdopcionEN> ReadAllDefault(int first, int size)
        {
            System.Collections.Generic.IList<SolicitudAdopcionEN> result = null;
            try
            {
                using (ITransaction tx = session.BeginTransaction())
                {
                    if (size > 0)
                        result = session.CreateCriteria(typeof(SolicitudAdopcionEN)).
                                 SetFirstResult(first).SetMaxResults(size).List<SolicitudAdopcionEN>();
                    else
                        result = session.CreateCriteria(typeof(SolicitudAdopcionEN)).List<SolicitudAdopcionEN>();
                }
            }

            catch (Exception ex)
            {
                SessionRollBack();
                if (ex is ProtectoraMilpatitasGenNHibernate.Exceptions.ModelException)
                    throw ex;
                throw new ProtectoraMilpatitasGenNHibernate.Exceptions.DataLayerException("Error in SolicitudAdopcionCAD.", ex);
            }

            return result;
        }

        // Modify default (Update all attributes of the class)

        public void ModifyDefault(SolicitudAdopcionEN solicitudAdopcion)
        {
            try
            {
                SessionInitializeTransaction();
                SolicitudAdopcionEN solicitudAdopcionEN = (SolicitudAdopcionEN)session.Load(typeof(SolicitudAdopcionEN), solicitudAdopcion.Id);

                solicitudAdopcionEN.Nombre = solicitudAdopcion.Nombre;


                solicitudAdopcionEN.AnimalesAcargo = solicitudAdopcion.AnimalesAcargo;


                solicitudAdopcionEN.AmbienteConvivencia = solicitudAdopcion.AmbienteConvivencia;


                solicitudAdopcionEN.TiempoLibre = solicitudAdopcion.TiempoLibre;


                solicitudAdopcionEN.TodosAcuerdo = solicitudAdopcion.TodosAcuerdo;


                solicitudAdopcionEN.MotivosAdopcion = solicitudAdopcion.MotivosAdopcion;


                solicitudAdopcionEN.Estado = solicitudAdopcion.Estado;





                session.Update(solicitudAdopcionEN);
                SessionCommit();
            }

            catch (Exception ex)
            {
                SessionRollBack();
                if (ex is ProtectoraMilpatitasGenNHibernate.Exceptions.ModelException)
                    throw ex;
                throw new ProtectoraMilpatitasGenNHibernate.Exceptions.DataLayerException("Error in SolicitudAdopcionCAD.", ex);
            }


            finally
            {
                SessionClose();
            }
        }


        public int Nuevo(SolicitudAdopcionEN solicitudAdopcion)
        {
            try
            {
                SessionInitializeTransaction();
                if (solicitudAdopcion.Usuario != null)
                {
                    // Argumento OID y no colección.
                    solicitudAdopcion.Usuario = (ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.UsuarioEN)session.Load(typeof(ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.UsuarioEN), solicitudAdopcion.Usuario.Email);

                    solicitudAdopcion.Usuario.SolicitudAdopcion
                    .Add(solicitudAdopcion);
                }
                if (solicitudAdopcion.Animal != null)
                {
                    // Argumento OID y no colección.
                    solicitudAdopcion.Animal = (ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.AnimalEN)session.Load(typeof(ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.AnimalEN), solicitudAdopcion.Animal.Id);

                    solicitudAdopcion.Animal.SolicitudAdopcion
                    .Add(solicitudAdopcion);
                }

                session.Save(solicitudAdopcion);
                SessionCommit();
            }

            catch (Exception ex)
            {
                SessionRollBack();
                if (ex is ProtectoraMilpatitasGenNHibernate.Exceptions.ModelException)
                    throw ex;
                throw new ProtectoraMilpatitasGenNHibernate.Exceptions.DataLayerException("Error in SolicitudAdopcionCAD.", ex);
            }


            finally
            {
                SessionClose();
            }

            return solicitudAdopcion.Id;
        }

        public void Eliminar(int id
                              )
        {
            try
            {
                SessionInitializeTransaction();
                SolicitudAdopcionEN solicitudAdopcionEN = (SolicitudAdopcionEN)session.Load(typeof(SolicitudAdopcionEN), id);
                session.Delete(solicitudAdopcionEN);
                SessionCommit();
            }

            catch (Exception ex)
            {
                SessionRollBack();
                if (ex is ProtectoraMilpatitasGenNHibernate.Exceptions.ModelException)
                    throw ex;
                throw new ProtectoraMilpatitasGenNHibernate.Exceptions.DataLayerException("Error in SolicitudAdopcionCAD.", ex);
            }


            finally
            {
                SessionClose();
            }
        }

        public void Rellenar_Solicitud(SolicitudAdopcionEN solicitudAdopcion)
        {
            try
            {
                SessionInitializeTransaction();
                SolicitudAdopcionEN solicitudAdopcionEN = (SolicitudAdopcionEN)session.Load(typeof(SolicitudAdopcionEN), solicitudAdopcion.Id);

                solicitudAdopcionEN.Nombre = solicitudAdopcion.Nombre;


                solicitudAdopcionEN.AnimalesAcargo = solicitudAdopcion.AnimalesAcargo;


                solicitudAdopcionEN.AmbienteConvivencia = solicitudAdopcion.AmbienteConvivencia;


                solicitudAdopcionEN.TiempoLibre = solicitudAdopcion.TiempoLibre;


                solicitudAdopcionEN.TodosAcuerdo = solicitudAdopcion.TodosAcuerdo;


                solicitudAdopcionEN.MotivosAdopcion = solicitudAdopcion.MotivosAdopcion;

                session.Update(solicitudAdopcionEN);
                SessionCommit();
            }

            catch (Exception ex)
            {
                SessionRollBack();
                if (ex is ProtectoraMilpatitasGenNHibernate.Exceptions.ModelException)
                    throw ex;
                throw new ProtectoraMilpatitasGenNHibernate.Exceptions.DataLayerException("Error in SolicitudAdopcionCAD.", ex);
            }


            finally
            {
                SessionClose();
            }
        }
        //Sin e: Ver_Solicitud
        //Con e: SolicitudAdopcionEN
        public SolicitudAdopcionEN Ver_Solicitud(int id
                                                  )
        {
            SolicitudAdopcionEN solicitudAdopcionEN = null;

            try
            {
                SessionInitializeTransaction();
                solicitudAdopcionEN = (SolicitudAdopcionEN)session.Get(typeof(SolicitudAdopcionEN), id);
                SessionCommit();
            }

            catch (Exception ex)
            {
                SessionRollBack();
                if (ex is ProtectoraMilpatitasGenNHibernate.Exceptions.ModelException)
                    throw ex;
                throw new ProtectoraMilpatitasGenNHibernate.Exceptions.DataLayerException("Error in SolicitudAdopcionCAD.", ex);
            }


            finally
            {
                SessionClose();
            }

            return solicitudAdopcionEN;
        }

        public System.Collections.Generic.IList<SolicitudAdopcionEN> Dame_Todas(int first, int size)
        {
            System.Collections.Generic.IList<SolicitudAdopcionEN> result = null;
            try
            {
                SessionInitializeTransaction();
                if (size > 0)
                    result = session.CreateCriteria(typeof(SolicitudAdopcionEN)).
                             SetFirstResult(first).SetMaxResults(size).List<SolicitudAdopcionEN>();
                else
                    result = session.CreateCriteria(typeof(SolicitudAdopcionEN)).List<SolicitudAdopcionEN>();
                SessionCommit();
            }

            catch (Exception ex)
            {
                SessionRollBack();
                if (ex is ProtectoraMilpatitasGenNHibernate.Exceptions.ModelException)
                    throw ex;
                throw new ProtectoraMilpatitasGenNHibernate.Exceptions.DataLayerException("Error in SolicitudAdopcionCAD.", ex);
            }


            finally
            {
                SessionClose();
            }

            return result;
        }

        public void Actualizar_Estado(SolicitudAdopcionEN solicitudAdopcion)
        {
            try
            {
                SessionInitializeTransaction();
                SolicitudAdopcionEN solicitudAdopcionEN = (SolicitudAdopcionEN)session.Load(typeof(SolicitudAdopcionEN), solicitudAdopcion.Id);

                solicitudAdopcionEN.Estado = solicitudAdopcion.Estado;

                session.Update(solicitudAdopcionEN);
                SessionCommit();
            }

            catch (Exception ex)
            {
                SessionRollBack();
                if (ex is ProtectoraMilpatitasGenNHibernate.Exceptions.ModelException)
                    throw ex;
                throw new ProtectoraMilpatitasGenNHibernate.Exceptions.DataLayerException("Error in SolicitudAdopcionCAD.", ex);
            }


            finally
            {
                SessionClose();
            }
        }
        public System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.SolicitudAdopcionEN> Obtener_Solicitud_Usuario(string p_email)
        {
            System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.SolicitudAdopcionEN> result;
            try
            {
                SessionInitializeTransaction();
                //String sql = @"FROM SolicitudAdopcionEN self where select sol FROM SolicitudAdopcionEN as sol INNER JOIN sol.Usuario as usu WHERE usu.Email=:p_email";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery("SolicitudAdopcionENObtener_Solicitud_UsuarioHQL");
                query.SetParameter("p_email", p_email);

                result = query.List<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.SolicitudAdopcionEN>();
                SessionCommit();
            }

            catch (Exception ex)
            {
                SessionRollBack();
                if (ex is ProtectoraMilpatitasGenNHibernate.Exceptions.ModelException)
                    throw ex;
                throw new ProtectoraMilpatitasGenNHibernate.Exceptions.DataLayerException("Error in SolicitudAdopcionCAD.", ex);
            }


            finally
            {
                SessionClose();
            }

            return result;
        }
    }
}