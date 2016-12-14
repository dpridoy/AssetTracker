using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracker.Core.Models
{
    public class Vendor
    {
        public int Id { get; set; }
        public int ProductCategoryId { get; set; }
        public int ProductNumbers { get; set; } 
    }
}
