using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace JSONPlaceholderAPIClient
{
   public class APIClient
    {
        public static HttpClient client = new HttpClient();

        public static void Put()
        {
            client.BaseAddress = new Uri("http://jsonplaceholder.typicode.com/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static async Task<HttpResponseMessage> CreatePosts(CreatePostModel post)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync("/posts", post);
            return response;
        }

        public static async Task<HttpResponseMessage> GetAllPosts()
        {
            HttpResponseMessage response = await client.GetAsync($"/posts");
            return response;
        }

        public static async Task<HttpResponseMessage> GetPost(string id)
        {
            HttpResponseMessage response = await client.GetAsync($"/posts/{id}");
            return response;
        }

        public static async Task<HttpResponseMessage> UpdatePost(FullPostModel post)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync($"/posts/{post.Id}", post);
            return response;
        }

        public static async Task<HttpResponseMessage> DeletePost(int id)
        {
            HttpResponseMessage response = await client.DeleteAsync($"/post/{id}");
            return response;
        }
    }
}