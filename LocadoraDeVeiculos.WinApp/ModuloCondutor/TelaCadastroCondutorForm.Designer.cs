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
            this.labelGuid = new System.Windows.Forms.Label();
            this.textBoxGuid = new System.Windows.Forms.TextBox();
            this.groupBoxCondutor = new System.Windows.Forms.GroupBox();
            this.checkBoxUsarRegistro = new System.Windows.Forms.CheckBox();
            this.comboBoxClienteFisico = new System.Windows.Forms.ComboBox();
            this.labelCPF = new System.Windows.Forms.Label();
            this.maskedTextBoxCPF = new System.Windows.Forms.MaskedTextBox();
            this.groupBoxCondutor.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelCNH
            // 
            this.labelCNH.AutoSize = true;
            this.labelCNH.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelCNH.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelCNH.Location = new System.Drawing.Point(6, 298);
            this.labelCNH.Name = "labelCNH";
            this.labelCNH.Size = new System.Drawing.Size(36, 15);
            this.labelCNH.TabIndex = 2;
            this.labelCNH.Text = "CNH:";
            this.labelCNH.Click += new System.EventHandler(this.labelCNH_Click);
            // 
            // labelEndereco
            // 
            this.labelEndereco.AutoSize = true;
            this.labelEndereco.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelEndereco.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelEndereco.Location = new System.Drawing.Point(6, 160);
            this.labelEndereco.Name = "labelEndereco";
            this.labelEndereco.Size = new System.Drawing.Size(59, 15);
            this.labelEndereco.TabIndex = 3;
            this.labelEndereco.Text = "Endereço:";
            this.labelEndereco.Click += new System.EventHandler(this.labelEndereco_Click);
            // 
            // labelNome
            // 
            this.labelNome.AutoSize = true;
            this.labelNome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelNome.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelNome.Location = new System.Drawing.Point(6, 114);
            this.labelNome.Name = "labelNome";
            this.labelNome.Size = new System.Drawing.Size(43, 15);
            this.labelNome.TabIndex = 4;
            this.labelNome.Text = "Nome:";
            this.labelNome.Click += new System.EventHandler(this.labelNome_Click);
            // 
            // labelEmpresa
            // 
            this.labelEmpresa.AutoSize = true;
            this.labelEmpresa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelEmpresa.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelEmpresa.Location = new System.Drawing.Point(6, 436);
            this.labelEmpresa.Name = "labelEmpresa";
            this.labelEmpresa.Size = new System.Drawing.Size(55, 15);
            this.labelEmpresa.TabIndex = 5;
            this.labelEmpresa.Text = "Empresa:";
            this.labelEmpresa.Click += new System.EventHandler(this.labelEmpresa_Click);
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelEmail.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelEmail.Location = new System.Drawing.Point(6, 390);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(44, 15);
            this.labelEmail.TabIndex = 6;
            this.labelEmail.Text = "E-mail:";
            this.labelEmail.Click += new System.EventHandler(this.labelEmail_Click);
            // 
            // labelValidadeCNH
            // 
            this.labelValidadeCNH.AutoSize = true;
            this.labelValidadeCNH.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelValidadeCNH.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelValidadeCNH.Location = new System.Drawing.Point(6, 344);
            this.labelValidadeCNH.Name = "labelValidadeCNH";
            this.labelValidadeCNH.Size = new System.Drawing.Size(83, 15);
            this.labelValidadeCNH.TabIndex = 7;
            this.labelValidadeCNH.Text = "Validade CNH:";
            this.labelValidadeCNH.Click += new System.EventHandler(this.labelValidadeCNH_Click);
            // 
            // labelTelefone
            // 
            this.labelTelefone.AutoSize = true;
            this.labelTelefone.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelTelefone.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelTelefone.Location = new System.Drawing.Point(6, 206);
            this.labelTelefone.Name = "labelTelefone";
            this.labelTelefone.Size = new System.Drawing.Size(54, 15);
            this.labelTelefone.TabIndex = 8;
            this.labelTelefone.Text = "Telefone:";
            this.labelTelefone.Click += new System.EventHandler(this.labelTelefone_Click);
            // 
            // textBoxNome
            // 
            this.textBoxNome.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxNome.Location = new System.Drawing.Point(6, 133);
            this.textBoxNome.MaxLength = 100;
            this.textBoxNome.Name = "textBoxNome";
            this.textBoxNome.Size = new System.Drawing.Size(228, 23);
            this.textBoxNome.TabIndex = 0;
            // 
            // textBoxEndereco
            // 
            this.textBoxEndereco.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxEndereco.Location = new System.Drawing.Point(6, 179);
            this.textBoxEndereco.MaxLength = 100;
            this.textBoxEndereco.Name = "textBoxEndereco";
            this.textBoxEndereco.Size = new System.Drawing.Size(213, 23);
            this.textBoxEndereco.TabIndex = 1;
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxEmail.Location = new System.Drawing.Point(6, 409);
            this.textBoxEmail.MaxLength = 100;
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(163, 23);
            this.textBoxEmail.TabIndex = 6;
            // 
            // maskedTextBoxTelefone
            // 
            this.maskedTextBoxTelefone.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.maskedTextBoxTelefone.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.maskedTextBoxTelefone.Location = new System.Drawing.Point(6, 225);
            this.maskedTextBoxTelefone.Mask = "(00) 90000-0000";
            this.maskedTextBoxTelefone.Name = "maskedTextBoxTelefone";
            this.maskedTextBoxTelefone.Size = new System.Drawing.Size(115, 23);
            this.maskedTextBoxTelefone.TabIndex = 2;
            this.maskedTextBoxTelefone.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // maskedTextBoxCNH
            // 
            this.maskedTextBoxCNH.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.maskedTextBoxCNH.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.maskedTextBoxCNH.Location = new System.Drawing.Point(6, 317);
            this.maskedTextBoxCNH.Mask = "00000000000";
            this.maskedTextBoxCNH.Name = "maskedTextBoxCNH";
            this.maskedTextBoxCNH.Size = new System.Drawing.Size(115, 23);
            this.maskedTextBoxCNH.TabIndex = 4;
            this.maskedTextBoxCNH.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // comboBoxEmpresa
            // 
            this.comboBoxEmpresa.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboBoxEmpresa.FormattingEnabled = true;
            this.comboBoxEmpresa.ItemHeight = 15;
            this.comboBoxEmpresa.Location = new System.Drawing.Point(6, 455);
            this.comboBoxEmpresa.Name = "comboBoxEmpresa";
            this.comboBoxEmpresa.Size = new System.Drawing.Size(163, 23);
            this.comboBoxEmpresa.TabIndex = 15;
            // 
            // dateTimePickerValidadeCNH
            // 
            this.dateTimePickerValidadeCNH.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dateTimePickerValidadeCNH.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerValidadeCNH.Location = new System.Drawing.Point(6, 363);
            this.dateTimePickerValidadeCNH.Name = "dateTimePickerValidadeCNH";
            this.dateTimePickerValidadeCNH.Size = new System.Drawing.Size(99, 23);
            this.dateTimePickerValidadeCNH.TabIndex = 5;
            // 
            // buttonGravar
            // 
            this.buttonGravar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonGravar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonGravar.Location = new System.Drawing.Point(244, 506);
            this.buttonGravar.Name = "buttonGravar";
            this.buttonGravar.Size = new System.Drawing.Size(67, 34);
            this.buttonGravar.TabIndex = 8;
            this.buttonGravar.Text = "Gravar";
            this.buttonGravar.UseVisualStyleBackColor = true;
            this.buttonGravar.Click += new System.EventHandler(this.buttonGravar_Click);
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancelar.Location = new System.Drawing.Point(317, 506);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(67, 34);
            this.buttonCancelar.TabIndex = 9;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            // 
            // labelGuid
            // 
            this.labelGuid.AutoSize = true;
            this.labelGuid.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelGuid.Location = new System.Drawing.Point(6, 18);
            this.labelGuid.Name = "labelGuid";
            this.labelGuid.Size = new System.Drawing.Size(35, 15);
            this.labelGuid.TabIndex = 26;
            this.labelGuid.Text = "Guid:";
            // 
            // textBoxGuid
            // 
            this.textBoxGuid.Enabled = false;
            this.textBoxGuid.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxGuid.Location = new System.Drawing.Point(6, 37);
            this.textBoxGuid.Name = "textBoxGuid";
            this.textBoxGuid.ReadOnly = true;
            this.textBoxGuid.Size = new System.Drawing.Size(265, 23);
            this.textBoxGuid.TabIndex = 25;
            // 
            // groupBoxCondutor
            // 
            this.groupBoxCondutor.Controls.Add(this.checkBoxUsarRegistro);
            this.groupBoxCondutor.Controls.Add(this.textBoxGuid);
            this.groupBoxCondutor.Controls.Add(this.comboBoxClienteFisico);
            this.groupBoxCondutor.Controls.Add(this.labelGuid);
            this.groupBoxCondutor.Controls.Add(this.maskedTextBoxTelefone);
            this.groupBoxCondutor.Controls.Add(this.labelCPF);
            this.groupBoxCondutor.Controls.Add(this.textBoxEndereco);
            this.groupBoxCondutor.Controls.Add(this.textBoxNome);
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
            this.groupBoxCondutor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.groupBoxCondutor.Location = new System.Drawing.Point(12, 12);
            this.groupBoxCondutor.Name = "groupBoxCondutor";
            this.groupBoxCondutor.Size = new System.Drawing.Size(372, 489);
            this.groupBoxCondutor.TabIndex = 27;
            this.groupBoxCondutor.TabStop = false;
            this.groupBoxCondutor.Text = "Dados do condutor:";
            // 
            // checkBoxUsarRegistro
            // 
            this.checkBoxUsarRegistro.AutoSize = true;
            this.checkBoxUsarRegistro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxUsarRegistro.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBoxUsarRegistro.Location = new System.Drawing.Point(6, 64);
            this.checkBoxUsarRegistro.Name = "checkBoxUsarRegistro";
            this.checkBoxUsarRegistro.Size = new System.Drawing.Size(165, 19);
            this.checkBoxUsarRegistro.TabIndex = 31;
            this.checkBoxUsarRegistro.Text = "Utilizar cadastro existente?";
            this.checkBoxUsarRegistro.UseVisualStyleBackColor = true;
            this.checkBoxUsarRegistro.CheckedChanged += new System.EventHandler(this.checkBoxUsarRegistro_CheckedChanged);
            this.checkBoxUsarRegistro.Click += new System.EventHandler(this.checkBoxUsarRegistro_Click);
            // 
            // comboBoxClienteFisico
            // 
            this.comboBoxClienteFisico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxClienteFisico.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboBoxClienteFisico.FormattingEnabled = true;
            this.comboBoxClienteFisico.Location = new System.Drawing.Point(6, 87);
            this.comboBoxClienteFisico.Name = "comboBoxClienteFisico";
            this.comboBoxClienteFisico.Size = new System.Drawing.Size(159, 23);
            this.comboBoxClienteFisico.TabIndex = 30;
            this.comboBoxClienteFisico.SelectedIndexChanged += new System.EventHandler(this.comboBoxClienteFisico_SelectedIndexChanged);
            // 
            // labelCPF
            // 
            this.labelCPF.AutoSize = true;
            this.labelCPF.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelCPF.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelCPF.Location = new System.Drawing.Point(6, 252);
            this.labelCPF.Name = "labelCPF";
            this.labelCPF.Size = new System.Drawing.Size(31, 15);
            this.labelCPF.TabIndex = 18;
            this.labelCPF.Text = "CPF:";
            this.labelCPF.Click += new System.EventHandler(this.labelCPF_Click);
            // 
            // maskedTextBoxCPF
            // 
            this.maskedTextBoxCPF.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.maskedTextBoxCPF.Location = new System.Drawing.Point(6, 271);
            this.maskedTextBoxCPF.Mask = "000\\.000\\.000-00";
            this.maskedTextBoxCPF.Name = "maskedTextBoxCPF";
            this.maskedTextBoxCPF.Size = new System.Drawing.Size(115, 23);
            this.maskedTextBoxCPF.TabIndex = 3;
            this.maskedTextBoxCPF.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // TelaCadastroCondutorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 546);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonGravar);
            this.Controls.Add(this.groupBoxCondutor);
            this.Name = "TelaCadastroCondutorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Condutores";
            this.groupBoxCondutor.ResumeLayout(false);
            this.groupBoxCondutor.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Label labelGuid;
        private System.Windows.Forms.TextBox textBoxGuid;
        private System.Windows.Forms.GroupBox groupBoxCondutor;
        private System.Windows.Forms.Label labelCPF;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxCPF;
        public System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.ComboBox comboBoxClienteFisico;
        private System.Windows.Forms.CheckBox checkBoxUsarRegistro;
    }
}