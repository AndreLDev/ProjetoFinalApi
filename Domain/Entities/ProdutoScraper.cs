using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ProdutoScraper
    {
        public string? MercadoTitle { get; set; }
        public string? MercadoPrice { get; set; }
        public string? MercadoUrl { get; set; }
        public string? MagazineTitle { get; set; }
        public string? MagazinePrice { get; set; }
        public string? MagazineUrl { get; set; }
        public int? Best {  get; set; }
    }
}
