using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DevQuimlabs.Models
{
    public partial class QuimlabsContext : DbContext
    {
        public QuimlabsContext()
        {
        }

        public QuimlabsContext(DbContextOptions<QuimlabsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Actividad> Actividads { get; set; } = null!;
        public virtual DbSet<Contenido> Contenidos { get; set; } = null!;
        public virtual DbSet<Estudiante> Estudiantes { get; set; } = null!;
        public virtual DbSet<Profesor> Profesors { get; set; } = null!;
        public virtual DbSet<Rol> Rols { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actividad>(entity =>
            {
                entity.HasKey(e => e.IdActividad);

                entity.ToTable("Actividad");

                entity.Property(e => e.IdActividad)
                    .ValueGeneratedNever()
                    .HasColumnName("idActividad");

                entity.Property(e => e.Calificacion).HasColumnName("calificacion");

                entity.Property(e => e.FechaFin)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaFin");

                entity.Property(e => e.FechaInicio)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaInicio");

                entity.Property(e => e.IdContenido).HasColumnName("idContenido");

                entity.Property(e => e.IdEstudiante).HasColumnName("idEstudiante");

                entity.HasOne(d => d.IdContenidoNavigation)
                    .WithMany(p => p.Actividads)
                    .HasForeignKey(d => d.IdContenido)
                    .HasConstraintName("FK_Actividad_Contenido");

                entity.HasOne(d => d.IdEstudianteNavigation)
                    .WithMany(p => p.Actividads)
                    .HasForeignKey(d => d.IdEstudiante)
                    .HasConstraintName("FK_Actividad_Estudiante");
            });

            modelBuilder.Entity<Contenido>(entity =>
            {
                entity.HasKey(e => e.IdContenido);

                entity.ToTable("Contenido");

                entity.Property(e => e.IdContenido)
                    .ValueGeneratedNever()
                    .HasColumnName("idContenido");

                entity.Property(e => e.Categoria)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("categoria");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha");

                entity.Property(e => e.FechaFin)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaFin");

                entity.Property(e => e.FechaInicio)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaInicio");

                entity.Property(e => e.IdProfesor).HasColumnName("idProfesor");
            });

            modelBuilder.Entity<Estudiante>(entity =>
            {
                entity.HasKey(e => e.IdEstudiante);

                entity.ToTable("Estudiante");

                entity.Property(e => e.IdEstudiante)
                    .ValueGeneratedNever()
                    .HasColumnName("idEstudiante");

                entity.Property(e => e.Grado)
                    .HasMaxLength(10)
                    .HasColumnName("grado")
                    .IsFixedLength();

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            });

            modelBuilder.Entity<Profesor>(entity =>
            {
                entity.HasKey(e => e.IdProfesor);

                entity.ToTable("Profesor");

                entity.Property(e => e.IdProfesor)
                    .ValueGeneratedNever()
                    .HasColumnName("idProfesor");

                entity.Property(e => e.Especialidad)
                    .HasMaxLength(10)
                    .HasColumnName("especialidad")
                    .IsFixedLength();

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Profesors)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK_Profesor_Usuario");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.HasKey(e => e.Idrol)
                    .HasName("PK_rol");

                entity.ToTable("Rol");

                entity.Property(e => e.Idrol)
                    .ValueGeneratedNever()
                    .HasColumnName("idrol");

                entity.Property(e => e.Rol1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("rol");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.ToTable("Usuario");

                entity.Property(e => e.IdUsuario)
                    .ValueGeneratedNever()
                    .HasColumnName("idUsuario");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(10)
                    .HasColumnName("apellido")
                    .IsFixedLength();

                entity.Property(e => e.Clave)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("clave");

                entity.Property(e => e.Correo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("correo");

                entity.Property(e => e.IdRol).HasColumnName("idRol");

                entity.Property(e => e.Identificacion).HasColumnName("identificacion");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(10)
                    .HasColumnName("nombre")
                    .IsFixedLength();

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdRol)
                    .HasConstraintName("FK_Usuario_Rol");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
