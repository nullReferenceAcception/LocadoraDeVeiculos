using FluentAssertions;
using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Infra.BancoDados.Tests.ModuloCompartilhado;
using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloFuncionario;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.BancoDeDados.Tests.ModuloFuncionario
{
    [TestClass]
    public class RepositorioFuncionarioEmBancoDadosTest : BaseTestRepositorio
    {
        Random random = new Random();
        RepositorioFuncionario repositorio = new();



        [TestMethod]
        public void Deve_selecionar_por_id()
        {
            Funcionario registro = CriarFuncionario();
            repositorio.Inserir(registro);

            Funcionario registro2 = repositorio.SelecionarPorID(registro.Id);

            Assert.AreEqual(registro2, registro);
        }


        [TestMethod]
        public void Nao_Deve_inserir_Funcionario_duplicada()
        {

            Funcionario registro = CriarFuncionario();

            repositorio.Inserir(registro);

            Funcionario registro2 = CriarFuncionario();

            registro2.Nome = registro.Nome;

            ValidationResult validationResult = repositorio.Inserir(registro2);


            validationResult.Errors[0].ErrorMessage.Should().Contain("Nome já está cadastrado");

        }



        [TestMethod]
        public void Deve_inserir_Funcionario()
        {

            Funcionario registro = CriarFuncionario();

            repositorio.Inserir(registro);

            Funcionario registro2 = repositorio.SelecionarPorID(registro.Id);

            Assert.AreEqual(registro, registro2);

        }

        [TestMethod]
        public void Deve_excluir_Funcionario()
        {


            Funcionario registro = CriarFuncionario();

            repositorio.Inserir(registro);

            repositorio.Excluir(registro);

            Funcionario registro2 = repositorio.SelecionarPorID(registro.Id);

            registro2.Should().Be(null);

        }
        [TestMethod]
        public void Deve_selecionar_todos_Funcionarios()
        {
            List<Funcionario> registros = new List<Funcionario>();

            for (int i = 0; i < 10; i++)
            {
                Funcionario registro = new("nome " + i.ToString(), "senha", "endereco", "telefone", "login", "senha", DateTime.Now, 12, true);

                repositorio.Inserir(registro);
                registros.Add(registro);
            }

            List<Funcionario> registrosDoBanco = repositorio.SelecionarTodos();

            for (int i = 0; i < registrosDoBanco.Count; i++)
            {
                Assert.AreEqual(registrosDoBanco[i], registros[i]);
            }


        }

        [TestMethod]
        public void Deve_editar_Funcionario()
        {


            Funcionario registro = CriarFuncionario();

            repositorio.Inserir(registro);

            registro.Nome = "ssssss";

            repositorio.Editar(registro);

            Funcionario registro2 = repositorio.SelecionarPorID(registro.Id);


            Assert.AreEqual(registro2, registro);

        }
      

        private Funcionario CriarFuncionario()
        {
            return new("nome", "endereco", "email", "telefone", "login", "senha", DateTime.Now, 12, true);
        }
    }
}
