using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace JSONPlaceholder
{
    class APIClient
    {
        public static HttpClient client = new HttpClient();

        public static async Task RunAsync()
        {
            client.BaseAddress = new Uri("http://jsonplaceholder.typicode.com/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

        }

        public static void ShowPost(Post post)
        {
            Console.WriteLine($"userId: {post.UserId}\tid: " +
                              $"{post.Id}\ttitle: {post.Title}\tbody: {post.Body}");
        }

        public static async Task<Uri> CreatePosts(Post post)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
                "/posts", post);
            response.EnsureSuccessStatusCode();

            return response.Headers.Location;
        }


        public static async Task<Post> GetPosts()
        {
            await RunAsync();

            Post post = null;
            HttpResponseMessage response = await client.GetAsync($"/posts");
            if (response.IsSuccessStatusCode)
            {
                List<Post> posts = await JsonConvert.DeserializeObjectAsync<List<Post>>(IList);
            }
            return post;
        }

        public static async Task<Post> GetPost(string id)
        {
            await RunAsync();

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