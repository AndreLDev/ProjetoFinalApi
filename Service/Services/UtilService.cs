using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Infra.CrossCutting.Scraper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class UtilService : IUtilService
    {
        private readonly IBaseRepository<Produto> _produtoRepository;
        private readonly IMapper _mapper;
        private readonly ILogRepository _logRepository;

        public UtilService(IBaseRepository<Produto> produtoRepository, IMapper mapper, ILogRepository logRepository)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
            _logRepository = logRepository;

        }

        public TResponseModel GetBenchMarkinById<TResponseModel>(int id) where TResponseModel : class
        {
            Produto produto = _produtoRepository.Select(id);

            MercadoLivreScraper mercadoLivreScraper = new MercadoLivreScraper(_logRepository, _mapper);
            ProdutoScraper scraper = mercadoLivreScraper.ObterPreco<ProdutoScraper>(produto);

            MagazineLuizaScraper magazineLuizaScraper = new MagazineLuizaScraper(_logRepository, _mapper);
            scraper = magazineLuizaScraper.ObterPreco<ProdutoScraper>(produto, scraper);


            var responseModels = _mapper.Map<TResponseModel>(scraper);

            return responseModels;
        }
    }
}
