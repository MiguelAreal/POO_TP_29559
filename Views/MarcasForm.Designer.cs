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
            txtSearchMarcas = new TextBox();
            dgvMarcas = new DataGridView();
            btnRemMarca = new Button();
            btnAddMarca = new Button();
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
            dgvMarcas.AllowUserToResizeRows = false;
            dgvMarcas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvMarcas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMarcas.BackgroundColor = Color.White;
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
            btnRemMarca.Location = new Point(163, 28);
            btnRemMarca.Name = "btnRemMarca";
            btnRemMarca.Size = new Size(43, 23);
            btnRemMarca.TabIndex = 6;
            btnRemMarca.Text = "-";
            btnRemMarca.UseVisualStyleBackColor = true;
            btnRemMarca.Click += btnRemMarca_Click;
            // 
            // btnAddMarca
            // 
            btnAddMarca.Location = new Point(114, 28);
            btnAddMarca.Name = "btnAddMarca";
            btnAddMarca.Size = new Size(43, 23);
            btnAddMarca.TabIndex = 5;
            btnAddMarca.Text = "+";
            btnAddMarca.UseVisualStyleBackColor = true;
            btnAddMarca.Click += btnAddMarca_Click;
            // 
            // MarcasForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnRemMarca);
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

            SetStyle(ControlStyles.OptimizedDoubleBuffer, true); // Otimiza ainda mais a suavidade
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);  // Evita repaint redundante
            UpdateStyles();
        }

        #endregion

        private TextBox txtSearchMarcas;
        private DataGridView dgvMarcas;
        private Button btnRemMarca;
        private Button btnAddMarca;
    }
}