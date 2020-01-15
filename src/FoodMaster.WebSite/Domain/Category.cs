using System.Text.Json.Serialization;

namespace FoodMaster.WebSite.Domain
{
    public class Category
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}