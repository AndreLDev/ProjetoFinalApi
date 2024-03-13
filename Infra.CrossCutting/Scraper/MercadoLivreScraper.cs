using AutoMapper;
using Domain.Entities;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.CrossCutting.Scraper
{
    public class MercadoLivreScraper : ScraperBase
    {
        private readonly IMapper _mapper;
        public TResponseModel ObterPreco<TResponseModel>(Produto produto) where TResponseModel : class
        {
            string url = $"https://lista.mercadolivre.com.br/{produto.Desciption}";

            try
            {
                HtmlWeb web = new HtmlWeb();
                HtmlDocument document = web.Load(url);

                HtmlNode firstProductPriceNode = document.DocumentNode.SelectSingleNode("//span[@class='andes-money-amount__fraction']");
                HtmlNode firstProductTitleNode = document.DocumentNode.SelectSingleNode("//h2[@class='ui-search-item__title']");
                HtmlNode firstProductUrlNode = document.DocumentNode.SelectSingleNode("//a[contains(@class, 'ui-search-link__title-card')]");

                if (firstProductPriceNode != null)
                {
                    string firstProductPrice = firstProductPriceNode.InnerText.Trim();
                    string firstProductTitle = firstProductTitleNode.InnerText.Trim();
                    string firstProductUrl = firstProductUrlNode.GetAttributeValue("href", "");

                    RegistrarLog("WebScraping - Mercado Livre", "Sucesso", produto.Id);

                    ProdutoScraper produtoScraper = new ProdutoScraper
                    {
                        MercadoTitle = firstProductTitle,
                        MercadoPrice = firstProductPrice,
                        MercadoUrl = firstProductUrl
                    };

                    TResponseModel responseModels = _mapper.Map<TResponseModel>(produtoScraper);

                    return responseModels;
                }
                else
                {
                    Console.WriteLine("Preço não encontrado.");
                    RegistrarLog("WebScraping - Mercado Livre", "Preço não encontrado", produto.Id);
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao acessar a página: {ex.Message}");
                RegistrarLog("Web Scraping - Mercado Livre", $"Erro: {ex.Message}", produto.Id);
                return null;
            }
        }
    }
}
