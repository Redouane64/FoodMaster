using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodMaster.WebSite.Domain
{
    public class Menu
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("category_id")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<Meal> Meals { get; set; }
    }
}
