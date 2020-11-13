

using System;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using ProtectoraMilpatitasGenNHibernate.Exceptions;

using ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas;
using ProtectoraMilpatitasGenNHibernate.CAD.ProtectoraMilpatitas;


namespace ProtectoraMilpatitasGenNHibernate.CEN.ProtectoraMilpatitas
{
/*
 *      Definition of the class SeguimientoCEN
 *
 */
public partial class SeguimientoCEN
{
private ISeguimientoCAD _ISeguimientoCAD;

public SeguimientoCEN()
{
        this._ISeguimientoCAD = new SeguimientoCAD ();
}

public SeguimientoCEN(ISeguimientoCAD _ISeguimientoCAD)
{
        this._ISeguimientoCAD = _ISeguimientoCAD;
}

public ISeguimientoCAD get_ISeguimientoCAD ()
{
        return this._ISeguimientoCAD;
}

public void Eliminar (int id
                      )
{
        _ISeguimientoCAD.Eliminar (id);
}

public System.Collections.Generic.IList<SeguimientoEN> Dame_Todos (int first, int size)
{
        System.Collections.Generic.IList<SeguimientoEN> list = null;

        list = _ISeguimientoCAD.Dame_Todos (first, size);
        return list;
}
public SeguimientoEN Dame_Por_Id (int id
                                  )
{
        SeguimientoEN seguimientoEN = null;

        seguimientoEN = _ISeguimientoCAD.Dame_Por_Id (id);
        return seguimientoEN;
}

public System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.SeguimientoEN> Obtener_Seguimiento_Usuario (string p_usuario)
{
        return _ISeguimientoCAD.Obtener_Seguimiento_Usuario (p_usuario);
}
public int Nuevo (ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas.EstadoSeguimientoEnum p_estado, Nullable<DateTime> p_fecha, string p_usuario, int p_animal, int p_contratoAdopcion)
{
        SeguimientoEN seguimientoEN = null;
        int oid;

        //Initialized SeguimientoEN
        seguimientoEN = new SeguimientoEN ();
        seguimientoEN.Estado = p_estado;

        seguimientoEN.Fecha = p_fecha;


        if (p_usuario != null) {
                // El argumento p_usuario -> Property usuario es oid = false
                // Lista de oids id
                seguimientoEN.Usuario = new ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.UsuarioEN ();
                seguimientoEN.Usuario.Email = p_usuario;
        }


        if (p_animal != -1) {
                // El argumento p_animal -> Property animal es oid = false
                // Lista de oids id
                seguimientoEN.Animal = new ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.AnimalEN ();
                seguimientoEN.Animal.Id = p_animal;
        }


        if (p_contratoAdopcion != -1) {
                // El argumento p_contratoAdopcion -> Property contratoAdopcion es oid = false
                // Lista de oids id
                seguimientoEN.ContratoAdopcion = new ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.ContratoAdopcionEN ();
                seguimientoEN.ContratoAdopcion.Id = p_contratoAdopcion;
        }

        //Call to SeguimientoCAD

        oid = _ISeguimientoCAD.Nuevo (seguimientoEN);
        return oid;
}
}
}
