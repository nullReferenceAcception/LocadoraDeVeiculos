using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloFuncionario
{
    public class ControladorFuncionario : ControladorBase
    {
        private IServicoFuncionario? servicoFuncionario;
        private TabelaFuncionarioControl? _tabelaFuncionario;
        private bool estadoFuncionarios = true;
        public ControladorFuncionario(IServicoFuncionario ser)
        {
            servicoFuncionario = ser;
        }

        public override void Inserir()
        {
            TelaCadastroFuncionarioForm tela = new();

            tela.Funcionario = new();

            tela.GravarRegistro = servicoFuncionario!.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarFuncionariosAtivos();
        }

        public override void Editar()
        {
            var numero = _tabelaFuncionario!.ObtemNumeroFuncionarioSelecionado();

            Funcionario funcionarioSelecionado = servicoFuncionario!.SelecionarPorID(numero);

            if (funcionarioSelecionado == null)
            {
                TelaPrincipalForm.Instancia!.AtualizarRodape($"Selecione um funcionário para editar",TelaPrincipalForm.Cor.Yellow);
                return;
            }

            var tela = new TelaCadastroFuncionarioForm();

            tela.Funcionario = funcionarioSelecionado;

            tela.GravarRegistro = servicoFuncionario.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarFuncionariosAtivos();
        }

        public override void Excluir()
        {
            var numero = _tabelaFuncionario!.ObtemNumeroFuncionarioSelecionado();

            Funcionario funcionarioSelecionado = servicoFuncionario!.SelecionarPorID(numero);

            if (funcionarioSelecionado == null)
            {
                TelaPrincipalForm.Instancia!.AtualizarRodape($"Selecione um funcionário para desabilitar",TelaPrincipalForm.Cor.Yellow);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente desabilitar o funcionário?",
               "Exclusão de Disciplinas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            ValidationResult validationResult;


            if (resultado == DialogResult.OK)
            {
                validationResult = servicoFuncionario.Excluir(funcionarioSelecionado);
                CarregarFuncionariosAtivos();

                if (validationResult.Errors.Count > 0)
                    TelaPrincipalForm.Instancia!.AtualizarRodape($"Esse registro esta sendo usado por outro cadastro deletar aquele primeiro",TelaPrincipalForm.Cor.Red);
            }
        }

        public override void Visualizar()
        {
            var numero = _tabelaFuncionario!.ObtemNumeroFuncionarioSelecionado();

            Funcionario selecionado = servicoFuncionario!.SelecionarPorID(numero);

            if (selecionado == null)
            {
                TelaPrincipalForm.Instancia!.AtualizarRodape($"Selecione um funcionário para visualizar",TelaPrincipalForm.Cor.Yellow);
                return;
            }

            var tela = new TelaCadastroFuncionarioForm();

            tela.Funcionario = selecionado;

            tela.EstadoDeAbilitacao(false);
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
            List<Funcionario> funcionariosDesativados = servicoFuncionario!.SelecionarDesativados();

            _tabelaFuncionario!.AtualizarRegistros(funcionariosDesativados);

            TelaPrincipalForm.Instancia!.AtualizarRodape($"Visualizando {funcionariosDesativados.Count} {(funcionariosDesativados.Count == 1 ? "funcionário desativado" : "funcionários desativados")}",TelaPrincipalForm.Cor.White);
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
            List<Funcionario> funcionarios = servicoFuncionario!.SelecionarTodos();

            _tabelaFuncionario!.AtualizarRegistros(funcionarios);

            TelaPrincipalForm.Instancia!.AtualizarRodape($"Visualizando {funcionarios.Count} {(funcionarios.Count == 1 ? "funcionário" : "funcionários")}",TelaPrincipalForm.Cor.White);
        }
    }
}
