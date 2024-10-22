namespace poo_tp_29559.Views
{
    partial class AddProdutoForm
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
            txtNome = new TextBox();
            cmbCategoria = new ComboBox();
            cmbMarca = new ComboBox();
            nudPreco = new NumericUpDown();
            lblNome = new Label();
            lblCategoria = new Label();
            lblMarca = new Label();
            lblPreco = new Label();
            lblStock = new Label();
            lblGarantiaMeses = new Label();
            nudStock = new NumericUpDown();
            nudGarantiaMeses = new NumericUpDown();
            btnConfirmar = new Button();
            btnCancelar = new Button();
            ((System.ComponentModel.ISupportInitialize)nudPreco).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudStock).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudGarantiaMeses).BeginInit();
            SuspendLayout();
            // 
            // txtNome
            // 
            txtNome.Font = new Font("Segoe UI", 10F);
            txtNome.Location = new Point(145, 90);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(202, 25);
            txtNome.TabIndex = 0;
            // 
            // cmbCategoria
            // 
            cmbCategoria.FlatStyle = FlatStyle.System;
            cmbCategoria.Font = new Font("Segoe UI", 10F);
            cmbCategoria.FormattingEnabled = true;
            cmbCategoria.Location = new Point(145, 135);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new Size(202, 25);
            cmbCategoria.TabIndex = 3;
            // 
            // cmbMarca
            // 
            cmbMarca.FlatStyle = FlatStyle.System;
            cmbMarca.Font = new Font("Segoe UI", 10F);
            cmbMarca.FormattingEnabled = true;
            cmbMarca.Location = new Point(145, 180);
            cmbMarca.Name = "cmbMarca";
            cmbMarca.Size = new Size(202, 25);
            cmbMarca.TabIndex = 4;
            // 
            // nudPreco
            // 
            nudPreco.DecimalPlaces = 2;
            nudPreco.Font = new Font("Segoe UI", 10F);
            nudPreco.Location = new Point(145, 225);
            nudPreco.Name = "nudPreco";
            nudPreco.Size = new Size(202, 25);
            nudPreco.TabIndex = 5;
            nudPreco.ThousandsSeparator = true;
            // 
            // lblNome
            // 
            lblNome.AutoSize = true;
            lblNome.Font = new Font("Segoe UI", 10F);
            lblNome.Location = new Point(94, 94);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(46, 19);
            lblNome.TabIndex = 8;
            lblNome.Text = "Nome";
            // 
            // lblCategoria
            // 
            lblCategoria.AutoSize = true;
            lblCategoria.Font = new Font("Segoe UI", 10F);
            lblCategoria.Location = new Point(72, 138);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Size = new Size(68, 19);
            lblCategoria.TabIndex = 9;
            lblCategoria.Text = "Categoria";
            // 
            // lblMarca
            // 
            lblMarca.AutoSize = true;
            lblMarca.Font = new Font("Segoe UI", 10F);
            lblMarca.Location = new Point(93, 183);
            lblMarca.Name = "lblMarca";
            lblMarca.Size = new Size(47, 19);
            lblMarca.TabIndex = 10;
            lblMarca.Text = "Marca";
            // 
            // lblPreco
            // 
            lblPreco.AutoSize = true;
            lblPreco.Font = new Font("Segoe UI", 10F);
            lblPreco.Location = new Point(97, 227);
            lblPreco.Name = "lblPreco";
            lblPreco.Size = new Size(43, 19);
            lblPreco.TabIndex = 11;
            lblPreco.Text = "Preço";
            // 
            // lblStock
            // 
            lblStock.AutoSize = true;
            lblStock.Font = new Font("Segoe UI", 10F);
            lblStock.Location = new Point(98, 272);
            lblStock.Name = "lblStock";
            lblStock.Size = new Size(42, 19);
            lblStock.TabIndex = 12;
            lblStock.Text = "Stock";
            // 
            // lblGarantiaMeses
            // 
            lblGarantiaMeses.AutoSize = true;
            lblGarantiaMeses.Font = new Font("Segoe UI", 10F);
            lblGarantiaMeses.Location = new Point(17, 317);
            lblGarantiaMeses.Name = "lblGarantiaMeses";
            lblGarantiaMeses.Size = new Size(123, 19);
            lblGarantiaMeses.TabIndex = 13;
            lblGarantiaMeses.Text = "Meses de Garantia";
            // 
            // nudStock
            // 
            nudStock.Font = new Font("Segoe UI", 10F);
            nudStock.Location = new Point(145, 270);
            nudStock.Name = "nudStock";
            nudStock.Size = new Size(202, 25);
            nudStock.TabIndex = 14;
            nudStock.ThousandsSeparator = true;
            // 
            // nudGarantiaMeses
            // 
            nudGarantiaMeses.Font = new Font("Segoe UI", 10F);
            nudGarantiaMeses.Location = new Point(145, 315);
            nudGarantiaMeses.Name = "nudGarantiaMeses";
            nudGarantiaMeses.Size = new Size(202, 25);
            nudGarantiaMeses.TabIndex = 15;
            nudGarantiaMeses.ThousandsSeparator = true;
            nudGarantiaMeses.Value = new decimal(new int[] { 36, 0, 0, 0 });
            // 
            // btnConfirmar
            // 
            btnConfirmar.Cursor = Cursors.Hand;
            btnConfirmar.Font = new Font("Segoe UI", 11F);
            btnConfirmar.Location = new Point(245, 435);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(102, 44);
            btnConfirmar.TabIndex = 16;
            btnConfirmar.Text = "Confirmar";
            btnConfirmar.UseVisualStyleBackColor = true;
            btnConfirmar.Click += btnConfirmar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Cursor = Cursors.Hand;
            btnCancelar.Font = new Font("Segoe UI", 11F);
            btnCancelar.Location = new Point(137, 435);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(102, 44);
            btnCancelar.TabIndex = 17;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // AddProdutoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;
            CancelButton = btnCancelar;
            ClientSize = new Size(373, 512);
            Controls.Add(btnCancelar);
            Controls.Add(btnConfirmar);
            Controls.Add(nudGarantiaMeses);
            Controls.Add(nudStock);
            Controls.Add(lblGarantiaMeses);
            Controls.Add(lblStock);
            Controls.Add(lblPreco);
            Controls.Add(lblMarca);
            Controls.Add(lblCategoria);
            Controls.Add(lblNome);
            Controls.Add(nudPreco);
            Controls.Add(cmbMarca);
            Controls.Add(cmbCategoria);
            Controls.Add(txtNome);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddProdutoForm";
            Resizable = false;
            Text = "Adicionar Novo Produto";
            Theme = MetroFramework.MetroThemeStyle.Light;
            TopMost = true;
            Load += AddProdutoForm_Load;
            ((System.ComponentModel.ISupportInitialize)nudPreco).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudStock).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudGarantiaMeses).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNome;
        private ComboBox cmbCategoria;
        private ComboBox cmbMarca;
        private NumericUpDown nudPreco;
        private Label lblNome;
        private Label lblCategoria;
        private Label lblMarca;
        private Label lblPreco;
        private Label lblStock;
        private Label lblGarantiaMeses;
        private NumericUpDown nudStock;
        private NumericUpDown nudGarantiaMeses;
        private Button btnConfirmar;
        private Button btnCancelar;
    }
}