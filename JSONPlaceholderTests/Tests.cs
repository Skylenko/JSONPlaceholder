using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using JSONPlaceholderAPIClient;
using NUnit.Framework;

namespace JSONPlaceholderTests
{
    [TestFixture]
    public class Tests
    {
        [OneTimeSetUp]
        public void SetUp()
        {
           ApiClient.Put();
        }

        [Test]
        public async Task CreatePost_ShouldReturnSuccessfulCode()
        {
            CreatePostModel post = new CreatePostModel(999, "new title", "same text");

            var response = await ApiClient.CreatePosts(post);

            Assert.AreEqual(response.StatusCode, HttpStatusCode.Created);
        }

        [Test]
        public async Task CreatePost_ShouldReturnFullNewPost()
        {
            CreatePostModel post = new CreatePostModel(999, "new title", "same text");

            var response = await ApiClient.CreatePosts(post);

            Assert.IsNotEmpty(response.DeserealizedContent.Result.ToString());
        }

        [Test]
        public async Task GetPost_ShouldHaveNotNullPost_UsingExistId()
        {
            var response = await ApiClient.GetPost("1");

            Assert.IsNotNull(response.DeserealizedContent.Result.Body);
        }

        [Test]
        public async Task GetPost_ShouldHaveSuccessfullCode_UsingExistId()
        {
            var response = await ApiClient.GetPost("10");

            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
        }

        [Test]
        public async Task GetPost_ShouldHaveNoSuccessfulCode_UsingNoExistId()
        {
            var response = await ApiClient.GetPost("0");

            Assert.AreEqual(response.StatusCode, HttpStatusCode.NotFound);
        }

        [Test]
        public async Task GetPost_ShouldHaveNotEmptyBody_UsingExistId()
        {
            var response = await ApiClient.GetPost("4");

            Assert.IsNotEmpty(response.DeserealizedContent.Result.Title);
        }

        [Test]
        public async Task GetPost_ShouldHaveSomeTitle_UsingExistId()
        {
            string title = "qui est esse";
            var response = await ApiClient.GetPost("2");

            Assert.AreEqual(response.DeserealizedContent.Result.Title, title);
        }

        [Test]
        public async Task GetAllPosts_ShouldBeNotNullPosts_PostsExist()
        {
            var response = await ApiClient.GetAllPosts();

            Assert.IsNotNull(response);
        }

        [Test]
        public async Task GetAllPosts_ShouldBeEqualsNumberOfPosts_PostsExist()
        {
            int numberOfPosts = 100;

            var response = await ApiClient.GetAllPosts();

            Assert.AreEqual(numberOfPosts, response.DeserealizedContent.Result.Count);
        }

        [Test]
        public async Task GetAllPosts_ShouldHasSuccessfulCode_PostsExist()
        {
            var response = await ApiClient.GetAllPosts();

            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
        }

        [Test]
        public async Task UpdatePost_ShouldReturnFullUpdatePost()
        {
            FullPostModel post = new FullPostModel(10, 1, "wert", "24");

            var response = await ApiClient.UpdatePost(post);

            Assert.IsNotEmpty(response.DeserealizedContent.ToString());
        }

        [Test]
        public async Task UpdatePost_ShouldReturnSuccessfulCode()
        {
            FullPostModel post = new FullPostModel(23, 7, "6", "789");

            var response = await ApiClient.UpdatePost(post);

            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
        }

        [Test]
        public async Task UpdatePost_ShouldReturnNotSuccessfulCode()
        {
            FullPostModel post = new FullPostModel(10, 0, "123", "poiu");

            var response = await ApiClient.UpdatePost(post);

            Assert.AreEqual(response.StatusCode, HttpStatusCode.NotFound);
        }

        [Test]
        public async Task UpdatePost_ShouldBodyEqualsNewString()
        {
            FullPostModel post = new FullPostModel(10, 5, "123", "5646");

            string newBody = post.Body;

            var response = await ApiClient.UpdatePost(post);

            Assert.AreEqual(newBody, response.DeserealizedContent.Result.Body);
        }

        [Test]
        public async Task DeletePost_ShoudReturnSuccessfulCode()
        {
            var response = await ApiClient.DeletePost(2);

            Assert.AreEqual(response.StatusCode, HttpStatusCode.NoContent);
        }

        [Test]
        public async Task DeletePost_ShoudReturnNoSuccessfulCode_ByUsingNoExistId()
        {
            var response = await ApiClient.DeletePost(0);

            Assert.AreEqual(response.StatusCode, HttpStatusCode.NotFound);
        }

        [Test]
        public async Task DeletePost_ShoudReturnNullDeletedPost()
        {
            var response = await ApiClient.DeletePost(7);

            Assert.IsEmpty(response.DeserealizedContent.Result.ToString());
        }
    }
}
