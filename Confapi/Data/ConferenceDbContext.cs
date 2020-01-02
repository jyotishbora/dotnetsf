using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Confapi.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Confapi.Data
{
    public class ConferenceDbContext : DbContext
    {
        public ConferenceDbContext(DbContextOptions<ConferenceDbContext> options) : base(options)
        {

        }

        public DbSet<Speaker> Speakers { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Speaker>()
                .HasData(new Speaker
                {
                    Id = 1,
                    Email = "John@mail.com",
                    Name = "John",
                    Sessions = new List<Session>
                    {
                        new Session
                        {
                            Id = 1,
                            Title = "Introduction to Asp.net core",
                            Location = "Room1",
                            Track = "Web Development",
                            Comments = new List<Comment>
                            {
                                new Comment
                                {
                                    Id = 1,
                                    CommenterName = "David",
                                    CommentText = "Very Excited to attend this talk",
                                    CommentTimeStamp = DateTime.Now
                                   
                                }
                            }
                        }
                    }

                });


            base.OnModelCreating(modelBuilder);
        }
    }
}
