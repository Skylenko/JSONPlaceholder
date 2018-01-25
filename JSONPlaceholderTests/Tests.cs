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

            HttpResponseMessage responseMessage = await ApiClient.CreatePosts(post);

            Assert.AreEqual(responseMessage.StatusCode, HttpStatusCode.OK);
        }

        [Test]
        public async Task CreatePost_ShouldReturnFullNewPost()
        {
            CreatePostModel post = new CreatePostModel(999, "new title", "same text");

            HttpResponseMessage responseMessage = await ApiClient.CreatePosts(post);
            FullPostModel fullPost = await responseMessage.Content.ReadAsAsync<FullPostModel>();

            Assert.IsNotEmpty(fullPost.ToString());
        }

        [Test]
        public async Task GetPost_ShouldHaveNotNullPost_UsingExistId()
        {
            HttpResponseMessage responseMessage = await ApiClient.GetPost("1");
            FullPostModel post = await responseMessage.Content.ReadAsAsync<FullPostModel>();

            Assert.IsNotNull(post);
        }

        [Test]
        public async Task GetPost_ShouldHaveSuccessfullCode_UsingExistId()
        {
            HttpResponseMessage responseMessage = await ApiClient.GetPost("10");

            Assert.AreEqual(responseMessage.StatusCode, HttpStatusCode.OK);
        }

        [Test]
        public async Task GetPost_ShouldHaveNoSuccessfulCode_UsingNoExistId()
        {
            HttpResponseMessage responseMessage = await ApiClient.GetPost("0");

            Assert.AreEqual(responseMessage.StatusCode, HttpStatusCode.NotFound);
        }

        [Test]
        public async Task GetPost_ShouldHaveNotEmptyBody_UsingExistId()
        {
            HttpResponseMessage responseMessage = await ApiClient.GetPost("4");
            FullPostModel post = await responseMessage.Content.ReadAsAsync<FullPostModel>();

            Assert.IsNotEmpty(post.Body);
        }

        [Test]
        public async Task GetPost_ShouldHaveSomeTitle_UsingExistId()
        {
            string title = "qui est esse";
            HttpResponseMessage responseMessage = await ApiClient.GetPost("2");
            FullPostModel post = await responseMessage.Content.ReadAsAsync<FullPostModel>();

            Assert.AreEqual(post.Title, title);
        }

        [Test]
        public async Task GetAllPosts_ShouldBeNotNullPosts_PostsExist()
        {
            HttpResponseMessage responseMessage = await ApiClient.GetAllPosts();
            List<FullPostModel> posts = await responseMessage.Content.ReadAsAsync<List<FullPostModel>>();

            Assert.IsNotNull(posts);
        }

        [Test]
        public async Task GetAllPosts_ShouldBeEqualsNumberOfPosts_PostsExist()
        {
            int numberOfPosts = 100;

            HttpResponseMessage responseMessage = await ApiClient.GetAllPosts();
            List<FullPostModel> posts = await responseMessage.Content.ReadAsAsync<List<FullPostModel>>();

            Assert.AreEqual(numberOfPosts, posts.Count);
        }

        [Test]
        public async Task GetAllPosts_ShouldHasSuccessfulCode_PostsExist()
        {
            HttpResponseMessage responseMessage = await ApiClient.GetAllPosts();

            Assert.AreEqual(responseMessage.StatusCode, HttpStatusCode.OK);
        }

        [Test]
        public async Task UpdatePost_ShouldReturnFullUpdatePost()
        {
            FullPostModel post = new FullPostModel(10, 5, "123", "789");

            HttpResponseMessage responseMessage = await ApiClient.UpdatePost(post);
            FullPostModel fullPost = await responseMessage.Content.ReadAsAsync<FullPostModel>();

            Assert.IsNotEmpty(fullPost.ToString());
        }

        [Test]
        public async Task UpdatePost_ShouldReturnSuccessfulCode()
        {
            FullPostModel post = new FullPostModel(10, 5, "123", "789");

            HttpResponseMessage responseMessage = await ApiClient.UpdatePost(post);

            Assert.AreEqual(responseMessage.StatusCode, HttpStatusCode.OK);
        }

        [Test]
        public async Task UpdatePost_ShouldBodyEqualsNewString()
        {
            FullPostModel post = new FullPostModel(10, 5, "123", "789");

            string newBody = post.Body;

            HttpResponseMessage responseMessage = await ApiClient.UpdatePost(post);
            FullPostModel fullPost = await responseMessage.Content.ReadAsAsync<FullPostModel>();

            Assert.AreEqual(newBody, fullPost.Body);
        }

        [Test]
        public async Task DeletePost_ShoudReturnSuccessfulCode()
        {
            HttpResponseMessage responseMessage = await ApiClient.DeletePost(8);

            Assert.AreEqual(responseMessage.StatusCode, HttpStatusCode.OK);
        }

        [Test]
        public async Task DeletePost_ShoudReturnNoSuccessfulCode_ByUsingNoExistId()
        {
            HttpResponseMessage responseMessage = await ApiClient.DeletePost(10000);

            Assert.AreEqual(responseMessage.StatusCode, HttpStatusCode.NotFound);
        }

        [Test]
        public async Task DeletePost_ShoudReturnNullDeletedPost()
        {
            HttpResponseMessage responseMessage = await ApiClient.DeletePost(8);
            FullPostModel fullPost = await responseMessage.Content.ReadAsAsync<FullPostModel>();

            Assert.IsNull(fullPost);
        }
    }
}
