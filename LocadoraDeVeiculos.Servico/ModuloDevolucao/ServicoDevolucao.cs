using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloDevolucao;
using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using LocadoraDeVeiculos.Servico.Compartilhado;
using System;
using System.Collections.Generic;

namespace LocadoraDeVeiculos.Servico.ModuloDevolucao
{
    public class ServicoDevolucao : ServicoBase<Devolucao, ValidadorDevolucao>, IServicoDevolucao
    {
        IRepositorioDevolucao _repositorioDevolucao;
        public ServicoDevolucao(IRepositorioDevolucao repositorio, IContextoPersistencia contexto) : base(new ValidadorDevolucao(), repositorio, contexto)
        {
            _repositorioDevolucao = repositorio;
        }

        public void RemoverTaxas(Devolucao devolucao, List<Taxa> taxas) => _repositorioDevolucao.RemoverTaxas(devolucao, taxas);

        protected override string MensagemDeErroSeTiverDuplicidade { get; set; } = "zXy";
    }
}
