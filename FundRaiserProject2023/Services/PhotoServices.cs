using FundRaiserProject2023.DbContexts;
using FundRaiserProject2023.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundRaiserProject2023.Services
{
    public class PhotoServices : IServices
    {
        private readonly OurDbContext _ourDbContext;


        public PhotoServices(OurDbContext ourDbContext)
        {
            _ourDbContext = ourDbContext;
        }


        public void Create()
        {
            var photo = new ProjectPhotos(); //this is needed to be dynamic from the forms

            _ourDbContext.ProjectPhotos.Add(photo);
            _ourDbContext.SaveChanges();
        }


        public void Delete() // this will need a change for the final version
        {
            int PhotoId = 5; //this is needed to be dynamic from the forms
            var photo = _ourDbContext
                .ProjectPhotos
                .Where(p => p.Id == PhotoId)
                .FirstOrDefault();
            if (photo != null)
            {
                _ourDbContext.ProjectPhotos.Remove(photo);
                _ourDbContext.SaveChanges();
            }

        }


        public void Read()
        {

            List<ProjectPhotos> photos = _ourDbContext.ProjectPhotos.ToList();

            photos.ForEach(photo =>
            { Console.WriteLine($" photo.Id = {photo.Id}"); });  // this will need a change for the final version

        }


        public void Update() // this will need a change for the final version
        {
            int photoId = 5; //this is needed to be dynamic from the forms
            string newDescription = "this photo shows our offices."; //this is needed to be dynamic from the forms

            var photo = _ourDbContext
                .ProjectPhotos
                .Where(p => p.Id == photoId)
                .FirstOrDefault();
            if (photo != null)
            {
                photo.PhotoDescription = newDescription;
                _ourDbContext.SaveChanges();
            }

        }
    }
}
