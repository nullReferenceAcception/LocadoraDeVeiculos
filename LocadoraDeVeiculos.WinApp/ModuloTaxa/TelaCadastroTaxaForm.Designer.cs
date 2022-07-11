namespace LocadoraDeVeiculos.WinApp.ModuloTaxa
{
    partial class TelaCadastroTaxaForm
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
            this.groupBoxTaxa = new System.Windows.Forms.GroupBox();
            this.radioButtonDiario = new System.Windows.Forms.RadioButton();
            this.radioButtonFixo = new System.Windows.Forms.RadioButton();
            this.labelID = new System.Windows.Forms.Label();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.labelDescricao = new System.Windows.Forms.Label();
            this.textBoxDescricao = new System.Windows.Forms.TextBox();
            this.labelValor = new System.Windows.Forms.Label();
            this.textBoxValor = new System.Windows.Forms.TextBox();
            this.groupBoxTaxa.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancelar.Location = new System.Drawing.Point(186, 178);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(67, 33);
            this.buttonCancelar.TabIndex = 5;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            // 
            // buttonGravar
            // 
            this.buttonGravar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonGravar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonGravar.Location = new System.Drawing.Point(113, 178);
            this.buttonGravar.Name = "buttonGravar";
            this.buttonGravar.Size = new System.Drawing.Size(67, 33);
            this.buttonGravar.TabIndex = 4;
            this.buttonGravar.Text = "Gravar";
            this.buttonGravar.UseVisualStyleBackColor = true;
            this.buttonGravar.Click += new System.EventHandler(this.buttonGravar_Click);
            // 
            // groupBoxTaxa
            // 
            this.groupBoxTaxa.Controls.Add(this.radioButtonDiario);
            this.groupBoxTaxa.Controls.Add(this.radioButtonFixo);
            this.groupBoxTaxa.Controls.Add(this.labelID);
            this.groupBoxTaxa.Controls.Add(this.textBoxID);
            this.groupBoxTaxa.Controls.Add(this.labelDescricao);
            this.groupBoxTaxa.Controls.Add(this.textBoxDescricao);
            this.groupBoxTaxa.Controls.Add(this.labelValor);
            this.groupBoxTaxa.Controls.Add(this.textBoxValor);
            this.groupBoxTaxa.Location = new System.Drawing.Point(12, 14);
            this.groupBoxTaxa.Name = "groupBoxTaxa";
            this.groupBoxTaxa.Size = new System.Drawing.Size(241, 158);
            this.groupBoxTaxa.TabIndex = 6;
            this.groupBoxTaxa.TabStop = false;
            this.groupBoxTaxa.Text = "Dados de taxas:";
            // 
            // radioButtonDiario
            // 
            this.radioButtonDiario.AutoSize = true;
            this.radioButtonDiario.Location = new System.Drawing.Point(84, 133);
            this.radioButtonDiario.Name = "radioButtonDiario";
            this.radioButtonDiario.Size = new System.Drawing.Size(56, 19);
            this.radioButtonDiario.TabIndex = 3;
            this.radioButtonDiario.TabStop = true;
            this.radioButtonDiario.Text = "Diario";
            this.radioButtonDiario.UseVisualStyleBackColor = true;
            // 
            // radioButtonFixo
            // 
            this.radioButtonFixo.AutoSize = true;
            this.radioButtonFixo.Location = new System.Drawing.Point(84, 112);
            this.radioButtonFixo.Name = "radioButtonFixo";
            this.radioButtonFixo.Size = new System.Drawing.Size(47, 19);
            this.radioButtonFixo.TabIndex = 2;
            this.radioButtonFixo.TabStop = true;
            this.radioButtonFixo.Text = "Fixo";
            this.radioButtonFixo.UseVisualStyleBackColor = true;
            // 
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.labelID.Location = new System.Drawing.Point(45, 29);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(21, 15);
            this.labelID.TabIndex = 29;
            this.labelID.Text = "guid:";
            // 
            // textBoxID
            // 
            this.textBoxID.Enabled = false;
            this.textBoxID.Location = new System.Drawing.Point(84, 25);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.ReadOnly = true;
            this.textBoxID.Size = new System.Drawing.Size(75, 23);
            this.textBoxID.TabIndex = 30;
            // 
            // labelDescricao
            // 
            this.labelDescricao.AutoSize = true;
            this.labelDescricao.Location = new System.Drawing.Point(5, 57);
            this.labelDescricao.Name = "labelDescricao";
            this.labelDescricao.Size = new System.Drawing.Size(61, 15);
            this.labelDescricao.TabIndex = 1;
            this.labelDescricao.Text = "Descrição:";
            // 
            // textBoxDescricao
            // 
            this.textBoxDescricao.Location = new System.Drawing.Point(84, 54);
            this.textBoxDescricao.MaxLength = 255;
            this.textBoxDescricao.Name = "textBoxDescricao";
            this.textBoxDescricao.Size = new System.Drawing.Size(143, 23);
            this.textBoxDescricao.TabIndex = 0;
            // 
            // labelValor
            // 
            this.labelValor.AutoSize = true;
            this.labelValor.Location = new System.Drawing.Point(30, 86);
            this.labelValor.Name = "labelValor";
            this.labelValor.Size = new System.Drawing.Size(36, 15);
            this.labelValor.TabIndex = 3;
            this.labelValor.Text = "Valor:";
            // 
            // textBoxValor
            // 
            this.textBoxValor.Location = new System.Drawing.Point(84, 83);
            this.textBoxValor.MaxLength = 255;
            this.textBoxValor.Name = "textBoxValor";
            this.textBoxValor.Size = new System.Drawing.Size(143, 23);
            this.textBoxValor.TabIndex = 1;
            // 
            // TelaCadastroTaxaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 218);
            this.Controls.Add(this.groupBoxTaxa);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonGravar);
            this.Name = "TelaCadastroTaxaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Taxas";
            this.groupBoxTaxa.ResumeLayout(false);
            this.groupBoxTaxa.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonGravar;
        public System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.GroupBox groupBoxTaxa;
        private System.Windows.Forms.Label labelDescricao;
        private System.Windows.Forms.TextBox textBoxDescricao;
        private System.Windows.Forms.Label labelValor;
        private System.Windows.Forms.TextBox textBoxValor;
        private System.Windows.Forms.Label labelID;
        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.RadioButton radioButtonDiario;
        private System.Windows.Forms.RadioButton radioButtonFixo;
    }
}