using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace JSONPlaceholder
{
    public class Post
    {
        public int UserId { get; set; }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public Post(int userId, int id, string title, string body)
        {
            UserId = userId;
            Id = id;
            Title = title;
            Body = body;
        }
    }
}