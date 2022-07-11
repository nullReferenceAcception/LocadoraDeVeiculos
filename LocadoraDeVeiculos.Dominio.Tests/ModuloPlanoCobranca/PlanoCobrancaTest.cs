using FluentValidation.TestHelper;
using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LocadoraDeVeiculos.Dominio.Tests.ModuloPlanoCobranca
{
    public class PlanoCobrancaTest
    {
        ValidadorPlanoCobranca validation;

        public PlanoCobrancaTest()
        {
            validation = new();
        }

        [TestMethod]
        public void Nao_pode_nome_vazio()
        {
            PlanoCobranca PlanoCobranca = new("nome",100,100,0,PlanoEnum.KmLivre,new GrupoVeiculos("grupo"));
            PlanoCobranca.Nome = "";

            var resultado = validation.TestValidate(PlanoCobranca);

            resultado.ShouldHaveValidationErrorFor(x => x.Nome);
        }

        public void Nao_pode_nome_so_com_espaco()
        {
            PlanoCobranca PlanoCobranca = new("nome", 100, 100, 0, PlanoEnum.KmLivre, new GrupoVeiculos("grupo"));
            PlanoCobranca.Nome = "   ";

            var resultado = validation.TestValidate(PlanoCobranca);

            resultado.ShouldHaveValidationErrorFor(x => x.Nome);
        }

        [TestMethod]
        public void Nao_pode_nome_com_menos_de_2_caracters()
        {
            PlanoCobranca PlanoCobranca = new("nome", 100, 100, 0, PlanoEnum.KmLivre, new GrupoVeiculos("grupo"));
            PlanoCobranca.Nome = "a";

            var resultado = validation.TestValidate(PlanoCobranca);

            resultado.ShouldHaveValidationErrorFor(x => x.Nome);
        }

        [TestMethod]
        public void nome_nao_poder_ter_caracters_especias()
        {
            PlanoCobranca PlanoCobranca = new("nome", 100, 100, 0, PlanoEnum.KmLivre, new GrupoVeiculos("grupo"));
            PlanoCobranca.Nome = "!@#$%¨%¨&*()(";

            var resultado = validation.TestValidate(PlanoCobranca);

            resultado.ShouldHaveValidationErrorFor(x => x.Nome);
        }
    }
}
