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
        private readonly string host = "https://teman.com.ua";
        private readonly ILogger<TaskRunner> _logger;

        public TemanComUa(AppDbContext db, ILogger<TaskRunner> logger) : base(db)
        {
            this._logger = logger;
        }

        List<ItemProvider> providers = new List<ItemProvider>()
        {
            new ItemProvider() { brand = EnumBrand.Audi, url = "https://teman.com.ua/cars/audi" },
            new ItemProvider() { brand = EnumBrand.BMW, url = "https://teman.com.ua/cars/bmw" },
            new ItemProvider() { brand = EnumBrand.Mercedes, url = "https://teman.com.ua/cars/mercedesbenz" },
        };

        public override void Run()
        {
            _logger.LogInformation($"Start {host}");
            CheckProvider(host);

            try
            {
                foreach (var item in providers)
                {
                    currentBrand = brands.Find(b => b.Name == item.brand.ToString());
                    if (currentBrand != null)
                    {
                        Step1(item);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }

        public void Step1(ItemProvider item)
        {
            DocLoad(item.url);
            var links = DNode.SelectNodes("//td[@class='cell-brand']//a");

            foreach (HtmlNode link in links)
            {
                string url = host + link.Attributes["href"].Value;
                string model = link.InnerText.Trim().Trim('/');

                try
                {
                    Step2(url, model);
                }
                catch (Exception ex)
                {
                    Thread.Sleep(500);
                    _logger.LogError(ex.Message);
                }
            }
        }

        private void Step2(string url, string model)
        {
            DocLoad(url);
            var links = DNode.SelectNodes("//a[@class='caption-element-a']");

            foreach (HtmlNode link in links)
            {
                string urlItem = host + link.Attributes["href"].Value;
                string category = link.InnerText;

                try
                {
                    Step3(urlItem, model, category);
                }
                catch (Exception ex)
                {
                    Thread.Sleep(500);
                    _logger.LogError(ex.Message);
                }
            }
        }

        private void Step3(string url, string model, string category)
        {
            Console.WriteLine(url);
            Model checkModel = AddModelIfNotExist(model);
            Category checkCategory = AddCategoryIfNotExist(category);

            var categories = DNode.SelectNodes("//div[@class='tem-category-list']//div[@class='caption']//a");
            foreach (HtmlNode item in categories)
            {
                url = host + item.Attributes["href"].Value;
                DocLoad(url);
                var subCategories = DNode.SelectNodes("//div[@class='tem-category-list']/div/div/a");

                foreach (HtmlNode subItem in subCategories)
                {
                    url = host + subItem.Attributes["href"].Value;
                    Step4(url, checkModel, checkCategory);
                }
            }
        }

        private void Step4(string url, Model checkModel, Category checkCategory)
        {
            Console.WriteLine("\t" + url);
            DocLoad(url);
            var products = DNode.SelectNodes("//div[@class='tgp-product-element']//div[@class='name']//a").Take(limit);

            foreach (HtmlNode item in products)
            {
                url = host + item.Attributes["href"].Value;
                Step5(url, checkModel, checkCategory);
            }
        }

        private void Step5(string url, Model model, Category category)
        {
            Console.WriteLine("\t\t" + url);
            Thread.Sleep(500);
            DocLoad(url);

            string name = GetText("//h1[@class='tgp-product-title']/span");
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
