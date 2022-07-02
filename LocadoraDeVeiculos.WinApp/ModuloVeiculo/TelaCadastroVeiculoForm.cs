﻿using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using System;
using System.Windows.Forms;
using LocadoraDeVeiculos.WinApp.Compartilhado;
using System.Drawing;
using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;

namespace LocadoraDeVeiculos.WinApp.ModuloVeiculo
{
    public partial class TelaCadastroVeiculoForm : Form
    {
        private readonly IServicoGrupoVeiculos _servicoGrupoVeiculos;
        private Veiculo _veiculo;

        public Veiculo Veiculo
        {
            get { return _veiculo; }
            set
            {
                _veiculo = value;
                ConfigurarTelaEditar();
            }
        }

        public TelaCadastroVeiculoForm(IServicoGrupoVeiculos serv)
        {
            InitializeComponent();
            this.ConfigurarTela();
            this._servicoGrupoVeiculos = serv;
            CarregarCores();
            CarregarCombustiveis();
            CarregarGrupoVeiculos();
            textBoxModelo.Focus();
        }

        public Func<Veiculo, ValidationResult>? GravarRegistro { get; set; }

        private void ConfigurarTelaEditar()
        {
            textBoxID.Text = Veiculo.Id.ToString();
            textBoxModelo.Text = Veiculo.Modelo;
            textBoxMarca.Text = Veiculo.Marca;
            textBoxPlaca.Text = Veiculo.Placa;
            textBoxAno.Text = Veiculo.Ano.ToString();
            comboBoxCor.SelectedItem = Veiculo.Cor;
            comboBoxCombustivel.SelectedItem = Veiculo.Combustivel;
            numericUpDownTanque.Value = Convert.ToDecimal(Veiculo.CapacidadeTanque);
            textBoxKmPercorrido.Text = Veiculo.KmPercorrido.ToString();
            comboBoxGrupoVeiculos.SelectedItem = Veiculo.GrupoVeiculos;
            pictureBoxFoto.Image = Veiculo.Foto.ParaImagem();
        }

        private void CarregarCores()
        {
            comboBoxCor.DataSource = Enum.GetValues(typeof(CorEnum));
            comboBoxCor.SelectedIndex = -1;
        }

        private void CarregarCombustiveis()
        {
            comboBoxCombustivel.DataSource = Enum.GetValues(typeof(CombustivelEnum));
            comboBoxCombustivel.SelectedIndex = -1;
        }

        private void CarregarGrupoVeiculos()
        {
            comboBoxGrupoVeiculos.DataSource = _servicoGrupoVeiculos.SelecionarTodos();
            comboBoxGrupoVeiculos.SelectedItem = -1;
        }

        private void buttonGravar_Click(object sender, EventArgs e)
        {
            ObterDadosDaTela();

            var resultadoValidacao = GravarRegistro!(Veiculo);

            if (!resultadoValidacao.IsValid)
            {
                TelaPrincipalForm.Instancia!.AtualizarRodape(resultadoValidacao.Errors[0].ErrorMessage);
                DialogResult = DialogResult.None;
            }
        }

        private void ObterDadosDaTela()
        {
            Veiculo.Modelo = textBoxModelo.Text;
            Veiculo.Marca = textBoxMarca.Text;
            Veiculo.Placa = textBoxPlaca.Text.ToUpper();
            Veiculo.Ano = Convert.ToInt32(textBoxAno.Text);
            Veiculo.Cor = (CorEnum)comboBoxCor.SelectedItem;
            Veiculo.Combustivel = (CombustivelEnum)comboBoxCombustivel.SelectedItem;
            Veiculo.GrupoVeiculos = (GrupoVeiculos)comboBoxGrupoVeiculos.SelectedItem;
            Veiculo.CapacidadeTanque = numericUpDownTanque.Value;
            Veiculo.KmPercorrido = Convert.ToDecimal(textBoxKmPercorrido.Text);
            Veiculo.Foto = pictureBoxFoto.ParaByteArray();
        }

        private void pictureBoxFoto_Click(object sender, EventArgs e)
        {
            openFileDialogFoto.Title = "Imagem do veículo";
            openFileDialogFoto.Filter = "Images (*.JPEG;*.BMP;*.JPG;*.GIF;*.PNG;*.)|*.JPEG;*.BMP;*.JPG;*.GIF;*.PNG;*.icon;*.JFIF";

            if (openFileDialogFoto.ShowDialog() == DialogResult.OK)
            {
                pictureBoxFoto.Image = Image.FromFile(openFileDialogFoto.FileName);
                pictureBoxFoto.Image = new Bitmap(pictureBoxFoto.Image, new Size(331, 301));
            }
        }
    }
}
