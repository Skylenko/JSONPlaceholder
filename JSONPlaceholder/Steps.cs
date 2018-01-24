using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace JSONPlaceholder
{
    public class Steps1
    {
        static void Main()
        {
            GetPosts().GetAwaiter().GetResult();
        }

        static async Task PostPosts()
        {
                Post post = new Post(9000, 101, "Widgets", "empty");

                var url = await APIClient.CreatePosts(post);

                Console.WriteLine($"Created at {url}");
            Console.ReadLine();
        }

        static async Task GetPost()
        {
            Post post = null;

            post = await APIClient.GetPost("2");
            APIClient.ShowPost(post);

            Console.ReadLine();
        }

        static async Task GetPosts()
        {
            Post post = null;

            post = await APIClient.GetPosts();
            APIClient.ShowPost(post);

            Console.ReadLine();
        }

        static async Task PutPosts()
        {
            Post post = null;
          
                Console.WriteLine("Updating title: ");
                post.Title = "80";
                await APIClient.UpdatePost(post);
        }

        static async Task DeletePosts()
        {
            var statusCode = await APIClient.DeletePost(7);
            Console.WriteLine($"Deleted (HTTP Status = {(int)statusCode})"); Console.ReadLine();
        }
    }
}

