using ApiExample.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiExample.Data
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options) // This constructor is used to pass the options to the base DbContext class
		{
			
		}

		public DbSet<SuperHero> SuperHeroes { get; set; } // This will create a table named "SuperHeroes" in the database
	}
}
