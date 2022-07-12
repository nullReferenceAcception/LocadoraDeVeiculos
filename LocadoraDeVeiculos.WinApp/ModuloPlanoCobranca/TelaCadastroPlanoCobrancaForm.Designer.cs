namespace LocadoraDeVeiculos.WinApp.ModuloPlanoCobranca
{
    partial class TelaCadastroPlanoCobrancaForm
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
            this.groupBoxTaxa = new System.Windows.Forms.GroupBox();
            this.comboBoxPlano = new System.Windows.Forms.ComboBox();
            this.labelPlano = new System.Windows.Forms.Label();
            this.textBoxValorPorKm = new System.Windows.Forms.TextBox();
            this.labelValorPorKm = new System.Windows.Forms.Label();
            this.textBoxValorDia = new System.Windows.Forms.TextBox();
            this.labelValorDia = new System.Windows.Forms.Label();
            this.labelKmIncluso = new System.Windows.Forms.Label();
            this.numericUpDownKmIncluso = new System.Windows.Forms.NumericUpDown();
            this.comboBoxGrupoVeiculos = new System.Windows.Forms.ComboBox();
            this.labelGuid = new System.Windows.Forms.Label();
            this.textBoxGuid = new System.Windows.Forms.TextBox();
            this.labelNome = new System.Windows.Forms.Label();
            this.textBoxNome = new System.Windows.Forms.TextBox();
            this.labelGrupoVeiculos = new System.Windows.Forms.Label();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.buttonGravar = new System.Windows.Forms.Button();
            this.groupBoxTaxa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownKmIncluso)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxTaxa
            // 
            this.groupBoxTaxa.Controls.Add(this.comboBoxPlano);
            this.groupBoxTaxa.Controls.Add(this.labelPlano);
            this.groupBoxTaxa.Controls.Add(this.textBoxValorPorKm);
            this.groupBoxTaxa.Controls.Add(this.labelValorPorKm);
            this.groupBoxTaxa.Controls.Add(this.textBoxValorDia);
            this.groupBoxTaxa.Controls.Add(this.labelValorDia);
            this.groupBoxTaxa.Controls.Add(this.labelKmIncluso);
            this.groupBoxTaxa.Controls.Add(this.numericUpDownKmIncluso);
            this.groupBoxTaxa.Controls.Add(this.comboBoxGrupoVeiculos);
            this.groupBoxTaxa.Controls.Add(this.labelGuid);
            this.groupBoxTaxa.Controls.Add(this.textBoxGuid);
            this.groupBoxTaxa.Controls.Add(this.labelNome);
            this.groupBoxTaxa.Controls.Add(this.textBoxNome);
            this.groupBoxTaxa.Controls.Add(this.labelGrupoVeiculos);
            this.groupBoxTaxa.Location = new System.Drawing.Point(12, 12);
            this.groupBoxTaxa.Name = "groupBoxTaxa";
            this.groupBoxTaxa.Size = new System.Drawing.Size(258, 329);
            this.groupBoxTaxa.TabIndex = 9;
            this.groupBoxTaxa.TabStop = false;
            this.groupBoxTaxa.Text = "Dados de taxas:";
            // 
            // comboBoxPlano
            // 
            this.comboBoxPlano.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPlano.FormattingEnabled = true;
            this.comboBoxPlano.Items.AddRange(new object[] {
            "Diario",
            "Km controlado",
            "Km livre"});
            this.comboBoxPlano.Location = new System.Drawing.Point(15, 169);
            this.comboBoxPlano.Name = "comboBoxPlano";
            this.comboBoxPlano.Size = new System.Drawing.Size(143, 23);
            this.comboBoxPlano.TabIndex = 2;
            this.comboBoxPlano.SelectedIndexChanged += new System.EventHandler(this.comboBoxPlano_SelectedIndexChanged);
            // 
            // labelPlano
            // 
            this.labelPlano.AutoSize = true;
            this.labelPlano.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelPlano.Location = new System.Drawing.Point(15, 151);
            this.labelPlano.Name = "labelPlano";
            this.labelPlano.Size = new System.Drawing.Size(40, 15);
            this.labelPlano.TabIndex = 37;
            this.labelPlano.Text = "Plano:";
            this.labelPlano.Click += new System.EventHandler(this.labelPlano_Click);
            // 
            // textBoxValorPorKm
            // 
            this.textBoxValorPorKm.Location = new System.Drawing.Point(15, 301);
            this.textBoxValorPorKm.MaxLength = 255;
            this.textBoxValorPorKm.Name = "textBoxValorPorKm";
            this.textBoxValorPorKm.Size = new System.Drawing.Size(143, 23);
            this.textBoxValorPorKm.TabIndex = 5;
            // 
            // labelValorPorKm
            // 
            this.labelValorPorKm.AutoSize = true;
            this.labelValorPorKm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelValorPorKm.Location = new System.Drawing.Point(15, 283);
            this.labelValorPorKm.Name = "labelValorPorKm";
            this.labelValorPorKm.Size = new System.Drawing.Size(78, 15);
            this.labelValorPorKm.TabIndex = 35;
            this.labelValorPorKm.Text = "Valor por Km:";
            this.labelValorPorKm.Click += new System.EventHandler(this.labelValorPorKm_Click);
            // 
            // textBoxValorDia
            // 
            this.textBoxValorDia.Location = new System.Drawing.Point(15, 257);
            this.textBoxValorDia.MaxLength = 255;
            this.textBoxValorDia.Name = "textBoxValorDia";
            this.textBoxValorDia.Size = new System.Drawing.Size(143, 23);
            this.textBoxValorDia.TabIndex = 4;
            // 
            // labelValorDia
            // 
            this.labelValorDia.AutoSize = true;
            this.labelValorDia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelValorDia.Location = new System.Drawing.Point(15, 239);
            this.labelValorDia.Name = "labelValorDia";
            this.labelValorDia.Size = new System.Drawing.Size(55, 15);
            this.labelValorDia.TabIndex = 33;
            this.labelValorDia.Text = "Valor dia:";
            this.labelValorDia.Click += new System.EventHandler(this.labelValorDia_Click);
            // 
            // labelKmIncluso
            // 
            this.labelKmIncluso.AutoSize = true;
            this.labelKmIncluso.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelKmIncluso.Location = new System.Drawing.Point(15, 195);
            this.labelKmIncluso.Name = "labelKmIncluso";
            this.labelKmIncluso.Size = new System.Drawing.Size(69, 15);
            this.labelKmIncluso.TabIndex = 32;
            this.labelKmIncluso.Text = "Km incluso:";
            this.labelKmIncluso.Click += new System.EventHandler(this.labelKmIncluso_Click);
            // 
            // numericUpDownKmIncluso
            // 
            this.numericUpDownKmIncluso.Location = new System.Drawing.Point(15, 213);
            this.numericUpDownKmIncluso.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.numericUpDownKmIncluso.Name = "numericUpDownKmIncluso";
            this.numericUpDownKmIncluso.Size = new System.Drawing.Size(77, 23);
            this.numericUpDownKmIncluso.TabIndex = 3;
            // 
            // comboBoxGrupoVeiculos
            // 
            this.comboBoxGrupoVeiculos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxGrupoVeiculos.FormattingEnabled = true;
            this.comboBoxGrupoVeiculos.Location = new System.Drawing.Point(15, 125);
            this.comboBoxGrupoVeiculos.Name = "comboBoxGrupoVeiculos";
            this.comboBoxGrupoVeiculos.Size = new System.Drawing.Size(143, 23);
            this.comboBoxGrupoVeiculos.TabIndex = 1;
            // 
            // labelGuid
            // 
            this.labelGuid.AutoSize = true;
            this.labelGuid.Location = new System.Drawing.Point(15, 19);
            this.labelGuid.Name = "labelGuid";
            this.labelGuid.Size = new System.Drawing.Size(35, 15);
            this.labelGuid.TabIndex = 29;
            this.labelGuid.Text = "Guid:";
            // 
            // textBoxGuid
            // 
            this.textBoxGuid.Enabled = false;
            this.textBoxGuid.Location = new System.Drawing.Point(15, 37);
            this.textBoxGuid.Name = "textBoxGuid";
            this.textBoxGuid.ReadOnly = true;
            this.textBoxGuid.Size = new System.Drawing.Size(228, 23);
            this.textBoxGuid.TabIndex = 30;
            // 
            // labelNome
            // 
            this.labelNome.AutoSize = true;
            this.labelNome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelNome.Location = new System.Drawing.Point(15, 63);
            this.labelNome.Name = "labelNome";
            this.labelNome.Size = new System.Drawing.Size(43, 15);
            this.labelNome.TabIndex = 1;
            this.labelNome.Text = "Nome:";
            this.labelNome.Click += new System.EventHandler(this.labelNome_Click);
            // 
            // textBoxNome
            // 
            this.textBoxNome.Location = new System.Drawing.Point(15, 81);
            this.textBoxNome.MaxLength = 255;
            this.textBoxNome.Name = "textBoxNome";
            this.textBoxNome.Size = new System.Drawing.Size(185, 23);
            this.textBoxNome.TabIndex = 0;
            // 
            // labelGrupoVeiculos
            // 
            this.labelGrupoVeiculos.AutoSize = true;
            this.labelGrupoVeiculos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelGrupoVeiculos.Location = new System.Drawing.Point(15, 107);
            this.labelGrupoVeiculos.Name = "labelGrupoVeiculos";
            this.labelGrupoVeiculos.Size = new System.Drawing.Size(105, 15);
            this.labelGrupoVeiculos.TabIndex = 3;
            this.labelGrupoVeiculos.Text = "Grupo de Veiculos:";
            this.labelGrupoVeiculos.Click += new System.EventHandler(this.labelGrupoVeiculos_Click);
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancelar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.buttonCancelar.Location = new System.Drawing.Point(203, 347);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(67, 33);
            this.buttonCancelar.TabIndex = 7;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            // 
            // buttonGravar
            // 
            this.buttonGravar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonGravar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonGravar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.buttonGravar.Location = new System.Drawing.Point(130, 347);
            this.buttonGravar.Name = "buttonGravar";
            this.buttonGravar.Size = new System.Drawing.Size(67, 33);
            this.buttonGravar.TabIndex = 6;
            this.buttonGravar.Text = "Gravar";
            this.buttonGravar.UseVisualStyleBackColor = true;
            this.buttonGravar.Click += new System.EventHandler(this.buttonGravar_Click);
            // 
            // TelaCadastroPlanoCobrancaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(279, 385);
            this.Controls.Add(this.groupBoxTaxa);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonGravar);
            this.Name = "TelaCadastroPlanoCobrancaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Plano de Cobrança";
            this.groupBoxTaxa.ResumeLayout(false);
            this.groupBoxTaxa.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownKmIncluso)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxTaxa;
        private System.Windows.Forms.Label labelKmIncluso;
        private System.Windows.Forms.NumericUpDown numericUpDownKmIncluso;
        private System.Windows.Forms.ComboBox comboBoxGrupoVeiculos;
        private System.Windows.Forms.Label labelGuid;
        private System.Windows.Forms.TextBox textBoxGuid;
        private System.Windows.Forms.Label labelNome;
        private System.Windows.Forms.TextBox textBoxNome;
        private System.Windows.Forms.Label labelGrupoVeiculos;
        public System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Button buttonGravar;
        private System.Windows.Forms.ComboBox comboBoxPlano;
        private System.Windows.Forms.Label labelPlano;
        private System.Windows.Forms.TextBox textBoxValorPorKm;
        private System.Windows.Forms.Label labelValorPorKm;
        private System.Windows.Forms.TextBox textBoxValorDia;
        private System.Windows.Forms.Label labelValorDia;
    }
}