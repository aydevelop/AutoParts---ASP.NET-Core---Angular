using AvtoZapchasti.Controllers.Base;
using ClosedXML.Excel;
using Database.Contract;
using Database.Model;
using Infrastructure.DtoAction.Spare;
using Infrastructure.Util;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
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

        [HttpGet("details/{id:guid}")]
        public async Task<Spare> Details(Guid id)
        {
            return await _db.GetWithDetails(id);
        }

        [HttpGet("filter")]
        public async Task<Pagination<Spare>> GetByFilter([FromQuery] SpareParamsAction spareParams)
        {
            var criteria = GetCriteria(spareParams);


            int total = 0;
            int take = spareParams.PageSize;
            int skip = take * (spareParams.PageIndex - 1);
            Spare[] spares = await _db.GetByFilterWithPaging(criteria, skip, take, out total, "priceAsk");

            return new Pagination<Spare>(spareParams.PageIndex, take, total, spares);
        }

        [HttpGet("excel-generate")]
        public async Task<IActionResult> GetExcelByFilter([FromQuery] SpareParamsAction spareParams)
        {
            var criteria = GetCriteria(spareParams);
            Spare[] spares = await _db.GetByFilterWithModel(criteria);

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Users");
                var row = 1;
                worksheet.Cell(row, 1).Value = "Id";
                worksheet.Cell(row, 2).Value = "Name";
                worksheet.Cell(row, 3).Value = "Price";
                worksheet.Cell(row, 4).Value = "ImageUrl";
                worksheet.Cell(row, 5).Value = "Brand";
                worksheet.Cell(row, 6).Value = "Model";
                worksheet.Cell(row, 7).Value = "Category";
                worksheet.Cell(row, 8).Value = "Url";

                foreach (var spare in spares)
                {
                    row++;
                    worksheet.Cell(row, 1).Value = spare.Id;
                    worksheet.Cell(row, 2).Value = spare.Name;
                    worksheet.Cell(row, 3).Value = spare.Price;
                    worksheet.Cell(row, 4).Value = spare.ImageUrl;
                    worksheet.Cell(row, 5).Value = spare.Model.Brand.Name;
                    worksheet.Cell(row, 6).Value = spare.Model.Name;
                    worksheet.Cell(row, 7).Value = spare.Category.Name;
                    worksheet.Cell(row, 8).Value = spare.Url;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    return File(stream.ToArray(),
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "result.xlsx");
                }
            }
        }

        private Expression<Func<Spare, bool>> GetCriteria(SpareParamsAction spareParams)
        {
            Expression<Func<Spare, bool>> criteria = (q =>
             (!spareParams.CategoryId.HasValue || q.CategoryId == spareParams.CategoryId) &&
             (!spareParams.BrandId.HasValue || q.Model.BrandId == spareParams.BrandId) &&
             (!spareParams.MaxPrice.HasValue || q.Price <= spareParams.MaxPrice) &&
             (!spareParams.MinPrice.HasValue || q.Price >= spareParams.MinPrice) &&
             (string.IsNullOrWhiteSpace(spareParams.Search) || q.Name.ToLower().Contains(spareParams.Search))
          );

            return criteria;
        }
    }
}
