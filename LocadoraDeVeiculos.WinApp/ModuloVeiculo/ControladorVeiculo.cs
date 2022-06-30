using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloVeiculo
{
    public class ControladorVeiculo : ControladorBase
    {
        private IServicoVeiculo servicoVeiculo;
        private TabelaVeiculoControl _tabelaVeiculos;

        public ControladorVeiculo(IServicoVeiculo serv)
        {
            this.servicoVeiculo = serv;
        }

        public override void Inserir()
        {
            TelaCadastroVeiculoForm tela = new();

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
                TelaPrincipalForm.Instancia!.AtualizarRodape($"Selecione um veículo para editar");
                return;
            }

            var tela = new TelaCadastroVeiculoForm();

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
                TelaPrincipalForm.Instancia!.AtualizarRodape($"Selecione um veículo para excluir");
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir o Veículo?",
               "Exclusão de Veículo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if(resultado == DialogResult.OK)
            {
                servicoVeiculo.Excluir(veiculoSelecionado);
                CarregarVeiculos();
            }
        }

        public override void Visualizar()
        {
            var numero = _tabelaVeiculos!.ObtemNumeroVeiculoSelecionado();

            Veiculo veiculoSelecionado = servicoVeiculo.SelecionarPorID(numero);

            if (veiculoSelecionado == null)
            {
                TelaPrincipalForm.Instancia!.AtualizarRodape($"Selecione um veículo para excluir");
                return;
            }

            var tela = new TelaCadastroVeiculoForm();

            tela.Veiculo = veiculoSelecionado;

            tela.Enable(false);
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

            TelaPrincipalForm.Instancia!.AtualizarRodape($"Visualizando {veiculos.Count} {(veiculos.Count == 1 ? "veículo" : "veículos")}");
        }
    }
}
