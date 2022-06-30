namespace LocadoraDeVeiculos.Dominio.Compartilhado
{
    public abstract class Pessoa<T> : EntidadeBase<T>
    {
       public string? Nome { get; set; }
       public string? Endereco { get; set; }
       public string? Email { get; set; }
       public string? Telefone { get; set; }

        public Pessoa(string nome, string endereco, string email, string telefone)
        {
            Nome = nome;
            Endereco = endereco;
            Email = email;
            Telefone = telefone;
        }

        public Pessoa()
        {

        }
    }
}
