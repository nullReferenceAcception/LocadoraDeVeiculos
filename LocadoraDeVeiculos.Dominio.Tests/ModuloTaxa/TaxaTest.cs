using FluentAssertions;
using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


            Taxa taxa = new("des1", 500);
            taxa.Id = 1;
            taxa.Descricao = "";

            var x = validation.Validate(taxa);

            x.Errors[0].ErrorMessage.Should().Contain("Descricao");

        }


        public void Nao_pode_nome_so_com_espaco()
        {


            Taxa taxa = new("des1", 500);
            taxa.Id = 1;
            taxa.Descricao = "   ";

            var x = validation.Validate(taxa);

            x.Errors[0].ErrorMessage.Should().Contain("Descricao");

        }


        [TestMethod]
        public void Nao_pode_nome_com_menos_de_2_caracters()
        {
            

            Taxa taxa = new("des1",500);
            taxa.Id = 1;
            taxa.Descricao = "a";

           var x = validation.Validate(taxa);

            x.Errors[0].ErrorMessage.Should().Contain("Descricao");

        }

        [TestMethod]
        public void Valor_Nao_pode_ser_nulo()
        {


            Taxa taxa = new("des1", 500);
            taxa.Id = 1;
            taxa.Valor = 0;

            var x = validation.Validate(taxa);

            x.Errors[0].ErrorMessage.Should().Contain("Valor");

        }

        [TestMethod]
        public void nome_nao_poder_ter_caracters_especias()
        {


            Taxa taxa = new("des1", 500);
            taxa.Id = 1;
            taxa.Descricao = "!@#$%¨%¨&*()(";

            var x = validation.Validate(taxa);

            x.Errors[0].ErrorMessage.Should().Contain("Descricao");

        }

    }
}
