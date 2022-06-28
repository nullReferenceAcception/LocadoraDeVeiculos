using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloTaxa
{
    public class ControladorTaxa : ControladorBase
    {
        private IServicoTaxa servicoTaxa;
        private TabelaTaxaControl? _tabelaTaxas;

        public ControladorTaxa(IServicoTaxa rep)
        {
            servicoTaxa = rep;
        }

        public override void Visualizar()
        {
            var numero = _tabelaTaxas!.ObtemNumeroTaxaSelecionada();

            Taxa Selecionado = servicoTaxa.SelecionarPorID(numero);

            if (Selecionado == null)
            {
                MessageBox.Show("Selecione uma Taxa!", "Edição de Taxas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var tela = new TelaCadastroTaxaForm();

            tela.Taxa = Selecionado;

            tela.Enable(false);
            tela.button2.Enabled = true;
            tela.button2.Text = "voltar";
            tela.ShowDialog();

        }

        public override void Inserir()
        {
            TelaCadastroTaxaForm tela = new();

            tela.Taxa = new();

            tela.GravarRegistro = servicoTaxa.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarTaxas();
        }
        public override void Editar()
        {
            var numero = _tabelaTaxas!.ObtemNumeroTaxaSelecionada();

            Taxa taxaSelecionada = servicoTaxa.SelecionarPorID(numero);

            if (taxaSelecionada == null)
            {
                MessageBox.Show("Selecione uma taxa primeiro!", "Edição de Taxas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var tela = new TelaCadastroTaxaForm();

            tela.Taxa = taxaSelecionada;

            tela.GravarRegistro = servicoTaxa.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarTaxas();
        }

        public override void Excluir()
        {
            var numero = _tabelaTaxas!.ObtemNumeroTaxaSelecionada();

            Taxa taxaSelecionada = servicoTaxa.SelecionarPorID(numero);

            if (taxaSelecionada == null)
            {
                MessageBox.Show("Selecione uma taxa primeiro!", "Exclusão de Taxa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir a Taxa?",
               "Exclusão de Taxas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if(resultado == DialogResult.OK)
            {
                servicoTaxa.Excluir(taxaSelecionada);
                CarregarTaxas();
            }
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfigToolboxTaxa();
        }

        public override UserControl ObtemListagem()
        {
            if (_tabelaTaxas == null)
                _tabelaTaxas = new TabelaTaxaControl();

            CarregarTaxas();

            return _tabelaTaxas;
        }

        private void CarregarTaxas()
        {
            List<Taxa> taxas = servicoTaxa.SelecionarTodos();

            _tabelaTaxas!.AtualizarRegistros(taxas);

            TelaPrincipalForm.Instancia!.AtualizarRodape($"Visualizando {taxas.Count} {(taxas.Count == 1 ? "taxa" : "taxas")}");
        }
    }
}
