using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Servico.Compartilhado;
using System.Collections.Generic;

namespace LocadoraDeVeiculos.Servico.ModuloFuncionario
{
    public class ServicoFuncionario : ServicoBase<Funcionario, ValidadorFuncionario>, IServicoFuncionario
    {
        IRepositorioFuncionario _repositorioFuncionario;
        public ServicoFuncionario(IRepositorioFuncionario repositorioFuncionario) : base(new ValidadorFuncionario(), repositorioFuncionario)
        {
            this._repositorioFuncionario = repositorioFuncionario;
        }

        public List<Funcionario> SelecionarDesativados()
        {
            return _repositorioFuncionario.SelecionarDesativados();
        }

        protected override string SqlMensagemDeErroSeTiverDuplicidade => "Login já está cadastrado";
    }
}
