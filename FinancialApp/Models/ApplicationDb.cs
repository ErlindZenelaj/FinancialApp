 using System;
using Microsoft.EntityFrameworkCore;

namespace FinancialApp.Models
{
	public class ApplicationDb:DbContext
	{
		public ApplicationDb(DbContextOptions options):base(options)
		{
		}

		public DbSet<Transaction> Transactions { get; set; }
		public DbSet<Category> Categories { get; set; }
	}
}

