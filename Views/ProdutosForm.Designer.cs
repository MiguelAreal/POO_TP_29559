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
            dgvProdutos = new DataGridView();
            btnAddProduto = new Button();
            txtSearchProduto = new TextBox();
            btnRemProduto = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvProdutos).BeginInit();
            SuspendLayout();
            // 
            // dgvProdutos
            // 
            dgvProdutos.AllowUserToAddRows = false;
            dgvProdutos.AllowUserToResizeRows = false;
            dgvProdutos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvProdutos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProdutos.BackgroundColor = Color.White;
            dgvProdutos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProdutos.Cursor = Cursors.IBeam;
            dgvProdutos.Location = new Point(20, 96);
            dgvProdutos.MultiSelect = false;
            dgvProdutos.Name = "dgvProdutos";
            dgvProdutos.RowHeadersVisible = false;
            dgvProdutos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProdutos.Size = new Size(760, 331);
            dgvProdutos.TabIndex = 0;
            dgvProdutos.CellValueChanged += dgvProdutos_CellValueChanged;
            // 
            // btnAddProduto
            // 
            btnAddProduto.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddProduto.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnAddProduto.BackColor = Color.FromArgb(13, 170, 220);
            btnAddProduto.Cursor = Cursors.Hand;
            btnAddProduto.FlatAppearance.BorderSize = 0;
            btnAddProduto.FlatStyle = FlatStyle.Flat;
            btnAddProduto.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddProduto.ForeColor = Color.Black;
            btnAddProduto.Location = new Point(726, 50);
            btnAddProduto.Name = "btnAddProduto";
            btnAddProduto.Size = new Size(54, 42);
            btnAddProduto.TabIndex = 1;
            btnAddProduto.Text = "+";
            btnAddProduto.TextAlign = ContentAlignment.TopCenter;
            btnAddProduto.UseVisualStyleBackColor = false;
            btnAddProduto.Click += btnAddProduto_Click;
            btnAddProduto.Enter += btnAddProduto_Enter;
            btnAddProduto.Leave += btnAddProduto_Leave;
            // 
            // txtSearchProduto
            // 
            txtSearchProduto.Font = new Font("Segoe UI", 10F);
            txtSearchProduto.Location = new Point(20, 67);
            txtSearchProduto.Name = "txtSearchProduto";
            txtSearchProduto.PlaceholderText = "Procurar...";
            txtSearchProduto.Size = new Size(260, 25);
            txtSearchProduto.TabIndex = 2;
            txtSearchProduto.TextChanged += txtSearchProduto_TextChanged;
            // 
            // btnRemProduto
            // 
            btnRemProduto.Cursor = Cursors.Hand;
            btnRemProduto.Location = new Point(128, 27);
            btnRemProduto.Name = "btnRemProduto";
            btnRemProduto.Size = new Size(43, 23);
            btnRemProduto.TabIndex = 4;
            btnRemProduto.Text = "-";
            btnRemProduto.UseVisualStyleBackColor = true;
            btnRemProduto.Click += btnRemProduto_Click;
            // 
            // ProdutosForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;
            ClientSize = new Size(800, 450);
            Controls.Add(btnRemProduto);
            Controls.Add(txtSearchProduto);
            Controls.Add(btnAddProduto);
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
        private Button btnAddProduto;
        private TextBox txtSearchProduto;
        private Button btnRemProduto;
    }
}