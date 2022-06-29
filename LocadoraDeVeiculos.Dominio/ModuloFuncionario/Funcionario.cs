﻿using LocadoraDeVeiculos.Dominio.Compartilhado;
using System;

namespace LocadoraDeVeiculos.Dominio.ModuloFuncionario
{
    public class Funcionario : Pessoa<Funcionario>
    {
        public string? Login { get; set; }
        public string? Senha { get; set; }
        public string? Cidade { get; set; }
        public DateTime DataAdmissao { get; set; }
        public Decimal Salario { get; set; }
        public bool EhAdmin { get; set; } // True é admin, false é comum

        public Funcionario()
        {

        }

        public Funcionario(string nome, string endereco, string email, string telefone, string login, string senha, DateTime dataAdmissao, Decimal salario, bool ehAdmin, string cidade) : base(nome, endereco, email, telefone)
        {
            Login = login;
            Senha = senha;
            DataAdmissao = dataAdmissao;
            Salario = salario;
            EhAdmin = ehAdmin;
            Cidade = cidade;
        }

     
        public override bool Equals(object? obj)
        {
            return obj is Funcionario funcionario &&
                   Id == funcionario.Id &&
                   Nome == funcionario.Nome &&
                   Endereco == funcionario.Endereco &&
                   Email == funcionario.Email &&
                   Telefone == funcionario.Telefone &&
                   Login == funcionario.Login &&
                   Senha == funcionario.Senha &&
                   DataAdmissao == funcionario.DataAdmissao &&
                   Salario == funcionario.Salario &&
                   Cidade == funcionario.Cidade &&
                   EhAdmin == funcionario.EhAdmin;
        }
    }
}
