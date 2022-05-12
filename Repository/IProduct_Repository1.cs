using Day1of_WenApi.Model;
using System.Collections.Generic;

namespace Day1of_WenApi.Repository
{
    public interface IProduct_Repository1
    {
        int Delete(int id);
        List<Product> GetAll();
        List<Product> GetAllProductsByCatID(int catid);
        Product GetById(int id);
        int Insert(Product produ);
        int Update(int id, Product produ);
    }
}