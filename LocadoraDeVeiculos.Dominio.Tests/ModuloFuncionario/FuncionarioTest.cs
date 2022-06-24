using FluentValidation.TestHelper;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.Tests.ModuloFuncionario
{
    [TestClass]
    public class FuncionarioTest
    {
        ValidadorFuncionario validation;

        public FuncionarioTest()
        {
            validation = new();
        }


        [TestMethod]
        public void Nao_pode_nome_vazio()
        {
          
            Funcionario funcionario = CriarFuncionario();
            funcionario.Id = 1;
            funcionario.Nome = "";


            var resultado = validation.TestValidate(funcionario);

            resultado.ShouldHaveValidationErrorFor(x => x.Nome);

        }

        private static Funcionario CriarFuncionario()
        {
            return new("nome","senha","endereco","telefone","login", "senha", DateTime.Now, 12, true);
        }

        public void Nao_pode_nome_so_com_espaco()
        {


            Funcionario Funcionario = CriarFuncionario();
            Funcionario.Id = 1;
            Funcionario.Nome = "   ";


            var resultado = validation.TestValidate(Funcionario);

            resultado.ShouldHaveValidationErrorFor(x => x.Nome);

        }


        [TestMethod]
        public void Nao_pode_nome_com_menos_de_2_caracters()
        {


            Funcionario Funcionario = CriarFuncionario();
            Funcionario.Id = 1;
            Funcionario.Nome = "a";

            var resultado = validation.TestValidate(Funcionario);

            resultado.ShouldHaveValidationErrorFor(x => x.Nome);

        }

        [TestMethod]
        public void nome_nao_poder_ter_caracters_especias()
        {


            Funcionario Funcionario = CriarFuncionario();
            Funcionario.Id = 1;
            Funcionario.Nome = "!@#$%¨%¨&*()(";

            var resultado = validation.TestValidate(Funcionario);

            resultado.ShouldHaveValidationErrorFor(x => x.Nome);

        }

    }
}
