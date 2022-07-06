using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloPlanoCobranca
{
    public class ControladorPlanoCobranca : ControladorBase
    {
        private IServicoPlanoCobranca servicoPlanoCobranca;
        private IServicoGrupoVeiculos servicoGrupoVeiculo;
        private TabelaPlanoCobrancaControl? _tabelaPlanoCobrancas;

        public ControladorPlanoCobranca(IServicoPlanoCobranca rep, IServicoGrupoVeiculos rep2)
        {
            servicoPlanoCobranca = rep;
            servicoGrupoVeiculo = rep2;
        }

        public override void Inserir()
        {
            Stream str;
            if (servicoGrupoVeiculo.QuantidadeRegistro() == 0)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape($"Cadastre no mínimo 1 'Grupo de Veículos' para cadastrar um plano de cobrança",CorParaRodape.Yellow);
                str = Properties.Resources.som;

                System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
                snd.Play();
                return;
            }

            TelaCadastroPlanoCobrancaForm tela = new(servicoGrupoVeiculo);

            tela.PlanoCobranca = new();

            tela.GravarRegistro = servicoPlanoCobranca.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarPlanoCobrancas();
        }
        public override void Editar()
        {
            var numero = _tabelaPlanoCobrancas!.ObtemNumeroPlanoCobrancaSelecionada();

            PlanoCobranca PlanoCobrancaSelecionada = servicoPlanoCobranca.SelecionarPorID(numero);

            if (PlanoCobrancaSelecionada == null)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape($"Selecione uma PlanoCobranca para editar",CorParaRodape.Yellow);
                return;
            }

            var tela = new TelaCadastroPlanoCobrancaForm(servicoGrupoVeiculo);

            tela.PlanoCobranca = PlanoCobrancaSelecionada;

            tela.GravarRegistro = servicoPlanoCobranca.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarPlanoCobrancas();
        }

        public override void Excluir()
        {
            var numero = _tabelaPlanoCobrancas!.ObtemNumeroPlanoCobrancaSelecionada();

            PlanoCobranca PlanoCobrancaSelecionada = servicoPlanoCobranca.SelecionarPorID(numero);

            if (PlanoCobrancaSelecionada == null)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape($"Selecione uma PlanoCobranca para excluir",CorParaRodape.Red);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir a PlanoCobranca?",
               "Exclusão de PlanoCobrancas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

             ValidationResult validationResult;
            if (resultado == DialogResult.OK)
            {
                validationResult = servicoPlanoCobranca.Excluir(PlanoCobrancaSelecionada);
                CarregarPlanoCobrancas();

                if (validationResult.Errors.Count > 0)
                    TelaPrincipalForm.Instancia.AtualizarRodape($"Esse registro esta sendo usado por outro cadastro deletar aquele primeiro",CorParaRodape.Red);

            }
        }

        public override void Visualizar()
        {
            var numero = _tabelaPlanoCobrancas!.ObtemNumeroPlanoCobrancaSelecionada();

            PlanoCobranca PlanoCobrancaSelecionada = servicoPlanoCobranca.SelecionarPorID(numero);

            if (PlanoCobrancaSelecionada == null)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape($"Selecione uma PlanoCobranca para visualizar",CorParaRodape.Yellow);
                return;
            }

            var tela = new TelaCadastroPlanoCobrancaForm(servicoGrupoVeiculo);

            tela.PlanoCobranca = PlanoCobrancaSelecionada;

            tela.EstadoDeAbilitacao(false);
            tela.buttonCancelar.Enabled = true;
            tela.buttonCancelar.Text = "Voltar";
            tela.ShowDialog();
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfigToolBoxPlanoCobranca();
        }

        public override UserControl ObtemListagem()
        {
            if (_tabelaPlanoCobrancas == null)
                _tabelaPlanoCobrancas = new TabelaPlanoCobrancaControl();

            CarregarPlanoCobrancas();

            return _tabelaPlanoCobrancas;
        }

        private void CarregarPlanoCobrancas()
        {
            List<PlanoCobranca> PlanoCobrancas = servicoPlanoCobranca.SelecionarTodos();

            _tabelaPlanoCobrancas!.AtualizarRegistros(PlanoCobrancas);

            TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {PlanoCobrancas.Count} {(PlanoCobrancas.Count == 1 ? "PlanoCobranca" : "PlanoCobrancas")}",CorParaRodape.White);
        }
    }
}
