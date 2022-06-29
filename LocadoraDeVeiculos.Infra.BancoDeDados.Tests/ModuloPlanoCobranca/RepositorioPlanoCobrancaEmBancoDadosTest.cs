using FluentAssertions;
using FluentValidation.Results;
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.BancoDeDados.Tests.ModuloPlanoCobranca
{
    [TestClass]
    public class RepositorioPlanoCobrancaEmBancoDadosTest : BaseTestRepositorio
    {
        Random random = new Random();
        ServicoPlanoCobranca Servico = new(new RepositorioPlanoCobranca());
        ServicoGrupoVeiculos ServicoGrupo = new(new RepositorioGrupoVeiculos());

        [TestMethod]
        public void Deve_inserir_PlanoCobranca()
        {
            PlanoCobranca planoCobranca = CriarPlanoCobranca();

            Servico.Inserir(planoCobranca);

            PlanoCobranca PlanoCobranca2 = Servico.SelecionarPorID(planoCobranca.Id);

            Assert.AreEqual(planoCobranca, PlanoCobranca2);
        }

        [TestMethod]
        public void Deve_editar_PlanoCobranca()
        {
            PlanoCobranca PlanoCobranca = CriarPlanoCobranca();

            Servico.Inserir(PlanoCobranca);

            PlanoCobranca.Nome = "ssssss";

            Servico.Editar(PlanoCobranca);

            PlanoCobranca PlanoCobranca2 = Servico.SelecionarPorID(PlanoCobranca.Id);

            Assert.AreEqual(PlanoCobranca2, PlanoCobranca);
        }

        [TestMethod]
        public void Deve_excluir_PlanoCobranca()
        {
            PlanoCobranca PlanoCobranca = CriarPlanoCobranca();

            Servico.Inserir(PlanoCobranca);

            Servico.Excluir(PlanoCobranca);

            PlanoCobranca PlanoCobranca2 = Servico.SelecionarPorID(PlanoCobranca.Id);

            PlanoCobranca2.Should().Be(null);
        }

        [TestMethod]
        public void Deve_selecionar_por_id()
        {
            PlanoCobranca registro = CriarPlanoCobranca();
            Servico.Inserir(registro);

            PlanoCobranca registro2 = Servico.SelecionarPorID(registro.Id);

            Assert.AreEqual(registro2, registro);
        }


        [TestMethod]
        public void Nao_Deve_inserir_PlanoCobranca_duplicada()
        {
            PlanoCobranca PlanoCobranca = CriarPlanoCobranca();

            Servico.Inserir(PlanoCobranca);

            PlanoCobranca PlanoCobranca2 = CriarPlanoCobranca();

            PlanoCobranca2.Nome = PlanoCobranca.Nome;

            ValidationResult validationResult = Servico.Inserir(PlanoCobranca2);

            validationResult.Errors[0].ErrorMessage.Should().Contain("Nome já está cadastrado");
        }

        [TestMethod]
        public void Deve_selecionar_todos_PlanoCobrancas()
        {
            List<PlanoCobranca> registros = new List<PlanoCobranca>();

            GrupoVeiculos grupoVeiculos = new GrupoVeiculos("grupo");
            ServicoGrupo.Inserir(grupoVeiculos);

            for (int i = 0; i < 10; i++)
            {

                PlanoCobranca PlanoCobranca = new PlanoCobranca("nome", random.Next(1,200), random.Next(1, 200), random.Next(1, 200), grupoVeiculos);

                Servico.Inserir(PlanoCobranca);
                registros.Add(PlanoCobranca);
            }

            List<PlanoCobranca> registrosDoBanco = Servico.SelecionarTodos();

            for (int i = 0; i < registrosDoBanco.Count; i++)
                Assert.AreEqual(registrosDoBanco[i], registros[i]);
        }

        private PlanoCobranca CriarPlanoCobranca()
        {
            GrupoVeiculos grupoVeiculos = new GrupoVeiculos("grupo");
            ServicoGrupo.Inserir(grupoVeiculos);
            return new PlanoCobranca("nome", random.Next(1, 200), random.Next(1, 200), random.Next(1, 200), grupoVeiculos);
        }
    }
}
