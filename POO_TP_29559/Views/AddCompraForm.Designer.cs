namespace poo_tp_29559.Views
{
    partial class AddCompraForm
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
            lblProduto = new Label();
            cmbProdutos = new ComboBox();
            dgvFatura = new DataGridView();
            IDProduto = new DataGridViewTextBoxColumn();
            Produto = new DataGridViewTextBoxColumn();
            Categoria = new DataGridViewTextBoxColumn();
            Marca = new DataGridViewTextBoxColumn();
            Quantidade = new DataGridViewTextBoxColumn();
            PrecoUni = new DataGridViewTextBoxColumn();
            nudQtd = new NumericUpDown();
            lblFatura = new Label();
            cmbMetodoPagamento = new ComboBox();
            label2 = new Label();
            label3 = new Label();
            listViewCampanhas = new ListView();
            Nome = new ColumnHeader();
            CategoriaAplicada = new ColumnHeader();
            Percentagem = new ColumnHeader();
            txtTotalBruto = new TextBox();
            label4 = new Label();
            label5 = new Label();
            txtTotalLiquido = new TextBox();
            btnCancelar = new Button();
            btnConfirmar = new Button();
            lblQtd = new Label();
            txtGarantia = new TextBox();
            label6 = new Label();
            btnRemItem = new Label();
            btnAddProduto = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvFatura).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudQtd).BeginInit();
            SuspendLayout();
            // 
            // lblProduto
            // 
            lblProduto.AutoSize = true;
            lblProduto.Font = new Font("Montserrat", 10F);
            lblProduto.Location = new Point(23, 66);
            lblProduto.Name = "lblProduto";
            lblProduto.Size = new Size(67, 20);
            lblProduto.TabIndex = 24;
            lblProduto.Text = "Produto";
            // 
            // cmbProdutos
            // 
            cmbProdutos.FlatStyle = FlatStyle.System;
            cmbProdutos.Font = new Font("Segoe UI", 10F);
            cmbProdutos.FormattingEnabled = true;
            cmbProdutos.Location = new Point(23, 88);
            cmbProdutos.Name = "cmbProdutos";
            cmbProdutos.Size = new Size(192, 25);
            cmbProdutos.TabIndex = 25;
            // 
            // dgvFatura
            // 
            dgvFatura.AllowUserToAddRows = false;
            dgvFatura.AllowUserToDeleteRows = false;
            dgvFatura.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvFatura.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Montserrat", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvFatura.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvFatura.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFatura.Columns.AddRange(new DataGridViewColumn[] { IDProduto, Produto, Categoria, Marca, Quantidade, PrecoUni });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(9, 171, 219);
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvFatura.DefaultCellStyle = dataGridViewCellStyle2;
            dgvFatura.GridColor = Color.White;
            dgvFatura.Location = new Point(380, 88);
            dgvFatura.MultiSelect = false;
            dgvFatura.Name = "dgvFatura";
            dgvFatura.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvFatura.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvFatura.RowHeadersVisible = false;
            dgvFatura.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            dgvFatura.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFatura.Size = new Size(506, 265);
            dgvFatura.TabIndex = 27;
            dgvFatura.CellEndEdit += dgvFatura_CellEndEdit;
            // 
            // IDProduto
            // 
            IDProduto.HeaderText = "IDProduto";
            IDProduto.Name = "IDProduto";
            IDProduto.ReadOnly = true;
            IDProduto.Visible = false;
            // 
            // Produto
            // 
            Produto.HeaderText = "Produto";
            Produto.Name = "Produto";
            Produto.ReadOnly = true;
            // 
            // Categoria
            // 
            Categoria.HeaderText = "Categoria";
            Categoria.Name = "Categoria";
            Categoria.ReadOnly = true;
            // 
            // Marca
            // 
            Marca.HeaderText = "Marca";
            Marca.Name = "Marca";
            Marca.ReadOnly = true;
            // 
            // Quantidade
            // 
            Quantidade.HeaderText = "Quantidade";
            Quantidade.Name = "Quantidade";
            Quantidade.ReadOnly = true;
            // 
            // PrecoUni
            // 
            PrecoUni.HeaderText = "Preço Uni.";
            PrecoUni.Name = "PrecoUni";
            PrecoUni.ReadOnly = true;
            // 
            // nudQtd
            // 
            nudQtd.Font = new Font("Segoe UI", 10F);
            nudQtd.Location = new Point(221, 87);
            nudQtd.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            nudQtd.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudQtd.Name = "nudQtd";
            nudQtd.Size = new Size(49, 25);
            nudQtd.TabIndex = 30;
            nudQtd.ThousandsSeparator = true;
            nudQtd.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblFatura
            // 
            lblFatura.AutoSize = true;
            lblFatura.Font = new Font("Montserrat", 10F);
            lblFatura.Location = new Point(380, 65);
            lblFatura.Name = "lblFatura";
            lblFatura.Size = new Size(54, 20);
            lblFatura.TabIndex = 33;
            lblFatura.Text = "Fatura";
            // 
            // cmbMetodoPagamento
            // 
            cmbMetodoPagamento.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMetodoPagamento.FlatStyle = FlatStyle.System;
            cmbMetodoPagamento.Font = new Font("Segoe UI", 10F);
            cmbMetodoPagamento.FormattingEnabled = true;
            cmbMetodoPagamento.Location = new Point(22, 166);
            cmbMetodoPagamento.Name = "cmbMetodoPagamento";
            cmbMetodoPagamento.Size = new Size(192, 25);
            cmbMetodoPagamento.TabIndex = 35;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Montserrat", 10F);
            label2.Location = new Point(22, 144);
            label2.Name = "label2";
            label2.Size = new Size(171, 20);
            label2.TabIndex = 34;
            label2.Text = "Método de Pagamento";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Montserrat", 10F);
            label3.Location = new Point(23, 218);
            label3.Name = "label3";
            label3.Size = new Size(163, 20);
            label3.TabIndex = 38;
            label3.Text = "Campanhas Aplicadas";
            // 
            // listViewCampanhas
            // 
            listViewCampanhas.Columns.AddRange(new ColumnHeader[] { Nome, CategoriaAplicada, Percentagem });
            listViewCampanhas.FullRowSelect = true;
            listViewCampanhas.HeaderStyle = ColumnHeaderStyle.None;
            listViewCampanhas.Location = new Point(23, 240);
            listViewCampanhas.MultiSelect = false;
            listViewCampanhas.Name = "listViewCampanhas";
            listViewCampanhas.Size = new Size(246, 139);
            listViewCampanhas.TabIndex = 39;
            listViewCampanhas.UseCompatibleStateImageBehavior = false;
            listViewCampanhas.View = View.Details;
            // 
            // Nome
            // 
            Nome.Text = "Campanha";
            // 
            // CategoriaAplicada
            // 
            CategoriaAplicada.Text = "Categoria";
            CategoriaAplicada.Width = 80;
            // 
            // Percentagem
            // 
            Percentagem.Text = "Desconto";
            // 
            // txtTotalBruto
            // 
            txtTotalBruto.BackColor = Color.White;
            txtTotalBruto.Font = new Font("Segoe UI", 10F);
            txtTotalBruto.Location = new Point(380, 381);
            txtTotalBruto.MaxLength = 9;
            txtTotalBruto.Name = "txtTotalBruto";
            txtTotalBruto.ReadOnly = true;
            txtTotalBruto.Size = new Size(100, 25);
            txtTotalBruto.TabIndex = 41;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Montserrat", 10F);
            label4.Location = new Point(377, 359);
            label4.Name = "label4";
            label4.Size = new Size(91, 20);
            label4.TabIndex = 42;
            label4.Text = "Total Bruto:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Montserrat", 10F);
            label5.Location = new Point(507, 359);
            label5.Name = "label5";
            label5.Size = new Size(102, 20);
            label5.TabIndex = 44;
            label5.Text = "Total Líquido:";
            // 
            // txtTotalLiquido
            // 
            txtTotalLiquido.BackColor = Color.White;
            txtTotalLiquido.Font = new Font("Segoe UI", 10F);
            txtTotalLiquido.Location = new Point(510, 381);
            txtTotalLiquido.MaxLength = 9;
            txtTotalLiquido.Name = "txtTotalLiquido";
            txtTotalLiquido.ReadOnly = true;
            txtTotalLiquido.Size = new Size(100, 25);
            txtTotalLiquido.TabIndex = 43;
            // 
            // btnCancelar
            // 
            btnCancelar.Cursor = Cursors.Hand;
            btnCancelar.Font = new Font("Segoe UI", 11F);
            btnCancelar.Location = new Point(676, 422);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(102, 50);
            btnCancelar.TabIndex = 45;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnConfirmar
            // 
            btnConfirmar.Cursor = Cursors.Hand;
            btnConfirmar.Font = new Font("Segoe UI", 11F);
            btnConfirmar.Location = new Point(784, 422);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(102, 50);
            btnConfirmar.TabIndex = 46;
            btnConfirmar.Text = "Confirmar";
            btnConfirmar.UseVisualStyleBackColor = true;
            btnConfirmar.Click += btnConfirmar_Click;
            // 
            // lblQtd
            // 
            lblQtd.AutoSize = true;
            lblQtd.Font = new Font("Montserrat", 10F);
            lblQtd.Location = new Point(221, 64);
            lblQtd.Name = "lblQtd";
            lblQtd.Size = new Size(39, 20);
            lblQtd.TabIndex = 47;
            lblQtd.Text = "Qtd.";
            // 
            // txtGarantia
            // 
            txtGarantia.BackColor = Color.White;
            txtGarantia.Font = new Font("Segoe UI", 10F);
            txtGarantia.Location = new Point(639, 382);
            txtGarantia.MaxLength = 9;
            txtGarantia.Name = "txtGarantia";
            txtGarantia.ReadOnly = true;
            txtGarantia.Size = new Size(100, 25);
            txtGarantia.TabIndex = 50;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Montserrat", 10F);
            label6.Location = new Point(639, 360);
            label6.Name = "label6";
            label6.Size = new Size(71, 20);
            label6.TabIndex = 49;
            label6.Text = "Garantia:";
            // 
            // btnRemItem
            // 
            btnRemItem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRemItem.Cursor = Cursors.Hand;
            btnRemItem.FlatStyle = FlatStyle.Flat;
            btnRemItem.Font = new Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRemItem.Location = new Point(851, 44);
            btnRemItem.Margin = new Padding(0);
            btnRemItem.Name = "btnRemItem";
            btnRemItem.Size = new Size(35, 40);
            btnRemItem.TabIndex = 51;
            btnRemItem.Text = "🗑️";
            btnRemItem.TextAlign = ContentAlignment.MiddleCenter;
            btnRemItem.Click += btnRemItem_Click_1;
            btnRemItem.MouseEnter += btnRemItem_MouseEnter;
            btnRemItem.MouseLeave += btnRemItem_MouseLeave;
            // 
            // btnAddProduto
            // 
            btnAddProduto.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddProduto.Cursor = Cursors.Hand;
            btnAddProduto.FlatStyle = FlatStyle.Flat;
            btnAddProduto.Font = new Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAddProduto.Location = new Point(280, 77);
            btnAddProduto.Margin = new Padding(0);
            btnAddProduto.Name = "btnAddProduto";
            btnAddProduto.Size = new Size(35, 40);
            btnAddProduto.TabIndex = 52;
            btnAddProduto.Text = "\U0001f6d2";
            btnAddProduto.TextAlign = ContentAlignment.MiddleCenter;
            btnAddProduto.Click += btnAddProduto_Click;
            btnAddProduto.MouseEnter += btnAddProduto_MouseEnter;
            btnAddProduto.MouseLeave += btnAddProduto_MouseLeave;
            // 
            // AddCompraForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;
            CancelButton = btnCancelar;
            ClientSize = new Size(911, 492);
            Controls.Add(btnAddProduto);
            Controls.Add(btnRemItem);
            Controls.Add(txtGarantia);
            Controls.Add(label6);
            Controls.Add(lblQtd);
            Controls.Add(btnCancelar);
            Controls.Add(btnConfirmar);
            Controls.Add(label5);
            Controls.Add(txtTotalLiquido);
            Controls.Add(label4);
            Controls.Add(txtTotalBruto);
            Controls.Add(listViewCampanhas);
            Controls.Add(label3);
            Controls.Add(cmbMetodoPagamento);
            Controls.Add(label2);
            Controls.Add(lblFatura);
            Controls.Add(nudQtd);
            Controls.Add(dgvFatura);
            Controls.Add(cmbProdutos);
            Controls.Add(lblProduto);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddCompraForm";
            Padding = new Padding(0, 60, 0, 0);
            Text = "Efetuar Compra";
            ((System.ComponentModel.ISupportInitialize)dgvFatura).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudQtd).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblProduto;
        private ComboBox cmbProdutos;
        private DataGridView dgvFatura;
        private NumericUpDown nudQtd;
        private Label lblFatura;
        private ComboBox cmbMetodoPagamento;
        private Label label2;
        private Label label3;
        private ListView listViewCampanhas;
        private TextBox txtTotalBruto;
        private Label label4;
        private Label label5;
        private TextBox txtTotalLiquido;
        private Button btnCancelar;
        private Button btnConfirmar;
        private Label lblQtd;
        private ColumnHeader Nome;
        private ColumnHeader CategoriaAplicada;
        private ColumnHeader Percentagem;
        private TextBox txtGarantia;
        private Label label6;
        private DataGridViewTextBoxColumn IDProduto;
        private DataGridViewTextBoxColumn Produto;
        private DataGridViewTextBoxColumn Categoria;
        private DataGridViewTextBoxColumn Marca;
        private DataGridViewTextBoxColumn Quantidade;
        private DataGridViewTextBoxColumn PrecoUni;
        private Label btnRemItem;
        private Label btnAddProduto;
    }
}