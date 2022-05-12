using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Day1of_WenApi.Model
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        [JsonIgnore]
        public virtual List<Product> products { get; set; }
    }
}
