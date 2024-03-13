using Application.Models.Response.Produto;

namespace Application.Models.Response.Log
{
    public class LogResponse
    {
        public int Id { get; set; }
        public string CodeRobot { get; set; }
        public string UserRobot { get; set; }
        public DateTime DateLog { get; set; }
        public string Stage { get; set; }
        public string InformationLog { get; set; }

        public ProdutoResponse Produto { get; set; }
    }
}
