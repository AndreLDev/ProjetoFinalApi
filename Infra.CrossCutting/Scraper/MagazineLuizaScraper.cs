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

namespace Infra.CrossCutting.Scraper
{
    public class MagazineLuizaScraper : ScraperBase
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
                using (IWebDriver driver = new ChromeDriver())
                {
                    driver.Navigate().GoToUrl($"https://www.magazineluiza.com.br/busca/{produto.Desciption}");

                    System.Threading.Thread.Sleep(5000);

                    IWebElement priceElement = driver.FindElement(By.CssSelector("[data-testid='price-value']"));
                    IWebElement titleElement = driver.FindElement(By.CssSelector("[data-testid='product-title']"));
                    IWebElement urlElement = driver.FindElement(By.CssSelector("[data-testid='product-card-container']"));

                    if (priceElement != null)
                    {

                        scraper.MagazineTitle = titleElement.Text;
                        scraper.MagazinePrice = priceElement.Text;
                        scraper.MagazineUrl = urlElement.GetAttribute("href");

                        RegistrarLog("WebScraping - Magazine Luiza", "Sucesso", produto.Id);

                        TResponseModel responseModels = _mapper.Map<TResponseModel>(scraper);

                        return responseModels;
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

