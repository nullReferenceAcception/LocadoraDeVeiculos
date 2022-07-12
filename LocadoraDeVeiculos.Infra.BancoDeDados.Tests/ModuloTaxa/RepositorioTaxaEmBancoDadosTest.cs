using FluentAssertions;
using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using LocadoraDeVeiculos.Infra.BancoDados.Tests.ModuloCompartilhado;
using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloTaxa;
using LocadoraDeVeiculos.Servico.ModuloTaxa;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace LocadoraDeVeiculos.Infra.BancoDeDados.Tests.ModuloTaxa
{
    [TestClass]
    public class RepositorioTaxaEmBancoDadosTest : BaseTestRepositorio
    {
        Random random = new Random();
        ServicoTaxa _servicoTaxa = new(new RepositorioTaxa());

        [TestMethod]
        public void Deve_inserir_Taxa()
        {
            Taxa taxa = CriarTaxa();

            _servicoTaxa.Inserir(taxa);

            Taxa tavaEncontrada = _servicoTaxa.SelecionarPorGuid(taxa.Guid);

            Assert.AreEqual(taxa, tavaEncontrada);
        }

        [TestMethod]
        public void Deve_editar_Taxa()
        {
            Taxa taxa = CriarTaxa();

            _servicoTaxa.Inserir(taxa);

            taxa.Descricao = "ssssss";

            _servicoTaxa.Editar(taxa);

            Taxa taxaEncontrada = _servicoTaxa.SelecionarPorGuid(taxa.Guid);

            Assert.AreEqual(taxaEncontrada, taxa);
        }

        [TestMethod]
        public void Deve_excluir_Taxa()
        {
            Taxa taxa = CriarTaxa();

            _servicoTaxa.Inserir(taxa);

            _servicoTaxa.Excluir(taxa);

            Taxa taxaEncontrada = _servicoTaxa.SelecionarPorGuid(taxa.Guid);

            taxaEncontrada.Should().Be(null);
        }

        [TestMethod]
        public void Deve_selecionar_por_id()
        {
            Taxa taxa = CriarTaxa();

            _servicoTaxa.Inserir(taxa);

            Taxa taxaEncontrada = _servicoTaxa.SelecionarPorGuid(taxa.Guid);

            Assert.AreEqual(taxaEncontrada, taxa);
        }

        [TestMethod]
        public void Nao_Deve_inserir_Taxa_duplicada()
        {
            Taxa taxa = CriarTaxa();

            _servicoTaxa.Inserir(taxa);

            Taxa taxaEncontrada = CriarTaxa();

            taxaEncontrada.Descricao = taxa.Descricao;

            ValidationResult validationResult = _servicoTaxa.Inserir(taxaEncontrada);

            validationResult.Errors[0].ErrorMessage.Should().Contain("Descrição já cadastrada");
        }

        [TestMethod]
        public void Deve_selecionar_todos_Taxas()
        {
            List<Taxa> taxas = new List<Taxa>();

            for (int i = 0; i < 10; i++)
            {
                Taxa Taxa = new Taxa(GerarNovaStringAleatoria(), (random.Next(0, 100) + (decimal)Math.Round(random.NextDouble(), 2)), true); ;

                _servicoTaxa.Inserir(Taxa);
                taxas.Add(Taxa);
            }

            List<Taxa> taxasEncontradas = _servicoTaxa.SelecionarTodos();


            Assert.IsTrue(taxasEncontradas.Count == taxas.Count);

            for (int i = 0; i < taxasEncontradas.Count; i++)
                Assert.IsTrue(taxasEncontradas.Contains(taxas[i]));
        }

        //TODO Não pode deixar excluir caso esteja linkado em outro registro

        private Taxa CriarTaxa()
        {
            return new Taxa(GerarNovaStringAleatoria(), (random.Next(0, 100) + (decimal)Math.Round(random.NextDouble(), 2)), true);
        }
    }
}
