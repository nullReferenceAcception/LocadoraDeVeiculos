using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloVeiculo
{
    public class ControladorVeiculo : ControladorBase
    {
        private IServicoVeiculo servicoVeiculo;
        private IServicoGrupoVeiculos servicoGrupoVeiculos;
        private TabelaVeiculoControl _tabelaVeiculos;

        public ControladorVeiculo(IServicoVeiculo servVeiculo, IServicoGrupoVeiculos servGrupo)
        {
            this.servicoVeiculo = servVeiculo;
            this.servicoGrupoVeiculos = servGrupo;
        }

        public override void Inserir()
        {
            if (servicoGrupoVeiculos.QuantidadeRegistro() == 0)
            {
                TelaPrincipalForm.Instancia!.AtualizarRodape($"Cadastre no mínimo 1 'Grupo de Veículos' para cadastrar um veículo",CorParaRodape.Yellow);
                return;
            }

            TelaCadastroVeiculoForm tela = new(servicoGrupoVeiculos);

            tela.Veiculo = new();

            tela.GravarRegistro = servicoVeiculo.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarVeiculos();
        }

        public override void Editar()
        {
            var numero = _tabelaVeiculos!.ObtemNumeroVeiculoSelecionado();

            Veiculo veiculoSelecionado = servicoVeiculo.SelecionarPorID(numero);

            if (veiculoSelecionado == null)
            {
                TelaPrincipalForm.Instancia!.AtualizarRodape($"Selecione um veículo para editar",CorParaRodape.Yellow);
                return;
            }

            TelaCadastroVeiculoForm tela = new(servicoGrupoVeiculos);

            tela.Veiculo = veiculoSelecionado;

            tela.GravarRegistro = servicoVeiculo.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarVeiculos();
        }

        public override void Excluir()
        {
            var numero = _tabelaVeiculos!.ObtemNumeroVeiculoSelecionado();

            Veiculo veiculoSelecionado = servicoVeiculo.SelecionarPorID(numero);

            if (veiculoSelecionado == null)
            {
                TelaPrincipalForm.Instancia!.AtualizarRodape($"Selecione um veículo para excluir", CorParaRodape.Yellow);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir o Veículo?",
               "Exclusão de Veículo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            ValidationResult validationResult;

            if (resultado == DialogResult.OK)
            {
                validationResult = servicoVeiculo.Excluir(veiculoSelecionado);
                CarregarVeiculos();

                if (validationResult.Errors.Count > 0)
                    TelaPrincipalForm.Instancia!.AtualizarRodape($"Esse registro esta sendo usado por outro cadastro deletar aquele primeiro",CorParaRodape.Red);
            }
        }

        public override void Visualizar()
        {
            var numero = _tabelaVeiculos!.ObtemNumeroVeiculoSelecionado();

            Veiculo veiculoSelecionado = servicoVeiculo.SelecionarPorID(numero);

            if (veiculoSelecionado == null)
            {
                TelaPrincipalForm.Instancia!.AtualizarRodape($"Selecione um veículo para visualizar", CorParaRodape.Yellow);
                return;
            }

            TelaCadastroVeiculoForm tela = new(servicoGrupoVeiculos);

            tela.Veiculo = veiculoSelecionado;

            tela.EstadoDeAbilitacao(false);
            tela.buttonCancelar.Enabled = true;
            tela.buttonCancelar.Text = "Voltar";
            tela.ShowDialog();
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfigToolboxVeiculo();
        }

        public override UserControl ObtemListagem()
        {
            if (_tabelaVeiculos == null)
                _tabelaVeiculos = new();

            CarregarVeiculos();

            return _tabelaVeiculos;
        }

        private void CarregarVeiculos()
        {
            List<Veiculo> veiculos = servicoVeiculo.SelecionarTodos();

            _tabelaVeiculos.AtualizarRegistros(veiculos);

            TelaPrincipalForm.Instancia!.AtualizarRodape($"Visualizando {veiculos.Count} {(veiculos.Count == 1 ? "veículo" : "veículos")}",CorParaRodape.Yellow);
        }
    }
}
