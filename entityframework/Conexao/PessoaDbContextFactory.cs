// Importa pacotes necessários para o Entity Framework e para a criação do contexto de banco de dados
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

// Classe responsável pela criação do contexto de banco de dados em tempo de design
public class PessoaDbContextFactory : IDesignTimeDbContextFactory<PessoaDbContext>
{
    // COnfigurações de conexão para o banco de dados MySQL
    private readonly string _server = "localhost";
    private readonly string _database = "base_entityframework";
    private readonly string _user = "root";
    private readonly string _password = "1q2w3e4r";

    public PessoaDbContext CreateDbContext(string[] args)
    {
        var connectionString = $"Server={_server};Database={_database};User ID={_user};Password={_password};";

        var optionsBuilder = new DbContextOptionsBuilder<PessoaDbContext>();
        optionsBuilder.UseMySQL(connectionString); // Configura o provedor MySQL para o contexto

        // Retorna uma nova instância do contexto de banco de dados configurado
        return new PessoaDbContext(optionsBuilder.Options);
    }
}