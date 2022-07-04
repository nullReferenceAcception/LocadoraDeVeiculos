namespace LocadoraDeVeiculos.WinApp.ModuloCliente
{
    partial class TelaCadastroClienteForm
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
            this.textBoxNome = new System.Windows.Forms.TextBox();
            this.textBoxEndereco = new System.Windows.Forms.TextBox();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.labelNome = new System.Windows.Forms.Label();
            this.labelTelefone = new System.Windows.Forms.Label();
            this.labelEmail = new System.Windows.Forms.Label();
            this.labelCNH = new System.Windows.Forms.Label();
            this.labelEndereco = new System.Windows.Forms.Label();
            this.groupBoxTipoCliente = new System.Windows.Forms.GroupBox();
            this.radioButtonCNPJ = new System.Windows.Forms.RadioButton();
            this.radioButtonCPF = new System.Windows.Forms.RadioButton();
            this.labelCPF = new System.Windows.Forms.Label();
            this.labelCNPJ = new System.Windows.Forms.Label();
            this.buttonGravar = new System.Windows.Forms.Button();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.maskedTextBoxCPF = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBoxCNPJ = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBoxTelefone = new System.Windows.Forms.MaskedTextBox();
            this.groupBoxDadosCliente = new System.Windows.Forms.GroupBox();
            this.maskedTextBoxCNH = new System.Windows.Forms.MaskedTextBox();
            this.dateTimePickerValidadeCNH = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.groupBoxTipoCliente.SuspendLayout();
            this.groupBoxDadosCliente.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxNome
            // 
            this.textBoxNome.Location = new System.Drawing.Point(105, 45);
            this.textBoxNome.MaxLength = 100;
            this.textBoxNome.Name = "textBoxNome";
            this.textBoxNome.Size = new System.Drawing.Size(239, 23);
            this.textBoxNome.TabIndex = 0;
            // 
            // textBoxEndereco
            // 
            this.textBoxEndereco.Location = new System.Drawing.Point(105, 74);
            this.textBoxEndereco.MaxLength = 100;
            this.textBoxEndereco.Name = "textBoxEndereco";
            this.textBoxEndereco.Size = new System.Drawing.Size(239, 23);
            this.textBoxEndereco.TabIndex = 1;
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(108, 170);
            this.textBoxEmail.MaxLength = 100;
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(239, 23);
            this.textBoxEmail.TabIndex = 4;
            // 
            // labelNome
            // 
            this.labelNome.AutoSize = true;
            this.labelNome.Location = new System.Drawing.Point(44, 48);
            this.labelNome.Name = "labelNome";
            this.labelNome.Size = new System.Drawing.Size(43, 15);
            this.labelNome.TabIndex = 6;
            this.labelNome.Text = "Nome:";
            // 
            // labelTelefone
            // 
            this.labelTelefone.AutoSize = true;
            this.labelTelefone.Location = new System.Drawing.Point(36, 202);
            this.labelTelefone.Name = "labelTelefone";
            this.labelTelefone.Size = new System.Drawing.Size(54, 15);
            this.labelTelefone.TabIndex = 9;
            this.labelTelefone.Text = "Telefone:";
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Location = new System.Drawing.Point(51, 170);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(39, 15);
            this.labelEmail.TabIndex = 10;
            this.labelEmail.Text = "Email:";
            // 
            // labelCNH
            // 
            this.labelCNH.AutoSize = true;
            this.labelCNH.Location = new System.Drawing.Point(51, 109);
            this.labelCNH.Name = "labelCNH";
            this.labelCNH.Size = new System.Drawing.Size(36, 15);
            this.labelCNH.TabIndex = 11;
            this.labelCNH.Text = "CNH:";
            // 
            // labelEndereco
            // 
            this.labelEndereco.AutoSize = true;
            this.labelEndereco.Location = new System.Drawing.Point(28, 77);
            this.labelEndereco.Name = "labelEndereco";
            this.labelEndereco.Size = new System.Drawing.Size(59, 15);
            this.labelEndereco.TabIndex = 12;
            this.labelEndereco.Text = "Endereço:";
            // 
            // groupBoxTipoCliente
            // 
            this.groupBoxTipoCliente.Controls.Add(this.radioButtonCNPJ);
            this.groupBoxTipoCliente.Controls.Add(this.radioButtonCPF);
            this.groupBoxTipoCliente.Location = new System.Drawing.Point(107, 228);
            this.groupBoxTipoCliente.Name = "groupBoxTipoCliente";
            this.groupBoxTipoCliente.Size = new System.Drawing.Size(133, 79);
            this.groupBoxTipoCliente.TabIndex = 6;
            this.groupBoxTipoCliente.TabStop = false;
            this.groupBoxTipoCliente.Text = "Tipo de cliente:";
            // 
            // radioButtonCNPJ
            // 
            this.radioButtonCNPJ.AutoSize = true;
            this.radioButtonCNPJ.Location = new System.Drawing.Point(19, 47);
            this.radioButtonCNPJ.Name = "radioButtonCNPJ";
            this.radioButtonCNPJ.Size = new System.Drawing.Size(104, 19);
            this.radioButtonCNPJ.TabIndex = 8;
            this.radioButtonCNPJ.TabStop = true;
            this.radioButtonCNPJ.Text = "Pessoa Jurídica";
            this.radioButtonCNPJ.UseVisualStyleBackColor = true;
            this.radioButtonCNPJ.CheckedChanged += new System.EventHandler(this.radioCNPJbtn_CheckedChanged);
            // 
            // radioButtonCPF
            // 
            this.radioButtonCPF.AutoSize = true;
            this.radioButtonCPF.Location = new System.Drawing.Point(19, 22);
            this.radioButtonCPF.Name = "radioButtonCPF";
            this.radioButtonCPF.Size = new System.Drawing.Size(93, 19);
            this.radioButtonCPF.TabIndex = 7;
            this.radioButtonCPF.TabStop = true;
            this.radioButtonCPF.Text = "Pessoa Fisica";
            this.radioButtonCPF.UseVisualStyleBackColor = true;
            this.radioButtonCPF.CheckedChanged += new System.EventHandler(this.radioCPFbtn_CheckedChanged);
            // 
            // labelCPF
            // 
            this.labelCPF.AutoSize = true;
            this.labelCPF.Location = new System.Drawing.Point(59, 317);
            this.labelCPF.Name = "labelCPF";
            this.labelCPF.Size = new System.Drawing.Size(31, 15);
            this.labelCPF.TabIndex = 15;
            this.labelCPF.Text = "CPF:";
            // 
            // labelCNPJ
            // 
            this.labelCNPJ.AutoSize = true;
            this.labelCNPJ.Location = new System.Drawing.Point(53, 348);
            this.labelCNPJ.Name = "labelCNPJ";
            this.labelCNPJ.Size = new System.Drawing.Size(37, 15);
            this.labelCNPJ.TabIndex = 16;
            this.labelCNPJ.Text = "CNPJ:";
            // 
            // buttonGravar
            // 
            this.buttonGravar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonGravar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonGravar.Location = new System.Drawing.Point(225, 389);
            this.buttonGravar.Name = "buttonGravar";
            this.buttonGravar.Size = new System.Drawing.Size(67, 33);
            this.buttonGravar.TabIndex = 11;
            this.buttonGravar.Text = "Gravar";
            this.buttonGravar.UseVisualStyleBackColor = true;
            this.buttonGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancelar.Location = new System.Drawing.Point(298, 389);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(67, 33);
            this.buttonCancelar.TabIndex = 12;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            // 
            // maskedTextBoxCPF
            // 
            this.maskedTextBoxCPF.Location = new System.Drawing.Point(107, 313);
            this.maskedTextBoxCPF.Mask = "000\\.000\\.000-00";
            this.maskedTextBoxCPF.Name = "maskedTextBoxCPF";
            this.maskedTextBoxCPF.Size = new System.Drawing.Size(140, 23);
            this.maskedTextBoxCPF.TabIndex = 9;
            this.maskedTextBoxCPF.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // maskedTextBoxCNPJ
            // 
            this.maskedTextBoxCNPJ.Location = new System.Drawing.Point(107, 342);
            this.maskedTextBoxCNPJ.Mask = "00\\.000\\.000/0000-00";
            this.maskedTextBoxCNPJ.Name = "maskedTextBoxCNPJ";
            this.maskedTextBoxCNPJ.Size = new System.Drawing.Size(140, 23);
            this.maskedTextBoxCNPJ.TabIndex = 10;
            this.maskedTextBoxCNPJ.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // maskedTextBoxTelefone
            // 
            this.maskedTextBoxTelefone.Location = new System.Drawing.Point(108, 199);
            this.maskedTextBoxTelefone.Mask = "(00) 90000-0000";
            this.maskedTextBoxTelefone.Name = "maskedTextBoxTelefone";
            this.maskedTextBoxTelefone.Size = new System.Drawing.Size(87, 23);
            this.maskedTextBoxTelefone.TabIndex = 5;
            this.maskedTextBoxTelefone.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // groupBoxDadosCliente
            // 
            this.groupBoxDadosCliente.Controls.Add(this.maskedTextBoxCNH);
            this.groupBoxDadosCliente.Controls.Add(this.dateTimePickerValidadeCNH);
            this.groupBoxDadosCliente.Controls.Add(this.label2);
            this.groupBoxDadosCliente.Controls.Add(this.maskedTextBoxTelefone);
            this.groupBoxDadosCliente.Controls.Add(this.label1);
            this.groupBoxDadosCliente.Controls.Add(this.textBoxID);
            this.groupBoxDadosCliente.Controls.Add(this.labelCPF);
            this.groupBoxDadosCliente.Controls.Add(this.groupBoxTipoCliente);
            this.groupBoxDadosCliente.Controls.Add(this.maskedTextBoxCNPJ);
            this.groupBoxDadosCliente.Controls.Add(this.labelEndereco);
            this.groupBoxDadosCliente.Controls.Add(this.labelCNPJ);
            this.groupBoxDadosCliente.Controls.Add(this.labelCNH);
            this.groupBoxDadosCliente.Controls.Add(this.maskedTextBoxCPF);
            this.groupBoxDadosCliente.Controls.Add(this.labelEmail);
            this.groupBoxDadosCliente.Controls.Add(this.textBoxNome);
            this.groupBoxDadosCliente.Controls.Add(this.labelTelefone);
            this.groupBoxDadosCliente.Controls.Add(this.textBoxEndereco);
            this.groupBoxDadosCliente.Controls.Add(this.labelNome);
            this.groupBoxDadosCliente.Controls.Add(this.textBoxEmail);
            this.groupBoxDadosCliente.Location = new System.Drawing.Point(12, 11);
            this.groupBoxDadosCliente.Name = "groupBoxDadosCliente";
            this.groupBoxDadosCliente.Size = new System.Drawing.Size(353, 372);
            this.groupBoxDadosCliente.TabIndex = 22;
            this.groupBoxDadosCliente.TabStop = false;
            this.groupBoxDadosCliente.Text = "Dados do cliente:";
            // 
            // maskedTextBoxCNH
            // 
            this.maskedTextBoxCNH.Location = new System.Drawing.Point(107, 106);
            this.maskedTextBoxCNH.Mask = "00000000000";
            this.maskedTextBoxCNH.Name = "maskedTextBoxCNH";
            this.maskedTextBoxCNH.Size = new System.Drawing.Size(75, 23);
            this.maskedTextBoxCNH.TabIndex = 2;
            // 
            // dateTimePickerValidadeCNH
            // 
            this.dateTimePickerValidadeCNH.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dateTimePickerValidadeCNH.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerValidadeCNH.Location = new System.Drawing.Point(107, 141);
            this.dateTimePickerValidadeCNH.Name = "dateTimePickerValidadeCNH";
            this.dateTimePickerValidadeCNH.Size = new System.Drawing.Size(100, 23);
            this.dateTimePickerValidadeCNH.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 15);
            this.label2.TabIndex = 26;
            this.label2.Text = "Validade CNH:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(66, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 15);
            this.label1.TabIndex = 24;
            this.label1.Text = "ID:";
            // 
            // textBoxID
            // 
            this.textBoxID.Enabled = false;
            this.textBoxID.Location = new System.Drawing.Point(104, 16);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.ReadOnly = true;
            this.textBoxID.Size = new System.Drawing.Size(75, 23);
            this.textBoxID.TabIndex = 23;
            // 
            // TelaCadastroClienteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 428);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonGravar);
            this.Controls.Add(this.groupBoxDadosCliente);
            this.Name = "TelaCadastroClienteForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cliente";
            this.groupBoxTipoCliente.ResumeLayout(false);
            this.groupBoxTipoCliente.PerformLayout();
            this.groupBoxDadosCliente.ResumeLayout(false);
            this.groupBoxDadosCliente.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelNome;
        private System.Windows.Forms.Label labelTelefone;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.Label labelCNH;
        private System.Windows.Forms.Label labelEndereco;
        private System.Windows.Forms.GroupBox groupBoxTipoCliente;
        private System.Windows.Forms.RadioButton radioButtonCNPJ;
        private System.Windows.Forms.RadioButton radioButtonCPF;
        private System.Windows.Forms.Label labelCPF;
        private System.Windows.Forms.Label labelCNPJ;
        private System.Windows.Forms.TextBox textBoxNome;
        private System.Windows.Forms.TextBox textBoxEndereco;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Button buttonGravar;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxCPF;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxCNPJ;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxTelefone;
        public System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.GroupBox groupBoxDadosCliente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePickerValidadeCNH;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxCNH;
    }
}