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
            var numero = _tabelaFuncionario.ObtemGuidFuncionarioSelecionado();

            Funcionario funcionarioSelecionado = _servicoFuncionario.SelecionarPorGuid(numero).Value;

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
            var numero = _tabelaFuncionario.ObtemGuidFuncionarioSelecionado();

            Funcionario funcionarioSelecionado = _servicoFuncionario.SelecionarPorGuid(numero).Value;

            if (funcionarioSelecionado == null)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape($"Selecione um funcionário para desabilitar", CorParaRodape.Yellow);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente desabilitar o funcionário?",
               "Desabilitar funcionários", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);


            if (resultado == DialogResult.OK)
            {
                funcionarioSelecionado.EstaAtivo = false;
                var resultadoExclusao = _servicoFuncionario.Excluir(funcionarioSelecionado);

                if (resultadoExclusao.IsSuccess)
                    CarregarFuncionariosAtivos();
                else
                    TelaPrincipalForm.Instancia.AtualizarRodape(resultadoExclusao.Errors[0].Message, CorParaRodape.Red);
            }
        }

        public override void Visualizar()
        {
            var numero = _tabelaFuncionario.ObtemGuidFuncionarioSelecionado();

            Funcionario selecionado = _servicoFuncionario.SelecionarPorGuid(numero).Value;

            if (selecionado == null)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape($"Selecione um funcionário para visualizar", CorParaRodape.Yellow);
                return;
            }

            var tela = new TelaCadastroFuncionarioForm();

            tela.Funcionario = selecionado;

            tela.Habilitar(false);
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
            List<Funcionario> funcionariosDesativados = _servicoFuncionario.SelecionarDesativados().Value;

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
            List<Funcionario> funcionarios = _servicoFuncionario.SelecionarTodos().Value;

            _tabelaFuncionario.AtualizarRegistros(funcionarios);

            TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {funcionarios.Count} {(funcionarios.Count == 1 ? "funcionário" : "funcionários")}", CorParaRodape.White);
        }
    }
}
