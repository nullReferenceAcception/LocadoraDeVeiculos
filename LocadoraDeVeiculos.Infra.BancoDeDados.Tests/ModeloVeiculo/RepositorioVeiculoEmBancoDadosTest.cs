using FluentAssertions;
using FluentResults;
using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using LocadoraDeVeiculos.Infra.BancoDados.Tests.ModuloCompartilhado;
using LocadoraDeVeiculos.Infra.ORM.ModuloGrupoVeiculo;
using LocadoraDeVeiculos.Infra.ORM.ModuloVeiculo;
using LocadoraDeVeiculos.Servico.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Servico.ModuloVeiculos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace LocadoraDeVeiculos.Infra.BancoDeDados.Tests.ModeloVeiculo
{
    [TestClass]
    public class RepositorioVeiculoEmBancoDadosTest : BaseTestRepositorio
    {

        [TestMethod]
        public void Deve_inserir_veiculo()
        {
            GrupoVeiculos grupo = CriarGrupoDeVeiculos();

            _servicoGrupoVeiculos.Inserir(grupo);

            Veiculo veiculo = CriarVeiculo();

            veiculo.GrupoVeiculos = grupo;

            _servicoVeiculo.Inserir(veiculo);

            Result<Veiculo> result = _servicoVeiculo.SelecionarPorGuid(veiculo.Id);

            result.Value.Should().Be(veiculo);
            result.Errors.Count.Should().Be(0);
            result.IsSuccess.Should().BeTrue();
        }

        [TestMethod]
        public void Deve_editar_veiculo()
        {
            GrupoVeiculos grupo = CriarGrupoDeVeiculos();

            _servicoGrupoVeiculos.Inserir(grupo);

            Veiculo veiculo = CriarVeiculo();

            veiculo.GrupoVeiculos = grupo;

            _servicoVeiculo.Inserir(veiculo);

            veiculo.Ano = 2020;
            veiculo.Modelo = "Siena";
            veiculo.Cor = CorEnum.Cinza;
            veiculo.Combustivel = CombustivelEnum.GNV;

            _servicoVeiculo.Editar(veiculo);

            var veiculoEncontrado = _servicoVeiculo.SelecionarPorGuid(veiculo.Id);

            veiculoEncontrado.Value.Should().Be(veiculo);
        }

        [TestMethod]
        public void Deve_excluir_veiculo()
        {
            GrupoVeiculos grupo = CriarGrupoDeVeiculos();

            _servicoGrupoVeiculos.Inserir(grupo);

            Veiculo veiculo = CriarVeiculo();

            veiculo.GrupoVeiculos = grupo;

            _servicoVeiculo.Inserir(veiculo);

            _servicoVeiculo.Excluir(veiculo);

            var veiculoEncontrado = _servicoVeiculo.SelecionarPorGuid(veiculo.Id);

            veiculoEncontrado.Value.Should().BeNull();
        }

        [TestMethod]
        public void Deve_selecionar_todos_veiculos()
        {
            GrupoVeiculos grupo = CriarGrupoDeVeiculos();

            _servicoGrupoVeiculos.Inserir(grupo);

            Veiculo veiculo = CriarVeiculo();

            veiculo.GrupoVeiculos = grupo;

            int quantidade = 3;

            List<Veiculo> veiculos = new();

            for (int i = 0; i < quantidade; i++)
            {
                veiculo.Placa = GerarNovaPlaca();
                _servicoVeiculo.Inserir(veiculo);
                veiculos.Add(veiculo);
            }

            List<Veiculo> veiculosEncontrados = _servicoVeiculo.SelecionarTodos().Value;

            Assert.IsTrue(veiculosEncontrados.Count == quantidade);

            for (int i = 0; i < quantidade; i++)
                Assert.IsTrue(veiculosEncontrados.Contains(veiculos[i]));
        }

        [TestMethod]
        public void Deve_selecionar_veiculo_por_guid()
        {
            GrupoVeiculos grupo = CriarGrupoDeVeiculos();

            _servicoGrupoVeiculos.Inserir(grupo);

            Veiculo veiculo = CriarVeiculo();

            veiculo.GrupoVeiculos = grupo;

            _servicoVeiculo.Inserir(veiculo);

            var veiculoEncontrado = _servicoVeiculo.SelecionarPorGuid(veiculo.Id);

            veiculoEncontrado.Value.Should().Be(veiculo);
        }

        [TestMethod]
        public void Nao_deve_inserir_placa_duplicada()
        {
            GrupoVeiculos grupo = CriarGrupoDeVeiculos();

            _servicoGrupoVeiculos.Inserir(grupo);

            Veiculo veiculo = CriarVeiculo();

            veiculo.GrupoVeiculos = grupo;

            _servicoVeiculo.Inserir(veiculo);

            veiculo.Id = new Guid();

            Result<Veiculo> resultado = _servicoVeiculo.Inserir(veiculo);

            resultado.IsFailed.Should().BeTrue();
            resultado.Errors[0].Message.Should().Contain("Placa já cadastrada");
        }

        private GrupoVeiculos CriarGrupoDeVeiculos()
        {
            return new("Teste");
        }
    }
}
