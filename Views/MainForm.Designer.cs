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
            msMainForm = new MenuStrip();
            produtosToolStripMenuItem = new ToolStripMenuItem();
            clientesToolStripMenuItem = new ToolStripMenuItem();
            clientesToolStripMenuItem1 = new ToolStripMenuItem();
            marcasToolStripMenuItem = new ToolStripMenuItem();
            vendasToolStripMenuItem = new ToolStripMenuItem();
            campanhasToolStripMenuItem = new ToolStripMenuItem();
            panelContainer = new Panel();
            msMainForm.SuspendLayout();
            SuspendLayout();
            // 
            // msMainForm
            // 
            msMainForm.BackColor = Color.Transparent;
            msMainForm.Items.AddRange(new ToolStripItem[] { produtosToolStripMenuItem, clientesToolStripMenuItem, clientesToolStripMenuItem1, marcasToolStripMenuItem, vendasToolStripMenuItem, campanhasToolStripMenuItem });
            msMainForm.Location = new Point(20, 60);
            msMainForm.Name = "msMainForm";
            msMainForm.RenderMode = ToolStripRenderMode.Professional;
            msMainForm.Size = new Size(880, 24);
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
            // clientesToolStripMenuItem1
            // 
            clientesToolStripMenuItem1.Name = "clientesToolStripMenuItem1";
            clientesToolStripMenuItem1.Size = new Size(61, 20);
            clientesToolStripMenuItem1.Text = "Clientes";
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
            // campanhasToolStripMenuItem
            // 
            campanhasToolStripMenuItem.Name = "campanhasToolStripMenuItem";
            campanhasToolStripMenuItem.Size = new Size(82, 20);
            campanhasToolStripMenuItem.Text = "Campanhas";
            // 
            // panelContainer
            // 
            panelContainer.Dock = DockStyle.Fill;
            panelContainer.Location = new Point(20, 84);
            panelContainer.Name = "panelContainer";
            panelContainer.Size = new Size(880, 466);
            panelContainer.TabIndex = 1;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(920, 570);
            Controls.Add(panelContainer);
            Controls.Add(msMainForm);
            MainMenuStrip = msMainForm;
            MinimumSize = new Size(920, 570);
            Name = "MainForm";
            Text = "Gestor de Comércio Eletrónico";
            Theme = MetroFramework.MetroThemeStyle.Light;
            Load += Form1_Load;
            msMainForm.ResumeLayout(false);
            msMainForm.PerformLayout();
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
    }
}
