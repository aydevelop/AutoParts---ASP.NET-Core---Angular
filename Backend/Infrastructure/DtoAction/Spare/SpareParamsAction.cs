using System;

namespace Infrastructure.DtoAction.Spare
{
    public class SpareParamsAction
    {
        public Guid? CategoryId { get; set; }
        public Guid? BrandId { get; set; }
        public decimal? MaxPrice { get; set; }
        public decimal? MinPrice { get; set; }

        public int PageIndex { get; set; } = 1;
        private const int _maxPageSize = 100;
        private int _pageSize = 10;

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > _maxPageSize) ? _maxPageSize : value;
        }

        private string _search;
        public string Search
        {
            get => _search;
            set => _search = value.ToLower();
        }
    }
}
