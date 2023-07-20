using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundRaiserProject2023.Models
{
    /*  Projects
        {Backer} |ProjectCreator| {RewardPackage} {ProjectFundings} |Category| {ProjectPhotos} {ProjectVideos} */

    public class Project
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }

        [Display(Name = "Funding Goal")]
        public decimal FundingGoal { get; set; }

        [Display(Name = "Current Funding")]
        public decimal CurrentFunding { get; set; }
        public virtual IEnumerable<Backer> Backers { get; set; } = new List<Backer>();

        [Display(Name = "Project Creator")]
        public virtual ProjectCreator? ProjectCreator { get; set; }

        [Display(Name = "Reward Packages")]
        public virtual IEnumerable<RewardPackage> RewardPackages { get; set; } = new List<RewardPackage>();
        public virtual IEnumerable<ProjectFunding> ProjectFundings { get; set; } = new List<ProjectFunding>();
        
        [Display(Name = "Photos")]
        public virtual IEnumerable<ProjectPhotos> ProjectPhotos { get; set; } = new List<ProjectPhotos>();
        
        [Display(Name = "Videos")]
        public virtual IEnumerable<ProjectVideos> ProjectVideos { get; set; } = new List<ProjectVideos>();
        public enum StatusUpdates 
        { 
            On_Going,
            Completed 
        };
    }
}
