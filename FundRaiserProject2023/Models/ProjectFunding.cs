using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundRaiserProject2023.Models
{
    /* ProjectFunding
     * |Backer| |Project| */

    public class ProjectFunding
    {
        public int Id { get; set; }

        [Display(Name = "Amount Contributed")]
        public decimal AmountContributed { get; set; }

        [Display(Name = "Time")]
        public DateTime Date { get; set; }
        public virtual Backer? Backer { get; set; }
        public virtual Project? Projects { get; set; }

    }
}
