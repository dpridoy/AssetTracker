using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracker.Core.Models
{
    public class AssetRegistration
    {
        public int Id { get; set; }
        public int AssetId { get; set; }
        public int OrganizationId { get; set; }
        public string SerialNo { get; set; }
        public string RegistrationCode { get; set; }
        public string Code { get; set; }
        public int? AssetLocationId { get; set; }

        [DisplayName("Assign To")]
        public int? EmployeeId { get; set; }

        public virtual Organization Organization { get; set; }
        public virtual Asset Asset { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual AssetLocation AssetLocation { get; set; }
    }
}
