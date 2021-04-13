using Microsoft.EntityFrameworkCore;
using CRPass.DO.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRPass.DAL.EF
{
    public partial class SolutionDbContext : DbContext
    {
        public SolutionDbContext(DbContextOptions<SolutionDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Boleteria> Boleteria { get; set; }
        public virtual DbSet<BoleteriaReservados> BoleteriaReservados { get; set; }
        //public virtual DbSet<ControlAforo> ControlAforo { get; set; }
        public virtual DbSet<Empresa> Empresa { get; set; }
        public virtual DbSet<Publicidad> Publicidad { get; set; }
        public virtual DbSet<Tickets> Tickets { get; set; }
        //public virtual DbSet<Usuarios> Usuarios { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Boleteria>(entity =>
            {
                entity.HasKey(e => e.CodBoleteria);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.CodEmpresaNavigation)
                    .WithMany(p => p.Boleteria)
                    .HasForeignKey(d => d.CodEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Boleteria_Empresa");
            });

            modelBuilder.Entity<BoleteriaReservados>(entity =>
            {
                entity.HasKey(e => new { e.CodBoletaReservado, e.CodBoleteria, e.CodTickets });

                entity.Property(e => e.CodBoletaReservado).ValueGeneratedOnAdd();

                entity.HasOne(d => d.CodBoleteriaNavigation)
                    .WithMany(p => p.BoleteriaReservados)
                    .HasForeignKey(d => d.CodBoleteria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BoleteriaReservados_Boleteria");

                entity.HasOne(d => d.CodTicketsNavigation)
                    .WithMany(p => p.BoleteriaReservados)
                    .HasForeignKey(d => d.CodTickets)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BoleteriaReservados_Tickets");
            });

            //modelBuilder.Entity<ControlAforo>(entity =>
            //{
            //    entity.HasKey(e => new { e.CodControl, e.CodEmpresa, e.NumeroDia });

            //    entity.Property(e => e.CodControl).ValueGeneratedOnAdd();

            //    entity.HasOne(d => d.CodEmpresaNavigation)
            //        .WithMany(p => p.ControlAforo)
            //        .HasForeignKey(d => d.CodEmpresa)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_ControlAforo_Empresa");
            //});

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.HasKey(e => e.CodEmpresa);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Ubicacion).IsRequired();
            });

            modelBuilder.Entity<Publicidad>(entity =>
            {
                entity.HasKey(e => e.CodPublicidad);
                entity.Property(e => e.CodPublicidad).ValueGeneratedNever();
                entity.Property(e => e.RutaArchivo).IsRequired();
                entity.HasOne(d => d.CodEmpresaNavigation)
                    .WithMany(p => p.Publicidad)
                    .HasForeignKey(d => d.CodEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Publicidad_Empresa");
            });

            modelBuilder.Entity<Tickets>(entity =>
            {
                entity.HasKey(e => e.CodTicket);

                entity.Property(e => e.CodTicket).ValueGeneratedNever();

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.Nreserva)
                    .IsRequired()
                    .HasColumnName("NReserva")
                    .HasMaxLength(6);

                entity.Property(e => e.Usuario)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.HasOne(d => d.CodEmpresaNavigation)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.CodEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tickets_Empresa");

                entity.HasOne(d => d.UsuarioNavigation)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.Usuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tickets_Usuarios");
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.Usuario);

                entity.Property(e => e.Usuario).HasMaxLength(10);

                entity.Property(e => e.Contrasena)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Correo).HasMaxLength(150);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.CodEmpresaNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.CodEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuarios_Empresa");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
