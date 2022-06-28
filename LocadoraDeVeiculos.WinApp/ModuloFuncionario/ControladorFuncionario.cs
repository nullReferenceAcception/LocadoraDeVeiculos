using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloFuncionario
{
    public class ControladorFuncionario : ControladorBase
    {
        private IServicoFuncionario? servicoFuncionario;
        private TabelaFuncionarioControl? _tabelaFuncionario;

        public ControladorFuncionario(IServicoFuncionario ser)
        {
            servicoFuncionario = ser;
        }

        public override void Visualizar()
        {
            var numero = _tabelaFuncionario!.ObtemNumeroFuncionarioSelecionado();

            Funcionario selecionado = servicoFuncionario!.SelecionarPorID(numero);

            if (selecionado == null)
            {
                MessageBox.Show("Selecione um Funcionario primeiro!", "Edição de Funcionarios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var tela = new TelaCadastroFuncionarioForm();

            tela.Funcionario = selecionado;

            tela.Enable(false);
            tela.buttonCancelar.Enabled = true;
            tela.buttonCancelar.Text = "Voltar";
            tela.ShowDialog();

        }
        public override void Inserir()
        {
            TelaCadastroFuncionarioForm tela = new();

            tela.Funcionario = new();

            tela.GravarRegistro = servicoFuncionario!.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarFuncionarios();
        }

        public override void Editar()
        {
            var numero = _tabelaFuncionario!.ObtemNumeroFuncionarioSelecionado();

            Funcionario funcionarioSelecionado = servicoFuncionario!.SelecionarPorID(numero);

            if (funcionarioSelecionado == null)
            {
                MessageBox.Show("Selecione um funcionário primeiro!", "Edição de Funcionário", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var tela = new TelaCadastroFuncionarioForm();

            tela.Funcionario = funcionarioSelecionado;

            tela.GravarRegistro = servicoFuncionario.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarFuncionarios();
        }

        public override void Excluir()
        {
            var numero = _tabelaFuncionario!.ObtemNumeroFuncionarioSelecionado();

            Funcionario funcionarioSelecionado = servicoFuncionario!.SelecionarPorID(numero);

            if (funcionarioSelecionado == null)
            {
                MessageBox.Show("Selecione um funcionário primeiro!", "Exclusão de Funcionário", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir o funcionário?",
               "Exclusão de Disciplinas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                servicoFuncionario.Excluir(funcionarioSelecionado);
                CarregarFuncionarios();
            }
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
            List<Funcionario> funcionarios = servicoFuncionario!.SelecionarTodos();

            _tabelaFuncionario!.AtualizarRegistros(funcionarios);

            TelaPrincipalForm.Instancia!.AtualizarRodape($"Visualizando {funcionarios.Count} {(funcionarios.Count == 1 ? "funcionário" : "funcionários")}");
        }
    }
}
