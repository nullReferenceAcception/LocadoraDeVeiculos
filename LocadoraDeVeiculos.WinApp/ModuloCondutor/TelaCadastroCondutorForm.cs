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
        private Condutor _condutor;
        private IServicoCliente _servicoCliente;

        public Condutor Condutor
        {
            get { return _condutor; }
            set
            {
                _condutor = value;
                ConfigurarTelaEditar();
            }
        }

        public TelaCadastroCondutorForm(IServicoCliente servicoCliente)
        {
            InitializeComponent();
            this._servicoCliente = servicoCliente;
            comboBoxEmpresa.DataSource = servicoCliente.SelecionarTodos();
            comboBoxClienteFisico.DataSource = servicoCliente.SelecionarTodosClientesQueSaoPessoaFisica();
            comboBoxClienteFisico.Enabled = false;
            this.ConfigurarTela();
            ConfigurarComponentes();
            this.AjustarLabelsHover();
        }

        public Func<Condutor, ValidationResult> GravarRegistro { get; set; }

        private void ConfigurarTelaEditar()
        {
            textBoxGuid.Text = _condutor.Guid.ToString();
            textBoxNome.Text = _condutor.Nome;
            textBoxEndereco.Text = _condutor.Endereco;
            maskedTextBoxCNH.Text = _condutor.CNH;
            if (_condutor.Guid != Guid.Empty)
                dateTimePickerValidadeCNH.Value = _condutor.DataValidadeCNH;
            textBoxEmail.Text = _condutor.Email;
            maskedTextBoxTelefone.Text = _condutor.Telefone;
            maskedTextBoxCPF.Text = _condutor.CPF;
            comboBoxEmpresa.SelectedItem = _condutor.Cliente;
        }

        private void ObterDadosDaTela()
        {
            _condutor.Nome = textBoxNome.Text;
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

            var resultadoValidacao = GravarRegistro(_condutor);

            if (!resultadoValidacao.IsValid)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape(resultadoValidacao.Errors[0].ErrorMessage, CorParaRodape.Red);
                DialogResult = DialogResult.None;
            }
        }

        bool isChecked = false;
        private void checkBoxUsarRegistro_Click(object sender, EventArgs e)
        {
            if (!checkBoxUsarRegistro.Checked && !isChecked)
            {
                checkBoxUsarRegistro.Checked = false;
                comboBoxClienteFisico.Enabled = false;
                DefinirEstadoCampos(!isChecked);
                LimparCampos();
            }
            else
            {
                checkBoxUsarRegistro.Checked = true;
                isChecked = true;
                comboBoxClienteFisico.Enabled = true;
                DefinirEstadoCampos(!isChecked);
            }
        }

        private void checkBoxUsarRegistro_CheckedChanged(object sender, EventArgs e)
        {
            isChecked = checkBoxUsarRegistro.Checked;
            if (isChecked && comboBoxClienteFisico.Items.Count > 0)
            {
                comboBoxClienteFisico.DroppedDown = true;
                comboBoxClienteFisico.SelectedIndex = 0;
                comboBoxClienteFisico.Select();
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

        private void LimparCampos()
        {
            textBoxNome.Clear();
            textBoxEndereco.Clear();
            textBoxEmail.Clear();
            maskedTextBoxCNH.Clear();
            maskedTextBoxCPF.Clear();
            maskedTextBoxTelefone.Clear();
            dateTimePickerValidadeCNH.Value = DateTime.Today;
        }

        private void DefinirEstadoCampos(bool status)
        {
            textBoxNome.Enabled = status;
            textBoxEndereco.Enabled = status;
            textBoxEmail.Enabled = status;
            maskedTextBoxCNH.Enabled = status;
            maskedTextBoxCPF.Enabled = status;
            maskedTextBoxTelefone.Enabled = status;
            dateTimePickerValidadeCNH.Enabled = status;
        }

        private void labelNome_Click(object sender, EventArgs e)
        {
            textBoxNome.Select();
        }

        private void labelEndereco_Click(object sender, EventArgs e)
        {
            textBoxEndereco.Select();
        }

        private void labelTelefone_Click(object sender, EventArgs e)
        {
            maskedTextBoxTelefone.Select();
        }

        private void labelCPF_Click(object sender, EventArgs e)
        {
            maskedTextBoxCPF.Select();
        }

        private void labelCNH_Click(object sender, EventArgs e)
        {
            maskedTextBoxCNH.Select();
        }

        private void labelValidadeCNH_Click(object sender, EventArgs e)
        {
            dateTimePickerValidadeCNH.Select();
            SendKeys.Send("%{DOWN}");
        }

        private void labelEmail_Click(object sender, EventArgs e)
        {
            textBoxEmail.Select();
        }

        private void labelEmpresa_Click(object sender, EventArgs e)
        {
            comboBoxEmpresa.DroppedDown = true;
            comboBoxEmpresa.SelectedIndex = 0;
            comboBoxEmpresa.Select();
        }
    }
}
