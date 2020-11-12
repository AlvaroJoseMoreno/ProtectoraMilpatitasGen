
using System;
using System.Text;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using ProtectoraMilpatitasGenNHibernate.Exceptions;
using ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas;
using ProtectoraMilpatitasGenNHibernate.CAD.ProtectoraMilpatitas;
using ProtectoraMilpatitasGenNHibernate.CEN.ProtectoraMilpatitas;



namespace ProtectoraMilpatitasGenNHibernate.CP.ProtectoraMilpatitas
{
public partial class MensajeCP : BasicCP
{
public MensajeCP() : base ()
{
}

public MensajeCP(ISession sessionAux)
        : base (sessionAux)
{
}
}
}
