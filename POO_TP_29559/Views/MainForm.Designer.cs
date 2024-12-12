namespace poo_tp_29559
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            msMainForm = new MenuStrip();
            produtosTSMI = new ToolStripMenuItem();
            categoriasTSMI = new ToolStripMenuItem();
            marcasTSMI = new ToolStripMenuItem();
            campanhasTSMI = new ToolStripMenuItem();
            vendasTSMI = new ToolStripMenuItem();
            clientesTSMI = new ToolStripMenuItem();
            panelContainer = new Panel();
            picBg = new PictureBox();
            statusStrip1 = new StatusStrip();
            github = new ToolStripStatusLabel();
            lblUserInfo = new Label();
            btnLogout = new Label();
            comprarTSMI = new ToolStripMenuItem();
            msMainForm.SuspendLayout();
            panelContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picBg).BeginInit();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // msMainForm
            // 
            msMainForm.BackColor = Color.Transparent;
            msMainForm.Items.AddRange(new ToolStripItem[] { produtosTSMI, categoriasTSMI, marcasTSMI, campanhasTSMI, vendasTSMI, clientesTSMI, comprarTSMI });
            msMainForm.Location = new Point(5, 60);
            msMainForm.Name = "msMainForm";
            msMainForm.RenderMode = ToolStripRenderMode.Professional;
            msMainForm.Size = new Size(990, 24);
            msMainForm.TabIndex = 0;
            msMainForm.Text = "msMainForm";
            msMainForm.ItemClicked += msMainForm_ItemClicked;
            // 
            // produtosTSMI
            // 
            produtosTSMI.Name = "produtosTSMI";
            produtosTSMI.Size = new Size(67, 20);
            produtosTSMI.Text = "Produtos";
            // 
            // categoriasTSMI
            // 
            categoriasTSMI.Name = "categoriasTSMI";
            categoriasTSMI.Size = new Size(75, 20);
            categoriasTSMI.Text = "Categorias";
            // 
            // marcasTSMI
            // 
            marcasTSMI.Name = "marcasTSMI";
            marcasTSMI.Size = new Size(57, 20);
            marcasTSMI.Text = "Marcas";
            // 
            // campanhasTSMI
            // 
            campanhasTSMI.Name = "campanhasTSMI";
            campanhasTSMI.Size = new Size(82, 20);
            campanhasTSMI.Text = "Campanhas";
            // 
            // vendasTSMI
            // 
            vendasTSMI.Name = "vendasTSMI";
            vendasTSMI.Size = new Size(56, 20);
            vendasTSMI.Text = "Vendas";
            // 
            // clientesTSMI
            // 
            clientesTSMI.Name = "clientesTSMI";
            clientesTSMI.Size = new Size(61, 20);
            clientesTSMI.Text = "Clientes";
            // 
            // panelContainer
            // 
            panelContainer.BackColor = Color.Transparent;
            panelContainer.Controls.Add(picBg);
            panelContainer.Dock = DockStyle.Fill;
            panelContainer.Location = new Point(5, 84);
            panelContainer.Name = "panelContainer";
            panelContainer.Size = new Size(990, 686);
            panelContainer.TabIndex = 1;
            // 
            // picBg
            // 
            picBg.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            picBg.BackColor = Color.Transparent;
            picBg.Image = (Image)resources.GetObject("picBg.Image");
            picBg.Location = new Point(381, 199);
            picBg.Name = "picBg";
            picBg.Size = new Size(230, 266);
            picBg.SizeMode = PictureBoxSizeMode.Zoom;
            picBg.TabIndex = 0;
            picBg.TabStop = false;
            picBg.WaitOnLoad = true;
            // 
            // statusStrip1
            // 
            statusStrip1.GripMargin = new Padding(2, 2, 2, 0);
            statusStrip1.Items.AddRange(new ToolStripItem[] { github });
            statusStrip1.LayoutStyle = ToolStripLayoutStyle.Flow;
            statusStrip1.Location = new Point(5, 770);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.RenderMode = ToolStripRenderMode.Professional;
            statusStrip1.Size = new Size(990, 25);
            statusStrip1.SizingGrip = false;
            statusStrip1.TabIndex = 2;
            statusStrip1.Text = "statusStrip1";
            // 
            // github
            // 
            github.Font = new Font("Segoe UI", 11F);
            github.IsLink = true;
            github.LinkColor = Color.Black;
            github.Name = "github";
            github.Size = new Size(56, 20);
            github.Text = "GitHub";
            github.VisitedLinkColor = Color.Black;
            github.Click += github_Click;
            // 
            // lblUserInfo
            // 
            lblUserInfo.Font = new Font("Montserrat", 9F);
            lblUserInfo.Location = new Point(748, 33);
            lblUserInfo.Name = "lblUserInfo";
            lblUserInfo.Size = new Size(192, 40);
            lblUserInfo.TabIndex = 3;
            lblUserInfo.Text = "UserInfo";
            lblUserInfo.TextAlign = ContentAlignment.TopRight;
            // 
            // btnLogout
            // 
            btnLogout.AutoSize = true;
            btnLogout.Font = new Font("Montserrat", 20F);
            btnLogout.Location = new Point(938, 30);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(54, 37);
            btnLogout.TabIndex = 4;
            btnLogout.Text = "👤";
            btnLogout.TextAlign = ContentAlignment.MiddleRight;
            // 
            // comprarTSMI
            // 
            comprarTSMI.Name = "comprarTSMI";
            comprarTSMI.Size = new Size(66, 20);
            comprarTSMI.Text = "Comprar";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;
            ClientSize = new Size(1000, 800);
            Controls.Add(btnLogout);
            Controls.Add(lblUserInfo);
            Controls.Add(panelContainer);
            Controls.Add(msMainForm);
            Controls.Add(statusStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = msMainForm;
            MinimumSize = new Size(1000, 650);
            Name = "MainForm";
            Padding = new Padding(5, 60, 5, 5);
            ShadowType = MetroFormShadowType.Flat;
            SizeGripStyle = SizeGripStyle.Show;
            Text = "Left Click - Gestor de Comércio Eletrónico";
            Theme = MetroFramework.MetroThemeStyle.Light;
            Load += Form1_Load;
            msMainForm.ResumeLayout(false);
            msMainForm.PerformLayout();
            panelContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picBg).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip msMainForm;
        private ToolStripMenuItem produtosTSMI;
        private ToolStripMenuItem categoriasTSMI;
        private ToolStripMenuItem clientesTSMI;
        private ToolStripMenuItem marcasTSMI;
        private ToolStripMenuItem vendasTSMI;
        private ToolStripMenuItem campanhasTSMI;
        private Panel panelContainer;
        private PictureBox picBg;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel github;
        private Label lblUserInfo;
        private Label btnLogout;
        private ToolStripMenuItem comprarTSMI;
    }
}
