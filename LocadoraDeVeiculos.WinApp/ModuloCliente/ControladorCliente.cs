using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloCliente
{
    public class ControladorCliente : ControladorBase
    {
        private IServicoCliente _servicoCliente;
        private TabelaClienteControl _tabelaCliente;

        public ControladorCliente(IServicoCliente servicoCliente)
        {
            _servicoCliente = servicoCliente;
        }

        public override void Inserir()
        {
            TelaCadastroClienteForm tela = new();

            tela.Cliente = new();

            tela.GravarRegistro = _servicoCliente.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarCliente();
        }
        public override void Editar()
        {
            var numero = _tabelaCliente.ObtemGuidClienteSelecionado();

            Cliente clienteSelecionado = _servicoCliente.SelecionarPorGuid(numero);

            if (clienteSelecionado == null)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape($"Selecione um cliente para editar", CorParaRodape.Yellow);
                return;
            }

            var tela = new TelaCadastroClienteForm();

            tela.Cliente = clienteSelecionado;

            tela.GravarRegistro = _servicoCliente.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarCliente();
        }

        public override void Excluir()
        {
            var numero = _tabelaCliente.ObtemGuidClienteSelecionado();

            Cliente clienteSelecionado = _servicoCliente.SelecionarPorGuid(numero);

            if (clienteSelecionado == null)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape($"Selecione um cliente para excluir", CorParaRodape.Yellow);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir o Cliente?",
               "Exclusão de Cliente", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);


            ValidationResult validationResult;

            if (resultado == DialogResult.OK)
            {
                validationResult = _servicoCliente.Excluir(clienteSelecionado);
                CarregarCliente();

                if (validationResult.Errors.Count > 0)
                    TelaPrincipalForm.Instancia.AtualizarRodape($"Esse registro esta sendo usado por outro cadastro deletar aquele primeiro", CorParaRodape.Red);
            }
        }

        public override void Visualizar()
        {
            var numero = _tabelaCliente.ObtemGuidClienteSelecionado();

            Cliente clienteSelecionado = _servicoCliente.SelecionarPorGuid(numero);

            if (clienteSelecionado == null)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape($"Selecione um cliente para visualizar", CorParaRodape.Yellow);
                return;
            }

            var tela = new TelaCadastroClienteForm();

            tela.Cliente = clienteSelecionado;

            tela.EstadoDeHabilitacao(false);
            tela.buttonCancelar.Enabled = true;
            tela.buttonCancelar.Text = "Voltar";
            tela.ShowDialog();
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfigToolboxCliente();
        }

        public override UserControl ObtemListagem()
        {
            if (_tabelaCliente == null)
                _tabelaCliente = new TabelaClienteControl();

            CarregarCliente();

            return _tabelaCliente;
        }

        private void CarregarCliente()
        {
            List<Cliente> clientes = _servicoCliente.SelecionarTodos();

            _tabelaCliente.AtualizarRegistros(clientes);

            TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {clientes.Count} {(clientes.Count == 1 ? "cliente" : "clientes")}", CorParaRodape.White);
        }
    }
}
