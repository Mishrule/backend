using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using TimeTableUI.Models.VMs;

namespace TimeTableUI.Controllers
{
    public class FileUploadController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //public async Task<List<Rooms>> Import(IFormFile file)
        //{
        //    var list = new List<Rooms>();
        //    using (var stream = new MemoryStream())
        //    {
        //        await file.CopyToAsync(stream);
        //        using (var package = new ExcelPackage(stream))
        //        {
        //            ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
        //            var rowcount = worksheet.Dimension.Rows;
        //            for (int row = 2; row <= rowcount; row++)
        //            {
        //                list.Add(new Rooms
        //                {
        //                    name = worksheet.Cells[row, 1].Value.ToString().Trim(),
        //                    lab = worksheet.Cells[row, 2].Value.Equals("true") ? true : false,
        //                    size = int.Parse(worksheet.Cells[row, 3].Value.ToString().Trim())
        //                });

        //            }
        //        }
        //    }

        //    return list;
       // }
    }
}
