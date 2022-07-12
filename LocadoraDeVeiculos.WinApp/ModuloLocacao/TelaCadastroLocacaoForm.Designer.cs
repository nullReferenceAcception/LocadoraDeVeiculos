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
            this.comboBoxPlanoCobranca = new System.Windows.Forms.ComboBox();
            this.labelPlanoCobranca = new System.Windows.Forms.Label();
            this.dateTimePickerDataPrevistaDevolucao = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerDataLocacao = new System.Windows.Forms.DateTimePicker();
            this.labelDevolucao = new System.Windows.Forms.Label();
            this.labelDataLocacao = new System.Windows.Forms.Label();
            this.comboBoxVeiculo = new System.Windows.Forms.ComboBox();
            this.labelVeiculo = new System.Windows.Forms.Label();
            this.comboBoxCliente = new System.Windows.Forms.ComboBox();
            this.labelCliente = new System.Windows.Forms.Label();
            this.textBoxNome = new System.Windows.Forms.TextBox();
            this.labelNome = new System.Windows.Forms.Label();
            this.groupBoxTaxa = new System.Windows.Forms.GroupBox();
            this.checkedListBoxTaxas = new System.Windows.Forms.CheckedListBox();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.buttonGravar = new System.Windows.Forms.Button();
            this.labelGuid = new System.Windows.Forms.Label();
            this.textBoxGuid = new System.Windows.Forms.TextBox();
            this.groupBoxLocacao.SuspendLayout();
            this.groupBoxTaxa.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxLocacao
            // 
            this.groupBoxLocacao.Controls.Add(this.labelGuid);
            this.groupBoxLocacao.Controls.Add(this.textBoxGuid);
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
            this.groupBoxLocacao.Size = new System.Drawing.Size(426, 522);
            this.groupBoxLocacao.TabIndex = 0;
            this.groupBoxLocacao.TabStop = false;
            this.groupBoxLocacao.Text = "Dados da locação:";
            // 
            // comboBoxPlanoCobranca
            // 
            this.comboBoxPlanoCobranca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPlanoCobranca.FormattingEnabled = true;
            this.comboBoxPlanoCobranca.ItemHeight = 15;
            this.comboBoxPlanoCobranca.Location = new System.Drawing.Point(173, 491);
            this.comboBoxPlanoCobranca.Name = "comboBoxPlanoCobranca";
            this.comboBoxPlanoCobranca.Size = new System.Drawing.Size(236, 23);
            this.comboBoxPlanoCobranca.TabIndex = 6;
            // 
            // labelPlanoCobranca
            // 
            this.labelPlanoCobranca.AutoSize = true;
            this.labelPlanoCobranca.Location = new System.Drawing.Point(48, 494);
            this.labelPlanoCobranca.Name = "labelPlanoCobranca";
            this.labelPlanoCobranca.Size = new System.Drawing.Size(108, 15);
            this.labelPlanoCobranca.TabIndex = 12;
            this.labelPlanoCobranca.Text = "Plano de cobrança:";
            // 
            // dateTimePickerDataPrevistaDevolucao
            // 
            this.dateTimePickerDataPrevistaDevolucao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dateTimePickerDataPrevistaDevolucao.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerDataPrevistaDevolucao.Location = new System.Drawing.Point(173, 456);
            this.dateTimePickerDataPrevistaDevolucao.Name = "dateTimePickerDataPrevistaDevolucao";
            this.dateTimePickerDataPrevistaDevolucao.Size = new System.Drawing.Size(98, 23);
            this.dateTimePickerDataPrevistaDevolucao.TabIndex = 5;
            // 
            // dateTimePickerDataLocacao
            // 
            this.dateTimePickerDataLocacao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dateTimePickerDataLocacao.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerDataLocacao.Location = new System.Drawing.Point(173, 423);
            this.dateTimePickerDataLocacao.Name = "dateTimePickerDataLocacao";
            this.dateTimePickerDataLocacao.Size = new System.Drawing.Size(98, 23);
            this.dateTimePickerDataLocacao.TabIndex = 4;
            // 
            // labelDevolucao
            // 
            this.labelDevolucao.AutoSize = true;
            this.labelDevolucao.Location = new System.Drawing.Point(4, 462);
            this.labelDevolucao.Name = "labelDevolucao";
            this.labelDevolucao.Size = new System.Drawing.Size(152, 15);
            this.labelDevolucao.TabIndex = 8;
            this.labelDevolucao.Text = "Data presvita de devolução:";
            // 
            // labelDataLocacao
            // 
            this.labelDataLocacao.AutoSize = true;
            this.labelDataLocacao.Location = new System.Drawing.Point(62, 429);
            this.labelDataLocacao.Name = "labelDataLocacao";
            this.labelDataLocacao.Size = new System.Drawing.Size(94, 15);
            this.labelDataLocacao.TabIndex = 7;
            this.labelDataLocacao.Text = "Data de locação:";
            // 
            // comboBoxVeiculo
            // 
            this.comboBoxVeiculo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxVeiculo.FormattingEnabled = true;
            this.comboBoxVeiculo.Location = new System.Drawing.Point(173, 120);
            this.comboBoxVeiculo.Name = "comboBoxVeiculo";
            this.comboBoxVeiculo.Size = new System.Drawing.Size(236, 23);
            this.comboBoxVeiculo.TabIndex = 2;
            // 
            // labelVeiculo
            // 
            this.labelVeiculo.AutoSize = true;
            this.labelVeiculo.Location = new System.Drawing.Point(108, 123);
            this.labelVeiculo.Name = "labelVeiculo";
            this.labelVeiculo.Size = new System.Drawing.Size(48, 15);
            this.labelVeiculo.TabIndex = 4;
            this.labelVeiculo.Text = "Veículo:";
            // 
            // comboBoxCliente
            // 
            this.comboBoxCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCliente.FormattingEnabled = true;
            this.comboBoxCliente.Location = new System.Drawing.Point(173, 90);
            this.comboBoxCliente.Name = "comboBoxCliente";
            this.comboBoxCliente.Size = new System.Drawing.Size(236, 23);
            this.comboBoxCliente.TabIndex = 1;
            // 
            // labelCliente
            // 
            this.labelCliente.AutoSize = true;
            this.labelCliente.Location = new System.Drawing.Point(106, 93);
            this.labelCliente.Name = "labelCliente";
            this.labelCliente.Size = new System.Drawing.Size(50, 15);
            this.labelCliente.TabIndex = 2;
            this.labelCliente.Text = "Clilente:";
            // 
            // textBoxNome
            // 
            this.textBoxNome.Location = new System.Drawing.Point(173, 56);
            this.textBoxNome.MaxLength = 255;
            this.textBoxNome.Name = "textBoxNome";
            this.textBoxNome.Size = new System.Drawing.Size(180, 23);
            this.textBoxNome.TabIndex = 0;
            // 
            // labelNome
            // 
            this.labelNome.AutoSize = true;
            this.labelNome.Location = new System.Drawing.Point(113, 59);
            this.labelNome.Name = "labelNome";
            this.labelNome.Size = new System.Drawing.Size(43, 15);
            this.labelNome.TabIndex = 0;
            this.labelNome.Text = "Nome:";
            // 
            // groupBoxTaxa
            // 
            this.groupBoxTaxa.Controls.Add(this.checkedListBoxTaxas);
            this.groupBoxTaxa.Location = new System.Drawing.Point(108, 149);
            this.groupBoxTaxa.Name = "groupBoxTaxa";
            this.groupBoxTaxa.Size = new System.Drawing.Size(301, 261);
            this.groupBoxTaxa.TabIndex = 6;
            this.groupBoxTaxa.TabStop = false;
            this.groupBoxTaxa.Text = "Taxas:";
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
            // buttonCancelar
            // 
            this.buttonCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancelar.Location = new System.Drawing.Point(371, 540);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(67, 33);
            this.buttonCancelar.TabIndex = 8;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            // 
            // buttonGravar
            // 
            this.buttonGravar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonGravar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonGravar.Location = new System.Drawing.Point(298, 540);
            this.buttonGravar.Name = "buttonGravar";
            this.buttonGravar.Size = new System.Drawing.Size(67, 33);
            this.buttonGravar.TabIndex = 7;
            this.buttonGravar.Text = "Gravar";
            this.buttonGravar.UseVisualStyleBackColor = true;
            // 
            // labelGuid
            // 
            this.labelGuid.AutoSize = true;
            this.labelGuid.Location = new System.Drawing.Point(121, 33);
            this.labelGuid.Name = "labelGuid";
            this.labelGuid.Size = new System.Drawing.Size(35, 15);
            this.labelGuid.TabIndex = 29;
            this.labelGuid.Text = "Guid:";
            // 
            // textBoxGuid
            // 
            this.textBoxGuid.Enabled = false;
            this.textBoxGuid.Location = new System.Drawing.Point(173, 30);
            this.textBoxGuid.Name = "textBoxGuid";
            this.textBoxGuid.ReadOnly = true;
            this.textBoxGuid.Size = new System.Drawing.Size(233, 23);
            this.textBoxGuid.TabIndex = 30;
            // 
            // TelaCadastroLocacaoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 582);
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
        private System.Windows.Forms.Label labelGuid;
        private System.Windows.Forms.TextBox textBoxGuid;
    }
}