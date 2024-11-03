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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            btnAddCategoria = new Button();
            txtSearchCategorias = new TextBox();
            dgvCategorias = new DataGridView();
            btnRemCategoria = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCategorias).BeginInit();
            SuspendLayout();
            // 
            // btnAddCategoria
            // 
            btnAddCategoria.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddCategoria.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnAddCategoria.BackColor = Color.FromArgb(13, 170, 220);
            btnAddCategoria.Cursor = Cursors.Hand;
            btnAddCategoria.FlatAppearance.BorderSize = 0;
            btnAddCategoria.FlatStyle = FlatStyle.Flat;
            btnAddCategoria.Font = new Font("Segoe UI", 13F);
            btnAddCategoria.ForeColor = Color.White;
            btnAddCategoria.Location = new Point(726, 48);
            btnAddCategoria.Name = "btnAddCategoria";
            btnAddCategoria.Size = new Size(54, 42);
            btnAddCategoria.TabIndex = 2;
            btnAddCategoria.Text = "➕";
            btnAddCategoria.UseVisualStyleBackColor = false;
            btnAddCategoria.Click += btnAddCategoria_Click;
            // 
            // txtSearchCategorias
            // 
            txtSearchCategorias.Font = new Font("Segoe UI", 10F);
            txtSearchCategorias.Location = new Point(20, 67);
            txtSearchCategorias.Name = "txtSearchCategorias";
            txtSearchCategorias.PlaceholderText = "Procurar...";
            txtSearchCategorias.Size = new Size(260, 25);
            txtSearchCategorias.TabIndex = 0;
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
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvCategorias.DefaultCellStyle = dataGridViewCellStyle2;
            dgvCategorias.Location = new Point(20, 96);
            dgvCategorias.MultiSelect = false;
            dgvCategorias.Name = "dgvCategorias";
            dgvCategorias.RowHeadersVisible = false;
            dgvCategorias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCategorias.Size = new Size(760, 331);
            dgvCategorias.TabIndex = 3;
            dgvCategorias.CellValueChanged += dgvCategorias_CellValueChanged;
            // 
            // btnRemCategoria
            // 
            btnRemCategoria.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRemCategoria.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnRemCategoria.BackColor = Color.Crimson;
            btnRemCategoria.BackgroundImageLayout = ImageLayout.Zoom;
            btnRemCategoria.Cursor = Cursors.Hand;
            btnRemCategoria.FlatAppearance.BorderSize = 0;
            btnRemCategoria.FlatStyle = FlatStyle.Flat;
            btnRemCategoria.Font = new Font("Segoe UI", 13F);
            btnRemCategoria.ForeColor = Color.White;
            btnRemCategoria.Location = new Point(659, 48);
            btnRemCategoria.Name = "btnRemCategoria";
            btnRemCategoria.Size = new Size(54, 42);
            btnRemCategoria.TabIndex = 1;
            btnRemCategoria.Text = "❌";
            btnRemCategoria.UseVisualStyleBackColor = false;
            btnRemCategoria.Click += btnRemCategoria_Click;
            // 
            // CategoriasForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;
            ClientSize = new Size(800, 450);
            Controls.Add(btnRemCategoria);
            Controls.Add(btnAddCategoria);
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

        private Button btnAddCategoria;
        private TextBox txtSearchCategorias;
        private DataGridView dgvCategorias;
        private Button btnRemCategoria;
    }
}