using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Servico.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.WinApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloPlanoCobranca
{
    public partial class TelaCadastroPlanoCobrancaForm : Form
    {
        private PlanoCobranca planoCobranca;

        public PlanoCobranca PlanoCobranca
        {
            get { return planoCobranca; }
            set
            {
                planoCobranca = value!;
                ConfigurarTelaEditar();
            }
        }
        IServicoGrupoVeiculos servicoGrupoVeiculos;
        public TelaCadastroPlanoCobrancaForm(IServicoGrupoVeiculos servicoGrupoVeiculos)
        {
            InitializeComponent();
            this.ConfigurarTela();
            textBoxValorDia.AplicarMascaraMoeda();
            textBoxValorPorKm.AplicarMascaraMoeda();
            this.servicoGrupoVeiculos = servicoGrupoVeiculos;
        }

        public Func<PlanoCobranca, ValidationResult>? GravarRegistro { get; set; }

        private void buttonGravar_Click(object sender, EventArgs e)
        {
            ObterDadosDaTela();

            
            var resultadoValidacao = GravarRegistro(PlanoCobranca);

            if (!resultadoValidacao.IsValid)
            {
                TelaPrincipalForm.Instancia!.AtualizarRodape(resultadoValidacao.Errors[0].ErrorMessage);
                DialogResult = DialogResult.None;
            }
        }

        private void ConfigurarTelaEditar()
        {
            comboBoxPlano.DataSource = Enum.GetValues(typeof(PlanoEnum));
            comboBoxGrupoVeiculos.DataSource = servicoGrupoVeiculos.SelecionarTodos();

            textBoxID.Text = planoCobranca.Id.ToString();
            textBoxNome.Text = planoCobranca.Nome;
            textBoxValorDia.Text = "R$ " + planoCobranca.ValorDia.ToString();
            textBoxValorPorKm.Text = "R$ " + planoCobranca.ValorPorKm.ToString();
            numericUpDownKmIncluso.Value = planoCobranca.KmLivreIncluso;
            comboBoxPlano.SelectedItem = (PlanoEnum)planoCobranca.Plano;
            comboBoxGrupoVeiculos.SelectedItem = planoCobranca.GrupoVeiculos;
        }

        private void ObterDadosDaTela()
        {
            
            planoCobranca.Nome = textBoxNome.Text;
            planoCobranca.ValorDia = Convert.ToDecimal(textBoxValorDia.Text.ToString().Replace("R$ ", ""));
            planoCobranca.ValorPorKm = Convert.ToDecimal(textBoxValorPorKm.Text.ToString().Replace("R$ ", ""));
            planoCobranca.KmLivreIncluso = (int)numericUpDownKmIncluso.Value;
            planoCobranca.GrupoVeiculos = (GrupoVeiculos)comboBoxGrupoVeiculos.SelectedItem;
            planoCobranca.Plano = (PlanoEnum)comboBoxPlano.SelectedItem;
        }

        private void comboBoxPlano_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxPlano.SelectedItem)
            {
                case PlanoEnum.Diario:
                    numericUpDownKmIncluso.Value = 0;
                    numericUpDownKmIncluso.Enabled = false;
                    textBoxValorPorKm.Enabled = true;
                    textBoxValorDia.Enabled = true;
                    break;

                case PlanoEnum.KmLivre:
                    numericUpDownKmIncluso.Value = 0;
                    numericUpDownKmIncluso.Enabled = false;
                    textBoxValorPorKm.Enabled = false;
                    textBoxValorPorKm.Text = "R$ 0";
                    textBoxValorDia.Enabled = true;
                    break;

                case PlanoEnum.KmControlado:
                    numericUpDownKmIncluso.Enabled = true;
                    textBoxValorPorKm.Enabled = true;
                    textBoxValorDia.Enabled = true;
                    break;


            }
        }
    }
}
