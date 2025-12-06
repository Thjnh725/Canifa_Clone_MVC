using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Canifa_Clone.Models
{
    public class ProductHomeVM
    {
        public int MaSP { get; set; }
        public string TenSP { get; set; }
        public decimal? GiaBan { get; set; }
        public decimal? GiaGoc { get; set; }
        
        public int PhanTramGiam { get; set; }
        public string AnhChinh { get; set; }

        // Danh sách ảnh đại diện theo từng màu
        public List<string> ListAnhDaiDienTheoMau { get; set; } = new List<string>();
        public ProductHomeVM() { }
    }
}