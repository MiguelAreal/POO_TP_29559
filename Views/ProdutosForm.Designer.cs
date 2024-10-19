namespace poo_tp_29559
{
    partial class ProdutosForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProdutosForm));
            dgvProdutos = new DataGridView();
            button1 = new Button();
            txtSearchProduto = new TextBox();
            btnSearchProduto = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvProdutos).BeginInit();
            SuspendLayout();
            // 
            // dgvProdutos
            // 
            dgvProdutos.AllowUserToDeleteRows = false;
            dgvProdutos.AllowUserToResizeRows = false;
            dgvProdutos.BackgroundColor = Color.White;
            dgvProdutos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProdutos.Location = new Point(20, 101);
            dgvProdutos.Name = "dgvProdutos";
            dgvProdutos.Size = new Size(760, 329);
            dgvProdutos.TabIndex = 0;
            dgvProdutos.CellContentClick += dataGridView1_CellContentClick;
            // 
            // button1
            // 
            button1.Location = new Point(140, 28);
            button1.Name = "button1";
            button1.Size = new Size(43, 23);
            button1.TabIndex = 1;
            button1.Text = "+";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // txtSearchProduto
            // 
            txtSearchProduto.Location = new Point(20, 72);
            txtSearchProduto.Name = "txtSearchProduto";
            txtSearchProduto.Size = new Size(260, 23);
            txtSearchProduto.TabIndex = 2;
            // 
            // btnSearchProduto
            // 
            btnSearchProduto.BackColor = Color.Transparent;
            btnSearchProduto.BackgroundImage = (Image)resources.GetObject("btnSearchProduto.BackgroundImage");
            btnSearchProduto.BackgroundImageLayout = ImageLayout.Zoom;
            btnSearchProduto.FlatAppearance.BorderSize = 0;
            btnSearchProduto.FlatStyle = FlatStyle.Flat;
            btnSearchProduto.Location = new Point(284, 67);
            btnSearchProduto.Name = "btnSearchProduto";
            btnSearchProduto.Size = new Size(32, 33);
            btnSearchProduto.TabIndex = 3;
            btnSearchProduto.UseVisualStyleBackColor = false;
            btnSearchProduto.Click += btnSearchProduto_Click;
            // 
            // ProdutosForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSearchProduto);
            Controls.Add(txtSearchProduto);
            Controls.Add(button1);
            Controls.Add(dgvProdutos);
            MaximizeBox = false;
            MinimizeBox = false;
            Movable = false;
            Name = "ProdutosForm";
            Resizable = false;
            ShadowType = MetroFormShadowType.None;
            Text = "Produtos";
            ((System.ComponentModel.ISupportInitialize)dgvProdutos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvProdutos;
        private Button button1;
        private TextBox txtSearchProduto;
        private Button btnSearchProduto;
    }
}