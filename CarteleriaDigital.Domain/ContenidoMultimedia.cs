using System;
using System.Collections.Generic;

namespace CarteleriaDigital.Domain;

public partial class ContenidoMultimedia
{
    public Guid IdContenido { get; set; }

    public Guid IdUsuario { get; set; }

    public string NombreArchivo { get; set; } = null!;

    public string UrlDescarga { get; set; } = null!;

    public string MimeType { get; set; } = null!;

    public int DuracionSeg { get; set; }

    public long PesoBytes { get; set; }

    public string ChecksumMd5 { get; set; } = null!;

    public DateTime? FechaSubida { get; set; }

    public bool? Activo { get; set; }

    public string? UrlMiniatura { get; set; }

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;

    public virtual ICollection<ListaItem> ListaItems { get; set; } = new List<ListaItem>();

    public virtual ICollection<RegistroReproduccion> RegistroReproduccions { get; set; } = new List<RegistroReproduccion>();
}
