using FluentValidation.TestHelper;
using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LocadoraDeVeiculos.Dominio.Tests.ModuloTaxa
{
    [TestClass]
    public class TaxaTest
    {

    ValidadorTaxa validation;

        public TaxaTest()
        {
            validation = new();
        }

        [TestMethod]
        public void Nao_pode_nome_vazio()
        {
            Taxa taxa = new("des1", 500, true);
            taxa.Id = 1;
            taxa.Descricao = "";

            var resultado = validation.TestValidate(taxa);

            resultado.ShouldHaveValidationErrorFor(x => x.Descricao);
        }


        public void Nao_pode_nome_so_com_espaco()
        {
            Taxa taxa = new("des1", 500, true);
            taxa.Id = 1;
            taxa.Descricao = "   ";

            var resultado = validation.TestValidate(taxa);

            resultado.ShouldHaveValidationErrorFor(x => x.Descricao);
        }

        [TestMethod]
        public void Nao_pode_nome_com_menos_de_2_caracters()
        {
            Taxa taxa = new("des1",500, true);
            taxa.Id = 1;
            taxa.Descricao = "a";

            var resultado = validation.TestValidate(taxa);

            resultado.ShouldHaveValidationErrorFor(x => x.Descricao);
        }

        [TestMethod]
        public void Valor_Nao_pode_ser_nulo()
        {
            Taxa taxa = new("des1", 500, true);
            taxa.Id = 1;
            taxa.Valor = 0;

            var resultado = validation.TestValidate(taxa);

            resultado.ShouldHaveValidationErrorFor(x => x.Valor);
        }

        [TestMethod]
        public void nome_nao_poder_ter_caracters_especias()
        {
            Taxa taxa = new("des1", 500, true);
            taxa.Id = 1;
            taxa.Descricao = "!@#$%¨%¨&*()(";

            var resultado = validation.TestValidate(taxa);

            resultado.ShouldHaveValidationErrorFor(x => x.Descricao);
        }
    }
}
