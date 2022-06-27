using FluentAssertions;
using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Infra.BancoDados.Tests.ModuloCompartilhado;
using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloGrupoVeiculos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace LocadoraDeVeiculos.Infra.BancoDeDados.Tests.ModuloGrupoVeiculos
{
    [TestClass]
    public class RepositorioGrupoVeiculosEmBancoDados : BaseTestRepositorio
    {
        RepositorioGrupoVeiculos repositorio = new();

        [TestMethod]
        public void Deve_selecionar_por_id()
        {
            GrupoVeiculos registro = CriarGrupoVeiculos();
            repositorio.Inserir(registro);

            GrupoVeiculos registro2 = repositorio.SelecionarPorID(registro.Id);

            Assert.AreEqual(registro2, registro);
        }


        [TestMethod]
        public void Nao_Deve_inserir_GrupoVeiculos_duplicada()
        {
            GrupoVeiculos GrupoVeiculos = CriarGrupoVeiculos();

            repositorio.Inserir(GrupoVeiculos);

            GrupoVeiculos GrupoVeiculos2 = CriarGrupoVeiculos();

            GrupoVeiculos2.Nome = GrupoVeiculos.Nome;

            ValidationResult validationResult = repositorio.Inserir(GrupoVeiculos2);

            validationResult.Errors[0].ErrorMessage.Should().Contain("Nome já está cadastrado");
        }



        [TestMethod]
        public void Deve_inserir_GrupoVeiculos()
        {
            GrupoVeiculos GrupoVeiculos = CriarGrupoVeiculos();

            repositorio.Inserir(GrupoVeiculos);

            GrupoVeiculos GrupoVeiculos2 = repositorio.SelecionarPorID(GrupoVeiculos.Id);

            Assert.AreEqual(GrupoVeiculos, GrupoVeiculos2);
        }

        [TestMethod]
        public void Deve_excluir_GrupoVeiculos()
        {
            GrupoVeiculos GrupoVeiculos = CriarGrupoVeiculos();

            repositorio.Inserir(GrupoVeiculos);

            repositorio.Excluir(GrupoVeiculos);

            GrupoVeiculos GrupoVeiculos2 = repositorio.SelecionarPorID(GrupoVeiculos.Id);

            GrupoVeiculos2.Should().Be(null);
        }

        [TestMethod]
        public void Deve_selecionar_todos_GrupoVeiculoss()
        {
            List<GrupoVeiculos> registros = new List<GrupoVeiculos>();

            for (int i = 0; i < 10; i++)
            {
                GrupoVeiculos GrupoVeiculos = new GrupoVeiculos("Nome " + i.ToString());

                repositorio.Inserir(GrupoVeiculos);
                registros.Add(GrupoVeiculos);
            }

            List<GrupoVeiculos> registrosDoBanco = repositorio.SelecionarTodos();

            for (int i = 0; i < registrosDoBanco.Count; i++)
                Assert.AreEqual(registrosDoBanco[i], registros[i]);
        }

        //TODO Não pode deixar excluir caso esteja linkado em outro registro

        [TestMethod]
        public void Deve_editar_GrupoVeiculos()
        {
            GrupoVeiculos GrupoVeiculos = CriarGrupoVeiculos();

            repositorio.Inserir(GrupoVeiculos);

            GrupoVeiculos.Nome = "ssssss";

            repositorio.Editar(GrupoVeiculos);

            GrupoVeiculos GrupoVeiculos2 = repositorio.SelecionarPorID(GrupoVeiculos.Id);

            Assert.AreEqual(GrupoVeiculos2, GrupoVeiculos);
        }
        //TODO Não pode deixar excluir caso esteja linkado em outro registro

        private GrupoVeiculos CriarGrupoVeiculos()
        {
            return new GrupoVeiculos("Nomé são");
        }
    }
}
