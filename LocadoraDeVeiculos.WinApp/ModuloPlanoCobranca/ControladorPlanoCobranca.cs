using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Media;

namespace LocadoraDeVeiculos.WinApp.ModuloPlanoCobranca
{
    public class ControladorPlanoCobranca : ControladorBase
    {
        private IServicoPlanoCobranca _servicoPlanoCobranca;
        private IServicoGrupoVeiculos _servicoGrupoVeiculo;
        private TabelaPlanoCobrancaControl _tabelaPlanoCobrancas;

        public ControladorPlanoCobranca(IServicoPlanoCobranca servicoPlanoCobranca, IServicoGrupoVeiculos servicoGrupoVeiculos)
        {
            _servicoPlanoCobranca = servicoPlanoCobranca;
            _servicoGrupoVeiculo = servicoGrupoVeiculos;
        }

        public override void Inserir()
        {
            Stream str;
            if (_servicoGrupoVeiculo.QuantidadeRegistro() == 0)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape($"Cadastre no mínimo 1 'Grupo de Veículos' para cadastrar um plano de cobrança",CorParaRodape.Yellow);
                str = Properties.Resources.som;

                SoundPlayer snd = new(str);
                snd.Play();
                return;
            }

            TelaCadastroPlanoCobrancaForm tela = new(_servicoGrupoVeiculo);

            tela.PlanoCobranca = new();

            tela.GravarRegistro = _servicoPlanoCobranca.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarPlanoCobrancas();
        }
        public override void Editar()
        {
            var numero = _tabelaPlanoCobrancas.ObtemNumeroPlanoCobrancaSelecionada();

            PlanoCobranca planoCobrancaSelecionado = _servicoPlanoCobranca.SelecionarPorID(numero);

            if (planoCobrancaSelecionado == null)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape($"Selecione uma PlanoCobranca para editar", CorParaRodape.Yellow);
                return;
            }

            var tela = new TelaCadastroPlanoCobrancaForm(_servicoGrupoVeiculo);

            tela.PlanoCobranca = planoCobrancaSelecionado;

            tela.GravarRegistro = _servicoPlanoCobranca.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarPlanoCobrancas();
        }

        public override void Excluir()
        {
            var numero = _tabelaPlanoCobrancas.ObtemNumeroPlanoCobrancaSelecionada();

            PlanoCobranca planoCobrancaSelecionado = _servicoPlanoCobranca.SelecionarPorID(numero);

            if (planoCobrancaSelecionado == null)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape($"Selecione uma PlanoCobranca para excluir", CorParaRodape.Red);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir a PlanoCobranca?",
               "Exclusão de PlanoCobrancas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

             ValidationResult validationResult;
            if (resultado == DialogResult.OK)
            {
                validationResult = _servicoPlanoCobranca.Excluir(planoCobrancaSelecionado);
                CarregarPlanoCobrancas();

                if (validationResult.Errors.Count > 0)
                    TelaPrincipalForm.Instancia.AtualizarRodape($"Esse registro esta sendo usado por outro cadastro deletar aquele primeiro",CorParaRodape.Red);

            }
        }

        public override void Visualizar()
        {
            var numero = _tabelaPlanoCobrancas.ObtemNumeroPlanoCobrancaSelecionada();

            PlanoCobranca planoCobrancaSelecionado = _servicoPlanoCobranca.SelecionarPorID(numero);

            if (planoCobrancaSelecionado == null)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape($"Selecione uma PlanoCobranca para visualizar", CorParaRodape.Yellow);
                return;
            }

            var tela = new TelaCadastroPlanoCobrancaForm(_servicoGrupoVeiculo);

            tela.PlanoCobranca = planoCobrancaSelecionado;

            tela.EstadoDeHabilitacao(false);
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
            List<PlanoCobranca> planoCobrancas = _servicoPlanoCobranca.SelecionarTodos();

            _tabelaPlanoCobrancas.AtualizarRegistros(planoCobrancas);

            TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {planoCobrancas.Count} {(planoCobrancas.Count == 1 ? "PlanoCobranca" : "PlanoCobrancas")}", CorParaRodape.White);
        }
    }
}
