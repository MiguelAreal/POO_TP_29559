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
            btnAddMarca = new Button();
            btnRemMarca2 = new Button();
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
            btnAddMarca.TabIndex = 7;
            btnAddMarca.Text = "➕";
            btnAddMarca.UseVisualStyleBackColor = false;
            btnAddMarca.Click += btnAddProduto_Click;
            // 
            // btnRemMarca2
            // 
            btnRemMarca2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRemMarca2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnRemMarca2.BackColor = Color.Crimson;
            btnRemMarca2.BackgroundImageLayout = ImageLayout.Zoom;
            btnRemMarca2.Cursor = Cursors.Hand;
            btnRemMarca2.FlatAppearance.BorderSize = 0;
            btnRemMarca2.FlatStyle = FlatStyle.Flat;
            btnRemMarca2.Font = new Font("Segoe UI", 13F);
            btnRemMarca2.ForeColor = Color.White;
            btnRemMarca2.Location = new Point(659, 48);
            btnRemMarca2.Name = "btnRemMarca2";
            btnRemMarca2.Size = new Size(54, 42);
            btnRemMarca2.TabIndex = 8;
            btnRemMarca2.Text = "❌";
            btnRemMarca2.UseVisualStyleBackColor = false;
            btnRemMarca2.Click += btnRemMarca_Click;
            // 
            // MarcasForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnRemMarca2);
            Controls.Add(btnAddMarca);
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
        private Button btnAddMarca;
        private Button btnRemMarca2;
    }
}