using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Canifa_Clone.Models
{
    public class HomeViewModel
    {
        public List<CategoryModel> Categories { get; set; }
        public List<ProductHomeVM> NewProducts { get; set; }
    }
}