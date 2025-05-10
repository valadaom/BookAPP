using BookAPP.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookAPP.Repository.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Livro> Livro => Set<Livro>();
        public DbSet<Autor> Autor => Set<Autor>();
        public DbSet<Assunto> Assunto => Set<Assunto>();
        public DbSet<Livro_Autor> Livro_Autor => Set<Livro_Autor>();
        public DbSet<Livro_Assunto> Livro_Assunto => Set<Livro_Assunto>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Livro_Autor>()
                .HasKey(la => new { la.Livro_CodL, la.Autor_CodAu });

            modelBuilder.Entity<Livro_Autor>()
                .HasOne(la => la.Livro)
                .WithMany(l => l.Livro_Autores)
                .HasForeignKey(la => la.Livro_CodL);

            modelBuilder.Entity<Livro_Autor>()
                .HasOne(la => la.Autor)
                .WithMany(a => a.Livro_Autores)
                .HasForeignKey(la => la.Autor_CodAu);

            modelBuilder.Entity<Livro_Assunto>()
                .HasKey(la => new { la.Livro_CodL, la.Assunto_CodAs });

            modelBuilder.Entity<Livro_Assunto>()
                .HasOne(la => la.Livro)
                .WithMany(l => l.Livro_Assuntos)
                .HasForeignKey(la => la.Livro_CodL);

            modelBuilder.Entity<Livro_Assunto>()
                .HasOne(la => la.Assunto)
                .WithMany(a => a.Livro_Assuntos)
                .HasForeignKey(la => la.Assunto_CodAs);
        }
    }
}
