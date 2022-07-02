using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Servico.Compartilhado;
using System.Collections.Generic;

namespace LocadoraDeVeiculos.Servico.ModuloCliente
{
    public class ServicoCliente : ServicoBase<Cliente, ValidadorCliente>, IServicoCliente
    {
        IRepositorioCliente repositorio;
        public ServicoCliente(IRepositorioCliente repositorio) : base(new ValidadorCliente(), repositorio)
        {
            this.repositorio = repositorio;
        }

        protected override string SqlMensagemDeErroSeTiverDuplicidade => "Nome já está cadastrado";

        public List<Cliente> SelecionarTodosClientesQueSaoPessoaFisica()
        {
            return repositorio.SelecionarTodosClientesQueSaoPessoaFisica();
        }

        public List<Cliente> SelecionarTodosClientesQueSaoPessoaJuridica()
        {
            return repositorio.SelecionarTodosClientesQueSaoPessoaJuridica();
        }
    }
}
