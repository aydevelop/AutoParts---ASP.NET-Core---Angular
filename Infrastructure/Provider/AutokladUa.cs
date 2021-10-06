using Database;
using Infrastructure.Provider.Base;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Provider
{
    public class AutokladUa : IProvider
    {
        private readonly StoreDbContext context;
        public AutokladUa(StoreDbContext context)
        {
            this.context = context;
        }

        public void Run()
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
                Step1(item);
            }
        }

        public void Step1(ItemProvider item)
        {
           
        }
    }
}
