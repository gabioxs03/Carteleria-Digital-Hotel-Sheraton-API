using System;
using System.Collections.Generic;

namespace CarteleriaDigital.Domain;

public partial class ListaReproduccion
{
    public Guid IdLista { get; set; }

    public Guid IdUsuario { get; set; }

    public string NombreLista { get; set; } = null!;

    public string? Descripcion { get; set; }

    public bool? EsDefault { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public int? DuracionSegLista { get; set; }

    public bool? Activo { get; set; }

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;

    public virtual ICollection<ListaItem> ListaItems { get; set; } = new List<ListaItem>();

    public virtual ICollection<Programacion> Programacions { get; set; } = new List<Programacion>();

    public virtual ICollection<RegistroReproduccion> RegistroReproduccions { get; set; } = new List<RegistroReproduccion>();
}
