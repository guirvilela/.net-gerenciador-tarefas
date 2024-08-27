using GerenciadorDeTarefas.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorDeTarefas.Infrastructure;

public class GerenciadorTarefasDbContext : DbContext
{
    public DbSet<TarefasEntity> Tarefas { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=C:\\Users\\guirv\\Desenvolvimento\\BackEnd\\GerenciadorDeTarefas\\GerenciadorDeTarefasDB.db");
    }
}

