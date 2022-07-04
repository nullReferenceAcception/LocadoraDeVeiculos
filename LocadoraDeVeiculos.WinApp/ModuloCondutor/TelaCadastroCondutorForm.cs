using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.WinApp.Compartilhado;
using System;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloCondutor
{
    public partial class TelaCadastroCondutorForm : Form
    {
        private Condutor? _condutor;
        private IServicoCliente servicoCliente;

        public Condutor? Condutor
        {
            get { return _condutor; }
            set
            {
                _condutor = value!;
                ConfigurarTelaEditar();
            }
        }

        public TelaCadastroCondutorForm(IServicoCliente servicoCliente)
        {
            InitializeComponent();
            this.servicoCliente = servicoCliente;
            comboBoxEmpresa.DataSource = servicoCliente.SelecionarTodosClientesQueSaoPessoaJuridica();
            comboBoxClienteFisico.DataSource = servicoCliente.SelecionarTodosClientesQueSaoPessoaFisica();
            comboBoxClienteFisico.Enabled = false;
            this.ConfigurarTela();
            ConfigurarComponentes();
        }

        public Func<Condutor, ValidationResult>? GravarRegistro { get; set; }

        private void ConfigurarTelaEditar()
        {
            textBoxID.Text = _condutor!.Id.ToString();
            textBoxNome.Text = _condutor!.Nome;
            textBoxEndereco.Text = _condutor.Endereco;
            maskedTextBoxCNH.Text = _condutor.CNH;
            if (_condutor.Id != 0)
                dateTimePickerValidadeCNH.Value = _condutor.DataValidadeCNH;
            textBoxEmail.Text = _condutor.Email;
            maskedTextBoxTelefone.Text = _condutor.Telefone;
            maskedTextBoxCPF.Text = _condutor.CPF;
            comboBoxEmpresa.SelectedItem = _condutor.Cliente;
        }

        private void ObterDadosDaTela()
        {
            _condutor!.Nome = textBoxNome.Text;
            _condutor.Endereco = textBoxEndereco.Text;
            _condutor.CNH = maskedTextBoxCNH.Text;
            _condutor.DataValidadeCNH = dateTimePickerValidadeCNH.Value;
            _condutor.CPF = maskedTextBoxCPF.Text;
            _condutor.Email = textBoxEmail.Text;
            _condutor.Telefone = maskedTextBoxTelefone.Text;
            _condutor.Cliente = (Cliente)comboBoxEmpresa.SelectedItem;
        }
 
        private void buttonGravar_Click(object sender, EventArgs e)
        {
            ObterDadosDaTela();

            var resultadoValidacao = GravarRegistro!(_condutor!);

            if (!resultadoValidacao.IsValid)
            {
                TelaPrincipalForm.Instancia!.AtualizarRodape(resultadoValidacao.Errors[0].ErrorMessage,TelaPrincipalForm.Cor.Red);
                DialogResult = DialogResult.None;
            }
        }
        bool isChecked = false;
        private void radioButtonUsarRegistro_CheckedChanged(object sender, EventArgs e)
        {
            isChecked = radioButtonUsarRegistro.Checked;
        }

        private void radioButtonUsarRegistro_Click(object sender, EventArgs e)
        {
            if (radioButtonUsarRegistro.Checked && !isChecked)
            {
                radioButtonUsarRegistro.Checked = false;
                comboBoxClienteFisico.Enabled = false;
            }
            else
            {
                radioButtonUsarRegistro.Checked = true;
                isChecked = false;
                comboBoxClienteFisico.Enabled = true;
            }
        }

        private void comboBoxClienteFisico_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cliente cliente = (Cliente)comboBoxClienteFisico.SelectedItem;


            textBoxNome.Text = cliente.Nome;
            textBoxEndereco.Text = cliente.Endereco;
            maskedTextBoxCNH.Text = cliente.CNH;
            dateTimePickerValidadeCNH.Value = cliente.DataValidadeCNH;
            textBoxEmail.Text = cliente.Email;
            maskedTextBoxTelefone.Text = cliente.Telefone;
            maskedTextBoxCPF.Text = cliente.CPF;
        }

        private void ConfigurarComponentes()
        {
            textBoxNome.Focus();
            textBoxNome.AceitaSoLetras();
        }
    }
}
