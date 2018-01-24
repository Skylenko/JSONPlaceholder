using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using NUnit.Framework;

namespace JSONPlaceholder
{
    [TestFixture]
    public class Tests
    {
        [OneTimeSetUp]
        public void SetUp()
        {
            APIClient.Put();
        }

        [Test]
        public async Task CreateNewDataInPost()
        {
            string path = APIClient.client.BaseAddress + "posts/" + "101";

            Post post = new Post(999, 101, "new title", "same text");
            HttpResponseMessage responseMessage = await APIClient.CreatePosts(post);

            Assert.AreEqual(responseMessage.Headers.Location, path);
            Assert.AreEqual((int)(responseMessage.StatusCode), 201);
        }

        [Test]
        public async Task GetDataFromPost()
        {
            HttpResponseMessage responseMessage = await APIClient.GetPost("2");
            Post post = await responseMessage.Content.ReadAsAsync<Post>();

            Assert.IsNotNull(responseMessage);
            Assert.AreEqual((int)(responseMessage.StatusCode), 200);
            Assert.IsNotEmpty(post.Body);
            Assert.AreEqual(post.Title, "qui est esse");
        }

        [Test]
        public async Task GetAllDataFromPost()
        {
            int numberOfPosts = 100;

            HttpResponseMessage responseMessage = await APIClient.GetAllPosts();
            List<Post> posts = await responseMessage.Content.ReadAsAsync<List<Post>>();

            Assert.IsNotNull(posts);
            Assert.AreEqual(numberOfPosts, posts.Count);
            Assert.AreEqual((int)(responseMessage.StatusCode), 200);
        }
    }
}
