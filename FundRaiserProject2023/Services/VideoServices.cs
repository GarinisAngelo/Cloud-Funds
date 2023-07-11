using FundRaiserProject2023.DbContexts;
using FundRaiserProject2023.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundRaiserProject2023.Services
{
    public class VideoServices : IServices
    {
        private readonly OurDbContext _ourDbContext;

        public VideoServices(OurDbContext ourDbContext)
        {
            _ourDbContext = ourDbContext;
        }


        public void Create()
        {
            var video = new ProjectVideos(); //this is needed to be dynamic from the forms

            _ourDbContext.ProjectVideos.Add(video);
            _ourDbContext.SaveChanges();
        }


        public void Delete() // this will need a change for the final version
        {
            int videoId = 5; //this is needed to be dynamic from the forms
            var video = _ourDbContext
                .ProjectVideos
                .Where(p => p.Id == videoId)
                .FirstOrDefault();
            if (video != null)
            {
                _ourDbContext.ProjectVideos.Remove(video);
                _ourDbContext.SaveChanges();
            }

        }


        public void Read()
        {

            List<ProjectVideos> video = _ourDbContext.ProjectVideos.ToList();

            video.ForEach(video =>
            { Console.WriteLine($" video.Id = {video.Id}"); });  // this will need a change for the final version

        }


        public void Update() // this will need a change for the final version
        {
            int videoId = 5; //this is needed to be dynamic from the forms
            string newDescription = "this video shows our team on a hiking travel."; //this is needed to be dynamic from the forms

            var video = _ourDbContext
                .ProjectVideos
                .Where(v => v.Id == videoId)
                .FirstOrDefault();
            if (video != null)
            {
                video.VideoDescription = newDescription;
                _ourDbContext.SaveChanges();
            }

        }
    }
}
