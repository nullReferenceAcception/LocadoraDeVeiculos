using FluentValidation.TestHelper;
using LocadoraDeVeiculos.Dominio.ModuloDevolucao;
using LocadoraDeVeiculos.Dominio.ModuloLocacao;
using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace LocadoraDeVeiculos.Dominio.Tests.ModuloDevolucao
{
    [TestClass]
    public class DevolucaoTest
    {
        ValidadorDevolucao _validador;
        public DevolucaoTest()
        {
            _validador = new();
        }

        [TestMethod]
        public void Nao_deve_inserir_sem_valorTotal()
        {
            Devolucao devolucao = GerarDevolucao();
            devolucao.ValorTotalReal = 0m;

            var res = _validador.TestValidate(devolucao);

            res.ShouldHaveValidationErrorFor(x => x.ValorTotalReal);
        }

        [TestMethod]
        public void Nao_deve_inserir_com_data_errada()
        {
            Devolucao devolucao = GerarDevolucao();
            devolucao.DataDevolucaoReal = DateTime.MinValue;
            var res = _validador.TestValidate(devolucao);

            res.ShouldHaveValidationErrorFor(x => x.DataDevolucaoReal.Date);
        }

        private Devolucao GerarDevolucao()
        {
            List<Taxa> taxas = new();
            return new Devolucao(new Locacao(), new Guid(), DateTime.Today, taxas, TanqueEnum.Cheio, 500.00m);
        }
    }
}
