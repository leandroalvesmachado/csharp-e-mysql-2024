// Importa o pacote EntityFrameworkCore para acesso ao Entity Framework Core
using Microsoft.EntityFrameworkCore;

// Define o contexto de dados para a entidade Pessoa, herdando de DbContext
public class PessoaDbContext : DbContext
{
    // Construtor que recebe opções de configuração para o DbContext
    public PessoaDbContext(DbContextOptions<PessoaDbContext> options) : base(options) { }

    // Representa a tabela 'Pessoas' no banco de dados
    public DbSet<Pessoa> Pessoas { get; set; }

    // Configura o modelo de dados, incluindo chaves primárias e relacionamentos
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Define a propriedade 'Codigo' como chave primária da entidade 'Pessoa'
        modelBuilder.Entity<Pessoa>().HasKey(i => i.Codigo);
    }
}