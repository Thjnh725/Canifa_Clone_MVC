using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Canifa_Clone.Models
{
    public class ProductDetailVM
    {
        public int MaSP { get; set; }
        public string TenSP { get; set; }
        public decimal GiaBan { get; set; }
        public decimal GiaGoc { get; set; }
        public int PhanTramGiam { get; set; }

        public List<BienTheGroupMau> DsMau { get; set; } = new List<BienTheGroupMau>();

        // Ảnh mặc định (là ảnh đại diện của màu đầu tiên)
        public string AnhChinh { get; set; }

        public ProductDetailVM() { }
    }
}