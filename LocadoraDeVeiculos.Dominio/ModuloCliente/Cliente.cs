using LocadoraDeVeiculos.Dominio.Compartilhado;
using System;

namespace LocadoraDeVeiculos.Dominio.ModuloCliente
{
    public class Cliente : Pessoa<Cliente>
    {
        public bool PessoaFisica { get; set; } // Falso = Pessoa Juridica
        public string? CPF { get; set; }
        public string? CNPJ { get; set; }

        public Cliente ()
        {

        }

        public Cliente(string nome, string endereco, string email, string telefone, bool pessoafisica, string cpf, string cnpj)
        {
            Nome = nome;
            Endereco = endereco;
            Email = email;
            Telefone = telefone;
            PessoaFisica = pessoafisica;
            CPF = cpf;
            CNPJ = cnpj;
        }

        public override string? ToString()
        {
            return Nome;
        }

        public override bool Equals(object? obj)
        {
            return obj is Cliente cliente &&
                   Id == cliente.Id &&
                   Nome == cliente.Nome &&
                   Endereco == cliente.Endereco &&
                   Email == cliente.Email &&
                   Telefone == cliente.Telefone &&
                   PessoaFisica == cliente.PessoaFisica &&
                   CPF == cliente.CPF &&
                   CNPJ == cliente.CNPJ;
        }
    }
}
