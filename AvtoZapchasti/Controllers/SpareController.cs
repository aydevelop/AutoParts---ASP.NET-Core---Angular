using AvtoZapchasti.Controllers.Base;
using Database.Contract;
using Database.Model;
using Infrastructure.DtoAction.Spare;
using Infrastructure.Util;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AvtoZapchasti.Controllers
{
    public class SpareController : CrudController<Spare>
    {
        private readonly ISpareRepository _db;

        public SpareController(ISpareRepository db) : base(db)
        {
            _db = db;
        }

        [HttpGet("filter")]
        public virtual async Task<Pagination<Spare>> GetByFilter([FromQuery] SpareParamsAction spareParams)
        {
            Expression<Func<Spare, bool>> criteria = (q =>
             (!spareParams.CategoryId.HasValue || q.CategoryId == spareParams.CategoryId) &&
             (!spareParams.BrandId.HasValue || q.Model.BrandId == spareParams.BrandId) &&
             (!spareParams.MaxPrice.HasValue || q.Price <= spareParams.MaxPrice) &&
             (!spareParams.MinPrice.HasValue || q.Price >= spareParams.MinPrice) &&
             (string.IsNullOrWhiteSpace(spareParams.Search) || q.Name.ToLower().Contains(spareParams.Search))
          );

            int total = await _db.Count();
            int take = spareParams.PageSize;
            int skip = take * (spareParams.PageIndex - 1);

            Spare[] spares = await _db.GetByFilerWithPaging(criteria, skip, take, "priceAsk");
            return new Pagination<Spare>(spareParams.PageIndex, take, total, spares);
        }
    }
}
