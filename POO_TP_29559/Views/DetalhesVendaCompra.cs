using MetroFramework.Forms;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using poo_tp_29559.Models;
using poo_tp_29559.Repositories.Enumerators;

namespace poo_tp_29559.Views
{
    /// <summary>
    /// Formulário para exibição de detalhes de uma transação de venda ou compra.
    /// </summary>
    public partial class DetalhesVendaCompra : MetroForm
    {
        #region Private Fields

        private UtilizadorController utilizadorController;
        private VendaCompraController _controller;
        private string nomeCliente;

        #endregion

        #region Construtors

        /// <summary>
        /// Construtor do formulário `DetalhesVendaCompra`.
        /// </summary>
        /// <param name="formType">Tipo de formulário (Venda ou Compra).</param>
        /// <param name="id">Identificador da transação de venda ou compra.</param>
        public DetalhesVendaCompra(FormTypes formType, int id)
        {
            InitializeComponent();
            utilizadorController = new UtilizadorController();
            _controller = new VendaCompraController();

            // Configura o título do formulário
            if (formType == FormTypes.Compras)
            {
                this.Text = "     " + "Detalhe de Compra";
            }
            else
            {
                this.Text = "     " + "Detalhe de Venda";
            }

            VendaCompra venda = (VendaCompra)_controller.GetById(id);
            Utilizador utilizadorVenda = new Utilizador();

            // Obtém o nome do cliente associado à venda
            if (venda.ClienteID != null)
            {
                utilizadorVenda = (Utilizador)utilizadorController.GetById(venda.ClienteID ?? 0);
            }
            nomeCliente = utilizadorVenda.Nome ?? "Desconhecido";

            // Preenche os labels com os dados da venda
            lblNIF.Text = $"NIF: {venda.NIF}";
            lblCliente.Text = $"Cliente: {nomeCliente}";
            lblDataVenda.Text = $"Data da Venda: {venda.DataVenda}";
            lblTotalBruto.Text = $"Total Bruto: {venda.TotalBruto:C}";
            lblTotalLiquido.Text = $"Total Líquido: {venda.TotalLiquido:C}";

            // Calcula os meses restantes da garantia
            CalculaMesesRestantesGarantia(venda);

            // Preenche a lista de itens na fatura
            foreach (var item in venda.Itens)
            {
                dgvFatura.Rows.Add(
                    item.ProdutoID,
                    item.ProdutoNome,
                    item.CategoriaNome,
                    item.MarcaNome,
                    item.Unidades,
                    item.PrecoUnitario.ToString("C"));
            }

            // Exibe campanhas aplicadas
            listViewCampanhas.Items.Clear();
            foreach (var item in venda.Itens)
            {
                if (item.PercentagemDesc.HasValue && item.PercentagemDesc > 0)
                {
                    var campanhaItem = new ListViewItem(new[] {
                        item.ProdutoNome,
                        item.CategoriaNome,
                        $"{item.PercentagemDesc}%"
                    });
                    listViewCampanhas.Items.Add(campanhaItem);
                }
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Calcula os meses restantes para o fim da garantia.
        /// </summary>
        /// <param name="venda">Instância da classe `VendaCompra` contendo a data do fim da garantia.</param>
        public void CalculaMesesRestantesGarantia(VendaCompra venda)
        {
            if (DateTime.TryParse(venda.FimDataGarantia, out var garantiaData))
            {
                var mesesRestantes = ((garantiaData.Year - DateTime.Now.Year) * 12) + garantiaData.Month - DateTime.Now.Month;

                if (mesesRestantes > 0)
                {
                    lblMesesRestantesGarantia.Text = $"Estado da Garantia:\nAinda tem {mesesRestantes} meses";
                    lblGarantiaStatus.Text = "✅";
                    lblGarantiaStatus.ForeColor = Color.Green;
                }
                else if (mesesRestantes == 0)
                {
                    lblMesesRestantesGarantia.Text = "Estado da Garantia:\nA garantia termina este mês";
                    lblGarantiaStatus.Text = "✅";
                    lblGarantiaStatus.ForeColor = Color.Green;
                }
                else
                {
                    lblMesesRestantesGarantia.Text = $"Estado da Garantia:\nTerminou há {-mesesRestantes} meses";
                    lblGarantiaStatus.Text = "❌";
                    lblGarantiaStatus.ForeColor = Color.Red;
                }
            }
            else
            {
                lblMesesRestantesGarantia.Text = "Estado da Garantia:\nData inválida";
                lblGarantiaStatus.Text = "❌";
                lblGarantiaStatus.ForeColor = Color.Red;
            }
        }

        #endregion

        #region Form Events

        /// <summary>
        /// Evento de cursor a passar por cima do botão de recuar.
        /// </summary>
        /// <param name="sender">O objeto que disparou o evento.</param>
        /// <param name="e">Dados do evento.</param>
        private void btnBack_MouseEnter(object sender, EventArgs e)
        {
            btnBack.ForeColor = Color.DodgerBlue;
        }

        /// <summary>
        /// Evento de cursor a sair de cima do botão de recuar.
        /// </summary>
        /// <param name="sender">O objeto que disparou o evento.</param>
        /// <param name="e">Dados do evento.</param>
        private void btnBack_MouseLeave(object sender, EventArgs e)
        {
            btnBack.ForeColor = Color.FromArgb(9, 171, 219);
        }

        /// <summary>
        /// Evento de clique no botão de voltar.
        /// </summary>
        /// <param name="sender">O objeto que disparou o evento.</param>
        /// <param name="e">Dados do evento.</param>
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}
