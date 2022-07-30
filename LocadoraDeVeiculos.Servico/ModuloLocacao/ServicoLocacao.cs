﻿using FluentResults;
using Locadora.Infra.Configs;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloLocacao;
using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using LocadoraDeVeiculos.Servico.Compartilhado;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;

namespace LocadoraDeVeiculos.Servico.ModuloLocacao
{
    public class ServicoLocacao : ServicoBase<Locacao, ValidadorLocacao>, IServicoLocacao
    {
        IRepositorioLocacao repositorioLocacao;
        public ServicoLocacao(IRepositorioLocacao repositorioLocacao, IContextoPersistencia contexto, ConfiguracaoAplicacaoLocadora loc) : base(new ValidadorLocacao(), repositorioLocacao, contexto,loc)
        {
            this.repositorioLocacao= repositorioLocacao;
        }
        
        public void RemoverTaxas(Locacao locacao,List<Taxa> taxas)
        {

            try
            {
                Log.Logger.Information("Removendo taxa de {locacao}", locacao);
                repositorioLocacao.RemoverTaxas(locacao, taxas);
            }
            catch (Exception ex)
            {
                StringBuilder msgErro = new StringBuilder("erro ao remover taxa de ");

                Log.Logger.Error(ex, msgErro + "{locacao}", locacao);
            }

            
        }

        public Result<List<Locacao>> SelecionarDesativados()
        {
            try
            {
                return Result.Ok(repositorioLocacao.SelecionarDesativados());
            }
            catch (Exception ex)
            {
                string msgErro = $"Falha no sistema ao tentar selecionar todos as loc~ções desativadas";

                Log.Logger.Error(ex, msgErro);

                return Result.Fail(msgErro);
            }
        }

        protected override string MensagemDeErroSeTiverDuplicidade { get; set; } = "Veiculo já está alocado";
    }
}
