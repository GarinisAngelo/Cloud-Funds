using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundRaiserProject2023.Models
{
    /*  ProjectCreator
        {Projects}*/

    public class ProjectCreator
    {        
        public int Id { get; set; }
        public string? Name { get; set; }
        public virtual IEnumerable<Project> Projects { get; set; } = new List<Project>();
    }
}
