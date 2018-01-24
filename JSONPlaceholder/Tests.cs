using System.Collections.Generic;
using System.Net.Http;
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

        //[Test]
        //public async Task CreateNewDataInPost()
        //{
        //    CreatePostModel post = new CreatePostModel(999, 101, "new title", "same text");
        //    HttpResponseMessage responseMessage = await APIClient.CreatePosts(post);

        //    Assert.AreEqual((int)(responseMessage.StatusCode), 200);
        //}

        [Test]
        public async Task GetDataFromPost()
        {
            HttpResponseMessage responseMessage = await APIClient.GetPost("2");
            CreatePostModel post = await responseMessage.Content.ReadAsAsync<CreatePostModel>();

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
            List<CreatePostModel> posts = await responseMessage.Content.ReadAsAsync<List<CreatePostModel>>();

            Assert.IsNotNull(posts);
            Assert.AreEqual(numberOfPosts, posts.Count);
            Assert.AreEqual((int)(responseMessage.StatusCode), 200);
        }
    }
}
