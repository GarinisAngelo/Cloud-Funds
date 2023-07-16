using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Display(Name = "Name")]
        public string? PhotoName { get; set; }

        [Display(Name = "Description")]
        public string? PhotoDescription { get; set; }
        public virtual Project? Projects { get; set; }
    }
}
