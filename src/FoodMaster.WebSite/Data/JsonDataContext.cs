using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

using FoodMaster.WebSite.Domain;

namespace FoodMaster.WebSite.Data
{
    public class JsonDataContext
    {
        private const string filename = "data.json";

        public static JsonDataContext Create()
        {
            var jsonStream = File.ReadAllText(filename);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = false
            };

            return JsonSerializer.Deserialize<JsonDataContext>(jsonStream, options);
        }

        public async Task WriteToUnderlyingFileAsync()
        {
            using var file = File.OpenWrite(filename);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = false,
                IgnoreNullValues = false,
                WriteIndented = true
            };

            await JsonSerializer.SerializeAsync<JsonDataContext>(file, this, options);
        }

        [JsonPropertyName("meals")]
        public ICollection<Meal> Meals { get; set; }

        [JsonPropertyName("ingredients")]
        public ICollection<Ingredient> Ingredients { get; set; }

        [JsonPropertyName("users")]
        public ICollection<User> Users { get; set; }

        [JsonPropertyName("carts")]
        public ICollection<Cart> Carts { get; set; }

        [JsonPropertyName("orders")]
        public ICollection<Order> Orders { get; set; }
    }
}
