using System.ComponentModel.DataAnnotations.Schema;

namespace FoodMaster.WebSite.Domain
{
    public class UserClaim
    {
        [Column("user_id")]
        public int UserId { get; set; }
        public User User { get; set; }

        [Column("claim_id")]
        public int ClaimId { get; set; }
        public Role Claim { get; set; }
    }
}