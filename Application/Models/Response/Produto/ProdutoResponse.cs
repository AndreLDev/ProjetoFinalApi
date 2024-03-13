namespace Application.Models.Response.Produto
{
    public class ProdutoResponse
    {
        public int Id { get; set; }
        public string Desciption { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int MinStock { get; set; }
    }
}
