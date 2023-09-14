using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CursosBiblicos.Models
{
    public partial class cursosbiblicosContext : DbContext
    {
        public cursosbiblicosContext()
        {
        }

        public cursosbiblicosContext(DbContextOptions<cursosbiblicosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ControladorAutenticacion> ControladorAutenticacions { get; set; } = null!;
        public virtual DbSet<ControladorCalificacione> ControladorCalificaciones { get; set; } = null!;
        public virtual DbSet<ControladorCurso> ControladorCursos { get; set; } = null!;
        public virtual DbSet<ControladorEstudiante> ControladorEstudiantes { get; set; } = null!;
        public virtual DbSet<ControladorInscripcione> ControladorInscripciones { get; set; } = null!;
        public virtual DbSet<ControladorInstructore> ControladorInstructores { get; set; } = null!;
        public virtual DbSet<ControladorModulosDeCurso> ControladorModulosDeCursos { get; set; } = null!;
        public virtual DbSet<ControladorRecurso> ControladorRecursos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;port=3306;user=root;database=cursosbiblicos", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.28-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_general_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<ControladorAutenticacion>(entity =>
            {
                entity.ToTable("controlador_autenticacion");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Contrasena)
                    .HasMaxLength(255)
                    .HasColumnName("contrasena");

                entity.Property(e => e.NombreDeUsuario)
                    .HasMaxLength(255)
                    .HasColumnName("nombre_de_usuario");

                entity.Property(e => e.Permisos)
                    .HasMaxLength(255)
                    .HasColumnName("permisos");
            });

            modelBuilder.Entity<ControladorCalificacione>(entity =>
            {
                entity.ToTable("controlador_calificaciones");

                entity.HasIndex(e => e.Curso, "curso");

                entity.HasIndex(e => e.Estudiante, "estudiante");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Calificacion)
                    .HasPrecision(5, 2)
                    .HasColumnName("calificacion");

                entity.Property(e => e.Curso)
                    .HasColumnType("int(11)")
                    .HasColumnName("curso");

                entity.Property(e => e.Estudiante)
                    .HasColumnType("int(11)")
                    .HasColumnName("estudiante");

                entity.Property(e => e.Fecha).HasColumnName("fecha");

                entity.HasOne(d => d.CursoNavigation)
                    .WithMany(p => p.ControladorCalificaciones)
                    .HasForeignKey(d => d.Curso)
                    .HasConstraintName("controlador_calificaciones_ibfk_2");

                entity.HasOne(d => d.EstudianteNavigation)
                    .WithMany(p => p.ControladorCalificaciones)
                    .HasForeignKey(d => d.Estudiante)
                    .HasConstraintName("controlador_calificaciones_ibfk_1");
            });

            modelBuilder.Entity<ControladorCurso>(entity =>
            {
                entity.ToTable("controlador_cursos");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .HasColumnType("text")
                    .HasColumnName("descripcion");

                entity.Property(e => e.FechaDeCreacion).HasColumnName("fecha_de_creacion");

                entity.Property(e => e.NombreDelCurso)
                    .HasMaxLength(255)
                    .HasColumnName("nombre_del_curso");

                entity.Property(e => e.Puntaje)
                    .HasColumnType("int(11)")
                    .HasColumnName("puntaje");
            });

            modelBuilder.Entity<ControladorEstudiante>(entity =>
            {
                entity.ToTable("controlador_estudiantes");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(255)
                    .HasColumnName("apellido");

                entity.Property(e => e.Apellido2)
                    .HasMaxLength(255)
                    .HasColumnName("apellido2");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(255)
                    .HasColumnName("direccion");

                entity.Property(e => e.Mail)
                    .HasMaxLength(255)
                    .HasColumnName("mail");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(255)
                    .HasColumnName("nombre");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(255)
                    .HasColumnName("telefono");
            });

            modelBuilder.Entity<ControladorInscripcione>(entity =>
            {
                entity.ToTable("controlador_inscripciones");

                entity.HasIndex(e => e.Curso, "curso");

                entity.HasIndex(e => e.Estudiante, "estudiante");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Curso)
                    .HasColumnType("int(11)")
                    .HasColumnName("curso");

                entity.Property(e => e.Estudiante)
                    .HasColumnType("int(11)")
                    .HasColumnName("estudiante");

                entity.Property(e => e.FechaDeInscripcion).HasColumnName("fecha_de_inscripcion");

                entity.HasOne(d => d.CursoNavigation)
                    .WithMany(p => p.ControladorInscripciones)
                    .HasForeignKey(d => d.Curso)
                    .HasConstraintName("controlador_inscripciones_ibfk_2");

                entity.HasOne(d => d.EstudianteNavigation)
                    .WithMany(p => p.ControladorInscripciones)
                    .HasForeignKey(d => d.Estudiante)
                    .HasConstraintName("controlador_inscripciones_ibfk_1");
            });

            modelBuilder.Entity<ControladorInstructore>(entity =>
            {
                entity.ToTable("controlador_instructores");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Apellido1)
                    .HasMaxLength(255)
                    .HasColumnName("apellido1");

                entity.Property(e => e.Apellido2)
                    .HasMaxLength(255)
                    .HasColumnName("apellido2");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(255)
                    .HasColumnName("direccion");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(255)
                    .HasColumnName("nombre");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(255)
                    .HasColumnName("telefono");
            });

            modelBuilder.Entity<ControladorModulosDeCurso>(entity =>
            {
                entity.ToTable("controlador_modulos_de_cursos");

                entity.HasIndex(e => e.Curso, "curso");

                entity.HasIndex(e => e.Estudiante, "estudiante");

                entity.HasIndex(e => e.Instructor, "instructor");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Curso)
                    .HasColumnType("int(11)")
                    .HasColumnName("curso");

                entity.Property(e => e.Estudiante)
                    .HasColumnType("int(11)")
                    .HasColumnName("estudiante");

                entity.Property(e => e.Instructor)
                    .HasColumnType("int(11)")
                    .HasColumnName("instructor");

                entity.HasOne(d => d.CursoNavigation)
                    .WithMany(p => p.ControladorModulosDeCursos)
                    .HasForeignKey(d => d.Curso)
                    .HasConstraintName("controlador_modulos_de_cursos_ibfk_1");

                entity.HasOne(d => d.EstudianteNavigation)
                    .WithMany(p => p.ControladorModulosDeCursos)
                    .HasForeignKey(d => d.Estudiante)
                    .HasConstraintName("controlador_modulos_de_cursos_ibfk_3");

                entity.HasOne(d => d.InstructorNavigation)
                    .WithMany(p => p.ControladorModulosDeCursos)
                    .HasForeignKey(d => d.Instructor)
                    .HasConstraintName("controlador_modulos_de_cursos_ibfk_2");
            });

            modelBuilder.Entity<ControladorRecurso>(entity =>
            {
                entity.ToTable("controlador_recursos");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .HasColumnType("text")
                    .HasColumnName("descripcion");

                entity.Property(e => e.Enlace)
                    .HasMaxLength(255)
                    .HasColumnName("enlace");

                entity.Property(e => e.NombreDelRecurso)
                    .HasMaxLength(255)
                    .HasColumnName("nombre_del_recurso");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(255)
                    .HasColumnName("tipo");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
