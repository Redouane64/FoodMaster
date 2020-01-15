using System.Text.Json.Serialization;

namespace FoodMaster.WebSite.Domain
{
    public class Ingredient
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }

    }
}