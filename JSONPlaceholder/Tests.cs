using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using NUnit.Framework;

namespace JSONPlaceholder
{
    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void SetUp()
        {
            APIClient.client.BaseAddress = new Uri("http://jsonplaceholder.typicode.com/");
            APIClient.client.DefaultRequestHeaders.Accept.Clear();
            APIClient.client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
        }

        [TearDown]
        public void TearDown()
        {
            APIClient.client.DefaultRequestHeaders.Accept.Clear();
        }

        [Test]
        public async Task GetDataFromPost()
        {
            Post post = await APIClient.GetPost("2");

            Assert.IsNotNull(post);
            Assert.IsNotEmpty(post.Body);
            Assert.AreEqual(post.Title, "qui est esse");
        }

        [Test]
        public async Task GetAllDataFromPost()
        {
            int numberOfPosts = 100;
            List <Post> posts = await APIClient.GetAllPosts();

            Assert.IsNotNull(posts);
            Assert.AreEqual(numberOfPosts, posts.Count);
        }
    }
}
