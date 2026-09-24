using System;
using System.Windows.Forms;

namespace GerenciadorProdutos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            cmbTipo.SelectedIndex = 0; // Inicia com o primeiro item selecionado
        }

        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Altera o rótulo do campo específico de acordo com a seleção
            if (cmbTipo.SelectedItem.ToString() == "Físico")
            {
                lblAtributo.Text = "Peso (Kg):";
            }
            else
            {
                lblAtributo.Text = "Tamanho (MB):";
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                string nome = txtNome.Text;
                decimal precoBase = Convert.ToDecimal(txtPrecoBase.Text);
                double atributo = Convert.ToDouble(txtAtributoEspecifico.Text);
                string tipo = cmbTipo.SelectedItem.ToString();

                Produto produto = null;

                // Instanciação e polimorfismo dependendo do tipo selecionado
                if (tipo == "Físico")
                {
                    produto = new ProdutoFisico(nome, precoBase, atributo);
                }
                else
                {
                    produto = new ProdutoDigital(nome, precoBase, atributo);
                }

                // Uso do DAO para persistência física no banco de dados
                ProdutoDAO dao = new ProdutoDAO();
                dao.Inserir(produto);

                MessageBox.Show("Produto cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimparCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimparCampos()
        {
            txtNome.Clear();
            txtPrecoBase.Clear();
            txtAtributoEspecifico.Clear();
            cmbTipo.SelectedIndex = 0;
            txtNome.Focus();
        }
    }
}