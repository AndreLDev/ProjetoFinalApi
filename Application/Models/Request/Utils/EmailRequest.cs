namespace Application.Models.Request.Utils
{
    public class EmailRequest
    {
        public string MercadoTitle { get; set; }
        public string MercadoPrice { get; set; }
        public string MercadoUrl { get; set; }
        public string MagazineTitle { get; set; }
        public string MagazinePrice { get; set; }
        public string MagazineUrl { get; set; }
        public int Best { get; set; }
        public string Email { get; set; }
        public int ProdutoId { get; set; }
    }
}
