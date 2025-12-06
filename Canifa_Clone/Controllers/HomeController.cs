using Canifa_Clone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
// Giả định DB_CANIFAEntities và các Models đã được định nghĩa

namespace Canifa_Clone.Controllers
{
    public class HomeController : Controller
    {
        Canifa_Entities db = new Canifa_Entities();

        public ActionResult Index()
        {
 

            var listSP = db.SanPham
            .Where(sp => sp.HienThi == true)
            .OrderBy(sp => sp.NgayTao) 
            .Take(5) 
            .ToList();

            List<ProductHomeVM> result = new List<ProductHomeVM>();

            foreach (var sp in listSP)
            {
               
                var dsMau = db.AnhSanPham
                    .Where(a => a.MaSP == sp.MaSP)
                    .GroupBy(a => a.MaMau)
                    .Select(g => g.FirstOrDefault(x => x.LaAnhDaiDien == true).LinkAnh)
                    .ToList();

                ProductHomeVM item = new ProductHomeVM
                {
                    MaSP = sp.MaSP,
                    TenSP = sp.TenSP,
                    GiaBan = sp.GiaBan,
                    GiaGoc = sp.GiaGoc,
                    ListAnhDaiDienTheoMau = dsMau,
                    AnhChinh = dsMau.FirstOrDefault()  
                };

                result.Add(item);
            }

            return View(result);
        }


        public ActionResult KhuyenMaiPartial()
        {
            // Giả sử db là DbContext của bạn
            // Lấy các khuyến mãi chưa hết hạn
            var listKM = db.KhuyenMai
                           .Where(x => x.NgayHetHan >= DateTime.Now)
                           .OrderBy(x => x.NgayHetHan)
                           .ToList();

            return PartialView(listKM);
        }
    }
}
