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
            button1 = new Button();
            txtSearchProduto = new TextBox();
            button2 = new Button();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
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
            dgvProdutos.Size = new Size(760, 329);
            dgvProdutos.TabIndex = 0;
            dgvProdutos.CellValueChanged += dgvProdutos_CellValueChanged;
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
            txtSearchProduto.Font = new Font("Segoe UI", 10F);
            txtSearchProduto.Location = new Point(20, 67);
            txtSearchProduto.Name = "txtSearchProduto";
            txtSearchProduto.PlaceholderText = "Procurar...";
            txtSearchProduto.Size = new Size(260, 25);
            txtSearchProduto.TabIndex = 2;
            txtSearchProduto.TextChanged += txtSearchProduto_TextChanged;
            // 
            // button2
            // 
            button2.Location = new Point(189, 28);
            button2.Name = "button2";
            button2.Size = new Size(43, 23);
            button2.TabIndex = 4;
            button2.Text = "-";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // ProdutosForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;
            ClientSize = new Size(800, 450);
            Controls.Add(button2);
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
        private Button button2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}