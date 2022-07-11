using FluentAssertions;
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

            GrupoVeiculos GrupoVeiculos2 = _servicoGrupoVeiculos.SelecionarPorGuid(GrupoVeiculos.Guid);

            Assert.AreEqual(GrupoVeiculos, GrupoVeiculos2);
        }

        [TestMethod]
        public void Deve_editar_GrupoVeiculos()
        {
            GrupoVeiculos GrupoVeiculos = CriarGrupoVeiculos();

            _servicoGrupoVeiculos.Inserir(GrupoVeiculos);

            GrupoVeiculos.Nome = "ssssss";

            _servicoGrupoVeiculos.Editar(GrupoVeiculos);

            GrupoVeiculos GrupoVeiculos2 = _servicoGrupoVeiculos.SelecionarPorGuid(GrupoVeiculos.Guid);

            Assert.AreEqual(GrupoVeiculos2, GrupoVeiculos);
        }

        [TestMethod]
        public void Deve_excluir_GrupoVeiculos()
        {
            GrupoVeiculos GrupoVeiculos = CriarGrupoVeiculos();

            _servicoGrupoVeiculos.Inserir(GrupoVeiculos);

            _servicoGrupoVeiculos.Excluir(GrupoVeiculos);

            GrupoVeiculos GrupoVeiculos2 = _servicoGrupoVeiculos.SelecionarPorGuid(GrupoVeiculos.Guid);

            GrupoVeiculos2.Should().Be(null);
        }

        [TestMethod]
        public void Deve_selecionar_todos_GrupoVeiculos()
        {
            List<GrupoVeiculos> registros = new List<GrupoVeiculos>();

            for (int i = 0; i < 10; i++)
            {
                GrupoVeiculos GrupoVeiculos = new GrupoVeiculos("Nome " + i.ToString());

                _servicoGrupoVeiculos.Inserir(GrupoVeiculos);
                registros.Add(GrupoVeiculos);
            }

            List<GrupoVeiculos> registrosDoBanco = _servicoGrupoVeiculos.SelecionarTodos();

            for (int i = 0; i < registrosDoBanco.Count; i++)
                Assert.AreEqual(registrosDoBanco[i], registros[i]);
        }

        [TestMethod]
        public void Deve_selecionar_por_id()
        {
            GrupoVeiculos registro = CriarGrupoVeiculos();
            _servicoGrupoVeiculos.Inserir(registro);

            GrupoVeiculos registro2 = _servicoGrupoVeiculos.SelecionarPorGuid(registro.Guid);

            Assert.AreEqual(registro2, registro);
        }

        [TestMethod]
        public void Nao_Deve_inserir_GrupoVeiculos_duplicada()
        {
            GrupoVeiculos GrupoVeiculos = CriarGrupoVeiculos();

            _servicoGrupoVeiculos.Inserir(GrupoVeiculos);

            GrupoVeiculos GrupoVeiculos2 = CriarGrupoVeiculos();

            GrupoVeiculos2.Nome = GrupoVeiculos.Nome;

            ValidationResult validationResult = _servicoGrupoVeiculos.Inserir(GrupoVeiculos2);

            validationResult.Errors[0].ErrorMessage.Should().Contain("Nome já está cadastrado");
        }

        private GrupoVeiculos CriarGrupoVeiculos()
        {
            return new GrupoVeiculos("Nome é");
        }
    }
}
