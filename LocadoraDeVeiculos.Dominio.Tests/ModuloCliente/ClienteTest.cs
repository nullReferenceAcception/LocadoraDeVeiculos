using FluentValidation.TestHelper;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LocadoraDeVeiculos.Dominio.Tests.ModuloCliente
{
    [TestClass]
    public class ClienteTest
    {
        ValidadorCliente validador;

        public ClienteTest()
        {
            validador = new();
        }

        [TestMethod]
        public void Nao_Deve_inserir_nome_apenas_com_espaco()
        {
            Cliente cliente = CriarCliente();
            cliente.Nome = " ";

            var resultado = validador.TestValidate(cliente);

            resultado.ShouldHaveValidationErrorFor(x => x.Nome);
        }

        [TestMethod]
        public void Nao_Deve_inserir_nome_vazio()
        {
            Cliente cliente = CriarCliente();
            cliente.Nome = "";

            var resultado = validador.TestValidate(cliente);

            resultado.ShouldHaveValidationErrorFor(x => x.Nome);
        }

        [TestMethod]
        public void Nao_Deve_inserir_nome_com_menos_de_2_letra()
        {
            Cliente cliente = CriarCliente();
            cliente.Nome = "jo";

            var resultado = validador.TestValidate(cliente);

            resultado.ShouldHaveValidationErrorFor(x => x.Nome);
        }

        [TestMethod]
        public void Nao_Deve_inserir_telefone_invalida()
        {
            Cliente cliente = CriarCliente();
            cliente.Telefone = "000000000";

            var resultado = validador.TestValidate(cliente);

            resultado.ShouldHaveValidationErrorFor(x => x.Telefone);
        }

        [TestMethod]
        public void Nao_Deve_inserir_email_invalido()
        {
            Cliente cliente = CriarCliente();
            cliente.Email = "lalala";

            var resultado = validador.TestValidate(cliente);

            resultado.ShouldHaveValidationErrorFor(x => x.Email);
        }

        [TestMethod]
        public void Nao_Deve_inserir_cpf_invalido()
        {
            Cliente cliente = CriarCliente();
            cliente.CPF = "991";

            var resultado = validador.TestValidate(cliente);

            resultado.ShouldHaveValidationErrorFor(x => x.CPF);
        }

        [TestMethod]
        public void Nao_Deve_inserir_cnpj_invalido()
        {
            Cliente cliente = CriarCliente();
            cliente.PessoaFisica = false;
            cliente.CPF = null;
            cliente.CNPJ = "111";

            var resultado = validador.TestValidate(cliente);

            resultado.ShouldHaveValidationErrorFor(x => x.CNPJ);
        }

       

        private Cliente CriarCliente()
        {
            return new Cliente("joao", "rua abrolingo filho", "joao@joao.com", "49989090909", true, "09876543211", "1234567889879");
        }
    }
}
