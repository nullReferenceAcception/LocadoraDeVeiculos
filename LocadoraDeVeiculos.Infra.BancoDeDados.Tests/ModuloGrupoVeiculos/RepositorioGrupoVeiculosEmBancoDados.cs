using FluentAssertions;
using FluentResults;
using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Infra.BancoDados.Tests.ModuloCompartilhado;
using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Servico.ModuloGrupoVeiculos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace LocadoraDeVeiculos.Infra.BancoDeDados.Tests.ModuloGrupoVeiculos
{
    [TestClass]
    public class RepositorioGrupoVeiculosEmBancoDados : BaseTestRepositorio
    {
        ServicoGrupoVeiculos _servicoGrupoVeiculos = new(new RepositorioGrupoVeiculos());

        [TestMethod]
        public void Deve_inserir_GrupoVeiculos()
        {
            GrupoVeiculos GrupoVeiculos = CriarGrupoVeiculos();

            _servicoGrupoVeiculos.Inserir(GrupoVeiculos);

            GrupoVeiculos GrupoVeiculos2 = _servicoGrupoVeiculos.SelecionarPorGuid(GrupoVeiculos.Guid).Value;

            Assert.AreEqual(GrupoVeiculos, GrupoVeiculos2);
        }

        [TestMethod]
        public void Deve_editar_GrupoVeiculos()
        {
            GrupoVeiculos GrupoVeiculos = CriarGrupoVeiculos();

            _servicoGrupoVeiculos.Inserir(GrupoVeiculos);

            GrupoVeiculos.Nome = "ssssss";

            _servicoGrupoVeiculos.Editar(GrupoVeiculos);

            GrupoVeiculos GrupoVeiculos2 = _servicoGrupoVeiculos.SelecionarPorGuid(GrupoVeiculos.Guid).Value;

            Assert.AreEqual(GrupoVeiculos2, GrupoVeiculos);
        }

        [TestMethod]
        public void Deve_excluir_GrupoVeiculos()
        {
            GrupoVeiculos GrupoVeiculos = CriarGrupoVeiculos();

            _servicoGrupoVeiculos.Inserir(GrupoVeiculos);

            _servicoGrupoVeiculos.Excluir(GrupoVeiculos);

            GrupoVeiculos GrupoVeiculos2 = _servicoGrupoVeiculos.SelecionarPorGuid(GrupoVeiculos.Guid).Value;

            GrupoVeiculos2.Should().Be(null);
        }

        [TestMethod]
        public void Deve_selecionar_todos_GrupoVeiculos()
        {
            List<GrupoVeiculos> registros = new List<GrupoVeiculos>();

            for (int i = 0; i < 10; i++)
            {
                GrupoVeiculos GrupoVeiculos = new GrupoVeiculos(GerarNovaStringAleatoria());

                _servicoGrupoVeiculos.Inserir(GrupoVeiculos);
                registros.Add(GrupoVeiculos);
            }

            List<GrupoVeiculos> registrosDoBanco = _servicoGrupoVeiculos.SelecionarTodos().Value;

            Assert.IsTrue(registrosDoBanco.Count == registros.Count);


            for (int i = 0; i < registrosDoBanco.Count; i++)
                Assert.IsTrue(registrosDoBanco.Contains(registros[i]));
        }

        [TestMethod]
        public void Deve_selecionar_por_id()
        {
            GrupoVeiculos registro = CriarGrupoVeiculos();
            _servicoGrupoVeiculos.Inserir(registro);

            GrupoVeiculos registro2 = _servicoGrupoVeiculos.SelecionarPorGuid(registro.Guid).Value;

            Assert.AreEqual(registro2, registro);
        }

        [TestMethod]
        public void Nao_Deve_inserir_GrupoVeiculos_duplicada()
        {
            GrupoVeiculos grupoVeiculos = CriarGrupoVeiculos();

            _servicoGrupoVeiculos.Inserir(grupoVeiculos);

            GrupoVeiculos grupoVeiculos2 = CriarGrupoVeiculos();

            grupoVeiculos2.Nome = grupoVeiculos.Nome;

            Result<GrupoVeiculos> result = _servicoGrupoVeiculos.Inserir(grupoVeiculos2);

            result.Errors[0].Message.Should().Contain("Nome já está cadastrado");
        }

        private GrupoVeiculos CriarGrupoVeiculos()
        {
            return new GrupoVeiculos(GerarNovaStringAleatoria());
        }
    }
}
