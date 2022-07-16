using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace KadabraMVC.Models
{
    public partial class KadabraHCContext : DbContext
    {
        public KadabraHCContext()
        {
        }

        public KadabraHCContext(DbContextOptions<KadabraHCContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AnotacionAclase> AnotacionAclases { get; set; } = null!;
        public virtual DbSet<Asistencia> Asistencias { get; set; } = null!;
        public virtual DbSet<Clase> Clases { get; set; } = null!;
        public virtual DbSet<Pago> Pagos { get; set; } = null!;
        public virtual DbSet<Plane> Planes { get; set; } = null!;
        public virtual DbSet<RegistroDeClase> RegistroDeClases { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=Nacho\\SQLEXPRESS; Database=KadabraHC; Trusted_Connection=True;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnotacionAclase>(entity =>
            {
                entity.HasKey(e => e.IdAnotacionAclase)
                    .HasName("PK__Anotacio__FAAA497C6E8C7BBB");

                entity.ToTable("AnotacionAClase");

                entity.Property(e => e.IdAnotacionAclase).HasColumnName("idAnotacionAClase");

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.FyHRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("FyH_Registro")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdAlumno).HasColumnName("idAlumno");

                entity.Property(e => e.IdClase).HasColumnName("idClase");

                entity.HasOne(d => d.IdAlumnoNavigation)
                    .WithMany(p => p.AnotacionAclases)
                    .HasForeignKey(d => d.IdAlumno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AnotacionClase_Alumno");

                entity.HasOne(d => d.IdClaseNavigation)
                    .WithMany(p => p.AnotacionAclases)
                    .HasForeignKey(d => d.IdClase)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AnotacionClase_Clase");
            });

            modelBuilder.Entity<Asistencia>(entity =>
            {
                entity.HasKey(e => e.IdAsistencia)
                    .HasName("PK__Asistenc__4E1AB89451CB571C");

                entity.Property(e => e.IdAsistencia).HasColumnName("idAsistencia");

                entity.Property(e => e.FyHRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("FyH_Registro")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdAlumno).HasColumnName("idAlumno");

                entity.Property(e => e.IdClase).HasColumnName("idClase");

                entity.Property(e => e.IdProfesor).HasColumnName("idProfesor");

                entity.HasOne(d => d.IdAlumnoNavigation)
                    .WithMany(p => p.AsistenciaIdAlumnoNavigations)
                    .HasForeignKey(d => d.IdAlumno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Asistencia_Alumno");

                entity.HasOne(d => d.IdClaseNavigation)
                    .WithMany(p => p.Asistencia)
                    .HasForeignKey(d => d.IdClase)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Asistencia_Clase");

                entity.HasOne(d => d.IdProfesorNavigation)
                    .WithMany(p => p.AsistenciaIdProfesorNavigations)
                    .HasForeignKey(d => d.IdProfesor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Asistencia_Profesor");
            });

            modelBuilder.Entity<Clase>(entity =>
            {
                entity.HasKey(e => e.IdClase)
                    .HasName("PK__Clases__17317A685BA4A3B8");

                entity.Property(e => e.IdClase).HasColumnName("idClase");

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.HorarioClase).HasColumnType("datetime");

                entity.Property(e => e.IdProfesor).HasColumnName("idProfesor");

                entity.HasOne(d => d.IdProfesorNavigation)
                    .WithMany(p => p.Clases)
                    .HasForeignKey(d => d.IdProfesor)
                    .HasConstraintName("FK_Clase_Profesor");
            });

            modelBuilder.Entity<Pago>(entity =>
            {
                entity.HasKey(e => e.IdPago)
                    .HasName("PK__Pagos__BD2295AD1CA3C54F");

                entity.Property(e => e.IdPago).HasColumnName("idPago");

                entity.Property(e => e.CantidadMesesPagados).HasColumnName("Cantidad_meses_pagados");

                entity.Property(e => e.FyHRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("FyH_Registro")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdAdministrativo).HasColumnName("idAdministrativo");

                entity.Property(e => e.IdAlumno).HasColumnName("idAlumno");

                entity.Property(e => e.MesPagado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Mes_Pagado");

                entity.HasOne(d => d.IdAdministrativoNavigation)
                    .WithMany(p => p.PagoIdAdministrativoNavigations)
                    .HasForeignKey(d => d.IdAdministrativo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pagos_Administrativos");

                entity.HasOne(d => d.IdAlumnoNavigation)
                    .WithMany(p => p.PagoIdAlumnoNavigations)
                    .HasForeignKey(d => d.IdAlumno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pagos_Alumnos");
            });

            modelBuilder.Entity<Plane>(entity =>
            {
                entity.HasKey(e => e.IdPlan)
                    .HasName("PK__Planes__BECFB996778882F4");

                entity.Property(e => e.IdPlan).HasColumnName("idPlan");

                entity.Property(e => e.NombrePlan)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.PrecioMensual)
                    .HasColumnType("money")
                    .HasColumnName("Precio_mensual");
            });

            modelBuilder.Entity<RegistroDeClase>(entity =>
            {
                entity.HasKey(e => e.IdRegistroDeClase)
                    .HasName("PK__Registro__F492E6B1E9E10503");

                entity.ToTable("RegistroDeClase");

                entity.Property(e => e.IdRegistroDeClase).HasColumnName("idRegistroDeClase");

                entity.Property(e => e.FyHRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("FyH_Registro")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdAdministrativo).HasColumnName("idAdministrativo");

                entity.Property(e => e.IdClase).HasColumnName("idClase");

                entity.HasOne(d => d.IdAdministrativoNavigation)
                    .WithMany(p => p.RegistroDeClases)
                    .HasForeignKey(d => d.IdAdministrativo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RegistroClase_Administrativos");

                entity.HasOne(d => d.IdClaseNavigation)
                    .WithMany(p => p.RegistroDeClases)
                    .HasForeignKey(d => d.IdClase)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RegistroClase_Clases");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuarios__645723A6C1DE412A");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("apellido");

                entity.Property(e => e.ClasesRestantes).HasDefaultValueSql("((0))");

                entity.Property(e => e.Contraseña)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Dni)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("DNI")
                    .IsFixedLength();

                entity.Property(e => e.Estado)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Activo')");

                entity.Property(e => e.FechaDeAlta)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Mail)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Tipo)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
