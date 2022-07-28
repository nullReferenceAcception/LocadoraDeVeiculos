using FluentResults;
using LocadoraDeVeiculos.Dominio.ModuloDevolucao;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloDevolucao
{
    public class ControladorDevolucao : ControladorBase
    {
        private IServicoDevolucao _servicoDevolucao;
        private TabelaDevolucaoControl _tabelaDevolucao;

        public ControladorDevolucao(IServicoDevolucao servicoDevolucao, TabelaDevolucaoControl tabelaDevolucao)
        {
            _servicoDevolucao = servicoDevolucao;
            _tabelaDevolucao = tabelaDevolucao;
        }

        public override void Inserir()
        {
            if (_servicoDevolucao.QuantidadeRegistro().Value == 0)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape($"Cadastre no mínimo 1 'Grupo de Veículos' para cadastrar um veículo", CorParaRodape.Yellow);
                return;
            }

            TelaCadastroDevolucaoForm tela = new(_servicoDevolucao);

            tela.Devolucao = new();

            tela.GravarRegistro = _servicoDevolucao.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarDevolucoes();
        }
        public override void Editar()
        {
            var numero = _tabelaDevolucao.ObtemGuidDevolucaoSelecionada();

            var devolucaoSelecionada = _servicoDevolucao.SelecionarPorGuid(numero);

            if (devolucaoSelecionada == null)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape($"Selecione uma devolução para editar", CorParaRodape.Yellow);
                return;
            }

            TelaCadastroDevolucaoForm tela = new(_servicoDevolucao);

            tela.Devolucao = devolucaoSelecionada.Value;

            tela.GravarRegistro = _servicoDevolucao.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarDevolucoes();
        }

        public override void Excluir()
        {
            var numero = _tabelaDevolucao.ObtemGuidDevolucaoSelecionada();

            Devolucao devolucaoSelecionada = _servicoDevolucao.SelecionarPorGuid(numero).Value;

            if (devolucaoSelecionada == null)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape($"Selecione uma devolução para excluir", CorParaRodape.Yellow);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir a devolução?",
               "Exclusão de Devolução", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            Result validationResult;

            if (resultado == DialogResult.OK)
            {
                validationResult = _servicoDevolucao.Excluir(devolucaoSelecionada);
                CarregarDevolucoes();

                if (validationResult.Errors.Count > 0)
                    TelaPrincipalForm.Instancia.AtualizarRodape(validationResult.Errors[0].Message, CorParaRodape.Red);
            }
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfigToolBoxDevolucao();
        }

        public override UserControl ObtemListagem()
        {
            if (_tabelaDevolucao == null)
                _tabelaDevolucao = new();

            CarregarDevolucoes();

            return _tabelaDevolucao;
        }

        private void CarregarDevolucoes()
        {
            List<Devolucao> devolucoes = _servicoDevolucao.SelecionarTodos().Value;

            _tabelaDevolucao.AtualizarRegistros(devolucoes);

            TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {devolucoes.Count} {(devolucoes.Count == 1 ? "veículo" : "veículos")}", CorParaRodape.Yellow);
        }
    }
}
