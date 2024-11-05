namespace poo_tp_29559.Views
{
    partial class AddClienteForm
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
            lblNIF = new Label();
            lblDataNasc = new Label();
            lblMorada = new Label();
            lblContacto = new Label();
            lblNome = new Label();
            txtNome = new TextBox();
            txtContacto = new TextBox();
            txtNIF = new TextBox();
            dtpNasc = new DateTimePicker();
            txtMorada = new TextBox();
            txtContacto1 = new TextBox();
            SuspendLayout();
            // 
            // btnCancelar
            // 
            btnCancelar.Cursor = Cursors.Hand;
            btnCancelar.Font = new Font("Segoe UI", 11F);
            btnCancelar.Location = new Point(106, 411);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(102, 44);
            btnCancelar.TabIndex = 6;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnConfirmar
            // 
            btnConfirmar.Cursor = Cursors.Hand;
            btnConfirmar.Font = new Font("Segoe UI", 11F);
            btnConfirmar.Location = new Point(214, 411);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(102, 44);
            btnConfirmar.TabIndex = 7;
            btnConfirmar.Text = "Confirmar";
            btnConfirmar.UseVisualStyleBackColor = true;
            btnConfirmar.Click += btnConfirmar_Click;
            // 
            // lblNIF
            // 
            lblNIF.AutoSize = true;
            lblNIF.Font = new Font("Segoe UI", 10F);
            lblNIF.Location = new Point(24, 327);
            lblNIF.Name = "lblNIF";
            lblNIF.Size = new Size(30, 19);
            lblNIF.TabIndex = 24;
            lblNIF.Text = "NIF";
            // 
            // lblDataNasc
            // 
            lblDataNasc.AutoSize = true;
            lblDataNasc.Font = new Font("Segoe UI", 10F);
            lblDataNasc.Location = new Point(24, 268);
            lblDataNasc.Name = "lblDataNasc";
            lblDataNasc.Size = new Size(133, 19);
            lblDataNasc.TabIndex = 23;
            lblDataNasc.Text = "Data de Nascimento";
            // 
            // lblMorada
            // 
            lblMorada.AutoSize = true;
            lblMorada.Font = new Font("Segoe UI", 10F);
            lblMorada.Location = new Point(23, 183);
            lblMorada.Name = "lblMorada";
            lblMorada.Size = new Size(65, 19);
            lblMorada.TabIndex = 22;
            lblMorada.Text = "Endereço";
            // 
            // lblContacto
            // 
            lblContacto.AutoSize = true;
            lblContacto.Font = new Font("Segoe UI", 10F);
            lblContacto.Location = new Point(24, 119);
            lblContacto.Name = "lblContacto";
            lblContacto.Size = new Size(65, 19);
            lblContacto.TabIndex = 21;
            lblContacto.Text = "Contacto";
            // 
            // lblNome
            // 
            lblNome.AutoSize = true;
            lblNome.Font = new Font("Segoe UI", 10F);
            lblNome.Location = new Point(23, 65);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(46, 19);
            lblNome.TabIndex = 20;
            lblNome.Text = "Nome";
            // 
            // txtNome
            // 
            txtNome.Font = new Font("Segoe UI", 10F);
            txtNome.Location = new Point(23, 87);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(293, 25);
            txtNome.TabIndex = 0;
            // 
            // txtContacto
            // 
            txtContacto.Font = new Font("Segoe UI", 10F);
            txtContacto.Location = new Point(73, 141);
            txtContacto.MaxLength = 9;
            txtContacto.Name = "txtContacto";
            txtContacto.Size = new Size(243, 25);
            txtContacto.TabIndex = 2;
            // 
            // txtNIF
            // 
            txtNIF.Font = new Font("Segoe UI", 10F);
            txtNIF.Location = new Point(24, 349);
            txtNIF.MaxLength = 9;
            txtNIF.Name = "txtNIF";
            txtNIF.Size = new Size(292, 25);
            txtNIF.TabIndex = 5;
            // 
            // dtpNasc
            // 
            dtpNasc.CalendarTitleBackColor = Color.DodgerBlue;
            dtpNasc.Location = new Point(24, 290);
            dtpNasc.Name = "dtpNasc";
            dtpNasc.RightToLeft = RightToLeft.No;
            dtpNasc.ShowCheckBox = true;
            dtpNasc.Size = new Size(292, 23);
            dtpNasc.TabIndex = 4;
            // 
            // txtMorada
            // 
            txtMorada.Font = new Font("Segoe UI", 10F);
            txtMorada.Location = new Point(23, 205);
            txtMorada.Multiline = true;
            txtMorada.Name = "txtMorada";
            txtMorada.Size = new Size(293, 46);
            txtMorada.TabIndex = 3;
            // 
            // txtContacto1
            // 
            txtContacto1.Font = new Font("Segoe UI", 10F);
            txtContacto1.Location = new Point(23, 141);
            txtContacto1.MaxLength = 4;
            txtContacto1.Name = "txtContacto1";
            txtContacto1.Size = new Size(44, 25);
            txtContacto1.TabIndex = 1;
            txtContacto1.Text = "+351";
            // 
            // AddClienteForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;
            CancelButton = btnCancelar;
            ClientSize = new Size(339, 478);
            Controls.Add(txtContacto1);
            Controls.Add(txtMorada);
            Controls.Add(dtpNasc);
            Controls.Add(txtNIF);
            Controls.Add(txtContacto);
            Controls.Add(btnCancelar);
            Controls.Add(btnConfirmar);
            Controls.Add(lblNIF);
            Controls.Add(lblDataNasc);
            Controls.Add(lblMorada);
            Controls.Add(lblContacto);
            Controls.Add(lblNome);
            Controls.Add(txtNome);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddClienteForm";
            Resizable = false;
            Text = "Adicionar Novo Cliente";
            TopMost = true;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCancelar;
        private Button btnConfirmar;
        private Label lblStock;
        private Label lblDataNasc;
        private Label lblMorada;
        private Label lblContacto;
        private Label lblNome;
        private TextBox txtNome;
        private TextBox txtContacto;
        private TextBox txtNIF;
        private DateTimePicker dtpNasc;
        private TextBox txtMorada;
        private Label lblNIF;
        private TextBox txtContacto1;
    }
}