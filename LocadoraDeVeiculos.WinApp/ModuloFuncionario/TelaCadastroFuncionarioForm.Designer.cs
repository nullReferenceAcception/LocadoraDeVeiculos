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
            this.labelID = new System.Windows.Forms.Label();
            this.textBoxID = new System.Windows.Forms.TextBox();
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
            this.buttonCancelar.Location = new System.Drawing.Point(323, 429);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(67, 33);
            this.buttonCancelar.TabIndex = 12;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            // 
            // labelNome
            // 
            this.labelNome.AutoSize = true;
            this.labelNome.Location = new System.Drawing.Point(79, 71);
            this.labelNome.Name = "labelNome";
            this.labelNome.Size = new System.Drawing.Size(43, 15);
            this.labelNome.TabIndex = 7;
            this.labelNome.Text = "Nome:";
            // 
            // buttonGravar
            // 
            this.buttonGravar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonGravar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonGravar.Location = new System.Drawing.Point(250, 429);
            this.buttonGravar.Name = "buttonGravar";
            this.buttonGravar.Size = new System.Drawing.Size(67, 33);
            this.buttonGravar.TabIndex = 11;
            this.buttonGravar.Text = "Gravar";
            this.buttonGravar.UseVisualStyleBackColor = true;
            this.buttonGravar.Click += new System.EventHandler(this.buttonGravar_Click);
            // 
            // textBoxNome
            // 
            this.textBoxNome.Location = new System.Drawing.Point(143, 68);
            this.textBoxNome.MaxLength = 100;
            this.textBoxNome.Name = "textBoxNome";
            this.textBoxNome.Size = new System.Drawing.Size(233, 23);
            this.textBoxNome.TabIndex = 0;
            // 
            // labelLogin
            // 
            this.labelLogin.AutoSize = true;
            this.labelLogin.Location = new System.Drawing.Point(82, 187);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(40, 15);
            this.labelLogin.TabIndex = 9;
            this.labelLogin.Text = "Login:";
            // 
            // textBoxLogin
            // 
            this.textBoxLogin.Location = new System.Drawing.Point(143, 184);
            this.textBoxLogin.MaxLength = 100;
            this.textBoxLogin.Name = "textBoxLogin";
            this.textBoxLogin.Size = new System.Drawing.Size(143, 23);
            this.textBoxLogin.TabIndex = 4;
            // 
            // labelSenha
            // 
            this.labelSenha.AutoSize = true;
            this.labelSenha.Location = new System.Drawing.Point(64, 204);
            this.labelSenha.Name = "labelSenha";
            this.labelSenha.Size = new System.Drawing.Size(42, 15);
            this.labelSenha.TabIndex = 13;
            this.labelSenha.Text = "Senha:";
            // 
            // textBoxSenha
            // 
            this.textBoxSenha.Location = new System.Drawing.Point(143, 213);
            this.textBoxSenha.MaxLength = 255;
            this.textBoxSenha.Name = "textBoxSenha";
            this.textBoxSenha.PasswordChar = '•';
            this.textBoxSenha.Size = new System.Drawing.Size(175, 23);
            this.textBoxSenha.TabIndex = 5;
            // 
            // dateTimePickerDataAdmissao
            // 
            this.dateTimePickerDataAdmissao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dateTimePickerDataAdmissao.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerDataAdmissao.Location = new System.Drawing.Point(128, 230);
            this.dateTimePickerDataAdmissao.Name = "dateTimePickerDataAdmissao";
            this.dateTimePickerDataAdmissao.Size = new System.Drawing.Size(100, 23);
            this.dateTimePickerDataAdmissao.TabIndex = 6;
            // 
            // labelDataAdmissao
            // 
            this.labelDataAdmissao.AutoSize = true;
            this.labelDataAdmissao.Location = new System.Drawing.Point(2, 236);
            this.labelDataAdmissao.Name = "labelDataAdmissao";
            this.labelDataAdmissao.Size = new System.Drawing.Size(105, 15);
            this.labelDataAdmissao.TabIndex = 15;
            this.labelDataAdmissao.Text = "Data de Admissão:";
            // 
            // labelSalario
            // 
            this.labelSalario.AutoSize = true;
            this.labelSalario.Location = new System.Drawing.Point(77, 274);
            this.labelSalario.Name = "labelSalario";
            this.labelSalario.Size = new System.Drawing.Size(45, 15);
            this.labelSalario.TabIndex = 17;
            this.labelSalario.Text = "Salário:";
            // 
            // textBoxSalario
            // 
            this.textBoxSalario.Location = new System.Drawing.Point(143, 271);
            this.textBoxSalario.MaxLength = 11;
            this.textBoxSalario.Name = "textBoxSalario";
            this.textBoxSalario.Size = new System.Drawing.Size(110, 23);
            this.textBoxSalario.TabIndex = 7;
            // 
            // groupBoxEhAdmin
            // 
            this.groupBoxEhAdmin.Controls.Add(this.radioButtonFuncionario);
            this.groupBoxEhAdmin.Controls.Add(this.radioButtonAdmin);
            this.groupBoxEhAdmin.Location = new System.Drawing.Point(62, 317);
            this.groupBoxEhAdmin.Name = "groupBoxEhAdmin";
            this.groupBoxEhAdmin.Size = new System.Drawing.Size(175, 84);
            this.groupBoxEhAdmin.TabIndex = 8;
            this.groupBoxEhAdmin.TabStop = false;
            this.groupBoxEhAdmin.Text = "Tipo de perfil:";
            // 
            // radioButtonFuncionario
            // 
            this.radioButtonFuncionario.AutoSize = true;
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
            this.labelEmail.Location = new System.Drawing.Point(78, 100);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(44, 15);
            this.labelEmail.TabIndex = 19;
            this.labelEmail.Text = "E-mail:";
            // 
            // labelTelefone
            // 
            this.labelTelefone.AutoSize = true;
            this.labelTelefone.Location = new System.Drawing.Point(68, 129);
            this.labelTelefone.Name = "labelTelefone";
            this.labelTelefone.Size = new System.Drawing.Size(54, 15);
            this.labelTelefone.TabIndex = 20;
            this.labelTelefone.Text = "Telefone:";
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(143, 97);
            this.textBoxEmail.MaxLength = 100;
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(233, 23);
            this.textBoxEmail.TabIndex = 1;
            // 
            // labelEndereco
            // 
            this.labelEndereco.AutoSize = true;
            this.labelEndereco.Location = new System.Drawing.Point(63, 158);
            this.labelEndereco.Name = "labelEndereco";
            this.labelEndereco.Size = new System.Drawing.Size(59, 15);
            this.labelEndereco.TabIndex = 24;
            this.labelEndereco.Text = "Endereço:";
            // 
            // textBoxEndereco
            // 
            this.textBoxEndereco.Location = new System.Drawing.Point(143, 155);
            this.textBoxEndereco.MaxLength = 100;
            this.textBoxEndereco.Name = "textBoxEndereco";
            this.textBoxEndereco.Size = new System.Drawing.Size(143, 23);
            this.textBoxEndereco.TabIndex = 3;
            // 
            // maskedTextBoxTelefone
            // 
            this.maskedTextBoxTelefone.Location = new System.Drawing.Point(143, 126);
            this.maskedTextBoxTelefone.Mask = "(00) 90000-0000";
            this.maskedTextBoxTelefone.Name = "maskedTextBoxTelefone";
            this.maskedTextBoxTelefone.Size = new System.Drawing.Size(100, 23);
            this.maskedTextBoxTelefone.TabIndex = 2;
            this.maskedTextBoxTelefone.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // groupBoxDadosFuncionario
            // 
            this.groupBoxDadosFuncionario.Controls.Add(this.labelID);
            this.groupBoxDadosFuncionario.Controls.Add(this.textBoxID);
            this.groupBoxDadosFuncionario.Controls.Add(this.textBoxCidade);
            this.groupBoxDadosFuncionario.Controls.Add(this.labelCidade);
            this.groupBoxDadosFuncionario.Controls.Add(this.groupBoxEhAdmin);
            this.groupBoxDadosFuncionario.Controls.Add(this.labelSenha);
            this.groupBoxDadosFuncionario.Controls.Add(this.labelDataAdmissao);
            this.groupBoxDadosFuncionario.Controls.Add(this.dateTimePickerDataAdmissao);
            this.groupBoxDadosFuncionario.Location = new System.Drawing.Point(15, 12);
            this.groupBoxDadosFuncionario.Name = "groupBoxDadosFuncionario";
            this.groupBoxDadosFuncionario.Size = new System.Drawing.Size(375, 411);
            this.groupBoxDadosFuncionario.TabIndex = 25;
            this.groupBoxDadosFuncionario.TabStop = false;
            this.groupBoxDadosFuncionario.Text = "Dados do funcionário:";
            // 
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.labelID.Location = new System.Drawing.Point(84, 35);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(21, 15);
            this.labelID.TabIndex = 26;
            this.labelID.Text = "ID:";
            // 
            // textBoxID
            // 
            this.textBoxID.Enabled = false;
            this.textBoxID.Location = new System.Drawing.Point(128, 27);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.ReadOnly = true;
            this.textBoxID.Size = new System.Drawing.Size(75, 23);
            this.textBoxID.TabIndex = 26;
            // 
            // textBoxCidade
            // 
            this.textBoxCidade.Location = new System.Drawing.Point(128, 288);
            this.textBoxCidade.MaxLength = 100;
            this.textBoxCidade.Name = "textBoxCidade";
            this.textBoxCidade.Size = new System.Drawing.Size(110, 23);
            this.textBoxCidade.TabIndex = 8;
            // 
            // labelCidade
            // 
            this.labelCidade.AutoSize = true;
            this.labelCidade.Location = new System.Drawing.Point(60, 291);
            this.labelCidade.Name = "labelCidade";
            this.labelCidade.Size = new System.Drawing.Size(47, 15);
            this.labelCidade.TabIndex = 0;
            this.labelCidade.Text = "Cidade:";
            // 
            // TelaCadastroFuncionarioForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 465);
            this.Controls.Add(this.maskedTextBoxTelefone);
            this.Controls.Add(this.labelEndereco);
            this.Controls.Add(this.textBoxEndereco);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.labelTelefone);
            this.Controls.Add(this.labelEmail);
            this.Controls.Add(this.labelSalario);
            this.Controls.Add(this.textBoxSalario);
            this.Controls.Add(this.textBoxSenha);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.labelNome);
            this.Controls.Add(this.buttonGravar);
            this.Controls.Add(this.textBoxNome);
            this.Controls.Add(this.labelLogin);
            this.Controls.Add(this.textBoxLogin);
            this.Controls.Add(this.groupBoxDadosFuncionario);
            this.Name = "TelaCadastroFuncionarioForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Funcionário";
            this.groupBoxEhAdmin.ResumeLayout(false);
            this.groupBoxEhAdmin.PerformLayout();
            this.groupBoxDadosFuncionario.ResumeLayout(false);
            this.groupBoxDadosFuncionario.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Label labelID;
        private System.Windows.Forms.TextBox textBoxID;
    }
}