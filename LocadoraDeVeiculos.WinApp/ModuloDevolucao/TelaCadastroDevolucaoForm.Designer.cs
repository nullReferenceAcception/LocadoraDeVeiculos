namespace LocadoraDeVeiculos.WinApp.ModuloDevolucao
{
    partial class TelaCadastroDevolucaoForm
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
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.buttonGravar = new System.Windows.Forms.Button();
            this.groupBoxDevolucao = new System.Windows.Forms.GroupBox();
            this.groupBoxValorTotal = new System.Windows.Forms.GroupBox();
            this.textBoxValorTotal = new System.Windows.Forms.TextBox();
            this.tabControlTaxas = new System.Windows.Forms.TabControl();
            this.tabPageTaxasJaSelecionadas = new System.Windows.Forms.TabPage();
            this.tabPageAdicionais = new System.Windows.Forms.TabPage();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.labelTanque = new System.Windows.Forms.Label();
            this.dateTimePickerDataDevolucaoReal = new System.Windows.Forms.DateTimePicker();
            this.labelDataDevolucao = new System.Windows.Forms.Label();
            this.textBoxKmVeiculo = new System.Windows.Forms.TextBox();
            this.labelKmVeiculo = new System.Windows.Forms.Label();
            this.labelDevolucao = new System.Windows.Forms.Label();
            this.dateTimePickerDataDevolucaoPrevista = new System.Windows.Forms.DateTimePicker();
            this.labelDataLocacao = new System.Windows.Forms.Label();
            this.dateTimePickerDataLocacao = new System.Windows.Forms.DateTimePicker();
            this.textBoxPlanoCobranca = new System.Windows.Forms.TextBox();
            this.labelPlanoCobranca = new System.Windows.Forms.Label();
            this.textBoxVeiculo = new System.Windows.Forms.TextBox();
            this.labelVeiculo = new System.Windows.Forms.Label();
            this.textBoxGrupoVeiculo = new System.Windows.Forms.TextBox();
            this.labelGrupoVeiculo = new System.Windows.Forms.Label();
            this.textBoxCondutor = new System.Windows.Forms.TextBox();
            this.labelCondutor = new System.Windows.Forms.Label();
            this.textBoxFuncionario = new System.Windows.Forms.TextBox();
            this.labelFuncionario = new System.Windows.Forms.Label();
            this.textBoxGuid = new System.Windows.Forms.TextBox();
            this.labelGuid = new System.Windows.Forms.Label();
            this.groupBoxDevolucao.SuspendLayout();
            this.groupBoxValorTotal.SuspendLayout();
            this.tabControlTaxas.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancelar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.buttonCancelar.Location = new System.Drawing.Point(645, 530);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(67, 33);
            this.buttonCancelar.TabIndex = 4;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            // 
            // buttonGravar
            // 
            this.buttonGravar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonGravar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonGravar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.buttonGravar.Location = new System.Drawing.Point(572, 530);
            this.buttonGravar.Name = "buttonGravar";
            this.buttonGravar.Size = new System.Drawing.Size(67, 33);
            this.buttonGravar.TabIndex = 3;
            this.buttonGravar.Text = "Gravar";
            this.buttonGravar.UseVisualStyleBackColor = true;
            this.buttonGravar.Click += new System.EventHandler(this.buttonGravar_Click);
            // 
            // groupBoxDevolucao
            // 
            this.groupBoxDevolucao.Controls.Add(this.groupBoxValorTotal);
            this.groupBoxDevolucao.Controls.Add(this.tabControlTaxas);
            this.groupBoxDevolucao.Controls.Add(this.comboBox1);
            this.groupBoxDevolucao.Controls.Add(this.labelTanque);
            this.groupBoxDevolucao.Controls.Add(this.dateTimePickerDataDevolucaoReal);
            this.groupBoxDevolucao.Controls.Add(this.labelDataDevolucao);
            this.groupBoxDevolucao.Controls.Add(this.textBoxKmVeiculo);
            this.groupBoxDevolucao.Controls.Add(this.labelKmVeiculo);
            this.groupBoxDevolucao.Controls.Add(this.labelDevolucao);
            this.groupBoxDevolucao.Controls.Add(this.dateTimePickerDataDevolucaoPrevista);
            this.groupBoxDevolucao.Controls.Add(this.labelDataLocacao);
            this.groupBoxDevolucao.Controls.Add(this.dateTimePickerDataLocacao);
            this.groupBoxDevolucao.Controls.Add(this.textBoxPlanoCobranca);
            this.groupBoxDevolucao.Controls.Add(this.labelPlanoCobranca);
            this.groupBoxDevolucao.Controls.Add(this.textBoxVeiculo);
            this.groupBoxDevolucao.Controls.Add(this.labelVeiculo);
            this.groupBoxDevolucao.Controls.Add(this.textBoxGrupoVeiculo);
            this.groupBoxDevolucao.Controls.Add(this.labelGrupoVeiculo);
            this.groupBoxDevolucao.Controls.Add(this.textBoxCondutor);
            this.groupBoxDevolucao.Controls.Add(this.labelCondutor);
            this.groupBoxDevolucao.Controls.Add(this.textBoxFuncionario);
            this.groupBoxDevolucao.Controls.Add(this.labelFuncionario);
            this.groupBoxDevolucao.Controls.Add(this.textBoxGuid);
            this.groupBoxDevolucao.Controls.Add(this.labelGuid);
            this.groupBoxDevolucao.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.groupBoxDevolucao.Location = new System.Drawing.Point(12, 12);
            this.groupBoxDevolucao.Name = "groupBoxDevolucao";
            this.groupBoxDevolucao.Size = new System.Drawing.Size(703, 512);
            this.groupBoxDevolucao.TabIndex = 15;
            this.groupBoxDevolucao.TabStop = false;
            this.groupBoxDevolucao.Text = "Dados da devolução:";
            // 
            // groupBoxValorTotal
            // 
            this.groupBoxValorTotal.Controls.Add(this.textBoxValorTotal);
            this.groupBoxValorTotal.Location = new System.Drawing.Point(301, 392);
            this.groupBoxValorTotal.Name = "groupBoxValorTotal";
            this.groupBoxValorTotal.Size = new System.Drawing.Size(387, 100);
            this.groupBoxValorTotal.TabIndex = 50;
            this.groupBoxValorTotal.TabStop = false;
            this.groupBoxValorTotal.Text = "Valor Total (R$):";
            // 
            // textBoxValorTotal
            // 
            this.textBoxValorTotal.Enabled = false;
            this.textBoxValorTotal.Location = new System.Drawing.Point(120, 44);
            this.textBoxValorTotal.Name = "textBoxValorTotal";
            this.textBoxValorTotal.ReadOnly = true;
            this.textBoxValorTotal.Size = new System.Drawing.Size(155, 23);
            this.textBoxValorTotal.TabIndex = 0;
            this.textBoxValorTotal.TabStop = false;
            // 
            // tabControlTaxas
            // 
            this.tabControlTaxas.Controls.Add(this.tabPageTaxasJaSelecionadas);
            this.tabControlTaxas.Controls.Add(this.tabPageAdicionais);
            this.tabControlTaxas.Location = new System.Drawing.Point(297, 19);
            this.tabControlTaxas.Name = "tabControlTaxas";
            this.tabControlTaxas.SelectedIndex = 0;
            this.tabControlTaxas.Size = new System.Drawing.Size(395, 367);
            this.tabControlTaxas.TabIndex = 49;
            // 
            // tabPageTaxasJaSelecionadas
            // 
            this.tabPageTaxasJaSelecionadas.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabPageTaxasJaSelecionadas.Location = new System.Drawing.Point(4, 24);
            this.tabPageTaxasJaSelecionadas.Name = "tabPageTaxasJaSelecionadas";
            this.tabPageTaxasJaSelecionadas.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTaxasJaSelecionadas.Size = new System.Drawing.Size(387, 339);
            this.tabPageTaxasJaSelecionadas.TabIndex = 0;
            this.tabPageTaxasJaSelecionadas.Text = "Taxas já selecionadas";
            this.tabPageTaxasJaSelecionadas.UseVisualStyleBackColor = true;
            // 
            // tabPageAdicionais
            // 
            this.tabPageAdicionais.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabPageAdicionais.Location = new System.Drawing.Point(4, 24);
            this.tabPageAdicionais.Name = "tabPageAdicionais";
            this.tabPageAdicionais.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAdicionais.Size = new System.Drawing.Size(387, 339);
            this.tabPageAdicionais.TabIndex = 1;
            this.tabPageAdicionais.Text = "Taxas adicionais";
            this.tabPageAdicionais.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(6, 477);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(152, 23);
            this.comboBox1.TabIndex = 2;
            // 
            // labelTanque
            // 
            this.labelTanque.AutoSize = true;
            this.labelTanque.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelTanque.Location = new System.Drawing.Point(6, 459);
            this.labelTanque.Name = "labelTanque";
            this.labelTanque.Size = new System.Drawing.Size(181, 15);
            this.labelTanque.TabIndex = 47;
            this.labelTanque.Text = "Nível do Tanque de Combustível:";
            // 
            // dateTimePickerDataDevolucaoReal
            // 
            this.dateTimePickerDataDevolucaoReal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dateTimePickerDataDevolucaoReal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerDataDevolucaoReal.Location = new System.Drawing.Point(6, 433);
            this.dateTimePickerDataDevolucaoReal.Name = "dateTimePickerDataDevolucaoReal";
            this.dateTimePickerDataDevolucaoReal.Size = new System.Drawing.Size(100, 23);
            this.dateTimePickerDataDevolucaoReal.TabIndex = 1;
            // 
            // labelDataDevolucao
            // 
            this.labelDataDevolucao.AutoSize = true;
            this.labelDataDevolucao.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelDataDevolucao.Location = new System.Drawing.Point(6, 415);
            this.labelDataDevolucao.Name = "labelDataDevolucao";
            this.labelDataDevolucao.Size = new System.Drawing.Size(109, 15);
            this.labelDataDevolucao.TabIndex = 45;
            this.labelDataDevolucao.Text = "Data de Devolução:";
            // 
            // textBoxKmVeiculo
            // 
            this.textBoxKmVeiculo.Location = new System.Drawing.Point(6, 389);
            this.textBoxKmVeiculo.Name = "textBoxKmVeiculo";
            this.textBoxKmVeiculo.Size = new System.Drawing.Size(100, 23);
            this.textBoxKmVeiculo.TabIndex = 0;
            // 
            // labelKmVeiculo
            // 
            this.labelKmVeiculo.AutoSize = true;
            this.labelKmVeiculo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelKmVeiculo.Location = new System.Drawing.Point(6, 371);
            this.labelKmVeiculo.Name = "labelKmVeiculo";
            this.labelKmVeiculo.Size = new System.Drawing.Size(152, 15);
            this.labelKmVeiculo.TabIndex = 43;
            this.labelKmVeiculo.Text = "Quilometragem do Veículo:";
            // 
            // labelDevolucao
            // 
            this.labelDevolucao.AutoSize = true;
            this.labelDevolucao.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelDevolucao.Location = new System.Drawing.Point(6, 327);
            this.labelDevolucao.Name = "labelDevolucao";
            this.labelDevolucao.Size = new System.Drawing.Size(110, 15);
            this.labelDevolucao.TabIndex = 42;
            this.labelDevolucao.Text = "Devolução prevista:";
            // 
            // dateTimePickerDataDevolucaoPrevista
            // 
            this.dateTimePickerDataDevolucaoPrevista.Enabled = false;
            this.dateTimePickerDataDevolucaoPrevista.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dateTimePickerDataDevolucaoPrevista.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerDataDevolucaoPrevista.Location = new System.Drawing.Point(6, 345);
            this.dateTimePickerDataDevolucaoPrevista.Name = "dateTimePickerDataDevolucaoPrevista";
            this.dateTimePickerDataDevolucaoPrevista.Size = new System.Drawing.Size(105, 23);
            this.dateTimePickerDataDevolucaoPrevista.TabIndex = 1;
            // 
            // labelDataLocacao
            // 
            this.labelDataLocacao.AutoSize = true;
            this.labelDataLocacao.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelDataLocacao.Location = new System.Drawing.Point(6, 283);
            this.labelDataLocacao.Name = "labelDataLocacao";
            this.labelDataLocacao.Size = new System.Drawing.Size(54, 15);
            this.labelDataLocacao.TabIndex = 40;
            this.labelDataLocacao.Text = "Locação:";
            // 
            // dateTimePickerDataLocacao
            // 
            this.dateTimePickerDataLocacao.Enabled = false;
            this.dateTimePickerDataLocacao.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dateTimePickerDataLocacao.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerDataLocacao.Location = new System.Drawing.Point(6, 301);
            this.dateTimePickerDataLocacao.Name = "dateTimePickerDataLocacao";
            this.dateTimePickerDataLocacao.Size = new System.Drawing.Size(105, 23);
            this.dateTimePickerDataLocacao.TabIndex = 0;
            // 
            // textBoxPlanoCobranca
            // 
            this.textBoxPlanoCobranca.Enabled = false;
            this.textBoxPlanoCobranca.Location = new System.Drawing.Point(6, 257);
            this.textBoxPlanoCobranca.Name = "textBoxPlanoCobranca";
            this.textBoxPlanoCobranca.ReadOnly = true;
            this.textBoxPlanoCobranca.Size = new System.Drawing.Size(265, 23);
            this.textBoxPlanoCobranca.TabIndex = 38;
            this.textBoxPlanoCobranca.TabStop = false;
            // 
            // labelPlanoCobranca
            // 
            this.labelPlanoCobranca.AutoSize = true;
            this.labelPlanoCobranca.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelPlanoCobranca.Location = new System.Drawing.Point(6, 239);
            this.labelPlanoCobranca.Name = "labelPlanoCobranca";
            this.labelPlanoCobranca.Size = new System.Drawing.Size(110, 15);
            this.labelPlanoCobranca.TabIndex = 37;
            this.labelPlanoCobranca.Text = "Plano de Cobrança:";
            // 
            // textBoxVeiculo
            // 
            this.textBoxVeiculo.Enabled = false;
            this.textBoxVeiculo.Location = new System.Drawing.Point(6, 213);
            this.textBoxVeiculo.Name = "textBoxVeiculo";
            this.textBoxVeiculo.ReadOnly = true;
            this.textBoxVeiculo.Size = new System.Drawing.Size(265, 23);
            this.textBoxVeiculo.TabIndex = 36;
            this.textBoxVeiculo.TabStop = false;
            // 
            // labelVeiculo
            // 
            this.labelVeiculo.AutoSize = true;
            this.labelVeiculo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelVeiculo.Location = new System.Drawing.Point(6, 195);
            this.labelVeiculo.Name = "labelVeiculo";
            this.labelVeiculo.Size = new System.Drawing.Size(48, 15);
            this.labelVeiculo.TabIndex = 35;
            this.labelVeiculo.Text = "Veículo:";
            // 
            // textBoxGrupoVeiculo
            // 
            this.textBoxGrupoVeiculo.Enabled = false;
            this.textBoxGrupoVeiculo.Location = new System.Drawing.Point(6, 169);
            this.textBoxGrupoVeiculo.Name = "textBoxGrupoVeiculo";
            this.textBoxGrupoVeiculo.ReadOnly = true;
            this.textBoxGrupoVeiculo.Size = new System.Drawing.Size(265, 23);
            this.textBoxGrupoVeiculo.TabIndex = 34;
            this.textBoxGrupoVeiculo.TabStop = false;
            // 
            // labelGrupoVeiculo
            // 
            this.labelGrupoVeiculo.AutoSize = true;
            this.labelGrupoVeiculo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelGrupoVeiculo.Location = new System.Drawing.Point(6, 151);
            this.labelGrupoVeiculo.Name = "labelGrupoVeiculo";
            this.labelGrupoVeiculo.Size = new System.Drawing.Size(105, 15);
            this.labelGrupoVeiculo.TabIndex = 33;
            this.labelGrupoVeiculo.Text = "Grupo de Veículos:";
            // 
            // textBoxCondutor
            // 
            this.textBoxCondutor.Enabled = false;
            this.textBoxCondutor.Location = new System.Drawing.Point(6, 125);
            this.textBoxCondutor.Name = "textBoxCondutor";
            this.textBoxCondutor.ReadOnly = true;
            this.textBoxCondutor.Size = new System.Drawing.Size(265, 23);
            this.textBoxCondutor.TabIndex = 32;
            this.textBoxCondutor.TabStop = false;
            // 
            // labelCondutor
            // 
            this.labelCondutor.AutoSize = true;
            this.labelCondutor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelCondutor.Location = new System.Drawing.Point(6, 107);
            this.labelCondutor.Name = "labelCondutor";
            this.labelCondutor.Size = new System.Drawing.Size(61, 15);
            this.labelCondutor.TabIndex = 31;
            this.labelCondutor.Text = "Condutor:";
            // 
            // textBoxFuncionario
            // 
            this.textBoxFuncionario.Enabled = false;
            this.textBoxFuncionario.Location = new System.Drawing.Point(6, 81);
            this.textBoxFuncionario.Name = "textBoxFuncionario";
            this.textBoxFuncionario.ReadOnly = true;
            this.textBoxFuncionario.Size = new System.Drawing.Size(265, 23);
            this.textBoxFuncionario.TabIndex = 30;
            this.textBoxFuncionario.TabStop = false;
            // 
            // labelFuncionario
            // 
            this.labelFuncionario.AutoSize = true;
            this.labelFuncionario.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelFuncionario.Location = new System.Drawing.Point(6, 63);
            this.labelFuncionario.Name = "labelFuncionario";
            this.labelFuncionario.Size = new System.Drawing.Size(73, 15);
            this.labelFuncionario.TabIndex = 29;
            this.labelFuncionario.Text = "Funcionário:";
            // 
            // textBoxGuid
            // 
            this.textBoxGuid.Enabled = false;
            this.textBoxGuid.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxGuid.Location = new System.Drawing.Point(6, 37);
            this.textBoxGuid.Name = "textBoxGuid";
            this.textBoxGuid.ReadOnly = true;
            this.textBoxGuid.Size = new System.Drawing.Size(265, 23);
            this.textBoxGuid.TabIndex = 0;
            this.textBoxGuid.TabStop = false;
            // 
            // labelGuid
            // 
            this.labelGuid.AutoSize = true;
            this.labelGuid.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelGuid.Location = new System.Drawing.Point(6, 19);
            this.labelGuid.Name = "labelGuid";
            this.labelGuid.Size = new System.Drawing.Size(35, 15);
            this.labelGuid.TabIndex = 28;
            this.labelGuid.Text = "Guid:";
            // 
            // TelaCadastroDevolucaoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 571);
            this.Controls.Add(this.groupBoxDevolucao);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonGravar);
            this.Name = "TelaCadastroDevolucaoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Devolução:";
            this.groupBoxDevolucao.ResumeLayout(false);
            this.groupBoxDevolucao.PerformLayout();
            this.groupBoxValorTotal.ResumeLayout(false);
            this.groupBoxValorTotal.PerformLayout();
            this.tabControlTaxas.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Button buttonGravar;
        private System.Windows.Forms.GroupBox groupBoxDevolucao;
        private System.Windows.Forms.TextBox textBoxGuid;
        private System.Windows.Forms.Label labelGuid;
        private System.Windows.Forms.GroupBox groupBoxValorTotal;
        private System.Windows.Forms.TextBox textBoxValorTotal;
        private System.Windows.Forms.TabControl tabControlTaxas;
        private System.Windows.Forms.TabPage tabPageTaxasJaSelecionadas;
        private System.Windows.Forms.TabPage tabPageAdicionais;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label labelTanque;
        private System.Windows.Forms.DateTimePicker dateTimePickerDataDevolucaoReal;
        private System.Windows.Forms.Label labelDataDevolucao;
        private System.Windows.Forms.TextBox textBoxKmVeiculo;
        private System.Windows.Forms.Label labelKmVeiculo;
        private System.Windows.Forms.Label labelDevolucao;
        private System.Windows.Forms.DateTimePicker dateTimePickerDataDevolucaoPrevista;
        private System.Windows.Forms.Label labelDataLocacao;
        private System.Windows.Forms.DateTimePicker dateTimePickerDataLocacao;
        private System.Windows.Forms.TextBox textBoxPlanoCobranca;
        private System.Windows.Forms.Label labelPlanoCobranca;
        private System.Windows.Forms.TextBox textBoxVeiculo;
        private System.Windows.Forms.Label labelVeiculo;
        private System.Windows.Forms.TextBox textBoxGrupoVeiculo;
        private System.Windows.Forms.Label labelGrupoVeiculo;
        private System.Windows.Forms.TextBox textBoxCondutor;
        private System.Windows.Forms.Label labelCondutor;
        private System.Windows.Forms.TextBox textBoxFuncionario;
        private System.Windows.Forms.Label labelFuncionario;
    }
}