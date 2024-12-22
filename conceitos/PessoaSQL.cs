// Importar o MySql.Data.MySqlClient
using MySql.Data.MySqlClient;

class PessoaSQL
{
    // Atributo contendo a string de conexão
    // Quando o atributo é readonly, só pode ser modificado no método construtor
    private readonly string? _stringDeConexao;

    // Método construtor
    public PessoaSQL(string conexao)
    {
        _stringDeConexao = conexao;
    }

    // Método para efetuar o cadastro
    public void Cadastrar(string nome, string cidade)
    {
        // Comando SQL
        string sql = "INSERT INTO base.pessoas (nome, cidade) VALUES(@nome, @cidade);";

        // Conexão com o banco de dados e execução do comando SQL
        using (var conexao = new MySqlConnection(_stringDeConexao))
        using (var comando = new MySqlCommand(sql, conexao))
        {
            // Especificar os parâmetros do SQL
            comando.Parameters.AddWithValue("@nome", nome);
            comando.Parameters.AddWithValue("@cidade", cidade);

            // Executar comando SQL
            try
            {
                conexao.Open();
                comando.ExecuteNonQuery();
                Console.WriteLine("Cadastrado efetuado com sucesso.");
            }
            catch (Exception e)
            {
                
                Console.WriteLine("Falha ao cadastrar: " + e.Message);
            }
        }
    }

    // Método para efetuar a seleção
    public void Selecionar()
    {
        // Comando SQL
        string sql = "SELECT * FROM base.pessoas";

        // Conexão com o banco de dados e execução do comando SQL
        using (var conexao = new MySqlConnection(_stringDeConexao))
        using (var comando = new MySqlCommand(sql, conexao))
        {
            try
            {
                // Abrir conexão MySQL
                conexao.Open();
                
                // Listar todas as pessoas
                using (var pessoas = comando.ExecuteReader())
                {
                    while (pessoas.Read())
                    {
                        Console.WriteLine("Código: " + pessoas["codigo"]);
                        Console.WriteLine("Nome: " + pessoas["nome"]);
                        Console.WriteLine("Cidade: " + pessoas["cidade"]);
                    }
                }
            }
            catch (Exception e)
            {
                
                Console.WriteLine("Falha ao selecionar: " + e.Message);
            }
        }
    }

    // Método para efetuar a edição
    public void Alterar(string nome, string cidade, int codigo)
    {
        // Comando SQL
        string sql = "UPDATE base.pessoas SET nome = @nome, cidade = @cidade WHERE codigo = @codigo;";

        // Conexão com o banco de dados e execução do comando SQL
        using (var conexao = new MySqlConnection(_stringDeConexao))
        using (var comando = new MySqlCommand(sql, conexao))
        {
            // Especificar os parâmetros do SQL
            comando.Parameters.AddWithValue("@nome", nome);
            comando.Parameters.AddWithValue("@cidade", cidade);
            comando.Parameters.AddWithValue("@codigo", codigo);

            // Executar comando SQL
            try
            {
                conexao.Open();
                comando.ExecuteNonQuery();
                Console.WriteLine("Dados alterados com sucesso.");
            }
            catch (Exception e)
            {
                
                Console.WriteLine("Falha ao alterar: " + e.Message);
            }
        }
    }

    // Método para efetuar a remoção
    public void Excluir(int codigo)
    {
        // Comando SQL
        string sql = "DELETE FROM base.pessoas WHERE codigo = @codigo;";

        // Conexão com o banco de dados e execução do comando SQL
        using (var conexao = new MySqlConnection(_stringDeConexao))
        using (var comando = new MySqlCommand(sql, conexao))
        {
            // Especificar os parâmetros do SQL
            comando.Parameters.AddWithValue("@codigo", codigo);

            // Executar comando SQL
            try
            {
                conexao.Open();
                comando.ExecuteNonQuery();
                Console.WriteLine("Pessoa removida com sucesso.");
            }
            catch (Exception e)
            {
                
                Console.WriteLine("Falha ao remover: " + e.Message);
            }
        }
    }
}