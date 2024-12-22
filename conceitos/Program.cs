// Criar objeto da classe Conexao
Conexao c = new();
// c.TestarConexao();

// Criar objeto da classe PessoaSQL
PessoaSQL p = new(c.ObterStringDeConexao());

// Cadastrando pessoas
// p.Cadastrar("Ralf", "Curitiba");
// p.Cadastrar("Ricardo", "Rio de Janeiro");

// Listando pessoas
// p.Selecionar();

// Alterar pessoa
// p.Alterar("Ralf edição", "Curitiba edição", 1);

// Excluir pessoa
// p.Excluir(1);
