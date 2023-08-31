using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Galeria.Models
{
    public partial class GaleriaContext : DbContext
    {
        public GaleriaContext()
        {
        }

        public GaleriaContext(DbContextOptions<GaleriaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Artistum> Artista { get; set; } = null!;
        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Compra> Compras { get; set; } = null!;
        public virtual DbSet<Cuadro> Cuadros { get; set; } = null!;
        public virtual DbSet<Persona> Personas { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-2LKTOJH\\SQLEXPRESS01; Database=Galeria; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artistum>(entity =>
            {
                entity.HasKey(e => e.IdArtista);

                entity.Property(e => e.IdArtista).HasColumnName("id_Artista");

                entity.Property(e => e.Estilo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Experiencia)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Firma)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("firma");

                entity.Property(e => e.IdPersona).HasColumnName("id_Persona");

                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithMany(p => p.Artista)
                    .HasForeignKey(d => d.IdPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Artista_Persona");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente);

                entity.ToTable("Cliente");

                entity.Property(e => e.IdCliente).HasColumnName("id_Cliente");

                entity.Property(e => e.CodigoPostal)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Codigo_Postal");

                entity.Property(e => e.Dierección)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdPersona).HasColumnName("id_Persona");

                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.IdPersona)
                    .HasConstraintName("FK_Cliente_Persona");
            });

            modelBuilder.Entity<Compra>(entity =>
            {
                entity.HasKey(e => e.IdCompras);

                entity.Property(e => e.IdCompras).HasColumnName("id_Compras");

                entity.Property(e => e.DetalleCompra)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Detalle_Compra");

                entity.Property(e => e.IdCliente).HasColumnName("id_Cliente");

                entity.Property(e => e.IdCuadro).HasColumnName("id_Cuadro");

                entity.Property(e => e.IdProducto).HasColumnName("id_Producto");

                entity.Property(e => e.PrecioTotal)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Precio_Total");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Compras)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Compras_Cliente");

                entity.HasOne(d => d.IdCliente1)
                    .WithMany(p => p.Compras)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Compras_Cuadro");

                entity.HasOne(d => d.IdCuadroNavigation)
                    .WithMany(p => p.Compras)
                    .HasForeignKey(d => d.IdCuadro)
                    .HasConstraintName("FK_Compras_Producto");
            });

            modelBuilder.Entity<Cuadro>(entity =>
            {
                entity.HasKey(e => e.IdCuadro);

                entity.ToTable("Cuadro");

                entity.Property(e => e.IdCuadro).HasColumnName("id_Cuadro");

                entity.Property(e => e.IdArtista).HasColumnName("id_Artista");

                entity.Property(e => e.Materiales)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Medidas)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdArtistaNavigation)
                    .WithMany(p => p.Cuadros)
                    .HasForeignKey(d => d.IdArtista)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cuadro_Artista");
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => e.IdPersona);

                entity.ToTable("Persona");

                entity.Property(e => e.IdPersona).HasColumnName("id_Persona");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Cedula)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CiudadRecidencia)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Ciudad_Recidencia");

                entity.Property(e => e.Correo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Edad)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.IdProducto);

                entity.ToTable("Producto");

                entity.Property(e => e.IdProducto).HasColumnName("id_Producto");

                entity.Property(e => e.Existencias)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdCuadro).HasColumnName("id_Cuadro");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Precio)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCuadroNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdCuadro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Producto_Cuadro");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
