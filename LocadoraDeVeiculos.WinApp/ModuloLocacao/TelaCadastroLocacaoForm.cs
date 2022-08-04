using FluentResults;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloLocacao;
using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloLocacao
{
    public partial class TelaCadastroLocacaoForm : Form
    {
        Locacao _locacao;
        Locacao _locacaoCalculo;
        IServicoVeiculo _servicoVeiculo;
        IServicoCondutor _servicoCondutor;
        IServicoGrupoVeiculos _servicoGrupoVeiculos;
        Locacao locacaoParaCalculos;

        public Locacao Locacao
        {
            get { return _locacao; }
            set
            {
                _locacao = value;
                ConfigurarTelaEditar();
            }
        }

        public TelaCadastroLocacaoForm(IServicoPlanoCobranca servicoPlanoCobranca, IServicoCliente servicoCliente, IServicoVeiculo servicoVeiculo, IServicoFuncionario servicoFuncionario, IServicoGrupoVeiculos servicoGrupoVeiculos, IServicoCondutor servicoCondutor, IServicoTaxa servicoTaxa)
        {
            InitializeComponent();
            this.ConfigurarTela();
            this.AjustarLabelsHover();

            locacaoParaCalculos = new();

            _servicoVeiculo = servicoVeiculo;
            _servicoCondutor = servicoCondutor;
            _servicoGrupoVeiculos = servicoGrupoVeiculos;

            foreach (var item in servicoTaxa.SelecionarTodos().Value)
                if(!item.EhAdicional)
                checkedListBoxTaxas.Items.Add(item);

            foreach (var item in servicoFuncionario.SelecionarTodos().Value)
                comboBoxFuncionario.Items.Add(item);

            foreach (var item in servicoPlanoCobranca.SelecionarTodos().Value)
                comboBoxPlanoCobranca.Items.Add(item);

            foreach (var item in servicoCliente.SelecionarTodos().Value)
                comboBoxCliente.Items.Add(item);

        }

        public Func<Locacao, Result<Locacao>> GravarRegistro { get; set; }
        public Action<Locacao, List<Taxa>> RemoverTaxas { get; internal set; }

        private void ConfigurarTelaEditar()
        {
            if (Locacao.Id != Guid.Empty)
            {
                // ordem de carregamento setado para que todo funcione corretamente so mexer se for necessario

                textBoxGuid.Text = Locacao.Id.ToString();
                comboBoxPlanoCobranca.SelectedItem = Locacao.PlanoCobranca;
                comboBoxGrupoVeiculos.SelectedItem = Locacao.Veiculo.GrupoVeiculos;
                comboBoxVeiculo.SelectedItem = Locacao.Veiculo;
                textBoxKmVeiculo.Text = Locacao.Veiculo.KmPercorrido.ToString();
                comboBoxFuncionario.SelectedItem = Locacao.Funcionario;
                comboBoxCliente.SelectedItem = Locacao.Cliente;
                dateTimePickerDataLocacao.Value = Locacao.DataLocacao;
                dateTimePickerDataPrevistaDevolucao.Value = Locacao.DataDevolucaoPrevista;
                textBoxTotalPrevisto.Text = Locacao.ValorTotalPrevisto.ToString();
                comboBoxCondutor.SelectedItem = Locacao.Condutor;

                for (int i = 0; i < checkedListBoxTaxas.Items.Count; i++)
                    if (Locacao.Taxas.Contains((Taxa)checkedListBoxTaxas.Items[i]))
                        checkedListBoxTaxas.SetItemChecked(i, true);

                AtualizarTotalPrevisto();
            }
        }

        private void ObterDadosDaTela(Locacao locacao)
        {
            locacao.Funcionario = (Funcionario)comboBoxFuncionario.SelectedItem;
            locacao.Veiculo = (Veiculo)comboBoxVeiculo.SelectedItem;
            locacao.Cliente = (Cliente)comboBoxCliente.SelectedItem;
            locacao.PlanoCobranca = (PlanoCobranca)comboBoxPlanoCobranca.SelectedItem;

            if (locacao.Cliente != null)
                locacao.Condutor = (Condutor)comboBoxCondutor.SelectedItem;

            locacao.DataDevolucaoPrevista = dateTimePickerDataPrevistaDevolucao.Value;
            locacao.DataLocacao = dateTimePickerDataLocacao.Value;

            foreach (Taxa taxa in checkedListBoxTaxas.CheckedItems)
                if (!locacao.Taxas.Contains(taxa))
                    locacao.Taxas.Add(taxa);

            List<Taxa> taxas = new();

            foreach (Taxa item in checkedListBoxTaxas.Items)
                if (!checkedListBoxTaxas.CheckedItems.Contains(item))
                    taxas.Add(item);

            RemoverTaxas(locacao, taxas);

            locacao.ValorTotalPrevisto = locacao.CalcularValor();

        }

        private void buttonGravar_Click(object sender, EventArgs e)
        {
            ObterDadosDaTela(_locacao);

            var resultadoValidacao = GravarRegistro(Locacao);

            if (resultadoValidacao.IsFailed)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape(resultadoValidacao.Errors[0].Message, CorParaRodape.Red);
                DialogResult = DialogResult.None;
            }
        }

        private void comboBoxGrupoVeiculos_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxVeiculo.Items.Clear();

            if (comboBoxGrupoVeiculos.SelectedIndex > -1)
                comboBoxVeiculo.Enabled = true;

            foreach (Veiculo item in _servicoVeiculo.SelecionarTodosDoGrupo((GrupoVeiculos)comboBoxGrupoVeiculos.SelectedItem).Value)
                comboBoxVeiculo.Items.Add(item);
        }

        private void AtualizarTotalPrevisto()
        {
            
            ObterDadosDaTela(locacaoParaCalculos);
            textBoxTotalPrevisto.Text = locacaoParaCalculos.ValorTotalPrevisto.ToString();

        }

        private void comboBoxCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxCondutor.Items.Clear();

            foreach (Condutor item in _servicoCondutor.SelecionarTodosDoCliente((Cliente)comboBoxCliente.SelectedItem).Value)
                comboBoxCondutor.Items.Add(item);

        }

        private void comboBoxPlanoCobranca_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxGrupoVeiculos.Items.Clear();
            if (comboBoxPlanoCobranca.SelectedIndex > -1)
            {
                comboBoxGrupoVeiculos.Enabled = true;
                checkedListBoxTaxas.Enabled = true;
            }

            GrupoVeiculos item = _servicoGrupoVeiculos.SelecionarGrupoDoPlano((PlanoCobranca)comboBoxPlanoCobranca.SelectedItem).Value;

            comboBoxGrupoVeiculos.Items.Add(item);

            AtualizarTotalPrevisto();
        }

        private void dateTimePickerDataPrevistaDevolucao_ValueChanged(object sender, EventArgs e)
        {
            AtualizarTotalPrevisto();
        }

        private void checkedListBoxTaxas_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            try
            {
                this.BeginInvoke((MethodInvoker)(() => AtualizarTotalPrevisto()));
            }
            catch (Exception ex) { }
        }


        private void numericUpDownKmPlanejado_ValueChanged(object sender, EventArgs e)
        {
            AtualizarTotalPrevisto();
        }

        private void comboBoxVeiculo_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxKmVeiculo.Text = ((Veiculo)comboBoxVeiculo.SelectedItem).KmPercorrido.ToString();
        }

        private void labelCliente_Click(object sender, EventArgs e)
        {
            comboBoxCliente.DroppedDown = true;
            comboBoxCliente.SelectedIndex = 0;
            comboBoxCliente.Select();
        }

        private void labelVeiculo_Click(object sender, EventArgs e)
        {
            comboBoxVeiculo.DroppedDown = true;
            comboBoxVeiculo.SelectedIndex = 0;
            comboBoxVeiculo.Select();
        }

        private void labelDataLocacao_Click(object sender, EventArgs e)
        {
            dateTimePickerDataLocacao.Select();
            SendKeys.Send("%{DOWN}");
        }

        private void labelDevolucao_Click(object sender, EventArgs e)
        {
            dateTimePickerDataPrevistaDevolucao.Select();
            SendKeys.Send("%{DOWN}");
        }

        private void labelPlanoCobranca_Click(object sender, EventArgs e)
        {
            comboBoxPlanoCobranca.DroppedDown = true;
            comboBoxPlanoCobranca.SelectedIndex = 0;
            comboBoxPlanoCobranca.Select();
        }

        private void labelGrupoVeiculos_Click(object sender, EventArgs e)
        {
            comboBoxGrupoVeiculos.DroppedDown = true;
            comboBoxGrupoVeiculos.SelectedIndex = 0;
            comboBoxGrupoVeiculos.Select();
        }

        private void labelFuncionario_Click(object sender, EventArgs e)
        {
            comboBoxFuncionario.DroppedDown = true;
            comboBoxFuncionario.SelectedIndex = 0;
            comboBoxFuncionario.Select();
        }
        private void labelCondutor_Click(object sender, EventArgs e)
        {
            comboBoxCondutor.DroppedDown = true;

            if(comboBoxCondutor.Items.Count > 0)
                comboBoxCondutor.SelectedIndex = 0;

            comboBoxCondutor.Select();
        }
    }
}
