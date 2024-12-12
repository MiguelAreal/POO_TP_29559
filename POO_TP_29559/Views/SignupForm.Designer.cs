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
            panel3 = new Panel();
            label6 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            lblTitle = new Label();
            btnSair = new Label();
            panelUser = new Panel();
            txtUser = new TextBox();
            imgUser = new Label();
            panelPassword = new Panel();
            btnHidePwd = new Label();
            txtPassword = new TextBox();
            imgPwd = new Label();
            btnSubmit = new Button();
            lblLoginAqui = new Label();
            panel1 = new Panel();
            dtpNasc = new DateTimePicker();
            label5 = new Label();
            panel2 = new Panel();
            txtNIF = new TextBox();
            label4 = new Label();
            panel4 = new Panel();
            txtContacto = new TextBox();
            txtContactoCodPais = new TextBox();
            label7 = new Label();
            leftPanel.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panelUser.SuspendLayout();
            panelPassword.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // leftPanel
            // 
            leftPanel.BackColor = Color.FromArgb(9, 171, 219);
            leftPanel.Controls.Add(panel3);
            leftPanel.Controls.Add(label3);
            leftPanel.Controls.Add(label2);
            leftPanel.Controls.Add(label1);
            leftPanel.Controls.Add(pictureBox1);
            leftPanel.Dock = DockStyle.Left;
            leftPanel.Location = new Point(0, 0);
            leftPanel.Margin = new Padding(0);
            leftPanel.Name = "leftPanel";
            leftPanel.Size = new Size(249, 532);
            leftPanel.TabIndex = 0;
            leftPanel.Paint += leftPanel_Paint;
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(label6);
            panel3.Location = new Point(251, 379);
            panel3.Name = "panel3";
            panel3.Size = new Size(323, 45);
            panel3.TabIndex = 10;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 20F);
            label6.ForeColor = Color.FromArgb(9, 171, 219);
            label6.Location = new Point(3, -1);
            label6.Name = "label6";
            label6.Size = new Size(54, 37);
            label6.TabIndex = 1;
            label6.Text = "\U0001faaa";
            label6.TextAlign = ContentAlignment.TopCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Bottom;
            label3.Font = new Font("Montserrat", 9F);
            label3.ForeColor = Color.White;
            label3.Location = new Point(0, 500);
            label3.Name = "label3";
            label3.Size = new Size(142, 32);
            label3.TabIndex = 3;
            label3.Text = "Desenvolvido por\r\nMiguel Areal - Nº29559";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Montserrat", 14F);
            label2.ForeColor = Color.White;
            label2.Location = new Point(44, 207);
            label2.Name = "label2";
            label2.Size = new Size(202, 52);
            label2.TabIndex = 2;
            label2.Text = "Gestor de Comércio\r\nEletrónico";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Montserrat", 14F);
            label1.ForeColor = Color.White;
            label1.Location = new Point(28, 176);
            label1.Name = "label1";
            label1.Size = new Size(218, 26);
            label1.TabIndex = 1;
            label1.Text = "Bem vindo à LeftClick";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.leftclick_logo;
            pictureBox1.Location = new Point(65, 27);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(115, 122);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
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
            panelUser.Controls.Add(txtUser);
            panelUser.Controls.Add(imgUser);
            panelUser.Location = new Point(249, 86);
            panelUser.Name = "panelUser";
            panelUser.Size = new Size(329, 45);
            panelUser.TabIndex = 6;
            // 
            // txtUser
            // 
            txtUser.BorderStyle = BorderStyle.None;
            txtUser.Font = new Font("Montserrat", 12F);
            txtUser.ForeColor = Color.FromArgb(9, 171, 219);
            txtUser.Location = new Point(55, 12);
            txtUser.Name = "txtUser";
            txtUser.PlaceholderText = "Nome";
            txtUser.Size = new Size(227, 20);
            txtUser.TabIndex = 1;
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
            panelPassword.Location = new Point(249, 156);
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
            imgPwd.Location = new Point(3, 4);
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
            btnSubmit.Location = new Point(342, 434);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(148, 42);
            btnSubmit.TabIndex = 5;
            btnSubmit.Text = "REGISTAR";
            btnSubmit.UseVisualStyleBackColor = false;
            // 
            // lblLoginAqui
            // 
            lblLoginAqui.AutoSize = true;
            lblLoginAqui.Cursor = Cursors.Hand;
            lblLoginAqui.Font = new Font("Montserrat", 9.749999F, FontStyle.Underline, GraphicsUnit.Point, 0);
            lblLoginAqui.ForeColor = Color.FromArgb(9, 171, 219);
            lblLoginAqui.Location = new Point(331, 486);
            lblLoginAqui.Name = "lblLoginAqui";
            lblLoginAqui.Size = new Size(170, 18);
            lblLoginAqui.TabIndex = 6;
            lblLoginAqui.Text = "Já tem conta? Entre aqui";
            lblLoginAqui.TextAlign = ContentAlignment.MiddleLeft;
            lblLoginAqui.Click += lblLoginAqui_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(dtpNasc);
            panel1.Controls.Add(label5);
            panel1.Location = new Point(248, 226);
            panel1.Name = "panel1";
            panel1.Size = new Size(323, 45);
            panel1.TabIndex = 8;
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
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 20F);
            label5.ForeColor = Color.FromArgb(9, 171, 219);
            label5.Location = new Point(3, 4);
            label5.Name = "label5";
            label5.Size = new Size(54, 37);
            label5.TabIndex = 1;
            label5.Text = "📅";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(txtNIF);
            panel2.Controls.Add(label4);
            panel2.Location = new Point(249, 296);
            panel2.Name = "panel2";
            panel2.Size = new Size(323, 45);
            panel2.TabIndex = 9;
            // 
            // txtNIF
            // 
            txtNIF.BorderStyle = BorderStyle.None;
            txtNIF.Font = new Font("Montserrat", 12F);
            txtNIF.ForeColor = Color.FromArgb(9, 171, 219);
            txtNIF.Location = new Point(54, 13);
            txtNIF.Name = "txtNIF";
            txtNIF.PlaceholderText = "NIF";
            txtNIF.Size = new Size(228, 20);
            txtNIF.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 20F);
            label4.ForeColor = Color.FromArgb(9, 171, 219);
            label4.Location = new Point(3, -1);
            label4.Name = "label4";
            label4.Size = new Size(54, 37);
            label4.TabIndex = 1;
            label4.Text = "\U0001faaa";
            label4.TextAlign = ContentAlignment.TopCenter;
            // 
            // panel4
            // 
            panel4.BackColor = Color.White;
            panel4.Controls.Add(txtContacto);
            panel4.Controls.Add(txtContactoCodPais);
            panel4.Controls.Add(label7);
            panel4.Location = new Point(249, 368);
            panel4.Name = "panel4";
            panel4.Size = new Size(323, 45);
            panel4.TabIndex = 10;
            // 
            // txtContacto
            // 
            txtContacto.BorderStyle = BorderStyle.None;
            txtContacto.Font = new Font("Montserrat", 12F);
            txtContacto.ForeColor = Color.FromArgb(9, 171, 219);
            txtContacto.Location = new Point(102, 13);
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
            txtContactoCodPais.Name = "txtContactoCodPais";
            txtContactoCodPais.Size = new Size(42, 20);
            txtContactoCodPais.TabIndex = 4;
            txtContactoCodPais.Text = "+351";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 20F);
            label7.ForeColor = Color.FromArgb(9, 171, 219);
            label7.Location = new Point(3, 4);
            label7.Name = "label7";
            label7.Size = new Size(54, 37);
            label7.TabIndex = 1;
            label7.Text = "📞";
            label7.TextAlign = ContentAlignment.TopCenter;
            // 
            // SignupForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = SystemColors.Control;
            ClientSize = new Size(569, 532);
            Controls.Add(panel4);
            Controls.Add(panel2);
            Controls.Add(panel1);
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
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panelUser.ResumeLayout(false);
            panelUser.PerformLayout();
            panelPassword.ResumeLayout(false);
            panelPassword.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel leftPanel;
        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label lblTitle;
        private Label btnSair;
        private Panel panelUser;
        private Panel panelPassword;
        private Label imgUser;
        private Label imgPwd;
        private Button btnSubmit;
        private Label lblLoginAqui;
        private TextBox txtUser;
        private Label btnHidePwd;
        private TextBox txtPassword;
        private Panel panel1;
        private Label label5;
        private DateTimePicker dtpNasc;
        private Panel panel2;
        private TextBox txtNIF;
        private Label label4;
        private Panel panel3;
        private Label label6;
        private Panel panel4;
        private TextBox txtContactoCodPais;
        private Label label7;
        private TextBox txtContacto;
    }
}
