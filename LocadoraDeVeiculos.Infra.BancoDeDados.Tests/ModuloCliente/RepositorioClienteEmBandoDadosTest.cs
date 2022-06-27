using FluentAssertions;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Infra.BancoDados.Tests.ModuloCompartilhado;
using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloCliente;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace LocadoraDeVeiculos.Infra.BancoDeDados.Tests.ModuloCliente
{
    [TestClass]
    public class RepositorioClienteEmBandoDadosTest : BaseTestRepositorio
    {
        Random random = new Random();
        RepositorioCliente repositorio = new();

        [TestMethod]
        public void Deve_selecionar_por_id()
        {
            Cliente registro = CriarClienteComCPF();
            repositorio.Inserir(registro);

            Cliente registro2 = repositorio.SelecionarPorID(registro.Id);

            Assert.AreEqual(registro2, registro);
        }

        [TestMethod]
        public void Deve_inserir_cliente_CPF()
        {
            Cliente cliente = CriarClienteComCPF();

            repositorio.Inserir(cliente);

            Cliente cliente2 = repositorio.SelecionarPorID(cliente.Id);

            Assert.AreEqual(cliente, cliente2);
        }

        public void Deve_inserir_cliente_CNPJ()
        {
            Cliente cliente = CriarClienteComCNPJ();

            repositorio.Inserir(cliente);

            Cliente cliente2 = repositorio.SelecionarPorID(cliente.Id);

            Assert.AreEqual(cliente, cliente2);
        }

        [TestMethod]
        public void Deve_excluir_Cliente()
        {
            Cliente cliente = CriarClienteComCPF();

            repositorio.Inserir(cliente);

            repositorio.Excluir(cliente);

            Cliente cliente2 = repositorio.SelecionarPorID(cliente.Id);

            cliente2.Should().Be(null);
        }
        [TestMethod]
        public void Deve_selecionar_todos_cliente()
        {
            List<Cliente> registros = new List<Cliente>();

            Cliente cliente;

            for (int i = 0; i < 10; i++)
            {
                if (i <= 5)
                    cliente = new Cliente("joao" + random.Next(100, 500).ToString(), "rua abrolingo filho", "12345678900", "joao@joao.com", "49989090909", true, "09876543211", null);
                else
                    cliente = new Cliente("joao" + random.Next(100, 500).ToString(), "rua abrolingo filho", "12345678900", "joao@joao.com", "49989090909", false, null, "09876543211");
                repositorio.Inserir(cliente);
                registros.Add(cliente);
            }

            List<Cliente> registrosDoBanco = repositorio.SelecionarTodos();

            for (int i = 0; i < registrosDoBanco.Count; i++)
                Assert.AreEqual(registrosDoBanco[i], registros[i]);
        }

        [TestMethod]
        public void Deve_editar_cliente()
        {
            Cliente cliente = CriarClienteComCPF();

            repositorio.Inserir(cliente);

            cliente.Nome = "ssssss";

            repositorio.Editar(cliente);

            Cliente cliente2 = repositorio.SelecionarPorID(cliente.Id);

            Assert.AreEqual(cliente2, cliente);
        }

        private Cliente CriarClienteComCPF()
        {
            return new Cliente("joao" + random.Next(100, 500).ToString(), "rua abrolingo filho", "12345678900", "joao@joao.com", "49989090909", true, "12340567889", null!);
        }

        private Cliente CriarClienteComCNPJ()
        {
            return new Cliente("joao" + random.Next(100, 500).ToString(), "rua abrolingo filho", "12345678900", "joao@joao.com", "49989090909", true, null!, "12340567889876");
        }
    }
}
