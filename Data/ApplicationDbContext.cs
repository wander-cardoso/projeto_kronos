using ProjKronos.Models;
using Microsoft.EntityFrameworkCore;


namespace ProjKronos.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }

        // ---------------------------------------------------- propiedades da classe aqui:
        public DbSet<Cliente>? Clientes { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<LinhaProcesso> LinhaProcessos { get; set; }
        public DbSet<Prioridade> Prioridades { get; set; }
        public DbSet<Processo> Processos { get; set; }
        public DbSet<ProjKronos.Models.Utilizador> Utilizador { get; set; } = default!;



    }
}