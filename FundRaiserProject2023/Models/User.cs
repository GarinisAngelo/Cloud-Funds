using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundRaiserProject2023.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public enum Role { Admin, Backer, ProjectCreator};
    }
}
