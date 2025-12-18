using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Canifa_Clone.Models
{
    public class BienTheGroupMau
    {
        public int MaMau { get; set; }
        public string TenMau { get; set; }
        public string MaHex { get; set; }
        public List<SizeInfo> DanhSachSize { get; set; } = new List<SizeInfo>();
        public List<string> DanhSachAnh { get; set; } = new List<string>();
        public string AnhDaiDien { get; set; }
        public bool IsSelected { get; set; } = false;
    }

    public class SizeInfo
    {
        public int MaSize { get; set; }
        public string TenSize { get; set; }
        public int SoLuongTon { get; set; }
        public bool IsAvailable => SoLuongTon > 0;
    }

    public class CartItemVM
    {
        public int MaSP { get; set; }
        public string TenSP { get; set; }
        public string AnhSP { get; set; }
        public decimal GiaBan { get; set; }

        public int MaMau { get; set; }
        public string TenMau { get; set; }

        public int MaSize { get; set; }
        public string TenSize { get; set; }

        public int SoLuong { get; set; }

        public decimal ThanhTien => GiaBan * SoLuong;
    }
}