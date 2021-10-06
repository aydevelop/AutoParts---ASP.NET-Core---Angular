using Database;
using Database.Model;
using HtmlAgilityPack;
using Infrastructure.Enum;
using Infrastructure.Provider.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Provider
{
    public class AutokladUa : AbsProvider
    {
        private readonly string host = "https://www.autoklad.ua";
        private readonly StoreDbContext context;
        private Brand brand;

        private List<Model> models = new List<Model>();
        private List<Brand> brands = new List<Brand>();
        private List<Category> categories = new List<Category>();

        public AutokladUa(StoreDbContext context)
        {
            this.context = context;
            models = context.Models.Include(u => u.Brand).ToList();
            brands = context.Brands.ToList();
            categories = context.Categories.ToList();
        }

        public override void Run()
        {
            List<ItemProvider> providers = new List<ItemProvider>()
            {
                new ItemProvider() { brand = EnumBrand.Audi, url = "https://www.autoklad.ua/cars/audi/" },
                new ItemProvider() { brand = EnumBrand.BMW, url = "https://www.autoklad.ua/cars/bmw/" },
                new ItemProvider() { brand = EnumBrand.Mercedes, url = "https://www.autoklad.ua/cars/mercedes/" },
                new ItemProvider() { brand = EnumBrand.Volkswagen, url = "https://www.autoklad.ua/cars/vw/" },
            };

            foreach (var item in providers)
            {
                brand = brands.Find(b => b.Name == item.brand.ToString());
                if (brand != null)
                {
                    Step1(item);
                }
            }
        }

        public void Step1(ItemProvider item)
        {
            
            var document = DocLoad(item.url);
            var links = document.DocumentNode.SelectNodes("//div[@class='uk-container o-text-formatted']//a");

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
            var document = DocLoad(url);
            var links = document.DocumentNode.SelectNodes("//div[@class='uk-container o-text-formatted']//a");

            foreach (HtmlNode link in links)
            {
                string urlItem = host + link.Attributes["href"].Value;
                string tmp = link.InnerText.Replace(model, "").Trim();
                string category = tmp.Substring(0, tmp.Length - 3);
                model = model.Substring(brand.Name.Length + 1).Trim();
                Step3(urlItem, model, category);
            }
        }

        public void Step3(string url, string model, string category)
        {
            Model checkModel = models.Find(q => q.Name == model && q.Brand.Name == brand.Name);
            if (checkModel == null)
            {
                checkModel = context.Models.Add(new Model() { Name = model, BrandId = brand.Id }).Entity;
                models.Add(checkModel);
            }

            Category checkCategory = categories.Find(q => q.Name == category);
            if(checkCategory == null)
            {
                checkCategory = context.Categories.Add(new Category() { Name = category }).Entity;
            }

            var document = DocLoad(url);
            var links = document.DocumentNode.SelectNodes("//div[@class='o-product o-product-special  ']//a");

            foreach (var link in links)
            {
                string urlItem = host + link.Attributes["href"].Value;
                Step4(urlItem, checkModel, checkCategory);
            }
        }

        public void Step4(string url, Model model, Category category)
        {
            var document = DocLoad(url);

            string name = document.DocumentNode.SelectSingleNode("//h1[@class='o-section-title o-head-title']").InnerText;
            string price = document.DocumentNode.SelectSingleNode("//*[@class='o-price']").InnerText;
            var tmp = document.DocumentNode.SelectSingleNode("//div[@class='uk-width-1-1 o-card-img']//a");
            string image = host + tmp.Attributes["href"].Value;
            string description = document.DocumentNode.SelectSingleNode("//div[@class='uk-width-3-5@m uk-first-column']").InnerText;

            Spare spare = new Spare();
            spare.Name = name;
            spare.Price = price;
            spare.ImageUrl = image;
            spare.Description = description;

            spare.CategoryId = category.Id;
            spare.ModelId = model.Id;
            context.Spares.Add(spare);            
        }
    }
}
