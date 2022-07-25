using FluentResults;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Servico.Compartilhado;
using Serilog;
using System;
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

        public Result<List<Cliente>> SelecionarTodosClientesQueSaoPessoaFisica()
        {

            try
            {
                return Result.Ok(_repositorioCliente.SelecionarTodosClientesQueSaoPessoaFisica());
            }
            catch (Exception ex)
            {
                string msgErro = $"Falha no sistema ao tentar selecionar todos os clientes fisicos ";

                Log.Logger.Error(ex, msgErro);

                return Result.Fail(msgErro);
            }

        }

        public Result<List<Cliente>> SelecionarTodosClientesQueSaoPessoaJuridica()
        {
            try
            {
                return Result.Ok(_repositorioCliente.SelecionarTodosClientesQueSaoPessoaJuridica());
            }
            catch (Exception ex)
            {
                string msgErro = $"Falha no sistema ao tentar selecionar todos os clientes juridicos";

                Log.Logger.Error(ex, msgErro);

                return Result.Fail(msgErro);
            }
        }

        protected override string MensagemDeErroSeTiverDuplicidade => "Nome já está cadastrado";
    }
}
