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
            btnSeeVenda = new Label();
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
            // btnSeeVenda
            // 
            btnSeeVenda.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSeeVenda.Cursor = Cursors.Hand;
            btnSeeVenda.FlatStyle = FlatStyle.Flat;
            btnSeeVenda.Font = new Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSeeVenda.Location = new Point(646, 50);
            btnSeeVenda.Margin = new Padding(0);
            btnSeeVenda.Name = "btnSeeVenda";
            btnSeeVenda.Size = new Size(35, 40);
            btnSeeVenda.TabIndex = 5;
            btnSeeVenda.Text = "📜";
            btnSeeVenda.TextAlign = ContentAlignment.MiddleCenter;
            btnSeeVenda.Visible = false;
            btnSeeVenda.MouseEnter += btnSeeVenda_MouseEnter;
            btnSeeVenda.MouseLeave += btnSeeVenda_MouseLeave;
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
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvItens);
            Controls.Add(btnAdd);
            Controls.Add(btnRem);
            Controls.Add(btnSeeVenda);
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
        private Label btnSeeVenda;
        private Label btnRem;
        private Label btnAdd;
    }
}