using FluentResults;
using Locadora.Infra.Configs;
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

        public ServicoCliente(IRepositorioCliente repositorioCliente, IContextoPersistencia contexto,ConfiguracaoAplicacaoLocadora loc) : base(new ValidadorCliente(), repositorioCliente, contexto,loc)
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
        protected override string MensagemDeErroSeTiverDuplicidade { get; set; } = "CPF já está cadastrado";

        protected override bool HaDuplicidade(Cliente registro)
        {
            if (base.HaDuplicidade(registro))
                return true;

            else if (TiverDuplicidadeCNPJ(registro))
            {
                MensagemDeErroSeTiverDuplicidade = "CNPJ já está cadastrado";
                return true;
            }

            return false;
        }

        private bool TiverDuplicidadeCNPJ(Cliente registro)
        {
            return _repositorioCliente.VerificarDuplicidadeCNPJ(registro);
        }
    }
}
