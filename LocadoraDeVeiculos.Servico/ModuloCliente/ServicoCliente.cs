using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Servico.Compartilhado;
using System.Collections.Generic;

namespace LocadoraDeVeiculos.Servico.ModuloCliente
{
    public class ServicoCliente : ServicoBase<Cliente, ValidadorCliente>, IServicoCliente
    {
        IRepositorioCliente _repositorioCliente;

        public ServicoCliente(IRepositorioCliente repositorioCliente) : base(new ValidadorCliente(), repositorioCliente)
        {
            this._repositorioCliente = repositorioCliente;
        }

        public List<Cliente> SelecionarTodosClientesQueSaoPessoaFisica()
        {
            return _repositorioCliente.SelecionarTodosClientesQueSaoPessoaFisica();
        }

        public List<Cliente> SelecionarTodosClientesQueSaoPessoaJuridica()
        {
            return _repositorioCliente.SelecionarTodosClientesQueSaoPessoaJuridica();
        }

        protected override string SqlMensagemDeErroSeTiverDuplicidade => "Nome já está cadastrado";
    }
}
