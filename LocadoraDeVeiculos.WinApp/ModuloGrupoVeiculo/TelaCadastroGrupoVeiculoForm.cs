﻿using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloGrupoVeiculo
{
    // existe um textBoxNome que não existe no designer e nao sei tirar use o textBoxName
    public partial class TelaCadastroGrupoVeiculoForm : Form
    {
        private GrupoVeiculos grupoVeiculos;
        public GrupoVeiculos GrupoVeiculos
        {
            get { return grupoVeiculos; }
            set
            {
                grupoVeiculos = value!;
                textBoxName.Text = grupoVeiculos.Nome;
            }
        }
        public Func<GrupoVeiculos, ValidationResult>? GravarRegistro { get; set; }
        public TelaCadastroGrupoVeiculoForm()
        {
            InitializeComponent();
            this.ConfigurarTela();
        }

        private void buttonGravar_Click(object sender, EventArgs e)
        {
            GrupoVeiculos.Nome = textBoxName.Text;

            var resultadoValidacao = GravarRegistro!(GrupoVeiculos);

            if (!resultadoValidacao.IsValid)
            {
                TelaPrincipalForm.Instancia!.AtualizarRodape(resultadoValidacao.Errors[0].ErrorMessage);
                DialogResult = DialogResult.None;
            }

        }
    }
}