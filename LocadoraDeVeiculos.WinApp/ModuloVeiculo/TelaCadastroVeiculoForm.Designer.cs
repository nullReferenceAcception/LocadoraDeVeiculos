namespace LocadoraDeVeiculos.WinApp.ModuloVeiculo
{
    partial class TelaCadastroVeiculoForm
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
            this.pictureBoxFoto = new System.Windows.Forms.PictureBox();
            this.groupBoxDadosVeiculo = new System.Windows.Forms.GroupBox();
            this.labelModelo = new System.Windows.Forms.Label();
            this.textBoxModelo = new System.Windows.Forms.TextBox();
            this.labelPlaca = new System.Windows.Forms.Label();
            this.maskedTextBoxPlaca = new System.Windows.Forms.MaskedTextBox();
            this.labelMarca = new System.Windows.Forms.Label();
            this.textBoxMarca = new System.Windows.Forms.TextBox();
            this.labelCor = new System.Windows.Forms.Label();
            this.comboBoxCor = new System.Windows.Forms.ComboBox();
            this.labelCombustivel = new System.Windows.Forms.Label();
            this.comboBoxCombustivel = new System.Windows.Forms.ComboBox();
            this.labelAno = new System.Windows.Forms.Label();
            this.textBoxAno = new System.Windows.Forms.TextBox();
            this.labelTanque = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.labelKmPercorrido = new System.Windows.Forms.Label();
            this.textBoxKmPercorrido = new System.Windows.Forms.TextBox();
            this.labelID = new System.Windows.Forms.Label();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.labelFoto = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFoto)).BeginInit();
            this.groupBoxDadosVeiculo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancelar.Location = new System.Drawing.Point(359, 585);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(67, 33);
            this.buttonCancelar.TabIndex = 7;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            // 
            // buttonGravar
            // 
            this.buttonGravar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonGravar.Location = new System.Drawing.Point(286, 585);
            this.buttonGravar.Name = "buttonGravar";
            this.buttonGravar.Size = new System.Drawing.Size(67, 33);
            this.buttonGravar.TabIndex = 6;
            this.buttonGravar.Text = "Gravar";
            this.buttonGravar.UseVisualStyleBackColor = true;
            this.buttonGravar.Click += new System.EventHandler(this.buttonGravar_Click);
            // 
            // pictureBoxFoto
            // 
            this.pictureBoxFoto.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pictureBoxFoto.Location = new System.Drawing.Point(169, 342);
            this.pictureBoxFoto.Name = "pictureBoxFoto";
            this.pictureBoxFoto.Size = new System.Drawing.Size(245, 203);
            this.pictureBoxFoto.TabIndex = 8;
            this.pictureBoxFoto.TabStop = false;
            // 
            // groupBoxDadosVeiculo
            // 
            this.groupBoxDadosVeiculo.Controls.Add(this.labelFoto);
            this.groupBoxDadosVeiculo.Controls.Add(this.labelID);
            this.groupBoxDadosVeiculo.Controls.Add(this.textBoxID);
            this.groupBoxDadosVeiculo.Controls.Add(this.textBoxKmPercorrido);
            this.groupBoxDadosVeiculo.Controls.Add(this.labelKmPercorrido);
            this.groupBoxDadosVeiculo.Controls.Add(this.numericUpDown1);
            this.groupBoxDadosVeiculo.Controls.Add(this.labelTanque);
            this.groupBoxDadosVeiculo.Controls.Add(this.textBoxAno);
            this.groupBoxDadosVeiculo.Controls.Add(this.labelAno);
            this.groupBoxDadosVeiculo.Controls.Add(this.comboBoxCombustivel);
            this.groupBoxDadosVeiculo.Controls.Add(this.labelCombustivel);
            this.groupBoxDadosVeiculo.Controls.Add(this.comboBoxCor);
            this.groupBoxDadosVeiculo.Controls.Add(this.labelCor);
            this.groupBoxDadosVeiculo.Controls.Add(this.textBoxMarca);
            this.groupBoxDadosVeiculo.Controls.Add(this.labelMarca);
            this.groupBoxDadosVeiculo.Controls.Add(this.maskedTextBoxPlaca);
            this.groupBoxDadosVeiculo.Controls.Add(this.labelPlaca);
            this.groupBoxDadosVeiculo.Controls.Add(this.textBoxModelo);
            this.groupBoxDadosVeiculo.Controls.Add(this.labelModelo);
            this.groupBoxDadosVeiculo.Controls.Add(this.pictureBoxFoto);
            this.groupBoxDadosVeiculo.Location = new System.Drawing.Point(12, 12);
            this.groupBoxDadosVeiculo.Name = "groupBoxDadosVeiculo";
            this.groupBoxDadosVeiculo.Size = new System.Drawing.Size(421, 567);
            this.groupBoxDadosVeiculo.TabIndex = 9;
            this.groupBoxDadosVeiculo.TabStop = false;
            this.groupBoxDadosVeiculo.Text = "Dados do veículo:";
            // 
            // labelModelo
            // 
            this.labelModelo.AutoSize = true;
            this.labelModelo.Location = new System.Drawing.Point(111, 53);
            this.labelModelo.Name = "labelModelo";
            this.labelModelo.Size = new System.Drawing.Size(51, 15);
            this.labelModelo.TabIndex = 9;
            this.labelModelo.Text = "Modelo:";
            // 
            // textBoxModelo
            // 
            this.textBoxModelo.Location = new System.Drawing.Point(168, 51);
            this.textBoxModelo.Name = "textBoxModelo";
            this.textBoxModelo.Size = new System.Drawing.Size(100, 23);
            this.textBoxModelo.TabIndex = 10;
            // 
            // labelPlaca
            // 
            this.labelPlaca.AutoSize = true;
            this.labelPlaca.Location = new System.Drawing.Point(124, 83);
            this.labelPlaca.Name = "labelPlaca";
            this.labelPlaca.Size = new System.Drawing.Size(38, 15);
            this.labelPlaca.TabIndex = 11;
            this.labelPlaca.Text = "Placa:";
            // 
            // maskedTextBoxPlaca
            // 
            this.maskedTextBoxPlaca.Location = new System.Drawing.Point(168, 81);
            this.maskedTextBoxPlaca.Mask = "___-____";
            this.maskedTextBoxPlaca.Name = "maskedTextBoxPlaca";
            this.maskedTextBoxPlaca.Size = new System.Drawing.Size(100, 23);
            this.maskedTextBoxPlaca.TabIndex = 12;
            this.maskedTextBoxPlaca.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // labelMarca
            // 
            this.labelMarca.AutoSize = true;
            this.labelMarca.Location = new System.Drawing.Point(119, 112);
            this.labelMarca.Name = "labelMarca";
            this.labelMarca.Size = new System.Drawing.Size(43, 15);
            this.labelMarca.TabIndex = 13;
            this.labelMarca.Text = "Marca:";
            // 
            // textBoxMarca
            // 
            this.textBoxMarca.Location = new System.Drawing.Point(168, 110);
            this.textBoxMarca.Name = "textBoxMarca";
            this.textBoxMarca.Size = new System.Drawing.Size(100, 23);
            this.textBoxMarca.TabIndex = 14;
            // 
            // labelCor
            // 
            this.labelCor.AutoSize = true;
            this.labelCor.Location = new System.Drawing.Point(133, 159);
            this.labelCor.Name = "labelCor";
            this.labelCor.Size = new System.Drawing.Size(29, 15);
            this.labelCor.TabIndex = 15;
            this.labelCor.Text = "Cor:";
            // 
            // comboBoxCor
            // 
            this.comboBoxCor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCor.FormattingEnabled = true;
            this.comboBoxCor.Location = new System.Drawing.Point(168, 154);
            this.comboBoxCor.Name = "comboBoxCor";
            this.comboBoxCor.Size = new System.Drawing.Size(121, 23);
            this.comboBoxCor.TabIndex = 16;
            // 
            // labelCombustivel
            // 
            this.labelCombustivel.AutoSize = true;
            this.labelCombustivel.Location = new System.Drawing.Point(85, 198);
            this.labelCombustivel.Name = "labelCombustivel";
            this.labelCombustivel.Size = new System.Drawing.Size(77, 15);
            this.labelCombustivel.TabIndex = 17;
            this.labelCombustivel.Text = "Combustível:";
            // 
            // comboBoxCombustivel
            // 
            this.comboBoxCombustivel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCombustivel.FormattingEnabled = true;
            this.comboBoxCombustivel.Location = new System.Drawing.Point(168, 193);
            this.comboBoxCombustivel.Name = "comboBoxCombustivel";
            this.comboBoxCombustivel.Size = new System.Drawing.Size(121, 23);
            this.comboBoxCombustivel.TabIndex = 18;
            // 
            // labelAno
            // 
            this.labelAno.AutoSize = true;
            this.labelAno.Location = new System.Drawing.Point(130, 238);
            this.labelAno.Name = "labelAno";
            this.labelAno.Size = new System.Drawing.Size(32, 15);
            this.labelAno.TabIndex = 19;
            this.labelAno.Text = "Ano:";
            // 
            // textBoxAno
            // 
            this.textBoxAno.Location = new System.Drawing.Point(168, 233);
            this.textBoxAno.Name = "textBoxAno";
            this.textBoxAno.Size = new System.Drawing.Size(100, 23);
            this.textBoxAno.TabIndex = 20;
            // 
            // labelTanque
            // 
            this.labelTanque.AutoSize = true;
            this.labelTanque.Location = new System.Drawing.Point(33, 268);
            this.labelTanque.Name = "labelTanque";
            this.labelTanque.Size = new System.Drawing.Size(129, 15);
            this.labelTanque.TabIndex = 21;
            this.labelTanque.Text = "Capacidade do tanque:";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.DecimalPlaces = 2;
            this.numericUpDown1.Location = new System.Drawing.Point(169, 267);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 23);
            this.numericUpDown1.TabIndex = 22;
            // 
            // labelKmPercorrido
            // 
            this.labelKmPercorrido.AutoSize = true;
            this.labelKmPercorrido.Location = new System.Drawing.Point(11, 303);
            this.labelKmPercorrido.Name = "labelKmPercorrido";
            this.labelKmPercorrido.Size = new System.Drawing.Size(151, 15);
            this.labelKmPercorrido.TabIndex = 23;
            this.labelKmPercorrido.Text = "Quilômetragem percorrida:";
            // 
            // textBoxKmPercorrido
            // 
            this.textBoxKmPercorrido.Location = new System.Drawing.Point(169, 296);
            this.textBoxKmPercorrido.Name = "textBoxKmPercorrido";
            this.textBoxKmPercorrido.Size = new System.Drawing.Size(100, 23);
            this.textBoxKmPercorrido.TabIndex = 24;
            // 
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.labelID.Location = new System.Drawing.Point(141, 25);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(21, 15);
            this.labelID.TabIndex = 31;
            this.labelID.Text = "ID:";
            // 
            // textBoxID
            // 
            this.textBoxID.Enabled = false;
            this.textBoxID.Location = new System.Drawing.Point(168, 22);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.ReadOnly = true;
            this.textBoxID.Size = new System.Drawing.Size(75, 23);
            this.textBoxID.TabIndex = 32;
            // 
            // labelFoto
            // 
            this.labelFoto.AutoSize = true;
            this.labelFoto.Location = new System.Drawing.Point(124, 342);
            this.labelFoto.Name = "labelFoto";
            this.labelFoto.Size = new System.Drawing.Size(34, 15);
            this.labelFoto.TabIndex = 33;
            this.labelFoto.Text = "Foto:";
            // 
            // TelaCadastroVeiculoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 623);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonGravar);
            this.Controls.Add(this.groupBoxDadosVeiculo);
            this.Name = "TelaCadastroVeiculoForm";
            this.Text = "Veículos";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFoto)).EndInit();
            this.groupBoxDadosVeiculo.ResumeLayout(false);
            this.groupBoxDadosVeiculo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Button buttonGravar;
        private System.Windows.Forms.PictureBox pictureBoxFoto;
        private System.Windows.Forms.GroupBox groupBoxDadosVeiculo;
        private System.Windows.Forms.TextBox textBoxKmPercorrido;
        private System.Windows.Forms.Label labelKmPercorrido;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label labelTanque;
        private System.Windows.Forms.TextBox textBoxAno;
        private System.Windows.Forms.Label labelAno;
        private System.Windows.Forms.ComboBox comboBoxCombustivel;
        private System.Windows.Forms.Label labelCombustivel;
        private System.Windows.Forms.ComboBox comboBoxCor;
        private System.Windows.Forms.Label labelCor;
        private System.Windows.Forms.TextBox textBoxMarca;
        private System.Windows.Forms.Label labelMarca;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxPlaca;
        private System.Windows.Forms.Label labelPlaca;
        private System.Windows.Forms.TextBox textBoxModelo;
        private System.Windows.Forms.Label labelModelo;
        private System.Windows.Forms.Label labelFoto;
        private System.Windows.Forms.Label labelID;
        private System.Windows.Forms.TextBox textBoxID;
    }
}