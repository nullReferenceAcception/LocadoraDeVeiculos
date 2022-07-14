using FluentResults;
using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloTaxa
{
    public class ControladorTaxa : ControladorBase
    {
        private IServicoTaxa _servicoTaxa;
        private TabelaTaxaControl _tabelaTaxas;

        public ControladorTaxa(IServicoTaxa servicoTaxa)
        {
            _servicoTaxa = servicoTaxa;
        }

        public override void Inserir()
        {
            TelaCadastroTaxaForm tela = new();

            tela.Taxa = new();

            tela.GravarRegistro = _servicoTaxa.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarTaxas();
        }
        public override void Editar()
        {
            var guid = _tabelaTaxas.ObtemGuidTaxaSelecionada();

            Taxa taxaSelecionada = _servicoTaxa.SelecionarPorGuid(guid).Value;

            if (taxaSelecionada == null)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape($"Selecione uma taxa para editar", CorParaRodape.Yellow);
                return;
            }

            var tela = new TelaCadastroTaxaForm();

            tela.Taxa = taxaSelecionada;

            tela.GravarRegistro = _servicoTaxa.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarTaxas();
        }

        public override void Excluir()
        {
            var guid = _tabelaTaxas.ObtemGuidTaxaSelecionada();

            Taxa taxaSelecionada = _servicoTaxa.SelecionarPorGuid(guid).Value;

            if (taxaSelecionada == null)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape($"Selecione uma taxa para excluir", CorParaRodape.Yellow);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir a Taxa?",
               "Exclusão de Taxas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            Result validationResult;

            if (resultado == DialogResult.OK)
            {
                validationResult = _servicoTaxa.Excluir(taxaSelecionada);
                CarregarTaxas();

                if (validationResult.Errors.Count > 0)
                    TelaPrincipalForm.Instancia.AtualizarRodape($"Esse registro esta sendo usado por outro cadastro deletar aquele primeiro", CorParaRodape.Red);
            }
        }

        public override void Visualizar()
        {
            var guid = _tabelaTaxas.ObtemGuidTaxaSelecionada();

            Taxa taxaSelecionada = _servicoTaxa.SelecionarPorGuid(guid).Value;

            if (taxaSelecionada == null)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape($"Selecione uma taxa para visualizar", CorParaRodape.Yellow);
                return;
            }

            var tela = new TelaCadastroTaxaForm();

            tela.Taxa = taxaSelecionada;

            tela.Habilitar(false);
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
            List<Taxa> taxas = _servicoTaxa.SelecionarTodos().Value;

            _tabelaTaxas.AtualizarRegistros(taxas);

            TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {taxas.Count} {(taxas.Count == 1 ? "taxa" : "taxas")}", CorParaRodape.White);
        }
    }
}
