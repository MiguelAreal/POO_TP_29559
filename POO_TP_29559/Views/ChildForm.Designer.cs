namespace poo_tp_29559.Views
{
    partial class ChildForm
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            dgvItens = new DataGridView();
            txtSearchItem = new TextBox();
            btnRemItem = new Button();
            btnAddItem = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvItens).BeginInit();
            SuspendLayout();
            // 
            // dgvItens
            // 
            dgvItens.AllowUserToAddRows = false;
            dgvItens.AllowUserToResizeRows = false;
            dgvItens.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvItens.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvItens.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 11F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(9, 171, 219);
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvItens.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvItens.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvItens.Cursor = Cursors.IBeam;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(9, 171, 219);
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvItens.DefaultCellStyle = dataGridViewCellStyle2;
            dgvItens.Location = new Point(17, 96);
            dgvItens.MultiSelect = false;
            dgvItens.Name = "dgvItens";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(9, 171, 219);
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvItens.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvItens.RowHeadersVisible = false;
            dgvItens.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvItens.Size = new Size(760, 331);
            dgvItens.TabIndex = 3;
            dgvItens.CurrentCellChanged += dgvItens_CurrentCellChanged;
            // 
            // txtSearchItem
            // 
            txtSearchItem.Font = new Font("Segoe UI", 10F);
            txtSearchItem.Location = new Point(17, 63);
            txtSearchItem.Name = "txtSearchItem";
            txtSearchItem.PlaceholderText = "Procurar...";
            txtSearchItem.Size = new Size(260, 25);
            txtSearchItem.TabIndex = 0;
            txtSearchItem.TextChanged += txtSearchItem_TextChanged;
            // 
            // btnRemItem
            // 
            btnRemItem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRemItem.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnRemItem.BackColor = Color.Transparent;
            btnRemItem.BackgroundImageLayout = ImageLayout.Zoom;
            btnRemItem.Cursor = Cursors.Hand;
            btnRemItem.FlatAppearance.BorderSize = 0;
            btnRemItem.FlatStyle = FlatStyle.Flat;
            btnRemItem.Font = new Font("Segoe UI", 20F);
            btnRemItem.ForeColor = Color.Black;
            btnRemItem.Location = new Point(691, 51);
            btnRemItem.Name = "btnRemItem";
            btnRemItem.Padding = new Padding(2, 0, 0, 0);
            btnRemItem.Size = new Size(36, 42);
            btnRemItem.TabIndex = 1;
            btnRemItem.Text = "🗑️";
            btnRemItem.UseVisualStyleBackColor = false;
            btnRemItem.Click += btnRemItem_Click;
            btnRemItem.MouseEnter += btnRemItem_MouseEnter;
            btnRemItem.MouseLeave += btnRemItem_MouseLeave;
            // 
            // btnAddItem
            // 
            btnAddItem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddItem.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnAddItem.BackColor = Color.Transparent;
            btnAddItem.BackgroundImageLayout = ImageLayout.Zoom;
            btnAddItem.Cursor = Cursors.Hand;
            btnAddItem.FlatAppearance.BorderSize = 0;
            btnAddItem.FlatStyle = FlatStyle.Flat;
            btnAddItem.Font = new Font("Segoe UI", 20F);
            btnAddItem.ForeColor = Color.Black;
            btnAddItem.Location = new Point(737, 51);
            btnAddItem.Name = "btnAddItem";
            btnAddItem.Size = new Size(40, 42);
            btnAddItem.TabIndex = 2;
            btnAddItem.Text = "🆕";
            btnAddItem.UseVisualStyleBackColor = false;
            btnAddItem.Click += btnAddItem_Click;
            btnAddItem.MouseEnter += btnAddItem_MouseEnter;
            btnAddItem.MouseLeave += btnAddItem_MouseLeave;
            // 
            // ChildForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvItens);
            Controls.Add(btnAddItem);
            Controls.Add(btnRemItem);
            Controls.Add(txtSearchItem);
            MaximizeBox = false;
            MinimizeBox = false;
            Movable = false;
            Name = "ChildForm";
            Resizable = false;
            ShadowType = MetroFormShadowType.None;
            Text = "ChildForm";
            ((System.ComponentModel.ISupportInitialize)dgvItens).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvItens;
        private TextBox txtSearchItem;
        private Button btnRemItem;
        private Button btnAddItem;
    }
}