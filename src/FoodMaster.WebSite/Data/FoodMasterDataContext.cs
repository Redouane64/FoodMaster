
using FoodMaster.WebSite.Domain;

using Microsoft.EntityFrameworkCore;

namespace FoodMaster.WebSite.Data
{
    public class FoodMasterDataContext : DbContext
    {
        public FoodMasterDataContext(DbContextOptions<FoodMasterDataContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .ToTable("users");

            modelBuilder.Entity<Claim>()
                .ToTable("claims");

            modelBuilder.Entity<Role>()
                .ToTable("roles");

            modelBuilder.Entity<UserClaim>()
                .ToTable("user_claims")
                .HasKey(x => new { x.UserId, x.ClaimId });

            modelBuilder.Entity<UserRole>()
                .ToTable("user_roles")
                .HasKey(x => new { x.UserId, x.RoleId });

            modelBuilder.Entity<Cart>()
                .ToTable("carts");

            modelBuilder.Entity<CartItem>()
                .ToTable("cart_items");

            modelBuilder.Entity<Category>()
                .ToTable("categories");

            modelBuilder.Entity<Menu>()
                .ToTable("menus");

            modelBuilder.Entity<MealIngredient>()
                .ToTable("meal_ingredients");

            modelBuilder.Entity<Meal>()
                .ToTable("meals");

            modelBuilder.Entity<Ingredient>()
                .ToTable("ingredients");

            modelBuilder.Entity<Order>()
                .ToTable("orders");

            modelBuilder.Entity<OrderItem>()
                .ToTable("order_items");

        }
    }
}
