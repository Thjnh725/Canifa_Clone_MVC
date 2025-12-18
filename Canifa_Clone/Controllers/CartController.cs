using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Canifa_Clone.Models;

namespace Canifa_Clone.Controllers
{
    public class CartController : Controller
    {
        Canifa_Entities db = new Canifa_Entities();

        // Lấy giỏ hàng từ Session
        public List<CartItemVM> GetCart()
        {
            List<CartItemVM> cart = Session["Cart"] as List<CartItemVM>;
            if (cart == null)
            {
                cart = new List<CartItemVM>();
                Session["Cart"] = cart;
            }
            return cart;
        }

        // GET: Cart
        public ActionResult Index()
        {
            var cart = GetCart();
            ViewBag.TotalAmount = cart.Sum(s => s.ThanhTien);
            ViewBag.Count = cart.Sum(s => s.SoLuong);
            return View(cart);
        }

        // Thêm sản phẩm vào giỏ
        [HttpPost]
        public ActionResult AddToCart(int maSP, int maMau, int maSize, int soLuong = 1)
        {
            var cart = GetCart();
            
            // Tìm sản phẩm cùng loại (cùng màu, cùng size) trong giỏ
            var item = cart.FirstOrDefault(s => s.MaSP == maSP && s.MaMau == maMau && s.MaSize == maSize);
            
            if (item == null)
            {
                // Lấy thông tin từ database
                var sp = db.SanPham.Find(maSP);
                var mau = db.MauSac.Find(maMau);
                var size = db.KichCo.Find(maSize);
                
                // Lấy ảnh đại diện của màu này
                var anh = db.AnhSanPham.FirstOrDefault(a => a.MaSP == maSP && a.MaMau == maMau && a.LaAnhDaiDien == true)?.LinkAnh 
                          ?? db.AnhSanPham.FirstOrDefault(a => a.MaSP == maSP && a.MaMau == maMau)?.LinkAnh;

                item = new CartItemVM
                {
                    MaSP = maSP,
                    TenSP = sp.TenSP,
                    GiaBan = sp.GiaBan ?? 0,
                    MaMau = maMau,
                    TenMau = mau?.TenMau,
                    MaSize = maSize,
                    TenSize = size?.TenSize,
                    AnhSP = anh,
                    SoLuong = soLuong
                };
                cart.Add(item);
            }
            else
            {
                item.SoLuong += soLuong;
            }

            Session["Cart"] = cart;
            return Json(new { success = true, count = cart.Sum(s => s.SoLuong) });
        }

        // Xóa sản phẩm khỏi giỏ
        public ActionResult RemoveFromCart(int maSP, int maMau, int maSize)
        {
            var cart = GetCart();
            var item = cart.FirstOrDefault(s => s.MaSP == maSP && s.MaMau == maMau && s.MaSize == maSize);
            if (item != null)
            {
                cart.Remove(item);
            }
            Session["Cart"] = cart;
            return RedirectToAction("Index");
        }

        // Cập nhật số lượng
        public ActionResult UpdateQuantity(int maSP, int maMau, int maSize, int quantity)
        {
            var cart = GetCart();
            var item = cart.FirstOrDefault(s => s.MaSP == maSP && s.MaMau == maMau && s.MaSize == maSize);
            if (item != null)
            {
                if (quantity > 0)
                {
                    item.SoLuong = quantity;
                }
                else
                {
                    cart.Remove(item);
                }
            }
            Session["Cart"] = cart;
            return RedirectToAction("Index");
        }

        // Lấy số lượng sản phẩm để hiển thị trên Header (dùng Ajax gọi)
        public ActionResult GetCartCount()
        {
            var cart = GetCart();
            int count = cart.Sum(s => s.SoLuong);
            return Json(new { count = count }, JsonRequestBehavior.AllowGet);
        }
    }
}
