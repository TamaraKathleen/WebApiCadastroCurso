using System;
using Microsoft.EntityFrameworkCore;
using WebApiCadastroCurso.Models;
using WebApiCadastroCurso.Repository;

namespace WebApiCadastroCurso.Data
{
    public class ApplicationContext : DbContext
    {

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(u =>
            {
                u.ToTable("Usuario");
                u.HasKey(u => u.Id);
                u.Property(u => u.Name).HasColumnType("VARCHAR(100)").IsRequired();
                u.Property(u => u.Email).HasColumnType("VARCHAR(100)").IsRequired();
                u.Property(u => u.Password).HasMaxLength(20).IsRequired();
                u.Property(u => u.Role).HasConversion<string>().IsRequired();
            });

            modelBuilder.Entity<Course>(u =>
            {
                u.ToTable("Cursos");
                u.HasKey(u => u.Id);
                u.Property(u => u.Titulo).HasColumnType("VARCHAR(20)").IsRequired();
                u.Property(u => u.Duracao).HasColumnType("INT").IsRequired();
                u.Property(u => u.Status).HasConversion<string>().IsRequired();

            });
        }

        public static implicit operator ApplicationContext(CadastraUserCourseRepository v)
        {
            throw new NotImplementedException();
        }
    }
}