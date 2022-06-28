using LocadoraDeVeiculos.Dominio.ModuloCliente;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloCliente
{
    public class ControladorCliente : ControladorBase
    {
        private IServicoCliente ServicoCliente;
        private TabelaClienteControl? _tabelaCliente;

        public ControladorCliente(IServicoCliente ser)
        {
            ServicoCliente = ser;
        }

        public override void Visualizar()
        {
            var numero = _tabelaCliente!.ObtemNumeroClienteSelecionado();

            Cliente clienteSelecionado = ServicoCliente.SelecionarPorID(numero);

            if (clienteSelecionado == null)
            {
                MessageBox.Show("Selecione um cliente primeiro!", "Edição de clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var tela = new TelaCadastroClienteForm();

            tela.cliente = clienteSelecionado;

            tela.Enable(false);
            tela.btnCancelar.Enabled = true;
            tela.btnCancelar.Text = "voltar";
            tela.ShowDialog();

        }

        public override void Inserir()
        {
            TelaCadastroClienteForm tela = new();

            tela.cliente = new();

            tela.GravarRegistro = ServicoCliente.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarCliente();
        }
        public override void Editar()
        {
            var numero = _tabelaCliente!.ObtemNumeroClienteSelecionado();

            Cliente clienteSelecionado = ServicoCliente.SelecionarPorID(numero);

            if (clienteSelecionado == null)
            {
                MessageBox.Show("Selecione um cliente primeiro!", "Edição de clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var tela = new TelaCadastroClienteForm();

            tela.cliente = clienteSelecionado;

            tela.GravarRegistro = ServicoCliente.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarCliente();
        }

        public override void Excluir()
        {
            var numero = _tabelaCliente!.ObtemNumeroClienteSelecionado();

            Cliente clienteSelecionado = ServicoCliente.SelecionarPorID(numero);

            if (clienteSelecionado == null)
            {
                MessageBox.Show("Selecione um cliente primeiro!", "Edição de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir o Cliente?",
               "Exclusão de Cliente", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                ServicoCliente.Excluir(clienteSelecionado);
                CarregarCliente();
            }
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
            List<Cliente> clientes = ServicoCliente.SelecionarTodos();

            _tabelaCliente!.AtualizarRegistros(clientes);

            TelaPrincipalForm.Instancia!.AtualizarRodape($"Visualizando {clientes.Count} {(clientes.Count == 1 ? "cliente" : "clientes")}");
        }
    }
}
