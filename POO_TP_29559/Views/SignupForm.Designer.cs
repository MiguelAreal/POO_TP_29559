namespace poo_tp_29559.Views
{
    partial class SignupForm
    {
        private System.ComponentModel.IContainer components = null;

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
            leftPanel = new Panel();
            labelRodape = new Label();
            lblSubtitulo = new Label();
            labelTitulo = new Label();
            imgLeftClick = new PictureBox();
            lblTitle = new Label();
            btnSair = new Label();
            panelUser = new Panel();
            txtNome = new TextBox();
            imgUser = new Label();
            panelPassword = new Panel();
            btnHidePwd = new Label();
            txtPassword = new TextBox();
            imgPwd = new Label();
            btnSubmit = new Button();
            lblLoginAqui = new Label();
            panelDN = new Panel();
            dtpNasc = new DateTimePicker();
            imgDataNasc = new Label();
            panelNif = new Panel();
            txtNIF = new TextBox();
            imgNIF = new Label();
            panelContacto = new Panel();
            txtContacto = new TextBox();
            txtContactoCodPais = new TextBox();
            imgContacto = new Label();
            panelTipoUser = new Panel();
            rdbCliente = new RadioButton();
            rdbAdmin = new RadioButton();
            imgTipoUser = new Label();
            panelMorada = new Panel();
            txtMorada = new TextBox();
            lblMorada = new Label();
            leftPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)imgLeftClick).BeginInit();
            panelUser.SuspendLayout();
            panelPassword.SuspendLayout();
            panelDN.SuspendLayout();
            panelNif.SuspendLayout();
            panelContacto.SuspendLayout();
            panelTipoUser.SuspendLayout();
            panelMorada.SuspendLayout();
            SuspendLayout();
            // 
            // leftPanel
            // 
            leftPanel.BackColor = Color.FromArgb(9, 171, 219);
            leftPanel.Controls.Add(labelRodape);
            leftPanel.Controls.Add(lblSubtitulo);
            leftPanel.Controls.Add(labelTitulo);
            leftPanel.Controls.Add(imgLeftClick);
            leftPanel.Dock = DockStyle.Left;
            leftPanel.Location = new Point(0, 0);
            leftPanel.Margin = new Padding(0);
            leftPanel.Name = "leftPanel";
            leftPanel.Size = new Size(249, 675);
            leftPanel.TabIndex = 0;
            // 
            // labelRodape
            // 
            labelRodape.AutoSize = true;
            labelRodape.Dock = DockStyle.Bottom;
            labelRodape.Font = new Font("Montserrat", 9F);
            labelRodape.ForeColor = Color.White;
            labelRodape.Location = new Point(0, 643);
            labelRodape.Name = "labelRodape";
            labelRodape.Size = new Size(142, 32);
            labelRodape.TabIndex = 3;
            labelRodape.Text = "Desenvolvido por\r\nMiguel Areal - Nº29559";
            labelRodape.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.Font = new Font("Montserrat", 14F);
            lblSubtitulo.ForeColor = Color.White;
            lblSubtitulo.Location = new Point(44, 343);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(202, 52);
            lblSubtitulo.TabIndex = 2;
            lblSubtitulo.Text = "Gestor de Comércio\r\nEletrónico";
            lblSubtitulo.TextAlign = ContentAlignment.MiddleRight;
            // 
            // labelTitulo
            // 
            labelTitulo.AutoSize = true;
            labelTitulo.Font = new Font("Montserrat", 14F);
            labelTitulo.ForeColor = Color.White;
            labelTitulo.Location = new Point(28, 312);
            labelTitulo.Name = "labelTitulo";
            labelTitulo.Size = new Size(218, 26);
            labelTitulo.TabIndex = 1;
            labelTitulo.Text = "Bem vindo à LeftClick";
            labelTitulo.TextAlign = ContentAlignment.MiddleRight;
            // 
            // imgLeftClick
            // 
            imgLeftClick.Image = Properties.Resources.leftclick_logo;
            imgLeftClick.Location = new Point(65, 27);
            imgLeftClick.Name = "imgLeftClick";
            imgLeftClick.Size = new Size(115, 122);
            imgLeftClick.SizeMode = PictureBoxSizeMode.StretchImage;
            imgLeftClick.TabIndex = 0;
            imgLeftClick.TabStop = false;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Montserrat", 14F);
            lblTitle.ForeColor = Color.FromArgb(9, 171, 219);
            lblTitle.Location = new Point(264, 42);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(197, 26);
            lblTitle.TabIndex = 4;
            lblTitle.Text = "Registe a sua conta";
            lblTitle.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnSair
            // 
            btnSair.AutoSize = true;
            btnSair.Cursor = Cursors.Hand;
            btnSair.Font = new Font("Montserrat", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSair.ForeColor = Color.FromArgb(9, 171, 219);
            btnSair.Location = new Point(533, 9);
            btnSair.Name = "btnSair";
            btnSair.Size = new Size(26, 26);
            btnSair.TabIndex = 5;
            btnSair.Text = "X";
            btnSair.TextAlign = ContentAlignment.MiddleRight;
            btnSair.Click += btnSair_Click;
            // 
            // panelUser
            // 
            panelUser.BackColor = Color.White;
            panelUser.Controls.Add(txtNome);
            panelUser.Controls.Add(imgUser);
            panelUser.Location = new Point(250, 86);
            panelUser.Name = "panelUser";
            panelUser.Size = new Size(329, 45);
            panelUser.TabIndex = 6;
            // 
            // txtNome
            // 
            txtNome.BorderStyle = BorderStyle.None;
            txtNome.Font = new Font("Montserrat", 12F);
            txtNome.ForeColor = Color.FromArgb(9, 171, 219);
            txtNome.Location = new Point(55, 12);
            txtNome.Name = "txtNome";
            txtNome.PlaceholderText = "Nome";
            txtNome.Size = new Size(227, 20);
            txtNome.TabIndex = 1;
            // 
            // imgUser
            // 
            imgUser.AutoSize = true;
            imgUser.Font = new Font("Segoe UI", 20F);
            imgUser.ForeColor = Color.FromArgb(9, 171, 219);
            imgUser.Location = new Point(4, 4);
            imgUser.Name = "imgUser";
            imgUser.Size = new Size(54, 37);
            imgUser.TabIndex = 0;
            imgUser.Text = "👤";
            imgUser.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelPassword
            // 
            panelPassword.BackColor = Color.White;
            panelPassword.Controls.Add(btnHidePwd);
            panelPassword.Controls.Add(txtPassword);
            panelPassword.Controls.Add(imgPwd);
            panelPassword.Location = new Point(250, 156);
            panelPassword.Name = "panelPassword";
            panelPassword.Size = new Size(323, 45);
            panelPassword.TabIndex = 7;
            // 
            // btnHidePwd
            // 
            btnHidePwd.AutoSize = true;
            btnHidePwd.Cursor = Cursors.Hand;
            btnHidePwd.Font = new Font("Segoe UI", 15F);
            btnHidePwd.ForeColor = Color.FromArgb(9, 171, 219);
            btnHidePwd.Location = new Point(278, 9);
            btnHidePwd.Name = "btnHidePwd";
            btnHidePwd.Size = new Size(39, 28);
            btnHidePwd.TabIndex = 3;
            btnHidePwd.Text = "👁️";
            btnHidePwd.Click += btnHidePwd_Click;
            // 
            // txtPassword
            // 
            txtPassword.BorderStyle = BorderStyle.None;
            txtPassword.Font = new Font("Montserrat", 12F);
            txtPassword.ForeColor = Color.FromArgb(9, 171, 219);
            txtPassword.Location = new Point(54, 13);
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderText = "Palavra-passe";
            txtPassword.Size = new Size(227, 20);
            txtPassword.TabIndex = 2;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // imgPwd
            // 
            imgPwd.AutoSize = true;
            imgPwd.Font = new Font("Segoe UI", 20F);
            imgPwd.ForeColor = Color.FromArgb(9, 171, 219);
            imgPwd.Location = new Point(4, 4);
            imgPwd.Name = "imgPwd";
            imgPwd.Size = new Size(54, 37);
            imgPwd.TabIndex = 1;
            imgPwd.Text = "🔑";
            imgPwd.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnSubmit
            // 
            btnSubmit.BackColor = Color.FromArgb(9, 171, 219);
            btnSubmit.Cursor = Cursors.Hand;
            btnSubmit.FlatAppearance.BorderSize = 0;
            btnSubmit.FlatStyle = FlatStyle.Flat;
            btnSubmit.Font = new Font("Montserrat", 12F);
            btnSubmit.ForeColor = Color.White;
            btnSubmit.Location = new Point(338, 591);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(148, 42);
            btnSubmit.TabIndex = 5;
            btnSubmit.Text = "REGISTAR";
            btnSubmit.UseVisualStyleBackColor = false;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // lblLoginAqui
            // 
            lblLoginAqui.AutoSize = true;
            lblLoginAqui.Cursor = Cursors.Hand;
            lblLoginAqui.Font = new Font("Montserrat", 9.749999F, FontStyle.Underline, GraphicsUnit.Point, 0);
            lblLoginAqui.ForeColor = Color.FromArgb(9, 171, 219);
            lblLoginAqui.Location = new Point(327, 638);
            lblLoginAqui.Name = "lblLoginAqui";
            lblLoginAqui.Size = new Size(170, 18);
            lblLoginAqui.TabIndex = 6;
            lblLoginAqui.Text = "Já tem conta? Entre aqui";
            lblLoginAqui.TextAlign = ContentAlignment.MiddleLeft;
            lblLoginAqui.Click += lblLoginAqui_Click;
            // 
            // panelDN
            // 
            panelDN.BackColor = Color.White;
            panelDN.Controls.Add(dtpNasc);
            panelDN.Controls.Add(imgDataNasc);
            panelDN.Location = new Point(250, 226);
            panelDN.Name = "panelDN";
            panelDN.Size = new Size(323, 45);
            panelDN.TabIndex = 8;
            // 
            // dtpNasc
            // 
            dtpNasc.CalendarFont = new Font("Montserrat", 12F);
            dtpNasc.CalendarTitleBackColor = Color.DodgerBlue;
            dtpNasc.Font = new Font("Montserrat", 10F);
            dtpNasc.Location = new Point(55, 12);
            dtpNasc.Name = "dtpNasc";
            dtpNasc.RightToLeft = RightToLeft.No;
            dtpNasc.ShowCheckBox = true;
            dtpNasc.Size = new Size(228, 24);
            dtpNasc.TabIndex = 5;
            // 
            // imgDataNasc
            // 
            imgDataNasc.AutoSize = true;
            imgDataNasc.Font = new Font("Segoe UI", 20F);
            imgDataNasc.ForeColor = Color.FromArgb(9, 171, 219);
            imgDataNasc.Location = new Point(4, 4);
            imgDataNasc.Name = "imgDataNasc";
            imgDataNasc.Size = new Size(54, 37);
            imgDataNasc.TabIndex = 1;
            imgDataNasc.Text = "📅";
            imgDataNasc.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelNif
            // 
            panelNif.BackColor = Color.White;
            panelNif.Controls.Add(txtNIF);
            panelNif.Controls.Add(imgNIF);
            panelNif.Location = new Point(250, 296);
            panelNif.Name = "panelNif";
            panelNif.Size = new Size(323, 45);
            panelNif.TabIndex = 9;
            // 
            // txtNIF
            // 
            txtNIF.BorderStyle = BorderStyle.None;
            txtNIF.Font = new Font("Montserrat", 12F);
            txtNIF.ForeColor = Color.FromArgb(9, 171, 219);
            txtNIF.Location = new Point(54, 13);
            txtNIF.MaxLength = 9;
            txtNIF.Name = "txtNIF";
            txtNIF.PlaceholderText = "NIF";
            txtNIF.Size = new Size(228, 20);
            txtNIF.TabIndex = 3;
            // 
            // imgNIF
            // 
            imgNIF.AutoSize = true;
            imgNIF.Font = new Font("Segoe UI", 20F);
            imgNIF.ForeColor = Color.FromArgb(9, 171, 219);
            imgNIF.Location = new Point(4, 2);
            imgNIF.Name = "imgNIF";
            imgNIF.Size = new Size(54, 37);
            imgNIF.TabIndex = 1;
            imgNIF.Text = "\U0001faaa";
            imgNIF.TextAlign = ContentAlignment.TopCenter;
            // 
            // panelContacto
            // 
            panelContacto.BackColor = Color.White;
            panelContacto.Controls.Add(txtContacto);
            panelContacto.Controls.Add(txtContactoCodPais);
            panelContacto.Controls.Add(imgContacto);
            panelContacto.Location = new Point(250, 368);
            panelContacto.Name = "panelContacto";
            panelContacto.Size = new Size(323, 45);
            panelContacto.TabIndex = 10;
            // 
            // txtContacto
            // 
            txtContacto.BorderStyle = BorderStyle.None;
            txtContacto.Font = new Font("Montserrat", 12F);
            txtContacto.ForeColor = Color.FromArgb(9, 171, 219);
            txtContacto.Location = new Point(102, 13);
            txtContacto.MaxLength = 9;
            txtContacto.Name = "txtContacto";
            txtContacto.PlaceholderText = "Contacto";
            txtContacto.Size = new Size(182, 20);
            txtContacto.TabIndex = 5;
            // 
            // txtContactoCodPais
            // 
            txtContactoCodPais.BorderStyle = BorderStyle.None;
            txtContactoCodPais.Font = new Font("Montserrat", 12F);
            txtContactoCodPais.ForeColor = Color.FromArgb(9, 171, 219);
            txtContactoCodPais.Location = new Point(54, 13);
            txtContactoCodPais.MaxLength = 4;
            txtContactoCodPais.Name = "txtContactoCodPais";
            txtContactoCodPais.Size = new Size(42, 20);
            txtContactoCodPais.TabIndex = 4;
            txtContactoCodPais.Text = "+351";
            // 
            // imgContacto
            // 
            imgContacto.AutoSize = true;
            imgContacto.Font = new Font("Segoe UI", 20F);
            imgContacto.ForeColor = Color.FromArgb(9, 171, 219);
            imgContacto.Location = new Point(4, 4);
            imgContacto.Name = "imgContacto";
            imgContacto.Size = new Size(54, 37);
            imgContacto.TabIndex = 1;
            imgContacto.Text = "📞";
            imgContacto.TextAlign = ContentAlignment.TopCenter;
            // 
            // panelTipoUser
            // 
            panelTipoUser.BackColor = Color.White;
            panelTipoUser.Controls.Add(rdbCliente);
            panelTipoUser.Controls.Add(rdbAdmin);
            panelTipoUser.Controls.Add(imgTipoUser);
            panelTipoUser.Location = new Point(250, 530);
            panelTipoUser.Name = "panelTipoUser";
            panelTipoUser.Size = new Size(323, 45);
            panelTipoUser.TabIndex = 11;
            // 
            // rdbCliente
            // 
            rdbCliente.AutoSize = true;
            rdbCliente.Checked = true;
            rdbCliente.Font = new Font("Montserrat", 9F);
            rdbCliente.Location = new Point(196, 15);
            rdbCliente.Name = "rdbCliente";
            rdbCliente.Size = new Size(67, 20);
            rdbCliente.TabIndex = 3;
            rdbCliente.TabStop = true;
            rdbCliente.Text = "Cliente";
            rdbCliente.UseVisualStyleBackColor = true;
            // 
            // rdbAdmin
            // 
            rdbAdmin.AutoSize = true;
            rdbAdmin.Font = new Font("Montserrat", 9F);
            rdbAdmin.Location = new Point(63, 15);
            rdbAdmin.Name = "rdbAdmin";
            rdbAdmin.Size = new Size(112, 20);
            rdbAdmin.TabIndex = 2;
            rdbAdmin.TabStop = true;
            rdbAdmin.Text = "Administrador";
            rdbAdmin.UseVisualStyleBackColor = true;
            // 
            // imgTipoUser
            // 
            imgTipoUser.AutoSize = true;
            imgTipoUser.Font = new Font("Segoe UI", 20F);
            imgTipoUser.ForeColor = Color.FromArgb(9, 171, 219);
            imgTipoUser.Location = new Point(4, 6);
            imgTipoUser.Name = "imgTipoUser";
            imgTipoUser.Size = new Size(54, 37);
            imgTipoUser.TabIndex = 1;
            imgTipoUser.Text = "🛡️";
            imgTipoUser.TextAlign = ContentAlignment.TopCenter;
            // 
            // panelMorada
            // 
            panelMorada.BackColor = Color.White;
            panelMorada.Controls.Add(txtMorada);
            panelMorada.Controls.Add(lblMorada);
            panelMorada.Location = new Point(250, 440);
            panelMorada.Name = "panelMorada";
            panelMorada.Size = new Size(323, 77);
            panelMorada.TabIndex = 11;
            // 
            // txtMorada
            // 
            txtMorada.BorderStyle = BorderStyle.None;
            txtMorada.Font = new Font("Montserrat", 12F);
            txtMorada.ForeColor = Color.FromArgb(9, 171, 219);
            txtMorada.Location = new Point(56, 13);
            txtMorada.MaxLength = 150;
            txtMorada.Multiline = true;
            txtMorada.Name = "txtMorada";
            txtMorada.PlaceholderText = "Morada";
            txtMorada.Size = new Size(228, 52);
            txtMorada.TabIndex = 5;
            // 
            // lblMorada
            // 
            lblMorada.AutoSize = true;
            lblMorada.Font = new Font("Segoe UI", 20F);
            lblMorada.ForeColor = Color.FromArgb(9, 171, 219);
            lblMorada.Location = new Point(4, 21);
            lblMorada.Name = "lblMorada";
            lblMorada.Size = new Size(54, 37);
            lblMorada.TabIndex = 1;
            lblMorada.Text = "🏠";
            lblMorada.TextAlign = ContentAlignment.TopCenter;
            // 
            // SignupForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = SystemColors.Control;
            ClientSize = new Size(569, 675);
            Controls.Add(panelMorada);
            Controls.Add(panelDN);
            Controls.Add(panelTipoUser);
            Controls.Add(panelContacto);
            Controls.Add(panelNif);
            Controls.Add(btnSubmit);
            Controls.Add(lblLoginAqui);
            Controls.Add(panelPassword);
            Controls.Add(panelUser);
            Controls.Add(btnSair);
            Controls.Add(lblTitle);
            Controls.Add(leftPanel);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SignupForm";
            StartPosition = FormStartPosition.CenterScreen;
            TopMost = true;
            leftPanel.ResumeLayout(false);
            leftPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)imgLeftClick).EndInit();
            panelUser.ResumeLayout(false);
            panelUser.PerformLayout();
            panelPassword.ResumeLayout(false);
            panelPassword.PerformLayout();
            panelDN.ResumeLayout(false);
            panelDN.PerformLayout();
            panelNif.ResumeLayout(false);
            panelNif.PerformLayout();
            panelContacto.ResumeLayout(false);
            panelContacto.PerformLayout();
            panelTipoUser.ResumeLayout(false);
            panelTipoUser.PerformLayout();
            panelMorada.ResumeLayout(false);
            panelMorada.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel leftPanel;
        private PictureBox imgLeftClick;
        private Label labelTitulo;
        private Label lblSubtitulo;
        private Label labelRodape;
        private Label lblTitle;
        private Label btnSair;
        private Panel panelUser;
        private Panel panelPassword;
        private Label imgUser;
        private Label imgPwd;
        private Button btnSubmit;
        private Label lblLoginAqui;
        private TextBox txtNome;
        private Label btnHidePwd;
        private TextBox txtPassword;
        private Panel panelDN;
        private Label imgDataNasc;
        private DateTimePicker dtpNasc;
        private Panel panelNif;
        private TextBox txtNIF;
        private Label imgNIF;
        private Panel panelContacto;
        private TextBox txtContactoCodPais;
        private Label imgContacto;
        private TextBox txtContacto;
        private Panel panelTipoUser;
        private RadioButton rdbCliente;
        private RadioButton rdbAdmin;
        private Label imgTipoUser;
        private Label label4;
        private Panel panelMorada;
        private TextBox txtMorada;
        private Label lblMorada;
    }
}
