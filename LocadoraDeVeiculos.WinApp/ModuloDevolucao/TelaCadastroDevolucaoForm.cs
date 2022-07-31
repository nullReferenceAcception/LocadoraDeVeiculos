using FluentResults;
using Locadora.Infra.Configs;
using LocadoraDeVeiculos.Dominio.ModuloDevolucao;
using LocadoraDeVeiculos.Dominio.ModuloLocacao;
using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloDevolucao
{
    public partial class TelaCadastroDevolucaoForm : Form
    {
        private Devolucao _devolucao;
        private IServicoDevolucao _servicoDevolucao;
        private IServicoLocacao _servicoLocacao;
        private IServicoTaxa _servicoTaxa;
        private IServicoVeiculo _servicoVeiculo;
        private ConfiguracaoAplicacaoLocadora configuracao;

        public Devolucao Devolucao
        {
            get { return _devolucao; }
            set
            {
                _devolucao = value;
            }
        }

        public Func<Devolucao, Result<Devolucao>> GravarRegistro { get; set; }

        public TelaCadastroDevolucaoForm(IServicoDevolucao servicoDevolucao, IServicoLocacao servicoLocacao, IServicoTaxa servicoTaxa, IServicoVeiculo servicoVeiculo, ConfiguracaoAplicacaoLocadora configuracao)
        {
            InitializeComponent();
            this.ConfigurarTela();
            this.AjustarLabelsHover();
            this._servicoDevolucao = servicoDevolucao;
            this._servicoLocacao = servicoLocacao;
            this._servicoTaxa = servicoTaxa;
            this._servicoVeiculo = servicoVeiculo;
            this.configuracao = configuracao;

            numericUpDownKmRodadosLocacao.Enabled = false;
            dateTimePickerDataDevolucaoReal.Enabled = false;
            comboBoxNivelTanque.Enabled = false;
            checkedListBoxTaxasAdicionais.Enabled = false;

            var combustiveis = Enum.GetValues(typeof(TanqueEnum));

            foreach (TanqueEnum combustivel in combustiveis)
                comboBoxNivelTanque.Items.Add(combustivel);

            foreach (var locacao in _servicoLocacao.SelecionarTodos().Value)
                comboBoxLocacoes.Items.Add(locacao);

            foreach (var taxaAdicional in _servicoTaxa.SelecionarTodosAdicionais().Value)
                checkedListBoxTaxasAdicionais.Items.Add(taxaAdicional);
        }

        private void comboBoxLocacoes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Locacao loc = (Locacao)comboBoxLocacoes.SelectedItem;
            textBoxGuid.Text = loc.Id.ToString();
            textBoxFuncionario.Text = loc.Funcionario.Nome;
            if(loc.Condutor != null)
                textBoxCondutor.Text = loc.Condutor.Nome;
            textBoxGrupoVeiculo.Text = loc.PlanoCobranca.GrupoVeiculos.Nome;
            textBoxVeiculo.Text = loc.Veiculo.Modelo;
            textBoxPlanoCobranca.Text = loc.PlanoCobranca.Nome;
            dateTimePickerDataLocacao.Value = loc.DataLocacao;
            dateTimePickerDataDevolucaoPrevista.Value = loc.DataDevolucaoPrevista;
            comboBoxNivelTanque.SelectedIndex = 0;
            numericUpDownKmRodadosLocacao.Minimum = loc.Veiculo.KmPercorrido;
            numericUpDownKmRodadosLocacao.Value = loc.Veiculo.KmPercorrido;

            numericUpDownKmRodadosLocacao.Enabled = true;
            dateTimePickerDataDevolucaoReal.Enabled = true;
            comboBoxNivelTanque.Enabled = true;
            checkedListBoxTaxasAdicionais.Enabled = true;

            checkedListBoxTaxasSelecionadas.Items.Clear();

            foreach (var taxa in loc.Taxas)
                checkedListBoxTaxasSelecionadas.Items.Add(taxa, true);

            AtualizarTotalPrevisto();
        }

        private void buttonGravar_Click(object sender, EventArgs e)
        {
            ObterDadosDaTela();

            var resultadoValidacao = GravarRegistro(Devolucao);
            resultadoValidacao = EditarKmVeiculo();

            if (resultadoValidacao.IsFailed)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape(resultadoValidacao.Errors[0].Message, CorParaRodape.Red);
                DialogResult = DialogResult.None;
            }
        }

        private void FinalizarLocacao()
        {
            Devolucao.Locacao.Status = StatusEnum.Finalizado;

            _servicoLocacao.Editar(Devolucao.Locacao);
        }

        private Result<Devolucao> EditarKmVeiculo()
        {
            if (numericUpDownKmRodadosLocacao.Value == Devolucao.Locacao.Veiculo.KmPercorrido)
                return Result.Fail(new Error("Quilometragem igual à que o veículo foi alugado!"));

            Devolucao.Locacao.Veiculo.KmPercorrido = numericUpDownKmRodadosLocacao.Value;

            _servicoVeiculo.Editar(Devolucao.Locacao.Veiculo);

            FinalizarLocacao();

            return Result.Ok();
        }

        private void AtualizarTotalPrevisto()
        {
            Locacao loc = (Locacao)comboBoxLocacoes.SelectedItem;

            PlanoCobranca planoCobranca = loc.PlanoCobranca;

            DateTime dataLocacao = dateTimePickerDataLocacao.Value;

            DateTime dataLocacaoPrevista = dateTimePickerDataDevolucaoPrevista.Value;

            int totalDias = (int)Math.Ceiling((dateTimePickerDataDevolucaoReal.Value.Date - dateTimePickerDataLocacao.Value.Date).TotalDays);

            decimal valorTotal = planoCobranca.ValorDia * totalDias;

            decimal kmRodados = loc.Veiculo.KmPercorrido - numericUpDownKmRodadosLocacao.Value;

            decimal totalKm = planoCobranca.KmLivreIncluso - kmRodados;

            if (totalKm > 0)
                valorTotal += planoCobranca.ValorPorKm * totalKm;

            foreach (Taxa item in checkedListBoxTaxasSelecionadas.Items)
            {
                if (item.EhDiaria)
                    valorTotal += item.Valor * totalDias;
                else
                    valorTotal += item.Valor;
            }

            foreach (Taxa item in checkedListBoxTaxasAdicionais.CheckedItems)
            {
                if (item.EhDiaria)
                    valorTotal += item.Valor * totalDias;
                else
                    valorTotal += item.Valor;
            }

            if (dateTimePickerDataDevolucaoReal.Value.Date > dateTimePickerDataDevolucaoPrevista.Value.Date)
                valorTotal += valorTotal * 0.10m;

            var custoCombustivel = 0m;

            switch(loc.Veiculo.Combustivel)
            {
                case CombustivelEnum.Diesel:
                    custoCombustivel = Decimal.Parse(configuracao.PrecoCombustiveis.Diesel);
                    break;
                case CombustivelEnum.Gasolina:
                    custoCombustivel = Decimal.Parse(configuracao.PrecoCombustiveis.Gasolina);
                    break;
                case CombustivelEnum.Álcool:
                    custoCombustivel = Decimal.Parse(configuracao.PrecoCombustiveis.Alcool);
                    break;
                case CombustivelEnum.Etanol:
                    custoCombustivel = Decimal.Parse(configuracao.PrecoCombustiveis.Etanol);
                    break;
                case CombustivelEnum.GNV:
                    custoCombustivel = Decimal.Parse(configuracao.PrecoCombustiveis.GNV);
                    break;
            }

            TanqueEnum tipoTanqueRetorno = (TanqueEnum)comboBoxNivelTanque.SelectedItem;

            var tamanhoTanque = loc.Veiculo.CapacidadeTanque;

            switch (tipoTanqueRetorno)
            {
                case TanqueEnum.Cheio:
                    break;
                case TanqueEnum.TresQuartos:
                    var umQuarto = tamanhoTanque / 4;
                    valorTotal += umQuarto * custoCombustivel;
                    break;
                case TanqueEnum.Meio:
                    var meio = tamanhoTanque / 2;
                    valorTotal += meio * custoCombustivel;
                    break;
                case TanqueEnum.UmQuarto:
                    var tresQuartos = tamanhoTanque * 3 / 4;
                    valorTotal += tresQuartos * custoCombustivel;
                    break;
                case TanqueEnum.Vazio:
                    valorTotal += tamanhoTanque * custoCombustivel;
                    break;
            }

            textBoxValorTotal.Text = Math.Round(valorTotal, 2).ToString();
        }

        private void ObterDadosDaTela()
        {
            Devolucao.DataDevolucaoReal = dateTimePickerDataDevolucaoReal.Value;
            Devolucao.Tanque = (TanqueEnum)comboBoxNivelTanque.SelectedItem;
            Devolucao.Locacao = (Locacao)comboBoxLocacoes.SelectedItem;

            foreach (Taxa taxa in checkedListBoxTaxasSelecionadas.CheckedItems)
                if (!Devolucao.TaxasAdicionais.Contains(taxa))
                    Devolucao.TaxasAdicionais.Add(taxa);

            List<Taxa> taxas = new();

            foreach (Taxa item in checkedListBoxTaxasSelecionadas.Items)
                if (!checkedListBoxTaxasSelecionadas.CheckedItems.Contains(item))
                    taxas.Add(item);

            Devolucao.ValorTotalReal = Convert.ToDecimal(textBoxValorTotal.Text);
        }

        private void checkedListBoxTaxasAdicionais_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            try
            {
                this.BeginInvoke((MethodInvoker)(() => AtualizarTotalPrevisto()));
            }
            catch (Exception ex) { }
        }

        private void comboBoxNivelTanque_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizarTotalPrevisto();
        }

        private void dateTimePickerDataDevolucaoReal_ValueChanged(object sender, EventArgs e)
        {
            AtualizarTotalPrevisto();
        }

        private void numericUpDownKmRodadosLocacao_ValueChanged(object sender, EventArgs e)
        {
            AtualizarTotalPrevisto();
        }
    }
}
