using LocadoraDeVeiculos.Dominio.Compartilhado;
using System;

namespace LocadoraDeVeiculos.Dominio.ModuloCliente
{
    public class Cliente : Pessoa<Cliente>

    {
        public string CNH { get; set; }
        public DateTime DataValidadeCNH { get; set; }
        public bool PessoaFisica { get; set; } // Falso = Pessoa Juridica
        public string CPF { get; set; }
        public string CNPJ { get; set; }

        public Cliente ()
        {

        }

        public Cliente(string nome, string endereco, string cnh, string email, string telefone, bool pessoafisica, string cpf, string cnpj,DateTime data)
        {
            Nome = nome;
            CNH = cnh;
            Endereco = endereco;
            Email = email;
            Telefone = telefone;
            PessoaFisica = pessoafisica;
            CPF = cpf;
            CNPJ = cnpj;
            DataValidadeCNH = data;
        }

        public override string? ToString()
        {
            return Nome;
        }

        public override bool Equals(object? obj)
        {
            return obj is Cliente cliente &&
                   Guid == cliente.Guid &&
                   Nome == cliente.Nome &&
                   Endereco == cliente.Endereco &&
                   Email == cliente.Email &&
                   Telefone == cliente.Telefone &&
                   CNH == cliente.CNH &&
                   DataValidadeCNH == cliente.DataValidadeCNH &&
                   PessoaFisica == cliente.PessoaFisica &&
                   CPF == cliente.CPF &&
                   CNPJ == cliente.CNPJ;
        }
    }
}
