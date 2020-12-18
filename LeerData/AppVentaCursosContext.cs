using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace LeerData
{
    public class appventaCursosContext : DbContext
    {
        private const string connectionString = @"Data Source = PC-PAUL\SQLEXPRESS01;Initial Catalog = Cursos_DB; Integrated Security = True";
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder){
            optionBuilder.UseSqlServer(connectionString);
        }
        public DbSet<Curso> Curso {get; set;}
        public DbSet<Precio> Precio {get; set;}
    }
}