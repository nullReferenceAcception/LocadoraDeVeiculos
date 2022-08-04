using FluentAssertions;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Infra.BancoDados.Compartilhado;
using LocadoraDeVeiculos.Infra.BancoDados.Tests.ModuloCompartilhado;
using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloCliente;
using LocadoraDeVeiculos.Infra.ORM.Compartilhado;
using LocadoraDeVeiculos.Infra.ORM.ModuloCliente;
using LocadoraDeVeiculos.Servico.ModuloCliente;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace LocadoraDeVeiculos.Infra.BancoDeDados.Tests.ModuloCliente
{
    [TestClass]
    public class RepositorioClienteEmBandoDadosTest : BaseTestRepositorio
    {
        [TestMethod]
        public void Deve_inserir_cliente_CPF()
        {
            Cliente cliente = CriarClienteComCPF();

            _servicoCliente.Inserir(cliente);

            Cliente clienteEncontrado = _servicoCliente.SelecionarPorGuid(cliente.Id).Value;

            Assert.AreEqual(cliente, clienteEncontrado);
        }

        [TestMethod]
        public void Deve_inserir_cliente_CNPJ()
        {
            Cliente cliente = CriarClienteComCNPJ();

            _servicoCliente.Inserir(cliente);

            Cliente clienteEncontrado = _servicoCliente.SelecionarPorGuid(cliente.Id).Value;

            Assert.AreEqual(cliente, clienteEncontrado);
        }

        [TestMethod]
        public void Deve_editar_cliente()
        {
            Cliente cliente = CriarClienteComCPF();

            _servicoCliente.Inserir(cliente);

            cliente.Nome = "ssssss";

            _servicoCliente.Editar(cliente);

            Cliente clienteEncontrado = _servicoCliente.SelecionarPorGuid(cliente.Id).Value;

            Assert.AreEqual(clienteEncontrado, cliente);
        }

        [TestMethod]
        public void Deve_excluir_Cliente()
        {
            Cliente cliente = CriarClienteComCPF();

            _servicoCliente.Inserir(cliente);

            _servicoCliente.Excluir(cliente);

            Cliente clienteEncontrado = _servicoCliente.SelecionarPorGuid(cliente.Id).Value;

            clienteEncontrado.Should().Be(null);
        }
        [TestMethod]
        public void Deve_selecionar_todos_cliente()
        {
            List<Cliente> registros = new List<Cliente>();

            Cliente cliente;

            for (int i = 0; i < 10; i++)
            {

                if (i > 5)
                 cliente = new Cliente(GerarNovaStringAleatoria(), GerarNovaStringAleatoria(), "joao@joao.com", "49989090909", true, GerarCpfAleatorio(), null);
             else
                 cliente = new Cliente(GerarNovaStringAleatoria(), GerarNovaStringAleatoria(), "joao@joao.com", "49989090909", false, null, GerarCnpjAleatorio());



                _servicoCliente.Inserir(cliente);
                registros.Add(cliente);
            }

            List<Cliente> registrosDoBanco = _servicoCliente.SelecionarTodos().Value;

            Assert.IsTrue(registrosDoBanco.Count == registros.Count);

            for (int i = 0; i < registrosDoBanco.Count; i++)
                Assert.IsTrue(registrosDoBanco.Contains(registros[i]));
        }

        [TestMethod]
        public void Deve_Selecionar_todos_clientes_que_sao_pessoas_fisicas()
        {
            Cliente clienteCPF = CriarClienteComCPF();

            Cliente clienteCPF2 = new Cliente("joaos", "rua abrolingo filho", "joao@joao.com", "49989090909", true, GerarCpfAleatorio(), null!);

            Cliente clienteCPF3= new Cliente("joaoes", "rua abrolingo filho", "joao@joao.com", "49989090909", true, GerarCpfAleatorio(), null!);

            Cliente clienteCNPJ = new Cliente("jo", "rua abrolingo filho", "joao@joao.com", "49989090909", false, null!, GerarCnpjAleatorio());

            _servicoCliente.Inserir(clienteCPF);

            _servicoCliente.Inserir(clienteCPF2);

            _servicoCliente.Inserir(clienteCPF3);

            _servicoCliente.Inserir(clienteCNPJ);

            List<Cliente> clientes = _servicoCliente.SelecionarTodosClientesQueSaoPessoaFisica().Value;

            clientes.Should().Contain(clienteCPF);
            clientes.Should().Contain(clienteCPF2);
            clientes.Should().Contain(clienteCPF3);
        }

        [TestMethod]
        public void Deve_Selecionar_todos_clientes_que_sao_pessoas_juridicas()
        {
            Cliente clienteCPF = CriarClienteComCPF();

            Cliente clienteCPF2 = new Cliente("joaos", "rua abrolingo filho", "joao@joao.com", "49989090909", true, GerarCpfAleatorio(), null!);

            Cliente clienteCPF3 = new Cliente("joaoes", "rua abrolingo filho", "joao@joao.com", "49989090909", true, GerarCpfAleatorio(), null!);

            Cliente clienteCNPJ = new Cliente("joasdasdsa", "rua abrolingo filho", "joao@joao.com", "49989090909", false, null!, GerarCnpjAleatorio());

            _servicoCliente.Inserir(clienteCPF);

            _servicoCliente.Inserir(clienteCPF2);

            _servicoCliente.Inserir(clienteCPF3);

            _servicoCliente.Inserir(clienteCNPJ);

            List<Cliente> clientes = _servicoCliente.SelecionarTodosClientesQueSaoPessoaJuridica().Value;

            clientes.Should().Contain(clienteCNPJ);
        }
    }
}
