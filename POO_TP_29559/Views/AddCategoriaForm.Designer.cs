﻿namespace poo_tp_29559.Views
{
    partial class AddCategoriaForm
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
            txtDescricao = new TextBox();
            btnCancelar = new Button();
            btnConfirmar = new Button();
            lblDescricao = new Label();
            lblNome = new Label();
            txtNome = new TextBox();
            SuspendLayout();
            // 
            // txtDescricao
            // 
            txtDescricao.Font = new Font("Segoe UI", 10F);
            txtDescricao.Location = new Point(103, 135);
            txtDescricao.Multiline = true;
            txtDescricao.Name = "txtDescricao";
            txtDescricao.Size = new Size(202, 107);
            txtDescricao.TabIndex = 38;
            // 
            // btnCancelar
            // 
            btnCancelar.Cursor = Cursors.Hand;
            btnCancelar.Font = new Font("Segoe UI", 11F);
            btnCancelar.Location = new Point(106, 409);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(102, 44);
            btnCancelar.TabIndex = 37;
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
            btnConfirmar.TabIndex = 36;
            btnConfirmar.Text = "Confirmar";
            btnConfirmar.UseVisualStyleBackColor = true;
            btnConfirmar.Click += btnConfirmar_Click;
            // 
            // lblDescricao
            // 
            lblDescricao.AutoSize = true;
            lblDescricao.Font = new Font("Segoe UI", 10F);
            lblDescricao.Location = new Point(31, 138);
            lblDescricao.Name = "lblDescricao";
            lblDescricao.Size = new Size(67, 19);
            lblDescricao.TabIndex = 34;
            lblDescricao.Text = "Descrição";
            // 
            // lblNome
            // 
            lblNome.AutoSize = true;
            lblNome.Font = new Font("Segoe UI", 10F);
            lblNome.Location = new Point(52, 94);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(46, 19);
            lblNome.TabIndex = 33;
            lblNome.Text = "Nome";
            // 
            // txtNome
            // 
            txtNome.Font = new Font("Segoe UI", 10F);
            txtNome.Location = new Point(103, 90);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(202, 25);
            txtNome.TabIndex = 31;
            // 
            // AddCategoriaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;
            CancelButton = btnCancelar;
            ClientSize = new Size(339, 476);
            Controls.Add(txtDescricao);
            Controls.Add(btnCancelar);
            Controls.Add(btnConfirmar);
            Controls.Add(lblDescricao);
            Controls.Add(lblNome);
            Controls.Add(txtNome);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddCategoriaForm";
            Resizable = false;
            Text = "Adicionar Nova Categoria";
            TopMost = true;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtDescricao;
        private Button btnCancelar;
        private Button btnConfirmar;
        private Label lblDescricao;
        private Label lblNome;
        private TextBox txtNome;
    }
}