namespace Application.Models.Request.Log
{
    public class CreateLogRequest
    {
        public string CodeRobot { get; set; }
        public string UserRobot { get; set; }
        public DateTime DateLog { get; set; }
        public string Stage { get; set; }
        public string InformationLog { get; set; }
        public int IdProduto { get; set; }
    }
}
