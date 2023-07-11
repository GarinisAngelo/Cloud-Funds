using FundRaiserProject2023.DbContexts;
using FundRaiserProject2023.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundRaiserProject2023.Services
{
    public class RewardPackagesServices:IServices
    {
        private readonly OurDbContext _ourDbContext;


        public RewardPackagesServices(OurDbContext ourDbContext)
        {
            _ourDbContext = ourDbContext;
        }


        public void Create()
        {
            var rewardPackage = new RewardPackage(); //this is needed to be dynamic from the forms

            _ourDbContext.RewardPackages.Add(rewardPackage);
            _ourDbContext.SaveChanges();
        }


        public void Delete() // this will need a change for the final version
        {
            int rewardId = 5; //this is needed to be dynamic from the forms
            var rewardPackage = _ourDbContext
                .RewardPackages
                .Where(p => p.Id == rewardId)
                .FirstOrDefault();
            if (rewardPackage != null)
            {
                _ourDbContext.RewardPackages.Remove(rewardPackage);
                _ourDbContext.SaveChanges();
            }

        }


        public void Read()
        {

            List<RewardPackage> rewardPackages = _ourDbContext.RewardPackages.ToList();

            rewardPackages.ForEach(rewardPackages =>
            { Console.WriteLine($" rewardPackages.Id = {rewardPackages.Id}"); });  // this will need a change for the final version

        }


        public void Update() // this will need a change for the final version
        {
            int rewardId = 5; //this is needed to be dynamic from the forms
            string newDescription = "reward package"; //this is needed to be dynamic from the forms

            var rewardPackage = _ourDbContext
                .RewardPackages
                .Where(p => p.Id == rewardId)
                .FirstOrDefault();
            if (rewardPackage != null)
            {
                rewardPackage.RewardDescription = newDescription;
                _ourDbContext.SaveChanges();
            }

        }
    }
}

