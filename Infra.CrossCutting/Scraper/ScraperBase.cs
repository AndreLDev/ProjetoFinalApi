using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.CrossCutting.Scraper
{
    public class ScraperBase
    {
        private readonly ILogRepository _logRepository;
        protected void RegistrarLog(string processo, string informacaoLog, int idProduto)
        {
            var log = new Log
            {
                CodeRobot = "3416",
                UserRobot = "andreLuiz",
                DateLog = DateTime.Now,
                Stage = processo,
                InformationLog = informacaoLog,
                IdProduto = idProduto
            };
            _logRepository.Insert(log);
        }
    }
}
