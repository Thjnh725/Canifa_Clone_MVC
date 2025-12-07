using Canifa_Clone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Canifa_Clone.Controllers
{
    public class SanPhamController : Controller
    {
        // GET: SanPham
        Canifa_Entities db = new Canifa_Entities();

        public ActionResult SanPhamMoi()
        {
            var listSP = db.SanPham
                .Where(sp => sp.HienThi == true)
                .OrderByDescending(sp => sp.NgayTao)
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

            var model = new HomeViewModel
            {
                Categories = new List<CategoryModel>
        {
            new CategoryModel { Title = "TẤT CẢ", ImageUrl = "/Content/Images/banner/istockphoto-1363627613-612x612.jpg", Link = "#" },
            new CategoryModel { Title = "NỮ",     ImageUrl = "/Content/Images/banner/istockphoto-1142399373-612x612.jpg",           Link = "#" },
            new CategoryModel { Title = "NAM",    ImageUrl = "/Content/Images/banner/istockphoto-1300966679-612x612.jpg",             Link = "#" },
            new CategoryModel { Title = "BÉ TRAI",ImageUrl = "/Content/Images/banner/istockphoto-1050662758-612x612.jpg",             Link = "#" },
            new CategoryModel { Title = "BÉ GÁI", ImageUrl = "/Content/Images/banner/istockphoto-956002732-612x612.jpg",            Link = "#" }
        },

                // NHỚ gán thêm list sản phẩm vào ViewModel
                NewProducts = result
            };

            return View(model);
        }

    }
}