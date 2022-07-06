using Newtonsoft.Json;

namespace LocadoraDeVeiculos.Dominio.Compartilhado
{
    public abstract class Pessoa<T> : EntidadeBase<T>
    {
       [JsonProperty(Order = -3)]
       public string? Nome { get; set; }
        [JsonProperty(Order = -2)]
        public string? Endereco { get; set; }
        [JsonProperty(Order = -1)]
        public string? Email { get; set; }
        [JsonProperty(Order = 0)]
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
