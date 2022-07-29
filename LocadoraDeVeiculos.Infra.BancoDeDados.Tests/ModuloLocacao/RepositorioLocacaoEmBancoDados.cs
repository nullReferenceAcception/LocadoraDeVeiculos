using FluentAssertions;
using FluentResults;
using LocadoraDeVeiculos.Dominio.ModuloLocacao;
using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Infra.BancoDados.Tests.ModuloCompartilhado;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace LocadoraDeVeiculos.Infra.BancoDeDados.Tests.ModuloLocacao
{
    [TestClass]
    public class RepositorioLocacaoEmBancoDados : BaseTestRepositorio
    {

        [TestMethod]
        public void Deve_inserir_locacao()
        {
            Locacao locacao = CriarLocacao();

            _servicoLocacao.Inserir(locacao);

            Locacao locacaoEncontrado = _servicoLocacao.SelecionarPorGuid(locacao.Id).Value;

            Assert.AreEqual(locacao, locacaoEncontrado);
        }

        [TestMethod]
        public void Deve_editar_locacao()
        {
            Locacao locacao = CriarLocacao();

            _servicoLocacao.Inserir(locacao);

            locacao.DataDevolucaoPrevista = System.DateTime.MaxValue;

            _servicoLocacao.Editar(locacao);

           Locacao locacaoEncontrado = _servicoLocacao.SelecionarPorGuid(locacao.Id).Value;

            Assert.AreEqual(locacao, locacaoEncontrado);
        }

        [TestMethod]
        public void Deve_Inativar_locacao()
        {
            Locacao locacao = CriarLocacao();

            _servicoLocacao.Inserir(locacao);

            _servicoLocacao.Excluir(locacao);


            Locacao locacaoEncontrado = _servicoLocacao.SelecionarPorGuid(locacao.Id).Value;

            locacaoEncontrado.Status.Should().Be(StatusEnum.Inativo);
        }
        [TestMethod]
        public void Deve_selecionar_por_id()
        {
            Locacao locacao = CriarLocacao();

            _servicoLocacao.Inserir(locacao);

            Locacao locacaoEncontrado = _servicoLocacao.SelecionarPorGuid(locacao.Id).Value;

            Assert.AreEqual(locacaoEncontrado, locacao);
        }


        [TestMethod]
        public void Nao_Deve_inserir_locacao_com_veiculo_ja_locado()
        {
            Locacao locacao = CriarLocacao();

            _servicoLocacao.Inserir(locacao);

            Locacao locacaoEncontrado = _servicoLocacao.SelecionarPorGuid(locacao.Id).Value;

            Result<Locacao> validationResult = _servicoLocacao.Inserir(locacaoEncontrado);

            validationResult.Errors[0].Message.Should().Contain("Veiculo já está alocado");
        }

        [TestMethod]
        public void Deve_selecionar_todos_locacao()
        {
            List<Locacao> locacoes = new List<Locacao>();

            for (int i = 0; i < 10; i++)
            {
                Locacao locacao = CriarLocacao();
                _servicoLocacao.Inserir(locacao);
                locacoes.Add(locacao);
            }

            List<Locacao> LocacoesEncontradas = _servicoLocacao.SelecionarTodos().Value;

            Assert.IsTrue(LocacoesEncontradas.Count == locacoes.Count);

            for (int i = 0; i < LocacoesEncontradas.Count; i++)
                Assert.IsTrue(LocacoesEncontradas.Contains(locacoes[i]));
        }
    }
}


