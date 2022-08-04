using FluentValidation.TestHelper;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloLocacao;
using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.Tests.ModuloLocacao
{
    [TestClass]
    public class LocacaoTest
    {
        ValidadorLocacao validation = new();
        [TestMethod]
        public void Nao_pode_registrar_data_locacao_menor_que_data_de_hoje()
        {
            Locacao locacao = CriarLocacao();

            locacao.DataLocacao = DateTime.Today.AddDays(-8);

            var resultado = validation.TestValidate(locacao);

            resultado.ShouldHaveValidationErrorFor(x => x.DataLocacao);
        }
        [TestMethod]
        public void Nao_pode_registrar_data_devolucao_menor_que_data_de_amanha()
        {
            Locacao locacao = CriarLocacao();

            locacao.DataDevolucaoPrevista = DateTime.Today;

            var resultado = validation.TestValidate(locacao);

            resultado.ShouldHaveValidationErrorFor(x => x.DataDevolucaoPrevista);
        }

        private Locacao CriarLocacao()
        {
            List<Taxa> taxas = new List<Taxa> { CriarTaxa() };
            return new Locacao(CriarFuncionario(), CriarCliente(), CriarCondutor(), CriarVeiculoSemGrupo(), CriarPlanoCobranca(),DateTime.Today,new DateTime(2100,01,01), taxas,StatusEnum.Ativo);
        }


        #region Dependencias
        private Funcionario CriarFuncionario()
        {
            return new("nome", "senha", "endereco", "telefone", "login", "senha", DateTime.Now, 12, true, "Lages", true);
        }
        private Cliente CriarCliente()
        {
            return new Cliente("joao", "rua abrolingo filho", "joao@joao.com", "49989090909", true, "09876543211", "1234567889879");
        }
        private Condutor CriarCondutor()
        {
            return new Condutor("sdjkfhgsdjk", "rua amaral junior 657", "12345678901", "guimotorista@gmail.com", "49998765432", "111111111111", DateTime.Today);
        }
        private Veiculo CriarVeiculoSemGrupo()
        {
            byte[] array = { 0, 100, 120, 210, 255 };
            return new("Uno", "ABC1234", "Fiat", 1995, 29.5m, 200000, CorEnum.Azul, CombustivelEnum.Gasolina, array);
        }

        private PlanoCobranca CriarPlanoCobranca()
        {
            return new("nome", 100, 100, 0, PlanoEnum.KmLivre, new GrupoVeiculos("grupo"));
        }
        private Taxa CriarTaxa()
        {
            return new Taxa("des1", 500, true);
        }
        #endregion
    }
}