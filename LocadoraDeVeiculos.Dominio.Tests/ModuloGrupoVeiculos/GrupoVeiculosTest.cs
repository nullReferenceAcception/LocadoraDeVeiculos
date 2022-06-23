using FluentValidation.TestHelper;
using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.Tests.ModuloGrupoVeiculos
{
    [TestClass]
    public class GrupoVeiculosTest
    {

        ValidadorGrupoVeiculos validation;

        public GrupoVeiculosTest()
        {
            validation = new();
        }


        [TestMethod]
        public void Nao_pode_nome_vazio()
        {


            GrupoVeiculos grupoVeiculos = new("");
            grupoVeiculos.Id = 1;


            var resultado = validation.TestValidate(grupoVeiculos);

            resultado.ShouldHaveValidationErrorFor(x => x.Nome);

        }


        public void Nao_pode_nome_so_com_espaco()
        {


            GrupoVeiculos GrupoVeiculos = new("des1");
            GrupoVeiculos.Id = 1;
            GrupoVeiculos.Nome = "   ";


            var resultado = validation.TestValidate(GrupoVeiculos);

            resultado.ShouldHaveValidationErrorFor(x => x.Nome);

        }


        [TestMethod]
        public void Nao_pode_nome_com_menos_de_2_caracters()
        {


            GrupoVeiculos GrupoVeiculos = new("des1");
            GrupoVeiculos.Id = 1;
            GrupoVeiculos.Nome = "a";

            var resultado = validation.TestValidate(GrupoVeiculos);

            resultado.ShouldHaveValidationErrorFor(x => x.Nome);

        }

        [TestMethod]
        public void nome_nao_poder_ter_caracters_especias()
        {


            GrupoVeiculos GrupoVeiculos = new("des1");
            GrupoVeiculos.Id = 1;
            GrupoVeiculos.Nome = "!@#$%¨%¨&*()(";

            var resultado = validation.TestValidate(GrupoVeiculos);



            resultado.ShouldHaveValidationErrorFor(x => x.Nome);

        }

    }
}
