using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundRaiserProject2023.Models
{
    /*  Projects
        {Backer} |ProjectCreator| {RewardPackage} {ProjectFundings} |Category| {ProjectPhotos} {ProjectVideos} */

    public class Project
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public enum StatusUpdates { On_Going , Completed };
        public decimal FundingGoal { get; set; }
        public decimal CurrentFunding { get; set; }
        public virtual IEnumerable<Backer> Backers { get; set; } = new List<Backer>();
        public virtual ProjectCreator? ProjectCreator { get; set; }
        public virtual IEnumerable<RewardPackage> RewardPackages { get; set; } = new List<RewardPackage>();
        public virtual IEnumerable<ProjectFunding> ProjectFundings { get; set; } = new List<ProjectFunding>();
        public virtual IEnumerable<ProjectPhotos> ProjectPhotos { get; set; } = new List<ProjectPhotos>();
        public virtual IEnumerable<ProjectVideos> ProjectVideos { get; set; } = new List<ProjectVideos>();
    }
}
