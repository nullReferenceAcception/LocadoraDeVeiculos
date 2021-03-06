using FluentAssertions;
using FluentResults;
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
            Funcionario funcionario = CriarFuncionario();

            servico.Inserir(funcionario);

            Funcionario funcionarioEncontrado = servico.SelecionarPorGuid(funcionario.Id).Value;

            Assert.AreEqual(funcionario, funcionarioEncontrado);
        }

        [TestMethod]
        public void Deve_editar_Funcionario()
        {
            Funcionario funcionario = CriarFuncionario();

            servico.Inserir(funcionario);

            funcionario.Nome = "ssssss";

            servico.Editar(funcionario);

            Funcionario funcionarioEncontrado = servico.SelecionarPorGuid(funcionario.Id).Value;

            Assert.AreEqual(funcionarioEncontrado, funcionario);
        }

        [TestMethod]
        public void Deve_excluir_Funcionario()
        {
            Funcionario funcionario = CriarFuncionario();

            servico.Inserir(funcionario);

            servico.Excluir(funcionario);

            Funcionario funcionarioEncontrado = servico.SelecionarPorGuid(funcionario.Id).Value;

            funcionarioEncontrado.EstaAtivo.Should().Be(false);
        }

        [TestMethod]
        public void Deve_selecionar_todos_Funcionarios()
        {
            List<Funcionario> funcionarios = new List<Funcionario>();

            for (int i = 0; i < 10; i++)
            {
                Funcionario registro = new(GerarNovaStringAleatoria(), GerarNovaStringAleatoria(), "s@s.s", "49989090909", GerarNovaPlaca(), GerarNovaStringAleatoria(), DateTime.Today, 12, true, GerarNovaStringAleatoria(), true);

                servico.Inserir(registro);
                funcionarios.Add(registro);
            }

            List<Funcionario> registrosDoBanco = servico.SelecionarTodos().Value;

            Assert.IsTrue(registrosDoBanco.Count == funcionarios.Count);

            for (int i = 0; i < registrosDoBanco.Count; i++)
                Assert.IsTrue(registrosDoBanco.Contains(funcionarios[i]));
        }

        [TestMethod]
        public void Deve_selecionar_por_id()
        {
            Funcionario funcionario = CriarFuncionario();

            servico.Inserir(funcionario);

            Funcionario funcionarioEncontrado = servico.SelecionarPorGuid(funcionario.Id).Value;

            Assert.AreEqual(funcionarioEncontrado, funcionario);
        }

        [TestMethod]
        public void Nao_Deve_inserir_Funcionario_Com_Login_duplicado()
        {
            Funcionario funcionario = CriarFuncionario();

            servico.Inserir(funcionario);

            Funcionario outroFuncionario = CriarFuncionario();

            outroFuncionario.Nome = "asjkdhasjkdh";

            outroFuncionario.Login = funcionario.Login;

            Result<Funcionario> result = servico.Inserir(outroFuncionario);

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
