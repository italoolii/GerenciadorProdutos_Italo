namespace GerenciadorProdutos
{
    // A classe ProdutoDigital herda da classe Produto
    public class ProdutoDigital : Produto
    {
        public double TamanhoMb { get; set; }

        public ProdutoDigital(string nome, decimal precoBase, double tamanhoMb)
            : base(nome, precoBase)
        {
            TamanhoMb = tamanhoMb;
        }

        // Polimorfismo: sobrescrevendo o método abstrato
        // O produto digital recebe um desconto de 5% por não ter custo de logística física
        public override decimal CalcularPrecoFinal()
        {
            decimal desconto = PrecoBase * 0.05m;
            return PrecoBase - desconto;
        }
    }
}