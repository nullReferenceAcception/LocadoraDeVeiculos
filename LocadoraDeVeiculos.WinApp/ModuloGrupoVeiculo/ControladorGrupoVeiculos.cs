﻿using FluentResults;
using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloGrupoVeiculo
{
    public class ControladorGrupoVeiculos : ControladorBase
    {
        private IServicoGrupoVeiculos _servicoGrupoVeiculo;
        private TabelaGrupoVeiculoControl _tabelaGrupoVeiculo;

        public ControladorGrupoVeiculos(IServicoGrupoVeiculos servicoGrupoVeiculo)
        {
            _servicoGrupoVeiculo = servicoGrupoVeiculo;
        }
        
        public override void Inserir()
        {
            TelaCadastroGrupoVeiculoForm tela = new();
            tela.GrupoVeiculos = new();

            tela.GravarRegistro = _servicoGrupoVeiculo.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                carregarGrupoVeiculos();
        }

        public override void Editar()
        {
            var numero = _tabelaGrupoVeiculo.ObtemGuidSelecionada();

            GrupoVeiculos Selecionada = _servicoGrupoVeiculo.SelecionarPorGuid(numero).Value;

            if (Selecionada == null)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape($"Selecione um grupo de veículos para editar", CorParaRodape.Yellow);
                return;
            }

            var tela = new TelaCadastroGrupoVeiculoForm();

            tela.GrupoVeiculos = Selecionada;

            tela.GravarRegistro = _servicoGrupoVeiculo.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                carregarGrupoVeiculos();
        }

        public override void Excluir()
        {
            var numero = _tabelaGrupoVeiculo.ObtemGuidSelecionada();

            GrupoVeiculos Selecionada = _servicoGrupoVeiculo.SelecionarPorGuid(numero).Value;

            if (Selecionada == null)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape($"Selecione um grupo de veículos para excluir", CorParaRodape.Yellow);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir a Grupo de Veiculos?",
               "Exclusão de Grupo de Veiculos", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            Result validationResult;

            if (resultado == DialogResult.OK)
            {
                validationResult = _servicoGrupoVeiculo.Excluir(Selecionada);
                carregarGrupoVeiculos();

                if (validationResult.Errors.Count > 0)
                    TelaPrincipalForm.Instancia.AtualizarRodape(validationResult.Errors[0].Message, CorParaRodape.Red);
            }
        }

        public override void Visualizar()
        {
            var numero = _tabelaGrupoVeiculo.ObtemGuidSelecionada();

            GrupoVeiculos Selecionado = _servicoGrupoVeiculo.SelecionarPorGuid(numero).Value;

            if (Selecionado == null)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape($"Selecione um grupo de veículos para visualizar", CorParaRodape.Yellow);
                return;
            }

            var tela = new TelaCadastroGrupoVeiculoForm();

            tela.GrupoVeiculos = Selecionado;

            tela.Habilitar(false);
            tela.buttonCancelar.Enabled = true;
            tela.buttonCancelar.Text = "Voltar";
            tela.ShowDialog();
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfigToolboxGrupoVeiculo();
        }

        public override UserControl ObtemListagem()
        {
            if (_tabelaGrupoVeiculo == null)
                _tabelaGrupoVeiculo = new TabelaGrupoVeiculoControl();

            carregarGrupoVeiculos();

            return _tabelaGrupoVeiculo;
        }

        private void carregarGrupoVeiculos()
        {
            List<GrupoVeiculos> grupoVeiculos = _servicoGrupoVeiculo.SelecionarTodos().Value;

            _tabelaGrupoVeiculo!.AtualizarRegistros(grupoVeiculos);

            TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {grupoVeiculos.Count} {(grupoVeiculos.Count == 1 ? "grupo de veículos" : "grupos de veículos")}", CorParaRodape.White);
        }
    }
}
