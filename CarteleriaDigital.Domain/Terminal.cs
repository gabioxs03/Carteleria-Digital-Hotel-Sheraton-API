using System;
using System.Collections.Generic;

namespace CarteleriaDigital.Domain;

public partial class Terminal
{
    public Guid IdTerminal { get; set; }

    public string Nombre { get; set; } = null!;

    public string Mac { get; set; } = null!;

    public int? Estado { get; set; }

    public DateTime? UltimaConexion { get; set; }

    public decimal? Latitud { get; set; }

    public decimal? Longitud { get; set; }

    public string? CodigoAeropuerto { get; set; }

    public bool? Activo { get; set; }

    public virtual ICollection<Programacion> Programacions { get; set; } = new List<Programacion>();

    public virtual ICollection<RegistroReproduccion> RegistroReproduccions { get; set; } = new List<RegistroReproduccion>();
}
