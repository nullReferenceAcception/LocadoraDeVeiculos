using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using System;
using System.Collections.Generic;

namespace LocadoraDeVeiculos.Dominio.ModuloCondutor
{
    public class Condutor : Pessoa<Condutor>
    {
        public string CNH { get; set; }
        public string CPF { get; set; }
        public DateTime DataValidadeCNH { get; set; }
        public Cliente Cliente { get; set; }

        public Condutor()
        {

        }

        public Condutor(string nome, string endereco, string cnh, string email, string telefone, string cpf, DateTime dataValidadeCNH)
        {
            Nome = nome;
            CNH = cnh;
            Endereco = endereco;
            Email = email;
            Telefone = telefone;
            CPF = cpf;
            DataValidadeCNH = dataValidadeCNH;
        }

        public override bool Equals(object? obj)
        {
            return obj is Condutor condutor &&
                   Id == condutor.Id &&
                   Nome == condutor.Nome &&
                   Endereco == condutor.Endereco &&
                   Email == condutor.Email &&
                   Telefone == condutor.Telefone &&
                   CNH == condutor.CNH &&
                   CPF == condutor.CPF &&
                   EqualityComparer<Cliente>.Default.Equals(Cliente, condutor.Cliente) &&
                   DataValidadeCNH == condutor.DataValidadeCNH;
        }
    }
}
