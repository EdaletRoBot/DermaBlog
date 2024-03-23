using DermaBlog.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace DermaBlog.DAL
{
    public class AppDbContext : IdentityDbContext<AppUser>
	{
		public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
		{

        }
        public DbSet<Thumb> Thumbs { get; set; }
		public DbSet<Post> Posts { get; set; }
		public DbSet<Blog> Blogs { get; set; }
		public DbSet<About> Abouts { get; set; }
        public DbSet<Contact> Contacts { get; set; }
    }
}
