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
    public class TemanComUa : BaseProvider
    {
        private readonly string _host = "";
        private readonly ILogger<TaskRunner> _logger;
        private List<ItemProvider> _providers = new List<ItemProvider>();

        public TemanComUa(AppDbContext db, ILogger<TaskRunner> logger, string host) : base(db)
        {
            this._logger = logger;
            this._host = host;

            //_providers.Add(new ItemProvider() { brand = EnumBrand.Audi, url = _host + "/cars/audi/" });
            //_providers.Add(new ItemProvider() { brand = EnumBrand.Audi, url = _host + "/cars/bmw/" });
            _providers.Add(new ItemProvider() { brand = EnumBrand.Audi, url = _host + "/cars/mercedesbenz" });
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
            var models = DNode.SelectNodes("//td[@class='cell-brand']//a").Take(limit);

            foreach (HtmlNode modelItem in models)
            {
                string url = _host + modelItem.Attributes["href"].Value;
                string model = modelItem.InnerText.Trim().Trim('/');

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

        private void GetCategory(string url, string model)
        {
            DocLoad(url);
            var links = DNode.SelectNodes("//a[@class='caption-element-a']");

            foreach (HtmlNode link in links)
            {
                string urlItem = _host + link.Attributes["href"].Value;
                string category = link.InnerText;

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

        private void CheckInfo(string url, string model, string category)
        {
            Console.WriteLine(url);
            Model checkModel = AddModelIfNotExist(model);
            Category checkCategory = AddCategoryIfNotExist(category);

            var categories = DNode.SelectNodes("//div[@class='tem-category-list']//div[@class='caption']//a");
            foreach (HtmlNode item in categories)
            {
                url = _host + item.Attributes["href"].Value;
                DocLoad(url);
                var subCategories = DNode.SelectNodes("//div[@class='tem-category-list']/div/div/a");

                foreach (HtmlNode subCategory in subCategories)
                {
                    url = _host + subCategory.Attributes["href"].Value;
                    GetSubCategory(url, checkModel, checkCategory);
                }
            }
        }

        private void GetSubCategory(string url, Model checkModel, Category checkCategory)
        {
            Console.WriteLine("\t" + url);
            DocLoad(url);
            var products = DNode.SelectNodes("//div[@class='tgp-product-element']//div[@class='name']//a").Take(limit);

            foreach (HtmlNode product in products)
            {
                url = _host + product.Attributes["href"].Value;
                GetProduct(url, checkModel, checkCategory);
            }
        }

        private void GetProduct(string url, Model model, Category category)
        {
            Console.WriteLine("\t\t" + url);
            Thread.Sleep(500);
            DocLoad(url);

            string name = GetText("//h1[@class='tgp-product-title']/span");
            if (total.Contains(name)) { return; }
            total.Add(name);

            string price = GetText("//div[@class='price']").Split(' ')[0];
            var link = DNode.SelectSingleNode("//div[@class='product-image']//img");
            string image = link.Attributes["data-src"].Value;
            string description = GetText("//div[@class='inner-description']");

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
