using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace FoodMaster.WebSite.Domain
{
    public class Meal
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("price")]
        public decimal Price { get; set; }

        [JsonPropertyName("category")]
        public int Category { get; set; }

        [JsonPropertyName("ingredients")]
        public IEnumerable<int> Ingredients { get; set; }

        [JsonPropertyName("calories")]
        public float Calories { get; set; }

    }
}