﻿namespace poo_tp_29559.Views
{
    partial class AddUpdProdutoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddUpdProdutoForm));
            cmbMarca = new ComboBox();
            nudPreco = new NumericUpDown();
            lblPreco = new Label();
            lblStock = new Label();
            nudStock = new NumericUpDown();
            btnConfirmar = new Button();
            btnCancelar = new Button();
            lblNome = new Label();
            cmbCategoria = new ComboBox();
            lblCategoria = new Label();
            txtNome = new TextBox();
            lblMarca = new Label();
            ((System.ComponentModel.ISupportInitialize)nudPreco).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudStock).BeginInit();
            SuspendLayout();
            // 
            // cmbMarca
            // 
            cmbMarca.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMarca.FlatStyle = FlatStyle.System;
            cmbMarca.Font = new Font("Segoe UI", 10F);
            cmbMarca.FormattingEnabled = true;
            cmbMarca.Location = new Point(23, 213);
            cmbMarca.Name = "cmbMarca";
            cmbMarca.Size = new Size(293, 25);
            cmbMarca.TabIndex = 4;
            // 
            // nudPreco
            // 
            nudPreco.DecimalPlaces = 2;
            nudPreco.Font = new Font("Segoe UI", 10F);
            nudPreco.Location = new Point(23, 274);
            nudPreco.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            nudPreco.Name = "nudPreco";
            nudPreco.Size = new Size(293, 25);
            nudPreco.TabIndex = 5;
            nudPreco.ThousandsSeparator = true;
            // 
            // lblPreco
            // 
            lblPreco.AutoSize = true;
            lblPreco.Font = new Font("Montserrat", 10F);
            lblPreco.Location = new Point(23, 252);
            lblPreco.Name = "lblPreco";
            lblPreco.Size = new Size(50, 20);
            lblPreco.TabIndex = 11;
            lblPreco.Text = "Preço";
            // 
            // lblStock
            // 
            lblStock.AutoSize = true;
            lblStock.Font = new Font("Montserrat", 10F);
            lblStock.Location = new Point(23, 316);
            lblStock.Name = "lblStock";
            lblStock.Size = new Size(49, 20);
            lblStock.TabIndex = 12;
            lblStock.Text = "Stock";
            // 
            // nudStock
            // 
            nudStock.Font = new Font("Segoe UI", 10F);
            nudStock.Location = new Point(23, 338);
            nudStock.Name = "nudStock";
            nudStock.Size = new Size(293, 25);
            nudStock.TabIndex = 14;
            nudStock.ThousandsSeparator = true;
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
            // lblNome
            // 
            lblNome.AutoSize = true;
            lblNome.Font = new Font("Montserrat", 10F);
            lblNome.Location = new Point(23, 71);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(52, 20);
            lblNome.TabIndex = 8;
            lblNome.Text = "Nome";
            // 
            // cmbCategoria
            // 
            cmbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategoria.FlatStyle = FlatStyle.System;
            cmbCategoria.Font = new Font("Segoe UI", 10F);
            cmbCategoria.FormattingEnabled = true;
            cmbCategoria.Location = new Point(23, 155);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new Size(293, 25);
            cmbCategoria.TabIndex = 1;
            // 
            // lblCategoria
            // 
            lblCategoria.AutoSize = true;
            lblCategoria.Font = new Font("Montserrat", 10F);
            lblCategoria.Location = new Point(23, 133);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Size = new Size(78, 20);
            lblCategoria.TabIndex = 9;
            lblCategoria.Text = "Categoria";
            // 
            // txtNome
            // 
            txtNome.Font = new Font("Segoe UI", 10F);
            txtNome.Location = new Point(23, 93);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(293, 25);
            txtNome.TabIndex = 0;
            // 
            // lblMarca
            // 
            lblMarca.AutoSize = true;
            lblMarca.Font = new Font("Montserrat", 10F);
            lblMarca.Location = new Point(23, 191);
            lblMarca.Name = "lblMarca";
            lblMarca.Size = new Size(52, 20);
            lblMarca.TabIndex = 10;
            lblMarca.Text = "Marca";
            // 
            // AddProdutoForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;
            CancelButton = btnCancelar;
            ClientSize = new Size(339, 476);
            Controls.Add(btnCancelar);
            Controls.Add(btnConfirmar);
            Controls.Add(nudStock);
            Controls.Add(lblStock);
            Controls.Add(lblPreco);
            Controls.Add(lblMarca);
            Controls.Add(lblCategoria);
            Controls.Add(lblNome);
            Controls.Add(nudPreco);
            Controls.Add(cmbMarca);
            Controls.Add(cmbCategoria);
            Controls.Add(txtNome);
            Icon = (Icon)resources.GetObject("$this.Icon");
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
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ComboBox cmbMarca;
        private NumericUpDown nudPreco;
        private Label lblPreco;
        private Label lblStock;
        private NumericUpDown nudStock;
        private Button btnConfirmar;
        private Button btnCancelar;
        private Label lblNome;
        private ComboBox cmbCategoria;
        private Label lblCategoria;
        private TextBox txtNome;
        private Label lblMarca;
    }
}