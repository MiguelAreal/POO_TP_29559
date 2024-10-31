namespace poo_tp_29559
{
    partial class CategoriasForm
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            btnAddMarca = new Button();
            txtSearchCategorias = new TextBox();
            dgvCategorias = new DataGridView();
            btnRemProduto = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCategorias).BeginInit();
            SuspendLayout();
            // 
            // btnAddMarca
            // 
            btnAddMarca.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddMarca.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnAddMarca.BackColor = Color.FromArgb(13, 170, 220);
            btnAddMarca.Cursor = Cursors.Hand;
            btnAddMarca.FlatAppearance.BorderSize = 0;
            btnAddMarca.FlatStyle = FlatStyle.Flat;
            btnAddMarca.Font = new Font("Segoe UI", 13F);
            btnAddMarca.ForeColor = Color.White;
            btnAddMarca.Location = new Point(726, 48);
            btnAddMarca.Name = "btnAddMarca";
            btnAddMarca.Size = new Size(54, 42);
            btnAddMarca.TabIndex = 10;
            btnAddMarca.Text = "➕";
            btnAddMarca.UseVisualStyleBackColor = false;
            btnAddMarca.Click += btnAddMarca_Click;
            // 
            // txtSearchCategorias
            // 
            txtSearchCategorias.Font = new Font("Segoe UI", 10F);
            txtSearchCategorias.Location = new Point(20, 67);
            txtSearchCategorias.Name = "txtSearchCategorias";
            txtSearchCategorias.PlaceholderText = "Procurar...";
            txtSearchCategorias.Size = new Size(260, 25);
            txtSearchCategorias.TabIndex = 9;
            // 
            // dgvCategorias
            // 
            dgvCategorias.AllowUserToAddRows = false;
            dgvCategorias.AllowUserToResizeRows = false;
            dgvCategorias.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvCategorias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCategorias.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvCategorias.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvCategorias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCategorias.Location = new Point(20, 96);
            dgvCategorias.MultiSelect = false;
            dgvCategorias.Name = "dgvCategorias";
            dgvCategorias.RowHeadersVisible = false;
            dgvCategorias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCategorias.Size = new Size(760, 331);
            dgvCategorias.TabIndex = 8;
            // 
            // btnRemProduto
            // 
            btnRemProduto.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRemProduto.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnRemProduto.BackColor = Color.Crimson;
            btnRemProduto.BackgroundImageLayout = ImageLayout.Zoom;
            btnRemProduto.Cursor = Cursors.Hand;
            btnRemProduto.FlatAppearance.BorderSize = 0;
            btnRemProduto.FlatStyle = FlatStyle.Flat;
            btnRemProduto.Font = new Font("Segoe UI", 13F);
            btnRemProduto.ForeColor = Color.White;
            btnRemProduto.Location = new Point(659, 48);
            btnRemProduto.Name = "btnRemProduto";
            btnRemProduto.Size = new Size(54, 42);
            btnRemProduto.TabIndex = 11;
            btnRemProduto.Text = "❌";
            btnRemProduto.UseVisualStyleBackColor = false;
            // 
            // CategoriasForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;
            ClientSize = new Size(800, 450);
            Controls.Add(btnRemProduto);
            Controls.Add(btnAddMarca);
            Controls.Add(txtSearchCategorias);
            Controls.Add(dgvCategorias);
            MaximizeBox = false;
            MinimizeBox = false;
            Movable = false;
            Name = "CategoriasForm";
            ShadowType = MetroFormShadowType.None;
            Text = "Categorias";
            ((System.ComponentModel.ISupportInitialize)dgvCategorias).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAddMarca;
        private TextBox txtSearchCategorias;
        private DataGridView dgvCategorias;
        private Button btnRemProduto;
    }
}