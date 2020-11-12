

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
}
}
