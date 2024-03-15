using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using HtmlAgilityPack;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Infra.CrossCutting.Scraper
{
    public class MagazineLuizaScraper : LogBase
    {
        private readonly IMapper _mapper;
        private readonly ILogRepository _logRepository;

        public MagazineLuizaScraper(ILogRepository logRepository, IMapper mapper) : base(logRepository, mapper)
        {
            _mapper = mapper;
            _logRepository = logRepository;
        }

        public TResponseModel ObterPreco<TResponseModel>(Produto produto, ProdutoScraper scraper) where TResponseModel : class
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = $"https://www.magazineluiza.com.br/busca/{produto.Desciption}";

                    HttpResponseMessage response = client.GetAsync(url).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        string content = response.Content.ReadAsStringAsync().Result;

                        var docHtml = new HtmlDocument();

                        docHtml.LoadHtml(content);

                        var produtos = docHtml.DocumentNode.SelectNodes("//a");

                        foreach (var item in produtos)
                        {
                            if (item.OuterHtml.Contains("data-testid=\"product-card-container\""))
                            {

                                var card = item;
                                var UrlValue = card.GetAttributeValue("href", "");
                                var PriceValue = card.SelectSingleNode(".//p[@data-testid=\"price-value\"]");
                                var TitleValue = card.SelectSingleNode(".//h2[@data-testid=\"product-title\"]");


                                scraper.MagazinePrice = PriceValue.InnerText.Trim();
                                scraper.MagazineTitle = TitleValue.InnerText.Trim();
                                scraper.MagazineUrl = "https://www.magazineluiza.com.br"+UrlValue;

                                RegistrarLog("WebScraping - Magazine Luiza", "Sucesso", produto.Id);

                                TResponseModel responseModels = _mapper.Map<TResponseModel>(scraper);

                                return responseModels;

                            }
                        }

                        Console.WriteLine("Preço não encontrado.");
                        RegistrarLog("WebScraping - Magazine Luiza", "Preço não encontrado", produto.Id);
                        return null;

                    }
                    else
                    {
                        Console.WriteLine("Preço não encontrado.");
                        RegistrarLog("WebScraping - Magazine Luiza", "Preço não encontrado", produto.Id);
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao acessar a página: {ex.Message}");
                RegistrarLog("Web Scraping - Magazine Luiza", $"Erro: {ex.Message}", produto.Id);
                return null;
            }
        }
    }
}

