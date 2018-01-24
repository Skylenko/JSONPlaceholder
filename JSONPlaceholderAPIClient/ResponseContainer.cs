using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace JSONPlaceholderAPIClient
{
    public class ResponseContainer<T>
    {
        public CreatePostModel DeserealizedContent { get; set; }
        public CreatePostModel StatusCode { get; set; }
    }
}