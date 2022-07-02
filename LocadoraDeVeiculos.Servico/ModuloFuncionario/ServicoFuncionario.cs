using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Servico.Compartilhado;
using System.Collections.Generic;

namespace LocadoraDeVeiculos.Servico.ModuloFuncionario
{
    public class ServicoFuncionario : ServicoBase<Funcionario, ValidadorFuncionario>, IServicoFuncionario
    {
        IRepositorioFuncionario repositorio;
        public ServicoFuncionario(IRepositorioFuncionario repositorio) : base(new ValidadorFuncionario(), repositorio)
        {
            this.repositorio = repositorio;
        }
        protected override string SqlMensagemDeErroSeTiverDuplicidade => "Login já está cadastrado";

        public List<Funcionario> SelecionarDesativados()
        {
            return repositorio.SelecionarDesativados();
        }
    }
}
