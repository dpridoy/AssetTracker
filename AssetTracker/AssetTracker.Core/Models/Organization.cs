﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracker.Core.Models
{
    public class Organization
    {
        //public Organization()
        //{
            
        //}
        //public Organization(string name, string code):this()
        //{
        //    this.Name = name;
        //    this.Code = code;
        //}

        public int Id { get; set; }

        [Required]
        [Display(Name = "Organization Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Organization Code")]
        //[StringLength(3)]
        public string Code { get; set; }
        [Required]
        [Display(Name = "Organization Location")]
        public string Location { get; set; }

        public virtual ICollection<OrganizationBranch> OrganizationBranches { get; set; } 
    }
}
