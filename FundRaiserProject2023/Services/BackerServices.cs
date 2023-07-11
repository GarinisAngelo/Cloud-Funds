using FundRaiserProject2023.DbContexts;
using FundRaiserProject2023.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundRaiserProject2023.Services
{
    public class BackerServices:IServices
    {
        private readonly OurDbContext _ourDbContext;


        public BackerServices(OurDbContext ourDbContext)
        {
            _ourDbContext = ourDbContext;
        }

        public void Create()
        {
            var backerServices = new Backer(); //this is needed to be dynamic from the forms

            _ourDbContext.Backers.Add(backerServices);
            _ourDbContext.SaveChanges();
        }

        public void Delete() // this will need a change for the final version
        {
            int BackerId = 5; //this is needed to be dynamic from the forms
            var backer = _ourDbContext
                .Backers
                .Where(p => p.Id == BackerId)
                .FirstOrDefault();
            if (backer != null)
            {
                _ourDbContext.Backers.Remove(backer);
                _ourDbContext.SaveChanges();
            }

        }

        public void Read()
        {

            List<Backer> backer = _ourDbContext.Backers.ToList();

            backer.ForEach(Backer =>
            { Console.WriteLine($" Backer.Id = {Backer.Id}"); });  // this will need a change for the final version

        }

        public void Update() // this will need a change for the final version
        {
            int backerID = 5; //this is needed to be dynamic from the forms
            string newName = "Backer no1"; //this is needed to be dynamic from the forms

            var backer = _ourDbContext
                .Backers
                .Where(p => p.Id == backerID)
                .FirstOrDefault();
            if (backer != null)
            {
                backer.User.Name = newName;
                _ourDbContext.SaveChanges();
            }

        }

    }
}
