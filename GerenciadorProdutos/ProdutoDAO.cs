using MySql.Data.MySqlClient;
using System;

namespace GerenciadorProdutos
{
    public class ProdutoDAO
    {
        public void Inserir(Produto produto)
        {
            string tipo = "";
            double atributo = 0;

            if (produto is ProdutoFisico fisico)
            {
                tipo = "Físico";
                atributo = fisico.PesoKg;
            }
            else if (produto is ProdutoDigital digital)
            {
                tipo = "Digital";
                atributo = digital.TamanhoMb;
            }

            // Conversão de decimais para o formato aceito pelo MySQL (substituindo vírgula por ponto)
            string precoBaseSql = produto.PrecoBase.ToString().Replace(",", ".");
            string precoFinalSql = produto.CalcularPrecoFinal().ToString().Replace(",", ".");
            string atributoSql = atributo.ToString().Replace(",", ".");

            // Criação da query SQL direta por meio de interpolação de strings
            string sql = $"INSERT INTO produtos (nome, tipo, preco_base, preco_final, atributo_especifico) " +
                         $"VALUES ('{produto.Nome}', '{tipo}', {precoBaseSql}, {precoFinalSql}, {atributoSql})";

            using (MySqlConnection conexao = ConexaoBD.ObterConexao())
            {
                using (MySqlCommand comando = new MySqlCommand(sql, conexao))
                {
                    comando.ExecuteNonQuery();
                }
            }
        }
    }
}