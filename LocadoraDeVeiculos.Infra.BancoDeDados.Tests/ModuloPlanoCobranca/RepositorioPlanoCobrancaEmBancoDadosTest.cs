using FluentAssertions;
using FluentResults;
using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Infra.BancoDados.Tests.ModuloCompartilhado;
using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Servico.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Servico.ModuloPlanoCobranca;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace LocadoraDeVeiculos.Infra.BancoDeDados.Tests.ModuloPlanoCobranca
{
    [TestClass]
    public class RepositorioPlanoCobrancaEmBancoDadosTest : BaseTestRepositorio
    {
        Random random = new();
        ServicoPlanoCobranca _servicoPlanoCobranca = new(new RepositorioPlanoCobranca());
        ServicoGrupoVeiculos _servicoGrupoVeiculo = new(new RepositorioGrupoVeiculos());

        [TestMethod]
        public void Deve_inserir_PlanoCobranca()
        {
            PlanoCobranca planoCobranca = CriarPlanoCobranca();

            _servicoPlanoCobranca.Inserir(planoCobranca);

            PlanoCobranca planoCobrancaEncontrado = _servicoPlanoCobranca.SelecionarPorGuid(planoCobranca.Guid).Value;

            Assert.AreEqual(planoCobranca, planoCobrancaEncontrado);
        }

        [TestMethod]
        public void Deve_editar_PlanoCobranca()
        {
            PlanoCobranca planoCobranca = CriarPlanoCobranca();

            _servicoPlanoCobranca.Inserir(planoCobranca);

            planoCobranca.Nome = "ssssss";

            _servicoPlanoCobranca.Editar(planoCobranca);

            PlanoCobranca planoCobrancaEncontrado = _servicoPlanoCobranca.SelecionarPorGuid(planoCobranca.Guid).Value;

            Assert.AreEqual(planoCobranca, planoCobrancaEncontrado);
        }

        [TestMethod]
        public void Deve_excluir_PlanoCobranca()
        {
            PlanoCobranca planoCobranca = CriarPlanoCobranca();

            _servicoPlanoCobranca.Inserir(planoCobranca);

            _servicoPlanoCobranca.Excluir(planoCobranca);

            PlanoCobranca planoCobrancaEncontrado = _servicoPlanoCobranca.SelecionarPorGuid(planoCobranca.Guid).Value;

            planoCobrancaEncontrado.Should().Be(null);
        }

        [TestMethod]
        public void Deve_selecionar_por_id()
        {
            PlanoCobranca planoCobranca = CriarPlanoCobranca();
            _servicoPlanoCobranca.Inserir(planoCobranca);

            PlanoCobranca planoCobrancaEncontrado = _servicoPlanoCobranca.SelecionarPorGuid(planoCobranca.Guid).Value;

            Assert.AreEqual(planoCobranca, planoCobrancaEncontrado);
        }

        [TestMethod]
        public void Nao_Deve_inserir_PlanoCobranca_duplicada()
        {
            PlanoCobranca planoCobranca = CriarPlanoCobranca();

            _servicoPlanoCobranca.Inserir(planoCobranca);

            PlanoCobranca outroPlanoCobranca = CriarPlanoCobranca();

            outroPlanoCobranca.Nome = planoCobranca.Nome;

            Result<PlanoCobranca> validationResult = _servicoPlanoCobranca.Inserir(outroPlanoCobranca);

            validationResult.Errors[0].Message.Should().Contain("Nome já está cadastrado");
        }

        [TestMethod]
        public void Deve_selecionar_todos_PlanoCobrancas()
        {
            List<PlanoCobranca> registros = new List<PlanoCobranca>();

            GrupoVeiculos grupoVeiculos = new GrupoVeiculos("grupo");
            _servicoGrupoVeiculo.Inserir(grupoVeiculos);

            PlanoCobranca PlanoCobranca = new PlanoCobranca(GerarNovaStringAleatoria(), random.Next(1, 200), random.Next(1, 200), random.Next(1, 200), PlanoEnum.KmLivre, grupoVeiculos);

            PlanoCobranca PlanoCobranca2 = new PlanoCobranca(GerarNovaStringAleatoria(), random.Next(1, 200), random.Next(1, 200), random.Next(1, 200), PlanoEnum.KmControlado, grupoVeiculos);

            PlanoCobranca PlanoCobranca3 = new PlanoCobranca(GerarNovaStringAleatoria(), random.Next(1, 200), random.Next(1, 200), random.Next(1, 200), PlanoEnum.Diario, grupoVeiculos);

            _servicoPlanoCobranca.Inserir(PlanoCobranca);

            _servicoPlanoCobranca.Inserir(PlanoCobranca2);

            _servicoPlanoCobranca.Inserir(PlanoCobranca3);

            registros.Add(PlanoCobranca);

            registros.Add(PlanoCobranca2);

            registros.Add(PlanoCobranca3);

            List<PlanoCobranca> registrosDoBanco = _servicoPlanoCobranca.SelecionarTodos().Value;

            Assert.IsTrue(registrosDoBanco.Count == registros.Count);

            for (int i = 0; i < registrosDoBanco.Count; i++)
                Assert.IsTrue(registrosDoBanco.Contains(registros[i]));
        }

        private PlanoCobranca CriarPlanoCobranca()
        {
            GrupoVeiculos grupoVeiculos = new GrupoVeiculos("grupo");
            _servicoGrupoVeiculo.Inserir(grupoVeiculos);
            return new PlanoCobranca(GerarNovaStringAleatoria(), random.Next(1, 200), random.Next(1, 200), random.Next(1, 200), PlanoEnum.KmControlado, grupoVeiculos);
        }
    }
}
