using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net;

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

        public static async Task<ResponseContainer<FullPostModel>> CreatePosts(CreatePostModel post)
        {
            HttpResponseMessage response = await Client.PostAsJsonAsync("/posts", post);

            ResponseContainer<FullPostModel> responseContainer = new ResponseContainer<FullPostModel>(response);

            return responseContainer;
        }

        public static async Task<ResponseContainer<List<FullPostModel>>> GetAllPosts()
        {
            HttpResponseMessage response = await Client.GetAsync("/posts");

            var resultResponseContainer = new ResponseContainer<List<FullPostModel>>(response);

            return resultResponseContainer;
        }

        public static async Task<ResponseContainer<FullPostModel>> GetPost(string id)
        {
            HttpResponseMessage response = await Client.GetAsync($"/posts/{id}");

            var resultResponseContainer = new ResponseContainer<FullPostModel>(response);

            return resultResponseContainer;
        }

        public static async Task<ResponseContainer<FullPostModel>> UpdatePost(FullPostModel post)
        {
            HttpResponseMessage response = await Client.PutAsJsonAsync($"/posts/{post.Id}", post);

            var resultResponseContainer = new ResponseContainer<FullPostModel>(response);

            return resultResponseContainer;
        }

        public static async Task<ResponseContainer<FullPostModel>> DeletePost(int id)
        {
            HttpResponseMessage response = await Client.DeleteAsync($"/post/{id}");

            var resultResponseContainer = new ResponseContainer<FullPostModel>(response);
           
            return resultResponseContainer;
        }
    }
}