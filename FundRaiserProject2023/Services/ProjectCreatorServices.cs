using FundRaiserProject2023.DbContexts;
using FundRaiserProject2023.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundRaiserProject2023.Services
{
    public class ProjectCreatorServices
    {
        private readonly OurDbContext _ourDbContext;


        public ProjectCreatorServices(OurDbContext ourDbContext)
        {
            _ourDbContext = ourDbContext;
        }

        public void Create()
        {
            var projectcreatorServices = new ProjectCreator(); //this is needed to be dynamic from the forms

            _ourDbContext.ProjectCreators.Add(projectcreatorServices);
            _ourDbContext.SaveChanges();
        }

        public void Delete() // this will need a change for the final version
        {
            int projectcreatorID = 5; //this is needed to be dynamic from the forms
            var projectCreator = _ourDbContext
                .ProjectCreators
                .Where(p => p.Id == projectcreatorID)
                .FirstOrDefault();
            if (projectCreator != null)
            {
                _ourDbContext.ProjectCreators.Remove(projectCreator);
                _ourDbContext.SaveChanges();
            }

        }

        public void Read()
        {

            List<ProjectCreator> projectCreators = _ourDbContext.ProjectCreators.ToList();

            projectCreators.ForEach(projectCreators =>
            { Console.WriteLine($" ProjectCreator.Id = {projectCreators.Id}"); });  // this will need a change for the final version

        }

        public void Update() // this will need a change for the final version
        {
            int projectcreatorID = 5; //this is needed to be dynamic from the forms
            string newName = "project creator no1"; //this is needed to be dynamic from the forms

            var projectcreator = _ourDbContext
                .ProjectCreators
                .Where(p => p.Id == projectcreatorID)
                .FirstOrDefault();
            if (projectcreator != null)
            {
                projectcreator.Name = newName;
                _ourDbContext.SaveChanges();
            }

        }
    }
}
