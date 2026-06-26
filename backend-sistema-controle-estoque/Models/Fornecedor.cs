namespace backend_sistema_controle_estoque.Models;

public class Fornecedor
{
    public int Id { get; private set; }
    public string Nome { get; private set; }
    public string Cnpj { get; private set; }
    public string Email { get; private set; }
    public string Telefone { get; private set; }
    public bool Ativo { get; private set; } = true;
    public ICollection<Produto> Produtos { get; private set; } = new List<Produto>();

    private Fornecedor () 
    { 
    
    }

    public Fornecedor(string nome, string cnpj, string email, string telefone)
    {
        ValidarFornecedor(nome, cnpj, email, telefone);

        Nome = nome.Trim();
        Cnpj = cnpj.Trim();
        Email = email.Trim();
        Telefone = telefone.Trim();
    }

    private void ValidarFornecedor(string nome, string cnpj, string email, string telefone)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException("O nome do fornecedor não pode ser vazio");
        if (string.IsNullOrWhiteSpace(cnpj))
            throw new ArgumentException("O CNPJ do fornecedor não pode ser vazio");
        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("O email do fornecedor não pode ser vazio");
        if (string.IsNullOrWhiteSpace(telefone))
            throw new ArgumentException("O telefone do fornecedor não pode ser vazio");

    }

    public void Atualizar(string novoNome ,string novoEmail, string novoTelefone) 
    {

        ValidarFornecedor(novoNome, Cnpj, novoEmail, novoTelefone);

        Nome = novoNome.Trim();
        Email = novoEmail.Trim();
        Telefone = novoTelefone.Trim();

    }

    public void Desativar()
    {
        if (!Ativo)
            throw new ArgumentException("O forncecedor já está desativado");

        Ativo = false;
    }

}
