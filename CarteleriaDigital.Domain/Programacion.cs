using System;
using System.Collections.Generic;

namespace CarteleriaDigital.Domain;

public partial class Programacion
{
    public Guid IdProgramacion { get; set; }

    public Guid IdLista { get; set; }

    public Guid IdTerminal { get; set; }

    public Guid IdUsuario { get; set; }

    public DateOnly FechaInicio { get; set; }

    public DateOnly? FechaFin { get; set; }

    public TimeOnly HorarioInicio { get; set; }

    public TimeOnly HorarioFin { get; set; }

    public string DiasSemana { get; set; } = null!;

    public int? Prioridad { get; set; }

    public bool? Activo { get; set; }

    public virtual ListaReproduccion IdListaNavigation { get; set; } = null!;

    public virtual Terminal IdTerminalNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;

    public virtual ICollection<RegistroReproduccion> RegistroReproduccions { get; set; } = new List<RegistroReproduccion>();
}
