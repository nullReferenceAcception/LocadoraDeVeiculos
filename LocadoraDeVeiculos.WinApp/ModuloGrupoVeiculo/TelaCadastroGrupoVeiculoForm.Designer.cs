namespace LocadoraDeVeiculos.WinApp.ModuloGrupoVeiculo
{
    partial class TelaCadastroGrupoVeiculoForm
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
            this.textBoxNome = new System.Windows.Forms.TextBox();
            this.groupBoxGrupoVeiculo = new System.Windows.Forms.GroupBox();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.labelDescricao = new System.Windows.Forms.Label();
            this.buttonGravar = new System.Windows.Forms.Button();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.groupBoxGrupoVeiculo.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxNome
            // 
            this.textBoxNome.Location = new System.Drawing.Point(12, 12);
            this.textBoxNome.Name = "textBoxNome";
            this.textBoxNome.PlaceholderText = "Nome";
            this.textBoxNome.Size = new System.Drawing.Size(100, 23);
            this.textBoxNome.TabIndex = 0;
            // 
            // groupBoxGrupoVeiculo
            // 
            this.groupBoxGrupoVeiculo.Controls.Add(this.buttonCancelar);
            this.groupBoxGrupoVeiculo.Controls.Add(this.labelDescricao);
            this.groupBoxGrupoVeiculo.Controls.Add(this.buttonGravar);
            this.groupBoxGrupoVeiculo.Controls.Add(this.textBoxName);
            this.groupBoxGrupoVeiculo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxGrupoVeiculo.Location = new System.Drawing.Point(0, 0);
            this.groupBoxGrupoVeiculo.Name = "groupBoxGrupoVeiculo";
            this.groupBoxGrupoVeiculo.Size = new System.Drawing.Size(284, 173);
            this.groupBoxGrupoVeiculo.TabIndex = 7;
            this.groupBoxGrupoVeiculo.TabStop = false;
            this.groupBoxGrupoVeiculo.Text = "Dados de Grupo de veiculo:";
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancelar.Location = new System.Drawing.Point(160, 91);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(67, 33);
            this.buttonCancelar.TabIndex = 5;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            // 
            // labelDescricao
            // 
            this.labelDescricao.AutoSize = true;
            this.labelDescricao.Location = new System.Drawing.Point(38, 65);
            this.labelDescricao.Name = "labelDescricao";
            this.labelDescricao.Size = new System.Drawing.Size(43, 15);
            this.labelDescricao.TabIndex = 1;
            this.labelDescricao.Text = "Nome:";
            // 
            // buttonGravar
            // 
            this.buttonGravar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonGravar.Location = new System.Drawing.Point(87, 91);
            this.buttonGravar.Name = "buttonGravar";
            this.buttonGravar.Size = new System.Drawing.Size(67, 33);
            this.buttonGravar.TabIndex = 4;
            this.buttonGravar.Text = "Gravar";
            this.buttonGravar.UseVisualStyleBackColor = true;
            this.buttonGravar.Click += new System.EventHandler(this.buttonGravar_Click);
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(87, 62);
            this.textBoxName.MaxLength = 255;
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(143, 23);
            this.textBoxName.TabIndex = 0;
            // 
            // TelaCadastroGrupoVeiculoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 173);
            this.Controls.Add(this.groupBoxGrupoVeiculo);
            this.Controls.Add(this.textBoxNome);
            this.Name = "TelaCadastroGrupoVeiculoForm";
            this.Text = "TelaCadastroGrupoVeiculoForm";
            this.groupBoxGrupoVeiculo.ResumeLayout(false);
            this.groupBoxGrupoVeiculo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxNome;
        private System.Windows.Forms.GroupBox groupBoxGrupoVeiculo;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Label labelDescricao;
        private System.Windows.Forms.Button buttonGravar;
        private System.Windows.Forms.TextBox textBoxName;
    }
}