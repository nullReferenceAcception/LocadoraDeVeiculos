﻿using LocadoraDeVeiculos.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloCliente
{
    public class Cliente : Pessoa<Cliente>

    {
        public string CNH { get; set; }
        public bool PessoaFisica { get; set; } // Falso = Pessoa Juridica
        public string CPF { get; set; }
        public string CNPJ { get; set; }

        public Cliente ()
        {

        }
        public Cliente(string nome, string endereco, string cnh, string email, string telefone, bool pessoafisica, string cpf, string cnpj)
        {
            Nome = nome;
            CNH = cnh;
            Endereco = endereco;
            Email = email;
            Telefone = telefone;
            PessoaFisica = pessoafisica;
            CPF = cpf;
            CNPJ = cnpj;
        }

        public override void Atualizar(Cliente registro)
        {
            this.Nome = registro.Nome;
            this.CNH = registro.CNH;
            this.Endereco = registro.Endereco;
            this.Email = registro.Email;
            this.Telefone = registro.Telefone;
            this.PessoaFisica = registro.PessoaFisica;
            this.CPF = registro.CPF;
            this.CNPJ = registro.CNPJ;
        }

        public override bool Equals(object? obj)
        {
            return obj is Cliente cliente &&
                   Id == cliente.Id &&
                   Nome == cliente.Nome &&
                   CNH == cliente.CNH &&
                   Endereco == cliente.Endereco &&
                   Email == cliente.Email &&
                   Telefone == cliente.Telefone &&
                   PessoaFisica == cliente.PessoaFisica &&
                   CPF == cliente.CPF &&
                   CNPJ == cliente.CNPJ;
        }

        
    }
}
