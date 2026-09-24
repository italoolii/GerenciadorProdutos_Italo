using System;

namespace GerenciadorProdutos
{
public abstract class Produto
{
    // Encapsulamento através de propriedades automáticas
    public int Id { get; set; }
    public string Nome { get; set; }
    public decimal PrecoBase { get; set; }

    // Construtor da classe base
    protected Produto(string nome, decimal precoBase)
    {
        Nome = nome;
        PrecoBase = precoBase;
    }

    // Método abstrato que força as subclasses a implementarem o polimorfismo
    public abstract decimal CalcularPrecoFinal();
}
}