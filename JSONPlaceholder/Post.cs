using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace JSONPlaceholder
{
    public class Post
    {
        internal List<Post> Posts;

        public int UserId { get; set; }

        public int Id { get; }

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