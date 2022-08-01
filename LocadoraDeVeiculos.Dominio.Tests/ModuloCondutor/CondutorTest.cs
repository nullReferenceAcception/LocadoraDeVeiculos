using FluentValidation.TestHelper;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LocadoraDeVeiculos.Dominio.Tests.ModuloCondutor
{
    [TestClass]
    public class CondutorTest
    {
        Random random = new();
        ValidadorCondutor validador;

        public CondutorTest()
        {
            validador = new();
        }

        [TestMethod]
        public void Nao_Deve_inserir_nome_apenas_com_espaco()
        {
            Condutor condutor = CriarCondutor();
            condutor.Nome = " ";

            var resultado = validador.TestValidate(condutor);

            resultado.ShouldHaveValidationErrorFor(x => x.Nome);
        }

        [TestMethod]
        public void Nao_Deve_inserir_nome_vazio()
        {
            Condutor Condutor = CriarCondutor();
            Condutor.Nome = "";

            var resultado = validador.TestValidate(Condutor);

            resultado.ShouldHaveValidationErrorFor(x => x.Nome);
        }

        [TestMethod]
        public void Nao_Deve_inserir_nome_com_menos_de_2_letra()
        {
            Condutor Condutor = CriarCondutor();
            Condutor.Nome = "jo";

            var resultado = validador.TestValidate(Condutor);

            resultado.ShouldHaveValidationErrorFor(x => x.Nome);
        }

        [TestMethod]
        public void Nao_Deve_inserir_telefone_invalida()
        {
            Condutor Condutor = CriarCondutor();
            Condutor.Telefone = "000000000";

            var resultado = validador.TestValidate(Condutor);

            resultado.ShouldHaveValidationErrorFor(x => x.Telefone);
        }

        [TestMethod]
        public void Nao_Deve_inserir_email_invalido()
        {
            Condutor Condutor = CriarCondutor();
            Condutor.Email = "lalala";

            var resultado = validador.TestValidate(Condutor);

            resultado.ShouldHaveValidationErrorFor(x => x.Email);
        }

        [TestMethod]
        public void Nao_Deve_inserir_cpf_invalido()
        {
            Condutor Condutor = CriarCondutor();
            Condutor.CPF = "991";

            var resultado = validador.TestValidate(Condutor);

            resultado.ShouldHaveValidationErrorFor(x => x.CPF);
        }

        private Condutor CriarCondutor()
        {
            return new Condutor(GerarNovoNome(), "rua amaral junior 657", "12345678901", "guimotorista@gmail.com", "49998765432", "111111111111", DateTime.Today);
        }

        private string GerarNovoNome()
        {
            const int qtdeLetras = 4;

            const string letras = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string novoNome = "";
            Random random = new();

            for (int i = 0; i < qtdeLetras; i++)
                novoNome += letras[random.Next(letras.Length)];

            return novoNome;
        }
    }
}
