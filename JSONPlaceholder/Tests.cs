using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
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
  
        }

        [Test]
        public async Task GetDataFromPost()
        {
            Post post = await APIClient.GetPost("2");
            Assert.IsNotNull(post);
        }
    }
}
