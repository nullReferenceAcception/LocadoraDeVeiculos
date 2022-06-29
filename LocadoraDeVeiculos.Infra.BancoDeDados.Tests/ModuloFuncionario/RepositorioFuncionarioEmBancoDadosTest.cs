using FluentAssertions;
using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Infra.BancoDados.Tests.ModuloCompartilhado;
using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloFuncionario;
using LocadoraDeVeiculos.Servico.ModuloFuncionario;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace LocadoraDeVeiculos.Infra.BancoDeDados.Tests.ModuloFuncionario
{
    [TestClass]
    public class servicoFuncionarioEmBancoDadosTest : BaseTestRepositorio
    {
        ServicoFuncionario servico = new(new RepositorioFuncionario());

        [TestMethod]
        public void Deve_inserir_Funcionario()
        {
            Funcionario registro = CriarFuncionario();

            servico.Inserir(registro);

            Funcionario registro2 = servico.SelecionarPorID(registro.Id);

            Assert.AreEqual(registro, registro2);
        }

        [TestMethod]
        public void Deve_editar_Funcionario()
        {
            Funcionario registro = CriarFuncionario();

            servico.Inserir(registro);

            registro.Nome = "ssssss";

            servico.Editar(registro);

            Funcionario registro2 = servico.SelecionarPorID(registro.Id);

            Assert.AreEqual(registro2, registro);
        }

        [TestMethod]
        public void Deve_excluir_Funcionario()
        {
            Funcionario registro = CriarFuncionario();

            servico.Inserir(registro);

            servico.Excluir(registro);

            Funcionario registro2 = servico.SelecionarPorID(registro.Id);

            registro2.EstaAtivo.Should().Be(false);
        }

        [TestMethod]
        public void Deve_selecionar_todos_Funcionarios()
        {
            List<Funcionario> registros = new List<Funcionario>();

            for (int i = 0; i < 10; i++)
            {
                Funcionario registro = new("nome " + i.ToString(), "senha", "endereco", "49989090909", "login", "senha", DateTime.Today, 12, true, "Lages", true);

                servico.Inserir(registro);
                registros.Add(registro);
            }

            List<Funcionario> registrosDoBanco = servico.SelecionarTodos();

            for (int i = 0; i < registrosDoBanco.Count; i++)
                Assert.AreEqual(registrosDoBanco[i], registros[i]);
        }

        [TestMethod]
        public void Deve_selecionar_por_id()
        {
            Funcionario registro = CriarFuncionario();
            servico.Inserir(registro);

            Funcionario registro2 = servico.SelecionarPorID(registro.Id);

            Assert.AreEqual(registro2, registro);
        }

        [TestMethod]
        public void Nao_Deve_inserir_Funcionario_Com_Login_duplicada()
        {
            Funcionario registro = CriarFuncionario();

            servico.Inserir(registro);

            Funcionario registro2 = CriarFuncionario();

            registro2.Nome = "asjkdhasjkdh";

            registro2.Login = registro.Login;

            ValidationResult validationResult = servico.Inserir(registro2);

            validationResult.Errors[0].ErrorMessage.Should().Contain("Login já está cadastrado");
        }




        private Funcionario CriarFuncionario()
        {
            return new("nome", "endereco", "e@e.e", "49991113939", "login", "senha", new DateTime(2020,02,02), 12, true, "Lages",true);
        }
    }
}
