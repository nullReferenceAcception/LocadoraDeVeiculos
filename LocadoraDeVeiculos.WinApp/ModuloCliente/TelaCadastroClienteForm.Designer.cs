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
            this.labelGuid = new System.Windows.Forms.Label();
            this.textBoxGuid = new System.Windows.Forms.TextBox();
            this.groupBoxTipoCliente.SuspendLayout();
            this.groupBoxDadosCliente.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxNome
            // 
            this.textBoxNome.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxNome.Location = new System.Drawing.Point(2, 81);
            this.textBoxNome.MaxLength = 100;
            this.textBoxNome.Name = "textBoxNome";
            this.textBoxNome.Size = new System.Drawing.Size(239, 23);
            this.textBoxNome.TabIndex = 0;
            // 
            // textBoxEndereco
            // 
            this.textBoxEndereco.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxEndereco.Location = new System.Drawing.Point(2, 125);
            this.textBoxEndereco.MaxLength = 100;
            this.textBoxEndereco.Name = "textBoxEndereco";
            this.textBoxEndereco.Size = new System.Drawing.Size(239, 23);
            this.textBoxEndereco.TabIndex = 1;
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxEmail.Location = new System.Drawing.Point(2, 169);
            this.textBoxEmail.MaxLength = 100;
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(239, 23);
            this.textBoxEmail.TabIndex = 4;
            // 
            // labelNome
            // 
            this.labelNome.AutoSize = true;
            this.labelNome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelNome.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelNome.Location = new System.Drawing.Point(2, 63);
            this.labelNome.Name = "labelNome";
            this.labelNome.Size = new System.Drawing.Size(43, 15);
            this.labelNome.TabIndex = 6;
            this.labelNome.Text = "Nome:";
            this.labelNome.Click += new System.EventHandler(this.labelNome_Click);
            // 
            // labelTelefone
            // 
            this.labelTelefone.AutoSize = true;
            this.labelTelefone.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelTelefone.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelTelefone.Location = new System.Drawing.Point(2, 195);
            this.labelTelefone.Name = "labelTelefone";
            this.labelTelefone.Size = new System.Drawing.Size(54, 15);
            this.labelTelefone.TabIndex = 9;
            this.labelTelefone.Text = "Telefone:";
            this.labelTelefone.Click += new System.EventHandler(this.labelTelefone_Click);
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelEmail.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelEmail.Location = new System.Drawing.Point(2, 151);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(39, 15);
            this.labelEmail.TabIndex = 10;
            this.labelEmail.Text = "Email:";
            this.labelEmail.Click += new System.EventHandler(this.labelEmail_Click);
            // 
            // labelEndereco
            // 
            this.labelEndereco.AutoSize = true;
            this.labelEndereco.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelEndereco.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelEndereco.Location = new System.Drawing.Point(2, 107);
            this.labelEndereco.Name = "labelEndereco";
            this.labelEndereco.Size = new System.Drawing.Size(59, 15);
            this.labelEndereco.TabIndex = 12;
            this.labelEndereco.Text = "Endereço:";
            this.labelEndereco.Click += new System.EventHandler(this.labelEndereco_Click);
            // 
            // groupBoxTipoCliente
            // 
            this.groupBoxTipoCliente.Controls.Add(this.radioButtonCNPJ);
            this.groupBoxTipoCliente.Controls.Add(this.radioButtonCPF);
            this.groupBoxTipoCliente.Location = new System.Drawing.Point(2, 239);
            this.groupBoxTipoCliente.Name = "groupBoxTipoCliente";
            this.groupBoxTipoCliente.Size = new System.Drawing.Size(133, 79);
            this.groupBoxTipoCliente.TabIndex = 6;
            this.groupBoxTipoCliente.TabStop = false;
            this.groupBoxTipoCliente.Text = "Tipo de cliente:";
            // 
            // radioButtonCNPJ
            // 
            this.radioButtonCNPJ.AutoSize = true;
            this.radioButtonCNPJ.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
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
            this.radioButtonCPF.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
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
            this.labelCPF.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelCPF.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelCPF.Location = new System.Drawing.Point(2, 321);
            this.labelCPF.Name = "labelCPF";
            this.labelCPF.Size = new System.Drawing.Size(31, 15);
            this.labelCPF.TabIndex = 15;
            this.labelCPF.Text = "CPF:";
            this.labelCPF.Click += new System.EventHandler(this.labelCPF_Click);
            // 
            // labelCNPJ
            // 
            this.labelCNPJ.AutoSize = true;
            this.labelCNPJ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelCNPJ.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelCNPJ.Location = new System.Drawing.Point(2, 365);
            this.labelCNPJ.Name = "labelCNPJ";
            this.labelCNPJ.Size = new System.Drawing.Size(37, 15);
            this.labelCNPJ.TabIndex = 16;
            this.labelCNPJ.Text = "CNPJ:";
            this.labelCNPJ.Click += new System.EventHandler(this.labelCNPJ_Click);
            // 
            // buttonGravar
            // 
            this.buttonGravar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonGravar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonGravar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.buttonGravar.Location = new System.Drawing.Point(131, 432);
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
            this.buttonCancelar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.buttonCancelar.Location = new System.Drawing.Point(204, 432);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(67, 33);
            this.buttonCancelar.TabIndex = 12;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            // 
            // maskedTextBoxCPF
            // 
            this.maskedTextBoxCPF.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.maskedTextBoxCPF.Location = new System.Drawing.Point(2, 339);
            this.maskedTextBoxCPF.Mask = "000\\.000\\.000-00";
            this.maskedTextBoxCPF.Name = "maskedTextBoxCPF";
            this.maskedTextBoxCPF.Size = new System.Drawing.Size(140, 23);
            this.maskedTextBoxCPF.TabIndex = 9;
            this.maskedTextBoxCPF.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // maskedTextBoxCNPJ
            // 
            this.maskedTextBoxCNPJ.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.maskedTextBoxCNPJ.Location = new System.Drawing.Point(2, 383);
            this.maskedTextBoxCNPJ.Mask = "00\\.000\\.000/0000-00";
            this.maskedTextBoxCNPJ.Name = "maskedTextBoxCNPJ";
            this.maskedTextBoxCNPJ.Size = new System.Drawing.Size(140, 23);
            this.maskedTextBoxCNPJ.TabIndex = 10;
            this.maskedTextBoxCNPJ.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // maskedTextBoxTelefone
            // 
            this.maskedTextBoxTelefone.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.maskedTextBoxTelefone.Location = new System.Drawing.Point(2, 213);
            this.maskedTextBoxTelefone.Mask = "(00) 90000-0000";
            this.maskedTextBoxTelefone.Name = "maskedTextBoxTelefone";
            this.maskedTextBoxTelefone.Size = new System.Drawing.Size(111, 23);
            this.maskedTextBoxTelefone.TabIndex = 5;
            this.maskedTextBoxTelefone.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // groupBoxDadosCliente
            // 
            this.groupBoxDadosCliente.Controls.Add(this.maskedTextBoxTelefone);
            this.groupBoxDadosCliente.Controls.Add(this.labelGuid);
            this.groupBoxDadosCliente.Controls.Add(this.textBoxGuid);
            this.groupBoxDadosCliente.Controls.Add(this.labelCPF);
            this.groupBoxDadosCliente.Controls.Add(this.groupBoxTipoCliente);
            this.groupBoxDadosCliente.Controls.Add(this.maskedTextBoxCNPJ);
            this.groupBoxDadosCliente.Controls.Add(this.labelEndereco);
            this.groupBoxDadosCliente.Controls.Add(this.labelCNPJ);
            this.groupBoxDadosCliente.Controls.Add(this.maskedTextBoxCPF);
            this.groupBoxDadosCliente.Controls.Add(this.labelEmail);
            this.groupBoxDadosCliente.Controls.Add(this.textBoxNome);
            this.groupBoxDadosCliente.Controls.Add(this.labelTelefone);
            this.groupBoxDadosCliente.Controls.Add(this.textBoxEndereco);
            this.groupBoxDadosCliente.Controls.Add(this.labelNome);
            this.groupBoxDadosCliente.Controls.Add(this.textBoxEmail);
            this.groupBoxDadosCliente.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.groupBoxDadosCliente.Location = new System.Drawing.Point(12, 11);
            this.groupBoxDadosCliente.Name = "groupBoxDadosCliente";
            this.groupBoxDadosCliente.Size = new System.Drawing.Size(259, 419);
            this.groupBoxDadosCliente.TabIndex = 22;
            this.groupBoxDadosCliente.TabStop = false;
            this.groupBoxDadosCliente.Text = "Dados do cliente:";
            // 
            // labelGuid
            // 
            this.labelGuid.AutoSize = true;
            this.labelGuid.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelGuid.Location = new System.Drawing.Point(2, 19);
            this.labelGuid.Name = "labelGuid";
            this.labelGuid.Size = new System.Drawing.Size(35, 15);
            this.labelGuid.TabIndex = 24;
            this.labelGuid.Text = "Guid:";
            // 
            // textBoxGuid
            // 
            this.textBoxGuid.Enabled = false;
            this.textBoxGuid.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxGuid.Location = new System.Drawing.Point(2, 37);
            this.textBoxGuid.Name = "textBoxGuid";
            this.textBoxGuid.ReadOnly = true;
            this.textBoxGuid.Size = new System.Drawing.Size(240, 23);
            this.textBoxGuid.TabIndex = 23;
            // 
            // TelaCadastroClienteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 471);
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
        private System.Windows.Forms.Label labelGuid;
        private System.Windows.Forms.TextBox textBoxGuid;
    }
}