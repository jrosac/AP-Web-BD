namespace Marketplace.API.Models
{
    public class Produto
    {
        public int IdProduto { get; set; }
        public decimal Preco { get; set; }
        public string Categoria { get; set; }
        public string Condicao { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public byte[] Foto { get; set; }
        public string Dimensoes { get; set; }
        public int Vendedor_IdVendedor { get; set; }
    }
}
