﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.CrossCutting.Scraper
{
    public class RequestLog
    {
        public string CodeRobot { get; set; }
        public string UserRobot { get; set; }
        public DateTime DateLog { get; set; }
        public string Stage { get; set; }
        public string InformationLog { get; set; }
        public int IdProduto { get; set; }
    }
}
