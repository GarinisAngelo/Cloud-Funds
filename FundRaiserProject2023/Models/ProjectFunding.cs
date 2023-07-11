using System;
using System.Collections.Generic;
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
        public decimal AmountContributed { get; set; }

        public DateTime Date = DateTime.Now;
        public virtual Backer? Backer { get; set; }
        public virtual Project? Projects { get; set; }
    }
}
