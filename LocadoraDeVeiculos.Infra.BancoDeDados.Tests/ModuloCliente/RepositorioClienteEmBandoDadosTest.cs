using FluentAssertions;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Infra.BancoDados.Tests.ModuloCompartilhado;
using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloCliente;
using LocadoraDeVeiculos.Servico.ModuloCliente;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace LocadoraDeVeiculos.Infra.BancoDeDados.Tests.ModuloCliente
{
    [TestClass]
    public class RepositorioClienteEmBandoDadosTest : BaseTestRepositorio
    {
        Random random = new Random();
        ServicoCliente _servicoCliente = new(new RepositorioCliente());

        [TestMethod]
        public void Deve_inserir_cliente_CPF()
        {
            Cliente cliente = CriarClienteComCPF();

            _servicoCliente.Inserir(cliente);

            Cliente cliente2 = _servicoCliente.SelecionarPorGuid(cliente.guid);

            Assert.AreEqual(cliente, cliente2);
        }

        public void Deve_inserir_cliente_CNPJ()
        {
            Cliente cliente = CriarClienteComCNPJ();

            _servicoCliente.Inserir(cliente);

            Cliente cliente2 = _servicoCliente.SelecionarPorGuid(cliente.guid);

            Assert.AreEqual(cliente, cliente2);
        }

        [TestMethod]
        public void Deve_editar_cliente()
        {
            Cliente cliente = CriarClienteComCPF();

            _servicoCliente.Inserir(cliente);

            cliente.Nome = "ssssss";

            _servicoCliente.Editar(cliente);

            Cliente cliente2 = _servicoCliente.SelecionarPorGuid(cliente.guid);

            Assert.AreEqual(cliente2, cliente);
        }

        [TestMethod]
        public void Deve_excluir_Cliente()
        {
            Cliente cliente = CriarClienteComCPF();

            _servicoCliente.Inserir(cliente);

            _servicoCliente.Excluir(cliente);

            Cliente cliente2 = _servicoCliente.SelecionarPorGuid(cliente.guid);

            cliente2.Should().Be(null);
        }
        [TestMethod]
        public void Deve_selecionar_todos_cliente()
        {
            List<Cliente> registros = new List<Cliente>();

            Cliente cliente;

            for (int i = 0; i < 10; i++)
            {
                 cliente = new Cliente("joao" + random.Next(100, 500).ToString(), "rua abrolingo filho", "12345678900", "joao@joao.com", "49989090909", true, "09876543211", null, DateTime.Today);
                _servicoCliente.Inserir(cliente);
                registros.Add(cliente);
            }

            List<Cliente> registrosDoBanco = _servicoCliente.SelecionarTodos();

            for (int i = 0; i < registrosDoBanco.Count; i++)
                Assert.AreEqual(registrosDoBanco[i], registros[i]);
        }

        [TestMethod]
        public void Deve_Selecionar_todos_clientes_que_sao_pessoas_fisicas()
        {
            Cliente clienteCPF = CriarClienteComCPF();

            Cliente clienteCPF2 = new Cliente("joaos", "rua abrolingo filho", "12345678900", "joao@joao.com", "49989090909", true, "12340567889", null!, DateTime.Today);

            Cliente clienteCPF3= new Cliente("joaoes", "rua abrolingo filho", "12345678900", "joao@joao.com", "49989090909", true, "12340567889", null!, DateTime.Today);

            Cliente clienteCNPJ = new Cliente("jo", "rua abrolingo filho", "12345678900", "joao@joao.com", "49989090909", false, null!, "12340567889876", DateTime.Today);

            _servicoCliente.Inserir(clienteCPF);

            _servicoCliente.Inserir(clienteCPF2);

            _servicoCliente.Inserir(clienteCPF3);

            _servicoCliente.Inserir(clienteCNPJ);

            List<Cliente> clientes = _servicoCliente.SelecionarTodosClientesQueSaoPessoaFisica();

            clientes.Should().Contain(clienteCPF);
            clientes.Should().Contain(clienteCPF2);
            clientes.Should().Contain(clienteCPF3);
        }

        [TestMethod]
        public void Deve_Selecionar_todos_clientes_que_sao_pessoas_juridicas()
        {
            Cliente clienteCPF = CriarClienteComCPF();

            Cliente clienteCPF2 = new Cliente("joaos", "rua abrolingo filho", "12345678900", "joao@joao.com", "49989090909", true, "12340567889", null!, DateTime.Today);

            Cliente clienteCPF3 = new Cliente("joaoes", "rua abrolingo filho", "12345678900", "joao@joao.com", "49989090909", true, "12340567889", null!, DateTime.Today);

            Cliente clienteCNPJ = new Cliente("joasdasdsa", "rua abrolingo filho", "12345678900", "joao@joao.com", "49989090909", false, null!, "12340567889876", DateTime.Today);

            _servicoCliente.Inserir(clienteCPF);

            _servicoCliente.Inserir(clienteCPF2);

            _servicoCliente.Inserir(clienteCPF3);

            _servicoCliente.Inserir(clienteCNPJ);

            List<Cliente> clientes = _servicoCliente.SelecionarTodosClientesQueSaoPessoaJuridica();

            clientes.Should().Contain(clienteCNPJ);
        }

        private Cliente CriarClienteComCPF()
        {
            return new Cliente("joao", "rua abrolingo filho", "12345678900", "joao@joao.com", "49989090909", true, "12340567889", null!, DateTime.Today);
        }

        private Cliente CriarClienteComCNPJ()
        {
            return new Cliente("joao", "rua abrolingo filho", "12345678900", "joao@joao.com", "49989090909", true, null!, "12340567889876", DateTime.Today);
        }
    }
}
