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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxNome = new System.Windows.Forms.TextBox();
            this.textBoxEndereco = new System.Windows.Forms.TextBox();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.maskedTextBoxTelefone = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBoxCNH = new System.Windows.Forms.MaskedTextBox();
            this.comboBoxEmpresa = new System.Windows.Forms.ComboBox();
            this.dateTimePickerValidadeCNH = new System.Windows.Forms.DateTimePicker();
            this.buttonGravar = new System.Windows.Forms.Button();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.groupBoxCondutor = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.maskedTextBoxCPF = new System.Windows.Forms.MaskedTextBox();
            this.groupBoxCondutor.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "CNH:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Endereço:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Nome:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 264);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "Empresa:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 235);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 15);
            this.label7.TabIndex = 6;
            this.label7.Text = "E-mail:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 210);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 15);
            this.label8.TabIndex = 7;
            this.label8.Text = "Validade CNH:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(26, 126);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 15);
            this.label9.TabIndex = 8;
            this.label9.Text = "Telefone:";
            // 
            // textBoxNome
            // 
            this.textBoxNome.Location = new System.Drawing.Point(117, 65);
            this.textBoxNome.Name = "textBoxNome";
            this.textBoxNome.Size = new System.Drawing.Size(163, 23);
            this.textBoxNome.TabIndex = 9;
            // 
            // textBoxEndereco
            // 
            this.textBoxEndereco.Location = new System.Drawing.Point(117, 94);
            this.textBoxEndereco.Name = "textBoxEndereco";
            this.textBoxEndereco.Size = new System.Drawing.Size(163, 23);
            this.textBoxEndereco.TabIndex = 10;
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(105, 232);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(163, 23);
            this.textBoxEmail.TabIndex = 11;
            // 
            // maskedTextBoxTelefone
            // 
            this.maskedTextBoxTelefone.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.maskedTextBoxTelefone.Location = new System.Drawing.Point(117, 123);
            this.maskedTextBoxTelefone.Mask = "(00) 90000-0000";
            this.maskedTextBoxTelefone.Name = "maskedTextBoxTelefone";
            this.maskedTextBoxTelefone.Size = new System.Drawing.Size(163, 23);
            this.maskedTextBoxTelefone.TabIndex = 12;
            this.maskedTextBoxTelefone.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // maskedTextBoxCNH
            // 
            this.maskedTextBoxCNH.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.maskedTextBoxCNH.Location = new System.Drawing.Point(105, 173);
            this.maskedTextBoxCNH.Mask = "00000000000";
            this.maskedTextBoxCNH.Name = "maskedTextBoxCNH";
            this.maskedTextBoxCNH.Size = new System.Drawing.Size(163, 23);
            this.maskedTextBoxCNH.TabIndex = 13;
            this.maskedTextBoxCNH.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // comboBoxEmpresa
            // 
            this.comboBoxEmpresa.FormattingEnabled = true;
            this.comboBoxEmpresa.Location = new System.Drawing.Point(105, 261);
            this.comboBoxEmpresa.Name = "comboBoxEmpresa";
            this.comboBoxEmpresa.Size = new System.Drawing.Size(163, 23);
            this.comboBoxEmpresa.TabIndex = 15;
            this.comboBoxEmpresa.SelectedIndexChanged += new System.EventHandler(this.comboBoxEmpresa_SelectedIndexChanged);
            // 
            // dateTimePickerValidadeCNH
            // 
            this.dateTimePickerValidadeCNH.Location = new System.Drawing.Point(105, 202);
            this.dateTimePickerValidadeCNH.Name = "dateTimePickerValidadeCNH";
            this.dateTimePickerValidadeCNH.Size = new System.Drawing.Size(163, 23);
            this.dateTimePickerValidadeCNH.TabIndex = 16;
            // 
            // buttonGravar
            // 
            this.buttonGravar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonGravar.Location = new System.Drawing.Point(103, 325);
            this.buttonGravar.Name = "buttonGravar";
            this.buttonGravar.Size = new System.Drawing.Size(89, 26);
            this.buttonGravar.TabIndex = 17;
            this.buttonGravar.Text = "Gravar";
            this.buttonGravar.UseVisualStyleBackColor = true;
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancelar.Location = new System.Drawing.Point(214, 325);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(89, 26);
            this.buttonCancelar.TabIndex = 18;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 15);
            this.label1.TabIndex = 26;
            this.label1.Text = "ID:";
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
            this.groupBoxCondutor.Controls.Add(this.label2);
            this.groupBoxCondutor.Controls.Add(this.maskedTextBoxCPF);
            this.groupBoxCondutor.Controls.Add(this.maskedTextBoxCNH);
            this.groupBoxCondutor.Controls.Add(this.label6);
            this.groupBoxCondutor.Controls.Add(this.comboBoxEmpresa);
            this.groupBoxCondutor.Controls.Add(this.textBoxEmail);
            this.groupBoxCondutor.Controls.Add(this.dateTimePickerValidadeCNH);
            this.groupBoxCondutor.Controls.Add(this.label7);
            this.groupBoxCondutor.Controls.Add(this.label8);
            this.groupBoxCondutor.Controls.Add(this.label3);
            this.groupBoxCondutor.Location = new System.Drawing.Point(12, 12);
            this.groupBoxCondutor.Name = "groupBoxCondutor";
            this.groupBoxCondutor.Size = new System.Drawing.Size(291, 296);
            this.groupBoxCondutor.TabIndex = 27;
            this.groupBoxCondutor.TabStop = false;
            this.groupBoxCondutor.Text = "Dados do condutor:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 15);
            this.label2.TabIndex = 18;
            this.label2.Text = "CPF:";
            // 
            // maskedTextBoxCPF
            // 
            this.maskedTextBoxCPF.Location = new System.Drawing.Point(105, 139);
            this.maskedTextBoxCPF.Mask = "000\\.000\\.000-00";
            this.maskedTextBoxCPF.Name = "maskedTextBoxCPF";
            this.maskedTextBoxCPF.Size = new System.Drawing.Size(163, 23);
            this.maskedTextBoxCPF.TabIndex = 17;
            this.maskedTextBoxCPF.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // TelaCadastroCondutorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 363);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxID);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonGravar);
            this.Controls.Add(this.maskedTextBoxTelefone);
            this.Controls.Add(this.textBoxEndereco);
            this.Controls.Add(this.textBoxNome);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBoxCondutor);
            this.Name = "TelaCadastroCondutorForm";
            this.Text = "TelaCadastroCondutorForm";
            this.groupBoxCondutor.ResumeLayout(false);
            this.groupBoxCondutor.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxNome;
        private System.Windows.Forms.TextBox textBoxEndereco;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxTelefone;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxCNH;
        private System.Windows.Forms.ComboBox comboBoxEmpresa;
        private System.Windows.Forms.DateTimePicker dateTimePickerValidadeCNH;
        private System.Windows.Forms.Button buttonGravar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.GroupBox groupBoxCondutor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxCPF;
        public System.Windows.Forms.Button buttonCancelar;
    }
}