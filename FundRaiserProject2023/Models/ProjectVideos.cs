using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Display(Name = "Name")]
        public string? VideoName { get; set; }

        [Display(Name = "Description")]
        public string? VideoDescription { get; set; }
        public virtual Project? Projects { get; set; }
    }
}
