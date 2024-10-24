namespace poo_tp_29559.Views
{
    partial class MarcasForm
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
            txtSearchMarcas = new TextBox();
            dgvMarcas = new DataGridView();
            btnRemMarca = new Button();
            btnAddProduto = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvMarcas).BeginInit();
            SuspendLayout();
            // 
            // txtSearchMarcas
            // 
            txtSearchMarcas.Font = new Font("Segoe UI", 10F);
            txtSearchMarcas.Location = new Point(20, 67);
            txtSearchMarcas.Name = "txtSearchMarcas";
            txtSearchMarcas.PlaceholderText = "Procurar...";
            txtSearchMarcas.Size = new Size(260, 25);
            txtSearchMarcas.TabIndex = 4;
            // 
            // dgvMarcas
            // 
            dgvMarcas.AllowUserToAddRows = false;
            dgvMarcas.AllowUserToResizeRows = false;
            dgvMarcas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvMarcas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMarcas.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvMarcas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvMarcas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMarcas.Location = new Point(20, 96);
            dgvMarcas.MultiSelect = false;
            dgvMarcas.Name = "dgvMarcas";
            dgvMarcas.RowHeadersVisible = false;
            dgvMarcas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMarcas.Size = new Size(760, 331);
            dgvMarcas.TabIndex = 3;
            dgvMarcas.CellValueChanged += dgvMarcas_CellValueChanged;
            // 
            // btnRemMarca
            // 
            btnRemMarca.Location = new Point(110, 27);
            btnRemMarca.Name = "btnRemMarca";
            btnRemMarca.Size = new Size(43, 23);
            btnRemMarca.TabIndex = 6;
            btnRemMarca.Text = "-";
            btnRemMarca.UseVisualStyleBackColor = true;
            btnRemMarca.Click += btnRemMarca_Click;
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
            btnAddProduto.ForeColor = Color.White;
            btnAddProduto.Location = new Point(726, 48);
            btnAddProduto.Name = "btnAddProduto";
            btnAddProduto.Size = new Size(54, 42);
            btnAddProduto.TabIndex = 7;
            btnAddProduto.Text = "+";
            btnAddProduto.TextAlign = ContentAlignment.TopCenter;
            btnAddProduto.UseVisualStyleBackColor = false;
            btnAddProduto.Click += btnAddProduto_Click;
            // 
            // MarcasForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnAddProduto);
            Controls.Add(btnRemMarca);
            Controls.Add(txtSearchMarcas);
            Controls.Add(dgvMarcas);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MarcasForm";
            Resizable = false;
            ShadowType = MetroFormShadowType.None;
            Text = "Marcas";
            ((System.ComponentModel.ISupportInitialize)dgvMarcas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtSearchMarcas;
        private DataGridView dgvMarcas;
        private Button btnRemMarca;
        private Button btnAddProduto;
    }
}