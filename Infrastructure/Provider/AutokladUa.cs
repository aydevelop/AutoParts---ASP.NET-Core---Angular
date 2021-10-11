using Database;
using Database.Model;
using HtmlAgilityPack;
using Infrastructure.Enum;
using Infrastructure.Provider.Base;
using System;
using System.Collections.Generic;

namespace Infrastructure.Provider
{
    public class AutokladUa : AbsProvider
    {
        private readonly string host = "https://www.autoklad.ua";
        public AutokladUa(StoreDbContext context) : base(context) { }

        List<ItemProvider> providers = new List<ItemProvider>()
        {
            //new ItemProvider() { brand = EnumBrand.Audi, url = "https://www.autoklad.ua/cars/audi/" },
            new ItemProvider() { brand = EnumBrand.BMW, url = "https://www.autoklad.ua/cars/bmw/" },
            new ItemProvider() { brand = EnumBrand.Mercedes, url = "https://www.autoklad.ua/cars/mercedes/" },
            new ItemProvider() { brand = EnumBrand.Volkswagen, url = "https://www.autoklad.ua/cars/vw/" },
        };

        public override void Run()
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

        public void Step1(ItemProvider item)
        {
            DocLoad(item.url);
            var links = DNode.SelectNodes("//div[@class='uk-container o-text-formatted']//a");

            foreach (HtmlNode link in links)
            {
                string url = host + link.Attributes["href"].Value;
                string model = link.InnerText.Replace("Запчасти на", "");
                model = model.Replace("VW", "Volkswagen");
                Step2(url, model);
            }
        }

        public void Step2(string url, string model)
        {
            DocLoad(url);
            var links = DNode.SelectNodes("//div[@class='uk-container o-text-formatted']//a");

            foreach (HtmlNode link in links)
            {
                string urlItem = host + link.Attributes["href"].Value;
                string tmp = link.InnerText.Replace(model, "").Trim();
                string category = tmp.Substring(0, tmp.Length - 3);
                model = model.Substring(currentBrand.Name.Length + 1).Trim();
                Step3(urlItem, model, category);
            }
        }

        public void Step3(string url, string model, string category)
        {
            Model checkModel = AddModelIfNotExist(model);
            Category checkCategory = AddCategoryIfNotExist(category);

            DocLoad(url);
            var links = DNode.SelectNodes("//div[@class='o-product o-product-special  ']//a");

            foreach (var link in links)
            {
                string test = host + null;
                string urlItem = host + link.Attributes["href"]?.Value;
                if (!total.Contains(urlItem) && !urlItem.Contains("javascript") && urlItem != host)
                {
                    total.Add(urlItem);
                    Console.WriteLine(urlItem);
                    Step4(urlItem, checkModel, checkCategory);
                }
            }
        }

        public void Step4(string url, Model model, Category category)
        {
            DocLoad(url);
            string html = DNode.InnerHtml;
            string name = GetText("//h1[@class='o-section-title o-head-title']");
            string price = GetText("//*[@class='o-price-code']/strong").Replace("грн", "");
            var link = DNode.SelectSingleNode("//div[@class='uk-width-1-1 o-card-img']//a");
            string image = link.Attributes["href"].Value;
            string description = GetText("//div[@class='uk-card uk-card-body uk-card-default uk-card-bodyh']");

            Spare spare = new Spare();
            spare.Name = name;
            spare.Price = price;
            spare.ImageUrl = image;
            spare.Description = description;
            spare.CategoryId = category.Id;
            spare.ModelId = model.Id;
            spare.Url = url;

            context.Spares.Add(spare);
            context.SaveChanges();
        }
    }
}
