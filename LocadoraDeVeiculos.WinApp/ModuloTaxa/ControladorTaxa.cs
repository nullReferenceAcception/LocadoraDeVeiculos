using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloTaxa
{
    internal class ControladorTaxa : ControladorBase
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
                MessageBox.Show("Selecione uma taxa primeiro!", "Edição de Taxas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                MessageBox.Show("Selecione uma taxa primeiro!", "Edição de Taxas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir a disciplina?",
               "Exclusão de Disciplinas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if(resultado == DialogResult.OK)
            {
                _repositorioTaxa.Excluir(taxaSelecionada);
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
            List<Taxa> taxas = _repositorioTaxa.SelecionarTodos();

            _tabelaTaxas!.AtualizarRegistros(taxas);

            TelaPrincipalForm.Instancia!.AtualizarRodape($"Visualizando {taxas.Count} taxas");
        }
    }
}
