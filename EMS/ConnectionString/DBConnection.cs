using EMS.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EMS.ConnectionString
{
	public class DBConnection : IdentityDbContext<IdentityUser, IdentityRole, string,
		IdentityUserClaim<string>, IdentityUserRole<string>,
	 IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
	{
		public DBConnection(DbContextOptions<DBConnection> options)
		   : base(options)
		{
		}
		public DbSet<EmployeeInfo> EmployeeInfo { get; set; }
		public DbSet<SetUpDepertment> SetUpDepertment {  get; set; }
		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
			builder.Entity<IdentityUser>();

		}
	}
}