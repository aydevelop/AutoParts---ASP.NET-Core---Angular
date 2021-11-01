﻿using Database;
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
        private readonly string host = "https://www.autoklad.ua";
        private readonly ILogger<TaskRunner> _logger;

        public AutokladUa(AppDbContext db, ILogger<TaskRunner> logger) : base(db)
        {
            this._logger = logger;
        }

        List<ItemProvider> providers = new List<ItemProvider>()
        {
            new ItemProvider() { brand = EnumBrand.Audi, url = "https://www.autoklad.ua/cars/audi/" },
            new ItemProvider() { brand = EnumBrand.BMW, url = "https://www.autoklad.ua/cars/bmw/" },
            new ItemProvider() { brand = EnumBrand.Mercedes, url = "https://www.autoklad.ua/cars/mercedes/" },
        };

        public override void Run()
        {
            _logger.LogInformation($"Start {host}");
            CheckProvider(host);

            try
            {
                context.Spares.RemoveRange(context.Spares.Where(q => q.ProviderId == providerId));
                context.SaveChanges();

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
            var links = DNode.SelectNodes("//div[@class='uk-container o-text-formatted']//a");

            foreach (HtmlNode link in links)
            {
                string url = host + link.Attributes["href"].Value;
                string model = link.InnerText.Replace("Запчасти на", "");
                model = model.Substring(currentBrand.Name.Length + 1).Trim();
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

        public void Step2(string url, string model)
        {
            DocLoad(url);
            var links = DNode.SelectNodes("//div[@class='uk-container o-text-formatted']//a");

            foreach (HtmlNode link in links)
            {
                string urlItem = host + link.Attributes["href"].Value;
                string category = link.InnerText.Split(new[] { " на " }, StringSplitOptions.None)[0];


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

        public void Step3(string url, string model, string category)
        {
            Console.WriteLine(url);
            Model checkModel = AddModelIfNotExist(model);
            Category checkCategory = AddCategoryIfNotExist(category);

            DocLoad(url);
            var links = DNode.SelectNodes("//div[@class='o-product o-product-special  ']//a").Take(10);

            foreach (var link in links)
            {
                string test = host + null;
                string urlItem = host + link.Attributes["href"]?.Value;
                if (!total.Contains(urlItem) && !urlItem.Contains("javascript") && urlItem != host)
                {
                    total.Add(urlItem);
                    Console.WriteLine("\t" + urlItem);
                    try
                    {
                        Step4(urlItem, checkModel, checkCategory);
                    }
                    catch (Exception ex)
                    {
                        Thread.Sleep(500);
                        _logger.LogError(ex.Message);
                    }
                }
            }
        }

        public void Step4(string url, Model model, Category category)
        {
            Thread.Sleep(1000);
            DocLoad(url);

            string name = GetText("//h1[@class='o-section-title o-head-title']");
            string price = GetText("//*[@class='o-price-code']/strong").Replace("грн", "");
            var link = DNode.SelectSingleNode("//div[@class='uk-width-1-1 o-card-img']//a");
            string image = link.Attributes["href"].Value;
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
