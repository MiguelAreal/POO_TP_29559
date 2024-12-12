namespace poo_tp_29559.Views
{
    partial class LoginForm
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
            Panel leftPanel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            lblTitle = new Label();
            btnSair = new Label();
            panelUser = new Panel();
            txtNIF = new TextBox();
            imgUser = new Label();
            panelPassword = new Panel();
            btnHidePwd = new Label();
            txtPassword = new TextBox();
            imgPwd = new Label();
            btnSubmit = new Button();
            lblRegisteAqui = new Label();
            leftPanel = new Panel();
            leftPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panelUser.SuspendLayout();
            panelPassword.SuspendLayout();
            SuspendLayout();
            // 
            // leftPanel
            // 
            leftPanel.BackColor = Color.FromArgb(9, 171, 219);
            leftPanel.Controls.Add(label3);
            leftPanel.Controls.Add(label2);
            leftPanel.Controls.Add(label1);
            leftPanel.Controls.Add(pictureBox1);
            leftPanel.Dock = DockStyle.Left;
            leftPanel.Location = new Point(0, 0);
            leftPanel.Margin = new Padding(0);
            leftPanel.Name = "leftPanel";
            leftPanel.Size = new Size(249, 436);
            leftPanel.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Bottom;
            label3.Font = new Font("Montserrat", 9F);
            label3.ForeColor = Color.White;
            label3.Location = new Point(0, 404);
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
            lblTitle.Size = new Size(243, 26);
            lblTitle.TabIndex = 4;
            lblTitle.Text = "Faça Login na sua conta";
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
            panelUser.Controls.Add(txtNIF);
            panelUser.Controls.Add(imgUser);
            panelUser.Location = new Point(249, 135);
            panelUser.Name = "panelUser";
            panelUser.Size = new Size(329, 45);
            panelUser.TabIndex = 6;
            // 
            // txtNIF
            // 
            txtNIF.BorderStyle = BorderStyle.None;
            txtNIF.Font = new Font("Montserrat", 12F);
            txtNIF.ForeColor = Color.FromArgb(9, 171, 219);
            txtNIF.Location = new Point(55, 12);
            txtNIF.MaxLength = 9;
            txtNIF.Name = "txtNIF";
            txtNIF.PlaceholderText = "NIF";
            txtNIF.Size = new Size(227, 20);
            txtNIF.TabIndex = 1;
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
            panelPassword.Location = new Point(249, 205);
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
            btnSubmit.Location = new Point(340, 305);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(148, 42);
            btnSubmit.TabIndex = 5;
            btnSubmit.Text = "ENTRAR";
            btnSubmit.UseVisualStyleBackColor = false;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // lblRegisteAqui
            // 
            lblRegisteAqui.AutoSize = true;
            lblRegisteAqui.Cursor = Cursors.Hand;
            lblRegisteAqui.Font = new Font("Montserrat", 9.749999F, FontStyle.Underline, GraphicsUnit.Point, 0);
            lblRegisteAqui.ForeColor = Color.FromArgb(9, 171, 219);
            lblRegisteAqui.Location = new Point(306, 362);
            lblRegisteAqui.Name = "lblRegisteAqui";
            lblRegisteAqui.Size = new Size(213, 18);
            lblRegisteAqui.TabIndex = 6;
            lblRegisteAqui.Text = "Não tem conta? Registe-se aqui";
            lblRegisteAqui.TextAlign = ContentAlignment.MiddleLeft;
            lblRegisteAqui.Click += lblRegisteAqui_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = SystemColors.Control;
            ClientSize = new Size(569, 436);
            Controls.Add(btnSubmit);
            Controls.Add(lblRegisteAqui);
            Controls.Add(panelPassword);
            Controls.Add(panelUser);
            Controls.Add(btnSair);
            Controls.Add(lblTitle);
            Controls.Add(leftPanel);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            TopMost = true;
            leftPanel.ResumeLayout(false);
            leftPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panelUser.ResumeLayout(false);
            panelUser.PerformLayout();
            panelPassword.ResumeLayout(false);
            panelPassword.PerformLayout();
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
        private Label lblRegisteAqui;
        private TextBox txtNIF;
        private Label btnHidePwd;
        private TextBox txtPassword;
    }
}