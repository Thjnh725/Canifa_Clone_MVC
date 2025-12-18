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
            new CategoryModel { Title = "TẤT CẢ", ImageUrl = "/Content/Images/banner/istockphoto-1363627613-612x612.jpg",  Link = Url.Action("SanPhamMoi", "SanPham") },
            new CategoryModel { Title = "NỮ",     ImageUrl = "/Content/Images/banner/istockphoto-1142399373-612x612.jpg",            Link = Url.Action("AnhNuClick", "SanPham") },
            new CategoryModel { Title = "NAM",    ImageUrl = "/Content/Images/banner/istockphoto-1300966679-612x612.jpg",             Link = Url.Action("AnhNamClick", "SanPham")  },
            new CategoryModel { Title = "BÉ TRAI",ImageUrl = "/Content/Images/banner/istockphoto-1050662758-612x612.jpg",            Link = Url.Action("AnhBeTraiClick", "SanPham")  },
            new CategoryModel { Title = "BÉ GÁI", ImageUrl = "/Content/Images/banner/istockphoto-956002732-612x612.jpg",            Link = Url.Action("AnhBeGaiClick", "SanPham")}
        },

                // NHỚ gán thêm list sản phẩm vào ViewModel
                NewProducts = result
            };

            return View(model);
        }

        public ActionResult AnhNuClick()
        {
            var danhSachIdChoPhep = new List<int> { 21, 22, 23, 24, 25, 26 };
            var listSP = db.SanPham
                .Where(sp => sp.HienThi == true   && sp.MaDM_Chinh.HasValue  && danhSachIdChoPhep.Contains(sp.MaDM_Chinh.Value))
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
            new CategoryModel { Title = "TẤT CẢ", ImageUrl = "/Content/Images/banner/istockphoto-1363627613-612x612.jpg",  Link = Url.Action("SanPhamMoi", "SanPham") },
            new CategoryModel { Title = "NỮ",     ImageUrl = "/Content/Images/banner/istockphoto-1142399373-612x612.jpg",            Link = Url.Action("AnhNuClick", "SanPham") },
            new CategoryModel { Title = "NAM",    ImageUrl = "/Content/Images/banner/istockphoto-1300966679-612x612.jpg",             Link = Url.Action("AnhNamClick", "SanPham")  },
            new CategoryModel { Title = "BÉ TRAI",ImageUrl = "/Content/Images/banner/istockphoto-1050662758-612x612.jpg",            Link = Url.Action("AnhBeTraiClick", "SanPham")  },
            new CategoryModel { Title = "BÉ GÁI", ImageUrl = "/Content/Images/banner/istockphoto-956002732-612x612.jpg",            Link = Url.Action("AnhBeGaiClick", "SanPham")}
        },

                // NHỚ gán thêm list sản phẩm vào ViewModel
                NewProducts = result
            };

            return View(model);
        }

        public ActionResult AnhNamClick()
        {
            var danhSachIdChoPhep = new List<int> { 15, 16, 17, 18, 19, 20 };
            var listSP = db.SanPham
                .Where(sp => sp.HienThi == true && sp.MaDM_Chinh.HasValue && danhSachIdChoPhep.Contains(sp.MaDM_Chinh.Value))
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
            new CategoryModel { Title = "TẤT CẢ", ImageUrl = "/Content/Images/banner/istockphoto-1363627613-612x612.jpg",  Link = Url.Action("SanPhamMoi", "SanPham") },
            new CategoryModel { Title = "NỮ",     ImageUrl = "/Content/Images/banner/istockphoto-1142399373-612x612.jpg",            Link = Url.Action("AnhNuClick", "SanPham") },
            new CategoryModel { Title = "NAM",    ImageUrl = "/Content/Images/banner/istockphoto-1300966679-612x612.jpg",             Link = Url.Action("AnhNamClick", "SanPham")  },
            new CategoryModel { Title = "BÉ TRAI",ImageUrl = "/Content/Images/banner/istockphoto-1050662758-612x612.jpg",            Link = Url.Action("AnhBeTraiClick", "SanPham")  },
            new CategoryModel { Title = "BÉ GÁI", ImageUrl = "/Content/Images/banner/istockphoto-956002732-612x612.jpg",            Link = Url.Action("AnhBeGaiClick", "SanPham")}
        },

                
                NewProducts = result
            };

            return View(model);
        }

        public ActionResult AnhBeTraiClick()
        {
            var danhSachIdChoPhep = new List<int> { 5,6,7,8};
            var listSP = db.SanPham
                .Where(sp => sp.HienThi == true && sp.MaDM_Chinh.HasValue && danhSachIdChoPhep.Contains(sp.MaDM_Chinh.Value))
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
            new CategoryModel { Title = "TẤT CẢ", ImageUrl = "/Content/Images/banner/istockphoto-1363627613-612x612.jpg",  Link = Url.Action("SanPhamMoi", "SanPham") },
            new CategoryModel { Title = "NỮ",     ImageUrl = "/Content/Images/banner/istockphoto-1142399373-612x612.jpg",            Link = Url.Action("AnhNuClick", "SanPham") },
            new CategoryModel { Title = "NAM",    ImageUrl = "/Content/Images/banner/istockphoto-1300966679-612x612.jpg",             Link = Url.Action("AnhNamClick", "SanPham")  },
            new CategoryModel { Title = "BÉ TRAI",ImageUrl = "/Content/Images/banner/istockphoto-1050662758-612x612.jpg",            Link = Url.Action("AnhBeTraiClick", "SanPham")  },
            new CategoryModel { Title = "BÉ GÁI", ImageUrl = "/Content/Images/banner/istockphoto-956002732-612x612.jpg",            Link = Url.Action("AnhBeGaiClick", "SanPham")}
        },


                NewProducts = result
            };

            return View(model);
        }

        public ActionResult AnhBeGaiClick()
        {
            var danhSachIdChoPhep = new List<int> { 9,10,11,12,13,14 };
            var listSP = db.SanPham
                .Where(sp => sp.HienThi == true && sp.MaDM_Chinh.HasValue && danhSachIdChoPhep.Contains(sp.MaDM_Chinh.Value))
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
            new CategoryModel { Title = "TẤT CẢ", ImageUrl = "/Content/Images/banner/istockphoto-1363627613-612x612.jpg",  Link = Url.Action("SanPhamMoi", "SanPham") },
            new CategoryModel { Title = "NỮ",     ImageUrl = "/Content/Images/banner/istockphoto-1142399373-612x612.jpg",            Link = Url.Action("AnhNuClick", "SanPham") },
            new CategoryModel { Title = "NAM",    ImageUrl = "/Content/Images/banner/istockphoto-1300966679-612x612.jpg",             Link = Url.Action("AnhNamClick", "SanPham")  },
            new CategoryModel { Title = "BÉ TRAI",ImageUrl = "/Content/Images/banner/istockphoto-1050662758-612x612.jpg",            Link = Url.Action("AnhBeTraiClick", "SanPham")  },
            new CategoryModel { Title = "BÉ GÁI", ImageUrl = "/Content/Images/banner/istockphoto-956002732-612x612.jpg",            Link = Url.Action("AnhBeGaiClick", "SanPham")}
        },


                NewProducts = result
            };

            return View(model);
        }

        public ActionResult Detail(int? id, int? maMau)
        {
            if (id == null) return HttpNotFound();

            // Khớp với bảng SanPham (MaSP, HienThi)
            var sanPham = db.SanPham.FirstOrDefault(sp => sp.MaSP == id && sp.HienThi == true);
            if (sanPham == null) return HttpNotFound();

            // Khớp với bảng ChiTietSanPham (MaSP, MaMau)
            var danhSachMauIds = db.ChiTietSanPham
                .Where(ct => ct.MaSP == id)
                .Select(ct => ct.MaMau)
                .Distinct()
                .ToList();

            var dsMauGroup = new List<BienTheGroupMau>();
            var selectedMauId = maMau ?? (danhSachMauIds.Any() ? danhSachMauIds.First() : 0);

            foreach (var mId in danhSachMauIds)
            {
                // Khớp với bảng MauSac (MaMau)
                var mauSac = db.MauSac.FirstOrDefault(m => m.MaMau == mId);
                if (mauSac == null) continue;

                // Khớp với bảng ChiTietSanPham (MaSP, MaMau, MaSize, SoLuongTon)
                var chiTietSize = db.ChiTietSanPham
                    .Where(ct => ct.MaSP == id && ct.MaMau == mId)
                    .ToList();

                var danhSachSize = chiTietSize.Select(ct => new SizeInfo
                {
                    MaSize = ct.MaSize ?? 0, 
                    TenSize = ct.KichCo != null ? ct.KichCo.TenSize : "",
                    SoLuongTon = ct.SoLuongTon ?? 0 
                })
                .OrderBy(s => {
                    int val;
                    // Thử chuyển đổi TenSize sang số để sắp xếp chính xác (98 < 104)
                    return int.TryParse(s.TenSize, out val) ? val : 999; 
                })
                .ThenBy(s => s.TenSize) // Nếu không phải số thì sắp xếp theo chữ
                .ToList();

                // Khớp với bảng AnhSanPham (MaSP, MaMau, LinkAnh, LaAnhDaiDien)
                var danhSachAnh = db.AnhSanPham
                    .Where(a => a.MaSP == id && a.MaMau == mId)
                    .OrderBy(a => a.LaAnhDaiDien == true ? 0 : 1)
                    .Select(a => a.LinkAnh)
                    .ToList();

                var anhDaiDien = db.AnhSanPham
                    .FirstOrDefault(a => a.MaSP == id && a.MaMau == mId && a.LaAnhDaiDien == true);

                var bienTheMau = new BienTheGroupMau
                {
                    MaMau = mauSac.MaMau,
                    TenMau = mauSac.TenMau,
                    MaHex = mauSac.MaHex,
                    DanhSachSize = danhSachSize,
                    DanhSachAnh = danhSachAnh,
                    AnhDaiDien = anhDaiDien != null ? anhDaiDien.LinkAnh : (danhSachAnh.Any() ? danhSachAnh.First() : null),
                    IsSelected = mId == selectedMauId
                };

                dsMauGroup.Add(bienTheMau);
            }

            // Tính PhanTramGiam nếu database chưa tính sẵn
            int phanTram = sanPham.PhanTramGiam ?? 0;
            if (phanTram == 0 && sanPham.GiaGoc > 0 && sanPham.GiaBan > 0)
            {
                phanTram = (int)Math.Round((double)((sanPham.GiaGoc - sanPham.GiaBan) / sanPham.GiaGoc * 100));
            }

            var model = new ProductDetailVM
            {
                MaSP = sanPham.MaSP,
                SKU_Code = sanPham.SKU_Code, // SKU_Code từ bảng SanPham
                TenSP = sanPham.TenSP,
                GiaBan = sanPham.GiaBan,
                GiaGoc = sanPham.GiaGoc,
                PhanTramGiam = phanTram,
                MoTa = sanPham.MoTa,
                ChatLieu = sanPham.ChatLieu,
                HuongDanSD = sanPham.HuongDanSD,
                IsNew = sanPham.IsNew,
                IsFreeship = sanPham.IsFreeship,
                DsMau = dsMauGroup,
                AnhChinh = dsMauGroup.FirstOrDefault(m => m.IsSelected)?.AnhDaiDien ?? (dsMauGroup.Any() ? dsMauGroup.First().AnhDaiDien : null)
            };

            return View(model);
        }

    }
}