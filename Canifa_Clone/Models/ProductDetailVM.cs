using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Canifa_Clone.Models
{
    public class ProductDetailVM
    {
        public int MaSP { get; set; }
        public string SKU_Code { get; set; }
        public string TenSP { get; set; }
        public decimal? GiaBan { get; set; }
        public decimal? GiaGoc { get; set; }
        public int? PhanTramGiam { get; set; }
        public string MoTa { get; set; }
        public string ChatLieu { get; set; }
        public string HuongDanSD { get; set; }
        public bool? IsNew { get; set; }
        public bool? IsFreeship { get; set; }

        public List<BienTheGroupMau> DsMau { get; set; } = new List<BienTheGroupMau>();

        // Ảnh mặc định (là ảnh đại diện của màu đầu tiên)
        public string AnhChinh { get; set; }

        public ProductDetailVM() { }
    }
}