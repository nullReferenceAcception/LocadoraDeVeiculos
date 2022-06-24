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
            this.button2 = new System.Windows.Forms.Button();
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
            this.groupBoxEhAdmin.SuspendLayout();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(314, 355);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(67, 33);
            this.button2.TabIndex = 11;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // labelNome
            // 
            this.labelNome.AutoSize = true;
            this.labelNome.Location = new System.Drawing.Point(81, 36);
            this.labelNome.Name = "labelNome";
            this.labelNome.Size = new System.Drawing.Size(43, 15);
            this.labelNome.TabIndex = 7;
            this.labelNome.Text = "Nome:";
            // 
            // buttonGravar
            // 
            this.buttonGravar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonGravar.Location = new System.Drawing.Point(241, 355);
            this.buttonGravar.Name = "buttonGravar";
            this.buttonGravar.Size = new System.Drawing.Size(67, 33);
            this.buttonGravar.TabIndex = 10;
            this.buttonGravar.Text = "Gravar";
            this.buttonGravar.UseVisualStyleBackColor = true;
            this.buttonGravar.Click += new System.EventHandler(this.buttonGravar_Click);
            // 
            // textBoxNome
            // 
            this.textBoxNome.Location = new System.Drawing.Point(148, 33);
            this.textBoxNome.MaxLength = 255;
            this.textBoxNome.Name = "textBoxNome";
            this.textBoxNome.Size = new System.Drawing.Size(233, 23);
            this.textBoxNome.TabIndex = 6;
            // 
            // labelLogin
            // 
            this.labelLogin.AutoSize = true;
            this.labelLogin.Location = new System.Drawing.Point(84, 76);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(40, 15);
            this.labelLogin.TabIndex = 9;
            this.labelLogin.Text = "Login:";
            // 
            // textBoxLogin
            // 
            this.textBoxLogin.Location = new System.Drawing.Point(148, 73);
            this.textBoxLogin.MaxLength = 255;
            this.textBoxLogin.Name = "textBoxLogin";
            this.textBoxLogin.Size = new System.Drawing.Size(143, 23);
            this.textBoxLogin.TabIndex = 8;
            // 
            // labelSenha
            // 
            this.labelSenha.AutoSize = true;
            this.labelSenha.Location = new System.Drawing.Point(84, 118);
            this.labelSenha.Name = "labelSenha";
            this.labelSenha.Size = new System.Drawing.Size(42, 15);
            this.labelSenha.TabIndex = 13;
            this.labelSenha.Text = "Senha:";
            // 
            // textBoxSenha
            // 
            this.textBoxSenha.Location = new System.Drawing.Point(148, 115);
            this.textBoxSenha.MaxLength = 255;
            this.textBoxSenha.Name = "textBoxSenha";
            this.textBoxSenha.PasswordChar = '°';
            this.textBoxSenha.Size = new System.Drawing.Size(175, 23);
            this.textBoxSenha.TabIndex = 12;
            // 
            // dateTimePickerDataAdmissao
            // 
            this.dateTimePickerDataAdmissao.Location = new System.Drawing.Point(148, 161);
            this.dateTimePickerDataAdmissao.Name = "dateTimePickerDataAdmissao";
            this.dateTimePickerDataAdmissao.Size = new System.Drawing.Size(233, 23);
            this.dateTimePickerDataAdmissao.TabIndex = 14;
            // 
            // labelDataAdmissao
            // 
            this.labelDataAdmissao.AutoSize = true;
            this.labelDataAdmissao.Location = new System.Drawing.Point(19, 167);
            this.labelDataAdmissao.Name = "labelDataAdmissao";
            this.labelDataAdmissao.Size = new System.Drawing.Size(105, 15);
            this.labelDataAdmissao.TabIndex = 15;
            this.labelDataAdmissao.Text = "Data de Admissão:";
            // 
            // labelSalario
            // 
            this.labelSalario.AutoSize = true;
            this.labelSalario.Location = new System.Drawing.Point(84, 207);
            this.labelSalario.Name = "labelSalario";
            this.labelSalario.Size = new System.Drawing.Size(45, 15);
            this.labelSalario.TabIndex = 17;
            this.labelSalario.Text = "Salário:";
            // 
            // textBoxSalario
            // 
            this.textBoxSalario.Location = new System.Drawing.Point(148, 204);
            this.textBoxSalario.MaxLength = 11;
            this.textBoxSalario.Name = "textBoxSalario";
            this.textBoxSalario.Size = new System.Drawing.Size(96, 23);
            this.textBoxSalario.TabIndex = 16;
            // 
            // groupBoxEhAdmin
            // 
            this.groupBoxEhAdmin.Controls.Add(this.radioButtonFuncionario);
            this.groupBoxEhAdmin.Controls.Add(this.radioButtonAdmin);
            this.groupBoxEhAdmin.Location = new System.Drawing.Point(148, 245);
            this.groupBoxEhAdmin.Name = "groupBoxEhAdmin";
            this.groupBoxEhAdmin.Size = new System.Drawing.Size(175, 84);
            this.groupBoxEhAdmin.TabIndex = 18;
            this.groupBoxEhAdmin.TabStop = false;
            this.groupBoxEhAdmin.Text = "Tipo de perfil:";
            // 
            // radioButtonFuncionario
            // 
            this.radioButtonFuncionario.AutoSize = true;
            this.radioButtonFuncionario.Location = new System.Drawing.Point(22, 47);
            this.radioButtonFuncionario.Name = "radioButtonFuncionario";
            this.radioButtonFuncionario.Size = new System.Drawing.Size(88, 19);
            this.radioButtonFuncionario.TabIndex = 1;
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
            this.radioButtonAdmin.TabIndex = 0;
            this.radioButtonAdmin.TabStop = true;
            this.radioButtonAdmin.Text = "Admin";
            this.radioButtonAdmin.UseVisualStyleBackColor = true;
            // 
            // TelaCadastroFuncionarioForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 408);
            this.Controls.Add(this.groupBoxEhAdmin);
            this.Controls.Add(this.labelSalario);
            this.Controls.Add(this.textBoxSalario);
            this.Controls.Add(this.labelDataAdmissao);
            this.Controls.Add(this.dateTimePickerDataAdmissao);
            this.Controls.Add(this.labelSenha);
            this.Controls.Add(this.textBoxSenha);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.labelNome);
            this.Controls.Add(this.buttonGravar);
            this.Controls.Add(this.textBoxNome);
            this.Controls.Add(this.labelLogin);
            this.Controls.Add(this.textBoxLogin);
            this.Name = "TelaCadastroFuncionarioForm";
            this.Text = "TelaCadastroFuncionarioForm";
            this.groupBoxEhAdmin.ResumeLayout(false);
            this.groupBoxEhAdmin.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
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
    }
}