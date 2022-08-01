using FluentResults;
using Locadora.Infra.Configs;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloDevolucao;
using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using LocadoraDeVeiculos.Servico.Compartilhado;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;

namespace LocadoraDeVeiculos.Servico.ModuloDevolucao
{
    public class ServicoDevolucao : ServicoBase<Devolucao, ValidadorDevolucao>, IServicoDevolucao
    {
        IRepositorioDevolucao _repositorioDevolucao;
        public ServicoDevolucao(IRepositorioDevolucao repositorio, IContextoPersistencia contexto, ConfiguracaoAplicacaoLocadora loc) : base(new ValidadorDevolucao(), repositorio, contexto,loc)
        {
            _repositorioDevolucao = repositorio;
        }

        public void RemoverTaxas(Devolucao devolucao, List<Taxa> taxas)
        {
            try
            {
                Log.Logger.Information("Removendo taxa de {@devolucao}", devolucao);
                _repositorioDevolucao.RemoverTaxas(devolucao, taxas);
            }
            catch (Exception ex)
            {
                StringBuilder msgErro = new StringBuilder("erro ao remover taxa de ");

                Log.Logger.Error(ex, msgErro + "{@classe}", devolucao);
            }
        }


        protected override string MensagemDeErroSeTiverDuplicidade { get; set; } = "zXy";
    }
}
