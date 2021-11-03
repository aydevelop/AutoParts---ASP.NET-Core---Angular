using Database;
using Database.Model;
using HtmlAgilityPack;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Infrastructure.Provider.Base
{
    public abstract class BaseProvider
    {
        protected List<Model> models = new List<Model>();
        protected List<Brand> brands = new List<Brand>();
        protected List<Category> categories = new List<Category>();
        protected readonly AppDbContext context;
        protected Brand currentBrand;
        protected Guid providerId;
        protected HtmlDocument doc;
        protected HtmlNode DNode => doc.DocumentNode;
        protected List<string> total = new List<string>();
        protected int limit = 10;

        public BaseProvider(AppDbContext context)
        {
            this.context = context;
            models = context.Models.Include(u => u.Brand).ToList();
            brands = context.Brands.ToList();
            categories = context.Categories.ToList();
        }

        public abstract void Run();

        public void DocLoad(string url)
        {
            var htmlWeb = new HtmlWeb();
            var document = htmlWeb.Load(url);
            doc = document;
        }

        public Model AddModelIfNotExist(string model)
        {
            Model checkModel = models.Find(q => q.Name.ToLower() == model.ToLower() && q.Brand.Name == currentBrand.Name);
            if (checkModel == null)
            {
                checkModel = context.Models.Add(new Model() { Name = model, BrandId = currentBrand.Id }).Entity;
                models.Add(checkModel);
            }

            return checkModel;
        }

        public Category AddCategoryIfNotExist(string category)
        {
            Category checkCategory = categories.Find(q => q.Name.ToLower() == category.ToLower());
            if (checkCategory == null)
            {
                checkCategory = context.Categories.Add(new Category() { Name = category }).Entity;
            }

            return checkCategory;
        }

        public string GetText(string path)
        {
            return HttpUtility.HtmlDecode(DNode.SelectSingleNode(path)?.InnerText?.Trim()) ?? "";
        }

        public void CheckProvider(string host)
        {
            var checkProvider = context.Providers.FirstOrDefault(q => q.SiteUrl == host);
            if (checkProvider == null)
            {
                Database.Model.Provider pr = new Database.Model.Provider() { Name = host, SiteUrl = host };
                context.Providers.Add(pr);
                providerId = pr.Id;
            }
            else
            {
                providerId = checkProvider.Id;
            }

            context.Spares.RemoveRange(context.Spares.Where(q => q.ProviderId == providerId));
            context.SaveChanges();
        }
    }
}
