using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ASP.NET_FinalProject.Models
{
    public class ModelDbContext : DbContext
    {
        public ModelDbContext():base("ModelDb")
        { }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogCategory> BlogCategories { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ContactUs> Contacts { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<ModelCategory> ModelCategories { get; set; }
        public DbSet<NavbarDropDownItem> NavbarDropDownItems { get; set; }
        public DbSet<NavbarItem> NavbarItems { get; set; }
        public DbSet<Personal> Personal { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}