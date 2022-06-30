using FluentValidation.TestHelper;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LocadoraDeVeiculos.Dominio.Tests.ModuloVeiculo
{
    [TestClass]
    public class VeiculoTest
    {
        ValidadorVeiculo validador;

        public VeiculoTest()
        {
            validador = new();
        }

        [TestMethod]
        public void Nao_pode_modelo_vazio()
        {
            Veiculo veiculo = CriarVeiculoSemGrupo();

            veiculo.Modelo = "";

            var resultado = validador.TestValidate(veiculo);

            resultado.ShouldHaveValidationErrorFor(x => x.Modelo);
        }

        [TestMethod]
        public void Nao_pode_placa_vazia()
        {
            Veiculo veiculo = CriarVeiculoSemGrupo();

            veiculo.Placa = "";

            var resultado = validador.TestValidate(veiculo);

            resultado.ShouldHaveValidationErrorFor(x => x.Placa);
        }

        [TestMethod]
        public void Nao_pode_marca_vazia()
        {
            Veiculo veiculo = CriarVeiculoSemGrupo();

            veiculo.Marca = "";

            var resultado = validador.TestValidate(veiculo);

            resultado.ShouldHaveValidationErrorFor(x => x.Marca);
        }

        [TestMethod]
        public void Nao_pode_cor_vazia()
        {
            Veiculo veiculo = CriarVeiculoSemGrupo();

            veiculo.Cor = null;

            var resultado = validador.TestValidate(veiculo);

            resultado.ShouldHaveValidationErrorFor(x => x.Cor);
        }

        [TestMethod]
        public void Nao_pode_ano_abaixo_2000()
        {
            Veiculo veiculo = CriarVeiculoSemGrupo();

            veiculo.Ano = 1999;

            var resultado = validador.TestValidate(veiculo);

            resultado.ShouldHaveValidationErrorFor(x => x.Ano);
        }

        [TestMethod]
        public void Nao_pode_tanque_zerado()
        {
            Veiculo veiculo = CriarVeiculoSemGrupo();

            veiculo.CapacidadeTanque = 0;

            var resultado = validador.TestValidate(veiculo);

            resultado.ShouldHaveValidationErrorFor(x => x.CapacidadeTanque);
        }

        [TestMethod]
        public void Nao_pode_km_zerado()
        {
            Veiculo veiculo = CriarVeiculoSemGrupo();

            veiculo.KmPercorrido = 0;

            var resultado = validador.TestValidate(veiculo);

            resultado.ShouldHaveValidationErrorFor(x => x.KmPercorrido);
        }

        [TestMethod]
        public void Nao_pode_foto_nula()
        {
            Veiculo veiculo = CriarVeiculoSemGrupo();

            veiculo.Foto = null;

            var resultado = validador.TestValidate(veiculo);

            resultado.ShouldHaveValidationErrorFor(x => x.Foto);
        }

        [TestMethod]
        public void Nao_pode_combustivel_nulo()
        {
            Veiculo veiculo = CriarVeiculoSemGrupo();

            veiculo.Combustivel = null;

            var resultado = validador.TestValidate(veiculo);

            resultado.ShouldHaveValidationErrorFor(x => x.Combustivel);
        }

        [TestMethod]
        public void Nao_pode_grupo_de_veiculos_nulo()
        {
            Veiculo veiculo = CriarVeiculoSemGrupo();

            var resultado = validador.TestValidate(veiculo);

            resultado.ShouldHaveValidationErrorFor(x => x.GrupoVeiculos);
        }

        private Veiculo CriarVeiculoSemGrupo()
        {
            byte[] array = { 0, 100, 120, 210, 255 };
            return new("Uno", "ABC1234", "Fiat", 1995, 29.5m, 200000, CorEnum.Azul, CombustivelEnum.Gasolina, array);
        }
    }
}
