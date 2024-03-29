﻿using FluentResults;
using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloVeiculo
{
    public class ControladorVeiculo : ControladorBase
    {
        private IServicoVeiculo _servicoVeiculo;
        private IServicoGrupoVeiculos servicoGrupoVeiculos;
        private TabelaVeiculoControl _tabelaVeiculos;

        public ControladorVeiculo(IServicoVeiculo servVeiculo, IServicoGrupoVeiculos servGrupo)
        {
            this._servicoVeiculo = servVeiculo;
            this.servicoGrupoVeiculos = servGrupo;
        }

        public override void Inserir()
        {
            if (servicoGrupoVeiculos.QuantidadeRegistro().Value == 0)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape($"Cadastre no mínimo 1 'Grupo de Veículos' para cadastrar um veículo",CorParaRodape.Yellow);
                return;
            }

            TelaCadastroVeiculoForm tela = new(servicoGrupoVeiculos);

            tela.Veiculo = new();

            tela.GravarRegistro = _servicoVeiculo.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarVeiculos();
        }

        public override void Editar()
        {
            var numero = _tabelaVeiculos.ObtemGuidVeiculoSelecionado();

            var veiculoSelecionado = _servicoVeiculo.SelecionarPorGuid(numero);

            if (veiculoSelecionado == null)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape($"Selecione um veículo para editar", CorParaRodape.Yellow);
                return;
            }

            TelaCadastroVeiculoForm tela = new(servicoGrupoVeiculos);

            tela.Veiculo = veiculoSelecionado.Value;

            tela.GravarRegistro = _servicoVeiculo.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarVeiculos();
        }

        public override void Excluir()
        {
            var numero = _tabelaVeiculos.ObtemGuidVeiculoSelecionado();

            Veiculo veiculoSelecionado = _servicoVeiculo.SelecionarPorGuid(numero).Value;

            if (veiculoSelecionado == null)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape($"Selecione um veículo para excluir", CorParaRodape.Yellow);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir o Veículo?",
               "Exclusão de Veículo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            Result validationResult;

            if (resultado == DialogResult.OK)
            {
                validationResult = _servicoVeiculo.Excluir(veiculoSelecionado);
                CarregarVeiculos();

                if (validationResult.Errors.Count > 0)
                    TelaPrincipalForm.Instancia.AtualizarRodape(validationResult.Errors[0].Message, CorParaRodape.Red);
            }
        }

        public override void Visualizar()
        {
            var numero = _tabelaVeiculos.ObtemGuidVeiculoSelecionado();

            Veiculo veiculoSelecionado = _servicoVeiculo.SelecionarPorGuid(numero).Value;

            if (veiculoSelecionado == null)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape($"Selecione um veículo para visualizar", CorParaRodape.Yellow);
                return;
            }

            TelaCadastroVeiculoForm tela = new(servicoGrupoVeiculos);

            tela.Veiculo = veiculoSelecionado;

            tela.Habilitar(false);
            tela.buttonCancelar.Enabled = true;
            tela.buttonCancelar.Text = "Voltar";
            tela.ShowDialog();
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfigToolboxVeiculo();
        }

        public override UserControl ObtemListagem()
        {
            if (_tabelaVeiculos == null)
                _tabelaVeiculos = new();

            CarregarVeiculos();

            return _tabelaVeiculos;
        }

        private void CarregarVeiculos()
        {
            List<Veiculo> veiculos = _servicoVeiculo.SelecionarTodos().Value;

            _tabelaVeiculos.AtualizarRegistros(veiculos);

            TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {veiculos.Count} {(veiculos.Count == 1 ? "veículo" : "veículos")}", CorParaRodape.Yellow);
        }
    }
}
