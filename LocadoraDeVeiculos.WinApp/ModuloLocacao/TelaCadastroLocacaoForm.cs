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
        IServicoVeiculo _servicoVeiculo;
        IServicoCondutor _servicoCondutor;
        IServicoGrupoVeiculos _servicoGrupoVeiculos;

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

            _servicoVeiculo = servicoVeiculo;
            _servicoCondutor = servicoCondutor;
            _servicoGrupoVeiculos = servicoGrupoVeiculos;

            foreach (var item in servicoTaxa.SelecionarTodos().Value)
                checkedListBoxTaxas.Items.Add(item);

            foreach (var item in servicoFuncionario.SelecionarTodos().Value)
                comboBoxFuncionario.Items.Add(item);

            foreach (var item in servicoPlanoCobranca.SelecionarTodos().Value)
                comboBoxPlanoCobranca.Items.Add(item);

            foreach (var item in servicoCliente.SelecionarTodos().Value)
                comboBoxCliente.Items.Add(item);
            }
            comboBoxPlanoCobranca.SelectedIndex = 0;
        }
        public Func<Locacao, Result<Locacao>> GravarRegistro { get; set; }
        public Action<Locacao, List<Taxa>> RemoverTaxas { get; internal set; }

        private void ConfigurarTelaEditar()
        {
            if (Locacao.Id != Guid.Empty)
            {
                textBoxGuid.Text = Locacao.Id.ToString();
                comboBoxFuncionario.SelectedItem = Locacao.Funcionario;
                comboBoxGrupoVeiculos.SelectedItem = Locacao.Veiculo.GrupoVeiculos;
                comboBoxVeiculo.SelectedItem = Locacao.Veiculo.Modelo;
                comboBoxCliente.SelectedItem = Locacao.Cliente;
                comboBoxPlanoCobranca.SelectedItem = Locacao.PlanoCobranca;
                comboBoxCondutor.SelectedItem = Locacao.Condutor;
                textBoxKmVeiculo.Text = Locacao.Veiculo.KmPercorrido.ToString();
                dateTimePickerDataLocacao.Value = Locacao.DataLocacao;
                dateTimePickerDataPrevistaDevolucao.Value = Locacao.DataDevolucaoPrevista;

                for (int i = 0; i < checkedListBoxTaxas.Items.Count; i++)
                    if (Locacao.Taxas.Contains((Taxa)checkedListBoxTaxas.Items[i]))
                        checkedListBoxTaxas.SetItemChecked(i, true);

                AtualizarTotalPrevisto();
            }
        }

        private void ObterDadosDaTela()
        {
            Locacao.Funcionario = (Funcionario)comboBoxFuncionario.SelectedItem;
            Locacao.Veiculo = (Veiculo)comboBoxVeiculo.SelectedItem;
            Locacao.Cliente = (Cliente)comboBoxCliente.SelectedItem;
            Locacao.PlanoCobranca = (PlanoCobranca)comboBoxPlanoCobranca.SelectedItem;
            Locacao.Condutor = (Condutor)comboBoxCondutor.SelectedItem;
            Locacao.DataDevolucaoPrevista = dateTimePickerDataPrevistaDevolucao.Value;
            Locacao.DataLocacao = dateTimePickerDataLocacao.Value;

            foreach (Taxa taxa in checkedListBoxTaxas.CheckedItems)
                if (!Locacao.Taxas.Contains(taxa))
                    Locacao.Taxas.Add(taxa);

            List<Taxa> taxas = new();

            foreach (Taxa item in checkedListBoxTaxas.Items)
                if (!checkedListBoxTaxas.CheckedItems.Contains(item))
                    taxas.Add(item);

            RemoverTaxas(Locacao, taxas);
        }

        
        private void buttonGravar_Click(object sender, EventArgs e)
        {
            ObterDadosDaTela();

            var resultadoValidacao = GravarRegistro(Locacao);

            if (resultadoValidacao.IsFailed)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape(resultadoValidacao.Errors[0].Message, CorParaRodape.Red);
                DialogResult = DialogResult.None;
            }
        }

        private void comboBoxGrupoVeiculos_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Veiculo item in _servicoVeiculo.SelecionarTodosDoGrupo((GrupoVeiculos)comboBoxGrupoVeiculos.SelectedItem).Value)
                comboBoxVeiculo.Items.Add(item);
        }

        private void comboBoxCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Condutor item in _servicoCondutor.SelecionarTodosDoCliente((Cliente)comboBoxCliente.SelectedItem).Value)
                comboBoxCondutor.Items.Add(item);
        }

        private void AtualizarTotalPrevisto()
        {
            PlanoCobranca planoCobranca = (PlanoCobranca)comboBoxPlanoCobranca.SelectedItem;

            DateTime dataLocacao = dateTimePickerDataLocacao.Value;

            DateTime dataLocacaoPrevista = dateTimePickerDataPrevistaDevolucao.Value;

            int totalDias = (int)((dateTimePickerDataPrevistaDevolucao.Value.Date - dateTimePickerDataLocacao.Value.Date).TotalDays);

            decimal valor = planoCobranca.ValorDia * totalDias;

            decimal totalKm = numericUpDownKmPlanejado.Value - planoCobranca.KmLivreIncluso;

            if (totalKm > 0)
                valor += planoCobranca.ValorPorKm * numericUpDownKmPlanejado.Value;

            foreach (Taxa item in checkedListBoxTaxas.CheckedItems)
                if (item.EhDiaria)
                    valor += item.Valor * totalDias;
                else
                    valor += item.Valor;

            textBoxTotalPrevisto.Text = Math.Round(valor, 3).ToString();
        }

        private void comboBoxPlanoCobranca_SelectedIndexChanged(object sender, EventArgs e)
        {
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

        private void textBoxKmPlanejado_TextChanged(object sender, EventArgs e)
        {
            AtualizarTotalPrevisto();
        }

        private void numericUpDownKmPlanejado_ValueChanged(object sender, EventArgs e)
        {
            AtualizarTotalPrevisto();
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
            comboBoxCondutor.SelectedIndex = 0;
            comboBoxCondutor.Select();
        }
    }
}
