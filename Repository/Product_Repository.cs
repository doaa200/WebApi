using Day1of_WenApi.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Day1of_WenApi.Repository
{
    public class Product_Repository : IProduct_Repository
    {
        SouqEntity context;
        public Product_Repository(SouqEntity _context)
        {
            context = _context;
        }
        public List<Product> GetAll()
        {
            return context.productss.ToList();
        }
        public List<Product> GetAllProductsByCatID(int catid)
        {
            return context.productss.Where(p => p.CatID == catid).ToList();
        }
        public Product GetById(int id)
        {
            return context.productss.FirstOrDefault(x => x.Id == id);
        }

        public int Insert(Product produ)
        {
            context.productss.Add(produ);
            return context.SaveChanges();
        }

        public int Update(int id, Product produ)
        {
            Product oldproduct = GetById(id);
            if (oldproduct != null)
            {
                oldproduct.Name = produ.Name;
                oldproduct.price = produ.price;
                oldproduct.Description = produ.Description;
                oldproduct.Quantity = produ.Quantity;

                return context.SaveChanges();
            }
            return 0;
        }

        public int Delete(int id)
        {
            Product oldproduct = GetById(id);
            context.productss.Remove(oldproduct);
            return context.SaveChanges();
        }




    }
}
