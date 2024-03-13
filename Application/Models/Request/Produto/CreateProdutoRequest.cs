
namespace Application.Models.Request.Produto
{
    public class CreateProdutoRequest
    {
        public string Desciption { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int MinStock { get; set; }
    }
}
