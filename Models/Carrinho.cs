namespace Marketplace.API.Models
{
    public class Carrinho
    {
        public int Idcarrinho { get; set; }
        public int Quantidade { get; set; }
        public double Preco { get; set; }
        public int Comprador_IdComprador { get; set; }
    }
}
