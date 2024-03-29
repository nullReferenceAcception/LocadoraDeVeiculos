﻿using FluentResults;
using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraDeVeiculos.WinApp.Compartilhado;
using System;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloPlanoCobranca
{
    public partial class TelaCadastroPlanoCobrancaForm : Form
    {
        private PlanoCobranca _planoCobranca;
        IServicoGrupoVeiculos _servicoGrupoVeiculos;

        public PlanoCobranca PlanoCobranca
        {
            get { return _planoCobranca; }
            set
            {
                _planoCobranca = value;
                ConfigurarTelaEditar();
            }
        }

        public TelaCadastroPlanoCobrancaForm(IServicoGrupoVeiculos servicoGrupoVeiculos)
        {
            InitializeComponent();
            this.ConfigurarTela();
            textBoxValorDia.AceitaNumeroEVirgulaPoeMascaraMoeda();
            textBoxValorPorKm.AceitaNumeroEVirgulaPoeMascaraMoeda();
            this._servicoGrupoVeiculos = servicoGrupoVeiculos;
            textBoxNome.Focus();
            textBoxNome.AceitaSoLetras();
            this.AjustarLabelsHover();
        }

        public Func<PlanoCobranca, Result<PlanoCobranca>> GravarRegistro { get; set; }

        private void buttonGravar_Click(object sender, EventArgs e)
        {
            ObterDadosDaTela();

            var resultadoValidacao = GravarRegistro(PlanoCobranca);

            if (resultadoValidacao.IsFailed)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape(resultadoValidacao.Errors[0].Message, CorParaRodape.Red);
                DialogResult = DialogResult.None;
            }
        }

        private void ConfigurarTelaEditar()
        {
            comboBoxPlano.DataSource = Enum.GetValues(typeof(PlanoEnum));
            comboBoxGrupoVeiculos.DataSource = _servicoGrupoVeiculos.SelecionarTodos().Value;

            textBoxGuid.Text = _planoCobranca.Id.ToString();
            textBoxNome.Text = _planoCobranca.Nome;
            textBoxValorDia.Text = "R$ " + _planoCobranca.ValorDia.ToString();
            textBoxValorPorKm.Text = "R$ " + _planoCobranca.ValorPorKm.ToString();
            numericUpDownKmIncluso.Value = _planoCobranca.KmLivreIncluso;
            comboBoxPlano.SelectedItem = (PlanoEnum)_planoCobranca.Plano;
            comboBoxGrupoVeiculos.SelectedItem = _planoCobranca.GrupoVeiculos;
        }

        private void ObterDadosDaTela()
        {
            _planoCobranca.Nome = textBoxNome.Text;
            _planoCobranca.ValorDia = Convert.ToDecimal(textBoxValorDia.Text.ToString().Replace("R$ ", ""));
            _planoCobranca.ValorPorKm = Convert.ToDecimal(textBoxValorPorKm.Text.ToString().Replace("R$ ", ""));
            _planoCobranca.KmLivreIncluso = (int)numericUpDownKmIncluso.Value;
            _planoCobranca.GrupoVeiculos = (GrupoVeiculos)comboBoxGrupoVeiculos.SelectedItem;
            _planoCobranca.Plano = (PlanoEnum)comboBoxPlano.SelectedItem;
        }

        private void comboBoxPlano_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxPlano.SelectedItem)
            {
                case PlanoEnum.Diario:
                    numericUpDownKmIncluso.Value = 0;
                    numericUpDownKmIncluso.Enabled = false;
                    labelKmIncluso.Cursor = DefaultCursor;
                    textBoxValorPorKm.Enabled = true;
                    textBoxValorDia.Enabled = true;
                    break;


                case PlanoEnum.KmControlado:
                    numericUpDownKmIncluso.Enabled = true;
                    labelKmIncluso.Cursor = Cursors.Hand;
                    textBoxValorPorKm.Enabled = true;
                    textBoxValorDia.Enabled = true;
                    break;

                case PlanoEnum.KmLivre:
                    numericUpDownKmIncluso.Value = 0;
                    numericUpDownKmIncluso.Enabled = false;
                    labelKmIncluso.Cursor = DefaultCursor;
                    textBoxValorPorKm.Enabled = false;
                    labelValorPorKm.Cursor = DefaultCursor;
                    textBoxValorPorKm.Text = "R$ 0";
                    textBoxValorDia.Enabled = true;
                    break;
            }
        }

        private void labelNome_Click(object sender, EventArgs e)
        {
            textBoxNome.Focus();
        }

        private void labelGrupoVeiculos_Click(object sender, EventArgs e)
        {
            comboBoxGrupoVeiculos.DroppedDown = true;
            comboBoxGrupoVeiculos.SelectedIndex = 0;
            comboBoxGrupoVeiculos.Select();
        }

        private void labelPlano_Click(object sender, EventArgs e)
        {
            comboBoxPlano.DroppedDown = true;
            comboBoxPlano.SelectedIndex = 0;
            comboBoxPlano.Select();
        }

        private void labelKmIncluso_Click(object sender, EventArgs e)
        {
            numericUpDownKmIncluso.Focus();
        }

        private void labelValorDia_Click(object sender, EventArgs e)
        {
            textBoxValorDia.Focus();
        }

        private void labelValorPorKm_Click(object sender, EventArgs e)
        {
            textBoxValorPorKm.Focus();
        }
    }
}
