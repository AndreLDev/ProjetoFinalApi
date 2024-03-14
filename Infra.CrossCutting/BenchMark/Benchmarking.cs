using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Infra.CrossCutting.Scraper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.CrossCutting.BenchMark
{
    public class Benchmarking : LogBase
    {
        private readonly IMapper _mapper;
        private readonly ILogRepository _logRepository;

        public Benchmarking(ILogRepository logRepository, IMapper mapper) : base(logRepository, mapper)
        {
            _mapper = mapper;
            _logRepository = logRepository;
        }

        public ProdutoScraper CompararValor(ProdutoScraper scraper , Produto produto)
        {
            var priceMercado = scraper.MercadoPrice.Replace(".", "");
            var priceMagazine = scraper.MagazinePrice.Trim(new char[] { ' ', 'R', '$' }).Replace(".", "");

            var numPrecoMercado = double.Parse(priceMercado);
            var numPrecoMagazine = double.Parse(priceMagazine);

            if (numPrecoMercado > numPrecoMagazine)
            {
                RegistrarLog("Benchmarking", "Sucesso", produto.Id);
                scraper.Best = 0;
                return scraper;
            }
            else if (numPrecoMagazine > numPrecoMercado)
            {
                RegistrarLog("Benchmarking", "Sucesso", produto.Id);
                scraper.Best = 1;
                return scraper;
            }
            else
            {
                RegistrarLog("Benchmarking", "Alerta", produto.Id);
                scraper.Best = 2;
                return scraper;
            }
        }
    }
}
