using FluentAssertions;
using LocadoraDeVeiculos.Dominio.ModuloDevolucao;
using LocadoraDeVeiculos.Infra.BancoDados.Tests.ModuloCompartilhado;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.BancoDeDados.Tests.ModuloDevolucao
{
    [TestClass]
    public class RepositorioDevolucaoEmBancoDados : BaseTestRepositorio
    {

        [TestMethod]
        public void Deve_inserir_devolucao()
        {
            Devolucao devolucao = CriarDevolucao();

            _servicoDevolucao.Inserir(devolucao);

            Devolucao devolucaoEncontrado = _servicoDevolucao.SelecionarPorGuid(devolucao.Id).Value;

            Assert.AreEqual(devolucao, devolucaoEncontrado);
        }

        [TestMethod]
        public void Deve_selecionar_por_id()
        {
            Devolucao devolucao = CriarDevolucao();

            _servicoDevolucao.Inserir(devolucao);

            Devolucao devolucaoEncontrado = _servicoDevolucao.SelecionarPorGuid(devolucao.Id).Value;

            Assert.AreEqual(devolucaoEncontrado, devolucao);
        }

        [TestMethod]
        public void Deve_selecionar_todos_devolucao()
        {
            List<Devolucao> devolucoes = new List<Devolucao>();

            for (int i = 0; i < 10; i++)
            {
                Devolucao devolucao = CriarDevolucao();
                _servicoDevolucao.Inserir(devolucao);
                devolucoes.Add(devolucao);
            }

            List<Devolucao> devolucoesEncontradas = _servicoDevolucao.SelecionarTodos().Value;

            Assert.IsTrue(devolucoesEncontradas.Count == devolucoes.Count);

            for (int i = 0; i < devolucoesEncontradas.Count; i++)
                Assert.IsTrue(devolucoesEncontradas.Contains(devolucoes[i]));
        }
    }
}
