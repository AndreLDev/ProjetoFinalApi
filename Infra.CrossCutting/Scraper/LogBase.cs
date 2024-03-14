using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.CrossCutting.Scraper
{
    public class LogBase
    {
        private readonly ILogRepository _logRepository;
        private readonly IMapper _mapper;

        public LogBase(ILogRepository logRepository, IMapper mapper)
        {
            _logRepository = logRepository;
            _mapper = mapper;
        }

        protected void RegistrarLog(string processo, string informacaoLog, int idProduto)
        {
            var log = new RequestLog
            {
                CodeRobot = "3416",
                UserRobot = "andreLuiz",
                DateLog = DateTime.Now,
                Stage = processo,
                InformationLog = informacaoLog,
                IdProduto = idProduto
            };
            Log entity = _mapper.Map<Log>(log);
            _logRepository.Insert(entity);
        }
    }
}
