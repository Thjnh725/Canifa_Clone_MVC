using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Canifa_Clone.Models
{
    public class KhuyenMai_db
    {
        Canifa_Entities db = new Canifa_Entities();
        public List<KhuyenMai> GetListActive()
        {
            return db.KhuyenMai
                     .Where(x => x.HienThi == true)
                     .OrderByDescending(x => x.Id)
                     .ToList();
        }
    }
}