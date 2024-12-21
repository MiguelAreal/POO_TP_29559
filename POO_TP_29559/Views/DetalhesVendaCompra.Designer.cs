namespace poo_tp_29559.Views
{
    partial class DetalhesVendaCompra
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
            lblDataVenda = new Label();
            lblCliente = new Label();
            lblNIF = new Label();
            lblGarantia = new Label();
            lblDescontos = new Label();
            dgvFatura = new DataGridView();
            IDProduto = new DataGridViewTextBoxColumn();
            Produto = new DataGridViewTextBoxColumn();
            Categoria = new DataGridViewTextBoxColumn();
            Marca = new DataGridViewTextBoxColumn();
            Quantidade = new DataGridViewTextBoxColumn();
            PrecoUni = new DataGridViewTextBoxColumn();
            lblGarantiaStatus = new Label();
            btnConfirmar = new Button();
            btnBack = new Label();
            listViewCampanhas = new ListView();
            Nome = new ColumnHeader();
            CategoriaAplicada = new ColumnHeader();
            Percentagem = new ColumnHeader();
            lblTotalBruto = new Label();
            lblTotalLiquido = new Label();
            lblMesesRestantesGarantia = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvFatura).BeginInit();
            SuspendLayout();
            // 
            // lblDataVenda
            // 
            lblDataVenda.AutoSize = true;
            lblDataVenda.Font = new Font("Montserrat", 10F);
            lblDataVenda.Location = new Point(25, 70);
            lblDataVenda.Name = "lblDataVenda";
            lblDataVenda.Size = new Size(118, 20);
            lblDataVenda.TabIndex = 0;
            lblDataVenda.Text = "Data de Venda :";
            // 
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.Font = new Font("Montserrat", 10F);
            lblCliente.Location = new Point(25, 110);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(65, 20);
            lblCliente.TabIndex = 1;
            lblCliente.Text = "Cliente :";
            // 
            // lblNIF
            // 
            lblNIF.AutoSize = true;
            lblNIF.Font = new Font("Montserrat", 10F);
            lblNIF.Location = new Point(25, 150);
            lblNIF.Name = "lblNIF";
            lblNIF.Size = new Size(40, 20);
            lblNIF.TabIndex = 2;
            lblNIF.Text = "NIF :";
            // 
            // lblGarantia
            // 
            lblGarantia.AutoSize = true;
            lblGarantia.Font = new Font("Montserrat", 10F);
            lblGarantia.Location = new Point(25, 190);
            lblGarantia.Name = "lblGarantia";
            lblGarantia.Size = new Size(75, 20);
            lblGarantia.TabIndex = 3;
            lblGarantia.Text = "Garantia :";
            // 
            // lblDescontos
            // 
            lblDescontos.AutoSize = true;
            lblDescontos.Font = new Font("Montserrat", 10F);
            lblDescontos.Location = new Point(25, 319);
            lblDescontos.Name = "lblDescontos";
            lblDescontos.Size = new Size(167, 20);
            lblDescontos.TabIndex = 4;
            lblDescontos.Text = "Campanhas Utilizadas:";
            // 
            // dgvFatura
            // 
            dgvFatura.AllowUserToAddRows = false;
            dgvFatura.AllowUserToDeleteRows = false;
            dgvFatura.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvFatura.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Montserrat", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvFatura.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvFatura.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFatura.Columns.AddRange(new DataGridViewColumn[] { IDProduto, Produto, Categoria, Marca, Quantidade, PrecoUni });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Montserrat", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(9, 171, 219);
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvFatura.DefaultCellStyle = dataGridViewCellStyle2;
            dgvFatura.GridColor = Color.White;
            dgvFatura.Location = new Point(262, 70);
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
            dgvFatura.Size = new Size(469, 209);
            dgvFatura.TabIndex = 28;
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
            // lblGarantiaStatus
            // 
            lblGarantiaStatus.AutoSize = true;
            lblGarantiaStatus.Font = new Font("Montserrat", 14F);
            lblGarantiaStatus.ForeColor = Color.FromArgb(0, 192, 0);
            lblGarantiaStatus.Location = new Point(93, 187);
            lblGarantiaStatus.Name = "lblGarantiaStatus";
            lblGarantiaStatus.Size = new Size(38, 26);
            lblGarantiaStatus.TabIndex = 29;
            lblGarantiaStatus.Text = "✅";
            // 
            // btnConfirmar
            // 
            btnConfirmar.Cursor = Cursors.Hand;
            btnConfirmar.Font = new Font("Segoe UI", 11F);
            btnConfirmar.Location = new Point(629, 410);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(102, 44);
            btnConfirmar.TabIndex = 47;
            btnConfirmar.Text = "OK";
            btnConfirmar.UseVisualStyleBackColor = true;
            // 
            // btnBack
            // 
            btnBack.AutoSize = true;
            btnBack.Cursor = Cursors.Hand;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Font = new Font("Montserrat", 20F);
            btnBack.ForeColor = Color.FromArgb(9, 171, 219);
            btnBack.Location = new Point(9, 18);
            btnBack.Margin = new Padding(0);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(54, 37);
            btnBack.TabIndex = 48;
            btnBack.Text = "🔙";
            btnBack.Click += btnBack_Click;
            btnBack.MouseEnter += btnBack_MouseEnter;
            btnBack.MouseLeave += btnBack_MouseLeave;
            // 
            // listViewCampanhas
            // 
            listViewCampanhas.Columns.AddRange(new ColumnHeader[] { Nome, CategoriaAplicada, Percentagem });
            listViewCampanhas.FullRowSelect = true;
            listViewCampanhas.HeaderStyle = ColumnHeaderStyle.None;
            listViewCampanhas.Location = new Point(25, 342);
            listViewCampanhas.MultiSelect = false;
            listViewCampanhas.Name = "listViewCampanhas";
            listViewCampanhas.Size = new Size(218, 139);
            listViewCampanhas.TabIndex = 49;
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
            // lblTotalBruto
            // 
            lblTotalBruto.AutoSize = true;
            lblTotalBruto.Font = new Font("Montserrat", 10F);
            lblTotalBruto.Location = new Point(262, 282);
            lblTotalBruto.Name = "lblTotalBruto";
            lblTotalBruto.Size = new Size(91, 20);
            lblTotalBruto.TabIndex = 50;
            lblTotalBruto.Text = "Total Bruto:";
            // 
            // lblTotalLiquido
            // 
            lblTotalLiquido.AutoSize = true;
            lblTotalLiquido.Font = new Font("Montserrat", 10F);
            lblTotalLiquido.Location = new Point(426, 282);
            lblTotalLiquido.Name = "lblTotalLiquido";
            lblTotalLiquido.Size = new Size(102, 20);
            lblTotalLiquido.TabIndex = 51;
            lblTotalLiquido.Text = "Total Líquido:";
            // 
            // lblMesesRestantesGarantia
            // 
            lblMesesRestantesGarantia.AutoSize = true;
            lblMesesRestantesGarantia.Font = new Font("Montserrat", 10F);
            lblMesesRestantesGarantia.Location = new Point(26, 229);
            lblMesesRestantesGarantia.Name = "lblMesesRestantesGarantia";
            lblMesesRestantesGarantia.Size = new Size(144, 20);
            lblMesesRestantesGarantia.TabIndex = 52;
            lblMesesRestantesGarantia.Text = "Estado da Garantia:";
            // 
            // DetalhesVendaCompra
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;
            CancelButton = btnConfirmar;
            ClientSize = new Size(757, 492);
            Controls.Add(dgvFatura);
            Controls.Add(lblMesesRestantesGarantia);
            Controls.Add(lblTotalLiquido);
            Controls.Add(lblTotalBruto);
            Controls.Add(listViewCampanhas);
            Controls.Add(btnConfirmar);
            Controls.Add(lblGarantia);
            Controls.Add(lblGarantiaStatus);
            Controls.Add(lblDescontos);
            Controls.Add(lblNIF);
            Controls.Add(lblCliente);
            Controls.Add(lblDataVenda);
            Controls.Add(btnBack);
            Font = new Font("Montserrat", 10F);
            Name = "DetalhesVendaCompra";
            Padding = new Padding(23, 72, 23, 24);
            Resizable = false;
            Text = "     Detalhes de Venda";
            ((System.ComponentModel.ISupportInitialize)dgvFatura).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblDataVenda;
        private Label lblCliente;
        private Label lblNIF;
        private Label lblGarantia;
        private Label lblDescontos;
        private DataGridView dgvFatura;
        private DataGridViewTextBoxColumn IDProduto;
        private DataGridViewTextBoxColumn Produto;
        private DataGridViewTextBoxColumn Categoria;
        private DataGridViewTextBoxColumn Marca;
        private DataGridViewTextBoxColumn Quantidade;
        private DataGridViewTextBoxColumn PrecoUni;
        private Label lblGarantiaStatus;
        private Button btnConfirmar;
        private Label btnBack;
        private ListView listViewCampanhas;
        private ColumnHeader Nome;
        private ColumnHeader CategoriaAplicada;
        private ColumnHeader Percentagem;
        private Label lblTotalBruto;
        private Label lblTotalLiquido;
        private Label lblMesesRestantesGarantia;
    }
}