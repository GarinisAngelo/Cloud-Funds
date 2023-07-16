using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundRaiserProject2023.Models
{
    /*  RewardPackage
        |Projects| */

    public class RewardPackage
    {
        public int Id { get; set; }

        [Display(Name = "Tier")]
        public string? PackageName { get; set; }

        [Display(Name = "Amount")]
        public decimal PackageAmount { get; set; }

        [Display(Name = "Reward")]
        public string? RewardDescription { get; set; }
        public virtual Project? Projects { get; set; }
    }
}
