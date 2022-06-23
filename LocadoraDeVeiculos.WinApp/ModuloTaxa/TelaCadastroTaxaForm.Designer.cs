﻿namespace LocadoraDeVeiculos.WinApp.ModuloTaxa
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
            this.panelFundo = new System.Windows.Forms.Panel();
            this.groupBoxTaxa = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.labelDescricao = new System.Windows.Forms.Label();
            this.buttonGravar = new System.Windows.Forms.Button();
            this.textBoxDescricao = new System.Windows.Forms.TextBox();
            this.labelValor = new System.Windows.Forms.Label();
            this.textBoxValor = new System.Windows.Forms.TextBox();
            this.panelFundo.SuspendLayout();
            this.groupBoxTaxa.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelFundo
            // 
            this.panelFundo.Controls.Add(this.groupBoxTaxa);
            this.panelFundo.Location = new System.Drawing.Point(12, 12);
            this.panelFundo.Name = "panelFundo";
            this.panelFundo.Size = new System.Drawing.Size(318, 240);
            this.panelFundo.TabIndex = 0;
            // 
            // groupBoxTaxa
            // 
            this.groupBoxTaxa.Controls.Add(this.button2);
            this.groupBoxTaxa.Controls.Add(this.labelDescricao);
            this.groupBoxTaxa.Controls.Add(this.buttonGravar);
            this.groupBoxTaxa.Controls.Add(this.textBoxDescricao);
            this.groupBoxTaxa.Controls.Add(this.labelValor);
            this.groupBoxTaxa.Controls.Add(this.textBoxValor);
            this.groupBoxTaxa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxTaxa.Location = new System.Drawing.Point(0, 0);
            this.groupBoxTaxa.Name = "groupBoxTaxa";
            this.groupBoxTaxa.Size = new System.Drawing.Size(318, 240);
            this.groupBoxTaxa.TabIndex = 6;
            this.groupBoxTaxa.TabStop = false;
            this.groupBoxTaxa.Text = "Dados de taxas:";
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(182, 145);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(67, 33);
            this.button2.TabIndex = 5;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // labelDescricao
            // 
            this.labelDescricao.AutoSize = true;
            this.labelDescricao.Location = new System.Drawing.Point(38, 65);
            this.labelDescricao.Name = "labelDescricao";
            this.labelDescricao.Size = new System.Drawing.Size(61, 15);
            this.labelDescricao.TabIndex = 1;
            this.labelDescricao.Text = "Descrição:";
            // 
            // buttonGravar
            // 
            this.buttonGravar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonGravar.Location = new System.Drawing.Point(105, 145);
            this.buttonGravar.Name = "buttonGravar";
            this.buttonGravar.Size = new System.Drawing.Size(67, 33);
            this.buttonGravar.TabIndex = 4;
            this.buttonGravar.Text = "Gravar";
            this.buttonGravar.UseVisualStyleBackColor = true;
            this.buttonGravar.Click += new System.EventHandler(this.buttonGravar_Click);
            // 
            // textBoxDescricao
            // 
            this.textBoxDescricao.Location = new System.Drawing.Point(105, 61);
            this.textBoxDescricao.MaxLength = 255;
            this.textBoxDescricao.Name = "textBoxDescricao";
            this.textBoxDescricao.Size = new System.Drawing.Size(143, 23);
            this.textBoxDescricao.TabIndex = 0;
            // 
            // labelValor
            // 
            this.labelValor.AutoSize = true;
            this.labelValor.Location = new System.Drawing.Point(63, 105);
            this.labelValor.Name = "labelValor";
            this.labelValor.Size = new System.Drawing.Size(36, 15);
            this.labelValor.TabIndex = 3;
            this.labelValor.Text = "Valor:";
            // 
            // textBoxValor
            // 
            this.textBoxValor.Location = new System.Drawing.Point(105, 101);
            this.textBoxValor.MaxLength = 255;
            this.textBoxValor.Name = "textBoxValor";
            this.textBoxValor.Size = new System.Drawing.Size(143, 23);
            this.textBoxValor.TabIndex = 2;
            // 
            // TelaCadastroTaxaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 264);
            this.Controls.Add(this.panelFundo);
            this.Name = "TelaCadastroTaxaForm";
            this.Text = "Cadastro de Taxas";
            this.panelFundo.ResumeLayout(false);
            this.groupBoxTaxa.ResumeLayout(false);
            this.groupBoxTaxa.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelFundo;
        private System.Windows.Forms.Label labelDescricao;
        private System.Windows.Forms.TextBox textBoxDescricao;
        private System.Windows.Forms.GroupBox groupBoxTaxa;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button buttonGravar;
        private System.Windows.Forms.Label labelValor;
        private System.Windows.Forms.TextBox textBoxValor;
    }
}