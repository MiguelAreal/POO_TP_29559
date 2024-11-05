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
            btnCancelar = new Button();
            btnConfirmar = new Button();
            lblStock = new Label();
            lblPreco = new Label();
            lblMarca = new Label();
            lblCategoria = new Label();
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
            // lblStock
            // 
            lblStock.AutoSize = true;
            lblStock.Font = new Font("Segoe UI", 10F);
            lblStock.Location = new Point(33, 303);
            lblStock.Name = "lblStock";
            lblStock.Size = new Size(68, 19);
            lblStock.TabIndex = 26;
            lblStock.Text = "Categoria";
            // 
            // lblPreco
            // 
            lblPreco.AutoSize = true;
            lblPreco.Font = new Font("Segoe UI", 10F);
            lblPreco.Location = new Point(32, 244);
            lblPreco.Name = "lblPreco";
            lblPreco.Size = new Size(83, 19);
            lblPreco.TabIndex = 25;
            lblPreco.Text = "Data de Fim";
            // 
            // lblMarca
            // 
            lblMarca.AutoSize = true;
            lblMarca.Font = new Font("Segoe UI", 10F);
            lblMarca.Location = new Point(33, 187);
            lblMarca.Name = "lblMarca";
            lblMarca.Size = new Size(93, 19);
            lblMarca.TabIndex = 24;
            lblMarca.Text = "Data de Início";
            // 
            // lblCategoria
            // 
            lblCategoria.AutoSize = true;
            lblCategoria.Font = new Font("Segoe UI", 10F);
            lblCategoria.Location = new Point(33, 130);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Size = new Size(90, 19);
            lblCategoria.TabIndex = 23;
            lblCategoria.Text = "Desconto (%)";
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
            Controls.Add(lblStock);
            Controls.Add(lblPreco);
            Controls.Add(lblMarca);
            Controls.Add(lblCategoria);
            Controls.Add(lblNome);
            Controls.Add(txtNome);
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
        private Label lblStock;
        private Label lblPreco;
        private Label lblMarca;
        private Label lblCategoria;
        private Label lblNome;
        private TextBox txtNome;
        private NumericUpDown nudPercentagemDesc;
        private DateTimePicker dtpIni;
        private DateTimePicker dtpFim;
        private ComboBox cmbCategoria;
    }
}