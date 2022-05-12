using Day1of_WenApi.Model;
using System.Collections.Generic;

namespace Day1of_WenApi.Repository
{
    public interface ICategory_Repository
    {
        int Delete(int id);
        List<Category> GetAll();
        Category GetById(int id);
        int Insert(Category catog);
        int Update(int id, Category catog);
    }
}