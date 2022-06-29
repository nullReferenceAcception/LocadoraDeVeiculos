using LocadoraDeVeiculos.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloCondutor
{
    public  class Condutor : Pessoa<Condutor>
    {
        public string CNH { get; set; }
        public string CPF { get; set; }

        public Condutor()
        {

        }

        public Condutor(string nome, string endereco, string cnh, string email, string telefone, bool pessoafisica, string cpf, string cnpj)
        {
            Nome = nome;
            CNH = cnh;
            Endereco = endereco;
            Email = email;
            Telefone = telefone;
            CPF = cpf;
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
                   CPF == condutor.CPF;
        }
    }
}
