using System;
using System.Collections.Generic;

namespace CarteleriaDigital.Domain;

public partial class UsuarioRol
{
    public Guid IdUsuarioRol { get; set; }

    public Guid IdUsuario { get; set; }

    public Guid IdRol { get; set; }

    public DateTime? FechaAsignacion { get; set; }

    public virtual Rol IdRolNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
