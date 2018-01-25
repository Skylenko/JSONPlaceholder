using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace JSONPlaceholderAPIClient
{
    public class ResponseContainer<T>
    {
        public bool DeserealizedContent { get; set; }
        public bool StatusCode { get; set; }
    }
}