﻿namespace LocadoraDeVeiculos.WinApp.ModuloConfiguracoes
{
    partial class TabelaConfiguracoesControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageLogs = new System.Windows.Forms.TabPage();
            this.textBoxUrlSeq = new System.Windows.Forms.TextBox();
            this.labelUrlSeq = new System.Windows.Forms.Label();
            this.buttonProcurar = new System.Windows.Forms.Button();
            this.textBoxDiretorioLog = new System.Windows.Forms.TextBox();
            this.labelDiretorioLogs = new System.Windows.Forms.Label();
            this.tabPageDatabase = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxConnectionString = new System.Windows.Forms.TextBox();
            this.buttonGravar = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPageLogs.SuspendLayout();
            this.tabPageDatabase.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageLogs);
            this.tabControl1.Controls.Add(this.tabPageDatabase);
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1541, 527);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageLogs
            // 
            this.tabPageLogs.BackColor = System.Drawing.Color.DarkGray;
            this.tabPageLogs.Controls.Add(this.textBoxUrlSeq);
            this.tabPageLogs.Controls.Add(this.labelUrlSeq);
            this.tabPageLogs.Controls.Add(this.buttonProcurar);
            this.tabPageLogs.Controls.Add(this.textBoxDiretorioLog);
            this.tabPageLogs.Controls.Add(this.labelDiretorioLogs);
            this.tabPageLogs.Location = new System.Drawing.Point(4, 24);
            this.tabPageLogs.Name = "tabPageLogs";
            this.tabPageLogs.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLogs.Size = new System.Drawing.Size(1533, 499);
            this.tabPageLogs.TabIndex = 0;
            this.tabPageLogs.Text = "Configurações de LOG";
            // 
            // textBoxUrlSeq
            // 
            this.textBoxUrlSeq.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxUrlSeq.Location = new System.Drawing.Point(24, 89);
            this.textBoxUrlSeq.Name = "textBoxUrlSeq";
            this.textBoxUrlSeq.Size = new System.Drawing.Size(385, 23);
            this.textBoxUrlSeq.TabIndex = 4;
            // 
            // labelUrlSeq
            // 
            this.labelUrlSeq.AutoSize = true;
            this.labelUrlSeq.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelUrlSeq.Location = new System.Drawing.Point(24, 71);
            this.labelUrlSeq.Name = "labelUrlSeq";
            this.labelUrlSeq.Size = new System.Drawing.Size(55, 15);
            this.labelUrlSeq.TabIndex = 3;
            this.labelUrlSeq.Text = "URL SEQ:";
            // 
            // buttonProcurar
            // 
            this.buttonProcurar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonProcurar.Location = new System.Drawing.Point(729, 45);
            this.buttonProcurar.Name = "buttonProcurar";
            this.buttonProcurar.Size = new System.Drawing.Size(75, 23);
            this.buttonProcurar.TabIndex = 2;
            this.buttonProcurar.Text = "Procurar";
            this.buttonProcurar.UseVisualStyleBackColor = true;
            this.buttonProcurar.Click += new System.EventHandler(this.buttonProcurar_Click);
            // 
            // textBoxDiretorioLog
            // 
            this.textBoxDiretorioLog.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxDiretorioLog.Location = new System.Drawing.Point(24, 45);
            this.textBoxDiretorioLog.Name = "textBoxDiretorioLog";
            this.textBoxDiretorioLog.Size = new System.Drawing.Size(699, 23);
            this.textBoxDiretorioLog.TabIndex = 1;
            // 
            // labelDiretorioLogs
            // 
            this.labelDiretorioLogs.AutoSize = true;
            this.labelDiretorioLogs.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelDiretorioLogs.Location = new System.Drawing.Point(24, 27);
            this.labelDiretorioLogs.Name = "labelDiretorioLogs";
            this.labelDiretorioLogs.Size = new System.Drawing.Size(97, 15);
            this.labelDiretorioLogs.TabIndex = 0;
            this.labelDiretorioLogs.Text = "Diretório de logs:";
            // 
            // tabPageDatabase
            // 
            this.tabPageDatabase.BackColor = System.Drawing.Color.DarkGray;
            this.tabPageDatabase.Controls.Add(this.label3);
            this.tabPageDatabase.Controls.Add(this.textBoxConnectionString);
            this.tabPageDatabase.Location = new System.Drawing.Point(4, 24);
            this.tabPageDatabase.Name = "tabPageDatabase";
            this.tabPageDatabase.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDatabase.Size = new System.Drawing.Size(1533, 499);
            this.tabPageDatabase.TabIndex = 1;
            this.tabPageDatabase.Text = "Configurações de Banco de Dados";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(26, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Conection string:";
            // 
            // textBoxConnectionString
            // 
            this.textBoxConnectionString.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxConnectionString.Location = new System.Drawing.Point(26, 35);
            this.textBoxConnectionString.Name = "textBoxConnectionString";
            this.textBoxConnectionString.Size = new System.Drawing.Size(416, 23);
            this.textBoxConnectionString.TabIndex = 4;
            // 
            // buttonGravar
            // 
            this.buttonGravar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonGravar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.buttonGravar.Location = new System.Drawing.Point(1404, 536);
            this.buttonGravar.Name = "buttonGravar";
            this.buttonGravar.Size = new System.Drawing.Size(136, 50);
            this.buttonGravar.TabIndex = 1;
            this.buttonGravar.Text = "Gravar configurações";
            this.buttonGravar.UseVisualStyleBackColor = true;
            // 
            // TabelaConfiguracoesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Controls.Add(this.buttonGravar);
            this.Controls.Add(this.tabControl1);
            this.Name = "TabelaConfiguracoesControl";
            this.Size = new System.Drawing.Size(1550, 590);
            this.tabControl1.ResumeLayout(false);
            this.tabPageLogs.ResumeLayout(false);
            this.tabPageLogs.PerformLayout();
            this.tabPageDatabase.ResumeLayout(false);
            this.tabPageDatabase.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageLogs;
        private System.Windows.Forms.TextBox textBoxDiretorioLog;
        private System.Windows.Forms.Label labelDiretorioLogs;
        private System.Windows.Forms.TabPage tabPageDatabase;
        private System.Windows.Forms.Button buttonGravar;
        private System.Windows.Forms.Button buttonProcurar;
        private System.Windows.Forms.TextBox textBoxUrlSeq;
        private System.Windows.Forms.Label labelUrlSeq;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxConnectionString;
    }
}
