using System.ComponentModel.DataAnnotations.Schema;

namespace FoodMaster.WebSite.Domain
{
    public class Claim
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("value")]
        public string Value { get; set; }

    }
}