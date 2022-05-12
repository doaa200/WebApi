using System.Collections.Generic;

namespace Day1of_WenApi.DTO
{
    public class CategoryWithProductNames
    {
        public int Category_Id { get; set; }
        public string Category_Name { get; set; }
        public List<ProductDTO> ProductsName { get; set; } = new List<ProductDTO>();
    }
}
