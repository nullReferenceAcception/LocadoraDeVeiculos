using FluentAssertions;
using FluentResults;
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

            Funcionario registro2 = servico.SelecionarPorGuid(registro.Guid).Value;

            Assert.AreEqual(registro, registro2);
        }

        [TestMethod]
        public void Deve_editar_Funcionario()
        {
            Funcionario registro = CriarFuncionario();

            servico.Inserir(registro);

            registro.Nome = "ssssss";

            servico.Editar(registro);

            Funcionario registro2 = servico.SelecionarPorGuid(registro.Guid).Value;

            Assert.AreEqual(registro2, registro);
        }

        [TestMethod]
        public void Deve_excluir_Funcionario()
        {
            Funcionario registro = CriarFuncionario();

            servico.Inserir(registro);

            servico.Excluir(registro);

            Funcionario registro2 = servico.SelecionarPorGuid(registro.Guid).Value;

            registro2.EstaAtivo.Should().Be(false);
        }

        [TestMethod]
        public void Deve_selecionar_todos_Funcionarios()
        {
            List<Funcionario> registros = new List<Funcionario>();

            for (int i = 0; i < 10; i++)
            {
                Funcionario registro = new(GerarNovaStringAleatoria(), GerarNovaStringAleatoria(), "s@s.s", "49989090909", GerarNovaPlaca(), GerarNovaStringAleatoria(), DateTime.Today, 12, true, GerarNovaStringAleatoria(), true);

                servico.Inserir(registro);
                registros.Add(registro);
            }

            List<Funcionario> registrosDoBanco = servico.SelecionarTodos().Value;


            Assert.IsTrue(registrosDoBanco.Count == registros.Count);

            for (int i = 0; i < registrosDoBanco.Count; i++)
                Assert.IsTrue(registrosDoBanco.Contains(registros[i]));
        }

        [TestMethod]
        public void Deve_selecionar_por_id()
        {
            Funcionario registro = CriarFuncionario();
            servico.Inserir(registro);

            Funcionario registro2 = servico.SelecionarPorGuid(registro.Guid).Value;

            Assert.AreEqual(registro2, registro);
        }

        [TestMethod]
        public void Nao_Deve_inserir_Funcionario_Com_Login_duplicado()
        {
            Funcionario registro = CriarFuncionario();

            servico.Inserir(registro);

            Funcionario registro2 = CriarFuncionario();

            registro2.Nome = "asjkdhasjkdh";

            registro2.Login = registro.Login;

            Result<Funcionario> result = servico.Inserir(registro2);

            result.Errors[0].Message.Should().Contain("Login já está cadastrado");
        }

        private Funcionario CriarFuncionario()
        {
            return new(GerarNovaStringAleatoria(), GerarNovaStringAleatoria(), "e@e.e", "49991113939", GerarNovaStringAleatoria(), GerarNovaStringAleatoria(), new DateTime(2020,02,02), 12, true, GerarNovaStringAleatoria(), true);
        }

        private string GerarNovaPlaca()
        {
            const int qtdeLetras = 8;

            const string letras = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string novaPlaca = "";
            Random random = new();

            for (int i = 0; i < qtdeLetras; i++)
                novaPlaca += letras[random.Next(letras.Length)];


            return novaPlaca;
        }


    }
}
