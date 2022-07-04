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
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.labelDataDevolucao = new System.Windows.Forms.Label();
            this.textBoxTanque = new System.Windows.Forms.TextBox();
            this.labelTanque = new System.Windows.Forms.Label();
            this.comboBoxLocacao = new System.Windows.Forms.ComboBox();
            this.labelLocacao = new System.Windows.Forms.Label();
            this.groupBoxDevolucao.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancelar.Location = new System.Drawing.Point(193, 143);
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
            this.buttonGravar.Location = new System.Drawing.Point(120, 143);
            this.buttonGravar.Name = "buttonGravar";
            this.buttonGravar.Size = new System.Drawing.Size(67, 33);
            this.buttonGravar.TabIndex = 3;
            this.buttonGravar.Text = "Gravar";
            this.buttonGravar.UseVisualStyleBackColor = true;
            // 
            // groupBoxDevolucao
            // 
            this.groupBoxDevolucao.Controls.Add(this.dateTimePicker1);
            this.groupBoxDevolucao.Controls.Add(this.labelDataDevolucao);
            this.groupBoxDevolucao.Controls.Add(this.textBoxTanque);
            this.groupBoxDevolucao.Controls.Add(this.labelTanque);
            this.groupBoxDevolucao.Controls.Add(this.comboBoxLocacao);
            this.groupBoxDevolucao.Controls.Add(this.labelLocacao);
            this.groupBoxDevolucao.Location = new System.Drawing.Point(12, 12);
            this.groupBoxDevolucao.Name = "groupBoxDevolucao";
            this.groupBoxDevolucao.Size = new System.Drawing.Size(248, 125);
            this.groupBoxDevolucao.TabIndex = 15;
            this.groupBoxDevolucao.TabStop = false;
            this.groupBoxDevolucao.Text = "Dados da devolução:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(115, 81);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(100, 23);
            this.dateTimePicker1.TabIndex = 2;
            // 
            // labelDataDevolucao
            // 
            this.labelDataDevolucao.AutoSize = true;
            this.labelDataDevolucao.Location = new System.Drawing.Point(6, 87);
            this.labelDataDevolucao.Name = "labelDataDevolucao";
            this.labelDataDevolucao.Size = new System.Drawing.Size(108, 15);
            this.labelDataDevolucao.TabIndex = 4;
            this.labelDataDevolucao.Text = "Data da devolução:";
            // 
            // textBoxTanque
            // 
            this.textBoxTanque.Location = new System.Drawing.Point(115, 51);
            this.textBoxTanque.MaxLength = 11;
            this.textBoxTanque.Name = "textBoxTanque";
            this.textBoxTanque.Size = new System.Drawing.Size(100, 23);
            this.textBoxTanque.TabIndex = 1;
            // 
            // labelTanque
            // 
            this.labelTanque.AutoSize = true;
            this.labelTanque.Location = new System.Drawing.Point(61, 54);
            this.labelTanque.Name = "labelTanque";
            this.labelTanque.Size = new System.Drawing.Size(48, 15);
            this.labelTanque.TabIndex = 2;
            this.labelTanque.Text = "Tanque:";
            // 
            // comboBoxLocacao
            // 
            this.comboBoxLocacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLocacao.FormattingEnabled = true;
            this.comboBoxLocacao.Location = new System.Drawing.Point(115, 22);
            this.comboBoxLocacao.Name = "comboBoxLocacao";
            this.comboBoxLocacao.Size = new System.Drawing.Size(121, 23);
            this.comboBoxLocacao.TabIndex = 0;
            // 
            // labelLocacao
            // 
            this.labelLocacao.AutoSize = true;
            this.labelLocacao.Location = new System.Drawing.Point(55, 25);
            this.labelLocacao.Name = "labelLocacao";
            this.labelLocacao.Size = new System.Drawing.Size(54, 15);
            this.labelLocacao.TabIndex = 0;
            this.labelLocacao.Text = "Locação:";
            // 
            // TelaCadastroDevolucaoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(268, 181);
            this.Controls.Add(this.groupBoxDevolucao);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonGravar);
            this.Name = "TelaCadastroDevolucaoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Devolução:";
            this.groupBoxDevolucao.ResumeLayout(false);
            this.groupBoxDevolucao.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Button buttonGravar;
        private System.Windows.Forms.GroupBox groupBoxDevolucao;
        private System.Windows.Forms.Label labelLocacao;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label labelDataDevolucao;
        private System.Windows.Forms.TextBox textBoxTanque;
        private System.Windows.Forms.Label labelTanque;
        private System.Windows.Forms.ComboBox comboBoxLocacao;
    }
}