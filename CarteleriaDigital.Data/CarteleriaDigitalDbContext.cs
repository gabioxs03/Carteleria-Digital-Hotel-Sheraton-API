using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using CarteleriaDigital.Domain;

namespace CarteleriaDigital.Data;

public partial class CarteleriaDigitalDbContext : DbContext
{
    public CarteleriaDigitalDbContext()
    {
    }

    public CarteleriaDigitalDbContext(DbContextOptions<CarteleriaDigitalDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ContenidoMultimedia> ContenidoMultimedia { get; set; }

    public virtual DbSet<ListaItem> ListaItems { get; set; }

    public virtual DbSet<ListaReproduccion> ListaReproduccions { get; set; }

    public virtual DbSet<Programacion> Programacions { get; set; }

    public virtual DbSet<RegistroReproduccion> RegistroReproduccions { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Terminal> Terminals { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<UsuarioRol> UsuarioRols { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ContenidoMultimedia>(entity =>
        {
            entity.HasKey(e => e.IdContenido).HasName("PK__Contenid__7FB5C29E4657D867");

            entity.HasIndex(e => e.ChecksumMd5, "IX_Contenido_MD5");

            entity.Property(e => e.IdContenido)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("idContenido");
            entity.Property(e => e.Activo)
                .HasDefaultValue(true)
                .HasColumnName("activo");
            entity.Property(e => e.ChecksumMd5)
                .HasMaxLength(32)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("checksumMD5");
            entity.Property(e => e.DuracionSeg).HasColumnName("duracionSeg");
            entity.Property(e => e.FechaSubida)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("fechaSubida");
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.MimeType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("mimeType");
            entity.Property(e => e.NombreArchivo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombreArchivo");
            entity.Property(e => e.PesoBytes).HasColumnName("pesoBytes");
            entity.Property(e => e.UrlDescarga)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("urlDescarga");
            entity.Property(e => e.UrlMiniatura)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("urlMiniatura");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.ContenidoMultimedia)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Contenido_Usuario");
        });

        modelBuilder.Entity<ListaItem>(entity =>
        {
            entity.HasKey(e => e.IdListaItem).HasName("PK__ListaIte__6688B8E4BFF0EFBF");

            entity.ToTable("ListaItem");

            entity.Property(e => e.IdListaItem)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("idListaItem");
            entity.Property(e => e.DuracionPersonalizada).HasColumnName("duracionPersonalizada");
            entity.Property(e => e.IdContenido).HasColumnName("idContenido");
            entity.Property(e => e.IdLista).HasColumnName("idLista");
            entity.Property(e => e.Orden).HasColumnName("orden");

            entity.HasOne(d => d.IdContenidoNavigation).WithMany(p => p.ListaItems)
                .HasForeignKey(d => d.IdContenido)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Item_Contenido");

            entity.HasOne(d => d.IdListaNavigation).WithMany(p => p.ListaItems)
                .HasForeignKey(d => d.IdLista)
                .HasConstraintName("FK_Item_Lista");
        });

        modelBuilder.Entity<ListaReproduccion>(entity =>
        {
            entity.HasKey(e => e.IdLista).HasName("PK__ListaRep__6C8A0FE59A16A7E9");

            entity.ToTable("ListaReproduccion");

            entity.Property(e => e.IdLista)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("idLista");
            entity.Property(e => e.Activo)
                .HasDefaultValue(true)
                .HasColumnName("activo");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.DuracionSegLista).HasColumnName("duracionSegLista");
            entity.Property(e => e.EsDefault)
                .HasDefaultValue(false)
                .HasColumnName("esDefault");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("fechaCreacion");
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.NombreLista)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombreLista");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.ListaReproduccions)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Lista_Usuario");
        });

        modelBuilder.Entity<Programacion>(entity =>
        {
            entity.HasKey(e => e.IdProgramacion).HasName("PK__Programa__EA62461DD3FB507F");

            entity.ToTable("Programacion");

            entity.Property(e => e.IdProgramacion)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("idProgramacion");
            entity.Property(e => e.Activo)
                .HasDefaultValue(true)
                .HasColumnName("activo");
            entity.Property(e => e.DiasSemana)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("diasSemana");
            entity.Property(e => e.FechaFin).HasColumnName("fechaFin");
            entity.Property(e => e.FechaInicio).HasColumnName("fechaInicio");
            entity.Property(e => e.HorarioFin)
                .HasPrecision(0)
                .HasColumnName("horarioFin");
            entity.Property(e => e.HorarioInicio)
                .HasPrecision(0)
                .HasColumnName("horarioInicio");
            entity.Property(e => e.IdLista).HasColumnName("idLista");
            entity.Property(e => e.IdTerminal).HasColumnName("idTerminal");
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.Prioridad)
                .HasDefaultValue(1)
                .HasColumnName("prioridad");

            entity.HasOne(d => d.IdListaNavigation).WithMany(p => p.Programacions)
                .HasForeignKey(d => d.IdLista)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Prog_Lista");

            entity.HasOne(d => d.IdTerminalNavigation).WithMany(p => p.Programacions)
                .HasForeignKey(d => d.IdTerminal)
                .HasConstraintName("FK_Prog_Terminal");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Programacions)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Prog_Usuario");
        });

        modelBuilder.Entity<RegistroReproduccion>(entity =>
        {
            entity.HasKey(e => e.IdRegistro).HasName("PK__Registro__62FC8F580F8F83CC");

            entity.ToTable("RegistroReproduccion");

            entity.Property(e => e.IdRegistro).HasColumnName("idRegistro");
            entity.Property(e => e.Detalle)
                .IsUnicode(false)
                .HasColumnName("detalle");
            entity.Property(e => e.DuracionReal).HasColumnName("duracionReal");
            entity.Property(e => e.FechaEvento)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("fechaEvento");
            entity.Property(e => e.IdContenido).HasColumnName("idContenido");
            entity.Property(e => e.IdLista).HasColumnName("idLista");
            entity.Property(e => e.IdProgramacion).HasColumnName("idProgramacion");
            entity.Property(e => e.IdTerminal).HasColumnName("idTerminal");
            entity.Property(e => e.TipoEvento)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tipoEvento");

            entity.HasOne(d => d.IdContenidoNavigation).WithMany(p => p.RegistroReproduccions)
                .HasForeignKey(d => d.IdContenido)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Log_Contenido");

            entity.HasOne(d => d.IdListaNavigation).WithMany(p => p.RegistroReproduccions)
                .HasForeignKey(d => d.IdLista)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Log_Lista");

            entity.HasOne(d => d.IdProgramacionNavigation).WithMany(p => p.RegistroReproduccions)
                .HasForeignKey(d => d.IdProgramacion)
                .HasConstraintName("FK_Log_Programacion");

            entity.HasOne(d => d.IdTerminalNavigation).WithMany(p => p.RegistroReproduccions)
                .HasForeignKey(d => d.IdTerminal)
                .HasConstraintName("FK_Log_Terminal");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__Rol__3C872F763ADD1A74");

            entity.ToTable("Rol");

            entity.HasIndex(e => e.NombreRol, "UQ__Rol__2787B00C3B9B6E13").IsUnique();

            entity.Property(e => e.IdRol)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("idRol");
            entity.Property(e => e.NombreRol)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombreRol");
        });

        modelBuilder.Entity<Terminal>(entity =>
        {
            entity.HasKey(e => e.IdTerminal).HasName("PK__Terminal__306191EA768E4E12");

            entity.ToTable("Terminal");

            entity.HasIndex(e => e.Mac, "IX_Terminal_MAC");

            entity.HasIndex(e => e.Mac, "UQ__Terminal__DF5071E6EA39A621").IsUnique();

            entity.Property(e => e.IdTerminal)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("idTerminal");
            entity.Property(e => e.Activo)
                .HasDefaultValue(true)
                .HasColumnName("activo");
            entity.Property(e => e.CodigoAeropuerto)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("codigoAeropuerto");
            entity.Property(e => e.Estado)
                .HasDefaultValue(0)
                .HasColumnName("estado");
            entity.Property(e => e.Latitud)
                .HasColumnType("decimal(9, 6)")
                .HasColumnName("latitud");
            entity.Property(e => e.Longitud)
                .HasColumnType("decimal(9, 6)")
                .HasColumnName("longitud");
            entity.Property(e => e.Mac)
                .HasMaxLength(17)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("mac");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.UltimaConexion).HasColumnName("ultimaConexion");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__645723A669BB452C");

            entity.ToTable("Usuario");

            entity.HasIndex(e => e.Usuario1, "IX_Usuario_User");

            entity.HasIndex(e => e.Mail, "UQ__Usuario__7A212904132C30C4").IsUnique();

            entity.HasIndex(e => e.Usuario1, "UQ__Usuario__9AFF8FC624FCF1AE").IsUnique();

            entity.Property(e => e.IdUsuario)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("idUsuario");
            entity.Property(e => e.Activo)
                .HasDefaultValue(true)
                .HasColumnName("activo");
            entity.Property(e => e.Apellido)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.Contraseña)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("contraseña");
            entity.Property(e => e.Mail)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("mail");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Usuario1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("usuario");
        });

        modelBuilder.Entity<UsuarioRol>(entity =>
        {
            entity.HasKey(e => e.IdUsuarioRol).HasName("PK__UsuarioR__50B09207C78498FF");

            entity.ToTable("UsuarioRol");

            entity.Property(e => e.IdUsuarioRol)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("idUsuarioRol");
            entity.Property(e => e.FechaAsignacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("fechaAsignacion");
            entity.Property(e => e.IdRol).HasColumnName("idRol");
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.UsuarioRols)
                .HasForeignKey(d => d.IdRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UsuarioRol_Rol");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.UsuarioRols)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UsuarioRol_Usuario");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
