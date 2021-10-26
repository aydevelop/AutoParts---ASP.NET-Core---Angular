namespace Infrastructure.DtoAction.Spare
{
    public class SpareParamsAction
    {
        public double? MaxPrice { get; set; }
        public double? MinPrice { get; set; }

        public int PageIndex { get; set; } = 1;
        private const int _maxPageSize = 100;
        private int _pageSize = 10;

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > _maxPageSize) ? _maxPageSize : value;
        }
    }
}
