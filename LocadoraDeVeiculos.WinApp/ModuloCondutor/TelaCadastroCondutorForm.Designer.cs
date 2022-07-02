namespace LocadoraDeVeiculos.WinApp.ModuloCondutor
{
    partial class TelaCadastroCondutorForm
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
            this.labelCNH = new System.Windows.Forms.Label();
            this.labelEndereco = new System.Windows.Forms.Label();
            this.labelNome = new System.Windows.Forms.Label();
            this.labelEmpresa = new System.Windows.Forms.Label();
            this.labelEmail = new System.Windows.Forms.Label();
            this.labelValidadeCNH = new System.Windows.Forms.Label();
            this.labelTelefone = new System.Windows.Forms.Label();
            this.textBoxNome = new System.Windows.Forms.TextBox();
            this.textBoxEndereco = new System.Windows.Forms.TextBox();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.maskedTextBoxTelefone = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBoxCNH = new System.Windows.Forms.MaskedTextBox();
            this.comboBoxEmpresa = new System.Windows.Forms.ComboBox();
            this.dateTimePickerValidadeCNH = new System.Windows.Forms.DateTimePicker();
            this.buttonGravar = new System.Windows.Forms.Button();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.labelID = new System.Windows.Forms.Label();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.groupBoxCondutor = new System.Windows.Forms.GroupBox();
            this.labelCPF = new System.Windows.Forms.Label();
            this.maskedTextBoxCPF = new System.Windows.Forms.MaskedTextBox();
            this.groupBoxCondutor.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelCNH
            // 
            this.labelCNH.AutoSize = true;
            this.labelCNH.Location = new System.Drawing.Point(63, 176);
            this.labelCNH.Name = "labelCNH";
            this.labelCNH.Size = new System.Drawing.Size(36, 15);
            this.labelCNH.TabIndex = 2;
            this.labelCNH.Text = "CNH:";
            // 
            // labelEndereco
            // 
            this.labelEndereco.AutoSize = true;
            this.labelEndereco.Location = new System.Drawing.Point(40, 85);
            this.labelEndereco.Name = "labelEndereco";
            this.labelEndereco.Size = new System.Drawing.Size(59, 15);
            this.labelEndereco.TabIndex = 3;
            this.labelEndereco.Text = "Endereço:";
            // 
            // labelNome
            // 
            this.labelNome.AutoSize = true;
            this.labelNome.Location = new System.Drawing.Point(56, 56);
            this.labelNome.Name = "labelNome";
            this.labelNome.Size = new System.Drawing.Size(43, 15);
            this.labelNome.TabIndex = 4;
            this.labelNome.Text = "Nome:";
            // 
            // labelEmpresa
            // 
            this.labelEmpresa.AutoSize = true;
            this.labelEmpresa.Location = new System.Drawing.Point(40, 264);
            this.labelEmpresa.Name = "labelEmpresa";
            this.labelEmpresa.Size = new System.Drawing.Size(55, 15);
            this.labelEmpresa.TabIndex = 5;
            this.labelEmpresa.Text = "Empresa:";
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Location = new System.Drawing.Point(55, 235);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(44, 15);
            this.labelEmail.TabIndex = 6;
            this.labelEmail.Text = "E-mail:";
            // 
            // labelValidadeCNH
            // 
            this.labelValidadeCNH.AutoSize = true;
            this.labelValidadeCNH.Location = new System.Drawing.Point(16, 208);
            this.labelValidadeCNH.Name = "labelValidadeCNH";
            this.labelValidadeCNH.Size = new System.Drawing.Size(83, 15);
            this.labelValidadeCNH.TabIndex = 7;
            this.labelValidadeCNH.Text = "Validade CNH:";
            // 
            // labelTelefone
            // 
            this.labelTelefone.AutoSize = true;
            this.labelTelefone.Location = new System.Drawing.Point(45, 114);
            this.labelTelefone.Name = "labelTelefone";
            this.labelTelefone.Size = new System.Drawing.Size(54, 15);
            this.labelTelefone.TabIndex = 8;
            this.labelTelefone.Text = "Telefone:";
            // 
            // textBoxNome
            // 
            this.textBoxNome.Location = new System.Drawing.Point(117, 65);
            this.textBoxNome.MaxLength = 100;
            this.textBoxNome.Name = "textBoxNome";
            this.textBoxNome.Size = new System.Drawing.Size(163, 23);
            this.textBoxNome.TabIndex = 0;
            // 
            // textBoxEndereco
            // 
            this.textBoxEndereco.Location = new System.Drawing.Point(117, 94);
            this.textBoxEndereco.MaxLength = 100;
            this.textBoxEndereco.Name = "textBoxEndereco";
            this.textBoxEndereco.Size = new System.Drawing.Size(163, 23);
            this.textBoxEndereco.TabIndex = 1;
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(105, 232);
            this.textBoxEmail.MaxLength = 100;
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(163, 23);
            this.textBoxEmail.TabIndex = 6;
            // 
            // maskedTextBoxTelefone
            // 
            this.maskedTextBoxTelefone.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.maskedTextBoxTelefone.Location = new System.Drawing.Point(117, 123);
            this.maskedTextBoxTelefone.Mask = "(00) 90000-0000";
            this.maskedTextBoxTelefone.Name = "maskedTextBoxTelefone";
            this.maskedTextBoxTelefone.Size = new System.Drawing.Size(89, 23);
            this.maskedTextBoxTelefone.TabIndex = 2;
            this.maskedTextBoxTelefone.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // maskedTextBoxCNH
            // 
            this.maskedTextBoxCNH.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.maskedTextBoxCNH.Location = new System.Drawing.Point(105, 173);
            this.maskedTextBoxCNH.Mask = "00000000000";
            this.maskedTextBoxCNH.Name = "maskedTextBoxCNH";
            this.maskedTextBoxCNH.Size = new System.Drawing.Size(89, 23);
            this.maskedTextBoxCNH.TabIndex = 4;
            this.maskedTextBoxCNH.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // comboBoxEmpresa
            // 
            this.comboBoxEmpresa.FormattingEnabled = true;
            this.comboBoxEmpresa.ItemHeight = 15;
            this.comboBoxEmpresa.Location = new System.Drawing.Point(105, 261);
            this.comboBoxEmpresa.Name = "comboBoxEmpresa";
            this.comboBoxEmpresa.Size = new System.Drawing.Size(163, 23);
            this.comboBoxEmpresa.TabIndex = 15;
            // 
            // dateTimePickerValidadeCNH
            // 
            this.dateTimePickerValidadeCNH.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerValidadeCNH.Location = new System.Drawing.Point(105, 202);
            this.dateTimePickerValidadeCNH.Name = "dateTimePickerValidadeCNH";
            this.dateTimePickerValidadeCNH.Size = new System.Drawing.Size(89, 23);
            this.dateTimePickerValidadeCNH.TabIndex = 5;
            // 
            // buttonGravar
            // 
            this.buttonGravar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonGravar.Location = new System.Drawing.Point(163, 314);
            this.buttonGravar.Name = "buttonGravar";
            this.buttonGravar.Size = new System.Drawing.Size(67, 33);
            this.buttonGravar.TabIndex = 8;
            this.buttonGravar.Text = "Gravar";
            this.buttonGravar.UseVisualStyleBackColor = true;
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancelar.Location = new System.Drawing.Point(236, 314);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(67, 33);
            this.buttonCancelar.TabIndex = 9;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            // 
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.labelID.Location = new System.Drawing.Point(78, 27);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(21, 15);
            this.labelID.TabIndex = 26;
            this.labelID.Text = "ID:";
            // 
            // textBoxID
            // 
            this.textBoxID.Enabled = false;
            this.textBoxID.Location = new System.Drawing.Point(117, 36);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.ReadOnly = true;
            this.textBoxID.Size = new System.Drawing.Size(75, 23);
            this.textBoxID.TabIndex = 25;
            // 
            // groupBoxCondutor
            // 
            this.groupBoxCondutor.Controls.Add(this.labelID);
            this.groupBoxCondutor.Controls.Add(this.labelCPF);
            this.groupBoxCondutor.Controls.Add(this.maskedTextBoxCPF);
            this.groupBoxCondutor.Controls.Add(this.maskedTextBoxCNH);
            this.groupBoxCondutor.Controls.Add(this.labelEmpresa);
            this.groupBoxCondutor.Controls.Add(this.comboBoxEmpresa);
            this.groupBoxCondutor.Controls.Add(this.textBoxEmail);
            this.groupBoxCondutor.Controls.Add(this.labelTelefone);
            this.groupBoxCondutor.Controls.Add(this.dateTimePickerValidadeCNH);
            this.groupBoxCondutor.Controls.Add(this.labelNome);
            this.groupBoxCondutor.Controls.Add(this.labelEmail);
            this.groupBoxCondutor.Controls.Add(this.labelEndereco);
            this.groupBoxCondutor.Controls.Add(this.labelValidadeCNH);
            this.groupBoxCondutor.Controls.Add(this.labelCNH);
            this.groupBoxCondutor.Location = new System.Drawing.Point(12, 12);
            this.groupBoxCondutor.Name = "groupBoxCondutor";
            this.groupBoxCondutor.Size = new System.Drawing.Size(291, 296);
            this.groupBoxCondutor.TabIndex = 27;
            this.groupBoxCondutor.TabStop = false;
            this.groupBoxCondutor.Text = "Dados do condutor:";
            // 
            // labelCPF
            // 
            this.labelCPF.AutoSize = true;
            this.labelCPF.Location = new System.Drawing.Point(68, 142);
            this.labelCPF.Name = "labelCPF";
            this.labelCPF.Size = new System.Drawing.Size(31, 15);
            this.labelCPF.TabIndex = 18;
            this.labelCPF.Text = "CPF:";
            // 
            // maskedTextBoxCPF
            // 
            this.maskedTextBoxCPF.Location = new System.Drawing.Point(105, 139);
            this.maskedTextBoxCPF.Mask = "000\\.000\\.000-00";
            this.maskedTextBoxCPF.Name = "maskedTextBoxCPF";
            this.maskedTextBoxCPF.Size = new System.Drawing.Size(89, 23);
            this.maskedTextBoxCPF.TabIndex = 3;
            this.maskedTextBoxCPF.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // TelaCadastroCondutorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 354);
            this.Controls.Add(this.textBoxID);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonGravar);
            this.Controls.Add(this.maskedTextBoxTelefone);
            this.Controls.Add(this.textBoxEndereco);
            this.Controls.Add(this.textBoxNome);
            this.Controls.Add(this.groupBoxCondutor);
            this.Name = "TelaCadastroCondutorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Condutores";
            this.groupBoxCondutor.ResumeLayout(false);
            this.groupBoxCondutor.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelCNH;
        private System.Windows.Forms.Label labelEndereco;
        private System.Windows.Forms.Label labelNome;
        private System.Windows.Forms.Label labelEmpresa;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.Label labelValidadeCNH;
        private System.Windows.Forms.Label labelTelefone;
        private System.Windows.Forms.TextBox textBoxNome;
        private System.Windows.Forms.TextBox textBoxEndereco;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxTelefone;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxCNH;
        private System.Windows.Forms.ComboBox comboBoxEmpresa;
        private System.Windows.Forms.DateTimePicker dateTimePickerValidadeCNH;
        private System.Windows.Forms.Button buttonGravar;
        private System.Windows.Forms.Label labelID;
        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.GroupBox groupBoxCondutor;
        private System.Windows.Forms.Label labelCPF;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxCPF;
        public System.Windows.Forms.Button buttonCancelar;
    }
}