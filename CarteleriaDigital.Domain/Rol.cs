using System;
using System.Collections.Generic;

namespace CarteleriaDigital.Domain;

public partial class Rol
{
    public Guid IdRol { get; set; }

    public string NombreRol { get; set; } = null!;

    public virtual ICollection<UsuarioRol> UsuarioRols { get; set; } = new List<UsuarioRol>();
}
