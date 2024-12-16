using MetroFramework.Forms;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using poo_tp_29559.Models;

namespace poo_tp_29559.Views
{
    public partial class DetalhesVendaCompra : MetroForm
    {
        private UtilizadorController utilizadorController;

        public DetalhesVendaCompra(string titulo,VendaCompra venda)
        {
            InitializeComponent();
            utilizadorController = new UtilizadorController();

            //Atribui Título
            this.Text = titulo;
            string nomeCliente;

            Utilizador utilizadorVenda = utilizadorController.GetById(venda.ClienteID);

            nomeCliente = utilizadorVenda.Nome ?? "Desconhecido";

            // Preenche os labels com os dados da venda
            lblNIF.Text = $"NIF: {venda.NIF}";
            lblCliente.Text = $"Cliente: {nomeCliente}";
            lblDataVenda.Text = $"Data da Venda: {venda.DataVenda}";
            lblTotalBruto.Text = $"Total Bruto: {venda.TotalBruto:C}";
            lblTotalLiquido.Text = $"Total Líquido: {venda.TotalLiquido:C}";

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

            // Exibe campanhas aplicadas (se houver)
            listViewCampanhas.Items.Clear();
            foreach (var item in venda.Itens)
            {
                if (item.PercentagemDesc.HasValue && item.PercentagemDesc > 0)
                {
                    var campanhaItem = new ListViewItem(new[]
                    {
                        item.ProdutoNome,
                        item.CategoriaNome,
                        $"{item.PercentagemDesc}%"
                    });
                    listViewCampanhas.Items.Add(campanhaItem);
                }
            }
        }
        public void CalculaMesesRestantesGarantia(VendaCompra venda)
        {
            // Calcula meses restantes da garantia
            if (DateTime.TryParse(venda.FimDataGarantia, out var garantiaData))
            {
                var mesesRestantes = ((garantiaData.Year - DateTime.Now.Year) * 12) + garantiaData.Month - DateTime.Now.Month;

                if (mesesRestantes > 0)
                {
                    // Garantia ainda válida
                    lblMesesRestantesGarantia.Text = $"Estado da Garantia:\nAinda tem {mesesRestantes} meses";
                    lblGarantiaStatus.Text = "✅";
                    lblGarantiaStatus.ForeColor = Color.Green;
                }
                else if (mesesRestantes == 0)
                {
                    // Garantia termina neste mês
                    lblMesesRestantesGarantia.Text = "Estado da Garantia:\nA garantia termina este mês";
                    lblGarantiaStatus.Text = "✅";
                    lblGarantiaStatus.ForeColor = Color.Green;
                }
                else
                {
                    // Garantia expirada
                    lblMesesRestantesGarantia.Text = $"Estado da Garantia:\nTerminou há {-mesesRestantes} meses";
                    lblGarantiaStatus.Text = "❌";
                    lblGarantiaStatus.ForeColor = Color.Red;
                }
            }
            else
            {
                // Caso a data da garantia seja inválida
                lblMesesRestantesGarantia.Text = "Estado da Garantia:\nData inválida";
                lblGarantiaStatus.Text = "❌";
                lblGarantiaStatus.ForeColor = Color.Red;
            }
        }



        private void btnBack_MouseEnter(object sender, EventArgs e)
        {
            btnBack.ForeColor = Color.DodgerBlue;
        }

        private void btnBack_MouseLeave(object sender, EventArgs e)
        {
            btnBack.ForeColor = Color.FromArgb(9, 171, 219);
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            this.Close(); // Fecha o formulário
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
