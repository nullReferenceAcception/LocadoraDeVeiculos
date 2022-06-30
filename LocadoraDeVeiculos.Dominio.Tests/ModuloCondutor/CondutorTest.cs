using FluentValidation.TestHelper;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.Tests.ModuloCondutor
{
    [TestClass]
    public class CondutorTest
    {
        Random random = new Random();
        ValidadorCondutor validador;

        public CondutorTest()
        {
            validador = new();
        }
        [TestMethod]
        public void Nao_Deve_inserir_nome_apenas_com_espaco()
        {
            Condutor condutor = CriarCondutor();
            condutor.Id = 1;
            condutor.Nome = " ";

            var resultado = validador.TestValidate(condutor);

            resultado.ShouldHaveValidationErrorFor(x => x.Nome);
        }
        [TestMethod]
        public void Nao_Deve_inserir_nome_vazio()
        {
            Condutor Condutor = CriarCondutor();
            Condutor.Id = 1;
            Condutor.Nome = "";

            var resultado = validador.TestValidate(Condutor);

            resultado.ShouldHaveValidationErrorFor(x => x.Nome);
        }

        [TestMethod]
        public void Nao_Deve_inserir_nome_com_menos_de_2_letra()
        {
            Condutor Condutor = CriarCondutor();
            Condutor.Id = 1;
            Condutor.Nome = "jo";

            var resultado = validador.TestValidate(Condutor);

            resultado.ShouldHaveValidationErrorFor(x => x.Nome);
        }

        [TestMethod]
        public void Nao_Deve_inserir_telefone_invalida()
        {
            Condutor Condutor = CriarCondutor();
            Condutor.Id = 1;
            Condutor.Telefone = "000000000";

            var resultado = validador.TestValidate(Condutor);

            resultado.ShouldHaveValidationErrorFor(x => x.Telefone);
        }
        [TestMethod]
        public void Nao_Deve_inserir_email_invalido()
        {
            Condutor Condutor = CriarCondutor();
            Condutor.Id = 1;
            Condutor.Email = "lalala";

            var resultado = validador.TestValidate(Condutor);

            resultado.ShouldHaveValidationErrorFor(x => x.Email);
        }
        [TestMethod]
        public void Nao_Deve_inserir_cpf_invalido()
        {
            Condutor Condutor = CriarCondutor();
            Condutor.Id = 1;
            Condutor.CPF = "991";

            var resultado = validador.TestValidate(Condutor);

            resultado.ShouldHaveValidationErrorFor(x => x.CPF);
        }
        private Condutor CriarCondutor()
        {
            return new Condutor("guilherme" + random.Next(100, 500).ToString(), "rua amaral junior 657", "12345678901", "guimotorista@gmail.com", "49998765432", "111111111111", DateTime.Today);
        }
    }
}
