using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundRaiserProject2023.Models
{
    /* ProjectPhotos
     * |Projects| */

    public class ProjectPhotos
    {
        public int Id { get; set; }
        public string? PhotoName { get; set; }
        public string? PhotoDescription { get; set; }
        public virtual Project? Projects { get; set; }
    }
}
