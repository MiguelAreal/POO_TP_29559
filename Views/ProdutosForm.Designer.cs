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
            dgvProdutos.AllowUserToResizeRows = false;
            dgvProdutos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvProdutos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProdutos.BackgroundColor = Color.White;
            dgvProdutos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
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
            btnAddProduto.Location = new Point(131, 29);
            btnAddProduto.Name = "btnAddProduto";
            btnAddProduto.Size = new Size(43, 23);
            btnAddProduto.TabIndex = 1;
            btnAddProduto.Text = "+";
            btnAddProduto.UseVisualStyleBackColor = true;
            btnAddProduto.Click += button1_Click_1;
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
            btnRemProduto.Location = new Point(180, 29);
            btnRemProduto.Name = "btnRemProduto";
            btnRemProduto.Size = new Size(43, 23);
            btnRemProduto.TabIndex = 4;
            btnRemProduto.Text = "-";
            btnRemProduto.UseVisualStyleBackColor = true;
            btnRemProduto.Click += button2_Click;
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