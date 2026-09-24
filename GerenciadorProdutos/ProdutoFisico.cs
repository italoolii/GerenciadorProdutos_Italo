namespace GerenciadorProdutos
{
    // A classe ProdutoFisico herda da classe Produto
    public class ProdutoFisico : Produto
    {
        public double PesoKg { get; set; }

        // Sobrecarga de construtores chamando o construtor base
        public ProdutoFisico(string nome, decimal precoBase, double pesoKg)
            : base(nome, precoBase)
        {
            PesoKg = pesoKg;
        }

        // Polimorfismo: sobrescrevendo o método abstrato da classe base
        // O produto físico possui um acréscimo de frete baseado no peso
        public override decimal CalcularPrecoFinal()
        {
            decimal frete = (decimal)(PesoKg * 2.50);
            return PrecoBase + frete;
        }
    }
}