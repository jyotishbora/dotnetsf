using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conference.Data;
using Conference.Data.Entities;

namespace Confapi.Data
{
    public class ConfSeeder
    {
        private readonly ConferenceDbContext _ctx;

        public ConfSeeder(ConferenceDbContext ctx)
        {
            _ctx = ctx;
        }

        public void Seed()
        {
            _ctx.Database.EnsureCreated();
            if (!_ctx.Speakers.Any())
            {
                var speaker = new Speaker
                {
                    Email = "John@mail.com",
                    Name = "John",


                };
                var session1 = new Session
                {

                    Title = "Introduction to Asp.net core",
                    Location = "Room1",
                    Track = "Web Development",
                    Speaker = speaker
                };

                var session2 = new Session
                {

                    Title = "Introduction to node.js",
                    Location = "Room2",
                    Track = "Web Development",
                    Speaker = speaker

                };


                var comment1 = new Comment
                {
                    CommenterName = "Mike",
                    CommentText = "Cannot wait to learn about Node.js",
                    CommentTimeStamp = DateTime.Now,
                    Session = session1

                };
                var comment2 = new List<Comment>()
                {
                    new Comment
                    {

                        CommenterName = "David",
                        CommentText = "Very Excited to attend this talk",
                        CommentTimeStamp = DateTime.Now,
                        Session = session2

                    },

                    new Comment
                    {
                        CommenterName = "Lisa",
                        CommentText = "Cool!!",
                        CommentTimeStamp = DateTime.Now,
                        Session = session2

                    }
                };



                _ctx.Speakers.Add(speaker);
                _ctx.Sessions.AddRange(new[] {session1, session2});
                _ctx.Comments.AddRange(comment2);
                _ctx.Comments.Add(comment1);


            }

            _ctx.SaveChanges();
        }
        

    }
}
