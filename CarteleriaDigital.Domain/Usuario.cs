using System;
using System.Collections.Generic;

namespace CarteleriaDigital.Domain;

public partial class Usuario
{
    public Guid IdUsuario { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Mail { get; set; } = null!;

    public string Usuario1 { get; set; } = null!;

    public string Contraseña { get; set; } = null!;

    public bool? Activo { get; set; }

    public virtual ICollection<ContenidoMultimedia> ContenidoMultimedia { get; set; } = new List<ContenidoMultimedia>();

    public virtual ICollection<ListaReproduccion> ListaReproduccions { get; set; } = new List<ListaReproduccion>();

    public virtual ICollection<Programacion> Programacions { get; set; } = new List<Programacion>();

    public virtual ICollection<UsuarioRol> UsuarioRols { get; set; } = new List<UsuarioRol>();
}
