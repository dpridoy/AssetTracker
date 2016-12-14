﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracker.Core.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public int Contact { get; set; }
        public string Email { get; set; }
        public int OrganizationId { get; set; }
        public int OrganizationBranchId { get; set; }
        public int DepartmentId { get; set; }
    }
}
