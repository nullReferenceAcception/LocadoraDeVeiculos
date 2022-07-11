using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloFuncionario
{
    public class ControladorFuncionario : ControladorBase
    {
        private IServicoFuncionario _servicoFuncionario;
        private TabelaFuncionarioControl _tabelaFuncionario;
        private bool estadoFuncionarios = true;
        public ControladorFuncionario(IServicoFuncionario ser)
        {
            _servicoFuncionario = ser;
        }

        public override void Inserir()
        {
            TelaCadastroFuncionarioForm tela = new();

            tela.Funcionario = new();

            tela.GravarRegistro = _servicoFuncionario.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarFuncionariosAtivos();
        }

        public override void Editar()
        {
            var numero = _tabelaFuncionario.ObtemNumeroFuncionarioSelecionado();

            Funcionario funcionarioSelecionado = _servicoFuncionario.SelecionarPorID(numero);

            if (funcionarioSelecionado == null)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape($"Selecione um funcionário para editar", CorParaRodape.Yellow);
                return;
            }

            var tela = new TelaCadastroFuncionarioForm();

            tela.Funcionario = funcionarioSelecionado;

            tela.GravarRegistro = _servicoFuncionario.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarFuncionariosAtivos();
        }

        public override void Excluir()
        {
            var numero = _tabelaFuncionario.ObtemNumeroFuncionarioSelecionado();

            Funcionario funcionarioSelecionado = _servicoFuncionario.SelecionarPorID(numero);

            if (funcionarioSelecionado == null)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape($"Selecione um funcionário para desabilitar", CorParaRodape.Yellow);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente desabilitar o funcionário?",
               "Desabilitar funcionários", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            ValidationResult validationResult;

            if (resultado == DialogResult.OK)
            {
                validationResult = _servicoFuncionario.Excluir(funcionarioSelecionado);
                CarregarFuncionariosAtivos();

                if (validationResult.Errors.Count > 0)
                    TelaPrincipalForm.Instancia.AtualizarRodape($"Esse registro esta sendo usado por outro cadastro deletar aquele primeiro", CorParaRodape.Red);
            }
        }

        public override void Visualizar()
        {
            var numero = _tabelaFuncionario.ObtemNumeroFuncionarioSelecionado();

            Funcionario selecionado = _servicoFuncionario.SelecionarPorID(numero);

            if (selecionado == null)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape($"Selecione um funcionário para visualizar", CorParaRodape.Yellow);
                return;
            }

            var tela = new TelaCadastroFuncionarioForm();

            tela.Funcionario = selecionado;

            tela.EstadoDeHabilitacao(false);
            tela.buttonCancelar.Enabled = true;
            tela.buttonCancelar.Text = "Voltar";
            tela.ShowDialog();
        }

        public override bool VisualizarDesativados()
        {
            if (estadoFuncionarios == false)
            {
                CarregarFuncionariosAtivos();
                estadoFuncionarios = true;
            }
            else
            {
                CarregarFuncionarioInativos();
                estadoFuncionarios = false;
            }

            return estadoFuncionarios;
        }

        private void CarregarFuncionarioInativos()
        {
            List<Funcionario> funcionariosDesativados = _servicoFuncionario.SelecionarDesativados();

            _tabelaFuncionario.AtualizarRegistros(funcionariosDesativados);

            TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {funcionariosDesativados.Count} {(funcionariosDesativados.Count == 1 ? "funcionário desativado" : "funcionários desativados")}", CorParaRodape.White);
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfigToolboxFuncionario();
        }

        public override UserControl ObtemListagem()
        {
            if (_tabelaFuncionario == null)
                _tabelaFuncionario = new TabelaFuncionarioControl();

            CarregarFuncionariosAtivos();

            return _tabelaFuncionario;
        }

        private void CarregarFuncionariosAtivos()
        {
            List<Funcionario> funcionarios = _servicoFuncionario.SelecionarTodos();

            _tabelaFuncionario.AtualizarRegistros(funcionarios);

            TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {funcionarios.Count} {(funcionarios.Count == 1 ? "funcionário" : "funcionários")}", CorParaRodape.White);
        }
    }
}
