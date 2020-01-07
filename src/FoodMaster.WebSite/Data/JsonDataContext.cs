using FoodMaster.WebSite.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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
            await JsonSerializer.SerializeAsync<JsonDataContext>(file, this);
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
