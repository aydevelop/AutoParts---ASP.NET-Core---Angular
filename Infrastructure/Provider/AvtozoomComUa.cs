using Database;
using Database.Model;
using HtmlAgilityPack;
using Infrastructure.Enum;
using Infrastructure.Provider.Base;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Infrastructure.Provider
{
    public class AvtozoomComUa : BaseProvider
    {
        private readonly string _host = "";
        private readonly ILogger<TaskRunner> _logger;
        private List<ItemProvider> _providers = new List<ItemProvider>();

        public AvtozoomComUa(AppDbContext db, ILogger<TaskRunner> logger, string host) : base(db)
        {
            this._logger = logger;
            this._host = host;

            _providers.Add(new ItemProvider() { brand = EnumBrand.Audi, url = _host + "/audi" });
            _providers.Add(new ItemProvider() { brand = EnumBrand.BMW, url = _host + "/bmw" });
            _providers.Add(new ItemProvider() { brand = EnumBrand.Mercedes, url = _host + "/mercedes" });
        }

        public override void Run()
        {
            _logger.LogInformation($"Start {_host}");
            CheckProvider(_host);

            try
            {
                foreach (var item in _providers)
                {
                    currentBrand = brands.Find(b => b.Name == item.brand.ToString());
                    if (currentBrand != null)
                    {
                        Start(item);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }

        public void Start(ItemProvider item)
        {
            DocLoad(item.url);
            var models = DNode.SelectNodes("//div[@class='container-white']//a[@class='title-item']");

            foreach (HtmlNode model in models)
            {
                string modelUrl = _host + model.Attributes["href"].Value;
                string modelName = model.ChildNodes[^2].InnerText;

                try
                {
                    GetCategory(modelUrl, modelName);
                }
                catch (Exception ex)
                {
                    Thread.Sleep(500);
                    _logger.LogError(ex.Message);
                }
            }
        }

        public void GetCategory(string url, string model)
        {
            DocLoad(url);
            var categories = DNode.SelectNodes("//div[@class='wrap-cat-row']//span[@class='h3']//a");

            foreach (HtmlNode category in categories)
            {
                string categoryUrl = _host + category.Attributes["href"].Value;
                string categoryName = category.InnerText.Trim();

                try
                {
                    CheckInfo(categoryUrl, model, categoryName);
                }
                catch (Exception ex)
                {
                    Thread.Sleep(500);
                    _logger.LogError(ex.Message);
                }
            }
        }

        private void CheckInfo(string categoryUrl, string model, string category)
        {
            Console.WriteLine(categoryUrl);
            Model checkModel = AddModelIfNotExist(model);
            Category checkCategory = AddCategoryIfNotExist(category);

            DocLoad(categoryUrl);
            var products = DNode.SelectNodes("//div[@class='product-name']//a").Take(limit);

            foreach (var product in products)
            {
                string productUrl = product.Attributes["href"]?.Value;
                if (!total.Contains(productUrl))
                {
                    Console.WriteLine("\t" + productUrl);

                    try
                    {
                        GetProduct(productUrl, checkModel, checkCategory);
                    }
                    catch (Exception ex)
                    {
                        Thread.Sleep(500);
                        _logger.LogError(ex.Message);
                    }
                }
            }
        }

        private void GetProduct(string productUrl, Model model, Category category)
        {
            Thread.Sleep(1000);
            DocLoad(productUrl);

            string name = GetText("//h1[@class='title-item']");
            string price = GetText("//*[@class='price-val']");
            var link = DNode.SelectSingleNode("//div[@id='gal-imags-first']//img");
            string image = link.Attributes["src"].Value;

            var dts = DNode.SelectNodes("//dl[@class='dl-horizontal dl-criteria m-no ']/dt");
            var dds = DNode.SelectNodes("//dl[@class='dl-horizontal dl-criteria m-no ']/dd");

            string description = "";
            for (int i = 0; i < dts.Count && i < dds.Count; i++)
            {
                var tableName = dts[i].InnerText.Trim();
                var tableValue = dds[i].InnerText.Trim();
                description += $"{tableName}: ${tableValue}" + Environment.NewLine;
            }

            Spare spare = new Spare();
            spare.Name = name;
            spare.Price = Convert.ToDecimal(price);
            spare.ImageUrl = image;
            spare.Description = description;
            spare.CategoryId = category.Id;
            spare.ModelId = model.Id;
            spare.Url = productUrl;
            spare.ProviderId = providerId;

            context.Spares.Add(spare);
            context.SaveChanges();
        }
    }
}
