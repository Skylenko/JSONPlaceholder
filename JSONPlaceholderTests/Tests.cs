using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using NUnit.Framework;
using JSONPlaceholderAPIClient;

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
        public async Task CreatePost_ShouldReturnSuccessfulCode()
        {
            CreatePostModel post = new CreatePostModel(999, "new title", "same text");

            HttpResponseMessage responseMessage = await APIClient.CreatePosts(post);

            Assert.AreEqual((int)(responseMessage.StatusCode), 201);
        }

        [Test]
        public async Task CreatePost_ShouldReturnFullNewPost()
        {
            CreatePostModel post = new CreatePostModel(999, "new title", "same text");

            HttpResponseMessage responseMessage = await APIClient.CreatePosts(post);
            FullPostModel fullPost = await responseMessage.Content.ReadAsAsync<FullPostModel>();

            Assert.IsNotEmpty(fullPost.ToString());
        }

        [Test]
        public async Task GetPost_ShouldHaveNotNullPost()
        {
            HttpResponseMessage responseMessage = await APIClient.GetPost("1");
            FullPostModel post = await responseMessage.Content.ReadAsAsync<FullPostModel>();

            Assert.IsNotNull(post);
        }

        [Test]
        public async Task GetPost_ShouldHaveSuccessfullCode()
        {
            HttpResponseMessage responseMessage = await APIClient.GetPost("10");

            Assert.AreEqual((int)(responseMessage.StatusCode), 200);
        }

        [Test]
        public async Task GetPost_ShouldHaveNoSuccessfulCode_ByNoExistId()
        {
            HttpResponseMessage responseMessage = await APIClient.GetPost("0");

            Assert.AreEqual((int)(responseMessage.StatusCode), 404);
        }

        [Test]
        public async Task GetPost_ShouldHaveNotEmptyBody()
        {
            HttpResponseMessage responseMessage = await APIClient.GetPost("4");
            FullPostModel post = await responseMessage.Content.ReadAsAsync<FullPostModel>();

            Assert.IsNotEmpty(post.Body);
        }

        [Test]
        public async Task GetPost_ShouldHaveSomeTitle()
        {
            string title = "qui est esse";
            HttpResponseMessage responseMessage = await APIClient.GetPost("2");
            FullPostModel post = await responseMessage.Content.ReadAsAsync<FullPostModel>();

            Assert.AreEqual(post.Title, title);
        }

        [Test]
        public async Task GetAllPosts_ShouldBeNotNullPosts()
        {
            HttpResponseMessage responseMessage = await APIClient.GetAllPosts();
            List<FullPostModel> posts = await responseMessage.Content.ReadAsAsync<List<FullPostModel>>();

            Assert.IsNotNull(posts);
        }

        [Test]
        public async Task GetAllPosts_ShouldBeEqualsNumberOfPosts()
        {
            int numberOfPosts = 100;

            HttpResponseMessage responseMessage = await APIClient.GetAllPosts();
            List<FullPostModel> posts = await responseMessage.Content.ReadAsAsync<List<FullPostModel>>();

            Assert.AreEqual(numberOfPosts, posts.Count);
        }

        [Test]
        public async Task GetAllPosts_ShouldHasSuccessfulCode()
        {
            HttpResponseMessage responseMessage = await APIClient.GetAllPosts();

            Assert.AreEqual((int)(responseMessage.StatusCode), 200);
        }

        [Test]
        public async Task UpdatePost_ShouldReturnFullUpdatePost()
        {
            FullPostModel post = new FullPostModel(10, 5, "123", "789");

            HttpResponseMessage responseMessage = await APIClient.UpdatePost(post);
            FullPostModel fullPost = await responseMessage.Content.ReadAsAsync<FullPostModel>();

            Assert.IsNotEmpty(fullPost.ToString());
        }

        [Test]
        public async Task UpdatePost_ShouldReturnSuccessfulCode()
        {
            FullPostModel post = new FullPostModel(10, 5, "123", "789");

            HttpResponseMessage responseMessage = await APIClient.UpdatePost(post);

            Assert.AreEqual((int)(responseMessage.StatusCode), 201);
        }

        [Test]
        public async Task UpdatePost_ShouldBodyEqualsNewString()
        {
            FullPostModel post = new FullPostModel(10, 5, "123", "789");

            string newBody = post.Body;

            HttpResponseMessage responseMessage = await APIClient.UpdatePost(post);
            FullPostModel fullPost = await responseMessage.Content.ReadAsAsync<FullPostModel>();

            Assert.AreEqual(newBody, fullPost.Body);
        }

        [Test]
        public async Task DeletePost_ShoudReturnSuccessfulCode()
        {
            HttpResponseMessage responseMessage = await APIClient.DeletePost(8);

            Assert.AreEqual((int)(responseMessage.StatusCode), 204);
        }

        [Test]
        public async Task DeletePost_ShoudReturnNoSuccessfulCode_ByUsingNoExistId()
        {
            HttpResponseMessage responseMessage = await APIClient.DeletePost(10000);

            Assert.AreEqual((int)(responseMessage.StatusCode), 404);
        }

        [Test]
        public async Task DeletePost_ShoudNotReturnDeletedPost()
        {
            HttpResponseMessage responseMessage = await APIClient.DeletePost(8);
            FullPostModel fullPost = await responseMessage.Content.ReadAsAsync<FullPostModel>();

            Assert.IsNull(fullPost);
        }
    }
}
