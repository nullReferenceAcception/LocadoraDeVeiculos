namespace LocadoraDeVeiculos.WinApp.ModuloLocacao
{
    partial class TelaCadastroLocacaoForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBoxLocacao = new System.Windows.Forms.GroupBox();
            this.labelNome = new System.Windows.Forms.Label();
            this.textBoxNome = new System.Windows.Forms.TextBox();
            this.labelCliente = new System.Windows.Forms.Label();
            this.comboBoxCliente = new System.Windows.Forms.ComboBox();
            this.comboBoxVeiculo = new System.Windows.Forms.ComboBox();
            this.labelVeiculo = new System.Windows.Forms.Label();
            this.checkedListBoxTaxas = new System.Windows.Forms.CheckedListBox();
            this.groupBoxTaxa = new System.Windows.Forms.GroupBox();
            this.labelDataLocacao = new System.Windows.Forms.Label();
            this.labelDevolucao = new System.Windows.Forms.Label();
            this.dateTimePickerDataLocacao = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerDataPrevistaDevolucao = new System.Windows.Forms.DateTimePicker();
            this.comboBoxPlanoCobranca = new System.Windows.Forms.ComboBox();
            this.labelPlanoCobranca = new System.Windows.Forms.Label();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.buttonGravar = new System.Windows.Forms.Button();
            this.groupBoxLocacao.SuspendLayout();
            this.groupBoxTaxa.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxLocacao
            // 
            this.groupBoxLocacao.Controls.Add(this.comboBoxPlanoCobranca);
            this.groupBoxLocacao.Controls.Add(this.labelPlanoCobranca);
            this.groupBoxLocacao.Controls.Add(this.dateTimePickerDataPrevistaDevolucao);
            this.groupBoxLocacao.Controls.Add(this.dateTimePickerDataLocacao);
            this.groupBoxLocacao.Controls.Add(this.labelDevolucao);
            this.groupBoxLocacao.Controls.Add(this.labelDataLocacao);
            this.groupBoxLocacao.Controls.Add(this.comboBoxVeiculo);
            this.groupBoxLocacao.Controls.Add(this.labelVeiculo);
            this.groupBoxLocacao.Controls.Add(this.comboBoxCliente);
            this.groupBoxLocacao.Controls.Add(this.labelCliente);
            this.groupBoxLocacao.Controls.Add(this.textBoxNome);
            this.groupBoxLocacao.Controls.Add(this.labelNome);
            this.groupBoxLocacao.Controls.Add(this.groupBoxTaxa);
            this.groupBoxLocacao.Location = new System.Drawing.Point(12, 12);
            this.groupBoxLocacao.Name = "groupBoxLocacao";
            this.groupBoxLocacao.Size = new System.Drawing.Size(426, 500);
            this.groupBoxLocacao.TabIndex = 0;
            this.groupBoxLocacao.TabStop = false;
            this.groupBoxLocacao.Text = "Dados da locação:";
            // 
            // labelNome
            // 
            this.labelNome.AutoSize = true;
            this.labelNome.Location = new System.Drawing.Point(116, 31);
            this.labelNome.Name = "labelNome";
            this.labelNome.Size = new System.Drawing.Size(43, 15);
            this.labelNome.TabIndex = 0;
            this.labelNome.Text = "Nome:";
            // 
            // textBoxNome
            // 
            this.textBoxNome.Location = new System.Drawing.Point(176, 28);
            this.textBoxNome.MaxLength = 255;
            this.textBoxNome.Name = "textBoxNome";
            this.textBoxNome.Size = new System.Drawing.Size(180, 23);
            this.textBoxNome.TabIndex = 0;
            // 
            // labelCliente
            // 
            this.labelCliente.AutoSize = true;
            this.labelCliente.Location = new System.Drawing.Point(109, 65);
            this.labelCliente.Name = "labelCliente";
            this.labelCliente.Size = new System.Drawing.Size(50, 15);
            this.labelCliente.TabIndex = 2;
            this.labelCliente.Text = "Clilente:";
            // 
            // comboBoxCliente
            // 
            this.comboBoxCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCliente.FormattingEnabled = true;
            this.comboBoxCliente.Location = new System.Drawing.Point(176, 62);
            this.comboBoxCliente.Name = "comboBoxCliente";
            this.comboBoxCliente.Size = new System.Drawing.Size(236, 23);
            this.comboBoxCliente.TabIndex = 1;
            // 
            // comboBoxVeiculo
            // 
            this.comboBoxVeiculo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxVeiculo.FormattingEnabled = true;
            this.comboBoxVeiculo.Location = new System.Drawing.Point(176, 92);
            this.comboBoxVeiculo.Name = "comboBoxVeiculo";
            this.comboBoxVeiculo.Size = new System.Drawing.Size(236, 23);
            this.comboBoxVeiculo.TabIndex = 2;
            // 
            // labelVeiculo
            // 
            this.labelVeiculo.AutoSize = true;
            this.labelVeiculo.Location = new System.Drawing.Point(111, 95);
            this.labelVeiculo.Name = "labelVeiculo";
            this.labelVeiculo.Size = new System.Drawing.Size(48, 15);
            this.labelVeiculo.TabIndex = 4;
            this.labelVeiculo.Text = "Veículo:";
            // 
            // checkedListBoxTaxas
            // 
            this.checkedListBoxTaxas.BackColor = System.Drawing.SystemColors.Control;
            this.checkedListBoxTaxas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBoxTaxas.FormattingEnabled = true;
            this.checkedListBoxTaxas.Location = new System.Drawing.Point(3, 19);
            this.checkedListBoxTaxas.Name = "checkedListBoxTaxas";
            this.checkedListBoxTaxas.Size = new System.Drawing.Size(295, 239);
            this.checkedListBoxTaxas.TabIndex = 3;
            // 
            // groupBoxTaxa
            // 
            this.groupBoxTaxa.Controls.Add(this.checkedListBoxTaxas);
            this.groupBoxTaxa.Location = new System.Drawing.Point(111, 121);
            this.groupBoxTaxa.Name = "groupBoxTaxa";
            this.groupBoxTaxa.Size = new System.Drawing.Size(301, 261);
            this.groupBoxTaxa.TabIndex = 6;
            this.groupBoxTaxa.TabStop = false;
            this.groupBoxTaxa.Text = "Taxas:";
            // 
            // labelDataLocacao
            // 
            this.labelDataLocacao.AutoSize = true;
            this.labelDataLocacao.Location = new System.Drawing.Point(65, 401);
            this.labelDataLocacao.Name = "labelDataLocacao";
            this.labelDataLocacao.Size = new System.Drawing.Size(94, 15);
            this.labelDataLocacao.TabIndex = 7;
            this.labelDataLocacao.Text = "Data de locação:";
            // 
            // labelDevolucao
            // 
            this.labelDevolucao.AutoSize = true;
            this.labelDevolucao.Location = new System.Drawing.Point(7, 434);
            this.labelDevolucao.Name = "labelDevolucao";
            this.labelDevolucao.Size = new System.Drawing.Size(152, 15);
            this.labelDevolucao.TabIndex = 8;
            this.labelDevolucao.Text = "Data presvita de devolução:";
            // 
            // dateTimePickerDataLocacao
            // 
            this.dateTimePickerDataLocacao.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerDataLocacao.Location = new System.Drawing.Point(176, 395);
            this.dateTimePickerDataLocacao.Name = "dateTimePickerDataLocacao";
            this.dateTimePickerDataLocacao.Size = new System.Drawing.Size(98, 23);
            this.dateTimePickerDataLocacao.TabIndex = 4;
            // 
            // dateTimePickerDataPrevistaDevolucao
            // 
            this.dateTimePickerDataPrevistaDevolucao.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerDataPrevistaDevolucao.Location = new System.Drawing.Point(176, 428);
            this.dateTimePickerDataPrevistaDevolucao.Name = "dateTimePickerDataPrevistaDevolucao";
            this.dateTimePickerDataPrevistaDevolucao.Size = new System.Drawing.Size(98, 23);
            this.dateTimePickerDataPrevistaDevolucao.TabIndex = 5;
            // 
            // comboBoxPlanoCobranca
            // 
            this.comboBoxPlanoCobranca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPlanoCobranca.FormattingEnabled = true;
            this.comboBoxPlanoCobranca.ItemHeight = 15;
            this.comboBoxPlanoCobranca.Location = new System.Drawing.Point(176, 463);
            this.comboBoxPlanoCobranca.Name = "comboBoxPlanoCobranca";
            this.comboBoxPlanoCobranca.Size = new System.Drawing.Size(236, 23);
            this.comboBoxPlanoCobranca.TabIndex = 6;
            // 
            // labelPlanoCobranca
            // 
            this.labelPlanoCobranca.AutoSize = true;
            this.labelPlanoCobranca.Location = new System.Drawing.Point(51, 466);
            this.labelPlanoCobranca.Name = "labelPlanoCobranca";
            this.labelPlanoCobranca.Size = new System.Drawing.Size(108, 15);
            this.labelPlanoCobranca.TabIndex = 12;
            this.labelPlanoCobranca.Text = "Plano de cobrança:";
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancelar.Location = new System.Drawing.Point(374, 518);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(67, 33);
            this.buttonCancelar.TabIndex = 8;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            // 
            // buttonGravar
            // 
            this.buttonGravar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonGravar.Location = new System.Drawing.Point(301, 518);
            this.buttonGravar.Name = "buttonGravar";
            this.buttonGravar.Size = new System.Drawing.Size(67, 33);
            this.buttonGravar.TabIndex = 7;
            this.buttonGravar.Text = "Gravar";
            this.buttonGravar.UseVisualStyleBackColor = true;
            // 
            // TelaCadastroLocacaoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 556);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonGravar);
            this.Controls.Add(this.groupBoxLocacao);
            this.Name = "TelaCadastroLocacaoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Locação";
            this.groupBoxLocacao.ResumeLayout(false);
            this.groupBoxLocacao.PerformLayout();
            this.groupBoxTaxa.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxLocacao;
        private System.Windows.Forms.Label labelDataLocacao;
        private System.Windows.Forms.ComboBox comboBoxVeiculo;
        private System.Windows.Forms.Label labelVeiculo;
        private System.Windows.Forms.ComboBox comboBoxCliente;
        private System.Windows.Forms.Label labelCliente;
        private System.Windows.Forms.TextBox textBoxNome;
        private System.Windows.Forms.Label labelNome;
        private System.Windows.Forms.GroupBox groupBoxTaxa;
        private System.Windows.Forms.CheckedListBox checkedListBoxTaxas;
        private System.Windows.Forms.ComboBox comboBoxPlanoCobranca;
        private System.Windows.Forms.Label labelPlanoCobranca;
        private System.Windows.Forms.DateTimePicker dateTimePickerDataPrevistaDevolucao;
        private System.Windows.Forms.DateTimePicker dateTimePickerDataLocacao;
        private System.Windows.Forms.Label labelDevolucao;
        public System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Button buttonGravar;
    }
}