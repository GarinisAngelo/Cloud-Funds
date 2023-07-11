using System;
using System.Collections.Generic;
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
        public string? PackageName { get; set; }
        public decimal PackageAmount { get; set; }
        public string? RewardDescription { get; set; }
        public virtual Project? Projects { get; set; }
    }
}
