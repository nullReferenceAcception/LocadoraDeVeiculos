using FluentResults;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using LocadoraDeVeiculos.Servico.Compartilhado;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;

namespace LocadoraDeVeiculos.Servico.ModuloTaxa
{
    public class ServicoTaxa : ServicoBase<Taxa, ValidadorTaxa>, IServicoTaxa
    {
        private IRepositorioTaxa _repositorioTaxa;
        public ServicoTaxa(IRepositorioTaxa repositorioTaxa, IContextoPersistencia contexto) : base(new ValidadorTaxa(), repositorioTaxa, contexto)
        {
            _repositorioTaxa = repositorioTaxa;
        }

        protected override string MensagemDeErroSeTiverDuplicidade { get; set; } = "Descrição já cadastrada";

        public Result<List<Taxa>> SelecionarTodosAdicionais()
        {
            try
            {
                return Result.Ok(_repositorioTaxa.SelecionarTodosAdicionais());
            }
            catch (Exception ex)
            {
                StringBuilder msgErro = new StringBuilder("Falha no sistema ao tentar selecionar todos os  ");

                Log.Logger.Error(ex, msgErro + "{classe}", typeof(Taxa).Name);

                return Result.Fail(msgErro.Append(typeof(Taxa).Name).ToString());
            }
        }
    }
}
