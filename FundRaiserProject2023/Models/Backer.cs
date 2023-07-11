using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundRaiserProject2023.Models
{
    /*  Backer
        {ProjectFunding} |User|*/

    public class Backer
    {
        [Key, ForeignKey("User")]
        public int Id { get; set; }
        public virtual User? User { get; set; }
        public virtual IEnumerable<ProjectFunding> ProjectFundings { get; set; } = new List<ProjectFunding>();
    }
}
