using FluentAssertions;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Infra.BancoDados.Tests.ModuloCompartilhado;
using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloCliente;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Cliente registro = CriarCliente();
            repositorio.Inserir(registro);

            Cliente registro2 = repositorio.SelecionarPorID(registro.Id);

            Assert.AreEqual(registro2, registro);
        }

        [TestMethod]
        public void Deve_inserir_cliente()
        {

            Cliente cliente = CriarCliente();

            repositorio.Inserir(cliente);

            Cliente cliente2 = repositorio.SelecionarPorID(cliente.Id);

            Assert.AreEqual(cliente, cliente2);

        }

        [TestMethod]
        public void Deve_excluir_Cliente()
        {


            Cliente cliente = CriarCliente();

            repositorio.Inserir(cliente);

            repositorio.Excluir(cliente);

            Cliente cliente2 = repositorio.SelecionarPorID(cliente.Id);

            cliente2.Should().Be(null);

        }
        [TestMethod]
        public void Deve_selecionar_todos_cliente()
        {
            List<Cliente> registros = new List<Cliente>();

            for (int i = 0; i < 10; i++)
            {
                Cliente cliente = new Cliente("joao" + random.Next(100, 500).ToString(), "rua abrolingo filho", "12345678900", "joao@joao.com", "49989090909", true, "09876543211", "12340567889879"); 

                repositorio.Inserir(cliente);
                registros.Add(cliente);
            }

            List<Cliente> registrosDoBanco = repositorio.SelecionarTodos();

            for (int i = 0; i < registrosDoBanco.Count; i++)
            {
                Assert.AreEqual(registrosDoBanco[i], registros[i]);
            }


        }

        [TestMethod]
        public void Deve_editar_cliente()
        {


            Cliente cliente = CriarCliente();

            repositorio.Inserir(cliente);

            cliente.Nome = "ssssss";

            repositorio.Editar(cliente);

            Cliente cliente2 = repositorio.SelecionarPorID(cliente.Id);


            Assert.AreEqual(cliente2, cliente);

        }
        private Cliente CriarCliente()
        {
            return new Cliente("joao" + random.Next(100, 500).ToString(), "rua abrolingo filho", "12345678900", "joao@joao.com", "49989090909", true, "09876543211", "12340567889879");
        }
    }
}
