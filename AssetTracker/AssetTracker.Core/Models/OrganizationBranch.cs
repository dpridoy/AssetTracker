using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracker.Core.Models
{
    public class OrganizationBranch
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Branch Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Branch Short Name")]
        public string ShortName { get; set; }

        public int OrganizationId { get; set; }

        public virtual Organization Organization { get; set; }
        public virtual ICollection<AssetLocation> AssetLocations { get; set; }
    }
}
