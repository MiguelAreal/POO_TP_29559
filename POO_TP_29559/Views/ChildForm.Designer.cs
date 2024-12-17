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
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            dgvItens = new DataGridView();
            txtSearchItem = new TextBox();
            btnSeeMovimento = new Label();
            btnRem = new Label();
            btnAdd = new Label();
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
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = SystemColors.Control;
            dataGridViewCellStyle7.Font = new Font("Segoe UI", 11F);
            dataGridViewCellStyle7.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = Color.FromArgb(9, 171, 219);
            dataGridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
            dgvItens.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dgvItens.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvItens.Cursor = Cursors.IBeam;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = SystemColors.Window;
            dataGridViewCellStyle8.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle8.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = Color.FromArgb(9, 171, 219);
            dataGridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.False;
            dgvItens.DefaultCellStyle = dataGridViewCellStyle8;
            dgvItens.Location = new Point(17, 96);
            dgvItens.MultiSelect = false;
            dgvItens.Name = "dgvItens";
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = SystemColors.Control;
            dataGridViewCellStyle9.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle9.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = Color.FromArgb(9, 171, 219);
            dataGridViewCellStyle9.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = DataGridViewTriState.True;
            dgvItens.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            dgvItens.RowHeadersVisible = false;
            dgvItens.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvItens.Size = new Size(760, 331);
            dgvItens.TabIndex = 3;
            dgvItens.CellValueChanged += dgvItens_CellValueChanged;
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
            // btnSeeMovimento
            // 
            btnSeeMovimento.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSeeMovimento.Cursor = Cursors.Hand;
            btnSeeMovimento.FlatStyle = FlatStyle.Flat;
            btnSeeMovimento.Font = new Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSeeMovimento.Location = new Point(646, 50);
            btnSeeMovimento.Margin = new Padding(0);
            btnSeeMovimento.Name = "btnSeeMovimento";
            btnSeeMovimento.Size = new Size(35, 40);
            btnSeeMovimento.TabIndex = 5;
            btnSeeMovimento.Text = "📜";
            btnSeeMovimento.TextAlign = ContentAlignment.MiddleCenter;
            btnSeeMovimento.Visible = false;
            btnSeeMovimento.Click += btnSeeMovimento_Click;
            btnSeeMovimento.MouseEnter += btnSeeVenda_MouseEnter;
            btnSeeMovimento.MouseLeave += btnSeeVenda_MouseLeave;
            // 
            // btnRem
            // 
            btnRem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRem.Cursor = Cursors.Hand;
            btnRem.FlatStyle = FlatStyle.Flat;
            btnRem.Font = new Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRem.Location = new Point(696, 50);
            btnRem.Margin = new Padding(0);
            btnRem.Name = "btnRem";
            btnRem.Size = new Size(35, 40);
            btnRem.TabIndex = 6;
            btnRem.Text = "🗑️";
            btnRem.TextAlign = ContentAlignment.MiddleCenter;
            btnRem.Click += btnRem_Click;
            btnRem.MouseEnter += btnRem_MouseEnter;
            btnRem.MouseLeave += btnRem_MouseLeave;
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAdd.Location = new Point(744, 50);
            btnAdd.Margin = new Padding(0);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(35, 40);
            btnAdd.TabIndex = 7;
            btnAdd.Text = "🆕";
            btnAdd.TextAlign = ContentAlignment.MiddleCenter;
            btnAdd.Click += btnAdd_Click;
            btnAdd.MouseEnter += btnAdd_MouseEnter;
            btnAdd.MouseLeave += btnAdd_MouseLeave;
            // 
            // ChildForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvItens);
            Controls.Add(btnAdd);
            Controls.Add(btnRem);
            Controls.Add(btnSeeMovimento);
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
        private Label btnSeeMovimento;
        private Label btnRem;
        private Label btnAdd;
    }
}