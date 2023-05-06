using Labb3_RestApi.Models;
using Microsoft.EntityFrameworkCore;

namespace Labb3_RestApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<Links> Links { get; set; }
        public DbSet<Person> Persons { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().HasData(
                new Person
                {
                    PersonId = 1,
                    FirstName = "Oskar",
                    LastName = "Åhling",
                    Phone = "070-2138149"
                },
                new Person
                {
                    PersonId = 2,
                    FirstName = "Ina",
                    LastName = "Nilsson",
                    Phone = "074-2251267"
                }, 
                new Person
                {
                    PersonId = 3,
                    FirstName = "Anakin",
                    LastName = "Skywalker",
                    Phone = "076-7643267"
                }, 
                new Person
                {
                    PersonId = 4,
                    FirstName = "Leia",
                    LastName = "Solo",
                    Phone = "072-1234567"
                });
            modelBuilder.Entity<Interest>().HasData(
                new Interest
                {
                    InterestId = 1,
                    FKPerson = 1,
                    Title = "MMA",
                    Description = "Ultimate competition combined of all martial arts in the world"
                    
                },
                new Interest
                {
                    InterestId = 2,
                    FKPerson = 1,
                    Title = "Gaming",
                    Description = "There is plethora of games that i like, but i prefer competetive once"
                },
                new Interest
                {
                    InterestId = 3,
                    FKPerson = 1,
                    Title = "Muaythai",
                    Description = "Coding holds a huge intrest considering its my potential future"
                }, 
                new Interest
                {
                    InterestId = 4,
                    FKPerson = 2,
                    Title = "RealityShows",
                    Description = "Reality shows are very fun because i like to see drama"
                },  
                new Interest
                {
                    InterestId = 5,
                    FKPerson = 3,
                    Title = "DarkSide",
                    Description = "Killing younglings for the good of the future"
                },  
                new Interest
                {
                    InterestId = 6,
                    FKPerson = 4,
                    Title = "Rebellions",
                    Description = "I like rebellions and kissing siblings"
                },  
                new Interest
                {
                    InterestId = 7,
                    FKPerson = 2,
                    Title = "Stargazing",
                    Description = "Star constelations are beautiful"
                });
            modelBuilder.Entity<Links>().HasData(
                new Links
                {
                    LinkId = 1,
                    FKPersonId=1,
                    FKinterestId=1,
                    Title="MMA clip",
                    URL= "https://www.youtube.com/watch?v=LNySNc76NNU"
                },
                new Links
                {
                    LinkId = 2,
                    FKPersonId = 2,
                    FKinterestId = 2,
                    Title = "Gaming",
                    URL = "https://eu.shop.battle.net/en-gb?from=root"
                },
                new Links
                {
                    LinkId = 3,
                    FKPersonId = 3,
                    FKinterestId = 3,
                    Title = "Muaythai",
                    URL = "https://www.facebook.com/Drakstadenmuaythai/?locale=sv_SE"
                },
                new Links
                {
                    LinkId = 4,
                    FKPersonId = 4,
                    FKinterestId = 4,
                    Title = "RealityShows",
                    URL = ""
                },
                new Links
                {
                    LinkId = 5,
                    FKPersonId = 1,
                    FKinterestId = 3,
                    Title = "",
                    URL = ""
                },
                new Links
                {
                    LinkId = 6,
                    FKPersonId = 1,
                    FKinterestId = 5,
                    Title = "DarkSide",
                    URL = "https://www.youtube.com/watch?v=Ogcd-etnFLw"
                },
                new Links
                {
                    LinkId = 7,
                    FKPersonId = 2,
                    FKinterestId = 7,
                    Title = "Rebellions",
                    URL = "https://www.youtube.com/watch?v=m8drjLtX1Wc"
                },
                new Links
                {
                    LinkId = 8,
                    FKPersonId = 4,
                    FKinterestId = 6,
                    Title = "Rebellion",
                    URL = "https://www.youtube.com/watch?v=Ogcd-etnFLw"
                });
        }
    }
}
