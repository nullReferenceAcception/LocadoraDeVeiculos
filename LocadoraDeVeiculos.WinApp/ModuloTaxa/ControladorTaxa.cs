using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloTaxa
{
    public class ControladorTaxa : ControladorBase
    {
        private IRepositorioTaxa _repositorioTaxa;
        private TabelaTaxaControl? _tabelaTaxas;

        public ControladorTaxa(IRepositorioTaxa rep)
        {
            _repositorioTaxa = rep;
        }

        public override void Inserir()
        {
            TelaCadastroTaxaForm tela = new();

            tela.Taxa = new();

            tela.GravarRegistro = _repositorioTaxa.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarTaxas();
        }
        public override void Editar()
        {
            var numero = _tabelaTaxas!.ObtemNumeroTaxaSelecionada();

            Taxa taxaSelecionada = _repositorioTaxa.SelecionarPorID(numero);

            if (taxaSelecionada == null)
            {
                TelaPrincipalForm.Instancia!.AtualizarRodape($"Selecione uma taxa para editar");
                return;
            }

            var tela = new TelaCadastroTaxaForm();

            tela.Taxa = taxaSelecionada;

            tela.GravarRegistro = _repositorioTaxa.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarTaxas();
        }

        public override void Excluir()
        {
            var numero = _tabelaTaxas!.ObtemNumeroTaxaSelecionada();

            Taxa taxaSelecionada = _repositorioTaxa.SelecionarPorID(numero);

            if (taxaSelecionada == null)
            {
                TelaPrincipalForm.Instancia!.AtualizarRodape($"Selecione uma taxa para excluir");
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir a Taxa?",
               "Exclusão de Taxas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if(resultado == DialogResult.OK)
            {
                _repositorioTaxa.Excluir(taxaSelecionada);
                CarregarTaxas();
            }
        }

        public override void Visualizar()
        {
            var numero = _tabelaTaxas!.ObtemNumeroTaxaSelecionada();

            Taxa taxaSelecionada = _repositorioTaxa.SelecionarPorID(numero);

            if (taxaSelecionada == null)
            {
                TelaPrincipalForm.Instancia!.AtualizarRodape($"Selecione uma taxa para visualizar");
                return;
            }

            var tela = new TelaCadastroTaxaForm();

            tela.Taxa = taxaSelecionada;

            tela.Enable(false);
            tela.buttonCancelar.Enabled = true;
            tela.buttonCancelar.Text = "Voltar";
            tela.ShowDialog();
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
            List<Taxa> taxas = _repositorioTaxa.SelecionarTodos();

            _tabelaTaxas!.AtualizarRegistros(taxas);

            TelaPrincipalForm.Instancia!.AtualizarRodape($"Visualizando {taxas.Count} {(taxas.Count == 1 ? "taxa" : "taxas")}");
        }
    }
}
