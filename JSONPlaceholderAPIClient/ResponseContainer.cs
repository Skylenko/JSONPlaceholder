using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace JSONPlaceholderAPIClient
{
    public class ResponseContainer<T>
    {
        public FullPostModel DeserealizedContent { get; set; }
        public FullPostModel StatusCode { get; set; }
    }
}