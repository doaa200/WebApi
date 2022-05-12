using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Day1of_WenApi.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int price { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int Quantity { get; set; }

        [ForeignKey("category")]
        public int CatID { get; set; }


        [JsonIgnore]
        public virtual Category category { get; set; }
    }
}
