using FluentAssertions;
using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using LocadoraDeVeiculos.Infra.BancoDados.Tests.ModuloCompartilhado;
using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloTaxa;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.BancoDeDados.Tests.ModuloTaxa
{
    [TestClass]
    public class RepositorioTaxaEmBancoDadosTest : BaseTestRepositorio
    {
        Random random = new Random();
        RepositorioTaxa repositorio = new();



        [TestMethod]
        public void Deve_selecionar_por_id()
        {
            Taxa registro = CriarTaxa();
            repositorio.Inserir(registro);

            Taxa registro2 = repositorio.SelecionarPorID(registro.Id);

            Assert.AreEqual(registro2, registro);
        }


        [TestMethod]
        public void Nao_Deve_inserir_Taxa_duplicada()
        {

            Taxa Taxa = CriarTaxa();

            repositorio.Inserir(Taxa);

            Taxa Taxa2 = CriarTaxa();

            Taxa2.Descricao = Taxa.Descricao;

          ValidationResult validationResult =  repositorio.Inserir(Taxa2);


            validationResult.Errors[0].ErrorMessage.Should().Contain("Nome já está cadastrado");

        }



        [TestMethod]
        public void Deve_inserir_Taxa()
        {

            Taxa Taxa = CriarTaxa();

            repositorio.Inserir(Taxa);

            Taxa Taxa2 = repositorio.SelecionarPorID(Taxa.Id);

            Assert.AreEqual(Taxa, Taxa2);

        }

        [TestMethod]
        public void Deve_excluir_Taxa()
        {


            Taxa Taxa = CriarTaxa();

            repositorio.Inserir(Taxa);

            repositorio.Excluir(Taxa);

            Taxa Taxa2 = repositorio.SelecionarPorID(Taxa.Id);

            Taxa2.Should().Be(null);

        }
        [TestMethod]
        public void Deve_selecionar_todos_Taxas()
        {
            List<Taxa> registros = new List<Taxa>();

            for (int i = 0; i < 10; i++)
            {
                Taxa Taxa = new Taxa("descricao " + i.ToString(), (random.Next(0, 100) + (decimal)Math.Round(random.NextDouble(), 2))); ;

                repositorio.Inserir(Taxa);
                registros.Add(Taxa);
            }

            List<Taxa> registrosDoBanco = repositorio.SelecionarTodos();

            for (int i = 0; i < registrosDoBanco.Count; i++)
            {
                Assert.AreEqual(registrosDoBanco[i], registros[i]);
            }


        }

        [TestMethod]
        public void Deve_editar_Taxa()
        {


            Taxa Taxa = CriarTaxa();

            repositorio.Inserir(Taxa);

            Taxa.Descricao = "ssssss";

            repositorio.Editar(Taxa);

            Taxa Taxa2 = repositorio.SelecionarPorID(Taxa.Id);


            Assert.AreEqual(Taxa2, Taxa);

        }
        //TODO Não pode deixar excluir caso esteja linkado em outro registro

        private Taxa CriarTaxa()
        {
            return new Taxa("descrição",(random.Next(0,100) + (decimal)Math.Round(random.NextDouble(),2)));
        }
    }
}
