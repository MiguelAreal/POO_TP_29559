﻿namespace poo_tp_29559.Views
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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            dgvItens = new DataGridView();
            txtSearchItem = new TextBox();
            btnConsultarAtualizar = new Label();
            btnRem = new Label();
            btnAdd = new Label();
            lblPesquisa = new Label();
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
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Control;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 11F);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(9, 171, 219);
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvItens.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvItens.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvItens.Cursor = Cursors.IBeam;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = SystemColors.Window;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle5.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(9, 171, 219);
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
            dgvItens.DefaultCellStyle = dataGridViewCellStyle5;
            dgvItens.Location = new Point(17, 96);
            dgvItens.MultiSelect = false;
            dgvItens.Name = "dgvItens";
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = SystemColors.Control;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle6.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(9, 171, 219);
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            dgvItens.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
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
            // 
            // btnConsultarAtualizar
            // 
            btnConsultarAtualizar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnConsultarAtualizar.Cursor = Cursors.Hand;
            btnConsultarAtualizar.FlatStyle = FlatStyle.Flat;
            btnConsultarAtualizar.Font = new Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnConsultarAtualizar.Location = new Point(646, 50);
            btnConsultarAtualizar.Margin = new Padding(0);
            btnConsultarAtualizar.Name = "btnConsultarAtualizar";
            btnConsultarAtualizar.Size = new Size(35, 40);
            btnConsultarAtualizar.TabIndex = 5;
            btnConsultarAtualizar.Text = "📜";
            btnConsultarAtualizar.TextAlign = ContentAlignment.MiddleCenter;
            btnConsultarAtualizar.Visible = false;
            btnConsultarAtualizar.Click += btnConsultarAtualizar_Click;
            btnConsultarAtualizar.MouseEnter += btnSeeVenda_MouseEnter;
            btnConsultarAtualizar.MouseLeave += btnSeeVenda_MouseLeave;
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
            // lblPesquisa
            // 
            lblPesquisa.Cursor = Cursors.Hand;
            lblPesquisa.FlatStyle = FlatStyle.Flat;
            lblPesquisa.Font = new Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPesquisa.Location = new Point(280, 55);
            lblPesquisa.Margin = new Padding(0);
            lblPesquisa.Name = "lblPesquisa";
            lblPesquisa.Size = new Size(40, 35);
            lblPesquisa.TabIndex = 8;
            lblPesquisa.Text = "🔍";
            lblPesquisa.TextAlign = ContentAlignment.MiddleCenter;
            lblPesquisa.Click += lblPesquisa_Click;
            // 
            // ChildForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;
            ClientSize = new Size(800, 450);
            Controls.Add(lblPesquisa);
            Controls.Add(dgvItens);
            Controls.Add(btnAdd);
            Controls.Add(btnRem);
            Controls.Add(btnConsultarAtualizar);
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
        private Label btnConsultarAtualizar;
        private Label btnRem;
        private Label btnAdd;
        private Label lblPesquisa;
    }
}