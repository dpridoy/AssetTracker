using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracker.Core.Models
{
    public class AssetLocation
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Asset Location Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Sort Name")]
        public string ShortName { get; set; }
        public int OrganizationBranchId { get; set; }
        public virtual OrganizationBranch OrganizationBranch { get; set; }
    }
}
