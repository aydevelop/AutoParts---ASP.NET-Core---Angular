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
    public class SpareController : BaseController
    {
        private readonly IRepository<Spare> _db;
        public SpareController(IRepository<Spare> db)
        {
            _db = db;
        }

        [HttpGet]
        public virtual async Task<Pagination<Spare>> GetByFilter([FromQuery] SpareParamsAction spareParams)
        {
            Expression<Func<Spare, bool>> criteria = (q =>
                (!spareParams.MaxPrice.HasValue || q.Price <= spareParams.MaxPrice) &&
                (!spareParams.MinPrice.HasValue || q.Price >= spareParams.MinPrice)
            );

            var total = await _db.Count();
            int skip = spareParams.PageSize * (spareParams.PageIndex - 1);
            var spares = await _db.GetByFilerWithPaging(criteria, skip, spareParams.PageSize);

            return new Pagination<Spare>(spareParams.PageIndex, spareParams.PageSize, total, spares);
        }
    }
}
