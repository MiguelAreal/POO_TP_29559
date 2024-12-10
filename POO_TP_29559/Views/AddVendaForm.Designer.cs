namespace poo_tp_29559.Views
{
    partial class AddVendaForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddVendaForm));
            lblProduto = new Label();
            cmbProdutos = new ComboBox();
            dgvFatura = new DataGridView();
            IDProduto = new DataGridViewTextBoxColumn();
            Produto = new DataGridViewTextBoxColumn();
            Categoria = new DataGridViewTextBoxColumn();
            Marca = new DataGridViewTextBoxColumn();
            Quantidade = new DataGridViewTextBoxColumn();
            PrecoUni = new DataGridViewTextBoxColumn();
            cmbClientes = new ComboBox();
            lblCliente = new Label();
            nudQtd = new NumericUpDown();
            btnAddProduto = new Button();
            btnAddCliente = new Button();
            label1 = new Label();
            cmbMetodoPagamento = new ComboBox();
            label2 = new Label();
            lblNIF = new Label();
            txtNIF = new TextBox();
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
            btnRemItem = new Button();
            txtGarantia = new TextBox();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvFatura).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudQtd).BeginInit();
            SuspendLayout();
            // 
            // lblProduto
            // 
            lblProduto.AutoSize = true;
            lblProduto.Font = new Font("Segoe UI", 10F);
            lblProduto.Location = new Point(23, 66);
            lblProduto.Name = "lblProduto";
            lblProduto.Size = new Size(59, 19);
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
            dgvFatura.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 11F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(9, 171, 219);
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvFatura.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvFatura.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFatura.Columns.AddRange(new DataGridViewColumn[] { IDProduto, Produto, Categoria, Marca, Quantidade, PrecoUni });
            dgvFatura.GridColor = Color.White;
            dgvFatura.Location = new Point(380, 88);
            dgvFatura.MultiSelect = false;
            dgvFatura.Name = "dgvFatura";
            dgvFatura.ReadOnly = true;
            dgvFatura.RowHeadersVisible = false;
            dgvFatura.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
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
            // cmbClientes
            // 
            cmbClientes.FlatStyle = FlatStyle.System;
            cmbClientes.Font = new Font("Segoe UI", 10F);
            cmbClientes.FormattingEnabled = true;
            cmbClientes.Location = new Point(23, 149);
            cmbClientes.Name = "cmbClientes";
            cmbClientes.Size = new Size(192, 25);
            cmbClientes.TabIndex = 29;
            cmbClientes.SelectedIndexChanged += cmbClientes_SelectedIndexChanged;
            // 
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.Font = new Font("Segoe UI", 10F);
            lblCliente.Location = new Point(23, 127);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(51, 19);
            lblCliente.TabIndex = 28;
            lblCliente.Text = "Cliente";
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
            // btnAddProduto
            // 
            btnAddProduto.Anchor = AnchorStyles.None;
            btnAddProduto.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnAddProduto.BackColor = Color.Transparent;
            btnAddProduto.BackgroundImageLayout = ImageLayout.Zoom;
            btnAddProduto.Cursor = Cursors.Hand;
            btnAddProduto.FlatAppearance.BorderSize = 0;
            btnAddProduto.FlatStyle = FlatStyle.Flat;
            btnAddProduto.Font = new Font("Segoe UI", 20F);
            btnAddProduto.ForeColor = Color.Black;
            btnAddProduto.Location = new Point(275, 75);
            btnAddProduto.Margin = new Padding(0);
            btnAddProduto.Name = "btnAddProduto";
            btnAddProduto.Size = new Size(37, 42);
            btnAddProduto.TabIndex = 31;
            btnAddProduto.Text = "\U0001f6d2";
            btnAddProduto.TextAlign = ContentAlignment.TopCenter;
            btnAddProduto.TextImageRelation = TextImageRelation.ImageAboveText;
            btnAddProduto.UseVisualStyleBackColor = false;
            btnAddProduto.Click += btnAddProduto_Click;
            // 
            // btnAddCliente
            // 
            btnAddCliente.Anchor = AnchorStyles.None;
            btnAddCliente.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnAddCliente.BackColor = Color.Transparent;
            btnAddCliente.BackgroundImageLayout = ImageLayout.Zoom;
            btnAddCliente.Cursor = Cursors.Hand;
            btnAddCliente.FlatAppearance.BorderSize = 0;
            btnAddCliente.FlatStyle = FlatStyle.Flat;
            btnAddCliente.Font = new Font("Segoe UI", 20F);
            btnAddCliente.ForeColor = Color.Black;
            btnAddCliente.Location = new Point(220, 138);
            btnAddCliente.Margin = new Padding(0);
            btnAddCliente.Name = "btnAddCliente";
            btnAddCliente.Size = new Size(37, 42);
            btnAddCliente.TabIndex = 32;
            btnAddCliente.Text = "🆕";
            btnAddCliente.TextAlign = ContentAlignment.TopCenter;
            btnAddCliente.TextImageRelation = TextImageRelation.ImageAboveText;
            btnAddCliente.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F);
            label1.Location = new Point(380, 65);
            label1.Name = "label1";
            label1.Size = new Size(48, 19);
            label1.TabIndex = 33;
            label1.Text = "Fatura";
            // 
            // cmbMetodoPagamento
            // 
            cmbMetodoPagamento.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMetodoPagamento.FlatStyle = FlatStyle.System;
            cmbMetodoPagamento.Font = new Font("Segoe UI", 10F);
            cmbMetodoPagamento.FormattingEnabled = true;
            cmbMetodoPagamento.Location = new Point(23, 282);
            cmbMetodoPagamento.Name = "cmbMetodoPagamento";
            cmbMetodoPagamento.Size = new Size(192, 25);
            cmbMetodoPagamento.TabIndex = 35;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F);
            label2.Location = new Point(23, 260);
            label2.Name = "label2";
            label2.Size = new Size(151, 19);
            label2.TabIndex = 34;
            label2.Text = "Método de Pagamento";
            // 
            // lblNIF
            // 
            lblNIF.AutoSize = true;
            lblNIF.Font = new Font("Segoe UI", 10F);
            lblNIF.Location = new Point(23, 191);
            lblNIF.Name = "lblNIF";
            lblNIF.Size = new Size(30, 19);
            lblNIF.TabIndex = 36;
            lblNIF.Text = "NIF";
            // 
            // txtNIF
            // 
            txtNIF.Font = new Font("Segoe UI", 10F);
            txtNIF.Location = new Point(23, 213);
            txtNIF.MaxLength = 9;
            txtNIF.Name = "txtNIF";
            txtNIF.Size = new Size(192, 25);
            txtNIF.TabIndex = 37;
            txtNIF.TextChanged += txtNIF_TextChanged;
            txtNIF.Leave += txtNIF_Leave;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F);
            label3.Location = new Point(24, 334);
            label3.Name = "label3";
            label3.Size = new Size(142, 19);
            label3.TabIndex = 38;
            label3.Text = "Campanhas Aplicadas";
            // 
            // listViewCampanhas
            // 
            listViewCampanhas.Columns.AddRange(new ColumnHeader[] { Nome, CategoriaAplicada, Percentagem });
            listViewCampanhas.FullRowSelect = true;
            listViewCampanhas.HeaderStyle = ColumnHeaderStyle.None;
            listViewCampanhas.Location = new Point(24, 356);
            listViewCampanhas.Name = "listViewCampanhas";
            listViewCampanhas.Size = new Size(226, 139);
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
            label4.Font = new Font("Segoe UI", 10F);
            label4.Location = new Point(377, 359);
            label4.Name = "label4";
            label4.Size = new Size(79, 19);
            label4.TabIndex = 42;
            label4.Text = "Total Bruto:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F);
            label5.Location = new Point(507, 359);
            label5.Name = "label5";
            label5.Size = new Size(90, 19);
            label5.TabIndex = 44;
            label5.Text = "Total Líquido:";
            // 
            // txtTotalLiquido
            // 
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
            btnCancelar.Location = new Point(679, 451);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(102, 44);
            btnCancelar.TabIndex = 45;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnConfirmar
            // 
            btnConfirmar.Cursor = Cursors.Hand;
            btnConfirmar.Font = new Font("Segoe UI", 11F);
            btnConfirmar.Location = new Point(787, 451);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(102, 44);
            btnConfirmar.TabIndex = 46;
            btnConfirmar.Text = "Confirmar";
            btnConfirmar.UseVisualStyleBackColor = true;
            // 
            // lblQtd
            // 
            lblQtd.AutoSize = true;
            lblQtd.Font = new Font("Segoe UI", 10F);
            lblQtd.Location = new Point(221, 64);
            lblQtd.Name = "lblQtd";
            lblQtd.Size = new Size(36, 19);
            lblQtd.TabIndex = 47;
            lblQtd.Text = "Qtd.";
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
            btnRemItem.Location = new Point(850, 365);
            btnRemItem.Name = "btnRemItem";
            btnRemItem.Padding = new Padding(2, 0, 0, 0);
            btnRemItem.Size = new Size(36, 42);
            btnRemItem.TabIndex = 48;
            btnRemItem.Text = "🗑️";
            btnRemItem.UseVisualStyleBackColor = false;
            btnRemItem.Click += btnRemItem_Click;
            // 
            // txtGarantia
            // 
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
            label6.Font = new Font("Segoe UI", 10F);
            label6.Location = new Point(639, 360);
            label6.Name = "label6";
            label6.Size = new Size(61, 19);
            label6.TabIndex = 49;
            label6.Text = "Garantia";
            // 
            // AddVendaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;
            CancelButton = btnCancelar;
            ClientSize = new Size(911, 529);
            Controls.Add(txtGarantia);
            Controls.Add(label6);
            Controls.Add(btnRemItem);
            Controls.Add(lblQtd);
            Controls.Add(btnCancelar);
            Controls.Add(btnConfirmar);
            Controls.Add(label5);
            Controls.Add(txtTotalLiquido);
            Controls.Add(label4);
            Controls.Add(txtTotalBruto);
            Controls.Add(listViewCampanhas);
            Controls.Add(label3);
            Controls.Add(txtNIF);
            Controls.Add(lblNIF);
            Controls.Add(cmbMetodoPagamento);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnAddCliente);
            Controls.Add(btnAddProduto);
            Controls.Add(nudQtd);
            Controls.Add(cmbClientes);
            Controls.Add(lblCliente);
            Controls.Add(dgvFatura);
            Controls.Add(cmbProdutos);
            Controls.Add(lblProduto);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddVendaForm";
            Padding = new Padding(0, 60, 0, 0);
            Text = "Efetuar Venda";
            ((System.ComponentModel.ISupportInitialize)dgvFatura).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudQtd).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblProduto;
        private ComboBox cmbProdutos;
        private DataGridView dgvFatura;
        private ComboBox cmbClientes;
        private Label lblCliente;
        private NumericUpDown nudQtd;
        private Button btnAddProduto;
        private Button btnAddCliente;
        private Label label1;
        private ComboBox cmbMetodoPagamento;
        private Label label2;
        private Label lblNIF;
        private TextBox txtNIF;
        private Label label3;
        private ListView listViewCampanhas;
        private TextBox txtTotalBruto;
        private Label label4;
        private Label label5;
        private TextBox txtTotalLiquido;
        private Button btnCancelar;
        private Button btnConfirmar;
        private Label lblQtd;
        private Button btnRemItem;
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
    }
}