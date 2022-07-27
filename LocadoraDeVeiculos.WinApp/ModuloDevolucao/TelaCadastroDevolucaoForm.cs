using FluentResults;
using LocadoraDeVeiculos.Dominio.ModuloDevolucao;
using System;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloDevolucao
{
    public partial class TelaCadastroDevolucaoForm : Form
    {
        private Devolucao _devolucao;
        private IServicoDevolucao _servicoDevolucao;

        public Devolucao Devolucao
        {
            get { return _devolucao; }
            set
            {
                _devolucao = value;
                ConfigurarTelaEditar();
            }
        }

        public TelaCadastroDevolucaoForm(IServicoDevolucao servicoDevolucao)
        {
            InitializeComponent();
            this.ConfigurarTela();
            this.AjustarLabelsHover();
            this._servicoDevolucao = servicoDevolucao;
        }

        public Func<Devolucao, Result<Devolucao>> GravarRegistro { get; set; }

        private void ConfigurarTelaEditar()
        {
            textBoxGuid.Text = Devolucao.Id.ToString();
            textBoxFuncionario.Text = "TODO";
            textBoxCondutor.Text = Devolucao.Locacao.Condutor.Nome;
            textBoxGrupoVeiculo.Text = "TODO";
            textBoxVeiculo.Text = Devolucao.Locacao.Veiculo.Modelo;
            textBoxPlanoCobranca.Text = Devolucao.Locacao.PlanoCobranca.Nome;
            dateTimePickerDataLocacao.Value = Devolucao.Locacao.DataLocacao;
            dateTimePickerDataDevolucaoPrevista.Value = Devolucao.Locacao.DataDevolucaoPrevista;

        }

        private void buttonGravar_Click(object sender, EventArgs e)
        {

        }
    }
}
