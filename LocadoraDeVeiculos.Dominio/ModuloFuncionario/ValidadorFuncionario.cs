using FluentValidation;
using System;
using System.Text.RegularExpressions;

namespace LocadoraDeVeiculos.Dominio.ModuloFuncionario
{
    public class ValidadorFuncionario : AbstractValidator<Funcionario>
    {
        public ValidadorFuncionario()
        {
            Regex padraoNome = new Regex("^[A-Z a-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ]*$");
            Regex padraoTelefone = new(@"^[1-9]{2}[0-9]{4,5}[0-9]{4}$");

            RuleFor(x => x.Nome)
                .NotNull().NotEmpty().MinimumLength(2).Matches(padraoNome);
            RuleFor(x => x.Telefone)
                .NotNull().NotEmpty().Matches(padraoTelefone);
            RuleFor(x => x.Endereco)
                .NotNull().NotEmpty();
            RuleFor(x => x.Email)
                .NotNull().NotEmpty().EmailAddress();
            RuleFor(x => x.EhAdmin)
                .NotNull();
            RuleFor(x => x.Login)
                .NotNull().NotEmpty();
            RuleFor(x => x.Senha)
                .NotNull().NotEmpty();
            RuleFor(x => x.DataAdmissao)
                .NotNull().NotEmpty().GreaterThan(DateTime.MinValue).LessThan(DateTime.Today);
            RuleFor(x => x.Salario)
                .NotNull().NotEmpty().GreaterThan(0);
        }
    }
}
