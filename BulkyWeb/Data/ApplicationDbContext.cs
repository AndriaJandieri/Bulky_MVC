using BulkyWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyWeb.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{

		}
		public DbSet<Category> Categories { get; set; }
		public DbSet<User> Users { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Category>().HasData(
				new Category { CategoryId = 1, CategoryName = "Action", DisplayOrder = 1 },
				new Category { CategoryId = 2, CategoryName = "Comedy", DisplayOrder = 3 },
				new Category { CategoryId = 3, CategoryName = "Romantic", DisplayOrder = 7 },
				new Category { CategoryId = 4, CategoryName = "War", DisplayOrder = 4 },
				new Category { CategoryId = 5, CategoryName = "Anime", DisplayOrder = 2 },
				new Category { CategoryId = 6, CategoryName = "Detective", DisplayOrder = 5 },
				new Category { CategoryId = 7, CategoryName = "Documentary", DisplayOrder = 6 }
				);

			modelBuilder.Entity<User>().HasData(
				new User { UserId = 1, UserName = "Johny", Email = "Johny@email.com" },
				new User { UserId = 2, UserName = "Lussie", Email = "Lussia@email.com" },
				new User { UserId = 3, UserName = "Ritta", Email = "Ritta@email.com" },
				new User { UserId = 4, UserName = "Josh", Email = "Josh@email.com" },
				new User { UserId = 5, UserName = "Sophie", Email = "Sophie@email.com" },
				new User { UserId = 6, UserName = "Steve", Email = "Steve@email.com" },
				new User { UserId = 7, UserName = "Diana", Email = "Diana@email.com" }
				);
		}
	}
}
