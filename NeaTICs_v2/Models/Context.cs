using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace NeaTICs_v2.Models
{
    public class Context : DbContext
    {
        public DbSet<City> Cities { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Goal> Goals { get; set; }
        public DbSet<Informatorio> Informatorio { get; set; }
        public DbSet<InformatorioForm> InformatorioForms { get; set; }
        public DbSet<Institution> Institutions { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<SocialLink> SocialLinks { get; set; }
        public DbSet<SocialType> SocialTypes { get; set; }
        public DbSet<TimeAvailability> TimeAvailabilities { get; set; }
        public DbSet<TimeRange> TimeRanges { get; set; }
        public DbSet<Telephone> Telephones { get; set; }
        public DbSet<University> Universities { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<UserProfile> UsersProfiles { get; set; }
        public DbSet<ContactMessage> ContactMessages { get; set; }

        public Context()
            : base("DefaultConnection")
        {

        }

    }
}