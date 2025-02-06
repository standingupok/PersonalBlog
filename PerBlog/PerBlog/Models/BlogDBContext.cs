using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using PerBlog.Models;
namespace PerBlog.Models
{
    public class BlogDBContext : IdentityDbContext<AppUser>
    {
        public BlogDBContext(DbContextOptions<BlogDBContext> options) : base(options) { }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<PerBlog.Models.User> User { get; set; }
        public DbSet<PerBlog.Models.Login> Login { get; set; }
    }
}
