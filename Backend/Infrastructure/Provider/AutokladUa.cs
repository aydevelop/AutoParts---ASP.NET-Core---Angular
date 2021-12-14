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
    public class AutokladUa : BaseProvider
    {
        private readonly string _host = "";
        private readonly ILogger<TaskRunner> _logger;
        private List<ItemProvider> _providers = new List<ItemProvider>();

        public AutokladUa(AppDbContext db, ILogger<TaskRunner> logger, string host) : base(db)
        {
            this._logger = logger;
            this._host = host;

            _providers.Add(new ItemProvider() { brand = EnumBrand.Audi, url = _host + "/cars/mercedes/" });
            _providers.Add(new ItemProvider() { brand = EnumBrand.Audi, url = _host + "/cars/bmw/" });
            _providers.Add(new ItemProvider() { brand = EnumBrand.Audi, url = _host + "/cars/audi/" });
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
            var links = DNode.SelectNodes("//div[@class='uk-container o-text-formatted']//a").Take(limit);

            foreach (HtmlNode link in links)
            {
                string url = _host + link.Attributes["href"].Value;
                string model = link.InnerText.Replace("Запчасти на", "");
                model = model.Substring(currentBrand.Name.Length + 1).Trim();
                try
                {
                    GetCategory(url, model);
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
            var categories = DNode.SelectNodes("//div[@class='uk-container o-text-formatted']//a");

            foreach (HtmlNode categoryItem in categories)
            {
                string urlItem = _host + categoryItem.Attributes["href"].Value;
                string category = categoryItem.InnerText.Split(new[] { " на " }, StringSplitOptions.None)[0];

                try
                {
                    CheckInfo(urlItem, model, category);
                }
                catch (Exception ex)
                {
                    Thread.Sleep(500);
                    _logger.LogError(ex.Message);
                }
            }
        }

        public void CheckInfo(string url, string model, string category)
        {
            Console.WriteLine(url);
            Model checkModel = AddModelIfNotExist(model);
            Category checkCategory = AddCategoryIfNotExist(category);

            DocLoad(url);
            var products = DNode.SelectNodes("//div[@class='o-product o-product-special  ']//a").Take(limit);

            foreach (var product in products)
            {
                string test = _host + null;
                string urlItem = _host + product.Attributes["href"]?.Value;
                if (!total.Contains(urlItem) && !urlItem.Contains("javascript") && urlItem != _host)
                {
                    total.Add(urlItem);
                    Console.WriteLine("\t" + urlItem);
                    try
                    {
                        GetProduct(urlItem, checkModel, checkCategory);
                    }
                    catch (Exception ex)
                    {
                        Thread.Sleep(500);
                        _logger.LogError(ex.Message);
                    }
                }
            }
        }

        public void GetProduct(string url, Model model, Category category)
        {
            Thread.Sleep(500);
            string name = GetText("//h1[@class='o-section-title o-head-title']");
            string price = GetText("//*[@class='o-price-code']/strong").Replace("грн", "");
            var link = DNode.SelectSingleNode("//meta[@property='twitter:image']");
            string image = link.Attributes["content"].Value;
            string description = GetText("//div[@class='uk-card uk-card-body uk-card-default uk-card-bodyh']");

            Spare spare = new Spare();
            spare.Name = name;
            spare.Price = Convert.ToDecimal(price);
            spare.ImageUrl = image;
            spare.Description = description;
            spare.CategoryId = category.Id;
            spare.ModelId = model.Id;
            spare.Url = url;
            spare.ProviderId = providerId;

            context.Spares.Add(spare);
            context.SaveChanges();
        }
    }
}
