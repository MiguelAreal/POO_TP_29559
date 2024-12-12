namespace poo_tp_29559.Views
{
    partial class AddMarcaForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddMarcaForm));
            btnCancelar = new Button();
            btnConfirmar = new Button();
            lblPais = new Label();
            lblDescricao = new Label();
            lblNome = new Label();
            cmbPais = new ComboBox();
            txtNome = new TextBox();
            txtDescricao = new TextBox();
            SuspendLayout();
            // 
            // btnCancelar
            // 
            btnCancelar.Cursor = Cursors.Hand;
            btnCancelar.Font = new Font("Segoe UI", 11F);
            btnCancelar.Location = new Point(106, 409);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(102, 44);
            btnCancelar.TabIndex = 3;
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
            btnConfirmar.TabIndex = 4;
            btnConfirmar.Text = "Confirmar";
            btnConfirmar.UseVisualStyleBackColor = true;
            btnConfirmar.Click += btnConfirmar_Click;
            // 
            // lblPais
            // 
            lblPais.AutoSize = true;
            lblPais.Font = new Font("Montserrat", 10F);
            lblPais.Location = new Point(20, 282);
            lblPais.Name = "lblPais";
            lblPais.Size = new Size(38, 20);
            lblPais.TabIndex = 24;
            lblPais.Text = "País";
            // 
            // lblDescricao
            // 
            lblDescricao.AutoSize = true;
            lblDescricao.Font = new Font("Montserrat", 10F);
            lblDescricao.Location = new Point(20, 135);
            lblDescricao.Name = "lblDescricao";
            lblDescricao.Size = new Size(79, 20);
            lblDescricao.TabIndex = 23;
            lblDescricao.Text = "Descrição";
            // 
            // lblNome
            // 
            lblNome.AutoSize = true;
            lblNome.Font = new Font("Montserrat", 10F);
            lblNome.Location = new Point(20, 69);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(52, 20);
            lblNome.TabIndex = 22;
            lblNome.Text = "Nome";
            // 
            // cmbPais
            // 
            cmbPais.FlatStyle = FlatStyle.System;
            cmbPais.Font = new Font("Segoe UI", 10F);
            cmbPais.FormattingEnabled = true;
            cmbPais.Location = new Point(23, 304);
            cmbPais.Name = "cmbPais";
            cmbPais.Size = new Size(293, 25);
            cmbPais.TabIndex = 2;
            // 
            // txtNome
            // 
            txtNome.Font = new Font("Segoe UI", 10F);
            txtNome.Location = new Point(23, 91);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(293, 25);
            txtNome.TabIndex = 0;
            // 
            // txtDescricao
            // 
            txtDescricao.Font = new Font("Segoe UI", 10F);
            txtDescricao.Location = new Point(23, 157);
            txtDescricao.Multiline = true;
            txtDescricao.Name = "txtDescricao";
            txtDescricao.Size = new Size(293, 107);
            txtDescricao.TabIndex = 1;
            // 
            // AddMarcaForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;
            CancelButton = btnCancelar;
            ClientSize = new Size(339, 476);
            Controls.Add(txtDescricao);
            Controls.Add(btnCancelar);
            Controls.Add(btnConfirmar);
            Controls.Add(lblPais);
            Controls.Add(lblDescricao);
            Controls.Add(lblNome);
            Controls.Add(cmbPais);
            Controls.Add(txtNome);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddMarcaForm";
            Resizable = false;
            Text = "Adicionar Nova Marca";
            TopMost = true;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCancelar;
        private Button btnConfirmar;
        private Label lblPais;
        private Label lblDescricao;
        private Label lblNome;
        private ComboBox cmbPais;
        private TextBox txtNome;
        private TextBox txtDescricao;
    }
}