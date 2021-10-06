using HtmlAgilityPack;

namespace Infrastructure.Provider.Base
{
    public abstract class AbsProvider
    {
        public abstract void Run();

        public HtmlDocument DocLoad(string url)
        {
            var htmlWeb = new HtmlWeb();
            var document = htmlWeb.Load(url);
            return document;
        }
    }
}
