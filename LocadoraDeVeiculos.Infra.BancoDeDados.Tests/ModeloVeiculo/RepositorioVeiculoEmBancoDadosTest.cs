using LocadoraDeVeiculos.Infra.BancoDados.Tests.ModuloCompartilhado;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using System;
using System.Collections.Generic;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloVeiculo;
using LocadoraDeVeiculos.Servico.ModuloVeiculos;
using LocadoraDeVeiculos.Servico.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;

namespace LocadoraDeVeiculos.Infra.BancoDeDados.Tests.ModeloVeiculo
{
    [TestClass]
    public class RepositorioVeiculoEmBancoDadosTest : BaseTestRepositorio
    {
        ServicoVeiculo _servicoVeiculo = new(new RepositorioVeiculo());
        ServicoGrupoVeiculos _servicoGrupoVeiculo = new(new RepositorioGrupoVeiculos());

        [TestMethod]
        public void Deve_inserir_veiculo()
        {
            GrupoVeiculos grupo = CriarGrupoDeVeiculos();

            _servicoGrupoVeiculo.Inserir(grupo);

            Veiculo veiculo = CriarVeiculoSemGrupo();

            veiculo.GrupoVeiculos = grupo;

            _servicoVeiculo.Inserir(veiculo);

            var veiculoEncontrado = _servicoVeiculo.SelecionarPorID(veiculo.Id);

            veiculoEncontrado.Should().Be(veiculo);
        }

        [TestMethod]
        public void Deve_editar_veiculo()
        {
            GrupoVeiculos grupo = CriarGrupoDeVeiculos();

            _servicoGrupoVeiculo.Inserir(grupo);

            Veiculo veiculo = CriarVeiculoSemGrupo();

            veiculo.GrupoVeiculos = grupo;

            _servicoVeiculo.Inserir(veiculo);

            veiculo.Ano = 2020;
            veiculo.Modelo = "Siena";
            veiculo.Cor = CorEnum.Cinza;
            veiculo.Combustivel = CombustivelEnum.GNV;

            _servicoVeiculo.Editar(veiculo);

            var veiculoEncontrado = _servicoVeiculo.SelecionarPorID(veiculo.Id);

            veiculoEncontrado.Should().Be(veiculo);
        }

        [TestMethod]
        public void Deve_excluir_veiculo()
        {
            GrupoVeiculos grupo = CriarGrupoDeVeiculos();

            _servicoGrupoVeiculo.Inserir(grupo);

            Veiculo veiculo = CriarVeiculoSemGrupo();

            veiculo.GrupoVeiculos = grupo;

            _servicoVeiculo.Inserir(veiculo);

            _servicoVeiculo.Excluir(veiculo);

            var veiculoEncontrado = _servicoVeiculo.SelecionarPorID(veiculo.Id);

            veiculoEncontrado.Should().BeNull();
        }

        [TestMethod]
        public void Deve_selecionar_todos_veiculos()
        {
            GrupoVeiculos grupo = CriarGrupoDeVeiculos();

            _servicoGrupoVeiculo.Inserir(grupo);

            Veiculo veiculo = CriarVeiculoSemGrupo();

            veiculo.GrupoVeiculos = grupo;

            int quantidade = 3;

            for (int i = 0; i < quantidade; i++)
            {
                veiculo.Placa = GerarNovaPlaca();
                _servicoVeiculo.Inserir(veiculo);
            }

            List<Veiculo> veiculosEncontrados = _servicoVeiculo.SelecionarTodos();

            veiculosEncontrados.Count.Should().Be(quantidade);
        }

        [TestMethod]
        public void Deve_selecionar_veiculo_por_id()
        {
            GrupoVeiculos grupo = CriarGrupoDeVeiculos();

            _servicoGrupoVeiculo.Inserir(grupo);

            Veiculo veiculo = CriarVeiculoSemGrupo();

            veiculo.GrupoVeiculos = grupo;

            _servicoVeiculo.Inserir(veiculo);

            var veiculoEncontrado = _servicoVeiculo.SelecionarPorID(veiculo.Id);

            veiculoEncontrado.Should().Be(veiculo);
        }

        //TODO: Verificar duplicidade de placas
        [TestMethod]
        public void Nao_deve_inserir_placa_duplicada()
        {
            GrupoVeiculos grupo = CriarGrupoDeVeiculos();

            _servicoGrupoVeiculo.Inserir(grupo);

            Veiculo veiculo = CriarVeiculoSemGrupo();

            veiculo.GrupoVeiculos = grupo;

            _servicoVeiculo.Inserir(veiculo);

            veiculo.Id = 2;
            var resultado = _servicoVeiculo.Inserir(veiculo);

            resultado.ToString().Should().Be("Placa já cadastrada");
        }

        private Veiculo CriarVeiculoSemGrupo()
        {
            byte[] array = { 0, 100, 120, 210, 255 };
            return new("Uno", GerarNovaPlaca(), "Fiat", 2005, 29.50m, 200000.00m, CorEnum.Azul, CombustivelEnum.Gasolina, array);
        }

        private GrupoVeiculos CriarGrupoDeVeiculos()
        {
            return new("Teste");
        }

        private string GerarNovaPlaca()
        {
            const int qtdeNumeros = 3;
            const int qtdeLetras = 4;

            const string letras = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string numeros = "0123456789";
            string novaPlaca = "";
            Random random = new();

            for (int i = 0; i < qtdeNumeros; i++)
                novaPlaca += letras[random.Next(letras.Length)];

            for (int i = 0; i < qtdeLetras; i++)
                novaPlaca += numeros[random.Next(numeros.Length)];

            return novaPlaca;
        }
    }
}
