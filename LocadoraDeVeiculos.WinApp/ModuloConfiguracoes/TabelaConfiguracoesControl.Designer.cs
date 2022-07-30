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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageLogs = new System.Windows.Forms.TabPage();
            this.buttonPesquisar = new System.Windows.Forms.Button();
            this.buttonAbrirSeq = new System.Windows.Forms.Button();
            this.textBoxUrlSeq = new System.Windows.Forms.TextBox();
            this.labelUrlSeq = new System.Windows.Forms.Label();
            this.textBoxDiretorioLog = new System.Windows.Forms.TextBox();
            this.labelDiretorioLogs = new System.Windows.Forms.Label();
            this.tabPageDatabase = new System.Windows.Forms.TabPage();
            this.buttonCopiar = new System.Windows.Forms.Button();
            this.labelConnectionString = new System.Windows.Forms.Label();
            this.textBoxConnectionString = new System.Windows.Forms.TextBox();
            this.tabPageCombustiveis = new System.Windows.Forms.TabPage();
            this.numericUpDownGNV = new System.Windows.Forms.NumericUpDown();
            this.labelGNV = new System.Windows.Forms.Label();
            this.numericUpDownEtanol = new System.Windows.Forms.NumericUpDown();
            this.labelEtanol = new System.Windows.Forms.Label();
            this.numericUpDownDiesel = new System.Windows.Forms.NumericUpDown();
            this.labelDiesel = new System.Windows.Forms.Label();
            this.labelAlcool = new System.Windows.Forms.Label();
            this.labelGasolina = new System.Windows.Forms.Label();
            this.numericUpDownAlcool = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownGasolina = new System.Windows.Forms.NumericUpDown();
            this.buttonGravar = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabPageLogs.SuspendLayout();
            this.tabPageDatabase.SuspendLayout();
            this.tabPageCombustiveis.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGNV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEtanol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDiesel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAlcool)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGasolina)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageLogs);
            this.tabControl.Controls.Add(this.tabPageDatabase);
            this.tabControl.Controls.Add(this.tabPageCombustiveis);
            this.tabControl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.tabControl.Location = new System.Drawing.Point(3, 3);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1541, 527);
            this.tabControl.TabIndex = 0;
            // 
            // tabPageLogs
            // 
            this.tabPageLogs.BackColor = System.Drawing.Color.DarkGray;
            this.tabPageLogs.Controls.Add(this.buttonPesquisar);
            this.tabPageLogs.Controls.Add(this.buttonAbrirSeq);
            this.tabPageLogs.Controls.Add(this.textBoxUrlSeq);
            this.tabPageLogs.Controls.Add(this.labelUrlSeq);
            this.tabPageLogs.Controls.Add(this.textBoxDiretorioLog);
            this.tabPageLogs.Controls.Add(this.labelDiretorioLogs);
            this.tabPageLogs.Location = new System.Drawing.Point(4, 24);
            this.tabPageLogs.Name = "tabPageLogs";
            this.tabPageLogs.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLogs.Size = new System.Drawing.Size(1533, 499);
            this.tabPageLogs.TabIndex = 0;
            this.tabPageLogs.Text = "Configurações de LOG";
            // 
            // buttonPesquisar
            // 
            this.buttonPesquisar.Location = new System.Drawing.Point(741, 44);
            this.buttonPesquisar.Name = "buttonPesquisar";
            this.buttonPesquisar.Size = new System.Drawing.Size(94, 23);
            this.buttonPesquisar.TabIndex = 6;
            this.buttonPesquisar.Text = "Pesquisar";
            this.buttonPesquisar.UseVisualStyleBackColor = true;
            // 
            // buttonAbrirSeq
            // 
            this.buttonAbrirSeq.Location = new System.Drawing.Point(425, 89);
            this.buttonAbrirSeq.Name = "buttonAbrirSeq";
            this.buttonAbrirSeq.Size = new System.Drawing.Size(119, 23);
            this.buttonAbrirSeq.TabIndex = 5;
            this.buttonAbrirSeq.Text = "Abrir no navegador";
            this.buttonAbrirSeq.UseVisualStyleBackColor = true;
            this.buttonAbrirSeq.Click += new System.EventHandler(this.buttonAbrirSeq_Click);
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
            this.tabPageDatabase.Controls.Add(this.buttonCopiar);
            this.tabPageDatabase.Controls.Add(this.labelConnectionString);
            this.tabPageDatabase.Controls.Add(this.textBoxConnectionString);
            this.tabPageDatabase.Location = new System.Drawing.Point(4, 24);
            this.tabPageDatabase.Name = "tabPageDatabase";
            this.tabPageDatabase.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDatabase.Size = new System.Drawing.Size(1533, 499);
            this.tabPageDatabase.TabIndex = 1;
            this.tabPageDatabase.Text = "Configurações de Banco de Dados";
            // 
            // buttonCopiar
            // 
            this.buttonCopiar.Location = new System.Drawing.Point(26, 64);
            this.buttonCopiar.Name = "buttonCopiar";
            this.buttonCopiar.Size = new System.Drawing.Size(75, 23);
            this.buttonCopiar.TabIndex = 6;
            this.buttonCopiar.Text = "Copiar";
            this.buttonCopiar.UseVisualStyleBackColor = true;
            this.buttonCopiar.Click += new System.EventHandler(this.buttonCopiar_Click);
            // 
            // labelConnectionString
            // 
            this.labelConnectionString.AutoSize = true;
            this.labelConnectionString.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelConnectionString.Location = new System.Drawing.Point(26, 17);
            this.labelConnectionString.Name = "labelConnectionString";
            this.labelConnectionString.Size = new System.Drawing.Size(105, 15);
            this.labelConnectionString.TabIndex = 5;
            this.labelConnectionString.Text = "Connection string:";
            // 
            // textBoxConnectionString
            // 
            this.textBoxConnectionString.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxConnectionString.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxConnectionString.Location = new System.Drawing.Point(26, 35);
            this.textBoxConnectionString.Name = "textBoxConnectionString";
            this.textBoxConnectionString.Size = new System.Drawing.Size(1170, 23);
            this.textBoxConnectionString.TabIndex = 4;
            // 
            // tabPageCombustiveis
            // 
            this.tabPageCombustiveis.BackColor = System.Drawing.Color.DarkGray;
            this.tabPageCombustiveis.Controls.Add(this.numericUpDownGNV);
            this.tabPageCombustiveis.Controls.Add(this.labelGNV);
            this.tabPageCombustiveis.Controls.Add(this.numericUpDownEtanol);
            this.tabPageCombustiveis.Controls.Add(this.labelEtanol);
            this.tabPageCombustiveis.Controls.Add(this.numericUpDownDiesel);
            this.tabPageCombustiveis.Controls.Add(this.labelDiesel);
            this.tabPageCombustiveis.Controls.Add(this.labelAlcool);
            this.tabPageCombustiveis.Controls.Add(this.labelGasolina);
            this.tabPageCombustiveis.Controls.Add(this.numericUpDownAlcool);
            this.tabPageCombustiveis.Controls.Add(this.numericUpDownGasolina);
            this.tabPageCombustiveis.Location = new System.Drawing.Point(4, 24);
            this.tabPageCombustiveis.Name = "tabPageCombustiveis";
            this.tabPageCombustiveis.Size = new System.Drawing.Size(1533, 499);
            this.tabPageCombustiveis.TabIndex = 2;
            this.tabPageCombustiveis.Text = "Configuração do Preços dos Combustíveis";
            // 
            // numericUpDownGNV
            // 
            this.numericUpDownGNV.DecimalPlaces = 2;
            this.numericUpDownGNV.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericUpDownGNV.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDownGNV.Location = new System.Drawing.Point(14, 193);
            this.numericUpDownGNV.Name = "numericUpDownGNV";
            this.numericUpDownGNV.Size = new System.Drawing.Size(77, 25);
            this.numericUpDownGNV.TabIndex = 9;
            // 
            // labelGNV
            // 
            this.labelGNV.AutoSize = true;
            this.labelGNV.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelGNV.Location = new System.Drawing.Point(14, 177);
            this.labelGNV.Name = "labelGNV";
            this.labelGNV.Size = new System.Drawing.Size(58, 15);
            this.labelGNV.TabIndex = 8;
            this.labelGNV.Text = "GNV (R$):";
            // 
            // numericUpDownEtanol
            // 
            this.numericUpDownEtanol.DecimalPlaces = 2;
            this.numericUpDownEtanol.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericUpDownEtanol.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDownEtanol.Location = new System.Drawing.Point(14, 151);
            this.numericUpDownEtanol.Name = "numericUpDownEtanol";
            this.numericUpDownEtanol.Size = new System.Drawing.Size(77, 25);
            this.numericUpDownEtanol.TabIndex = 7;
            // 
            // labelEtanol
            // 
            this.labelEtanol.AutoSize = true;
            this.labelEtanol.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelEtanol.Location = new System.Drawing.Point(14, 135);
            this.labelEtanol.Name = "labelEtanol";
            this.labelEtanol.Size = new System.Drawing.Size(67, 15);
            this.labelEtanol.TabIndex = 6;
            this.labelEtanol.Text = "Etanol (R$):";
            // 
            // numericUpDownDiesel
            // 
            this.numericUpDownDiesel.DecimalPlaces = 2;
            this.numericUpDownDiesel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericUpDownDiesel.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDownDiesel.Location = new System.Drawing.Point(14, 109);
            this.numericUpDownDiesel.Name = "numericUpDownDiesel";
            this.numericUpDownDiesel.Size = new System.Drawing.Size(77, 25);
            this.numericUpDownDiesel.TabIndex = 5;
            // 
            // labelDiesel
            // 
            this.labelDiesel.AutoSize = true;
            this.labelDiesel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelDiesel.Location = new System.Drawing.Point(14, 93);
            this.labelDiesel.Name = "labelDiesel";
            this.labelDiesel.Size = new System.Drawing.Size(65, 15);
            this.labelDiesel.TabIndex = 4;
            this.labelDiesel.Text = "Diesel (R$):";
            // 
            // labelAlcool
            // 
            this.labelAlcool.AutoSize = true;
            this.labelAlcool.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelAlcool.Location = new System.Drawing.Point(14, 51);
            this.labelAlcool.Name = "labelAlcool";
            this.labelAlcool.Size = new System.Drawing.Size(68, 15);
            this.labelAlcool.TabIndex = 3;
            this.labelAlcool.Text = "Álcool (R$):";
            // 
            // labelGasolina
            // 
            this.labelGasolina.AutoSize = true;
            this.labelGasolina.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelGasolina.Location = new System.Drawing.Point(14, 9);
            this.labelGasolina.Name = "labelGasolina";
            this.labelGasolina.Size = new System.Drawing.Size(79, 15);
            this.labelGasolina.TabIndex = 2;
            this.labelGasolina.Text = "Gasolina (R$):";
            // 
            // numericUpDownAlcool
            // 
            this.numericUpDownAlcool.DecimalPlaces = 2;
            this.numericUpDownAlcool.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericUpDownAlcool.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDownAlcool.Location = new System.Drawing.Point(14, 67);
            this.numericUpDownAlcool.Name = "numericUpDownAlcool";
            this.numericUpDownAlcool.Size = new System.Drawing.Size(77, 25);
            this.numericUpDownAlcool.TabIndex = 1;
            // 
            // numericUpDownGasolina
            // 
            this.numericUpDownGasolina.DecimalPlaces = 2;
            this.numericUpDownGasolina.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericUpDownGasolina.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDownGasolina.Location = new System.Drawing.Point(14, 25);
            this.numericUpDownGasolina.Name = "numericUpDownGasolina";
            this.numericUpDownGasolina.Size = new System.Drawing.Size(77, 25);
            this.numericUpDownGasolina.TabIndex = 0;
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
            this.buttonGravar.Click += new System.EventHandler(this.buttonGravar_Click);
            // 
            // TabelaConfiguracoesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Controls.Add(this.buttonGravar);
            this.Controls.Add(this.tabControl);
            this.Name = "TabelaConfiguracoesControl";
            this.Size = new System.Drawing.Size(1550, 590);
            this.tabControl.ResumeLayout(false);
            this.tabPageLogs.ResumeLayout(false);
            this.tabPageLogs.PerformLayout();
            this.tabPageDatabase.ResumeLayout(false);
            this.tabPageDatabase.PerformLayout();
            this.tabPageCombustiveis.ResumeLayout(false);
            this.tabPageCombustiveis.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGNV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEtanol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDiesel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAlcool)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGasolina)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageLogs;
        private System.Windows.Forms.TextBox textBoxDiretorioLog;
        private System.Windows.Forms.Label labelDiretorioLogs;
        private System.Windows.Forms.TabPage tabPageDatabase;
        private System.Windows.Forms.Button buttonGravar;
        private System.Windows.Forms.TextBox textBoxUrlSeq;
        private System.Windows.Forms.Label labelUrlSeq;
        private System.Windows.Forms.Label labelConnectionString;
        private System.Windows.Forms.TextBox textBoxConnectionString;
        private System.Windows.Forms.TabPage tabPageCombustiveis;
        private System.Windows.Forms.NumericUpDown numericUpDownAlcool;
        private System.Windows.Forms.NumericUpDown numericUpDownGasolina;
        private System.Windows.Forms.Label labelAlcool;
        private System.Windows.Forms.Label labelGasolina;
        private System.Windows.Forms.NumericUpDown numericUpDownGNV;
        private System.Windows.Forms.Label labelGNV;
        private System.Windows.Forms.NumericUpDown numericUpDownEtanol;
        private System.Windows.Forms.Label labelEtanol;
        private System.Windows.Forms.NumericUpDown numericUpDownDiesel;
        private System.Windows.Forms.Label labelDiesel;
        private System.Windows.Forms.Button buttonPesquisar;
        private System.Windows.Forms.Button buttonAbrirSeq;
        private System.Windows.Forms.Button buttonCopiar;
    }
}
