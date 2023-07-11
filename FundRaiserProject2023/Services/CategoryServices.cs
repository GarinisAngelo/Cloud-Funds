using FundRaiserProject2023.DbContexts;
using FundRaiserProject2023.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundRaiserProject2023.Services
{
    public class CategoryServices
    {
        private readonly OurDbContext _ourDbContext;


        public CategoryServices(OurDbContext ourDbContext)
        {
            _ourDbContext = ourDbContext;
        }

        public void Create()
        {
            var categoryServices = new Backer(); //this is needed to be dynamic from the forms

            _ourDbContext.Backers.Add(categoryServices);
            _ourDbContext.SaveChanges();
        }

        public void Delete() // this will need a change for the final version
        {
            int categoryID = 5; //this is needed to be dynamic from the forms
            var category = _ourDbContext
                .Categories
                .Where(p => p.Id == categoryID)
                .FirstOrDefault();
            if (category != null)
            {
                _ourDbContext.Categories.Remove(category);
                _ourDbContext.SaveChanges();
            }

        }

        public void Read()
        {

            List<Category> categories = _ourDbContext.Categories.ToList();

            categories.ForEach(categories =>
            { Console.WriteLine($" Category.Id = {categories.Id}"); });  // this will need a change for the final version

        }

        public void Update() // this will need a change for the final version
        {
            int categoryId = 5; //this is needed to be dynamic from the forms
            string newDescription = "category"; //this is needed to be dynamic from the forms

            var category = _ourDbContext
                .Categories
                .Where(p => p.Id == categoryId)
                .FirstOrDefault();
            if (category != null)
            {
                category.CategoryName = newDescription;
                _ourDbContext.SaveChanges();
            }

        }
    }
}