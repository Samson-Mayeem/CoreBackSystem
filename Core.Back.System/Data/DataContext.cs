using Core.Back.System.Models;
using Microsoft.EntityFrameworkCore;

namespace Core.Back.System.Data
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions options) : base(options)
		{
		}
		public DbSet<Payment> Payments { get; set; }
	}
}
