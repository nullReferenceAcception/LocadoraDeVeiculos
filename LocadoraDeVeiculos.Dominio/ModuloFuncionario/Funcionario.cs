using LocadoraDeVeiculos.Dominio.Compartilhado;
using System;

namespace LocadoraDeVeiculos.Dominio.ModuloFuncionario
{
    public class Funcionario : Pessoa<Funcionario>
    {
        public string? Login { get; set; }
        public string? Senha { get; set; }
        public DateTime DataAdmissao { get; set; }
        public Decimal Salario { get; set; }
        public bool EhAdmin { get; set; } // True é admin, false é comum
        public override void Atualizar(Funcionario registro)
        {
            this.Nome = registro.Nome;
            this.Endereco = registro.Endereco;
            this.Email = registro.Email;
            this.Telefone = registro.Telefone;
            this.Login = registro.Login;
            this.Senha = registro.Senha;
            this.DataAdmissao = registro.DataAdmissao;
            this.Salario = registro.Salario;
            this.EhAdmin = registro.EhAdmin;
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
                   EhAdmin == funcionario.EhAdmin;
        }
    }
}
