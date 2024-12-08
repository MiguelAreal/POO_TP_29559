namespace poo_tp_29559.Views
{
    partial class AddCampanhaForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddCampanhaForm));
            btnCancelar = new Button();
            btnConfirmar = new Button();
            lblCategoria = new Label();
            lblDataFim = new Label();
            lblDataIni = new Label();
            lblDesconto = new Label();
            lblNome = new Label();
            txtNome = new TextBox();
            nudPercentagemDesc = new NumericUpDown();
            dtpIni = new DateTimePicker();
            dtpFim = new DateTimePicker();
            cmbCategoria = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)nudPercentagemDesc).BeginInit();
            SuspendLayout();
            // 
            // btnCancelar
            // 
            btnCancelar.Cursor = Cursors.Hand;
            btnCancelar.Font = new Font("Segoe UI", 11F);
            btnCancelar.Location = new Point(106, 409);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(102, 44);
            btnCancelar.TabIndex = 5;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnConfirmar
            // 
            btnConfirmar.Cursor = Cursors.Hand;
            btnConfirmar.Font = new Font("Segoe UI", 11F);
            btnConfirmar.Location = new Point(214, 409);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(102, 44);
            btnConfirmar.TabIndex = 6;
            btnConfirmar.Text = "Confirmar";
            btnConfirmar.UseVisualStyleBackColor = true;
            btnConfirmar.Click += btnConfirmar_Click;
            // 
            // lblCategoria
            // 
            lblCategoria.AutoSize = true;
            lblCategoria.Font = new Font("Segoe UI", 10F);
            lblCategoria.Location = new Point(33, 303);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Size = new Size(123, 19);
            lblCategoria.TabIndex = 26;
            lblCategoria.Text = "Categoria Aplicada";
            // 
            // lblDataFim
            // 
            lblDataFim.AutoSize = true;
            lblDataFim.Font = new Font("Segoe UI", 10F);
            lblDataFim.Location = new Point(32, 244);
            lblDataFim.Name = "lblDataFim";
            lblDataFim.Size = new Size(83, 19);
            lblDataFim.TabIndex = 25;
            lblDataFim.Text = "Data de Fim";
            // 
            // lblDataIni
            // 
            lblDataIni.AutoSize = true;
            lblDataIni.Font = new Font("Segoe UI", 10F);
            lblDataIni.Location = new Point(33, 187);
            lblDataIni.Name = "lblDataIni";
            lblDataIni.Size = new Size(93, 19);
            lblDataIni.TabIndex = 24;
            lblDataIni.Text = "Data de Início";
            // 
            // lblDesconto
            // 
            lblDesconto.AutoSize = true;
            lblDesconto.Font = new Font("Segoe UI", 10F);
            lblDesconto.Location = new Point(33, 130);
            lblDesconto.Name = "lblDesconto";
            lblDesconto.Size = new Size(90, 19);
            lblDesconto.TabIndex = 23;
            lblDesconto.Text = "Desconto (%)";
            // 
            // lblNome
            // 
            lblNome.AutoSize = true;
            lblNome.Font = new Font("Segoe UI", 10F);
            lblNome.Location = new Point(32, 74);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(46, 19);
            lblNome.TabIndex = 22;
            lblNome.Text = "Nome";
            // 
            // txtNome
            // 
            txtNome.Font = new Font("Segoe UI", 10F);
            txtNome.Location = new Point(33, 96);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(276, 25);
            txtNome.TabIndex = 0;
            // 
            // nudPercentagemDesc
            // 
            nudPercentagemDesc.DecimalPlaces = 1;
            nudPercentagemDesc.Font = new Font("Segoe UI", 10F);
            nudPercentagemDesc.Location = new Point(33, 152);
            nudPercentagemDesc.Name = "nudPercentagemDesc";
            nudPercentagemDesc.Size = new Size(276, 25);
            nudPercentagemDesc.TabIndex = 1;
            nudPercentagemDesc.ThousandsSeparator = true;
            // 
            // dtpIni
            // 
            dtpIni.Location = new Point(33, 209);
            dtpIni.Name = "dtpIni";
            dtpIni.Size = new Size(276, 23);
            dtpIni.TabIndex = 2;
            // 
            // dtpFim
            // 
            dtpFim.Location = new Point(32, 266);
            dtpFim.Name = "dtpFim";
            dtpFim.Size = new Size(277, 23);
            dtpFim.TabIndex = 3;
            // 
            // cmbCategoria
            // 
            cmbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategoria.FormattingEnabled = true;
            cmbCategoria.Location = new Point(33, 325);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new Size(276, 23);
            cmbCategoria.TabIndex = 4;
            // 
            // AddCampanhaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;
            CancelButton = btnCancelar;
            ClientSize = new Size(339, 476);
            Controls.Add(cmbCategoria);
            Controls.Add(dtpFim);
            Controls.Add(dtpIni);
            Controls.Add(nudPercentagemDesc);
            Controls.Add(btnCancelar);
            Controls.Add(btnConfirmar);
            Controls.Add(lblCategoria);
            Controls.Add(lblDataFim);
            Controls.Add(lblDataIni);
            Controls.Add(lblDesconto);
            Controls.Add(lblNome);
            Controls.Add(txtNome);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddCampanhaForm";
            Resizable = false;
            ShadowType = MetroFormShadowType.None;
            Text = "Adicionar Nova Campanha";
            ((System.ComponentModel.ISupportInitialize)nudPercentagemDesc).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCancelar;
        private Button btnConfirmar;
        private Label lblCategoria;
        private Label lblDataFim;
        private Label lblDataIni;
        private Label lblDesconto;
        private Label lblNome;
        private TextBox txtNome;
        private NumericUpDown nudPercentagemDesc;
        private DateTimePicker dtpIni;
        private DateTimePicker dtpFim;
        private ComboBox cmbCategoria;
    }
}