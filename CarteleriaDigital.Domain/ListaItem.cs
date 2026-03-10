using System;
using System.Collections.Generic;

namespace CarteleriaDigital.Domain;

public partial class ListaItem
{
    public Guid IdListaItem { get; set; }

    public Guid IdLista { get; set; }

    public Guid IdContenido { get; set; }

    public int Orden { get; set; }

    public int? DuracionPersonalizada { get; set; }

    public virtual ContenidoMultimedia IdContenidoNavigation { get; set; } = null!;

    public virtual ListaReproduccion IdListaNavigation { get; set; } = null!;
}
