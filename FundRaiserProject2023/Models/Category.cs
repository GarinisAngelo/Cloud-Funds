using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundRaiserProject2023.Models
{
    /* Category
     * |Projects| */

    public class Category
    {
        public int Id { get; set; }

        [Display(Name = "Name")]
        public string? CategoryName { get; set; }
        public virtual Project? Projects { get; set; }

    }
}
