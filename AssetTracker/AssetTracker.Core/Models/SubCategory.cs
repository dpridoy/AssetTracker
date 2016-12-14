using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracker.Core.Models
{
    public class SubCategory
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int GeneralCategoryId { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
