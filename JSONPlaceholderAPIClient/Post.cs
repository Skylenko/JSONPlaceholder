namespace JSONPlaceholderAPIClient
{
    public class FullPostModel
    {
        public int UserId { get; set; }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public FullPostModel(int userId, int id, string title, string body)
        {
            UserId = userId;
            Id = id;
            Title = title;
            Body = body;
        }
    }

    public class CreatePostModel
    {
        public int UserId { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public CreatePostModel(int userId, string title, string body)
        {
            UserId = userId;
            Title = title;
            Body = body;
        }
    }
}