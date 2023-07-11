using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundRaiserProject2023.Models
{
    /* ProjectVideos
     * |Projects| */

    public class ProjectVideos 
    {
        public int Id { get; set; }
        public string? VideoName { get; set; }
        public string? VideoDescription { get; set; }
        public virtual Project? Projects { get; set; }
    }
}
