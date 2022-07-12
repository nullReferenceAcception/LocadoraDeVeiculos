namespace LocadoraDeVeiculos.WinApp.ModuloFuncionario
{
    partial class TelaCadastroFuncionarioForm
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
            this.labelNome = new System.Windows.Forms.Label();
            this.buttonGravar = new System.Windows.Forms.Button();
            this.textBoxNome = new System.Windows.Forms.TextBox();
            this.labelLogin = new System.Windows.Forms.Label();
            this.textBoxLogin = new System.Windows.Forms.TextBox();
            this.labelSenha = new System.Windows.Forms.Label();
            this.textBoxSenha = new System.Windows.Forms.TextBox();
            this.dateTimePickerDataAdmissao = new System.Windows.Forms.DateTimePicker();
            this.labelDataAdmissao = new System.Windows.Forms.Label();
            this.labelSalario = new System.Windows.Forms.Label();
            this.textBoxSalario = new System.Windows.Forms.TextBox();
            this.groupBoxEhAdmin = new System.Windows.Forms.GroupBox();
            this.radioButtonFuncionario = new System.Windows.Forms.RadioButton();
            this.radioButtonAdmin = new System.Windows.Forms.RadioButton();
            this.labelEmail = new System.Windows.Forms.Label();
            this.labelTelefone = new System.Windows.Forms.Label();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.labelEndereco = new System.Windows.Forms.Label();
            this.textBoxEndereco = new System.Windows.Forms.TextBox();
            this.maskedTextBoxTelefone = new System.Windows.Forms.MaskedTextBox();
            this.groupBoxDadosFuncionario = new System.Windows.Forms.GroupBox();
            this.labelGuid = new System.Windows.Forms.Label();
            this.textBoxGuid = new System.Windows.Forms.TextBox();
            this.textBoxCidade = new System.Windows.Forms.TextBox();
            this.labelCidade = new System.Windows.Forms.Label();
            this.groupBoxEhAdmin.SuspendLayout();
            this.groupBoxDadosFuncionario.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancelar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.buttonCancelar.Location = new System.Drawing.Point(213, 610);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(67, 33);
            this.buttonCancelar.TabIndex = 12;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            // 
            // labelNome
            // 
            this.labelNome.AutoSize = true;
            this.labelNome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelNome.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelNome.Location = new System.Drawing.Point(6, 65);
            this.labelNome.Name = "labelNome";
            this.labelNome.Size = new System.Drawing.Size(43, 15);
            this.labelNome.TabIndex = 7;
            this.labelNome.Text = "Nome:";
            this.labelNome.Click += new System.EventHandler(this.labelNome_Click);
            // 
            // buttonGravar
            // 
            this.buttonGravar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonGravar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonGravar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.buttonGravar.Location = new System.Drawing.Point(146, 610);
            this.buttonGravar.Name = "buttonGravar";
            this.buttonGravar.Size = new System.Drawing.Size(67, 33);
            this.buttonGravar.TabIndex = 11;
            this.buttonGravar.Text = "Gravar";
            this.buttonGravar.UseVisualStyleBackColor = true;
            this.buttonGravar.Click += new System.EventHandler(this.buttonGravar_Click);
            // 
            // textBoxNome
            // 
            this.textBoxNome.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxNome.Location = new System.Drawing.Point(6, 85);
            this.textBoxNome.MaxLength = 100;
            this.textBoxNome.Name = "textBoxNome";
            this.textBoxNome.Size = new System.Drawing.Size(233, 23);
            this.textBoxNome.TabIndex = 0;
            // 
            // labelLogin
            // 
            this.labelLogin.AutoSize = true;
            this.labelLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelLogin.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelLogin.Location = new System.Drawing.Point(6, 257);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(40, 15);
            this.labelLogin.TabIndex = 9;
            this.labelLogin.Text = "Login:";
            this.labelLogin.Click += new System.EventHandler(this.labelLogin_Click);
            // 
            // textBoxLogin
            // 
            this.textBoxLogin.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxLogin.Location = new System.Drawing.Point(6, 277);
            this.textBoxLogin.MaxLength = 100;
            this.textBoxLogin.Name = "textBoxLogin";
            this.textBoxLogin.Size = new System.Drawing.Size(143, 23);
            this.textBoxLogin.TabIndex = 4;
            // 
            // labelSenha
            // 
            this.labelSenha.AutoSize = true;
            this.labelSenha.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelSenha.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelSenha.Location = new System.Drawing.Point(6, 305);
            this.labelSenha.Name = "labelSenha";
            this.labelSenha.Size = new System.Drawing.Size(42, 15);
            this.labelSenha.TabIndex = 13;
            this.labelSenha.Text = "Senha:";
            this.labelSenha.Click += new System.EventHandler(this.labelSenha_Click);
            // 
            // textBoxSenha
            // 
            this.textBoxSenha.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxSenha.Location = new System.Drawing.Point(6, 325);
            this.textBoxSenha.MaxLength = 255;
            this.textBoxSenha.Name = "textBoxSenha";
            this.textBoxSenha.PasswordChar = '•';
            this.textBoxSenha.Size = new System.Drawing.Size(175, 23);
            this.textBoxSenha.TabIndex = 5;
            // 
            // dateTimePickerDataAdmissao
            // 
            this.dateTimePickerDataAdmissao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dateTimePickerDataAdmissao.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dateTimePickerDataAdmissao.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerDataAdmissao.Location = new System.Drawing.Point(6, 373);
            this.dateTimePickerDataAdmissao.Name = "dateTimePickerDataAdmissao";
            this.dateTimePickerDataAdmissao.Size = new System.Drawing.Size(100, 23);
            this.dateTimePickerDataAdmissao.TabIndex = 6;
            // 
            // labelDataAdmissao
            // 
            this.labelDataAdmissao.AutoSize = true;
            this.labelDataAdmissao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelDataAdmissao.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelDataAdmissao.Location = new System.Drawing.Point(6, 353);
            this.labelDataAdmissao.Name = "labelDataAdmissao";
            this.labelDataAdmissao.Size = new System.Drawing.Size(105, 15);
            this.labelDataAdmissao.TabIndex = 15;
            this.labelDataAdmissao.Text = "Data de Admissão:";
            this.labelDataAdmissao.Click += new System.EventHandler(this.labelDataAdmissao_Click);
            // 
            // labelSalario
            // 
            this.labelSalario.AutoSize = true;
            this.labelSalario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelSalario.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelSalario.Location = new System.Drawing.Point(6, 401);
            this.labelSalario.Name = "labelSalario";
            this.labelSalario.Size = new System.Drawing.Size(45, 15);
            this.labelSalario.TabIndex = 17;
            this.labelSalario.Text = "Salário:";
            this.labelSalario.Click += new System.EventHandler(this.labelSalario_Click);
            // 
            // textBoxSalario
            // 
            this.textBoxSalario.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxSalario.Location = new System.Drawing.Point(6, 421);
            this.textBoxSalario.MaxLength = 11;
            this.textBoxSalario.Name = "textBoxSalario";
            this.textBoxSalario.Size = new System.Drawing.Size(110, 23);
            this.textBoxSalario.TabIndex = 7;
            // 
            // groupBoxEhAdmin
            // 
            this.groupBoxEhAdmin.Controls.Add(this.radioButtonFuncionario);
            this.groupBoxEhAdmin.Controls.Add(this.radioButtonAdmin);
            this.groupBoxEhAdmin.Location = new System.Drawing.Point(6, 498);
            this.groupBoxEhAdmin.Name = "groupBoxEhAdmin";
            this.groupBoxEhAdmin.Size = new System.Drawing.Size(175, 84);
            this.groupBoxEhAdmin.TabIndex = 8;
            this.groupBoxEhAdmin.TabStop = false;
            this.groupBoxEhAdmin.Text = "Tipo de perfil:";
            // 
            // radioButtonFuncionario
            // 
            this.radioButtonFuncionario.AutoSize = true;
            this.radioButtonFuncionario.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radioButtonFuncionario.Location = new System.Drawing.Point(22, 47);
            this.radioButtonFuncionario.Name = "radioButtonFuncionario";
            this.radioButtonFuncionario.Size = new System.Drawing.Size(88, 19);
            this.radioButtonFuncionario.TabIndex = 10;
            this.radioButtonFuncionario.TabStop = true;
            this.radioButtonFuncionario.Text = "Funcionário";
            this.radioButtonFuncionario.UseVisualStyleBackColor = true;
            // 
            // radioButtonAdmin
            // 
            this.radioButtonAdmin.AutoSize = true;
            this.radioButtonAdmin.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radioButtonAdmin.Location = new System.Drawing.Point(22, 22);
            this.radioButtonAdmin.Name = "radioButtonAdmin";
            this.radioButtonAdmin.Size = new System.Drawing.Size(61, 19);
            this.radioButtonAdmin.TabIndex = 9;
            this.radioButtonAdmin.TabStop = true;
            this.radioButtonAdmin.Text = "Admin";
            this.radioButtonAdmin.UseVisualStyleBackColor = true;
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelEmail.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelEmail.Location = new System.Drawing.Point(6, 113);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(44, 15);
            this.labelEmail.TabIndex = 19;
            this.labelEmail.Text = "E-mail:";
            this.labelEmail.Click += new System.EventHandler(this.labelEmail_Click);
            // 
            // labelTelefone
            // 
            this.labelTelefone.AutoSize = true;
            this.labelTelefone.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelTelefone.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelTelefone.Location = new System.Drawing.Point(6, 161);
            this.labelTelefone.Name = "labelTelefone";
            this.labelTelefone.Size = new System.Drawing.Size(54, 15);
            this.labelTelefone.TabIndex = 20;
            this.labelTelefone.Text = "Telefone:";
            this.labelTelefone.Click += new System.EventHandler(this.labelTelefone_Click);
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxEmail.Location = new System.Drawing.Point(6, 133);
            this.textBoxEmail.MaxLength = 100;
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(233, 23);
            this.textBoxEmail.TabIndex = 1;
            // 
            // labelEndereco
            // 
            this.labelEndereco.AutoSize = true;
            this.labelEndereco.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelEndereco.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelEndereco.Location = new System.Drawing.Point(6, 209);
            this.labelEndereco.Name = "labelEndereco";
            this.labelEndereco.Size = new System.Drawing.Size(59, 15);
            this.labelEndereco.TabIndex = 24;
            this.labelEndereco.Text = "Endereço:";
            this.labelEndereco.Click += new System.EventHandler(this.labelEndereco_Click);
            // 
            // textBoxEndereco
            // 
            this.textBoxEndereco.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxEndereco.Location = new System.Drawing.Point(6, 229);
            this.textBoxEndereco.MaxLength = 100;
            this.textBoxEndereco.Name = "textBoxEndereco";
            this.textBoxEndereco.Size = new System.Drawing.Size(143, 23);
            this.textBoxEndereco.TabIndex = 3;
            // 
            // maskedTextBoxTelefone
            // 
            this.maskedTextBoxTelefone.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.maskedTextBoxTelefone.Location = new System.Drawing.Point(6, 181);
            this.maskedTextBoxTelefone.Mask = "(00) 90000-0000";
            this.maskedTextBoxTelefone.Name = "maskedTextBoxTelefone";
            this.maskedTextBoxTelefone.Size = new System.Drawing.Size(100, 23);
            this.maskedTextBoxTelefone.TabIndex = 2;
            this.maskedTextBoxTelefone.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // groupBoxDadosFuncionario
            // 
            this.groupBoxDadosFuncionario.Controls.Add(this.labelEmail);
            this.groupBoxDadosFuncionario.Controls.Add(this.labelNome);
            this.groupBoxDadosFuncionario.Controls.Add(this.textBoxEmail);
            this.groupBoxDadosFuncionario.Controls.Add(this.maskedTextBoxTelefone);
            this.groupBoxDadosFuncionario.Controls.Add(this.labelTelefone);
            this.groupBoxDadosFuncionario.Controls.Add(this.labelGuid);
            this.groupBoxDadosFuncionario.Controls.Add(this.textBoxNome);
            this.groupBoxDadosFuncionario.Controls.Add(this.labelEndereco);
            this.groupBoxDadosFuncionario.Controls.Add(this.textBoxGuid);
            this.groupBoxDadosFuncionario.Controls.Add(this.textBoxEndereco);
            this.groupBoxDadosFuncionario.Controls.Add(this.textBoxCidade);
            this.groupBoxDadosFuncionario.Controls.Add(this.labelCidade);
            this.groupBoxDadosFuncionario.Controls.Add(this.groupBoxEhAdmin);
            this.groupBoxDadosFuncionario.Controls.Add(this.labelSenha);
            this.groupBoxDadosFuncionario.Controls.Add(this.textBoxSenha);
            this.groupBoxDadosFuncionario.Controls.Add(this.labelSalario);
            this.groupBoxDadosFuncionario.Controls.Add(this.labelDataAdmissao);
            this.groupBoxDadosFuncionario.Controls.Add(this.textBoxSalario);
            this.groupBoxDadosFuncionario.Controls.Add(this.labelLogin);
            this.groupBoxDadosFuncionario.Controls.Add(this.dateTimePickerDataAdmissao);
            this.groupBoxDadosFuncionario.Controls.Add(this.textBoxLogin);
            this.groupBoxDadosFuncionario.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.groupBoxDadosFuncionario.Location = new System.Drawing.Point(15, 12);
            this.groupBoxDadosFuncionario.Name = "groupBoxDadosFuncionario";
            this.groupBoxDadosFuncionario.Size = new System.Drawing.Size(266, 595);
            this.groupBoxDadosFuncionario.TabIndex = 25;
            this.groupBoxDadosFuncionario.TabStop = false;
            this.groupBoxDadosFuncionario.Text = "Dados do funcionário:";
            // 
            // labelGuid
            // 
            this.labelGuid.AutoSize = true;
            this.labelGuid.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelGuid.Location = new System.Drawing.Point(6, 17);
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
            this.textBoxGuid.Size = new System.Drawing.Size(247, 23);
            this.textBoxGuid.TabIndex = 26;
            // 
            // textBoxCidade
            // 
            this.textBoxCidade.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxCidade.Location = new System.Drawing.Point(6, 469);
            this.textBoxCidade.MaxLength = 100;
            this.textBoxCidade.Name = "textBoxCidade";
            this.textBoxCidade.Size = new System.Drawing.Size(110, 23);
            this.textBoxCidade.TabIndex = 8;
            // 
            // labelCidade
            // 
            this.labelCidade.AutoSize = true;
            this.labelCidade.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelCidade.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelCidade.Location = new System.Drawing.Point(6, 449);
            this.labelCidade.Name = "labelCidade";
            this.labelCidade.Size = new System.Drawing.Size(47, 15);
            this.labelCidade.TabIndex = 0;
            this.labelCidade.Text = "Cidade:";
            this.labelCidade.Click += new System.EventHandler(this.labelCidade_Click);
            // 
            // TelaCadastroFuncionarioForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 653);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonGravar);
            this.Controls.Add(this.groupBoxDadosFuncionario);
            this.Name = "TelaCadastroFuncionarioForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Funcionário";
            this.groupBoxEhAdmin.ResumeLayout(false);
            this.groupBoxEhAdmin.PerformLayout();
            this.groupBoxDadosFuncionario.ResumeLayout(false);
            this.groupBoxDadosFuncionario.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label labelNome;
        private System.Windows.Forms.Button buttonGravar;
        private System.Windows.Forms.TextBox textBoxNome;
        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.TextBox textBoxLogin;
        private System.Windows.Forms.Label labelSenha;
        private System.Windows.Forms.TextBox textBoxSenha;
        private System.Windows.Forms.DateTimePicker dateTimePickerDataAdmissao;
        private System.Windows.Forms.Label labelDataAdmissao;
        private System.Windows.Forms.Label labelSalario;
        private System.Windows.Forms.TextBox textBoxSalario;
        private System.Windows.Forms.GroupBox groupBoxEhAdmin;
        private System.Windows.Forms.RadioButton radioButtonFuncionario;
        private System.Windows.Forms.RadioButton radioButtonAdmin;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.Label labelTelefone;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Label labelEndereco;
        private System.Windows.Forms.TextBox textBoxEndereco;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxTelefone;
        private System.Windows.Forms.GroupBox groupBoxDadosFuncionario;
        private System.Windows.Forms.TextBox textBoxCidade;
        private System.Windows.Forms.Label labelCidade;
        public System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Label labelGuid;
        private System.Windows.Forms.TextBox textBoxGuid;
    }
}