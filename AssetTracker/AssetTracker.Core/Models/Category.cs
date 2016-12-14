using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracker.Core.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string   Name { get; set; }
        public string   Code { get; set; }
        public int GeneralCategoryID { get; set; }
        public GeneralCategory GeneralCategory { get; set; } 
    }
}
