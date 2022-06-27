using FluentValidation.TestHelper;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            Cliente cliente = new("joao", "rua abrolingo filho", "12345678900", "joao@joao.com", "(49)98909-0909", true, "09876543211", "1234567889879");
            cliente.Id = 1;
            cliente.Nome = " ";

            var resultado = validador.TestValidate(cliente);

            resultado.ShouldHaveValidationErrorFor(x => x.Nome);
        }

        [TestMethod]
        public void Nao_Deve_inserir_nome_vazio()
        {
            Cliente cliente = new("joao", "rua abrolingo filho", "12345678900", "joao@joao.com", "(49)98909-0909", true, "09876543211", "1234567889879");
            cliente.Id = 1;
            cliente.Nome = "";

            var resultado = validador.TestValidate(cliente);

            resultado.ShouldHaveValidationErrorFor(x => x.Nome);
        }

        [TestMethod]
        public void Nao_Deve_inserir_nome_com_menos_de_2_letra()
        {
            Cliente cliente = new("joao", "rua abrolingo filho", "12345678900", "joao@joao.com", "(49)98909-0909", true, "09876543211", "1234567889879");
            cliente.Id = 1;
            cliente.Nome = "jo";

            var resultado = validador.TestValidate(cliente);

            resultado.ShouldHaveValidationErrorFor(x => x.Nome);
        }

        [TestMethod]
        public void Nao_Deve_inserir_telefone_invalida()
        {
            Cliente cliente = new("joao", "rua abrolingo filho", "12345678900", "joao@joao.com", "(49)98909-0909", true, "09876543211", "1234567889879");
            cliente.Id = 1;
            cliente.Telefone = "000000000";

            var resultado = validador.TestValidate(cliente);

            resultado.ShouldHaveValidationErrorFor(x => x.Telefone);
        }
        [TestMethod]
        public void Nao_Deve_inserir_email_invalido()
        {
            Cliente cliente = new("joao", "rua abrolingo filho", "12345678900", "joao@joao.com", "(49)98909-0909", true, "09876543211", "1234567889879");
            cliente.Id = 1;
            cliente.Email = "lalala";

            var resultado = validador.TestValidate(cliente);

            resultado.ShouldHaveValidationErrorFor(x => x.Email);
        }
        [TestMethod]
        public void Nao_Deve_inserir_cpf_invalido()
        {
            Cliente cliente = new("joao", "rua abrolingo filho", "12345678900", "joao@joao.com", "(49)98909-0909", true, "09876543211", "1234567889879");
            cliente.Id = 1;
            cliente.CPF = "991";

            var resultado = validador.TestValidate(cliente);

            resultado.ShouldHaveValidationErrorFor(x => x.CPF);
        }

        [TestMethod]
        public void Nao_Deve_inserir_cnpj_invalido()
        {
            Cliente cliente = new("joao", "rua abrolingo filho", "12345678900", "joao@joao.com", "49989090909", false, "09876543211", "1234567889879");
            cliente.Id = 1;
            cliente.CNPJ = "111";

            var resultado = validador.TestValidate(cliente);

            resultado.ShouldHaveValidationErrorFor(x => x.CNPJ);
        }
    }
}
