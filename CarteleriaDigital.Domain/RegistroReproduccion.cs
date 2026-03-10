using System;
using System.Collections.Generic;

namespace CarteleriaDigital.Domain;

public partial class RegistroReproduccion
{
    public long IdRegistro { get; set; }

    public Guid IdTerminal { get; set; }

    public Guid IdLista { get; set; }

    public Guid IdContenido { get; set; }

    public Guid? IdProgramacion { get; set; }

    public string TipoEvento { get; set; } = null!;

    public int? DuracionReal { get; set; }

    public string? Detalle { get; set; }

    public DateTime? FechaEvento { get; set; }

    public virtual ContenidoMultimedia IdContenidoNavigation { get; set; } = null!;

    public virtual ListaReproduccion IdListaNavigation { get; set; } = null!;

    public virtual Programacion? IdProgramacionNavigation { get; set; }

    public virtual Terminal IdTerminalNavigation { get; set; } = null!;
}
