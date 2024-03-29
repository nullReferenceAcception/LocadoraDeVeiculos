﻿using FluentAssertions;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Infra.BancoDados.Compartilhado;
using LocadoraDeVeiculos.Infra.BancoDados.Tests.ModuloCompartilhado;
using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloCliente;
using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloCondutor;
using LocadoraDeVeiculos.Infra.ORM.Compartilhado;
using LocadoraDeVeiculos.Infra.ORM.ModuloCliente;
using LocadoraDeVeiculos.Infra.ORM.ModuloCondutor;
using LocadoraDeVeiculos.Servico.ModuloCliente;
using LocadoraDeVeiculos.Servico.ModuloCondutor;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace LocadoraDeVeiculos.Infra.BancoDeDados.Tests.ModuloCondutor
{
    [TestClass]
    public class RepositorioCondutorEmBancoDeDados : BaseTestRepositorio
    {

        [TestMethod]
        public void Deve_inserir_Condutor()
        {
            Cliente cliente = CriarClienteComCPF();

            _servicoCliente.Inserir(cliente);
            
            Condutor condutor = CriarCondutor();

            condutor.Cliente = cliente;

            _servicoCondutor.Inserir(condutor);

            Condutor condutorEncontrado = _servicoCondutor.SelecionarPorGuid(condutor.Id).Value;

            Assert.AreEqual(condutor, condutorEncontrado);
        }

        [TestMethod]
        public void Deve_editar_Condutor()
        {
            Cliente cliente = CriarClienteComCPF();

            _servicoCliente.Inserir(cliente);

            Condutor condutor = CriarCondutor();

            condutor.Cliente = cliente;

            _servicoCondutor.Inserir(condutor);

            condutor.Nome = "ssssss";

            _servicoCondutor.Editar(condutor);

            Condutor condutorEncontrado = _servicoCondutor.SelecionarPorGuid(condutor.Id).Value;

            Assert.AreEqual(condutorEncontrado, condutor);
        }

        [TestMethod]
        public void Deve_excluir_Condutor()
        {
            Cliente cliente = CriarClienteComCPF();

            _servicoCliente.Inserir(cliente);

            Condutor condutor = CriarCondutor();

            condutor.Cliente = cliente;

            _servicoCondutor.Inserir(condutor);

            _servicoCondutor.Excluir(condutor);

            Condutor condutorEncontrado = _servicoCondutor.SelecionarPorGuid(condutor.Id).Value;

            condutorEncontrado.Should().Be(null);
        }

        [TestMethod]
        public void Deve_selecionar_todos_Condutor()
        {
            List<Condutor> registros = new List<Condutor>();

            Condutor condutor;

            Cliente cliente = CriarClienteComCPF();

            _servicoCliente.Inserir(cliente);

            for (int i = 0; i < 10; i++)
            {
                if (i <= 5)
                    condutor = new Condutor(GerarNovaStringAleatoria(), "rua amaral junior 657", "12345678901", "guimotorista@gmail.com", "49998765432", GerarCpfAleatorio(), DateTime.Today);
                else
                    condutor = new Condutor(GerarNovaStringAleatoria(), "rua juvenil 657", "12345678901", "guimotorista445@gmail.com", "49998789432", GerarCpfAleatorio(), DateTime.Today);
                
                condutor.Cliente = cliente;

                _servicoCondutor.Inserir(condutor);

                registros.Add(condutor);
            }

            List<Condutor> registrosDoBanco = _servicoCondutor.SelecionarTodos().Value;

            Assert.IsTrue(registrosDoBanco.Count == registros.Count);

            for (int i = 0; i < registrosDoBanco.Count; i++)
                Assert.IsTrue(registrosDoBanco.Contains(registros[i]));
        }

      

        [TestMethod]
        public void Deve_selecionar_por_id()
        {
            Cliente cliente = CriarClienteComCPF();

            _servicoCliente.Inserir(cliente);

            Condutor condutor = CriarCondutor();

            condutor.Cliente = cliente;

            _servicoCondutor.Inserir(condutor);

            Condutor condutorEncontrado = _servicoCondutor.SelecionarPorGuid(condutor.Id).Value;

            Assert.AreEqual(condutorEncontrado, condutor);
        }
    }
}
