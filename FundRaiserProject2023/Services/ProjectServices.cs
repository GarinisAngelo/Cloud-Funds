using FundRaiserProject2023.DbContexts;
using FundRaiserProject2023.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundRaiserProject2023.Services
{
    public class ProjectServices : IProjectService
    {

        private readonly OurDbContext _ourDbContext;


        public ProjectServices(OurDbContext ourDbContext)
        {
            _ourDbContext = ourDbContext;
        }


        public void Create()
        {
            var project = new Project(); //this is needed to be dynamic from the forms

            _ourDbContext.Projects.Add(project);
            _ourDbContext.SaveChanges();
        }


        public void Delete() // this will need a change for the final version
        {
            int projectId = 5; //this is needed to be dynamic from the forms
            var project = _ourDbContext
                .Projects
                .Where(p => p.Id == projectId)
                .FirstOrDefault();
            if (project != null)
            {
                _ourDbContext.Projects.Remove(project);
                _ourDbContext.SaveChanges();
            }

        }


        public void Read()
        {
            
            List<Project> projects = _ourDbContext.Projects.ToList();

            projects.ForEach(project => 
                { Console.WriteLine($" project.Id = {project.Id}"); });  // this will need a change for the final version

        }


        public void Update() // this will need a change for the final version
        {
            int projectId = 5; //this is needed to be dynamic from the forms
            string newDescription = "this project in about science and space"; //this is needed to be dynamic from the forms

            var project = _ourDbContext
                .Projects
                .Where(p => p.Id == projectId)
                .FirstOrDefault();
            if (project != null)
            {
                project.Description = newDescription;
                _ourDbContext.SaveChanges();
            }

        }
    }
}

