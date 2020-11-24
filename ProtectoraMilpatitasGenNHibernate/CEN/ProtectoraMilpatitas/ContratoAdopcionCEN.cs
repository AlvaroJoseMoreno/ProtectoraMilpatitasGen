

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
 *      Definition of the class ContratoAdopcionCEN
 *
 */
public partial class ContratoAdopcionCEN
{
private IContratoAdopcionCAD _IContratoAdopcionCAD;

public ContratoAdopcionCEN()
{
        this._IContratoAdopcionCAD = new ContratoAdopcionCAD ();
}

public ContratoAdopcionCEN(IContratoAdopcionCAD _IContratoAdopcionCAD)
{
        this._IContratoAdopcionCAD = _IContratoAdopcionCAD;
}

public IContratoAdopcionCAD get_IContratoAdopcionCAD ()
{
        return this._IContratoAdopcionCAD;
}

public void Eliminar (int id
                      )
{
        _IContratoAdopcionCAD.Eliminar (id);
}

public ContratoAdopcionEN Ver_Contrato (int id
                                        )
{
        ContratoAdopcionEN contratoAdopcionEN = null;

        contratoAdopcionEN = _IContratoAdopcionCAD.Ver_Contrato (id);
        return contratoAdopcionEN;
}

public System.Collections.Generic.IList<ContratoAdopcionEN> Dame_Todos (int first, int size)
{
        System.Collections.Generic.IList<ContratoAdopcionEN> list = null;

        list = _IContratoAdopcionCAD.Dame_Todos (first, size);
        return list;
}
public System.Collections.Generic.IList<ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.ContratoAdopcionEN> Obtener_Contrato_Usuario (string p_email)
{
        return _IContratoAdopcionCAD.Obtener_Contrato_Usuario (p_email);
}
public int Nuevo (string p_usuario, int p_solicitudAdopcion, int p_animal)
{
        ContratoAdopcionEN contratoAdopcionEN = null;
        int oid;

        //Initialized ContratoAdopcionEN
        contratoAdopcionEN = new ContratoAdopcionEN ();

        if (p_usuario != null) {
                // El argumento p_usuario -> Property usuario es oid = false
                // Lista de oids id
                contratoAdopcionEN.Usuario = new ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.UsuarioEN ();
                contratoAdopcionEN.Usuario.Email = p_usuario;
        }


        if (p_solicitudAdopcion != -1) {
                // El argumento p_solicitudAdopcion -> Property solicitudAdopcion es oid = false
                // Lista de oids id
                contratoAdopcionEN.SolicitudAdopcion = new ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.SolicitudAdopcionEN ();
                contratoAdopcionEN.SolicitudAdopcion.Id = p_solicitudAdopcion;
        }


        if (p_animal != -1) {
                // El argumento p_animal -> Property animal es oid = false
                // Lista de oids id
                contratoAdopcionEN.Animal = new ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas.AnimalEN ();
                contratoAdopcionEN.Animal.Id = p_animal;
        }

        //Call to ContratoAdopcionCAD

        oid = _IContratoAdopcionCAD.Nuevo (contratoAdopcionEN);
        return oid;
}
}
}
