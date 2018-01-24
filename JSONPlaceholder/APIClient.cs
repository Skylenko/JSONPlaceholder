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
        public static void Main()
        {
        }
        public static HttpClient client = new HttpClient();

        public static async Task<Uri> CreatePosts(Post post)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync("/posts", post);
            response.EnsureSuccessStatusCode();

            return response.Headers.Location;
        }

        public static async Task<List<Post>> GetAllPosts()
        {
            HttpResponseMessage response = await client.GetAsync($"/posts");
            List<Post> posts = await response.Content.ReadAsAsync<List<Post>>();

            return posts;
        }

        public static async Task<Post> GetPost(string id)
        {
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

        public static async Task<HttpResponseMessage> DeletePost(int id)
        {
            HttpResponseMessage response = await client.DeleteAsync($"/post/{id}");
            return response;
        }
    }
}