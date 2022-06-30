using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using System;
using System.Windows.Forms;
using LocadoraDeVeiculos.WinApp.Compartilhado;

namespace LocadoraDeVeiculos.WinApp.ModuloVeiculo
{
    public partial class TelaCadastroVeiculoForm : Form
    {
        private Veiculo _veiculo;

        public Veiculo Veiculo
        {
            get { return _veiculo; }
            set
            {
                _veiculo = value;
                pictureBoxFoto.Image = Veiculo.Foto.ParaImagem();
            }
        }

        public TelaCadastroVeiculoForm()
        {
            InitializeComponent();
            this.ConfigurarTela();
        }

        public Func<Veiculo, ValidationResult>? GravarRegistro { get; set; }

        private void buttonGravar_Click(object sender, EventArgs e)
        {
            Veiculo.Foto = pictureBoxFoto.ParaByteArray();
        }
    }
}
