using Day1of_WenApi.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Day1of_WenApi.Repository
{
    public class Category_Repository : ICategory_Repository
    {
        SouqEntity context;
        public Category_Repository(SouqEntity _context)
        {
            context = _context;
        }
        public List<Category> GetAll()
        {
            return context.categories.ToList();
        }

        public Category GetById(int id)
        {
            return context.categories.Include(p => p.products).FirstOrDefault(x => x.Id == id);
        }



        public int Insert(Category catog)
        {
            context.categories.Add(catog);
            return context.SaveChanges();
        }

        public int Update(int id, Category catog)
        {
            Category oldcategory = GetById(id);
            if (oldcategory != null)
            {
                oldcategory.Name = catog.Name;
                oldcategory.Brand = catog.Brand;


                return context.SaveChanges();
            }
            return 0;
        }

        public int Delete(int id)
        {
            Category oldcategory = GetById(id);
            context.categories.Remove(oldcategory);
            return context.SaveChanges();
        }
    }
}
