namespace poo_tp_29559.Views
{
    partial class VendasForm
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
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            dgvVendas = new DataGridView();
            btnAddProduto = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvVendas).BeginInit();
            SuspendLayout();
            // 
            // dgvVendas
            // 
            dgvVendas.AllowUserToAddRows = false;
            dgvVendas.AllowUserToResizeRows = false;
            dgvVendas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvVendas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVendas.BackgroundColor = Color.White;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = SystemColors.Control;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle5.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dgvVendas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dgvVendas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVendas.Cursor = Cursors.IBeam;
            dgvVendas.Location = new Point(20, 96);
            dgvVendas.MultiSelect = false;
            dgvVendas.Name = "dgvVendas";
            dgvVendas.RowHeadersVisible = false;
            dgvVendas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVendas.Size = new Size(760, 331);
            dgvVendas.TabIndex = 4;
            // 
            // btnAddProduto
            // 
            btnAddProduto.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddProduto.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnAddProduto.BackColor = Color.FromArgb(13, 170, 220);
            btnAddProduto.Cursor = Cursors.Hand;
            btnAddProduto.FlatAppearance.BorderSize = 0;
            btnAddProduto.FlatStyle = FlatStyle.Flat;
            btnAddProduto.Font = new Font("Segoe UI", 16F);
            btnAddProduto.ForeColor = Color.White;
            btnAddProduto.Location = new Point(726, 48);
            btnAddProduto.Name = "btnAddProduto";
            btnAddProduto.Size = new Size(54, 42);
            btnAddProduto.TabIndex = 5;
            btnAddProduto.Text = "\U0001f6d2";
            btnAddProduto.TextAlign = ContentAlignment.TopCenter;
            btnAddProduto.UseVisualStyleBackColor = false;
            // 
            // VendasForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;
            ClientSize = new Size(800, 450);
            Controls.Add(btnAddProduto);
            Controls.Add(dgvVendas);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "VendasForm";
            Resizable = false;
            ShadowType = MetroFormShadowType.None;
            Text = "Vendas";
            ((System.ComponentModel.ISupportInitialize)dgvVendas).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvVendas;
        private Button btnAddProduto;
    }
}