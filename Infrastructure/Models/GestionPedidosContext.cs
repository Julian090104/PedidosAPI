using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Infrastructure.Models
{
    public partial class GestionPedidosContext : DbContext
    {
        public GestionPedidosContext()
        {
        }

        public GestionPedidosContext(DbContextOptions<GestionPedidosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Articulo> Articulos { get; set; } = null!;
        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<DetallePedido> DetallePedidos { get; set; } = null!;
        public virtual DbSet<Pedido> Pedidos { get; set; } = null!;

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=JULIAN;Database=Gestion-Pedidos;Trusted_Connection=True;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Articulo>(entity =>
            {
                entity.HasKey(e => e.Idarticulo)
                    .HasName("PK__Articulo__48472EAFEA2BEE59");

                entity.ToTable("Articulo");

                entity.Property(e => e.Idarticulo)
                    .ValueGeneratedNever()
                    .HasColumnName("IDArticulo");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.Idcliente)
                    .HasName("PK__Cliente__9B8553FC7A8E6354");

                entity.ToTable("Cliente");

                entity.Property(e => e.Idcliente)
                    .ValueGeneratedNever()
                    .HasColumnName("IDCliente");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DetallePedido>(entity =>
            {
                entity.HasKey(e => e.IddetallePedido)
                    .HasName("PK__DetalleP__8F0552440682F13C");

                entity.ToTable("DetallePedido");

                entity.Property(e => e.IddetallePedido)
                    .ValueGeneratedNever()
                    .HasColumnName("IDDetallePedido");

                entity.Property(e => e.Idarticulo).HasColumnName("IDArticulo");

                entity.Property(e => e.Idpedido).HasColumnName("IDPedido");

                entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.IdarticuloNavigation)
                    .WithMany(p => p.DetallePedidos)
                    .HasForeignKey(d => d.Idarticulo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DetallePe__IDArt__3F466844");

                entity.HasOne(d => d.IdpedidoNavigation)
                    .WithMany(p => p.DetallePedidos)
                    .HasForeignKey(d => d.Idpedido)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DetallePe__IDPed__3E52440B");
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.HasKey(e => e.Idpedido)
                    .HasName("PK__Pedido__00C11F99C98848FD");

                entity.ToTable("Pedido");

                entity.Property(e => e.Idpedido)
                    .ValueGeneratedNever()
                    .HasColumnName("IDPedido");

                entity.Property(e => e.Estado)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.Idcliente).HasColumnName("IDCliente");

                entity.HasOne(d => d.IdclienteNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.Idcliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Pedido__IDClient__398D8EEE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
