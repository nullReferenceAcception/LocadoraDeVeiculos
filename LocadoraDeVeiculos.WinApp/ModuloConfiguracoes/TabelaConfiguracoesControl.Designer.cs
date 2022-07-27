namespace LocadoraDeVeiculos.WinApp.ModuloConfiguracoes
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
            this.textBoxDiretorioLog = new System.Windows.Forms.TextBox();
            this.labelDiretorioLogs = new System.Windows.Forms.Label();
            this.tabPageDatabase = new System.Windows.Forms.TabPage();
            this.buttonGravar = new System.Windows.Forms.Button();
            this.buttonProcurar = new System.Windows.Forms.Button();
            this.labelUrlSeq = new System.Windows.Forms.Label();
            this.textBoxUrlSeq = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPageLogs.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageLogs);
            this.tabControl1.Controls.Add(this.tabPageDatabase);
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(931, 490);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageLogs
            // 
            this.tabPageLogs.Controls.Add(this.textBoxUrlSeq);
            this.tabPageLogs.Controls.Add(this.labelUrlSeq);
            this.tabPageLogs.Controls.Add(this.buttonProcurar);
            this.tabPageLogs.Controls.Add(this.textBoxDiretorioLog);
            this.tabPageLogs.Controls.Add(this.labelDiretorioLogs);
            this.tabPageLogs.Location = new System.Drawing.Point(4, 24);
            this.tabPageLogs.Name = "tabPageLogs";
            this.tabPageLogs.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLogs.Size = new System.Drawing.Size(923, 462);
            this.tabPageLogs.TabIndex = 0;
            this.tabPageLogs.Text = "Configurações de LOG";
            this.tabPageLogs.UseVisualStyleBackColor = true;
            // 
            // textBoxDiretorioLog
            // 
            this.textBoxDiretorioLog.Location = new System.Drawing.Point(24, 45);
            this.textBoxDiretorioLog.Name = "textBoxDiretorioLog";
            this.textBoxDiretorioLog.Size = new System.Drawing.Size(699, 23);
            this.textBoxDiretorioLog.TabIndex = 1;
            // 
            // labelDiretorioLogs
            // 
            this.labelDiretorioLogs.AutoSize = true;
            this.labelDiretorioLogs.Location = new System.Drawing.Point(24, 27);
            this.labelDiretorioLogs.Name = "labelDiretorioLogs";
            this.labelDiretorioLogs.Size = new System.Drawing.Size(97, 15);
            this.labelDiretorioLogs.TabIndex = 0;
            this.labelDiretorioLogs.Text = "Diretório de logs:";
            // 
            // tabPageDatabase
            // 
            this.tabPageDatabase.Location = new System.Drawing.Point(4, 24);
            this.tabPageDatabase.Name = "tabPageDatabase";
            this.tabPageDatabase.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDatabase.Size = new System.Drawing.Size(923, 462);
            this.tabPageDatabase.TabIndex = 1;
            this.tabPageDatabase.Text = "Configurações de Banco de Dados";
            this.tabPageDatabase.UseVisualStyleBackColor = true;
            // 
            // buttonGravar
            // 
            this.buttonGravar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonGravar.Location = new System.Drawing.Point(791, 495);
            this.buttonGravar.Name = "buttonGravar";
            this.buttonGravar.Size = new System.Drawing.Size(136, 50);
            this.buttonGravar.TabIndex = 1;
            this.buttonGravar.Text = "Gravar configurações";
            this.buttonGravar.UseVisualStyleBackColor = true;
            // 
            // buttonProcurar
            // 
            this.buttonProcurar.Location = new System.Drawing.Point(729, 45);
            this.buttonProcurar.Name = "buttonProcurar";
            this.buttonProcurar.Size = new System.Drawing.Size(75, 23);
            this.buttonProcurar.TabIndex = 2;
            this.buttonProcurar.Text = "Procurar";
            this.buttonProcurar.UseVisualStyleBackColor = true;
            // 
            // labelUrlSeq
            // 
            this.labelUrlSeq.AutoSize = true;
            this.labelUrlSeq.Location = new System.Drawing.Point(24, 71);
            this.labelUrlSeq.Name = "labelUrlSeq";
            this.labelUrlSeq.Size = new System.Drawing.Size(55, 15);
            this.labelUrlSeq.TabIndex = 3;
            this.labelUrlSeq.Text = "URL SEQ:";
            // 
            // textBoxUrlSeq
            // 
            this.textBoxUrlSeq.Location = new System.Drawing.Point(24, 89);
            this.textBoxUrlSeq.Name = "textBoxUrlSeq";
            this.textBoxUrlSeq.Size = new System.Drawing.Size(385, 23);
            this.textBoxUrlSeq.TabIndex = 4;
            // 
            // TabelaConfiguracoesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonGravar);
            this.Controls.Add(this.tabControl1);
            this.Name = "TabelaConfiguracoesControl";
            this.Size = new System.Drawing.Size(937, 548);
            this.tabControl1.ResumeLayout(false);
            this.tabPageLogs.ResumeLayout(false);
            this.tabPageLogs.PerformLayout();
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
    }
}
