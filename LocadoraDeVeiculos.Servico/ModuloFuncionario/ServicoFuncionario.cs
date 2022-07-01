using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Servico.Compartilhado;

namespace LocadoraDeVeiculos.Servico.ModuloFuncionario
{
    public class ServicoFuncionario : ServicoBase<Funcionario, ValidadorFuncionario>, IServicoFuncionario
    {
        IRepositorioFuncionario repositorio;
        public ServicoFuncionario(IRepositorioFuncionario repositorio) : base(new ValidadorFuncionario(), repositorio)
        {
            this.repositorio = repositorio;
        }
        protected override string SqlMensagemDeErro => "Login já está cadastrado";
    }
}
