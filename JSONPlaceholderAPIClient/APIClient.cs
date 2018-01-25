using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace JSONPlaceholderAPIClient
{
   public class ApiClient
    {
        public static HttpClient Client = new HttpClient();

        public static void Put()
        {
            Client.BaseAddress = new Uri("http://jsonplaceholder.typicode.com/");
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static async Task<HttpResponseMessage> CreatePosts(CreatePostModel post)
        {
            HttpResponseMessage response = await Client.PostAsJsonAsync("/posts", post);

            return response;
        }

        public static async Task<HttpResponseMessage> GetAllPosts()
        {
            HttpResponseMessage response = await Client.GetAsync("/posts");
            return response;
        }

        public static async Task<HttpResponseMessage> GetPost(string id)
        {
            HttpResponseMessage response = await Client.GetAsync($"/posts/{id}");
            return response;
        }

        public static async Task<HttpResponseMessage> UpdatePost(FullPostModel post)
        {
            HttpResponseMessage response = await Client.PutAsJsonAsync($"/posts/{post.Id}", post);
            return response;
        }

        public static async Task<HttpResponseMessage> DeletePost(int id)
        {
            HttpResponseMessage response = await Client.DeleteAsync($"/post/{id}");
            return response;
        }
    }
}