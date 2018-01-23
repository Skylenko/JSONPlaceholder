using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace JSONPlaceholder
{
    class APIClient
    {
        static void Run()
        {
            client.BaseAddress = new Uri("http://jsonplaceholder.typicode.com/");
            client.DefaultRequestHeaders.Accept.Clear();
            APIClient.client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public static HttpClient client = new HttpClient();

        //public static void ShowPost(Post post)
        //{
        //    Console.WriteLine($"userId: {post.UserId}\tid: " +
        //                      $"{post.Id}\ttitle: {post.Title}\tbody: {post.Body}");
        //}

        public static async Task<Uri> CreatePosts(Post post)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
                "/posts", post);
            response.EnsureSuccessStatusCode();

            return response.Headers.Location;
        }

        public static async Task<Post> GetPost(string id)
        {
            Run();
            Post post = null;
            HttpResponseMessage response = await client.GetAsync($"/posts/{id}");
            if (response.IsSuccessStatusCode)
            {
                post = await response.Content.ReadAsAsync<Post>();
            }
            return post;
        }

        public static async Task<Post> UpdatePost(Post post)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync(
                $"/posts/{post.Id}", post);
        //    response.EnsureSuccessStatusCode();

            post = await response.Content.ReadAsAsync<Post>();
            return post;
        }

       public static async Task<HttpStatusCode> DeletePost(int id)
        {
            HttpResponseMessage response = await client.DeleteAsync(
                $"/post/{id}");
            return response.StatusCode;
        }
    }
}