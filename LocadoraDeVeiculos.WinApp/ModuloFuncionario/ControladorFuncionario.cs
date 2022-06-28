﻿using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloFuncionario
{
    public class ControladorFuncionario : ControladorBase
    {
        private IRepositorioFuncionario? _repositorioFuncionario;
        private TabelaFuncionarioControl? _tabelaFuncionario;

        public ControladorFuncionario(IRepositorioFuncionario rep)
        {
            _repositorioFuncionario = rep;
        }

        public override void Inserir()
        {
            TelaCadastroFuncionarioForm tela = new();

            tela.Funcionario = new();

            tela.GravarRegistro = _repositorioFuncionario!.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarFuncionarios();
        }

        public override void Editar()
        {
            var numero = _tabelaFuncionario!.ObtemNumeroFuncionarioSelecionado();

            Funcionario funcionarioSelecionado = _repositorioFuncionario!.SelecionarPorID(numero);

            if (funcionarioSelecionado == null)
            {
                TelaPrincipalForm.Instancia!.AtualizarRodape($"Selecione um funcionário para editar");
                return;
            }

            var tela = new TelaCadastroFuncionarioForm();

            tela.Funcionario = funcionarioSelecionado;

            tela.GravarRegistro = _repositorioFuncionario.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarFuncionarios();
        }

        public override void Excluir()
        {
            var numero = _tabelaFuncionario!.ObtemNumeroFuncionarioSelecionado();

            Funcionario funcionarioSelecionado = _repositorioFuncionario!.SelecionarPorID(numero);

            if (funcionarioSelecionado == null)
            {
                TelaPrincipalForm.Instancia!.AtualizarRodape($"Selecione um funcionário para excluir");
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir o funcionário?",
               "Exclusão de Disciplinas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                _repositorioFuncionario.Excluir(funcionarioSelecionado);
                CarregarFuncionarios();
            }
        }

        public override void Visualizar()
        {
            var numero = _tabelaFuncionario!.ObtemNumeroFuncionarioSelecionado();

            Funcionario selecionado = _repositorioFuncionario!.SelecionarPorID(numero);

            if (selecionado == null)
            {
                TelaPrincipalForm.Instancia!.AtualizarRodape($"Selecione um funcionário para visualizar");
                return;
            }

            var tela = new TelaCadastroFuncionarioForm();

            tela.Funcionario = selecionado;

            tela.Enable(false);
            tela.buttonCancelar.Enabled = true;
            tela.buttonCancelar.Text = "Voltar";
            tela.ShowDialog();
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfigToolboxFuncionario();
        }

        public override UserControl ObtemListagem()
        {
            if (_tabelaFuncionario == null)
                _tabelaFuncionario = new TabelaFuncionarioControl();

            CarregarFuncionarios();

            return _tabelaFuncionario;
        }

        private void CarregarFuncionarios()
        {
            List<Funcionario> funcionarios = _repositorioFuncionario!.SelecionarTodos();

            _tabelaFuncionario!.AtualizarRegistros(funcionarios);

            TelaPrincipalForm.Instancia!.AtualizarRodape($"Visualizando {funcionarios.Count} {(funcionarios.Count == 1 ? "funcionário" : "funcionários")}");
        }
    }
}
