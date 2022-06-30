using FluentAssertions;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Infra.BancoDados.Tests.ModuloCompartilhado;
using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloCliente;
using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloCondutor;
using LocadoraDeVeiculos.Servico.ModuloCliente;
using LocadoraDeVeiculos.Servico.ModuloCondutor;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.BancoDeDados.Tests.ModuloCondutor
{
    [TestClass]
    public class RepositorioCondutorEmBancoDeDados : BaseTestRepositorio
    {
        Random random = new Random();
        ValidadorCondutor validador;
        ServicoCondutor servico = new(new RepositorioCondutor());
        ServicoCliente servicoCliente = new(new RepositorioCliente());

        public RepositorioCondutorEmBancoDeDados()
        {
            validador = new();
        }
        [TestMethod]
        public void Deve_selecionar_por_id()
        {
            Cliente cliente = CriarCliente();

            servicoCliente.Inserir(cliente);
            
            Condutor registro = CriarCondutor();

            registro.Cliente = cliente;

            servico.Inserir(registro);

            Condutor registro2 = servico.SelecionarPorID(registro.Id);

            Assert.AreEqual(registro2, registro);
        }

        [TestMethod]
        public void Deve_inserir_Condutor()
        {
            Cliente cliente = CriarCliente();

            servicoCliente.Inserir(cliente);
            
            Condutor condutor = CriarCondutor();

            condutor.Cliente = cliente;

            servico.Inserir(condutor);

            Condutor Condutor2 = servico.SelecionarPorID(condutor.Id);

            Assert.AreEqual(condutor, Condutor2);
        }

        

        [TestMethod]
        public void Deve_excluir_Condutor()
        {
            Cliente cliente = CriarCliente();

            servicoCliente.Inserir(cliente);

            Condutor condutor = CriarCondutor();

            condutor.Cliente = cliente;

            servico.Inserir(condutor);

            servico.Excluir(condutor);

            Condutor Condutor2 = servico.SelecionarPorID(condutor.Id);

            Condutor2.Should().Be(null);
        }
        [TestMethod]
        public void Deve_selecionar_todos_Condutor()
        {
            List<Condutor> registros = new List<Condutor>();

            Condutor condutor;

            Cliente cliente = CriarCliente();

            servicoCliente.Inserir(cliente);

            for (int i = 0; i < 10; i++)
            {
                if (i <= 5)
                    condutor = new Condutor("guilherme" + random.Next(100, 500).ToString(), "rua amaral junior 657", "12345678901", "guimotorista@gmail.com", "49998765432", "11111111111", DateTime.Today);
                else
                    condutor = new Condutor("guilherme" + random.Next(100, 500).ToString(), "rua juvenil 657", "12345678901", "guimotorista445@gmail.com", "49998789432", "11001111111", DateTime.Today);
                condutor.Cliente = cliente;

                servico.Inserir(condutor);

                registros.Add(condutor);
            }

            List<Condutor> registrosDoBanco = servico.SelecionarTodos();

            for (int i = 0; i < registrosDoBanco.Count; i++)
                Assert.AreEqual(registrosDoBanco[i], registros[i]);
        }

        [TestMethod]
        public void Deve_editar_Condutor()
        {
            Cliente cliente = CriarCliente();

            servicoCliente.Inserir(cliente);

            Condutor condutor = CriarCondutor();

            condutor.Cliente = cliente;

            servico.Inserir(condutor);

            condutor.Nome = "ssssss";

            servico.Editar(condutor);

            Condutor condutor2 = servico.SelecionarPorID(condutor.Id);

            Assert.AreEqual(condutor2, condutor);
        }


        private Condutor CriarCondutor()
        {
            
            return new Condutor("guilherme" + random.Next(100, 500).ToString(), "rua amaral junior 657", "12345678901", "guimotorista@gmail.com", "49998765432", "11111111111", DateTime.Today);
        }
        private Cliente CriarCliente()
        {
            
            return   new Cliente("joao" + random.Next(100, 500).ToString(), "rua abrolingo filho", "12345678900", "joao@joao.com", "49989090909", false, null!, "12340567123889");
            
    
        }
    }
}
