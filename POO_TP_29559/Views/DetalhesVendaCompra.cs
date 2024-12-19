using MetroFramework.Forms;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using poo_tp_29559.Models;

namespace poo_tp_29559.Views
{
    /**
     * @class DetalhesVendaCompra
     * @brief Formulário para exibição de detalhes de uma transação de venda ou compra.
     * 
     * A classe `DetalhesVendaCompra` representa uma interface gráfica que exibe os detalhes de uma transação, 
     * incluindo informações sobre o cliente, data da transação, valores, garantia, itens comprados e campanhas aplicadas.
     * Este formulário é implementado utilizando MetroFramework.
     * 
     * @author Miguel Areal
     * @date 12/2024
     */
    public partial class DetalhesVendaCompra : MetroForm
    {
        private UtilizadorController utilizadorController;

        /**
         * @brief Construtor do formulário `DetalhesVendaCompra`.
         * 
         * Este construtor inicializa o formulário com os dados da venda ou compra especificada, configurando
         * os controles para exibir informações detalhadas ao utilizador.
         * 
         * @param titulo Título do formulário a ser exibido na interface.
         * @param venda Instância da classe `VendaCompra` contendo os dados da transação.
         */
        public DetalhesVendaCompra(string titulo, VendaCompra venda)
        {
            InitializeComponent();
            utilizadorController = new UtilizadorController();

            // Configura o título do formulário
            this.Text = "     " + titulo;

            string nomeCliente;
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

        /**
         * @brief Calcula os meses restantes para o fim da garantia.
         * 
         * Este método calcula o tempo restante para a expiração da garantia e exibe o estado da garantia no formulário.
         * 
         * @param venda Instância da classe `VendaCompra` contendo a data do fim da garantia.
         */
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

        /**
        * @brief Evento de cursor a passar por cima do botão de recuar.
        * 
        * Altera a cor do botão.
        * 
         * @param sender O objeto que disparou o evento.
         * @param e Dados do evento.
        */
        private void btnBack_MouseEnter(object sender, EventArgs e)
        {
            btnBack.ForeColor = Color.DodgerBlue;
        }

        /**
       * @brief Evento de cursor a sair de cima do botão de recuar.
       * 
       * Altera a cor do botão.
       * 
        * @param sender O objeto que disparou o evento.
        * @param e Dados do evento.
       */
        private void btnBack_MouseLeave(object sender, EventArgs e)
        {
            btnBack.ForeColor = Color.FromArgb(9, 171, 219);
        }
    }
}
