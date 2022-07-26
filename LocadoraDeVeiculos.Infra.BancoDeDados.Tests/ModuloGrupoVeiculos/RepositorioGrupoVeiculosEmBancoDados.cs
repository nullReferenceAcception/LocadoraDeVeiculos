using FluentAssertions;
using FluentResults;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Infra.BancoDados.Compartilhado;
using LocadoraDeVeiculos.Infra.BancoDados.Tests.ModuloCompartilhado;
using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Infra.ORM.Compartilhado;
using LocadoraDeVeiculos.Servico.ModuloGrupoVeiculos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace LocadoraDeVeiculos.Infra.BancoDeDados.Tests.ModuloGrupoVeiculos
{
    [TestClass]
    public class RepositorioGrupoVeiculosEmBancoDados : BaseTestRepositorio
    {
        ServicoGrupoVeiculos _servicoGrupoVeiculos;

        public RepositorioGrupoVeiculosEmBancoDados()
        {
            _servicoGrupoVeiculos = new(new RepositorioGrupoVeiculos(), new LocadoraDbContext(Db.conexaoComBanco.ConnectionString));
        }

        [TestMethod]
        public void Deve_inserir_GrupoVeiculos()
        {
            GrupoVeiculos grupoVeiculos = CriarGrupoVeiculos();

            _servicoGrupoVeiculos.Inserir(grupoVeiculos);

            GrupoVeiculos grupoVeiculosEncontrado = _servicoGrupoVeiculos.SelecionarPorGuid(grupoVeiculos.Id).Value;

            Assert.AreEqual(grupoVeiculos, grupoVeiculosEncontrado);
        }

        [TestMethod]
        public void Deve_editar_GrupoVeiculos()
        {
            GrupoVeiculos grupoVeiculos = CriarGrupoVeiculos();

            _servicoGrupoVeiculos.Inserir(grupoVeiculos);

            grupoVeiculos.Nome = "ssssss";

            _servicoGrupoVeiculos.Editar(grupoVeiculos);

            GrupoVeiculos grupoVeiculosEncontrado = _servicoGrupoVeiculos.SelecionarPorGuid(grupoVeiculos.Id).Value;

            Assert.AreEqual(grupoVeiculosEncontrado, grupoVeiculos);
        }

        [TestMethod]
        public void Deve_excluir_GrupoVeiculos()
        {
            GrupoVeiculos grupoVeiculos = CriarGrupoVeiculos();

            _servicoGrupoVeiculos.Inserir(grupoVeiculos);

            _servicoGrupoVeiculos.Excluir(grupoVeiculos);

            GrupoVeiculos grupoVeiculosEncontrado = _servicoGrupoVeiculos.SelecionarPorGuid(grupoVeiculos.Id).Value;

            grupoVeiculosEncontrado.Should().Be(null);
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
            GrupoVeiculos grupoVeiculos = CriarGrupoVeiculos();
            _servicoGrupoVeiculos.Inserir(grupoVeiculos);

            GrupoVeiculos grupoVeiculosEncontrado = _servicoGrupoVeiculos.SelecionarPorGuid(grupoVeiculos.Id).Value;

            Assert.AreEqual(grupoVeiculosEncontrado, grupoVeiculos);
        }

        [TestMethod]
        public void Nao_Deve_inserir_GrupoVeiculos_duplicada()
        {
            GrupoVeiculos grupoVeiculos = CriarGrupoVeiculos();

            _servicoGrupoVeiculos.Inserir(grupoVeiculos);

            GrupoVeiculos grupoVeiculosEncontrado = CriarGrupoVeiculos();

            grupoVeiculosEncontrado.Nome = grupoVeiculos.Nome;

            Result<GrupoVeiculos> result = _servicoGrupoVeiculos.Inserir(grupoVeiculosEncontrado);

            result.Errors[0].Message.Should().Contain("Nome já está cadastrado");
        }

        private GrupoVeiculos CriarGrupoVeiculos()
        {
            return new GrupoVeiculos(GerarNovaStringAleatoria());
        }
    }
}
