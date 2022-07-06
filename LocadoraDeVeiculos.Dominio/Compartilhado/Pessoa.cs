using Newtonsoft.Json;

namespace LocadoraDeVeiculos.Dominio.Compartilhado
{
    public abstract class Pessoa<T> : EntidadeBase<T>
    {
       [JsonProperty(Order = -9)]
       public string? Nome { get; set; }
        [JsonProperty(Order = -8)]
        public string? Endereco { get; set; }
        [JsonProperty(Order = -7)]
        public string? Email { get; set; }
        [JsonProperty(Order = -6)]
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
