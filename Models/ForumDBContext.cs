using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace forumAspMVC.Models
{
    public class ForumDBContext : DbContext
    {
        public ForumDBContext() : base("ForumConectionString")
        {

        }
        public DbSet<User> users { get; set; }

        public DbSet<Category> categories { get; set; }

        public DbSet<Comment> comments { get; set; }
        
        public DbSet<Post> posts { get; set; }
    }
}