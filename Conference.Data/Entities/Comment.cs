using System;

namespace Conference.Data.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string CommenterName { get; set; }
        public string CommentText { get; set; }
        public DateTime CommentTimeStamp { get; set; }
        public Session Session { get; set; }
    }
}
