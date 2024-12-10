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
            produtosToolStripMenuItem = new ToolStripMenuItem();
            clientesToolStripMenuItem = new ToolStripMenuItem();
            marcasToolStripMenuItem = new ToolStripMenuItem();
            vendasToolStripMenuItem = new ToolStripMenuItem();
            clientesToolStripMenuItem1 = new ToolStripMenuItem();
            campanhasToolStripMenuItem = new ToolStripMenuItem();
            panelContainer = new Panel();
            picBg = new PictureBox();
            statusStrip1 = new StatusStrip();
            github = new ToolStripStatusLabel();
            msMainForm.SuspendLayout();
            panelContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picBg).BeginInit();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // msMainForm
            // 
            msMainForm.BackColor = Color.Transparent;
            msMainForm.Items.AddRange(new ToolStripItem[] { produtosToolStripMenuItem, clientesToolStripMenuItem, marcasToolStripMenuItem, vendasToolStripMenuItem, clientesToolStripMenuItem1, campanhasToolStripMenuItem });
            msMainForm.Location = new Point(5, 60);
            msMainForm.Name = "msMainForm";
            msMainForm.RenderMode = ToolStripRenderMode.Professional;
            msMainForm.Size = new Size(990, 24);
            msMainForm.TabIndex = 0;
            msMainForm.Text = "msMainForm";
            msMainForm.ItemClicked += msMainForm_ItemClicked;
            // 
            // produtosToolStripMenuItem
            // 
            produtosToolStripMenuItem.Name = "produtosToolStripMenuItem";
            produtosToolStripMenuItem.Size = new Size(67, 20);
            produtosToolStripMenuItem.Text = "Produtos";
            // 
            // clientesToolStripMenuItem
            // 
            clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            clientesToolStripMenuItem.Size = new Size(75, 20);
            clientesToolStripMenuItem.Text = "Categorias";
            // 
            // marcasToolStripMenuItem
            // 
            marcasToolStripMenuItem.Name = "marcasToolStripMenuItem";
            marcasToolStripMenuItem.Size = new Size(57, 20);
            marcasToolStripMenuItem.Text = "Marcas";
            // 
            // vendasToolStripMenuItem
            // 
            vendasToolStripMenuItem.Name = "vendasToolStripMenuItem";
            vendasToolStripMenuItem.Size = new Size(56, 20);
            vendasToolStripMenuItem.Text = "Vendas";
            // 
            // clientesToolStripMenuItem1
            // 
            clientesToolStripMenuItem1.Name = "clientesToolStripMenuItem1";
            clientesToolStripMenuItem1.Size = new Size(61, 20);
            clientesToolStripMenuItem1.Text = "Clientes";
            // 
            // campanhasToolStripMenuItem
            // 
            campanhasToolStripMenuItem.Name = "campanhasToolStripMenuItem";
            campanhasToolStripMenuItem.Size = new Size(82, 20);
            campanhasToolStripMenuItem.Text = "Campanhas";
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
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;
            ClientSize = new Size(1000, 800);
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
        private ToolStripMenuItem produtosToolStripMenuItem;
        private ToolStripMenuItem clientesToolStripMenuItem;
        private ToolStripMenuItem clientesToolStripMenuItem1;
        private ToolStripMenuItem marcasToolStripMenuItem;
        private ToolStripMenuItem vendasToolStripMenuItem;
        private ToolStripMenuItem campanhasToolStripMenuItem;
        private Panel panelContainer;
        private PictureBox picBg;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel github;
    }
}
