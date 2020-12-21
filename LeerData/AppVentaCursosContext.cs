using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace LeerData
{
    public class appventaCursosContext : DbContext
    {
        private const string connectionString = @"Data Source = PC-PAUL\SQLEXPRESS01;Initial Catalog = Cursos_DB; Integrated Security = True";
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer(connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Curso_Instructor>().HasKey(ci => new {ci.CursoId, ci.InstructorId});
        }
        public DbSet<Curso> Curso {get; set;}
        public DbSet<Precio> Precio {get; set;}
        public DbSet<Comentario> Comentario {get; set;}
        public DbSet<Instructor> Instructor {get; set;}
        public DbSet<Curso_Instructor> Curso_Instructor {get; set;}
    }
}